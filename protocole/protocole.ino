#include <SoftwareSerial.h>
bool movedFrom=false;
int entree[9];
SoftwareSerial portOne(10,11);
bool termineLateral=false;
void setup(){
  Serial.begin(9600);
  portOne.begin(9600);
  pinMode(8, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(5,OUTPUT);
}

void loop()
{
 
  /*portOne.listen();
  if (portOne.available() > 0&&portOne.read()==1) {
     for(int i=0;i<4;i++){
     entree[i]=Serial.read();
     }
    int curCol=(int)entree[1];
    int destCol=(int)entree[3];
    */
    int curCol=2;
    int destCol=3;
    
  actionMoteur(HIGH, curCol);
  analogWrite(9,0);
  while(!termineLateral&&portOne.available() > 0&&portOne.read()!=1)
 {
   delay(1);
 }
actionAimant(1);
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
 delay(7500*deplacement);

}
void actionAimant(bool b){
  digitalWrite(5, b);
}
//}
