#include <Servo.h>
#include <dht.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>

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
LiquidCrystal_I2C lcd(0x27,20,4);
int tini = 0;
int tact = 0;
float temperature = 0;
float humidity = 0;
int angleservo;


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
  lcd.init();
  lcd.backlight();
  tini = millis();
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
  if(distance<MINDISTANCE)
  {
    angleservo = SERVOCLOSE;
    servo.write(angleservo);
    delay(200);
  }else
  {
    angleservo = SERVOOPEN;
    servo.write(angleservo);
    delay(200);
  }
  int chk = DHT.read11(DHT11PIN);
  temperature = DHT.temperature;
  humidity = DHT.humidity;
  if(DHT.temperature >0 && humidity >0)
  {
    
    if(temperature>MAXTEMPERATURE)
    {
      digitalWrite(IN1,LOW);
      digitalWrite(IN2,HIGH);
      delay(200);
    }else{
      digitalWrite(IN1,LOW);
      digitalWrite(IN2,LOW);
      delay(200);
    }
  }
  
  tact = millis();
  
  lcd.setCursor(4,0);
  lcd.print("T:");
  lcd.setCursor(6,0);
  lcd.print(temperature);
  lcd.setCursor(0,1);
  lcd.print("H:");
  lcd.setCursor(2,1);
  lcd.print(humidity);
  lcd.setCursor(9,1);
  lcd.print("H:");
  lcd.setCursor(11,1);
  lcd.print(distance);
  lcd.setCursor(15,1);
  delay(1000);
  Serial.print(tact);
  Serial.print(",");
  Serial.print(angleservo);
  Serial.print(",");
  Serial.print(temperature);
  Serial.print(",");
  Serial.print(distance);
  Serial.println();
}
