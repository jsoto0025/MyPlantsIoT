#include <Servo.h>
#include <dht.h>
#include <Wire.h>

#define TRINGPIN 9
#define ECHOPIN 10
#define SERVOPIN 2
#define MINDISTANCE 10
#define SERVOOPEN  30
#define SERVOCLOSE  0
#define DHT11PIN 7
#define IN1 11
#define IN2 12
#define MAXTEMPERATURE 24
#define DHT11PIN 7

long duration;
float distance;
int counterprint = 0;
Servo servo;
int angle =0;
dht DHT;

void setup()
{
  Wire.begin();
  pinMode(TRINGPIN, OUTPUT); // Sets the trigPin as an Output
  pinMode(ECHOPIN, INPUT); // Sets the echoPin as an Input
  servo.attach(SERVOPIN);
  Serial.begin(9600); // Starts the serial communication
  servo.write(SERVOOPEN);
  
  delay(200);
  pinMode(IN1,OUTPUT);
  pinMode(IN2,OUTPUT);
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
  int chk = DHT.read11(DHT11PIN);
  if(DHT.temperature >0 && DHT.humidity >0)
  {
    
    if(DHT.temperature>MAXTEMPERATURE)
    {
      Serial.println(DHT.temperature);
      digitalWrite(IN1,HIGH);
      digitalWrite(IN2,LOW);
      delay(200);
    }else{
      digitalWrite(IN1,LOW);
      digitalWrite(IN2,LOW);
      delay(200);
    }
  }

}
