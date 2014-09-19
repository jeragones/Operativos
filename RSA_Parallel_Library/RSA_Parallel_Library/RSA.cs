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

        /// <summary>
        /// Determina el maximo comun divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        /// <summary>
        /// Genera la clave publica
        /// </summary>
        /// <param name="p">entero primo</param>
        /// <param name="q">entero primo</param>
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

        /// <summary>
        /// Genera Clave privada
        /// </summary>
        /// <param name="p">entero primo</param>
        /// <param name="q">entero primo</param>
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

        /// <summary>
        /// encripta un caragter utilizando la clave publica
        /// </summary>
        /// <param name="m">valor ascii del carácter</param>
        /// <returns></returns>
        public int Encriptar(int m)
        {
            uint k = Convert.ToUInt32(publick[0]);
            int n = publick[1];
            IntX c=(IntX.Pow(m, k) % n);
            string cs = c.ToString();
            return Convert.ToInt32(cs);
        }

        /// <summary>
        /// Desencripta un caragter utilizando la clave privada
        /// </summary>
        /// <param name="m">valor ascii del carácter</param>
        /// <returns></returns>
        public int Desencriptar(int m)
        {
            uint d = Convert.ToUInt32(privatek[0]);
            int n = privatek[1];
            IntX c = (IntX.Pow(m, d) % n);
            string cs = c.ToString();
            return Convert.ToInt32(cs);
        }

        /// <summary>
        /// encripta de manera secuencial una cadena de texto
        /// crea un char[] de todos los caracteres de la cadena y le envia el valor ascii de cada char al metodo Encriptar
        /// </summary>
        /// <param name="txt">cadena a encriptar</param>
        /// <returns></returns>
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

        /// <summary>
        /// desencripta de manera secuencial una cadena de texto
        /// crea un char[] de todos los caracteres de la cadena y le envia el valor ascii de cada char al metodo Desencriptar
        /// </summary>
        /// <param name="txt">cadena a desencriptar</param>
        /// <returns></returns>
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

        /// <summary>
        /// toma una cadena y la divide en n partes
        /// </summary>
        /// <param name="txt">cadena</param>
        /// <param name="n">numero de divisiones solicitadas</param>
        /// <returns></returns>
        public string[] splicer(string txt, int n) 
        {
            string[] partes = new string[n+1];
            
            int start = 0;
            int x = 0;
            //int parts = 5;
            int size = txt.Length / n ;

            while (start < txt.Length)
            {
                int end = start + size < txt.Length ? size : txt.Length - start;
                partes[x]=(txt.Substring(start, end));
                start += size;
                x += 1;
            }
            return partes;
        }

        /// <summary>
        /// Encripta una cadena de manera paralela
        /// </summary>
        /// <param name="txt">cadena a eencriptar</param>
        /// <returns></returns>
        public string EncrRSAParalelo(string txt)
        {
            
            int cores = 4;//Environment.ProcessorCount;
            /* si utiliza el numero de cores del procesador para dividir el texto y hacer varias
               llamadas en paralelo del metodo encriptar, el tiempo de ejecucion es mas prolongado*/
            
            string[] t = splicer(txt,cores);
            string res = "";
            // crea n llamadas en paralelo dependiendo del numero de cores 
            if (cores == 4) 
            {
                String c1="", c2="", c3="", c4 = "" ;
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Encriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Encriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Encriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Encriptar(t[3].ToCharArray()[i]));
                    }
                }
                );
                res = c1+c2+c3+c4;
            }
            else if(cores == 6) 
            {
                String c1 = "", c2 = "", c3 = "", c4 = "",c5="",c6="";
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Encriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Encriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Encriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Encriptar(t[3].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[4].ToCharArray().Length; i++)
                    {
                        c5 += (char)(Encriptar(t[4].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[5].ToCharArray().Length; i++)
                    {
                        c6 += (char)(Encriptar(t[5].ToCharArray()[i]));
                    }
                }
                );
                res = c1 + c2 + c3 + c4 + c5 + c6;
            }
            else if (cores == 8)
            {
                String c1 = "", c2 = "", c3 = "", c4 = "", c5 = "", c6 = "", c7 = "", c8 = "";
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Encriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Encriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Encriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Encriptar(t[3].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[4].ToCharArray().Length; i++)
                    {
                        c5 += (char)(Encriptar(t[4].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[5].ToCharArray().Length; i++)
                    {
                        c6 += (char)(Encriptar(t[5].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[6].ToCharArray().Length; i++)
                    {
                        c7 += (char)(Encriptar(t[6].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[7].ToCharArray().Length; i++)
                    {
                        c8 += (char)(Encriptar(t[7].ToCharArray()[i]));
                    }
                }
                );
                res = c1 + c2 + c3 + c4 + c5 + c6+ c7 +c8;
            }
            else {
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
                res= C1 + C2;
            
            }
            return res;
        }

        /// <summary>
        /// Desencripta de manera paralela una cadena
        /// </summary>
        /// <param name="txt">cadena a desencriptar</param>
        /// <returns></returns>
        public string DesenRSAParalelo(string txt)
        {
            int cores = 2;//Environment.ProcessorCount;
            /* si utiliza el numero de cores del procesador para dividir el texto y hacer varias
               llamadas en paralelo del metodo encriptar, el tiempo de ejecucion es mas prolongado*/

            string[] t = splicer(txt, cores);
            string res = "";
            if (cores == 4)
            {
                String c1 = "", c2 = "", c3 = "", c4 = "";
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Desencriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Desencriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Desencriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Desencriptar(t[3].ToCharArray()[i]));
                    }
                }
                );
                res = c1 + c2 + c3 + c4;
            }
            else if (cores == 6)
            {
                String c1 = "", c2 = "", c3 = "", c4 = "", c5 = "", c6 = "";
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Desencriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Desencriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Desencriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Desencriptar(t[3].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[4].ToCharArray().Length; i++)
                    {
                        c5 += (char)(Desencriptar(t[4].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[5].ToCharArray().Length; i++)
                    {
                        c6 += (char)(Desencriptar(t[5].ToCharArray()[i]));
                    }
                }
                );
                res = c1 + c2 + c3 + c4 + c5 + c6;
            }
            else if (cores == 8)
            {
                String c1 = "", c2 = "", c3 = "", c4 = "", c5 = "", c6 = "", c7 = "", c8 = "";
                Parallel.Invoke(() =>
                {
                    for (int i = 0; i < t[0].ToCharArray().Length; i++)
                    {
                        c1 += (char)(Desencriptar(t[0].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[1].ToCharArray().Length; i++)
                    {
                        c2 += (char)(Desencriptar(t[1].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[2].ToCharArray().Length; i++)
                    {
                        c3 += (char)(Desencriptar(t[2].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[3].ToCharArray().Length; i++)
                    {
                        c4 += (char)(Desencriptar(t[3].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[4].ToCharArray().Length; i++)
                    {
                        c5 += (char)(Desencriptar(t[4].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[5].ToCharArray().Length; i++)
                    {
                        c6 += (char)(Desencriptar(t[5].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[6].ToCharArray().Length; i++)
                    {
                        c7 += (char)(Desencriptar(t[6].ToCharArray()[i]));
                    }
                },
                () =>
                {
                    for (int i = 0; i < t[7].ToCharArray().Length; i++)
                    {
                        c8 += (char)(Desencriptar(t[7].ToCharArray()[i]));
                    }
                }
                );
                res = c1 + c2 + c3 + c4 + c5 + c6 + c7 + c8;
            }
            else
            {
                string Mitad1;
                string Mitad2;
                int largoTexto = txt.Count();
                int iMitad = largoTexto / 2;
                Mitad1 = txt.Substring(0, iMitad);
                Mitad2 = txt.Substring(iMitad, iMitad);
                char[] letras1 = Mitad1.ToCharArray();
                char[] letras2 = Mitad2.ToCharArray();
                string C1 = "", C2 = "";
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
                res = C1 + C2;

            }
            return res;
        }

    }
}
