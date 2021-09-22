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

namespace PROYECTO
{
    public partial class frmPermisos : Form
    {
        private static frmPermisos ofrmPermisos = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private UsuarioDAO ousuarioDAO = null;

        private Boolean nuevo = true;
        private PantallasPermisosDAO opantallaDAO = null;

        private String codigo = "sis_usuariopermiso", descripcion = "Registro de usuarios y sus permisos.", modulo = "Sistema";


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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombreusuario.Text = "";
            txtContrasenna2.Text = "";
            txtcontrasenna.Text = "";
            rboAdministrador.Checked = true;
            dgrUsuarios.ClearSelection();
            btnGuardar.Enabled = true;
            nuevo = true;
        }

        private void frmPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmPermisos = null;
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void llenarGrid()
        {
            try
            {

                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    ousuarioDAO = new UsuarioDAO();
                    dgrUsuarios.DataSource = ousuarioDAO.consultaUsuarios(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (ousuarioDAO.Error())
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
            llenarGrid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreusuario.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre de usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtcontrasenna.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite la contraseña del usuario a crear", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Nombre de usuario existente favor ingresar uno nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    string rol = rboAdministrador.Checked ? "ADMINISTRADOR" : "VENDEDOR";
                    ousuarioDAO = new UsuarioDAO();
                    ousuarioDAO.Agregar(txtNombreusuario.Text, txtcontrasenna.Text, rol, PROYECTO.Properties.Settings.Default.No_cia);
                    if (ousuarioDAO.Error())
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

        private void btnEliminar_Click(object sender, EventArgs e)
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
                        ousuarioDAO = new UsuarioDAO();
                        ousuarioDAO.Eliminar(dgrUsuarios.SelectedCells[0].Value.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                        if (ousuarioDAO.Error())
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

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreusuario.Text = dgrUsuarios["usuario", e.RowIndex].Value.ToString();
            txtcontrasenna.Text = "********************";
            txtContrasenna2.Text = "********************";
            if (dgrUsuarios["rol", e.RowIndex].Value.ToString().Equals("ADMINISTRADOR"))
                rboAdministrador.Checked = true;
            else
                rboVendedor.Checked = true;
            btnGuardar.Enabled = false;
            llenarGridPermisos();
            permisosPantallas();
            nuevo = false;
        }

        private void btnAsignarPermisos_Click(object sender, EventArgs e)
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

        private void llenarGridPermisos()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    opantallaDAO = new PantallasPermisosDAO();
                    dgrPantallas.DataSource = opantallaDAO.consultaPantallas().Tables[0];
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
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    opantallaDAO = new PantallasPermisosDAO();
                    DataSet oDataSet = opantallaDAO.consultaPantallasPermisos(dgrUsuarios.SelectedCells[0].Value.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow oFila in oDataSet.Tables[0].Rows)
                        {
                            foreach (DataGridViewRow oFila1 in dgrPantallas.Rows)
                            {
                                if (oFila1.Cells["pan_id"].Value.ToString().Equals(oFila.ItemArray[0].ToString()) && oFila.ItemArray[1].ToString().Equals("1"))
                                    oFila1.Cells["acceso"].Value = "1";
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
                if (oFila.Cells["usuario"].Value.ToString().Equals(txtNombreusuario.Text))
                    existe = true;
            }
            return existe;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && nuevo)
            {
                tabControl1.SelectedIndex = 0;
                btnNuevo.PerformClick();
                MessageBox.Show("Seleccione el usuario para ver sus permisos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgrPantallas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dgrUsuarioCentros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

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