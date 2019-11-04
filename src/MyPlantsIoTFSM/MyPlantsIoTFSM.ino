#include <dht.h>
#include <Wire.h>
#include <math.h>
#include <LiquidCrystal_I2C.h>
#include <Servo.h>

//FSM States
#define SSOFOFF 0 // State with Servo OPENED  position and fan OFF
#define SSOFON 1 // State with Servo OPENED  position and fan ON
#define SSCFON 2 // State with Servo CLOSED  position and fan ON
#define SSCFOFF 3 // State with Servo CLOSED  position and fan OFF

//I/O Pin Labeling
#define SERVOPIN 2
#define ULTRASONICTRINGPIN 9
#define ULTRASONICECHOPIN 10
#define DHT11PIN 7

//Constants declaration
#define SERVOOPENEDANGLE 0
#define SERVOCLOSEDEANGLE 50
#define MINWATERDISTANCE 10
#define MAXTEMPERATURE 24

//Variables declaration
unsigned int state = SSOFOFF;
unsigned int nextstate = SSOFOFF;
String strtemperatura;
String strhumedad;
String strdistance;
long duration;
int distance;
String salidaserial = "";
Servo servo;
LiquidCrystal_I2C lcd(0x27,20,4);
dht DHT;
unsigned long tact = 0; //Actual time (tact) as unsigned long
unsigned long tini = 0; //Initial time (tini) as unsigned long
unsigned long trel = 0; //Relative time (trel) as unsigned long
float temperature;
float humidity;
String strstate;

void setup() {

  Wire.begin();
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  strtemperatura = "";
  strhumedad = "";
  strdistance = "";
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(ULTRASONICTRINGPIN, OUTPUT); // Sets the ULTRASONICTRINGPIN as an Output
  pinMode(ULTRASONICECHOPIN, INPUT); // Sets the ULTRASONICECHOPIN as an Input
  servo.attach(SERVOPIN);
  tini = millis();
  DHT.read11(DHT11PIN);
}

void loop() {
  // put your main code here, to run repeatedly:
  tact = millis(); //Refresh always actual time
  getnextstate();
  Serial.print(state);
  Serial.print(state);
  switch(state)
  {
    
    case SSOFOFF:
      {
        trel = tact - tini;
        if(state!=nextstate)
        {
          state = nextstate;
          openservo(true);
          poweronfan(false);
          tini = millis();
        }
      }
    break;
    case SSOFON:
      {
        trel = tact - tini;
        if(state!=nextstate)
        {
          state = nextstate;
          openservo(false);
          poweronfan(true);
          tini = millis();
        }
      }
    break;
    case SSCFON:
      {
        trel = tact - tini;
        if(state!=nextstate)
        {
          state = nextstate;
          openservo(false);
          poweronfan(true);
          tini = millis();
        }
      }
    break;
    case SSCFOFF:
      {
        trel = tact - tini;
        if(state!=nextstate)
        {
          state = nextstate;
          openservo(false);
          poweronfan(false);
          tini = millis();
        }
      }
    break;
  }
  printlcd();
  //printserial();
}

//Get Next State id
void getnextstate(){
  getdistance();
  gettemperature();
  if((distance>MINWATERDISTANCE)&(temperature>MAXTEMPERATURE))
  {
    nextstate = SSOFON;
  }
  if((distance>MINWATERDISTANCE)&(temperature<MAXTEMPERATURE))
  {
    nextstate = SSOFOFF;
  }
  if((distance<MINWATERDISTANCE)&(temperature<MAXTEMPERATURE))
  {
    nextstate = SSCFOFF;
  }
  if((distance<MINWATERDISTANCE)&(temperature>MAXTEMPERATURE))
  {
    nextstate = SSCFON;
  }
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
  strdistance = String(distance);
}

//Gets the ambient temperature
void gettemperature()
{
  temperature = DHT.temperature;
  humidity = DHT.humidity;
}

//Open/Close water pump
void openservo(bool openservo)
{
  if(openservo)
  {
      servo.write(SERVOOPENEDANGLE);
      delay(15*SERVOCLOSEDEANGLE);
  }
  else
  {
      servo.write(SERVOCLOSEDEANGLE);
      delay(15*SERVOCLOSEDEANGLE);
  }
}

//Power ON Fan
void poweronfan(bool powerfan)
{
  
}

//Prints data to LCD
void printlcd()
{
  lcd.setCursor(2,0);
  lcd.print("T:");
  lcd.setCursor(5,0);
  strtemperatura = String(temperature,4);
  strhumedad = String(humidity,4);
  lcd.print(temperature);
  lcd.setCursor(10,0);
  lcd.print("C");
  lcd.setCursor(2,1);
  lcd.print("H:");
  lcd.setCursor(5,1);
  lcd.print(humidity);
  lcd.setCursor(10,1);
  lcd.print("%");
  strdistance = String(distance);
  lcd.setCursor(12,0);
  lcd.print("     ");
  lcd.setCursor(12,0);
  lcd.print(distance);
  lcd.print("CM");
}

//Sends data to serial port
void printserial()
{
  strstate = String(state,1);
  salidaserial = strtemperatura + "," + strhumedad + "," + strdistance + "," + strstate + "\r\n";
  Serial.print(salidaserial);
}
