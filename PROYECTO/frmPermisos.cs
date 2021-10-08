using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using System.Collections;
using ENTIDADES;
using System.Text.RegularExpressions;
using Entidades;

namespace PROYECTO
{
    public partial class frmPermisos : Form
    {
        private static frmPermisos ofrmPermisos = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private UsuarioDAO oUsuarioDAO = null;
        private Usuario oUsuario = null;

        private Boolean nuevo = true;
        private PantallasPermisosDAO opantallaDAO = null;

        private String codigo = "sis_usuariopermiso", descripcion = "Registro de usuarios y sus permisos.", modulo = "Seguridad";


        public String Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public frmPermisos()
        {
            InitializeComponent();
        }

        public static frmPermisos getInstance()
        {
            if (ofrmPermisos == null)
                ofrmPermisos = new frmPermisos();
            return ofrmPermisos;
        }

        private void frmPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmPermisos = null;
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnMNuevo.PerformClick();
        }

        private void llenarGrid()
        {
            try
            {

                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oUsuarioDAO = new UsuarioDAO();
                    dgrUsuarios.DataSource = oUsuarioDAO.consultaUsuarios(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oUsuarioDAO.Error())
                        MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            llenarGrid();
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodUsuario.Text = dgrUsuarios["usuario", e.RowIndex].Value.ToString();

                txtIdentificacion.Text = dgrUsuarios["cedula", e.RowIndex].Value.ToString();
                txtNombre.Text = dgrUsuarios["nombre", e.RowIndex].Value.ToString();
                txtApellido1.Text = dgrUsuarios["apellido1", e.RowIndex].Value.ToString();
                txtApellido2.Text = dgrUsuarios["apellido2", e.RowIndex].Value.ToString();
                txtCorreo.Text = dgrUsuarios["email", e.RowIndex].Value.ToString();

                txtcontrasenna.Text = "********************";
                txtContrasenna2.Text = "********************";
                if (dgrUsuarios["rol", e.RowIndex].Value.ToString().Equals("ADMINISTRADOR"))
                    rboAdministrador.Checked = true;
                else
                    rboFuncionario.Checked = true;

                btnMEliminar.Enabled = true;
                btnMAsignarPermisos.Enabled = true;

                txtCodUsuario.ReadOnly = true;

                txtcontrasenna.Enabled = false;
                txtContrasenna2.Enabled = false;

                grbRol.Enabled = false;

                llenarGridPermisos();
                permisosPantallas();
                nuevo = false;

                HabilitaPermisos(true);
            }
            catch { }
        }

        private void HabilitaPermisos(Boolean pHabilita)
        {
            try
            {
                dgrPantallas.Enabled = pHabilita;
                chkTodasPantallas.Enabled = pHabilita;
                btnGuardarPermisos.Enabled = pHabilita;
            }
            catch { }
        }

        private void llenarGridPermisos()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    opantallaDAO = new PantallasPermisosDAO();
                    DataTable oDataTable = opantallaDAO.consultaPantallas().Tables[0];
                    dgrPantallas.DataSource = oDataTable;
                    if (opantallaDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void permisosPantallas()
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodUsuario.Text))
                    return;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    opantallaDAO = new PantallasPermisosDAO();
                    DataSet oDataSet = opantallaDAO.consultaPantallasPermisos(txtCodUsuario.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow oFila in oDataSet.Tables[0].Rows)
                        {
                            foreach (DataGridViewRow oFila1 in dgrPantallas.Rows)
                            {
                                if (oFila1.Cells["PAN_ID"].Value.ToString().Equals(oFila["PAN_ID"].ToString()) && oFila["ACCESO"].ToString().Equals("1"))
                                    oFila1.Cells["ACCESO"].Value = "1";
                            }
                        }
                    }
                    if (opantallaDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    opantallaDAO = new PantallasPermisosDAO();
                    foreach (DataGridViewRow oFila1 in dgrPantallas.Rows)
                    {
                        opantallaDAO.crearAcceso(dgrUsuarios.SelectedCells[0].Value.ToString(), oFila1.Cells["pan_id"].Value.ToString(), int.Parse(oFila1.Cells["acceso"].Value.ToString()), PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    if (opantallaDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Accesos agregados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                    chkTodasPantallas.Checked = false;
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private Boolean Existente()
        {
            Boolean existe = false;
            foreach (DataGridViewRow oFila in dgrUsuarios.Rows)
            {
                if (oFila.Cells["usuario"].Value.ToString().Equals(txtCodUsuario.Text))
                    existe = true;
            }
            return existe;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && nuevo)
            {
                tabControl1.SelectedIndex = 0;
                btnMNuevo.PerformClick();
                MessageBox.Show("Seleccione el usuario para ver sus permisos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtcontrasenna_Leave(object sender, EventArgs e)
        {
            if (Valida_Contrasenna(txtcontrasenna.Text.Trim()))
                txtContrasenna2.Focus();
            else
            {
                MessageBox.Show("La contraseña no es valida, La contraseña debe tener 8 caracteres, incluyendo 1 letra mayúscula, 1 carácter especial, caracteres alfanuméricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcontrasenna.Focus();
            }
        }

        private Boolean Valida_Contrasenna(String input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            return hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
        }

        private void txtContrasenna2_Leave(object sender, EventArgs e)
        {
            if (!txtcontrasenna.Text.Trim().Equals(txtContrasenna2.Text.Trim()))
            {
                MessageBox.Show("La contraseña y la confirmacion deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            txtCodUsuario.Clear();
            txtContrasenna2.Clear();
            txtcontrasenna.Clear();

            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtCorreo.Clear();

            rboAdministrador.Checked = true;
            dgrUsuarios.ClearSelection();

            nuevo = true;

            btnMEliminar.Enabled = false;
            btnMAsignarPermisos.Enabled = false;

            txtCodUsuario.ReadOnly = false;

            txtcontrasenna.Enabled = true;
            txtContrasenna2.Enabled = true;

            grbRol.Enabled = true;

            HabilitaPermisos(false);
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodUsuario.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtNombre.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre del usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevo)
                {
                    if (txtcontrasenna.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Digite la contraseña del usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!Valida_Contrasenna(txtcontrasenna.Text.Trim()))
                    {
                        MessageBox.Show("La contraseña no es valida, La contraseña debe tener 8 caracteres, incluyendo 1 letra mayúscula, 1 carácter especial, caracteres alfanuméricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtcontrasenna.Focus();
                        return;
                    }
                    if (txtContrasenna2.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Digite la confirmacion de contraseña del usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!txtcontrasenna.Text.Trim().Equals(txtContrasenna2.Text.Trim()))
                    {
                        MessageBox.Show("La contraseña y la confirmacion deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (Existente())
                    {
                        MessageBox.Show("Usuario existente favor ingresar uno nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oUsuario = new Usuario();

                    oUsuario.CodUsuario = txtCodUsuario.Text.Trim();
                    oUsuario.Contrasenna = txtcontrasenna.Text.Trim();
                    oUsuario.Rol = rboAdministrador.Checked ? "ADMINISTRADOR" : "FUNCIONARIO";
                    oUsuario.Cedula = txtIdentificacion.Text.Trim();
                    oUsuario.Nombre = txtNombre.Text.Trim();
                    oUsuario.Apellido1 = txtApellido1.Text.Trim();
                    oUsuario.Apellido2 = txtApellido2.Text.Trim();
                    oUsuario.Email = txtCorreo.Text.Trim();

                    oUsuarioDAO = new UsuarioDAO();
                    oUsuarioDAO.Agregar(oUsuario, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oUsuarioDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    oConexion.cerrarConexion();
                    llenarGrid();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgrUsuarios.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione el usuario a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oUsuario = new Usuario();

                        oUsuario.CodUsuario = txtCodUsuario.Text;

                        oUsuarioDAO = new UsuarioDAO();
                        oUsuarioDAO.Eliminar(oUsuario, PROYECTO.Properties.Settings.Default.No_cia);
                        if (oUsuarioDAO.Error())
                            MessageBox.Show("Ocurrió un error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Usuario eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        llenarGrid();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnMAsignarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrUsuarios.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el usuario asignar permisos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tabControl1.SelectedIndex = 1;
                llenarGridPermisos();
                permisosPantallas();
            }
            catch { }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void chkTodasPantallas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodasPantallas.Checked)
            {
                for (int x = 0; x < dgrPantallas.Rows.Count; x++)
                {
                    dgrPantallas.Rows[x].Cells["acceso"].Value = "1";
                }
            }
            else
            {
                llenarGridPermisos();
                permisosPantallas();
            }
        }

    }
}