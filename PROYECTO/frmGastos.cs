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
    public partial class frmGastos : Form
    {

        private ConexionDAO oConexion;
        private static frmGastos instance = null;
        private GastoDAO oGastosDAO = new GastoDAO();
        private Gasto oGasto;
        private int gasto = 0;
        private String codigo = "par_Gastos", descripcion = "Registro de gastos del sistema.", modulo = "Mantenimientos";
        private Boolean nuevo = false;

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

        public frmGastos()
        {
            InitializeComponent();
        }

        public static frmGastos getInstance()
        {
            if (instance == null)
                instance = new frmGastos();
            return instance;
        }

        private void LimpiarCampos()
        {
            gasto = 0;
            nuevo = true;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtBCodigo.Text = "";
            txtBNombre.Text = "";
            dgrDatos.ClearSelection();
        }
        private void Guardar()
        {
            try
            {
                if (!txtCodigo.Text.Equals("") && !txtNombre.Text.Equals(""))
                {
                    if (Existente())
                    {
                        MessageBox.Show("Error al Agregar:\nTipo de Gasto Existente", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //tobNuevo.PerformClick();
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oGasto = new Gasto();

                        oGasto.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oGasto.Indice = gasto;
                        oGasto.Nombre = txtNombre.Text;
                        oGasto.Codigo = txtCodigo.Text;
                        oGasto.Tipo = cmbTipo.Text;
                        oGastosDAO.Guardar(oGasto);
                        if (oGastosDAO.Error())
                            MessageBox.Show("Error al guardar los datos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Guardado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        llenaGrid();
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese los datos a guardar en las cajas de texto", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void llenaGrid()
        {
            try
            {

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oGastosDAO.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    //Evaluar si ocurriió un Error
                    if (oGastosDAO.Error())
                        MessageBox.Show("Error al Listar los datos de los gastos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void llenaGrid2(int tipo, string palabra)
        {
            try
            {

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oGastosDAO.Listar(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    //Evaluar si ocurriió un Error
                    if (oGastosDAO.Error())
                        MessageBox.Show("Error al Listar los datos de los gastos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmTiposGastos_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;

            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Tipos de Gastos ";
            llenaGrid();
            btnMNuevo.PerformClick();
            cmbTipo.SelectedIndex = 0;
        }

        private void txtBCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBCodigo.Text.Trim().Equals(""))
                    llenaGrid();
                else
                    llenaGrid2(1, txtBCodigo.Text);
            }
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBNombre.Text.Trim().Equals(""))
                    llenaGrid();
                else
                    llenaGrid2(2, txtBNombre.Text);
            }
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            cmbTipo.SelectedIndex = 0;
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gasto = int.Parse(dgrDatos["gas_indice", e.RowIndex].Value.ToString());
                txtNombre.Text = dgrDatos["gas_nombre", e.RowIndex].Value.ToString();
                txtCodigo.Text = dgrDatos["gas_codigo", e.RowIndex].Value.ToString();
                cmbTipo.Text = dgrDatos["gas_tipo", e.RowIndex].Value.ToString();

                nuevo = false;

                txtNombre.Focus();

            }
            catch (Exception ex) { }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Esta seguro que desea ELIMINAR el Registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gasto != 0)
                    {

                        oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                        oConexion.cerrarConexion();
                        if (oConexion.abrirConexion())
                        {
                            oGasto = new Gasto();

                            oGasto.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                            oGasto.Indice = gasto;
                            oGastosDAO.Eliminar(oGasto);
                            if (oGastosDAO.Error())
                                MessageBox.Show("Error al Eliminar los datos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Eliminado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            oConexion.cerrarConexion();
                            llenaGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione el gasto a Eliminar", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmTiposGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
            instance = null;
        }

        private Boolean Existente()
        {
            Boolean existe = false;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
            {
                if (oFila.Cells["codig"].Value.ToString().Equals(txtCodigo.Text))
                    existe = true;
            }
            return existe;
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
            frmAyuda oFrm = frmAyuda.getInstance("t6");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }
    }
}