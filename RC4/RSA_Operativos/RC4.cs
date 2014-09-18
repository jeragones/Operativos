using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSA_Operativos
{
    class RC4_Class
    {
        public string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] box = new int[256];

            for (int i = 0; i < 256; i++)
            {
                box[i] = i;
            }

            for (int i = 0; i < 256; i++)
            {
                j = (key[i % key.Length] + box[i] + j) % 256;
                x = box[i];
                box[i] = box[j];
                box[j] = x;
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = i % 256;
                j = (box[y] + j) % 256;
                x = box[y];
                box[y] = box[j];
                box[j] = x;

                result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToString();
        }
        public string RC4Secuencial(string m, string p)
        {
             char[] letras = m.ToCharArray();
             string encrip = "";
             for (int i = 0; i < letras.Length; i++)
                {
                    
                    encrip += RC4(Convert.ToString(letras[i]), p);
                }
             return encrip;
        }

        public string RC4Paralelo(string m, string p)
        {

            string Mitad1;
            string Mitad2;
            int largoTexto = m.Count();
            int iMitad = largoTexto / 2;
            Mitad1 = m.Substring(0, iMitad);
            Mitad2 = m.Substring(iMitad, iMitad);


            char[] letras1 = Mitad1.ToCharArray();
            char[] letras2 = Mitad2.ToCharArray();
            string encrip = "";
            string Result1 = "";
            string Result2 = "";
            Parallel.Invoke(() =>
                {
                    for (int i = 0; i < letras1.Length; i++)
                    {

                        Result1 += RC4(Convert.ToString(letras1[i]), p);
                    }
                }, //close second Action
                () =>
                {
                    for (int i = 0; i < letras1.Length; i++)
                    {

                        Result2 += RC4(Convert.ToString(letras2[i]), p);
                    }
                } //close third Action
           ); //close parallel.invoke
            encrip = Result1 + Result2;
            return encrip;
        }
    }
}
