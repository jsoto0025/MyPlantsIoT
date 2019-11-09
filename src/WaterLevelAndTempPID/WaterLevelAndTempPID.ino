#include <Servo.h>

#define TRINGPIN 9
#define ECHOPIN 10
#define SERVOPIN 2
#define MINDISTANCE 10
#define SERVOOPEN  30
#define SERVOCLOSE  0

long duration;
float distance;
int counterprint = 0;
Servo servo;
int angle =0;

void setup()
{
  pinMode(TRINGPIN, OUTPUT); // Sets the trigPin as an Output
  pinMode(ECHOPIN, INPUT); // Sets the echoPin as an Input
  servo.attach(SERVOPIN);
  Serial.begin(9600); // Starts the serial communication
  servo.write(SERVOOPEN);
  delay(200);
}

void loop()
{
  // Clears the trigPin
  digitalWrite(TRINGPIN, LOW);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(TRINGPIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRINGPIN, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(ECHOPIN, HIGH);
  // Calculating the distance
  distance= duration*0.034/2;
  Serial.println(distance);
  if(distance<MINDISTANCE)
  {
    servo.write(SERVOCLOSE);
    delay(200);
  }

}
