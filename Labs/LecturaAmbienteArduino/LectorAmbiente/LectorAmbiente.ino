#include <BH1750FVI.h>

/*/

Lector ambiente con sensor DHT11
Tutorial original: http://www.circuitbasics.com/how-to-set-up-the-dht11-humidity-sensor-on-an-arduino/
Author: jsoto25@hotmail.com
Date: 2019/10/26

*/
#include <dht.h>
#include <Wire.h>
//#include <BH1750FVI.h> // Sensor Library
//#include <BH1750.h>
#include <math.h>
//uint8_t ADDRESSPIN = 13;
//BH1750FVI::eDeviceAddress_t DEVICEADDRESS = BH1750FVI::k_DevAddress_H;
//BH1750FVI::eDeviceMode_t DEVICEMODE = BH1750FVI::k_DevModeContHighRes;
// Create the Lightsensor instance
//BH1750FVI LightSensor(ADDRESSPIN, DEVICEADDRESS, DEVICEMODE);
//BH1750FVI LightSensor;
//Device_Address_H "0x5C";
//BH1750::Mode modo = BH1750::CONTINUOUS_LOW_RES_MODE;

dht DHT;


#define DHT11_PIN 7
// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  Wire.begin();
  Serial.begin(9600);//Para el ejemplo del ambiente
  //Serial.begin(57600); //Para el ejemplo de la luminosidad, no funiona el ejemplo del ambiente con este valor
  //Serial.begin(115200);
  //LightSensor.begin();  
  //lightMeter.configure(0x10);
  //lightMeter.begin(modo);
  
  Serial.println("Running...");

}

// the loop function runs over and over again forever
void loop() {
  int chk = DHT.read11(DHT11_PIN);
  int i;
  uint16_t val=0;
  
  if(DHT.temperature >0 && DHT.humidity)
  {
    Serial.print("Temperature = ");
    Serial.println(DHT.temperature);
    Serial.print("Humidity = ");
    Serial.println(DHT.humidity);
  }

  //uint16_t lux = LightSensor.GetLightIntensity();
  //uint16_t lux = lightMeter.readLightLevel(true);
  //Serial.print("Light: ");
  //Serial.println(lux);
   
   delay(1000);                     // wait for a second
}
