using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cifrados
{
    public class Cesar : Icesar
    {
       

        public void Cifrar(string dirLectura, string dirEscritura, string Word)
        {
            // Diccionarios
            Dictionary<int, char> ABCifrado = new Dictionary<int, char>();
            Dictionary<char, char> Texto = new Dictionary<char, char>();

            string Abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] ABC = Abecedario.ToArray();
            char Letra;

            string TextoArchivo = System.IO.File.ReadAllText(dirLectura, Encoding.Default);
            string mensaje = TextoArchivo;
                        
            //agrega la clave al abecedario
            int NumLetra = 0;
            foreach (char item in Word.ToUpper())
            {
                ABCifrado.Add(NumLetra++, item);

            }
            for (Letra = 'A'; Letra <= 'Z'; Letra++)
            {
                if (ABCifrado.ContainsValue(Letra) == false)
                {
                    ABCifrado.Add(NumLetra++, Letra);

                }
            }

            //Agreagar Diccionario Texto

            for (int i = 0; i < 26; i++)
            {
                Texto.Add(ABC[i], ABCifrado[i]);
            }

            //Cifrando texto

            string TextoFinal = "";
            foreach (char item in mensaje.ToUpper())
            {
                TextoFinal = TextoFinal + Texto[item];
            }

            File.WriteAllText(dirEscritura, TextoFinal);


        }
        public void Descifrar(string dirLectura, string dirEscritura, string Word)
        {
            // Diccionarios
            Dictionary<int, char> ABCifrado = new Dictionary<int, char>();
            Dictionary<char, char> Texto = new Dictionary<char, char>();

            string Abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] ABC = Abecedario.ToArray();
            char Letra;

            string TextoArchivo = System.IO.File.ReadAllText(dirLectura, Encoding.Default);
            string mensaje = TextoArchivo;

            //agrega la clave al abecedario
            int NumLetra = 0;
            foreach (char item in Word.ToUpper())
            {
                ABCifrado.Add(NumLetra++, item);

            }
            for (Letra = 'A'; Letra <= 'Z'; Letra++)
            {
                if (ABCifrado.ContainsValue(Letra) == false)
                {
                    ABCifrado.Add(NumLetra++, Letra);

                }
            }

            //Agreagar Diccionario Texto

            for (int i = 0; i < 26; i++)
            {
                Texto.Add(ABCifrado[i], ABC[i]);
            }

            //Descifrando texto

            string TextoFinal = "";
            foreach (char item in mensaje.ToUpper())
            {
                TextoFinal = TextoFinal + Texto[item];
            }

            File.WriteAllText(dirEscritura, TextoFinal);

        }
    }
}
