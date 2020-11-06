using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Cifrados
{
    public class Zigzag: Izigzag
    {
        
        public void Cifrar(string dirLectura, string dirEscritura, int niveles)
        {
            string CurrentFile = "";

            string texto = System.IO.File.ReadAllText(dirLectura, Encoding.Default);
            string mensaje = texto;
            var lineas = new List<StringBuilder>();
            for (int i = 0; i < niveles; i++)
            {
                lineas.Add(new StringBuilder());
            }
            int Actual = 0;
            int Direccion = 1;

            for (int i = 0; i < mensaje.Length; i++)
            {
                lineas[Actual].Append(mensaje[i]);

                if (Actual == 0)
                    Direccion = 1;
                else if (Actual == niveles - 1)
                    Direccion = -1;

                Actual += Direccion;
            }
            StringBuilder CifradoFinal = new StringBuilder();

            for (int i = 0; i < niveles; i++)
                CifradoFinal.Append(lineas[i].ToString());

            string Cifrados = CifradoFinal.ToString();

            File.WriteAllText(dirEscritura, Cifrados);
        }

        public void Descifrar(string dirLectura, string dirEscritura, int niveles)
        {
            string Data = System.IO.File.ReadAllText(dirLectura, Encoding.Default);
            string mensaje = Data;
            var lineas = new List<StringBuilder>();
           
            for (int i = 0; i < niveles; i++)
            {
                lineas.Add(new StringBuilder());
            }

            int[] LineaI = Enumerable.Repeat(0, niveles).ToArray();

            int ActualL = 0;
            int Direccion = 1;

            //Donde inicia
            for (int i = 0; i < mensaje.Length; i++)
            {
                LineaI[ActualL]++;

                if (ActualL == 0)
                    Direccion = 1;
                else if (ActualL == niveles - 1)
                    Direccion = -1;

                ActualL += Direccion;
            }

            int ActualPosicion = 0;

            for (int j = 0; j < niveles; j++)
            {
                for (int c = 0; c < LineaI[j]; c++)
                {
                    lineas[j].Append(mensaje[ActualPosicion]);
                    ActualPosicion++;
                }
            }

            StringBuilder descifrado = new StringBuilder();

            ActualL = 0;
            Direccion = 1;

            int[] LP = Enumerable.Repeat(0, niveles).ToArray();

            for (int i = 0; i < mensaje.Length; i++)
            {
                descifrado.Append(lineas[ActualL][LP[ActualL]]);
                LP[ActualL]++;

                if (ActualL == 0)
                    Direccion = 1;
                else if (ActualL == niveles - 1)
                    Direccion = -1;
                ActualL += Direccion;
            }

            string DescifradoF = descifrado.ToString();

            File.WriteAllText(dirEscritura, DescifradoF);
        }
    }
}
