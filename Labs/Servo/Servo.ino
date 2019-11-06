
#include <Servo.h>
int servoport = 2;
int servopulse = 1500;
Servo servo;
void setup() {
  // put your setup code here, to run once:
  servo.attach(2);
  servo.write(0);
  delay(30);
}

void loop() {
  /*
  for(int pos=0;pos<90;pos++)
  {
    servo.write(pos);
  delay(15);
  }
  */
  servo.write(180);
  delay(60*180);
  servo.write(0);
  delay(60*180);
}
