using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.IO;

namespace PROYECTO
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private ServicioDAO oServicioDAO = new ServicioDAO();
        private ProveedorDAO oProveedorDAO = new ProveedorDAO();
        private static frmServicios instance = null;
        private Boolean nuevo = false;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Servicio oServicio;
        private double indice = 0;

        private String codigo = "par_Servicios", descripcion = "Mantenimiento de servicios", modulo = "Mantenimientos";

        private String codigo2 = "", descripcion2 = "", modulo2 = "";

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

        public static frmServicios getInstance()
        {
            if (instance == null)
                instance = new frmServicios();
            return instance;
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            try
            {
                btnMNuevo.PerformClick();
                Llenar_Grid();
            }
            catch (Exception ex)
            {

            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";

            indice = 0;

            nuevo = true;
            /*Codigos*/
            /*Descripciones*/
            txtDesBreveArt.Clear();

            /*Precios*/
            txtPrecioCosto.Text = "0";
            txtPrecioVenta.Text = "0";
            txtImpuesto.Text = "0";
            chkIVI.Checked = false;
            chkIVI.Enabled = false;

        }

        public void LlenarServicio(String cod, String des, String dato1)
        {
            try
            {
                LimpiarCampos();
                txtDesBreveArt.Text = des;

                buscarServicios();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            //frmConsulta oConsulta = frmConsulta.getInstance("ARTICULO_ARTICULOS");
            //oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            //oConsulta.ShowDialog();
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {

        }

        private void Agregar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicio = new Servicio();
                    oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oServicio.Tipo = "SER";
                    oServicio.Impuestos = Double.Parse(txtImpuesto.Text);

                    if (oServicio.Impuestos == 0)
                        oServicio.Venta_IVI = "N";
                    else
                    {
                        if (chkIVI.Checked)
                            oServicio.Venta_IVI = "S";
                        else
                            oServicio.Venta_IVI = "N";
                    }

                    oServicio.Indice = indice;
                    oServicio.Codigo = txtCodigo.Text;
                    oServicio.Descripcion = txtDesBreveArt.Text;

                    oServicio.Nombre = txtDesBreveArt.Text;
                    oServicio.TipoCodigo = "IN";

                    indice = double.Parse(oServicioDAO.Agregar(oServicio));

                    if (oServicio.Indice == 0)
                    {
                        oServicio.Indice = indice;
                        oServicio.Codigo = indice.ToString();
                        oServicioDAO.Agregar(oServicio);
                        oServicio.Indice = 0;
                    }

                    if (oServicio.Indice == 0)
                        txtCodigo.Text = indice.ToString();

                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al guardar:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Llenar_Grid();
                    LimpiarCampos();
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

        private void Modificar()
        {
            try
            {
                if (txtDesBreveArt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite la descripción del artículo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Agregar();
            }
            catch (Exception ex) { }
        }

        private void Eliminar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicio = new Servicio();
                    oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oServicio.Tipo = "SER";
                    oServicio.Indice = indice;

                    oServicioDAO.Eliminar(oServicio);
                    if (oServicioDAO.Error())
                    {
                        MessageBox.Show("Error al eliminar:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                    Llenar_Grid();
                    btnMNuevo.PerformClick();
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

        private void frmArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                instance = null;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtCantEmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;
                for (int i = 0; i < txtPrecioCosto.Text.Length; i++)
                {
                    if (txtPrecioCosto.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                txtPrecioCosto.Text = "0";
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;
                for (int i = 0; i < txtPrecioVenta.Text.Length; i++)
                {
                    if (txtPrecioVenta.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                txtPrecioVenta.Text = "0";
            }
        }

        private void txtPrecioCosto_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrecioCosto.Text = Double.Parse(txtPrecioCosto.Text.Substring(1)).ToString("########0.##");

                if (txtPrecioCosto.Text.Equals("0"))
                    txtPrecioCosto.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioVenta_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrecioVenta.Text = Double.Parse(txtPrecioVenta.Text.Substring(1)).ToString("########0.##");
                if (txtPrecioVenta.Text.Equals("0"))
                    txtPrecioVenta.Clear();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecioVenta.Text.Trim().Equals(""))
                    txtPrecioVenta.Text = "0";

                txtPrecioVenta.Text = Double.Parse(txtPrecioVenta.Text).ToString("###,###,##0.##");
                //ponerSimbolos();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioCosto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecioCosto.Text.Trim().Equals(""))
                    txtPrecioCosto.Text = "0";

                txtPrecioCosto.Text = Double.Parse(txtPrecioCosto.Text).ToString("###,###,##0.##");
                //ponerSimbolos();
            }
            catch (Exception ex)
            {

            }
        }


        private Boolean TienePermiso()
        {
            try
            {
                Boolean tienePermiso = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();

                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo2);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo2, modulo2, descripcion2, PROYECTO.Properties.Settings.Default.No_cia);
                    }

                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo2, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odataset.Tables[0].Rows[0]["PER_ACCESO"].ToString().Equals("0"))
                        tienePermiso = true;
                    oConexion.cerrarConexion();
                }

                return tienePermiso;
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
                return false;
            }
        }

        public void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioDAO.ConsultarTodo(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indice = double.Parse(dgrDatos["ART_INDICE", e.RowIndex].Value.ToString());
                txtCodigo.Text = dgrDatos["ART_CODIGO", e.RowIndex].Value.ToString();
                txtDesBreveArt.Text = dgrDatos["ART_DESC_BREVE", e.RowIndex].Value.ToString();
                txtImpuesto.Text = double.Parse(dgrDatos["ART_IMPUESTOS", e.RowIndex].Value.ToString()).ToString("##0.##");

                if (txtImpuesto.Text.Equals("0"))
                {
                    chkIVI.Checked = false;
                    chkIVI.Enabled = false;
                }
                else
                {
                    chkIVI.Enabled = true;
                    if (dgrDatos["ART_VENTA_IVI", e.RowIndex].Value.ToString().Equals("S"))
                        chkIVI.Checked = true;
                    else
                        chkIVI.Checked = false;
                }

                nuevo = false;

                txtDesBreveArt.Focus();

            }
            catch (Exception ex) { }
        }

        private void dgrDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void buscarServicios()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oData = oServicioDAO.ConsultarEspecificoIndice2(indice.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oData.Rows.Count > 0)
                        {
                            txtCodigo.Text = oData.Rows[0]["ART_CODIGO"].ToString();
                            txtDesBreveArt.Text = oData.Rows[0]["ART_DESC_BREVE"].ToString();

                        }
                        oConexion.cerrarConexion();
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtFiltroCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtFiltroDescBreve.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    filtrarGrid(1, txtFiltroCodigo.Text);
            }
        }

        private void txtFiltroDescBreve_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtFiltroDescBreve.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    filtrarGrid(2, txtFiltroDescBreve.Text);
            }
        }


        private void filtrarGrid(int ind, string palabraFiltro)
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioDAO.Listar(ind, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex) { }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();

        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void txtImpuesto_Enter(object sender, EventArgs e)
        {
            txtImpuesto.Text = double.Parse(txtImpuesto.Text).ToString("##0.##");
            if (txtImpuesto.Text.Equals("0"))
                txtImpuesto.Clear();
        }

        private void txtImpuesto_Leave(object sender, EventArgs e)
        {
            if (txtImpuesto.Text.Trim().Equals(""))
                txtImpuesto.Text = "0";

            if (txtImpuesto.Text.Trim().Equals("0"))
                chkIVI.Enabled = false;
            else
                chkIVI.Enabled = true;

            txtImpuesto.Text = double.Parse(txtImpuesto.Text).ToString("##0.##");
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtDesBreveArt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La descripción del artículo está vacía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Eliminar();
            }
        }

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t3");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }
    }
}