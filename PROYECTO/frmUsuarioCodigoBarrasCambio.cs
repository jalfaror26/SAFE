using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;

namespace PROYECTO
{
    public partial class frmUsuarioCodigoBarrasCambio : Form
    {
        private static frmUsuarioCodigoBarrasCambio Instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

        private string usuario = "";

        public frmUsuarioCodigoBarrasCambio(string pusuario)
        {
            InitializeComponent();
            usuario = pusuario;
        }

        public static frmUsuarioCodigoBarrasCambio getInstance(string usuario)
        {
            if (Instance == null)
                Instance = new frmUsuarioCodigoBarrasCambio(usuario);
            return Instance;
        }

        private void frmUsuarioAdministracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmUsuarioAdministracion.getInstance().Enabled = true;
            Instance = null;
        }

        private void btnCambiarContrasenna_Click(object sender, EventArgs e)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (oConexion.existeUsuario(usuario, txtContrasennaActual.Text, PROYECTO.Properties.Settings.Default.No_cia) && txtNuevaContrasenna.Text.Equals(txtConfirmNueva.Text))
                    {
                        UsuarioDAO ousuarioDAO = new UsuarioDAO();

                        oConexion.cerrarConexion();
                        oConexion.abrirConexion();

                        ousuarioDAO.CambiarCodigoBarras(usuario, txtConfirmNueva.Text, PROYECTO.Properties.Settings.Default.No_cia);
                        if (ousuarioDAO.Error())
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos del usuario." + ousuarioDAO.DescError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite la informacion solicitada correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNuevaContrasenna.Clear();
                        txtContrasennaActual.Clear();
                        txtConfirmNueva.Clear();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void frmUsuarioContraseñaCambio_Load(object sender, EventArgs e)
        {
            label4.Text = usuario;
        }
    }
}