using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Text.RegularExpressions;
using Entidades;

namespace PROYECTO
{
    public partial class frmUsuarioContraseñaCambio : Form
    {
        private static frmUsuarioContraseñaCambio Instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

        private string usuario = "";
        private Usuario oUsuario = null;

        public frmUsuarioContraseñaCambio(string pusuario)
        {
            InitializeComponent();
            usuario = pusuario;
        }

        public static frmUsuarioContraseñaCambio getInstance(string usuario)
        {
            if (Instance == null)
                Instance = new frmUsuarioContraseñaCambio(usuario);
            return Instance;
        }

        private void frmUsuarioAdministracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmUsuarioAdministracion.getInstance().Enabled = true;
            Instance = null;
        }

        private Boolean Valida_Contrasenna(String input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            return hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
        }

        private void btnCambiarContrasenna_Click(object sender, EventArgs e)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (oConexion.existeUsuario(usuario, txtContrasennaActual.Text, PROYECTO.Properties.Settings.Default.No_cia))
                    {

                        UsuarioDAO ousuarioDAO = new UsuarioDAO();

                        oConexion.cerrarConexion();
                        oConexion.abrirConexion();

                        if (!Valida_Contrasenna(txtNuevaContrasenna.Text.Trim()))
                        {
                            MessageBox.Show("La contraseña no es valida, La contraseña debe tener 8 caracteres, incluyendo 1 letra mayúscula, 1 carácter especial, caracteres alfanuméricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNuevaContrasenna.Focus();
                            return;
                        }

                        if (txtConfirmNueva.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Digite la confirmacion de contraseña del usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtConfirmNueva.Focus();
                            return;
                        }
                        if (!txtNuevaContrasenna.Text.Trim().Equals(txtConfirmNueva.Text.Trim()))
                        {
                            MessageBox.Show("La contraseña y la confirmacion deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtConfirmNueva.Focus();
                            return;
                        }

                        oUsuario = new Usuario();

                        oUsuario.CodUsuario = usuario;
                        oUsuario.Contrasenna = txtConfirmNueva.Text;

                        ousuarioDAO.CambiarContraseña(oUsuario, PROYECTO.Properties.Settings.Default.No_cia);
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
            this.Text = this.Text + " - " + this.Name;
            label4.Text = usuario;
        }

        private void txtNuevaContrasenna_Leave(object sender, EventArgs e)
        {
            if (Valida_Contrasenna(txtNuevaContrasenna.Text.Trim()))
                txtConfirmNueva.Focus();
            else
            {
                MessageBox.Show("La contraseña no es valida, La contraseña debe tener 8 caracteres, incluyendo 1 letra mayúscula, 1 carácter especial, caracteres alfanuméricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaContrasenna.Focus();
            }
        }

        private void txtConfirmNueva_Leave(object sender, EventArgs e)
        {
            if (!txtNuevaContrasenna.Text.Trim().Equals(txtConfirmNueva.Text.Trim()))
            {
                MessageBox.Show("La contraseña y la confirmacion deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}