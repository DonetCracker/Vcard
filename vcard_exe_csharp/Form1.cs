using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace warpiton
{

    public partial class Form1 : Form
    {
        
        [DllImport("vcarddll", EntryPoint = "getVcard",ExactSpelling = true,CallingConvention = CallingConvention.Cdecl,SetLastError = true)]
        static extern IntPtr getVcard([MarshalAs(UnmanagedType.LPStr)] string vcardbuff, [In] int size,out IntPtr outs);


        private Stopwatch stopwatch;
        private BackgroundWorker isneWorker;
        static public int Blobsize;
        List<Csvcard> vlist=new List<Csvcard>();
        public Form1()
        {
            InitializeComponent();
            ;
            isneWorker = new BackgroundWorker();
            isneWorker.DoWork += isneWorker_DoWork;
            isneWorker.RunWorkerCompleted += isneWorker_RunWorkerCompleted;
          //  Debug.Write("************"+stopwatch.ElapsedMilliseconds+"*************");
          //  dataGridView1.DataSource = vlist;


        }

        void isneWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            dataGridView1.DataSource = vlist;
        }

        void isneWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (vlist.Count != 0)
            {
                try
                {
                    vlist.Clear();
                }
                finally
                {
                  vlist=new List<Csvcard>();  
                }
              
            }
            string fp = e.Argument as string;
            stopwatch = Stopwatch.StartNew();
            IntPtr d;
            foreach (var v in Script.Maisn(fp))
            {

                var y = getVcard(v, v.Length, out d);
                Blobsize = d.ToInt32();
                Vcard ptrToStructure = (Vcard)Marshal.PtrToStructure(y, typeof(Vcard));
                if (Blobsize > 500)
                {

                    int size = Marshal.SizeOf(typeof(Vcard));
                    IntPtr ds = y + size - 1;
                    string ads = Marshal.PtrToStringAnsi(ds);
                    if (ads != null)
                    {
                        ads = ads.Replace("\r\n", "").Replace(Environment.NewLine, "");
                        ads = ads.Replace("ýýýý", "");
                        ads = ads.Replace("\r", "");
                        ads = ads.Replace(" ", "");
                        ads = ads.Trim();

                        ptrToStructure.vphoto.pbData = ads.ToCharArray();
                    }
                }

                vlist.Add(item: new Csvcard(ptrToStructure));
            }
       
            stopwatch.Stop();
           
        }
        Graphics _es;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //_es = e.Graphics;
            //var ess = new Rectangle(new Point(0, 0), new Size(120, 80));
            //_es.FillRectangle(Brushes.BlueViolet, ess);
            //_es.DrawString("stopwatch:" + stopwatch.ElapsedMilliseconds,
            //    new Font(FontFamily.GenericSerif, 30), Brushes.BurlyWood, ess);

           
        }

        static public  int MaxNumSize=20;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var picturPhoto = vlist[e.RowIndex].PicturPhoto;
            if (picturPhoto != null) pictureBox1.Image = vlist[e.RowIndex].PicturPhoto.GetImage();
            else
            {
                pictureBox1.Image = null;
            }

            dataemail.DataSource = vlist[e.RowIndex].Emails;
            datanumbers.DataSource = vlist[e.RowIndex].NumberlList;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileOk += (t, r) => { if (dialog.CheckFileExists == true) isneWorker.RunWorkerAsync(dialog.FileName); };
            var d= dialog.ShowDialog();
            
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Number
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string numb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string prfix;
        [MarshalAs(UnmanagedType.U1)]
        public bool PREF;

        
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Name
    {

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string CHARSET;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string ENCODING;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 150)]
        public string nameprefix;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 150)]
        public string famliy;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst =150)]
        public string fristname;

        [MarshalAs(UnmanagedType.U1)]
        public bool isencoded;
    };
       [StructLayout(LayoutKind.Sequential)]
    public struct FFName
    {

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string CHARSET;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string ENCODING;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 150)]
        public string frmatname;

        [MarshalAs(UnmanagedType.U1)]
        public bool isencoded;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Photo
    {
       
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string ENCODING;
          
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string type;

        [MarshalAs(UnmanagedType.ByValArray)]
        public char[] pbData;

    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Email
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string EMAIL;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string prfix;
       [MarshalAs(UnmanagedType.U1)]
        public bool PREF;
    };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Vcard
    {

        public Name vcardname;


        public FFName vformatedname;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public Number[] vnumbers;

        public Email vemail;

        public Photo vphoto;

       
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Vcardheder
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string header;
        [MarshalAs(UnmanagedType.I8)]
        int vcardcount;
        [MarshalAs(UnmanagedType.I8)]
        int filesize;
    };

 

    public static class Ex
    {
        public static string Decode(this string input) 
        {
            var i = 0;
            var output = new List<byte>();
            while (input != null && i < input.Length && i + 2 <= input.Length)
            {
                if (input[i] != '=' || input[i + 1] != '\r' || input[i + 2] != '\n')
                    switch (input[i])
                    {
                        case '=':
                            string sHex = input;
                            sHex = sHex.Substring(i + 1, 2);
                            int hex = Convert.ToInt32(sHex, 16);
                            byte b = Convert.ToByte(hex);
                            output.Add(b);
                            i += 3;
                            break;
                        default:
                            output.Add((byte) input[i]);
                            i++;
                            break;
                    }
                else
                    //Skip
                    i += 3;
            }


          //  if (String.IsNullOrEmpty(bodycharset))
                return Encoding.UTF8.GetString(output.ToArray());
           // return System.String.Compare(bodycharset, "ISO-2022-JP", System.StringComparison.OrdinalIgnoreCase) == 0 ? Encoding.GetEncoding("Shift_JIS").GetString(output.ToArray()) : Encoding.GetEncoding(bodycharset).GetString(output.ToArray());
        }
    }

}

