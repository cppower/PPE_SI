/**
* chess.cpp ®Victor AMBLARD
* PPE SI 2014-2015
* La fonction prend en paramètres 4 entiers : curX, curY, xDestination, yDestination et retourne true ou false 
*
**/

#include <iostream>
#include <iomanip>
#include <cctype>
#include <cmath>
#define TOUR 'T'
#define ROI 'K'
#define PION 'P'
#define FOU 'F'
#define REINE 'R'
#define CAVALIER 'C'
#define EMPTY '.'
#define NORTH 100
#define NORTH_EAST 101
#define EAST 102
#define SOUTH_EAST 103
#define SOUTH 104
#define SOUTH_WEST 105
#define WEST 106
#define NORTH_WEST 107
#define CAVALIER_1 110
#define CAVALIER_2 111
#define CAVALIER_3 112
#define CAVALIER_4 113

#define NO_MOVE 199





using namespace std;

char chessboard [9][9];
int curX=1;
int curY=1;
//By convention, blacks are in lower case, whites in upper

void initChessBoard(){
for(int i=3;i<=6;i++){
	for(int j=1;j<=8;j++){
		chessboard[i][j]=EMPTY;
		}
	}
for(int j=1;j<=8;j++){
	chessboard[2][j]=PION;
	chessboard[7][j]=tolower(PION);
}
chessboard[8][1]=tolower(TOUR);
chessboard[8][8]=tolower(TOUR);
chessboard[1][1]=TOUR;
chessboard[1][8]=TOUR;

chessboard[8][2]=tolower(CAVALIER);
chessboard[8][7]=tolower(CAVALIER);
chessboard[1][2]=CAVALIER;
chessboard[1][7]=CAVALIER;

chessboard[8][3]=tolower(FOU);
chessboard[8][6]=tolower(FOU);
chessboard[1][3]=FOU;
chessboard[1][6]=FOU;

chessboard[8][5]=tolower(ROI);
chessboard[1][5]=ROI;

chessboard[8][4]=tolower(REINE);
chessboard[1][4]=REINE;

/* What the chessboard should look like after init */
/**
*8 t c f r k f c t
*7 p p p p p p p p
*6 . . . . . . . .
*5 . . . . . . . .
*4 . . . . . . . .
*3 . . . . . . . .
*2 P P P P P P P P
*1 T C F K R F C T
*  a b c d e f g h 
**/

}
void printChessBoard(){
	for(int i=8;i>=1;i--){
		for(int j = 1;j<=8;j++){
			cout<<chessboard[i][j]<<"\t";
		}
		cout<<"\n\n";
	}
}
bool passageLibre(int xArr, int yArr, int direction){
	
	if(direction==NORTH){
		for(int i=curX-1;i>xArr;i--){
			if(chessboard[i][curY]!=EMPTY)
				return false;
		}
		return true;
	}
	if(direction==SOUTH){
		for(int i=curX+1;i<xArr;i++){
			if(chessboard[i][curY]!=EMPTY)
				return false;
		}
		return true;
	}
	if(direction==WEST){
		for(int i=curY-1;i>yArr;i--){
			if(chessboard[curX][i]!=EMPTY)
				return false;
		}
		return true;
	}
	if(direction==EAST){
		for(int i=curY+1;i<yArr;i++){
			if(chessboard[curX][i]!=EMPTY)
				return false;
		}
		return true;
	}
	if(direction==NORTH_WEST){
		for(int i=curY+1;i<yArr;i++){
			for(int j=curX+1;j<xArr;j++){
			if(chessboard[j][i]!=EMPTY)
				return false;
		 }
		}
		return true;
	}
	if(direction==NORT_EAST){
		for(int i=curY+1;i<yArr;i++){
			if(chessboard[curX][i]!=EMPTY)
				return false;
		}
		return true;
	}
}
int direct(int deltaX, int deltaY){
	if(deltaX==0&&deltaY==0)
		return NO_MOVE;
	if(deltaX==0){
		if(deltaY<0){
			return NORTH;
		}else{
			return SOUTH;
		}
	}else if (deltaY==0){
		if(deltaX<0){
			return WEST;
		}else{
			return EAST;
		}
	}else{
		if(deltaX==deltaY&&deltaX>0){
			return SOUTH_EAST;
		}else if (deltaX==deltaY&&deltaX<0){
			return NORTH_WEST;
		}else if(deltaX==-deltaY&&deltaX>0){
			return NORTH_EAST;
		}else if(deltaX==-deltaY&&deltaX<0){
			return SOUTH_WEST;
		}else if(deltaX==2&&deltaY==1){
			return CAVALIER_1;
		}else if (deltaX==-2&&deltaY==1){
			return CAVALIER_2;
		}else if (deltaX==2&&deltaY==-1){
			return CAVALIER_3;
		}else if(deltaX==-2&&deltaY==-1){
			return CAVALIER_4;
		}
	}
}
bool goodMove(int xArr, int yArr){
	if(chessboard[curX][curY]==EMPTY||curX<=0||curY<=0)
			return false;
	int deltaX=xArr-curX;
	int deltaY=yArr-curY;
	int norme = (int)sqrt(deltaX*deltaX+deltaY*deltaY);
	if(!isupper(chessboard[curX][curY])){
		deltaX=-deltaX;
	//#petitedouille
	deltaY=-deltaY;}
	int direction = direct(deltaY, deltaX);	
	char piece=chessboard[curX][curY];
	if(piece==PION){
		if(direction!=SOUTH||norme>2)
			return false;
	}else if(piece==TOUR){
		if(direction!=NORTH&&direction!=SOUTH&&direction!=EAST&&direction!=WEST)
			return false;
	}else if(piece==ROI){
		if(norme!=1)
			return false;
	}else if(piece==FOU){
		if(direction!=NORTH_WEST&&direction!=NORTH_EAST&&direction!=SOUTH_EAST&&direction!=SOUTH_WEST)
			return false;
	}else if(piece==CAVALIER){
		if(direction!=CAVALIER_1&&direction!=CAVALIER_2&&direction!=CAVALIER_3&&direction!=CAVALIER_4)
			return false;
	}
	if(passageLibre(xArr, yArr, direction))
		return true;
	return false;
}

int main(int argc, char *argv[]){ //Sisi
	initChessBoard();
	printChessBoard();
	while(0==0){
		int a;
		int b,c,d;
		cin>>a>>b;
		cin>>c>>d;
		curX=a;
		curY=b;
		cout<<chessboard[a][b]<<"\n";
		if(goodMove(c,d)){
			chessboard[c][d]=chessboard[a][b];
			chessboard[a][b]=EMPTY;
			printChessBoard();
		}else{
			cout<<"Mouvement invalide :(";
		}
	}		
} 