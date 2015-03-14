#include <fix_fft.h>


void setup(){
  pinMode(5,OUTPUT);
  char im[128];
char data[128];
char ecarts[36][64];
char records[36][65];
}
void loop(){
  int static i = 0;
  static long tt;
  int val;
  int sumDelta=0;
int mini=1000000;
int iMin=0;
  
   while (millis() > tt){
	if (i < 128){
	  val = analogRead(A2);
	  data[i] = val / 4 - 128;
	  im[i] = 0;
	  i++;  
	  
	}
	else{
	  fix_fft(data,im,7,0);
	  for (i=0; i< 64;i++){
	     data[i] = sqrt(data[i] * data[i] + im[i] * im[i]);
	  }

	 for(int i=0;i<36;i++){
             for(int j=0;j<64;j++){
               ecarts[i][j]=sqrt((records[i][j]-data[j])^2);
                                   Serial.println(data[j]);
               sumDelta+=ecarts[i][j];
             } 
             if(sumDelta<mini){
               mini=sumDelta;
               iMin=i;}
	}  
}
    tt = millis();
   }
} 


