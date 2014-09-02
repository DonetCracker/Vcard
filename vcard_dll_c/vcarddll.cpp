// vcarddll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "vcarddll.h"
#include <stdlib.h>
#include <stdio.h>
#include"Vcards.h"


// This is an example of an exported variable


VCARDDLL_API int nvcarddll=0;




#define isnewviledline(x) strchr((x),';')!=NULL||strchr((x),':')!=NULL
// end Adrass
#define _size(start,end) (end)-(start)
// This is the constructor of a class that has been exported.
// see vcarddll.h for the class definition

EXTERN_C VCARDDLL_API VCARD* getVcard(char* m ,int cardsize ,int* outs)
{
	bool newfiled=false;


	bool end=false;
	VCARD* nvcard=new VCARD();
	char y[10000]={'\0'};
	int anchor=0;	
	int numcounter=0;
	bool haspref=false;
	for (int s=0;s<cardsize;s++)///5282
	{
		
		//char* ys=(char*)malloc(cardsize*sizeof(char));
		//[filedname];[type]:[value]
		//start with : has no coutme type
		if(m[s]=='\n')
		{
			memcpy(y,(m+anchor),_size(anchor,s));
			//strlen(y):y->line_buff
			int line_size=strlen(y);
			int f=0;                                                //m+s;
			///making sure the next line is real
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
						memset(ys,0,strlen(ys));                   
						break;
					}
					else
					{

						memcpy(y+line_size,ys,f);
						//strcat(y,ys);
						//s+=f;
						f++;
					}
				}
			}
			//#ifdef TEST
			char filed_name[150]={'\0'};
			char filed_value[750]={'\0'};
			char coustm_name[2750]={'\0'};
                        //old/char* coustm_vale=(char*)malloc(cardsize);
                        char coustm_vale[]=new char[cardsize)];
			memset(coustm_vale,0,cardsize);
			char defend_vale[150]={'\0'};  
			//#endif // TEST
			int save=0;
			line_size=strlen(y);
			for (int l=0;l<line_size;l++)
			{
				if (y[l]==';')
				{
					haspref=true; //coustm TYpe;
					// f_name = y[anc to l]
					memcpy(filed_name,y,l);

					//printf("*filed_name_name(no base filed):%s\n",filed_name);
					newfiled=true;		

					for (int t=l+1;t<line_size;t++)
					{
						if (y[t]==':') /////start get coustm type
						{
							// f_value = y[l+1 to size]
							memcpy(coustm_name,y+l+1,_size(l,t)-1);// make it t-l only to enc /r
							//printf("*coustm_type_name:%s\n",coustm_name);

							memcpy(coustm_vale,y+(t+1),_size(t,line_size)-2/*+1*/);//make -1 to include \r
							//printf("*coustm_vale_name:%s\n",coustm_vale);
							if(!strcmp(filed_name,"EMAIL"))
							{
								strcpy_s(nvcard->vemail.EMAIL,coustm_vale);
								if(!strcmp(coustm_name,"PREF"))
									nvcard->vemail.PREF=true;
								else
									nvcard->vemail.PREF=false;
								strcpy_s(nvcard->vemail.prfix,defend_vale);
								//vm.vemail=email;
							}
							else if(!strcmp(filed_name,"TEL"))
							{

								if(strlen(defend_vale)==0)
								{

									nvcard->vnumbers[numcounter].PREF=false;
									strcpy_s(nvcard->vnumbers[numcounter].prfix,coustm_name);

								}
								else
								{
									nvcard->vnumbers[numcounter].PREF=true;///if coustm name  ==pref
									strcpy_s(nvcard->vnumbers[numcounter].prfix,defend_vale);

								}
								strcpy_s(nvcard->vnumbers[numcounter].numb,coustm_vale);
								//vm.vnumbers[numcounter++]=number;
								numcounter++;
							}



							else if (!strcmp(filed_name,"PHOTO"))
							{

								if(strlen(defend_vale)!=0)
								{
									nvcard=(VCARD*)realloc(nvcard,sizeof( VCARD) + strlen(coustm_vale));
									//nvcard = (VCARD*)malloc(sizeof( VCARD) + strlen(coustm_vale));

									memcpy( nvcard->vphoto.photobytes,coustm_vale,strlen(coustm_vale));
									strcpy_s(nvcard->vphoto.ENCODING,defend_vale);
									strcpy_s(nvcard->vphoto.type,coustm_name);
									int yy=sizeof(*nvcard);
								}

								*outs=strlen(coustm_vale);
							}

							else if (!strcmp(filed_name,"N"))
							{

								if(strlen(defend_vale)!=0)
								{
									if (strstr(defend_vale,"CHARSET"))
										strcpy_s(nvcard->vcardname.CHARSET,strchr(defend_vale,'=')+1);
									if (strstr(coustm_name,"ENCODING"))
									{
										strcpy_s(nvcard->vcardname.ENCODING,strchr(coustm_name,'=')+1);
										nvcard->vcardname.isencoded=true;
									}
									else
										nvcard->vcardname.isencoded=false;
										/*
									char* pch;

									//strchr(coustm_vale,';');
									char* str [14];
									int yp=0;

									save=(int)coustm_vale;
									pch=strchr(coustm_vale,';');
									while (pch)
									{
										pch=strchr(coustm_vale,';');
										if(pch==nullptr)
											break;
										*pch=0;
										str[yp++]=coustm_vale;
										coustm_vale=pch+1;

									}
									strcpy_s(nvcard->vcardname.nameprefix,str[0]);
									strcpy_s(nvcard->vcardname.fristname,str[1]);
									strcpy_s(nvcard->vcardname.famliy,str[2]);
									****old***/
									char* pch;
									char* pch1;

									//strchr(coustm_vale,';');
									char* namelist [5];
									int yp=0;
									
									//save=(int)filed_value;
									pch=coustm_vale;
									while (true)
									{
										
										pch1=strchr(pch,';');
											if(pch1==nullptr)
											break;
									   *pch1=0;
									
										namelist[yp++]=pch;
										pch=pch1+1;
									
								
									}
									strcpy_s(nvcard->vcardname.famliy,str[0]);
									strcpy_s(nvcard->vcardname.fristname,str[1]);
									strcpy_s(nvcard->vcardname.nameprefix,str[2]);

								}

							//	coustm_vale=(char*)save;
							}
							else if (!strcmp(filed_name,"FN"))
							{

								if(strlen(defend_vale)!=0)
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

								
							}
							break;

						}
						if(y[t]==';')
						{
							// d_value = y[l to t]
							memcpy(defend_vale,y+l+1,_size(l,t)-1); //y+l+1	
							//printf("defend_vale:%s\n",defend_vale);
							l=t;
						}
					}

					break;           /////////////end inner for (t) /////////////////////
				}
				else if(y[l]==':')
				{

					//f_name = y[anc to l];
					memcpy(filed_name,y,l);

					newfiled=true;
					//printf("***filed_name:%s\n",filed_name);
					memcpy(filed_value,y+l+1,_size(l,line_size));
					if (!strcmp(filed_name,"FN"))
					{
						nvcard->vformatedname.isencoded=false;
						//strcpy_s(nvcard->vformatedname.CHARSET,"None");
						strcpy_s(nvcard->vformatedname.fname,filed_value);
					}
					if (!strcmp(filed_name,"N"))
					{
						char* pch;
						char* pch1;

									//strchr(coustm_vale,';');
									char* namelist [5];
									int yp=0;
									
									//save=(int)filed_value;
									pch=filed_value;
									while (true)
									{
										
										pch1=strchr(pch,';');
											if(pch1==nullptr)
											break;
									   *pch1=0;
									
										namelist[yp++]=pch;
										pch=pch1+1;
									
								
									}
									strcpy_s(nvcard->vcardname.famliy,str[0]);
									strcpy_s(nvcard->vcardname.fristname,str[1]);
									strcpy_s(nvcard->vcardname.nameprefix,str[2]);



						nvcard->vcardname.isencoded=false;
						
					}
					//printf("***filed_value:%s\n",filed_value);
					if(!strcmp( filed_name,"END"))
					{
						end=true;
						//newfiled=false;
						//printf("\n************************\n");
						//
					}
					break;///end big for;
				}
			}
			s=anchor+line_size;
			anchor=s+1;
			//free(y);

			delete(coustm_vale);
			memset(y,'\0',line_size);

		}

	}

	return nvcard;
}
//Error	2	error C4996: 'strcat': This function or variable may be unsafe. Consider using strcat_s instead. To disable deprecation, use _CRT_SECURE_NO_WARNINGS. See online help for details.	c:\users\xobyx\documents\visual studio 2012\projects\vcard\vcarddll\vcarddll.cpp	212	1	vcarddll

EXTERN_C VCARDDLL_API char* getvcardstring(VCARD i)
{

	char* y=(char*)malloc(6000);
	char* trues="true";
	char* falses="false";
	bool isd=i.vnumbers[0].PREF;
	sprintf_s(y,150,"*name*-%s\t-*number*-%s--%s--(%s)",i.vformatedname,i.vnumbers[0].prfix,i.vnumbers[0].numb,isd==true?trues:falses);

	return y;
}



#endif // _cp
