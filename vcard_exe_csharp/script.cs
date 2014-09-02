using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace warpiton
{
    internal static class Script
    {
       // private static string Filename = @"C:\Users\xobyx\Desktop\00001.vcf";

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }


        public static List<string> Maisn(string Filename)
        {

            byte[] y = File.ReadAllBytes(Filename);
            List<byte[]> op = new List<byte[]>();
            for (int i = 0; i < y.Length; i++)
            {
                string ys = Encoding.ASCII.GetString(y, i, 11);
                if (ys.Contains("BEGIN:VCARD"))
                    for (int n = i + 11; n < y.Length; n++)
                    {
                        string yn = Encoding.ASCII.GetString(y, n, 9);
                        if (yn.Contains("END:VCARD"))
                        {

                            int m = n + 0x9 + 0x2;
                            var s = SubArray(y, i, (m - i));
                            i = m - 1;
                            op.Add(s);
                            break;
                        }
                    }
            }
            return op.ConvertAll((r => Encoding.ASCII.GetString(r)));
        }
    }





}
