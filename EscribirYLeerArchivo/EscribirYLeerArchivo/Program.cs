using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscribirYLeerArchivo
{
    class Program
    {
        static void Main(string[] args)
        {
            String rutaArchivoSalida = @"/users/Ulises/desktop/archivoTexto.txt";
            String rutaArchivoEntrada = rutaArchivoSalida;
            StreamWriter escribir = new StreamWriter(rutaArchivoSalida);
            for(int i=0; i<=100; i++)
                escribir.WriteLine(i);
            escribir.Close();

            StreamReader leer = new StreamReader(rutaArchivoEntrada);
            String linea = "";
            while(linea!=null)
            {
                linea = leer.ReadLine();
                Console.WriteLine(linea);
            }
            leer.Close();
            Console.ReadKey();
        }
    }
}
