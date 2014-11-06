// vcarddll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "vcarddll.h"
#include <stdlib.h>
#include <stdio.h>
#include "Vcards.h"


// This is an example of an exported variable
EXTERN_C VCARDDLL_API  int  writevcard(VCARD m,char* nk );
EXTERN_C VCARDDLL_API void test(char* n)
{
#define test 1
	VCARD* s=new VCARD();
	memset(s,0,sizeof(VCARD));
	char* sn=(char*)malloc(10000); 
	FAKECARD(s);
	int size;
	size=writevcard(*s,sn);
	memcpy(n,sn,size);
	free(sn);
}


// This is an example of an exported function.

#ifdef __cplusplus


#define isnewviledline(x) strchr((x),';')!=NULL||strchr((x),':')!=NULL
// end Adrass
#define _size(start,end) (end)-(start)
// This is the constructor of a class that has been exported.
// see vcarddll.h for the class definition

EXTERN_C VCARDDLL_API VCARD* getVcard(char* m ,int cardsize ,int* outs)
{
	bool newfiled=false;
	bool end=false;
	if(cardsize==0)
	{
		return nullptr;
	}
	//*outs=0;
	VCARD* nvcard=(VCARD*)malloc(sizeof(VCARD));
	memset(nvcard,0,sizeof(VCARD));
	char y[10000]={'\0'};
	int anchor=0;	
	int numcounter=0;
	bool haspref=false;
	//////////////new line seprator
	for (int s=0;s<cardsize;s++)///5282
	{
		//[filedname];[type]:[value]
		//start with : has no coutme type
		if(m[s]=='\n')
		{
			memcpy(y,(m+anchor),_size(anchor,s));
			//strlen(y):y->line_buff
			//////////////////////////////**//////making sure the next line is real////////**/////////////////////////////////////////////////////
			int line_size=strlen(y);
			int f=0;    
			char* ys=(char*)malloc(cardsize*sizeof(char));//m+s;

			while(f+s<cardsize)      //0x0023c404                              //old//m[s+1+f]!=0)//f<cardsize//)
			{
				if(*(m+(s+1+f))!='\n')
				{
					f++;
				}
				else
				{

					memcpy(ys,m+(s+1),f);                          //s:(\n)start + f:size 
					if(isnewviledline(ys))                         //check next line
					{
						free(ys);                  
						break;
					}
					else
					{

						memcpy(y+line_size,ys,f);

						//s+=f;
						f++;
					}
				}
			}
			//if(ys!=nullptr)free(ys);
			char filed_name[150]={'\0'};
			char filed_value[750]={'\0'};
			char coustm_name[2750]={'\0'};
			//old/char* coustm_vale=(char*)malloc(cardsize);
			char coustm_vale[10000]={'\0'};
			bool h_defend_vale=false;
			bool h_filed_value=false;
			bool h_coustm_vale=false;
			//memset(coustm_vale,0,cardsize);
			char defend_vale[150]={'\0'};  
			//#endif // TEST
			int save=0;
			line_size=strlen(y);
			for (int im=0;im<line_size;im++)
			{

				if((y+im)!=nullptr)
					if (*(y+im)==';')
					{

						haspref=true; //coustm TYpe;
						// f_name = y[anc to l]
						memcpy(filed_name,y,im);


						//printf("*filed_name_name(no base filed):%s\n",filed_name);
						newfiled=true;		

						for (int t=im+1;t<line_size;t++)
						{
							if (y[t]==':') /////start get coustm type
							{
								// f_value = y[l+1 to size]
								memcpy(coustm_name,y+im+1,_size(im,t)-1);// make it t-l only to enc /r
								//printf("*coustm_type_name:%s\n",coustm_name);

								memcpy(coustm_vale,y+(t+1),_size(t,line_size)-2/*+1*/);//make -1 to include \r
								h_coustm_vale=true;
								//printf("*coustm_vale_name:%s\n",coustm_vale);

								break;

							}
							if(y[t]==';')
							{
								// d_value = y[l to t]
								memcpy(defend_vale,y+im+1,_size(im,t)-1); //y+l+1	
								h_defend_vale=true;
								//printf("defend_vale:%s\n",defend_vale);
								im=t;
							}
						}

						break;           /////////////end inner for (t) /////////////////////
					}
					else if(y[im]==':')
					{

						//f_name = y[anc to l];
						memcpy(filed_name,y,im);

						newfiled=true;
						//printf("***filed_name:%s\n",filed_name);
						memcpy(filed_value,y+im+1,_size(im,line_size));
						h_filed_value=true;

						break;///end big for;
					}
					//printf("***filed_value:%s\n",filed_value);

			}
			if(h_defend_vale||h_coustm_vale||h_filed_value)
			{
				end=true;
				if(!strcmp(filed_name,"EMAIL"))
				{

					if (h_filed_value)
						strcpy_s(nvcard->vemail.EMAIL,filed_value);

					else if (h_coustm_vale)
					{
						if(h_defend_vale)
						{
							if(!strcmp(defend_vale,"PREF"))
								nvcard->vemail.PREF=true;
							strcpy_s(nvcard->vemail.prfix,coustm_name);
						}
						else
						{
							if(!strcmp(coustm_name,"PREF"))
								nvcard->vemail.PREF=true;
							else
							{
								nvcard->vemail.PREF=false;
								strcpy_s(nvcard->vemail.prfix,coustm_name);

							}
						}
						strcpy_s(nvcard->vemail.EMAIL,coustm_vale);
					}

					//vm.vemail=email;
				}
				else if(!strcmp(filed_name,"TEL"))
				{


					if (h_filed_value)
					{

						strcpy_s(nvcard->vnumbers[numcounter].numb,filed_value);
					}
					else if (h_coustm_vale)
					{
						if(h_defend_vale)
						{
							if(strcmp(defend_vale,"PREF")&& strcmp(coustm_name,"PREF"))
							{
								strcat_s(defend_vale,";");
								strcpy_s(nvcard->vnumbers[numcounter].prfix,defend_vale);	
								strcat_s(nvcard->vnumbers[numcounter].prfix,coustm_name);

							}

							else if (strcmp(defend_vale,"PREF")|| strcmp(coustm_name,"PREF"))
							{
								nvcard->vnumbers[numcounter].PREF=true;
								if(!strcmp(coustm_name,"PREF"))
								{
									strcpy_s(nvcard->vnumbers[numcounter].prfix,defend_vale);
								}
								else
								{
									strcpy_s(nvcard->vnumbers[numcounter].prfix,coustm_name);
								}

							}
							else
							{
								nvcard->vnumbers[numcounter].PREF=true;

							}



						}
						else
						{

							nvcard->vnumbers[numcounter].PREF=!strcmp(coustm_name,"PREF");
							if(!nvcard->vnumbers[numcounter].PREF)
								strcpy_s(nvcard->vnumbers[numcounter].prfix,coustm_name);
						}
						strcpy_s(nvcard->vnumbers[numcounter].numb,coustm_vale);
					}



					numcounter++;
				}



				else if (!strcmp(filed_name,"PHOTO"))
				{
					if (h_filed_value)
						{

							strcpy_s(nvcard->vnumbers[numcounter].numb,filed_value);
						}

						else if(h_coustm_vale)
						{
							if(h_defend_vale)
								strcpy_s(nvcard->vphoto.ENCODING,defend_vale);

							char* i= (char*)malloc(10000);
							char* m=coustm_vale;
							int s=0;
							while(m++&&*m!=0)
							{
								if(!(*m=='\n'||*m=='\r'||*m==' '))
								{
									*(i+s++)=*m;
								}

							}

							strcpy_s(nvcard->vphoto.type,coustm_name);
							memcpy_s(nvcard->vphoto.photobytes,s,i,s);
							free(i);

							
						}
				}

				else if (!strcmp(filed_name,"N"))
				{

					if(h_defend_vale)
					{
						if (strstr(defend_vale,"CHARSET"))
						{
							strcpy_s(nvcard->vcardname.CHARSET,strchr(defend_vale,'=')+1);
						}
						else if (strstr(coustm_name,"CHARSET"))
						{
							strcpy_s(nvcard->vcardname.CHARSET,strchr(coustm_name,'=')+1);
						}

						if (strstr(coustm_name,"ENCODING"))
						{
							strcpy_s(nvcard->vcardname.ENCODING,strchr(coustm_name,'=')+1);
							nvcard->vcardname.isencoded=true;
						}
						else if (strstr(defend_vale,"ENCODING"))
						{
							strcpy_s(nvcard->vcardname.ENCODING,strchr(defend_vale,'=')+1);
							nvcard->vcardname.isencoded=true;
						}
						else
						{
							nvcard->vcardname.isencoded=false;
						}
					}
					else if(h_coustm_vale)
					{
						if (strstr(coustm_name,"LANGUAGE")||strstr(defend_vale,"CHARSET"))
						{
							strcpy_s(nvcard->vcardname.CHARSET,strchr(coustm_name,'=')+1);
							//nvcard->vcardname.isencoded=true;
						}

					}
					char* pch;
					char* pch1;

					//strchr(coustm_vale,';');
					char* namelist [5]={'\0'};
					int yp=0;


					if (h_filed_value)
						pch=filed_value;
					else
						pch=coustm_vale;
					while (true)
					{

						pch1=strchr(pch,';');
						if(pch1==nullptr)
						{
							namelist[yp++]=pch;
							break;
						}
						*pch1=0;

						namelist[yp++]=pch;
						pch=pch1+1;


					}
					if(yp>=2)
					{
						strcpy_s(nvcard->vcardname.famliy,namelist[0]);
						strcpy_s(nvcard->vcardname.fristname,namelist[1]);
						strcpy_s(nvcard->vcardname.midlename,namelist[2]);
						strcpy_s(nvcard->vcardname.nameprefix,namelist[3]);
					}


					//	coustm_vale=(char*)save;
				}
				else if (!strcmp(filed_name,"FN"))
				{

					if(h_defend_vale)
					{
						if (strstr(defend_vale,"CHARSET"))
							strcpy_s(nvcard->vformatedname.CHARSET,strchr(defend_vale,'=')+1);
						if (strstr(coustm_name,"ENCODING"))
						{
							strcpy_s(nvcard->vformatedname.ENCODING,strchr(coustm_name,'=')+1);
							nvcard->vformatedname.isencoded=true;
						}
						else
							nvcard->vformatedname.isencoded=false;
						strcpy_s(nvcard->vformatedname.fname,coustm_vale);

					}
					else if (h_filed_value)

					{
						nvcard->vformatedname.isencoded=false;
						//strcpy_s(nvcard->vformatedname.CHARSET,"None");
						strcpy_s(nvcard->vformatedname.fname,filed_value);
					}


				}
				h_defend_vale=false;
				h_filed_value=false;
				h_coustm_vale=false;
			}
			s=anchor+line_size;
			anchor=s+1;
			//free(y);



			memset(y,'\0',line_size);

		}

	}

	return nvcard;
}
//Error	2	error C4996: 'strcat': This function or variable may be unsafe. Consider using strcat_s instead. To disable deprecation, use _CRT_SECURE_NO_WARNINGS. See online help for details.	c:\users\xobyx\documents\visual studio 2012\projects\vcard\vcarddll\vcarddll.cpp	212	1	vcarddll



EXTERN_C VCARDDLL_API  int  writevcard(VCARD i,LPSTR vcardbuf )
{
	FILE* a;
	char g[100]={0};

	int m= GetTimeFormatA(LOCALE_USER_DEFAULT,0,NULL,"h--m--s",g,10);
	strcat_s(g,".vcf");
	
	fopen_s(&a,g,"w+");
	fprintf(a,"BEGIN:VCARD\n");
	fprintf(a,"VERSION:2.1\n");
	if(strlen(i.vcardname.fristname)!=0)
	{
		fprintf(a,"%s","N");
		if(strlen( i.vcardname.CHARSET)!=0)//ENCODING=%s:%s;%s;%s;;\n
			fprintf(a,";CHARSET=%s",i.vcardname.CHARSET);
		if(strlen(i.vcardname.ENCODING)!=0)
			fprintf(a,";ENCODING=%s",i.vcardname.ENCODING);
		fprintf(a,":%s;%s;%s;%s;\n",i.vcardname.famliy,i.vcardname.fristname,i.vcardname.midlename,i.vcardname.nameprefix);
	}
	if(strlen(i.vformatedname.fname)!=0)
	{
		if(strlen( i.vformatedname.CHARSET)!=0)
			fprintf(a,"FN;CHARSET=%s;ENCODING=%s:%s\n",i.vformatedname.CHARSET,i.vformatedname.ENCODING,i.vformatedname.fname);
		else
			fprintf(a,"FN:%s\n",i.vformatedname.fname);
	}
	if(strlen(i.vemail.EMAIL)!=0)
	{

		fputs("EMAIL",a);
		if(strlen(i.vemail.prfix)!=0)
		{
			fputc(';',a);
			fputs(i.vemail.prfix,a);

		}
		if(i.vemail.PREF)
			fputs(";PREF",a);

		fputc(':',a);
		fputs(i.vemail.EMAIL,a);
		fputc('\n',a);

	}

	for (int mi=4 ;mi>=0;mi--)
	{
		if(strlen(i.vnumbers[mi].numb)!=0)
		{
			if(i.vnumbers[mi].PREF&&strlen(i.vnumbers[mi].prfix)!=0)
				fprintf(a,"TEL;%s;PREF:%s\n",i.vnumbers[mi].prfix,i.vnumbers[mi].numb);
			else  if(strlen(i.vnumbers[mi].prfix)!=0&&!i.vnumbers[mi].PREF)
				fprintf(a,"TEL;%s:%s\n",i.vnumbers[mi].prfix,i.vnumbers[mi].numb);
		}

	}
	if(strlen(i.vphoto.type)!=0)
	{
		//	fprintf(a,"PHOTO;ENCODING=%s;%s:%s/n",i.vphoto.ENCODING,i.vphoto.type,(char*)i.vphoto.photobytes);
	}
	fprintf(a,"END:VCARD\n");
	int size=	ftell(a);
	if(size!=0)
	{
		char al[1000]={0};
		if(al!=NULL)
		{
			fseek(a,0,SEEK_SET);
			fread(al,size,1,a);
			fclose(a);
			memcpy(vcardbuf,al,size-1);
			
			
		}
	}
	
	return size ;
}

//static char* Decode( char* inputs,wxString EencodeType="UTF-8")
//	{
//
//
//		if (inputs)
//		{
//			char* out;
//			char*bb=(char*)malloc(10000);
//			char* f=inputs;
//			f.Replace("\r","");
//			f.Trim();
//			f.Replace("==","=");
//			if(f.EndsWith("="))
//				f.RemoveLast();
//			const char* input=f;
//			int nf=0;
//			// 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F
//			const char hexVal[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 10, 11, 12, 13, 14, 15};
//
//			for (int i = 0; i <(int) strlen(input); ++i)
//			{
//				if (input[i] == '=')
//				{
//					byte y= 13 -'0';
//					byte g=  ((byte)hexVal[input[++i] - '0']) << 4 ;
//					byte c= (byte) hexVal[input[++i] - '0'];
//					byte eq=g+c;
//					bb[nf++]=eq;
//				}
//				else
//				{
//					bb[nf++]=input[i];
//				}
//			}
//			if(EencodeType=="UTF-8")
//				out=wxString::FromUTF8((char*)bb,nf);
//
//			free(bb);
//
//
//			return out;
//		}
//
//		return "";
//	}

	static size_t Encode (char *s,const wchar_t* In , const char* tocode="UTF-8")
	{

		const char *d;
		if(tocode=="UTF-8");
		//	d=In.ToUTF8();
		else
			return -1;
		char hex[] = "0123456789ABCDEF";
		char *s0 = s;
		int dlen=strlen(d);
		while (dlen--)
		{
			unsigned char c = *d++;
			if (c == ' ')
			{
				*s++='=';
				*s++ =0x32 ;
				*s++ =0x30 ;

			}
			else if (c >= 0x7f || c < 0x20 || c == '_' )
			{
				*s++ = '=';
				*s++ = hex[(c & 0xf0) >> 4];
				*s++ = hex[c & 0x0f];
			}
			else
				*s++ = c;
		}

		return s - s0;
	}

#endif // _cp
