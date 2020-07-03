using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArchivosBinConEstructura
{
    class Program
    {
        static void Main(string[] args)
        {
            int opMenu = 0;

            do
            {
                Console.WriteLine("\n Menu");
                Console.WriteLine("\n 1.-Crear&Guardar " +
                    "\n 2.-Abrir");
                Console.WriteLine("\n Dame la opcion");
                opMenu = int.Parse(Console.ReadLine());
                switch (opMenu)
                {
                    
                    case 1:
                        Console.WriteLine("Dame el nombre del archivo: ");
                        String nombreArchivo = Console.ReadLine() + ".bin";
                        Console.WriteLine("Nombre: ");
                        String nombre = Console.ReadLine();
                        //guardado nombre
                        for (int i = nombre.Length; i < 30; i++)
                            nombre += " ";
                        

                        Console.WriteLine("Edad: ");
                        Int32 edad = Int32.Parse(Console.ReadLine());
                        FileStream stream = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
                        BinaryWriter br = new BinaryWriter(stream);
                        br.Write(nombre);
                        br.Write(edad);
                        br.Close();
                        stream.Close();

                        break;
                    case 2:
                        Console.WriteLine("Dame el nombre del archivo");
                        String nombreArchivoAbrir = Console.ReadLine() + ".bin";
                        FileStream stream1 = new FileStream(nombreArchivoAbrir, FileMode.Open, FileAccess.Read);
                        BinaryReader bw = new BinaryReader(stream1);
                        //Console.WriteLine(bw.ReadString() + bw.ReadInt32()  );
                        String newname;
                        String name = bw.ReadString();
                        int contador = 0;
                        int age = bw.ReadInt32();
                        foreach(char ch in name)
                        {
                            if(ch!=' ')
                            {
                                contador++;
                            }

                        }
                        newname = name.Substring(0, contador);

                        Console.WriteLine(newname + age);
                        stream1.Close();
                        bw.Close();


                        break;
                }

            } while (opMenu != 3); 
           
        }
    }
}
