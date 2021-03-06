using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using System.Collections;
using System.IO;
using ENTIDADES;
using Entidades;

namespace PROYECTO
{
    public partial class frmUsuarioAdministracion : Form
    {
        private static frmUsuarioAdministracion ofrmPermisos2 = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private UsuarioDAO ousuarioDAO = null;
        private Usuario oUsuario = null;

        private Boolean nuevo = true;
        private DataTable miArray = null;
        private String codigo = "sis_usuariopermiso", descripcion = "Administración de usuario.", modulo = "Seguridad";
        private string origen = "";
        private string txtRutaLogo = "", txtRutaDirectorio = "";
        private EmpresaDAO oEmpresaDAO = new EmpresaDAO();

        public frmUsuarioAdministracion()
        {
            InitializeComponent();
        }

        public static frmUsuarioAdministracion getInstance()
        {
            if (ofrmPermisos2 == null)
                ofrmPermisos2 = new frmUsuarioAdministracion();
            return ofrmPermisos2;
        }

        private void frmPermisos2_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmPermisos2 = null;
        }

        private void frmPermisos2_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            try
            {
                if (PROYECTO.Properties.Settings.Default.FormaConectar.Equals("1"))
                    rbo1.Checked = true;
                else
                    rbo2.Checked = true;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    label1.Text = PROYECTO.Properties.Settings.Default.Usuario;
                    origen = "";
                    imgFoto.Image = null;
                    imgFoto.Visible = true;

                    ousuarioDAO = new UsuarioDAO();
                    DataTable oImagen = ousuarioDAO.consultaImagen(label1.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    imgFoto.Image = null;
                    if (oImagen.Rows.Count > 0)
                    {
                        if (oImagen.Rows[0].ItemArray[0] != null)
                        {
                            byte[] imageBytes = (byte[])oImagen.Rows[0].ItemArray[0];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
                              imageBytes.Length);

                            ms.Write(imageBytes, 0, imageBytes.Length);
                            Image image = Image.FromStream(ms, true);
                            imgFoto.Image = image;
                        }
                    }

                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbo1.Checked)
                    PROYECTO.Properties.Settings.Default.FormaConectar = "1";
                else if (rbo2.Checked)
                    PROYECTO.Properties.Settings.Default.FormaConectar = "2";

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    int p = 0;
                    for (int x = ofdRutaImagen.FileName.Length - 1; x > 0; x--)
                    {
                        string v = ofdRutaImagen.FileName[x].ToString();
                        if (v.Equals("\\"))
                        {
                            p = x;
                            x = 0;
                        }
                    }

                    string nombreLogo = "";
                    if (p > 0)
                    {
                        nombreLogo = ofdRutaImagen.FileName.Substring(p, ofdRutaImagen.FileName.Length - p);
                    }

                    Image image = imgFoto.Image;

                    byte[] bLogo;
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        image.Save(mStream, image.RawFormat);
                        bLogo = mStream.ToArray();
                    }

                    ousuarioDAO = new UsuarioDAO();

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();

                    if (!nombreLogo.Equals(""))
                    {
                        oUsuario = new Usuario();

                        oUsuario.CodUsuario = label1.Text;

                        ousuarioDAO.GuardarImagen(oUsuario, bLogo, PROYECTO.Properties.Settings.Default.No_cia);
                        if (ousuarioDAO.Error())
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos del usuario." + ousuarioDAO.DescError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void imgFoto_Click(object sender, EventArgs e)
        {
            try
            {
                ofdRutaImagen.Filter = "All Formats|*.JPG|JPEG (*.JPG)|*.JPG";
                if (ofdRutaImagen.ShowDialog() == DialogResult.OK)
                {
                    origen = ofdRutaImagen.FileName;
                    imgFoto.ImageLocation = ofdRutaImagen.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmUsuarioAdministracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t16");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }


        private void ofdRutaImagen_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.FileInfo f2 = new System.IO.FileInfo(ofdRutaImagen.FileName);
            if (f2.Length > 32000)
            {
                MessageBox.Show("Solo se permiten imagenes jpeg con tamańo menor a 32kb");
                imgFoto.Image = null;
                ofdRutaImagen = new OpenFileDialog();
            }
        }

        private void btnCambiarContraseńa_Click(object sender, EventArgs e)
        {
            frmUsuarioContraseńaCambio ofrmcambio = frmUsuarioContraseńaCambio.getInstance(label1.Text, "N");
            ofrmcambio.MdiParent = this.MdiParent;
            ofrmcambio.Show();
            this.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}