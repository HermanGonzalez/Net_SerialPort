
const int LedPinYellow = 11;
const int LedPinRed = 12;
const int LedPinGreen =13;
const int LedPinWhite = 10;
const int InputPin = 2;
int input = 0;
int wait = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(LedPinYellow,OUTPUT);
  pinMode(LedPinRed,OUTPUT);
  pinMode(LedPinGreen,OUTPUT);
  pinMode(LedPinWhite,OUTPUT);
  pinMode(InputPin,INPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  String receiveVal;

  input = digitalRead(InputPin);     
  
  if(input == HIGH){
    Serial.write("open");
    digitalWrite(LedPinWhite, 
  }else{
    digitalWrite(LedPinWhite, 0);
  }
  
  //Look if there's something in the serial port
  if(Serial.available() > 0){
    //read the serial port content
    receiveVal = Serial.readString();
     
    if(receiveVal.equals("green")){
       digitalWrite(LedPinGreen, 1);   
    }else{
       digitalWrite(LedPinGreen, 0);
    }

    if(receiveVal.equals("red")){
      digitalWrite(LedPinRed, 1);   
    }else{
      digitalWrite(LedPinRed, 0);    
    }

    if(receiveVal.equals("yellow")){
       digitalWrite(LedPinYellow, 1);   
    }else{
       digitalWrite(LedPinYellow, 0);   
    }

  }

  delay(50);
}
