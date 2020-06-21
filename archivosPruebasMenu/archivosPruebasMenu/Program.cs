using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace archivosPruebasMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            

            do
            {
                Console.WriteLine("\n MENU");
                Console.WriteLine("\n" +
                    "\n 1.-Abrir Archivo" +
                    "\n 2.-Crear Archivo" +
                    "\n 3.-Modificar Archivo" +
                    "\n 4.-Eliminar Archivo" +
                    "\n 5.-Salir \n");
                Console.WriteLine("Escriba una opcion: ");
                op = Convert.ToInt32(Console.ReadLine());

                switch(op)
                {
                    case 1:
                        Console.WriteLine("Nombre del Archivo: ");
                        String nombreArchivo1 = Console.ReadLine();
                        FileStream streamReader = new FileStream(nombreArchivo1,
                        FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(streamReader);
                        Console.Write(reader.ReadString());
                        reader.Close();
                        streamReader.Close();
                        break;
                    case 2:

                        Console.WriteLine("Nombre del Archivo: ");
                        String nombreArchivo = Console.ReadLine();
                        Console.WriteLine("Contenido del Archivo: ");
                        String contenidoArchivo = Console.ReadLine();
                        FileStream stream = new FileStream(nombreArchivo,FileMode.Create, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(contenidoArchivo);
                        writer.Close();
                        stream.Close();
                        break;
                    case 3:
                       
                        break;
                        
                }

                    
            } while (op != 5);
        }
    }
}
