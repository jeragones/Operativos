using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSA_Operativos
{
    class RSA_Class
    {
        Int64[] publickey = new Int64[2];
        Int64[] privatekey = new Int64[2];

        public int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
            
        public void generar_public(int p, int q)
        {
            int n = p * q;
            int pn = (p - 1) * (q - 1);
            Random rnd = new Random();
            int e = 0;//rnd.Next(1,pn);
            
            for (int i = 5; i < pn; i++)
            {
                if (GCD(i, pn) == 1)
                {
                    e = i;
                    break;
                }
            }

            publickey[0] = e;
            publickey[1] = n;
            
        }

        public void generar_private(int p, int q)
        {
            int n = p * q;
            int pn = (p - 1) * (q - 1);
            int d = 0;//p * ((p * q) % pn);

            for (int i = 0; i < n; i++)
            {
                if ((i * publickey[0]) % pn == 1)
                {
                    d = i;
                    break;
                }
            }


            privatekey[0] = d;
            privatekey[1] = n;
            
        }

        public Int64 EncriptarRSA(int p, int q, Int64 m) //m^e%n
        {
            
            Int64 e=publickey[0];
            Int64 n=publickey[1];
            Int64 x = Convert.ToInt64(Math.Pow(m, e) % n);
            return x;
        }

        public long DesEncriptarRSA(int p, int q, Int64 m) //m^e%n
        {
            Int64 d = privatekey[0];
            Int64 n = privatekey[1];
            long x = Convert.ToInt64(Math.Pow(m, d));
            long y = x % n;
            return y;
        }

        
    }
}
