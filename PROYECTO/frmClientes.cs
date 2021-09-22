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
    public partial class frmClientes : Form
    {


        private frmClientes()
        {
            InitializeComponent();
        }

        private ClienteDAO oClienteDAO_MC = new ClienteDAO();
        private static frmClientes instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Cliente oCliente_MC;
        private Int32 indice;
        private String codigo = "par_clientes", descripcion = "Registro de clientes del sistema.", modulo = "Parametros_Generales";
        private string txtCodigo = "";

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



        public static frmClientes getInstance()
        {
            if (instance == null)
                instance = new frmClientes();
            return instance;
        }


        private void frmClientes_Load(object sender, EventArgs e)
        {
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Clientes ";
            Llenar_Grid();
            LlenarCombos();
            btnMNuevo.PerformClick();
            LimpiarCampos();
        }

        private void LlenarCombos()
        {
            cboTipoId.Items.Clear();

            cboTipoId.Items.Add("F�sica");
            cboTipoId.Items.Add("Jur�dica");
            cboTipoId.Items.Add("Pasaporte");
            cboTipoId.Items.Add("Residencia");
            cboTipoId.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            indice = 0;
            cboTipoId.Items.Clear();
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtContacto.Text = "";
            txtCorreo.Text = "";
            txtUbicacion.Text = "";
            txtDias.Text = "0";
            LlenarCombos();
            txtIdentificacion.Clear();
            dgrDatos.ClearSelection();
            cboLCMoneda.SelectedIndex = 0;
            txtLCLimite.Text = "0";
            /*************************************/
            txtBId.Text = "";
            txtBNombre.Text = "";
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oClienteDAO_MC.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];


                    //Evaluar si ocurrii� un Error
                    if (oClienteDAO_MC.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oClienteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos est�n correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void Llenar_Grid(int tipo, String palabra)
        {
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                dgrDatos.DataSource = oClienteDAO_MC.Listar(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                if (oClienteDAO_MC.Error())
                    MessageBox.Show("Error al listar los datos:\n" + oClienteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos est�n correctos");
            }

        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indice = Convert.ToInt32(dgrDatos["CLI_LINEA", e.RowIndex].Value.ToString());
                txtCodigo = dgrDatos["CLI_ID", e.RowIndex].Value.ToString();
                switch (dgrDatos["CLI_TIPO_ID", e.RowIndex].Value.ToString())
                {
                    case "F": cboTipoId.Text = "F�sica"; break;
                    case "J": cboTipoId.Text = "Jur�dica"; break;
                    case "P": cboTipoId.Text = "Pasaporte"; break;
                    case "R": cboTipoId.Text = "Residencia"; break;
                }
                txtNombre.Text = dgrDatos["CLI_NOMBRE", e.RowIndex].Value.ToString();
                txtTelefono.Text = dgrDatos["CLI_TELEFONO", e.RowIndex].Value.ToString();
                txtFax.Text = dgrDatos["CLI_FAX", e.RowIndex].Value.ToString();
                txtContacto.Text = dgrDatos["CLI_CONTACTO", e.RowIndex].Value.ToString();
                txtCorreo.Text = dgrDatos["CLI_CORREO", e.RowIndex].Value.ToString();
                txtUbicacion.Text = dgrDatos["CLI_UBICACION", e.RowIndex].Value.ToString();
                txtDias.Text = dgrDatos["CLI_DIAS", e.RowIndex].Value.ToString();
                txtIdentificacion.Text = dgrDatos["cli_identificacion", e.RowIndex].Value.ToString();

                cboLCMoneda.SelectedItem = dgrDatos["CLI_LC_MONEDA", e.RowIndex].Value.ToString();
                txtLCLimite.Text = double.Parse(dgrDatos["CLI_LC_LIMITE", e.RowIndex].Value.ToString()).ToString("###,###,##0.##");
            }
            catch (Exception ex) { }
        }

        private char EvaluarTipoID()
        {
            char ret = ' ';
            if (cboTipoId.Text.Equals("Jur�dica"))
                ret = 'J';
            if (cboTipoId.Text.Equals("F�sica"))
                ret = 'F';
            if (cboTipoId.Text.Equals("Pasaporte"))
                ret = 'P';
            if (cboTipoId.Text.Equals("Residencia"))
                ret = 'R';
            return ret;
        }

        private void Guardar()
        {
            try
            {

                if (txtNombre.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (txtIdentificacion.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCliente_MC = new Cliente();

                    oCliente_MC.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCliente_MC.Indice = indice;
                    oCliente_MC.Id = "";//txtCodigo.Text;
                    oCliente_MC.TipoId = EvaluarTipoID();
                    oCliente_MC.Nombre = txtNombre.Text;
                    oCliente_MC.Telefono = txtTelefono.Text;
                    oCliente_MC.Fax = txtFax.Text;
                    oCliente_MC.Contacto = txtContacto.Text;
                    oCliente_MC.Correo = txtCorreo.Text;
                    oCliente_MC.Ubicacion = txtUbicacion.Text;
                    oCliente_MC.Identificacion = txtIdentificacion.Text;
                    if (txtDias.Text.Trim().Equals(""))
                        oCliente_MC.Dias = 0;
                    else
                        oCliente_MC.Dias = Convert.ToInt32(txtDias.Text);

                    oCliente_MC.Almacen = 0;
                    oCliente_MC.DescAlmacen = "";

                    oCliente_MC.Lc_limite = double.Parse(txtLCLimite.Text);
                    oCliente_MC.Lc_moneda = cboLCMoneda.SelectedItem.ToString();

                    if (indice == 0)
                        oClienteDAO_MC.Agregar(oCliente_MC, out indice);
                    else
                        oClienteDAO_MC.Modificar(oCliente_MC);

                    if (oClienteDAO_MC.Error())
                        MessageBox.Show("Error al Guardar:\n" + oClienteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Guardado Correctamente!!", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Llenar_Grid();
                        btnMNuevo.PerformClick();
                    }
                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos est�n correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void Eliminar()
        {
            try
            {
                if (dgrDatos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCliente_MC = new Cliente();

                    oCliente_MC.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCliente_MC.Indice = indice;
                    oClienteDAO_MC.Eliminar(oCliente_MC);
                    if (oClienteDAO_MC.Error())
                    {
                        MessageBox.Show("Error al Eliminar:\n" + oClienteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Eliminado correctamente!!", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                    Llenar_Grid();
                    btnMNuevo.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos est�n correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private Boolean esCorreo(String correo)
        {
            try
            {
                Boolean bandera = false;
                if (correo.Equals(""))
                    bandera = true;
                else
                {
                    for (int i = 0; i < correo.Length; i++)
                    {
                        if (correo[i].Equals('@'))
                            bandera = true;
                    }
                }
                return bandera;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBId.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(1, txtBId.Text);
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBNombre.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBNombre.Text);
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
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

        private void dgrDatos_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void txtLCLimite_Enter(object sender, EventArgs e)
        {
            txtLCLimite.Text = double.Parse(txtLCLimite.Text).ToString("########0.##");
            if (txtLCLimite.Text.Equals("0"))
                txtLCLimite.Clear();
        }

        private void txtLCLimite_Leave(object sender, EventArgs e)
        {
            if (txtLCLimite.Text.Equals(""))
                txtLCLimite.Text = "0";
            txtLCLimite.Text = double.Parse(txtLCLimite.Text).ToString("###,###,##0.##");
        }

        private void txtLCLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtLCLimite.Text.Length; i++)
            {
                if (txtLCLimite.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Est� seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }
    }
}