using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace warpiton
{
    public class Csvcard
    {

        private Vcard IsaVcard { get; set; }


        public Csvcard(Vcard vcard)
        {
            foreach (var variable in vcard.vnumbers)
            {
                if (!string.IsNullOrEmpty(variable.numb))
                {
                    NumberlList.Add(new Number(variable));
                }


            }
            IsaVcard = vcard;

            if (!string.IsNullOrEmpty(IsaVcard.vcardname.fristname))
                FullName = new Name(IsaVcard);
            if (!string.IsNullOrEmpty(IsaVcard.vemail.EMAIL))
                Emails.Add(new Emailb(IsaVcard));

            if (!string.IsNullOrEmpty(IsaVcard.vphoto.type))
                PicturPhoto = new Photo(IsaVcard);
            Formatedname = new Ffname(IsaVcard);

        }


        public Photo PicturPhoto;
        public Name FullName;
        public Ffname Formatedname;
        public List<Number> NumberlList = new List<Number>();
        public List<Emailb> Emails = new List<Emailb>();


        public class Photo
        {
            public Photo(Vcard smVcard)
            {
                Encodings = smVcard.vphoto.ENCODING;
                char[] encodingchars = smVcard.vphoto.pbData;
                Decodedbytes = Convert.FromBase64CharArray(encodingchars, 0, encodingchars.Length);
                Itype = smVcard.vphoto.type;

            }

            private string _path;
            public string Encodings;
            public byte[] Decodedbytes;
            public string Itype;

            public Image GetImage()
            {
                if (!string.IsNullOrEmpty(_path) && new FileInfo(_path).Exists) return Image.FromFile(_path);
                _path = DateTime.Now.ToBinary() + "temp." + Itype;
                File.WriteAllBytes(_path, Decodedbytes);
                return Image.FromFile(_path);
            }


        }

        public class Ffname : Encoding
        {
            public string Forenamed;
            public Ffname(Vcard sc)
                : base(sc.vformatedname.CHARSET, sc.vformatedname.ENCODING, sc.vformatedname.isencoded)
            {
                Forenamed = base.GetName(sc.vformatedname.frmatname);
            }


        }


        public class Name : Encoding
        {

            public Name(Vcard sn)
                : base(sn.vcardname.CHARSET, sn.vcardname.ENCODING, sn.vcardname.isencoded)
            {


                Nameprifx = sn.vcardname.nameprefix;
                Fristname = sn.vcardname.fristname;
                Famliyname = sn.vcardname.famliy;

            }



            public string Fristname
            {
                get { return _fristname; }
                private set
                {

                    _fristname = GetName(value);
                }
            }

            public string Famliyname
            {
                get { return _famliyname; }
                private set
                {

                    _famliyname = GetName(value);
                }
            }

            public string Nameprifx
            {
                get { return _nameprifx; }
                private set { _nameprifx = GetName(value); }
            }



            public override string ToString()
            {
                return Nameprifx + ";" + Fristname + ";" + Famliyname;
            }

            private string _fristname;
            private string _famliyname;
            private string _nameprifx;


        }

        public abstract class Encoding
        {
            public string Charset;
            public string Encodeing;
            public bool Isencoding;

            protected Encoding(string charset, string encodeing, bool isencoding)
            {
                Charset = charset;
                Encodeing = encodeing;
                Isencoding = isencoding;
            }
            public virtual string GetName(string name)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    string n = name.Trim();
                    n = n.Replace("\r", string.Empty);
                    n = n.Replace("==", "=");
                    if (Isencoding)

                        return n.Decode();
                    return n;
                }
                return "";
            }
        }

        public class Emailb
        {
            public Emailb(string em, string prif, bool pref)
            {
                Email = em;
                Prefered = pref;
                Prfix = prif;

            }

            private string _email;
            private string _prfix;
            private bool _prefered;

            public Emailb(Vcard em)
            {
                _email = em.vemail.EMAIL;
                _prefered = em.vemail.PREF;
                _prfix = em.vemail.prfix;
            }

            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }

            public string Prfix
            {
                get { return _prfix; }
                set { _prfix = value; }
            }

            public bool Prefered
            {
                get { return _prefered; }
                set { _prefered = value; }
            }

            public override string ToString()
            {
                return "Px:" + _prfix + " Em:" + _email + " Pr" + _prefered.ToString();
            }
        }
        public class Number
        {
            private string _numb;
            private string _prefix;
            private bool _prefer;

            public Number(warpiton.Number s)
            {
                Numb = s.numb;
                Prefix = s.prfix;
                Prefer = s.PREF;


            }

            public string Numb
            {
                get { return _numb; }
                set { _numb = value; }
            }

            public string Prefix
            {
                get { return _prefix; }
                set { _prefix = value; }
            }

            public bool Prefer
            {
                get { return _prefer; }
                set { _prefer = value; }
            }

            public override string ToString()
            {
                return "Px:" + Prefix + " N:" + Numb + "  Pr" + Prefer.ToString();
            }
        }
        public string FormName
        {
            get { return Formatedname.Forenamed; }

        }

        public string Pemail
        {
            get
            {
                if (Emails.Count != 0) return Emails[0].Email;
                return "None";
            }
        }

        public string Pnumber
        {
            get
            {
                if (NumberlList.Count != 0) return NumberlList[0].Numb;
                return "None";
            }
        }
        public override string ToString()
        {
            return "Nae:" + FormName + "  Num:" + NumberlList.Count + " Em:" + Emails.Count;
           
        }
        
    }

 
}
