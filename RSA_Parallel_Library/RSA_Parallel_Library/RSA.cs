using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using IntXLib;

namespace RSA_Parallel_Library
{
    class RSA
    {
        int[] publick = new int[2];
        int[] privatek = new int[2];

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public void publicKey(int p, int q)
        {
            int n = p * q;
            int v = (p - 1) * (q - 1);
            int k=0;

            for (int i = 3; i < v; i++)
            {
                
                if ( GCD(i,v)== 1)
                {
                    k = i;
                    break;
                }
            }
            publick[0] = k;
            publick[1] = n;
        }

        public void privateKey(int p, int q)
        {
            int n = p * q;
            int v = (p - 1) * (q - 1);
            int d = 0;

            for (int i = 0; i < n; i++)
            {

                if ((i*publick[0])%v == 1)
                {
                    d = i;
                    break;
                }
            }
            privatek[0] = d;
            privatek[1] = n;
        }

        public int Encriptar(int m)
        {
            uint k = Convert.ToUInt32(publick[0]);
            int n = publick[1];
            IntX c=(IntX.Pow(m, k) % n);
            string cs = c.ToString();
            return Convert.ToInt32(cs);
        }

        public int Desencriptar(int m)
        {
            uint d = Convert.ToUInt32(privatek[0]);
            int n = privatek[1];
            IntX c = (IntX.Pow(m, d) % n);
            string cs = c.ToString();
            return Convert.ToInt32(cs);
        }

        public string EncrRSASecuencial(string txt)
        {
            char[] letras = txt.ToCharArray();
            String C = "";
            for (int i = 0; i < letras.Length; i++)
            {

                C += (char)(Encriptar(letras[i]));
            }
            return C;
        }

        public string DesenRSASecuencial(string txt)
        {
            char[] letras = txt.ToCharArray();
            String C = "";
            for (int i = 0; i < letras.Length; i++)
            {

                C += (char)(Desencriptar(letras[i]));
            }
            return C;
        }

        public string EncrRSAParalelo(string txt)
        {
            string Mitad1;
            string Mitad2;
            int largoTexto = txt.Count();
            int iMitad = largoTexto / 2;
            Mitad1 = txt.Substring(0, iMitad);
            Mitad2 = txt.Substring(iMitad, iMitad);
            
            char[] letras1 = Mitad1.ToCharArray();
            char[] letras2 = Mitad2.ToCharArray();
            String C1 = "";
            String C2 = "";

            Parallel.Invoke(() => 
            {
                for (int i = 0; i < letras1.Length; i++)
                {

                    C1 += (char)(Encriptar(letras1[i]));
                }
 
            }, 
            () => 
            {
                for (int i = 0; i < letras2.Length; i++)
                {

                    C2 += (char)(Encriptar(letras2[i]));
                }
            });
            
            return C1+C2;
        }

        public string DesenRSAParalelo(string txt)
        {
            string Mitad1;
            string Mitad2;
            int largoTexto = txt.Count();
            int iMitad = largoTexto / 2;
            Mitad1 = txt.Substring(0, iMitad);
            Mitad2 = txt.Substring(iMitad, iMitad);

            char[] letras1 = Mitad1.ToCharArray();
            char[] letras2 = Mitad2.ToCharArray();
            String C1 = "";
            String C2 = "";

            Parallel.Invoke(() =>
            {
                for (int i = 0; i < letras1.Length; i++)
                {

                    C1 += (char)(Desencriptar(letras1[i]));
                }

            },
            () =>
            {
                for (int i = 0; i < letras2.Length; i++)
                {

                    C2 += (char)(Desencriptar(letras2[i]));
                }
            });

            return C1 + C2;
        }

    }
}
