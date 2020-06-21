using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscribirYLeerArchivoBinario
{
    class EscrbirBinario
    {
        public EscrbirBinario()
        {
            string fileName = "datos.bin";
            double[,] data = new double[4, 4];
            Random objeto = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = objeto.NextDouble() + objeto.Next(5, 26);
                    Console.Write("[{0}]", data[i, j]);
                }
                Console.WriteLine();
            }

            FileStream stream = new FileStream(fileName,
                FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);

            Console.WriteLine("Dame tu nombre");
            string nombre = Console.ReadLine();

            writer.Write(nombre);
         //   writer.Write("\n");

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    writer.Write(data[i, j]);
                }
                writer.Write("\n");
            }
            writer.Close();
            stream.Close();
        
    }
    }
}
