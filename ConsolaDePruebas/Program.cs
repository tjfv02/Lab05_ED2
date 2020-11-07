using System;
using System.Collections.Generic;
using System.Linq;
using Cifrados;
 
namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Zigzag Codificador = new Zigzag();

            //Pruebas de cifrado y descifrado con zig zag
            //Codificador.Cifrar("C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\Mensaje.txt", "C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\MensajeCifrado.txt",3);
            //Codificador.Descifrar("C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\MensajeCifrado.txt", "C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\Mensajedescifrado.txt", 3);

            Cesar Prueba = new Cesar();







           /*
            
            Dictionary<int, char> ABCifrado = new Dictionary<int, char>();
            Dictionary<char, char> Texto = new Dictionary<char, char>();

            string Abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] dummy = Abecedario.ToArray();
            
            // Agrega todas las letras al diccionario
            int NumLetra = 0;
            char Letra;

            string Word = "hola";
            //agrega la clave al abecedario


            int NumLetra2 = 0;
            foreach (char item in Word.ToUpper())
            {
                ABCifrado.Add(NumLetra2++,item);

            }
            for (Letra = 'A'; Letra <= 'Z'; Letra++)
            {
                if (ABCifrado.ContainsValue(Letra) == false)
                {
                    ABCifrado.Add(NumLetra2++, Letra);

                }
            }




            //Agreagar Diccionario Texto

            for (int i = 0; i < 26; i++)
            {
                Texto.Add( ABCifrado[i], dummy[i]);
            }



            //for (Letra = 'A'; Letra <= 'Z'; Letra++)
            //{
            //    Console.WriteLine(Texto[Letra]);
            //}

            string mensaje = "shjuans";
            string TextoFinal = "";
            foreach (char item in mensaje.ToUpper())
            {
                TextoFinal = TextoFinal + Texto[item];
            }

            Console.WriteLine(TextoFinal);
           */

        }
    }
}
