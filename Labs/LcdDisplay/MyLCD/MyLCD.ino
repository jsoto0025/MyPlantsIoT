#include <LiquidCrystal_I2C.h>

#include <Wire.h>

LiquidCrystal_I2C lcd(0x27,20,4);
void setup()
 {
    lcd.init();
    lcd.backlight();
    lcd.setCursor(0,0);
    lcd.print("Antonita te amo");
 }

void loop()
 {
   delay(1000);
   lcd.setCursor(0,0);
   lcd.print("I Love my family");
   lcd.setCursor(0,1);
   lcd.print("Jsoto");
   delay(1000);
   lcd.clear();
 }
    
