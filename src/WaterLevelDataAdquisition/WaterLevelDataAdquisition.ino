#include <Servo.h>
//I/O pin labeling
#define SERVOPIN 2
#define ULTRASONICTRINGPIN 9
#define ULTRASONICECHOPIN 10

//Constants declaration
#define SERVOOPENEDANGLE 30
#define SERVOCLOSEDEANGLE 0
#define MINWATERDISTANCE 8
#define MAXTEMPERATURE 24

//Constant definitions
const unsigned int NUMREADS = 12;  //Samples to average for smoothing

//Variable definitions
unsigned int val = 0;
String readBuffer = "";
unsigned int sp = 0;
//Smoothing vars (filter electronic noise)
unsigned int readings[NUMREADS] = {0};
unsigned int readIndex = 0;
unsigned int total = 0;
Servo servo;
long duration;
int distance;
float tini = 0;
float tactual = 0;
float tloop = 0;

//Subroutines and functions
unsigned int smooth() { //Recursive moving average subroutine
  total = total - readings[readIndex]; // subtract the last reading
  //readings[readIndex] = getdistance(); // read from the sensor:
  total = total + readings[readIndex]; // add the reading to the total:
  readIndex = readIndex + 1; // advance to the next position in the array:
  if (readIndex >= NUMREADS) {// if we're at the end of the array...
    readIndex = 0; // ...wrap around to the beginning:
  }
  return total / NUMREADS; // calculate the average:
}

//Configuration
void setup() {  
  tini = millis();
  Serial.begin(9600);
  servo.attach(SERVOPIN);
  pinMode(ULTRASONICTRINGPIN, OUTPUT); // Sets the ULTRASONICTRINGPIN as an Output
  pinMode(ULTRASONICECHOPIN, INPUT); // Sets the ULTRASONICECHOPIN as an Input
  servo.write(sp);
  delay(15*SERVOCLOSEDEANGLE);
}

void loop() {
  //Serial.print("Hola");
  //val = smooth();
  if (Serial.available() > 0) {
    readBuffer = Serial.readStringUntil('\n');
    sp = readBuffer.toInt();
    readBuffer = "";
    Serial.flush();
    //analogWrite(ACTUATORPIN, sp * 255.0 / 1023.0);
    Serial.println("SERVOOPENEDANGLE");
    servo.write(sp);
    delay(15*SERVOCLOSEDEANGLE);
    
    //Serial.print(readings[total]);
    //Serial.println(val);
  }
  getdistance();
  tactual=millis();
  Serial.print(tactual);
  Serial.print(",");
  Serial.print(sp);
  Serial.print(",");
  Serial.print(distance);
  Serial.println();
}

//Get the distance from ultrasonic sensor to water pump
void getdistance()
{
  // Clears the ULTRASONICTRINGPIN
  digitalWrite(ULTRASONICTRINGPIN, LOW);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(ULTRASONICTRINGPIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(ULTRASONICTRINGPIN, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(ULTRASONICECHOPIN, HIGH);
  // Calculating the distance
  distance= duration*0.034/2;
  //strdistance = String(distance);
  //return distance;
}
