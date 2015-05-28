#include <SoftwareSerial.h>
bool movedFrom=false;
int entree[9];
int electromagnet=2;
SoftwareSerial portOne(10,11);
bool termineLateral=false;
bool demarre=false;
void setup(){
  Serial.begin(9600);
  portOne.begin(9600);
  pinMode(8, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(13,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(electromagnet, OUTPUT);
 
}

void loop()
{
 
if ( Serial.available() ) {
   demarre=true; 
} 
  
if(demarre){
actionMoteurLateral(LOW,curCol);
digitalWrite(8,HIGH);
actionMoteurVertical(HIGH);
digitalWrite(12,LOW);
actionAimant(true);
//Revenir en butée
actionMoteurVertical(LOW);
digitalWrite(12,HIGH);
actionMoteurLateral(HIGH, curCol);
  digitalWrite(8,LOW);
analogWrite(9,0);
 //Aller à destination 
actionMoteurLateral(HIGH, destCol);
actionMoteurVertical(HIGH);
 analogWrite(9,0);
actionAimant(0);
 actionMoteurVertical(LOW);
 actionMoteurLateral(HIGH, destCol);
 analogWrite(9,0);
 
demarre=false;

}
 }
void actionMoteurLateral(bool b, int deplacement){
  digitalWrite(8,b);
  digitalWrite(11,!b);
  analogWrite(9,255);
 delay(10000*deplacement);

}
void actionMoteurVertical(bool b){
  digitalWrite(12,b);
  digitalWrite(13,!b);
  analogWrite(9,255);
  delay(15000);
}
void actionAimant(bool b){
  if(b)
  digitalWrite(electromagnet, HIGH);
  else
  digitalWrite(electromagnet, LOW);  
}
//}
