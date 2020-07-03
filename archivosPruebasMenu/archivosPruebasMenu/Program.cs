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
                    "\n 0.-Ver Archivos" +
                    "\n 1.-Abrir Archivo" +
                    "\n 2.-Crear Archivo" +
                    "\n 3.-Modificar Archivo" +
                    "\n 4.-Eliminar Archivo" +
                    "\n 5.-Salir \n");
                Console.WriteLine("Escriba una opcion: ");
                op = Convert.ToInt32(Console.ReadLine());

                switch(op)
                {
                    case 0:
                        DirectoryInfo di = new DirectoryInfo(@"C:\Users\Ulises\Documents\Ulises\Archivos\Archivos\archivosPruebasMenu\archivosPruebasMenu\bin\Debug"); //listar los archivos!
                        foreach( var fi in di.GetFiles("*.bin*"))
                        {
                            Console.WriteLine(fi.Name);
                        }

                        break;
                    case 1:
                        Console.WriteLine("Nombre del Archivo: ");
                        String nombreArchivo1 = Console.ReadLine() + ".bin";
                        FileStream streamReader = new FileStream(nombreArchivo1,
                        FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(streamReader);
                        Console.WriteLine("contenido del archivo: ");
                        Console.Write(reader.ReadString());
                        reader.Close();
                        streamReader.Close();
                        break;
                    case 2:

                        Console.WriteLine("Nombre del Archivo: ");
                        String nombreArchivo = Console.ReadLine() + ".bin";
                        Console.WriteLine("Contenido del Archivo: ");
                        String contenidoArchivo = Console.ReadLine();
                        FileStream stream = new FileStream(nombreArchivo,FileMode.Create, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(contenidoArchivo);
                        writer.Close();
                        stream.Close();
                        break;
                    case 3:
                        int subop=0;
                        Console.WriteLine("Que deseas modificar? " +
                        "\n 1.-Nombre Archivo" +
                        "\n 2.-Contenido");
                        subop = Convert.ToInt32(Console.ReadLine());

                        switch (subop)
                        {
                            case 1:
                                String original = "";
                                String nuevo = "";
                                Console.WriteLine("Dame el nombre del archivo a modificar: ");
                                original = Console.ReadLine() + ".bin";
                                if (File.Exists(original))
                                {
                                    Console.WriteLine("Dame el nuevo nombre del archivo");
                                    nuevo = Console.ReadLine() + ".bin";
                                    if (!File.Exists(nuevo))
                                    {
                                        File.Move(original, nuevo);
                                    }
                                    else
                                    {
                                        Console.Write("Error");
                                    }

                                }
                                else
                                {
                                    Console.Write("Error");
                                }

                                break;
                            case 2:
                                String nombreArchivos = "";
                                String contenidoArchivos = "";
                                Console.WriteLine("Dame el nombre del archivo a modificar el contenido: ");
                                nombreArchivos = Console.ReadLine() + ".bin";
                                try
                                {
                                    using (writer = new BinaryWriter(new FileStream(nombreArchivos, FileMode.Open)))//Abre el archivo con el BinaryWriter
                                    {
                                        writer.Seek(0, SeekOrigin.Begin);//Posiciona el grabado del archivo en la dirección actual
                                        Console.WriteLine("Contenido del Archivo: ");
                                        contenidoArchivos = Console.ReadLine();
                                        writer.Write(contenidoArchivos);
                                        writer.Seek(0, SeekOrigin.End);

                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                    
                               

                                break;

                            default:
                                break;
                        }
                        break;
                            case 4:
                            String nombreAuxiliar = "";
                            Console.WriteLine("Dame el nombre del archivo que deseas eliminar: ");
                            nombreAuxiliar = Console.ReadLine() + ".bin";
                            if(File.Exists(nombreAuxiliar))
                            {
                                File.Delete(nombreAuxiliar);
                            }    
                            break;

                    default:

                        break;

                }
                
                    
            } while (op != 5);
        }
    }
}
