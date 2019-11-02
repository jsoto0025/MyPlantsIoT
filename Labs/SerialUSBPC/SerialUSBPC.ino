
int counter;
void setup() {
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {

  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on 
  delay(500);                       // wait for half a second
  int bytesSent = Serial.write("hello");//send the string "hello" and return the length of the string.
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off 
  delay(500);                       // wait for half a second

  counter++;
}
