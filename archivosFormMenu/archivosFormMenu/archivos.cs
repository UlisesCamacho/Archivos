using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace archivosFormMenu
{
    public partial class archivos : Form
    {
        private BinaryWriter bw;
        private BinaryReader br;
        private String nombreArchivo;
        private cuadroDialogo CuadroDialogo;
        private List<Int32> listEdad;
        private List<String> listNombre;


        public archivos()
        {
            listNombre = new List<String>();
            listEdad = new List<Int32>();
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.AccessibleName)
            {
                case "Crear":
                    
                    this.CuadroDialogo = new cuadroDialogo("Crear Archivo");
                    if(CuadroDialogo.ShowDialog().Equals(DialogResult.OK))
                    {
                        this.nombreArchivo = CuadroDialogo.nombreA + ".bin";
                        if(!File.Exists(this.nombreArchivo))
                        {
                            FileStream file;
                            file = new FileStream(this.nombreArchivo, FileMode.Create);
                            file.Close();
                            label1.Visible = true;
                            label2.Visible = true;
                            Nombre.Visible = true;
                            Edad.Visible = true;
                            Guardar.Enabled = true;
                          
                        }
                        else
                        {
                            MessageBox.Show("Nombre ya existe, escribir otro nombre ");
                        }
                    }
                    break;
                case "Abrir":
                    this.CuadroDialogo = new cuadroDialogo("Abrir Archivo");
                    dataGridView1.Rows.Clear();
                    if(this.CuadroDialogo.ShowDialog().Equals(DialogResult.OK))
                    {
                        this.nombreArchivo = CuadroDialogo.nombreA + ".bin";
                        if(File.Exists(this.nombreArchivo))
                        {
                            this.leerArchivo(this.nombreArchivo);
                        }
                    }

                    break;

            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Nombre.Clear();
            Edad.Value = 0;
            listEdad.Clear();
            listNombre.Clear();
            MessageBox.Show("guardado");
        }
        private void leerArchivo(String nombreArch)
        {
            FileStream file = new FileStream(nombreArch, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(file);
            int datos = br.ReadInt32();
            String name = " ";
            int age = 0;
            for (int i = 0; i < datos; i++)
            {
                name = br.ReadString();
                name = name.Split(' ').First();
                age = br.ReadInt32();
                dataGridView1.Rows.Add(name, age);
            }
            file.Close();
            br.Close();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(Nombre.Text) || Edad.Value == 0)
            {
                
                listNombre.Add(Nombre.Text);
                listEdad.Add(Int32.Parse(Edad.Value.ToString()));
                dataGridView1.Rows.Add(Nombre.Text, Edad.Value);
                //guardado en el archivo
                String nombre = Nombre.Text;
                for (int i = nombre.Length; i < 30; i++)
                    nombre += " ";
                Int32 edad = Int32.Parse(Edad.Value.ToString());
                FileStream file = new FileStream(this.nombreArchivo, FileMode.Open, FileAccess.Write);
                bw = new BinaryWriter(file);
                bw.Seek(0, SeekOrigin.Begin);//no se sobreescribe
                bw.Write(listEdad.Count); //para mostrar datos
                bw.Seek(0, SeekOrigin.End);
                bw.Write(nombre);
                bw.Write(edad);
              //  bw.Write("\n");
                file.Close();
                bw.Close();
                Nombre.Clear();
                Edad.Value = 0;
            }
            else
            {
                MessageBox.Show("no se puede guardar un campo vacio");
            }
        }
    }
}
