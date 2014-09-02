#ifndef _Vcards_h_

#define _Vcards_h_

#define MAX_NUM_SIZE 20
struct Number
{
	char numb[MAX_NUM_SIZE];
	char prfix [10];
	bool PREF;
}number;
struct Name
{
 char CHARSET[10];
 char ENCODING[20];
 char nameprefix[150];
 char famliy[150];
 char fristname[150];
 bool isencoded;

}fname;
struct formatedname
{
 char CHARSET[10];
 char ENCODING[20]; 
char fname[150];
bool isencoded;

}ffname;
struct  Photo
{
	char ENCODING[20];
	char type[10];
	char photobytes[];
}photo,*ph;
struct Email
{
	char EMAIL[30];
	char prfix [10];
	bool PREF;
}email;
typedef struct 
{
Name vcardname;
formatedname vformatedname;
Number vnumbers[5];

Email vemail;
Photo vphoto ;
}VCARD;


struct VCARDHEDER
{
	char header[10];
	int vcardcount;
	int filesize;
	

}vcardheader; 








#endif // !_Vcards_h_
