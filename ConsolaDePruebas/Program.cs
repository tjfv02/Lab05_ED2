using System;
using Cifrados;
namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Zigzag Codificador = new Zigzag();
            Codificador.Cifrado("C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\Mensaje.txt", "C:\\Users\\Danilo_Toshiba\\Desktop\\ED2 LAB 5\\MensajeCifrado.txt",3);


        }
    }
}
