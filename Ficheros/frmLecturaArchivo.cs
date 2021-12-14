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

namespace Ficheros
{
    public partial class frmLecturaArchivo : Form
    {
        
        public frmLecturaArchivo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            //apertura del fichero
            try
            {
                string file = this.txtArchivo.Text;
                FileStream archivo = new FileStream(file, FileMode.Open);
                StreamReader sr = new StreamReader(archivo);

                //lectura de la primera línea del archivo
                string cad, aux = "";
                cad = sr.ReadLine();
                while (cad != null)
                {
                    aux += cad + Environment.NewLine;
                    cad = sr.ReadLine();
                }
                this.txtResultado.Text = aux;

                //cerrar el flujo
                sr.Close();
            }
            catch(IOException e1)
            {
                MessageBox.Show(e1.Message.ToString(), "Mensaje para los papus" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\Python310";
            openFileDialog1.Filter = "txt files(*.txt)| *.txt";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtArchivo.Text = openFileDialog1.FileName;
            }
            else
            {
                this.txtArchivo.Text = "";
            }
        }
    }
}
