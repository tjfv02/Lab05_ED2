using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Cifrados
{
    public class Zigzag
    {
        

        public void Cifrado(string dirLectura, string dirEscritura, int niveles)
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
            //For para saber donde empezamos

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

            //Saber donde se encuentra cada caracter
            for (int i = 0; i < niveles; i++)
                CifradoFinal.Append(lineas[i].ToString());

            string Cifrados = CifradoFinal.ToString();

            File.WriteAllText(dirEscritura, Cifrados);
            CurrentFile = dirEscritura;
        }
    }
}
