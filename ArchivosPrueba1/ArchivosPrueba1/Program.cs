using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ArchivosPrueba1
{
    class Program
    {
        static StreamReader leer;
        static StreamWriter escribir;
        static void Main(string[] args)
        {
            Console.Title = "Ejemplo de archivos en C#";
            int Op;
            String cadena;
            Console.WriteLine("Opcion 1 para crear y escribir sobre un archivo: ");
            Console.WriteLine("Opcion 2 para leer un archivo: ");
            Op = int.Parse(Console.ReadLine());
            if(Op==1)
            {
                escribir = new StreamWriter("Archivo.txt", true);
                Console.WriteLine("Escribir mensaje de prueba: ");
                cadena = Console.ReadLine();
                escribir.WriteLine(cadena);
                Console.WriteLine("Escrituta exitosa...");
                escribir.Close();
            }
            if(Op==2)
            {
                leer = new StreamReader("Archivo.txt", true);
                cadena = leer.ReadLine();
                Console.WriteLine("lo leido del archivo es: \n\t\t\t" +"'"+cadena+"'");
                leer.Close();

            }
            Console.ReadKey();

        }
    }
}
