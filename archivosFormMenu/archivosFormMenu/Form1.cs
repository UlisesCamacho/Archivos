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
    public partial class Form1 : Form
    {
        private BinaryWriter bw;
        private BinaryReader br;
        private String nombreArchivo;
        private cuadroDialogo CuadroDialogo;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.AccessibleName)
            {
                case "Crear":
                    
                    this.CuadroDialogo = new cuadroDialogo();
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
                    this.CuadroDialogo = new cuadroDialogo();
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
            String nombre = Nombre.Text;
            for (int i = nombre.Length; i < 30; i++)
                nombre += " ";
            Int32 edad = Int32.Parse(Edad.Text);
            FileStream file = new FileStream(this.nombreArchivo, FileMode.Create, FileAccess.Write);
            bw = new BinaryWriter(file);
            bw.Write(nombre);
            bw.Write(edad);
            bw.Close();
            file.Close();
            Nombre.Clear();
            Edad.Clear();
            MessageBox.Show("guardado");
        }
        private void leerArchivo(String nombreArch)
        {
            FileStream file = new FileStream(nombreArch, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(file);
            String name = br.ReadString();
            int age = br.ReadInt32();
            name = name.Split(' ').First();
            MessageBox.Show(name + age);
            file.Close();
            br.Close();
        }

    }
}
