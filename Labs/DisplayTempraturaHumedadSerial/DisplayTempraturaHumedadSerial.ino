/*
Lector de humedad y temperatura del ambiente con sensor DHT11 y muestra los datos en un display: LCD Controller PCF8574T
Tutorial original censor ambiente: http://www.circuitbasics.com/how-to-set-up-the-dht11-humidity-sensor-on-an-arduino/
Tutorial display: LCD Controller PCF8574T
Author: jsoto25@hotmail.com
Date: 2019/10/29
*/

#include <dht.h>
#include <Wire.h>
#include <math.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,20,4);
dht DHT;
#define DHT11_PIN 7
String strTemperatura;
String strHumedad;
void setup() { 
  Wire.begin();
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  strTemperatura = "";
  strHumedad = "";
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  int chk = DHT.read11(DHT11_PIN);
  if(DHT.temperature >0 && DHT.humidity >0)
  {
    lcd.setCursor(4,0);
    lcd.print("T:");
    lcd.setCursor(7,0);
    strTemperatura = String(DHT.temperature,4);
    lcd.print(DHT.temperature);
    Serial.println(DHT.temperature);
    lcd.setCursor(12,0);
    lcd.print("C");
    lcd.setCursor(4,1);
    lcd.print("H:");
    lcd.setCursor(7,1);
    lcd.print(DHT.humidity);
    Serial.println(DHT.humidity);
    lcd.setCursor(12,1);
    lcd.print("%");
  }
   delay(500);
   digitalWrite(LED_BUILTIN, HIGH);
   delay(500);
   digitalWrite(LED_BUILTIN, LOW);
}
