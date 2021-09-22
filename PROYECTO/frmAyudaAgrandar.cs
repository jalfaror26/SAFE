using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROYECTO
{
    public partial class frmAyudaAgrandar : Form
    {
        private static frmAyudaAgrandar instance = null;

        private frmAyudaAgrandar(Image image,String titulo)
        {
            this.Text = titulo;
            this.ClientSize = new System.Drawing.Size(image.Width, image.Height);            
            InitializeComponent();
            pbImagen.Image = image;
          //  pbImagen.Size = new System.Drawing.Size(image.Width, image.Height);
        }

        public static frmAyudaAgrandar getInstance(Image image, String titulo)
        {
            if (instance == null)
                instance = new frmAyudaAgrandar(image, titulo);
            return instance;
        }

        private void frmAgrandar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAyuda.getInstance().Enabled = true;
            instance = null;
        }

        private void pbImagen_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}