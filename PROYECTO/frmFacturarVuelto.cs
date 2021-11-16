using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Drawing.Printing;
using System.IO;

namespace PROYECTO
{
    public partial class frmFacturarVuelto : Form
    {
        private static frmFacturarVuelto instance = null;
        private String monto, vuelto, origen = "";
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

        private frmFacturarVuelto(string pmonto, string pvuelto, String pOrigen)
        {
            monto = pmonto;
            vuelto = pvuelto;
            origen = pOrigen;
            InitializeComponent();
        }

        public static frmFacturarVuelto getInstance(string monto, string vuelto, String pOrigen)
        {
            if (instance == null)
                instance = new frmFacturarVuelto(monto, vuelto, pOrigen);
            return instance;
        }

        private void frmFacturarVuelto_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void frmFacturarVuelto_Load(object sender, EventArgs e)
        {
            lblMonto.Text = monto;
            lblVuelto.Text = vuelto;

            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oTablaImagen = new DataTable();

                    oTablaImagen = oConexion.EjecutaSentencia("SELECT EMPR_LOGO FROM TBL_EMPRESA em where em.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    if (oTablaImagen.Rows.Count > 0)
                    {
                        if (oTablaImagen.Rows[0].ItemArray[0] != null)
                        {
                            Bitmap imagen = null;
                            Byte[] bytes = (Byte[])oTablaImagen.Rows[0]["EMPR_LOGO"];
                            MemoryStream ms = new MemoryStream(bytes);
                            imagen = new Bitmap(ms);
                            this.pictureBox1.Image = imagen;

                        }
                    }
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}