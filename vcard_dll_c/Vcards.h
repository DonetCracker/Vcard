#ifndef _Vcards_h_

#define _Vcards_h_

#define cmemcopy(d,s)  memset(d,0,strlen(d));\
	memcpy(d,s,strlen(s));
#define FAKECARD(r)	cmemcopy(r->vcardname.famliy," AlAmeen");\
	cmemcopy(r->vcardname.fristname,"Oby");\
	cmemcopy(r->vcardname.nameprefix,"Mr.");\
	cmemcopy(r->vcardname.midlename,"Magid");\
	cmemcopy(r->vemail.EMAIL,"xobyxm@hotmail.com");\
	cmemcopy(r->vformatedname.fname,"Mr.oby Magid AlAmeen");\
	cmemcopy(r->vnumbers[0].numb,"0913011221");\
	r->vnumbers[0].PREF=true;\
	cmemcopy(r->vnumbers[0].prfix,"X-Home");\
	r->vemail.PREF=true;

#define MAX_NUM_SIZE 50

struct Number
{
	char numb[MAX_NUM_SIZE];
	char prfix [20];
	bool PREF;
}number;
struct Name
{
 char CHARSET[10];
 char ENCODING[20];
 char nameprefix[150];
 char famliy[250];
 char fristname[250];
 char midlename[250];
 bool isencoded;

}fname;
struct formatedname
{
 char CHARSET[10];
 char ENCODING[20]; 
char fname[350];
bool isencoded;

}ffname;
struct  Photo
{
	char ENCODING[20];
	char type[20];
	char photobytes[20000];
	
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
