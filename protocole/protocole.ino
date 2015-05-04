#include <SoftwareSerial.h>
bool movedFrom=false;
int entree[9];
int electromagnet=2;
SoftwareSerial portOne(10,11);
bool termineLateral=false;
void setup(){
  Serial.begin(9600);
  portOne.begin(9600);
  pinMode(8, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(electromagnet, OUTPUT);
 
}

void loop()
{
 
  
    int curCol=3;
    int destCol=2;
    
  /*actionMoteur(HIGH, curCol);
  analogWrite(9,0);
  while(!termineLateral&&portOne.available() > 0&&portOne.read()!=1)
 {
   delay(1);
 }*/
actionAimant(true);
//Revenir en butée
actionMoteur(LOW, curCol);
 analogWrite(9,0);
 //Aller à destination 
actionMoteur(HIGH, destCol);
 analogWrite(9,0);
actionAimant(0);
 
 //Revenir en butee
 actionMoteur(LOW, destCol);
 analogWrite(9,0);
   delay(20000);

 }
void actionMoteur(bool b, int deplacement){
  digitalWrite(8,b);
  digitalWrite(11,!b);
  analogWrite(9,255);
 delay(10000*deplacement);

}
void actionAimant(bool b){
  if(b)
  digitalWrite(electromagnet, HIGH);
  else
  digitalWrite(electromagnet, LOW);  
}
//}
