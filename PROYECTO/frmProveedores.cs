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
    public partial class frmProveedores : Form
    {
        private frmProveedores()
        {
            InitializeComponent();
        }

        private ProveedorDAO oProveedorDAO = new ProveedorDAO();
        private static frmProveedores instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor,Conexion.getInstance().Clave);
        private Proveedor oProveedor;
        private String codigo = "par_proveedores", descripcion = "Registro de proveedores del sistema.", modulo = "Mantenimientos";
        private Double indiceProveedor = 0;

        public String Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        public String Descripcion1
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public static frmProveedores getInstance()
        {
            if (instance == null)
                instance = new frmProveedores();
            return instance;
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Proveedores ";
            Llenar_Grid();
            LlenarCombos();
            btnMNuevo.PerformClick();
        }

        private void LlenarCombos()
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("-- NO APLICA --");
            cboCategoria.Items.Add("COMPRAS");
            cboCategoria.Items.Add("SERVICIO");

            cboTipoId.Items.Clear();
            cboTipoId.Items.Add("Física");
            cboTipoId.Items.Add("Jurídica");
            cboTipoId.Items.Add("Pasaporte");
            cboTipoId.Items.Add("Residencia");
            cboTipoId.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            LlenarCombos();
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtContacto.Text = "";
            txtTelContacto.Text = "";
            txtDescripcion.Text = "";
            txtUbicacion.Text = "";
            cboTipoId.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            txtDias.Text = "0";
            /*************************************/

            txtrefbancaria.Text = "";
            dgrDatos.ClearSelection();
        }

        #region Métodos privados de la Clase

        private void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oProveedorDAO.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oProveedorDAO.Error())
                        MessageBox.Show("Error al listar los datos de proveedores:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Llenar_Grid(int tipo, String palabra)
        {
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                dgrDatos.DataSource = oProveedorDAO.Listar(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                if (oProveedorDAO.Error())
                {
                    MessageBox.Show("Error al listar los datos de proveedores:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrDatos.Rows.Count > 0)
                {
                    indiceProveedor = Double.Parse(dgrDatos["PROV_LINEA", e.RowIndex].Value.ToString());
                    txtId.Text = dgrDatos["PROV_ID", e.RowIndex].Value.ToString();
                    txtNombre.Text = dgrDatos["PROV_NOMBRE", e.RowIndex].Value.ToString();
                    txtTelefono.Text = dgrDatos["PROV_TELEFONO", e.RowIndex].Value.ToString();
                    txtFax.Text = dgrDatos["PROV_FAX", e.RowIndex].Value.ToString();
                    txtContacto.Text = dgrDatos["PROV_CONTACTO", e.RowIndex].Value.ToString();
                    txtTelContacto.Text = dgrDatos["PROV_TEL_CONTACTO", e.RowIndex].Value.ToString();
                    txtUbicacion.Text = dgrDatos["PROV_UBICACION", e.RowIndex].Value.ToString();
                    txtDescripcion.Text = dgrDatos["PROV_DESCRIPCION", e.RowIndex].Value.ToString();
                    txtDias.Text = dgrDatos["PROV_DIAS", e.RowIndex].Value.ToString();
                    cboCategoria.Text = dgrDatos["PROV_CATEGORIA", e.RowIndex].Value.ToString();
                    txtrefbancaria.Text = dgrDatos["PROV_REFBANCARIA", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex) { }
        }

        private Boolean ValidarDatos()
        {
            Boolean correcto = true;
            if (txtId.Text.Trim().Equals("") || txtNombre.Text.Trim().Equals("") || cboCategoria.SelectedIndex == -1)
                correcto = false;
            return correcto;
        }

        private void Agregar()
        {
            try
            {
                if (ValidarDatos())
                {
                    if (Existente())
                    {
                        MessageBox.Show("Error al agregar:\nProveedor Existente", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnMNuevo.PerformClick();
                        return;
                    }
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oProveedor = new Proveedor();

                        oProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oProveedor.Indice = indiceProveedor;
                        oProveedor.Id = txtId.Text;
                        oProveedor.TipoID = cboTipoId.SelectedItem.ToString();
                        oProveedor.Nombre = txtNombre.Text;
                        oProveedor.Telefono = txtTelefono.Text;
                        oProveedor.Fax = txtFax.Text;
                        oProveedor.Contacto = txtContacto.Text;
                        oProveedor.TelContacto = txtTelContacto.Text;
                        oProveedor.Ubicacion = txtUbicacion.Text;
                        oProveedor.Descripcion = txtDescripcion.Text;
                        if (txtDias.Text.Trim().Equals(""))
                            oProveedor.Dias = 0;
                        else
                            oProveedor.Dias = Convert.ToInt32(txtDias.Text);
                        oProveedor.Categoria = cboCategoria.Text;
                        oProveedor.RefBancaria = txtrefbancaria.Text;
                        oProveedorDAO.Agregar(oProveedor);
                        if (oProveedorDAO.Error())
                            MessageBox.Show("Error al agregar:\n" + oProveedorDAO.DescError(), "Error de Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Agregado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnMNuevo.PerformClick();
                        }
                        oConexion.cerrarConexion();
                        Llenar_Grid();
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                    }
                }
                else
                {
                    MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtId.Text.Trim().Equals(""))
                        txtId.Focus();
                    else
                        txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Modificar()
        {
            try
            {
                if (ValidarDatos())
                {
                    if (dgrDatos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oProveedor = new Proveedor();

                        oProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oProveedor.Indice = indiceProveedor;
                        oProveedor.Id = txtId.Text;
                        oProveedor.TipoID = cboTipoId.SelectedItem.ToString();
                        oProveedor.Nombre = txtNombre.Text;
                        oProveedor.Telefono = txtTelefono.Text;
                        oProveedor.Fax = txtFax.Text;
                        oProveedor.Contacto = txtContacto.Text;
                        oProveedor.TelContacto = txtTelContacto.Text;
                        oProveedor.Ubicacion = txtUbicacion.Text;
                        oProveedor.Descripcion = txtDescripcion.Text;
                        if (txtDias.Text.Trim().Equals(""))
                            oProveedor.Dias = 0;
                        else
                            oProveedor.Dias = Convert.ToInt32(txtDias.Text);
                        oProveedor.Categoria = cboCategoria.Text;
                        oProveedor.RefBancaria = txtrefbancaria.Text;
                        oProveedorDAO.Modificar(oProveedor);
                        if (oProveedorDAO.Error())
                        {
                            MessageBox.Show("Error al Modificar el Proveedor:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Modificado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        Llenar_Grid();
                        btnMNuevo.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                    }
                }
                else
                {
                    MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtId.Text.Trim().Equals(""))
                        txtId.Focus();
                    else
                        txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Eliminar()
        {
            try
            {
                if (ValidarDatos())
                {
                    if (dgrDatos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oProveedor = new Proveedor();

                        oProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oProveedor.Indice = indiceProveedor;
                        oProveedorDAO.Eliminar(oProveedor);
                        if (oProveedorDAO.Error())
                        {
                            MessageBox.Show("Error al Eliminar el Proveedor:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Eliminado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        Llenar_Grid();
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                    }
                }
                else
                {
                    MessageBox.Show("Error:\nExisten campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtId.Text.Trim().Equals(""))
                        txtId.Focus();
                    else
                        txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        private void btnBusq2_Click(object sender, EventArgs e)
        {

        }

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBNombre.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    Llenar_Grid(2, txtBNombre.Text);
            }
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBId.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    Llenar_Grid(1, txtBId.Text);
            }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
            btnMNuevo.PerformClick();
        }

        private Boolean Existente()
        {
            Boolean existe = false;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
            {
                if (oFila.Cells["PROV_ID"].Value.ToString().Equals(txtId.Text))
                    existe = true;
            }
            return existe;
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || txtDias.Text.Length > 3 || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsWhiteSpace(e.KeyChar) && !Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('(') && !e.KeyChar.Equals(')') && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
                e.Handled = true;
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsWhiteSpace(e.KeyChar) && !Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('(') && !e.KeyChar.Equals(')') && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
                e.Handled = true;
        }

        private void txtTelContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsWhiteSpace(e.KeyChar) && !Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('(') && !e.KeyChar.Equals(')') && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
                e.Handled = true;
        }

        private void dgrDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            indiceProveedor = 0;
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            if (indiceProveedor == 0)
                Agregar();
            else
                Modificar();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
                btnMNuevo.PerformClick();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (e.KeyCode == Keys.F1)
                    Ayuda();
            }
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t5");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }
    }
}