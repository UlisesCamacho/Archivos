using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace archivosFormMenu
{
    public partial class cuadroDialogo : Form
    {
        

        public cuadroDialogo(String titulo)
        {
            this.Text = titulo;
            InitializeComponent();
        }
        public String nombreA
        {
            get { return this.textBox1.Text; } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede dejar vacio ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.textBox1.Clear();
        }

        
    }
}
