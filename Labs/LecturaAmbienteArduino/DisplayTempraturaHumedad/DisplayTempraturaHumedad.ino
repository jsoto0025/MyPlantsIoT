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

void setup() { 
  Wire.begin();
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
}

void loop() {
  int chk = DHT.read11(DHT11_PIN);
  if(DHT.temperature >0 && DHT.humidity >0)
  {
    lcd.setCursor(4,0);
    lcd.print("T:");
    lcd.setCursor(7,0);
    lcd.print(DHT.temperature);
    lcd.setCursor(4,1);
    lcd.print("H:");
    lcd.setCursor(7,1);
    lcd.print(DHT.humidity);
  }
   delay(1000);
}
