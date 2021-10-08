using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Collections;
using System.Drawing.Printing;
using System.IO;


namespace PROYECTO
{
    public partial class frmCotizacion : Form
    {
        private static frmCotizacion instance = null;
        private ProformaDAO oProformaDAO = null;
        private Proforma oProforma = null;
        private ProformaDetalleDAO oProformaDetalleDAO = null;
        private ProformaDetalle oProformaDetalle = null;

        private TipoCambioDAO oTipoCambioDAO = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ServicioDAO oServicioDAO = null;
        private DataSet TipoCambio = null;
        private ReportesDAO oReporteDAO = new ReportesDAO();
        private Cantidad_a_Letra objeto;

        private String codigo = "pro_cotizacion", descripcion = "Cotización de Servicios.", modulo = "Procesos";

        private String tipoDocumento = "";
        private Double IndiceDocumento = 0, indiceArticulo = 0;
        private int indiceProforma = 0;
        private String tipoCliente = "", txtUbicacion = "", txtTelefono = "", cmbMoneda = "COL", lblMontoEnLetras = "", idCliente = "";

        private double txtTipoCambio = 0, cantidad2 = 0;
        private DateTime dtpFechaProforma;
        private String IVI = "N";
        private double IV = 0;

        private int indiceDetalle = 0, cliente = 0, txtDias = 0, tipoDescuento = 0;

        private String codigoAbrir = "", descripcionAbrir = "", moduloAbrir = "";

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

        public frmCotizacion()
        {
            InitializeComponent();
        }

        public static frmCotizacion getInstance()
        {
            if (instance == null)
                instance = new frmCotizacion();
            return instance;
        }

        private void frmCotizacioncion_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void obtieneTipoCambio()
        {
            try
            {

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oTipoCambioDAO = new TipoCambioDAO();
                    TipoCambio = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia);
                    if (oTipoCambioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los tipos de cambio: " + oTipoCambioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        txtTipoCambio = Double.Parse(TipoCambio.Tables[0].Rows[0]["cambio_dolar"].ToString());
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private Boolean cantidadRegistros()
        {
            try
            {
                Boolean cant = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDAO = new ProformaDAO();
                    DataTable odata = oProformaDAO.consultaCantProformas(PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        if (double.Parse(odata.Rows[0].ItemArray[0].ToString()) > 0)
                            cant = true;
                    }
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return cant;
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
                return true;
            }
        }

        private void limpiar()
        {

            txtANombreDe.Text = "";
            txtCliente.Text = "";
            btnBusqCliente.Enabled = true;
            txtDias = 0;

            txtCantidad.Text = "0";
            txtCodarticulo.Text = "";
            indiceArticulo = 0;
            txtPrecioUnitario.Text = "¢ 0";
            txtTotalPorLinea.Text = "¢ 0";
            txtDescArticulo.Text = "";
            txtDescuento.Text = "¢ 0";
            txtEstado.Text = "ABIERTA";
            txtMonto_IV.Text = "¢ 0";
            txtSubTotal.Text = "¢ 0";
            indiceDetalle = 0;
            txtPorcDecuento.Text = "0";
            txtTelefono = "";
            txtTotalProforma.Text = "¢ 0";
            txtUbicacion = "";
            chkDescuento.Checked = false;
            idCliente = "";
            cmbMoneda = "COL";
            oConexion.cerrarConexion();
            oConexion.abrirConexion();
            DateTime fecha = oConexion.fecha();
            dtpFechaProforma = fecha;
            oConexion.cerrarConexion();
            limpiarAbajo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable miArreglo = new DataTable();

                // if (MessageBox.Show("Desea crear una nueva Proforma?", "Observacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtUsuario.Text = PROYECTO.Properties.Settings.Default.Usuario;

                    if (txtProforma.BackColor == Color.White && txtProforma.Text.Equals(""))
                    {
                        MessageBox.Show("Digite el numero de Proforma con que iniciara el sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oProformaDAO = new ProformaDAO();
                        oProforma = new Proforma();

                        oProforma.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oProforma.Cliente = "-1";
                        oProforma.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                        oProforma.Estado = txtEstado.Text;
                        oProforma.NumProforma = int.Parse(txtProforma.Text);
                        oProforma.FechaProforma = dtpFechaProforma;
                        oProforma.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                        oProforma.Moneda = cmbMoneda;
                        oProforma.Nombre = txtANombreDe.Text;
                        oProforma.Observacion = "";
                        oProforma.Saldo = Double.Parse(txtTotalProforma.Text.Substring(1));
                        oProforma.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                        oProforma.Telefono = txtTelefono;
                        oProforma.Tipocambio = txtTipoCambio;
                        oProforma.Total = Double.Parse(txtTotalProforma.Text.Substring(1));
                        oProforma.Ubicacion = txtUbicacion;
                        oProforma.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                        oProforma.Vendedor = PROYECTO.Properties.Settings.Default.Usuario;
                        if (rbContado.Checked)
                            oProforma.Tipo = "CONTADO";
                        else
                            oProforma.Tipo = "CREDITO";
                        oProforma.IndiceDocumento = 0;
                        oProforma.TipoDocumento = "";
                        miArreglo = oProformaDAO.Agregar(oProforma);
                        if (oProformaDAO.Error())
                            MessageBox.Show("Ocurrio un error al guardar los datos: " + oProformaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        txtProforma.ReadOnly = true;
                        txtProforma.BackColor = Color.Blue;
                        txtProforma.ForeColor = Color.White;
                        txtProforma.Text = miArreglo.Rows[0].ItemArray[0].ToString();
                        indiceProforma = int.Parse(miArreglo.Rows[0].ItemArray[1].ToString());
                        btnBusqCliente.PerformClick();
                        lblMontoEnLetras = "";
                    }
                    else
                        MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnBusqCliente.PerformClick();
                limpiar();
                llenarGrid();
                txtCodarticulo.Focus();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnnuevoDetalle_Click(object sender, EventArgs e)
        {
            limpiarAbajo();
            txtCodarticulo.Focus();
        }

        private void limpiarAbajo()
        {
            txtCodarticulo.ReadOnly = false;
            cantidad2 = 0;
            btnGuardarDetalle.Text = " F3 - Guardar";
            btnGuardarDetalle.ImageIndex = 1;
            txtCantidad.Text = "0";
            txtCodarticulo.Text = "";
            indiceArticulo = 0;
            txtDescArticulo.Text = "";
            indiceDetalle = 0;
            txtSubTotalLinea.Text = cmbMoneda.Equals("COL") ? "¢ 0" : cmbMoneda.Equals("USD") ? "$ 0" : "€ 0";
            txtPrecioUnitario.Text = cmbMoneda.Equals("COL") ? "¢ 0" : cmbMoneda.Equals("USD") ? "$ 0" : "€ 0";
            txtTotalPorLinea.Text = cmbMoneda.Equals("COL") ? "¢ 0" : cmbMoneda.Equals("USD") ? "$ 0" : "€ 0";
            txtLineaDescuento.Text = "0";

            dgrDatos.ClearSelection();
            txtCantidad.ReadOnly = false;

            IVI = "N";
            IV = 0;
        }

        private void frmCotizacioncion_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            btnGuardar.Visible = true;
            obtieneTipoCambio();

            limpiar();
            if (!cantidadRegistros())
            {
                txtProforma.ReadOnly = false;
                txtProforma.BackColor = Color.White;
                txtProforma.ForeColor = Color.Black;
            }
            else
                txtProforma.Text = "0";
            Cargar();
        }

        public void cargaCliente(String codigo, String nombre)
        {
            try
            {
                idCliente = codigo;

                if (codigo.Equals("-1"))
                {
                    rbContado.Checked = true;
                    rbCredito.Enabled = false;
                }
                else
                    rbCredito.Enabled = true;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDAO = new ProformaDAO();
                    DataTable odata = oProformaDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        //if (!codigo.Equals("-1"))
                        txtANombreDe.Text = odata.Rows[0]["cli_nombre"].ToString();
                        txtCliente.Text = odata.Rows[0]["CLI_IDENTIFICACION"].ToString();
                        //else
                        //{
                        //    txtANombreDe.Clear();
                        //    txtANombreDe.Focus();
                        //}
                        txtTelefono = odata.Rows[0]["cli_telefono"].ToString();
                        txtUbicacion = odata.Rows[0]["cli_ubicacion"].ToString();
                        txtDias = int.Parse(odata.Rows[0]["cli_dias"].ToString());
                    }

                    if (txtDias == 0)
                        rbContado.Checked = true;
                    else
                        rbCredito.Checked = true;
                    
                    modificar();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        public void cargaProforma(String Proforma, String nombre)
        {
            try
            {
                string anterior = txtProforma.Text;

                String pProforma = Proforma[0].ToString();
                for (int x = 1; x < Proforma.Length; x++)
                {
                    if (char.IsNumber(Proforma[x]))
                        pProforma += Proforma[x];
                    else
                        x = Proforma.Length;
                }

                Proforma = pProforma;

                txtProforma.Text = Proforma;

                txtANombreDe.Text = nombre;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDAO = new ProformaDAO();
                    DataTable odata = oProformaDAO.ConsultaProforma(txtProforma.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        indiceProforma = int.Parse(odata.Rows[0]["fac_linea"].ToString());
                        dtpFechaProforma = DateTime.Parse(odata.Rows[0]["fac_fecha"].ToString());
                        idCliente = odata.Rows[0]["fac_cliente"].ToString();

                        if (idCliente.Equals("-1"))
                        {
                            rbCredito.Enabled = false;
                        }
                        else
                        {
                            rbCredito.Enabled = true;
                        }

                        txtANombreDe.Text = odata.Rows[0]["fac_nombre"].ToString();
                        txtTelefono = odata.Rows[0]["fac_telefono"].ToString();
                        txtUbicacion = odata.Rows[0]["fac_ubicacion"].ToString();
                        cmbMoneda = odata.Rows[0]["fac_moneda"].ToString();
                        txtTipoCambio = double.Parse(odata.Rows[0]["fac_tipo_cambio"].ToString());
                        txtEstado.Text = odata.Rows[0]["fac_estado"].ToString();
                        String porcentaje = odata.Rows[0]["fac_pordescuento"].ToString();
                        if (porcentaje.Equals(""))
                            porcentaje = "0";
                        else if (porcentaje.Equals("0"))
                            chkDescuento.Checked = false;
                        else
                            chkDescuento.Checked = true;
                        txtPorcDecuento.Text = porcentaje;
                        txtUsuario.Text = odata.Rows[0]["FAC_USUARIO"].ToString();


                        if (cmbMoneda.Equals("COL"))
                        {
                            txtMonto_IV.Text = "¢ " + odata.Rows[0]["fac_subtotal"].ToString();
                            txtSubTotal.Text = "¢ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                            txtDescuento.Text = "¢ " + odata.Rows[0]["fac_descuento"].ToString();
                            txtTotalProforma.Text = "¢ " + odata.Rows[0]["fac_total"].ToString();
                        }
                        else if (cmbMoneda.Equals("USD"))
                        {
                            txtMonto_IV.Text = "$ " + odata.Rows[0]["fac_subtotal"].ToString();
                            txtSubTotal.Text = "$ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                            txtDescuento.Text = "$ " + odata.Rows[0]["fac_descuento"].ToString();
                            txtTotalProforma.Text = "$ " + odata.Rows[0]["fac_total"].ToString();
                        }

                        if (odata.Rows[0]["fac_tipo"].ToString().Equals("CONTADO"))
                        {
                            rbContado.Checked = true;
                        }
                        else
                        {
                            rbCredito.Checked = true;
                        }

                        try
                        {
                            IndiceDocumento = Double.Parse(odata.Rows[0]["fac_indicedocumento"].ToString());
                        }
                        catch
                        {
                            IndiceDocumento = 0;
                        }
                        tipoDocumento = odata.Rows[0]["fac_tipodocumento"].ToString();
                    }
                    else
                    {
                        if (!Proforma.Equals(anterior))
                            cargaProforma(anterior, "");
                        return;
                    }
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    odata = oProformaDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        txtDias = int.Parse(odata.Rows[0]["cli_dias"].ToString());
                        txtCliente.Text = odata.Rows[0]["CLI_IDENTIFICACION"].ToString();
                    }
                    else
                        txtDias = 0;

                    oConexion.cerrarConexion();
                    limpiarAbajo();
                    llenarGrid();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnBusqCliente_Click(object sender, EventArgs e)
        {
            frmConsultaCliente oConsulta = frmConsultaCliente.getInstance(this.Name);
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        private void btnBusqProforma_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("PROFORMA");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
            btnGuardar.Visible = true;
        }

        public void modificar()
        {
            try
            {
                if (txtEstado.Text.Equals("FACTURADA"))
                {
                    cargaProforma(txtProforma.Text, txtANombreDe.Text);
                    return;
                }
                if (indiceProforma == 0)
                {
                    cargaProforma(txtProforma.Text, txtANombreDe.Text);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    cargaProforma(txtProforma.Text, txtANombreDe.Text);
                    return;
                }
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDAO = new ProformaDAO();
                    oProforma = new Proforma();

                    oProforma.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oProforma.Indice = indiceProforma;
                    oProforma.Cliente = idCliente;
                    oProforma.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oProforma.PorDescuento = Double.Parse(txtPorcDecuento.Text);
                    oProforma.Estado = txtEstado.Text;
                    oProforma.NumProforma = int.Parse(txtProforma.Text);
                    oProforma.FechaProforma = dtpFechaProforma;
                    oProforma.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                    oProforma.Moneda = cmbMoneda;
                    oProforma.Nombre = txtANombreDe.Text;
                    String comentario = oProformaDAO.ConsultaProforma(txtProforma.Text, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["fac_observacion"].ToString();
                    oProforma.Observacion = comentario;
                    oProforma.Saldo = Double.Parse(txtTotalProforma.Text.Substring(1));
                    oProforma.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oProforma.Telefono = txtTelefono;
                    oProforma.Tipocambio = txtTipoCambio;
                    oProforma.Total = Double.Parse(txtTotalProforma.Text.Substring(1));
                    oProforma.Ubicacion = txtUbicacion;
                    oProforma.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oProforma.Vendedor = PROYECTO.Properties.Settings.Default.Usuario;
                    if (rbContado.Checked)
                        oProforma.Tipo = "CONTADO";
                    else
                        oProforma.Tipo = "CREDITO";

                    oProformaDAO.Modificar(oProforma);
                    if (oProformaDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oProformaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();

                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        public void modificarEstado()
        {
            try
            {
                if (indiceProforma == 0)
                {
                    cargaProforma(txtProforma.Text, txtANombreDe.Text);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    cargaProforma(txtProforma.Text, txtANombreDe.Text);
                    return;
                }
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDAO = new ProformaDAO();
                    oProforma = new Proforma();

                    oProforma.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oProforma.Indice = indiceProforma;
                    oProforma.Cliente = idCliente;
                    oProforma.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oProforma.PorDescuento = Double.Parse(txtPorcDecuento.Text);
                    oProforma.Estado = txtEstado.Text;
                    oProforma.NumProforma = int.Parse(txtProforma.Text);
                    oProforma.FechaProforma = dtpFechaProforma;
                    oProforma.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                    oProforma.Moneda = cmbMoneda;
                    oProforma.Nombre = txtANombreDe.Text;
                    String comentario = oProformaDAO.ConsultaProforma(txtProforma.Text, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["fac_observacion"].ToString();
                    oProforma.Observacion = comentario;
                    oProforma.Saldo = Double.Parse(txtTotalProforma.Text.Substring(1));
                    oProforma.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oProforma.Telefono = txtTelefono;
                    oProforma.Tipocambio = txtTipoCambio;
                    oProforma.Total = Double.Parse(txtTotalProforma.Text.Substring(1));
                    oProforma.Ubicacion = txtUbicacion;
                    oProforma.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oProforma.Vendedor = PROYECTO.Properties.Settings.Default.Usuario;

                    if (rbContado.Checked)
                        oProforma.Tipo = "CONTADO";
                    else
                        oProforma.Tipo = "CREDITO";

                    oProformaDAO.ModificaEstadoProforma(oProforma);
                    if (oProformaDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oProformaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();

                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void btnBusqArticulo_Click(object sender, EventArgs e)
        {
            frmConsultaServicios oConsulta = new frmConsultaServicios("frmCotizacion");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        public void cargaArticulo(String pindiceArticulo, String pDescripcion, String pIVI, double pIV)
        {
            try
            {
                IVI = pIVI;
                IV = pIV;

                txtPrecioUnitario.ForeColor = Color.Black;
                txtPrecioUnitario.BackColor = Color.White;

                txtPrecioUnitario.ReadOnly = false;

                txtCodarticulo.Text = pindiceArticulo;
                indiceArticulo = double.Parse(pindiceArticulo);
                txtDescArticulo.Text = pDescripcion;

                txtPrecioUnitario.Text = cmbMoneda.Equals("COL") ? double.Parse("0").ToString("¢ ###,###,##0.##") : cmbMoneda.Equals("USD") ? double.Parse("0").ToString("$ ###,###,##0.##") : double.Parse("0").ToString("€ ###,###,##0.##");

                txtCantidad.Focus();

                oConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            GuardarDetalle();
        }

        private void GuardarDetalle()
        {
            try
            {
                if (indiceProforma == 0)
                {
                    MessageBox.Show("Seleccione la Proforma a la cual agregara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtEstado.Text.Equals("FACTURADA"))
                {
                    MessageBox.Show("No se puede Modificar la Proforma porque ya es ta en estado: FACTURADA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (indiceArticulo == 0)
                {
                    MessageBox.Show("Seleccione el artículo a Proformar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPrecioUnitario.Text.Equals("") || txtPrecioUnitario.Text.Substring(1).Equals(" 0"))
                {
                    MessageBox.Show("Digite el costo unitario del artículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCantidad.Text.Equals("") || txtCantidad.Text.Equals("0"))
                {
                    MessageBox.Show("Digite la cantidad del artículo a Proformar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCliente.Text.Equals("") || idCliente.Equals(""))
                {
                    MessageBox.Show("Seleccione el cliente de la Proforma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDetalleDAO = new ProformaDetalleDAO();
                    oProformaDetalle = new ProformaDetalle();

                    oProformaDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                    if (btnGuardarDetalle.Text.Equals(" F3 - Guardar"))
                    {
                        oProformaDetalle.CodArticulo = indiceArticulo.ToString();

                        oProformaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oProformaDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oProformaDetalle.SubTotal = oProformaDetalle.PrecioUnitario * oProformaDetalle.Cantidad;
                        oProformaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oProformaDetalle.SubTotal * (oProformaDetalle.Descuento / 100);
                        oProformaDetalle.Monto_IV = IVI.Equals("S") ? 0 : oProformaDetalle.SubTotal * (IV / 100);
                        oProformaDetalle.PrecioTotal = oProformaDetalle.SubTotal - montoDescuento + oProformaDetalle.Monto_IV;

                        oProformaDetalle.Descripcion = txtDescArticulo.Text;
                        oProformaDetalle.TipoPrecio = 1;
                        oProformaDetalle.Medida = "UND";
                        oProformaDetalle.IndiceProforma = indiceProforma;

                        oProformaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;

                        oProformaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);

                        oProformaDetalle.IVI = IVI;

                        oProformaDetalleDAO.Agregar(oProformaDetalle);
                        if (oProformaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oProformaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (btnGuardarDetalle.Text.Equals(" F3 - Modificar"))
                    {
                        String embAnterior = "";
                        DataTable oEmba = oConexion.EjecutaSentencia("SELECT DETFAC_MEDIDA FROM TBL_PROFORMA_DETALLE pd where pd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_INDICEFACTURA='" + indiceProforma + "' and DETFAC_CODIGO='" + indiceArticulo);
                        if (oEmba.Rows.Count > 0)
                        {
                            embAnterior = oEmba.Rows[0].ItemArray[0].ToString();
                        }

                        if (indiceDetalle == 0)
                        {
                            MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        oProformaDetalle.CodArticulo = indiceArticulo.ToString();

                        oProformaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oProformaDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oProformaDetalle.SubTotal = oProformaDetalle.PrecioUnitario * oProformaDetalle.Cantidad;
                        oProformaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oProformaDetalle.SubTotal * (oProformaDetalle.Descuento / 100);
                        oProformaDetalle.Monto_IV = IVI.Equals("S") ? 0 : oProformaDetalle.SubTotal * (IV / 100);
                        oProformaDetalle.PrecioTotal = oProformaDetalle.SubTotal - montoDescuento + oProformaDetalle.Monto_IV;

                        oProformaDetalle.Descripcion = txtDescArticulo.Text;
                        oProformaDetalle.Medida = "UND";
                        oProformaDetalle.IndiceProforma = indiceProforma;

                        oProformaDetalle.TipoPrecio = 1;
                        oProformaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                        oProformaDetalle.Indice = indiceDetalle;

                        oProformaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        oProformaDetalle.IVI = IVI;

                        oProformaDetalleDAO.Modificar(oProformaDetalle);
                        if (oProformaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oProformaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    oConexion.cerrarConexion();

                    llenarGrid();

                    limpiarAbajo();
                    modificar();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (indiceProforma == 0)
                    {
                        MessageBox.Show("Seleccione la Proforma a la cual eliminara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (indiceDetalle == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("FACTURADA"))
                    {
                        MessageBox.Show("No se puede Modificar la Proforma porque ya es ta en estado: FACTURADA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("ANULADA"))
                    {
                        MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oProformaDetalleDAO = new ProformaDetalleDAO();
                        oProformaDetalle = new ProformaDetalle();

                        oProformaDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oProformaDetalle.IndiceProforma = indiceProforma;
                        oProformaDetalle.Indice = indiceDetalle;
                        oProformaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oProformaDetalle.CodArticulo = indiceArticulo.ToString();

                        oProformaDetalleDAO.Eliminar(oProformaDetalle);
                        if (oProformaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oProformaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        oConexion.cerrarConexion();
                        limpiarAbajo();
                        llenarGrid();
                        modificar();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void llenarGrid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oProformaDetalleDAO = new ProformaDetalleDAO();

                    dgrDatos.DataSource = oProformaDetalleDAO.Consulta(indiceProforma, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oProformaDetalleDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oProformaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    calculaValores();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void dgrdatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String cadena = "";

                indiceDetalle = int.Parse(dgrDatos["detfac_numerolinea", e.RowIndex].Value.ToString());
                txtCantidad.Text = dgrDatos["detfac_cantidad", e.RowIndex].Value.ToString();
                cantidad2 = Double.Parse(dgrDatos["detfac_cantidad", e.RowIndex].Value.ToString());
                indiceArticulo = double.Parse(dgrDatos["detfac_codigo", e.RowIndex].Value.ToString());
                txtCodarticulo.Text = dgrDatos["art_codigo", e.RowIndex].Value.ToString();
                txtDescArticulo.Text = dgrDatos["detfac_descripcion", e.RowIndex].Value.ToString();
                IVI = dgrDatos["detfac_ivi", e.RowIndex].Value.ToString();
                IV = double.Parse(dgrDatos["art_impuestos", e.RowIndex].Value.ToString());

                if (cmbMoneda.Equals("COL")) cadena = "¢";
                else if (cmbMoneda.Equals("USD")) cadena = "$";
                else if (cmbMoneda.Equals("EUR")) cadena = "€";

                txtPrecioUnitario.Text = cadena + Double.Parse(dgrDatos["DETFAC_PRECIO_UNITARIO", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.##");
                txtSubTotalLinea.Text = cadena + Double.Parse(dgrDatos["DETFAC_SUBTOTAL", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.##");
                txtLineaDescuento.Text = Double.Parse(dgrDatos["detfac_descuento", e.RowIndex].Value.ToString()).ToString("###,###,##0.##");
                txtTotalPorLinea.Text = cadena + Double.Parse(dgrDatos["DETFAC_PRECIO_TOTAL", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.##");


                btnGuardarDetalle.Text = " F3 - Modificar";
                txtCantidad.ReadOnly = true;
                txtCodarticulo.ReadOnly = true;
                btnGuardarDetalle.ImageIndex = 4;

                txtCantidad.ReadOnly = false;

                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCostoUnitario_TextChanged(object sender, EventArgs e)
        {
        }

        public void calculaValores()
        {
            try
            {
                Double totalMonto_IV = 0, granTotal = 0, totalLinea = 0, descuento = 0, subtotal = 0, porcDescuento = 0;

                foreach (DataGridViewRow ofila in dgrDatos.Rows)
                {
                    totalLinea += Double.Parse(ofila.Cells["DETFAC_PRECIO_TOTAL"].Value.ToString());
                    totalMonto_IV += Double.Parse(ofila.Cells["DETFAC_MONTO_IV"].Value.ToString());
                    subtotal += Double.Parse(ofila.Cells["DETFAC_SUBTOTAL"].Value.ToString());
                    porcDescuento = Double.Parse(ofila.Cells["detfac_descuento"].Value.ToString()) / 100;
                    descuento += subtotal * porcDescuento;
                }

                granTotal = totalLinea;

                if (chkDescuento.Checked)
                {
                    descuento = subtotal * (Double.Parse(txtPorcDecuento.Text) / 100);
                    if (descuento > 0)
                        granTotal -= descuento;
                }

                if (cmbMoneda.Equals("COL"))
                {
                    txtMonto_IV.Text = "¢ ";
                    txtSubTotal.Text = "¢ ";
                    txtDescuento.Text = "¢ ";
                    txtTotalProforma.Text = "¢ ";
                }
                else if (cmbMoneda.Equals("USD"))
                {
                    txtMonto_IV.Text = "$ ";
                    txtSubTotal.Text = "$ ";
                    txtDescuento.Text = "$ ";
                    txtTotalProforma.Text = "$ ";
                }
                else if (cmbMoneda.Equals("EUR"))
                {
                    txtMonto_IV.Text = "€ ";
                    txtSubTotal.Text = "€ ";
                    txtDescuento.Text = "€ ";
                    txtTotalProforma.Text = "€ ";
                }

                if (totalLinea > 0)
                    txtMonto_IV.Text += totalMonto_IV.ToString("###,###,##0.##");
                else
                    txtMonto_IV.Text += "0";

                if (subtotal > 0)
                    txtSubTotal.Text += subtotal.ToString("###,###,##0.##");
                else
                    txtSubTotal.Text += "0";

                if (descuento > 0)
                    txtDescuento.Text += descuento.ToString("###,###,##0.##");
                else
                    txtDescuento.Text += "0";

                if (granTotal > 0)
                {
                    if (cmbMoneda.Equals("COL"))
                    {
                        RedondearNumero oRedondear = new RedondearNumero();
                        granTotal = oRedondear.Redondear(granTotal);
                    }
                    txtTotalProforma.Text += granTotal.ToString("###,###,##0.##");
                }
                else
                    txtTotalProforma.Text += "0";
            }
            catch (Exception ex)
            {

            }
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (txtEstado.Text.Equals("FACTURADA"))
            {
                return;
            }
            if (txtEstado.Text.Equals("ANULADA"))
            {
                return;
            }
            txtPorcDecuento.ReadOnly = !chkDescuento.Checked;
            txtPorcDecuento.Text = "0";

        }

        private void txtTotalProforma_TextChanged(object sender, EventArgs e)
        {
            String cadena = "";
            if (txtTotalProforma.Text.Length > 2)
            {
                if (Double.Parse(txtTotalProforma.Text.Substring(1)) > 0)
                {
                    if (cmbMoneda.Equals("COL")) cadena = "colones";
                    else if (cmbMoneda.Equals("USD")) cadena = "dolares";
                    else if (cmbMoneda.Equals("EUR")) cadena = "euros";

                    objeto = new Cantidad_a_Letra();
                    String montoenletras = objeto.ConvertirCadena(Double.Parse(txtTotalProforma.Text.Substring(1)), cadena);
                    lblMontoEnLetras = montoenletras.ToUpper();
                }
            }
        }

        private void txtPorcDecuento_TextChanged(object sender, EventArgs e)
        {
            if (!txtPorcDecuento.Text.Equals(""))
                calculaValores();
        }

        private void txtPorcDecuento_KeyUp(object sender, KeyEventArgs e)
        {
            calculaValores();
        }

        private void btnProformar_Click(object sender, EventArgs e)
        {
            //if (txtProforma.Text.Equals(""))
            //{
            //    MessageBox.Show("Seleccione el documento a Facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (dgrDatos.Rows.Count == 0)
            //{
            //    MessageBox.Show("No se puede Facturar si no hay detalle en la Proforma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (txtCliente.Text.Trim().Equals("") || idCliente.Equals(""))
            //{
            //    MessageBox.Show("Seleccione el cliente de la Factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (txtEstado.Text.Equals("FACTURADA"))
            //{
            //    MessageBox.Show("Este documento ya fue Facturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (txtEstado.Text.Equals("ANULADA"))
            //{
            //    MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (rbCredito.Checked)
            //    if (MessageBox.Show("¿Está seguro que desea Facturar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        return;

            //modificar();

            //oConexion.cerrarConexion();
            //if (oConexion.abrirConexion())
            //{
            //    FacturaDAO oFacturaDAO = new FacturaDAO();
            //    Factura oFactura = new Factura();

            //    oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
            //    oFactura.Cliente = idCliente;
            //    oFactura.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
            //    oFactura.Estado = txtEstado.Text;
            //    oFactura.NumFactura = 1;
            //    oFactura.FechaFactura = oConexion.fecha();
            //    oFactura.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
            //    oFactura.Moneda = cmbMoneda;
            //    oFactura.Nombre = txtANombreDe.Text;
            //    oFactura.Observacion = "";
            //    oFactura.OrdenCompra = "";
            //    oFactura.Retencion = 0;
            //    oFactura.Saldo = rbCredito.Checked ? Double.Parse(txtTotalProforma.Text.Substring(1)) : 0;
            //    oFactura.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
            //    oFactura.Telefono = txtTelefono;
            //    oFactura.Tipocambio = txtTipoCambio;
            //    oFactura.Total = Double.Parse(txtTotalProforma.Text.Substring(1));
            //    oFactura.Adelanto = Double.Parse(txtTotalProforma.Text.Substring(1));
            //    oFactura.Ubicacion = txtUbicacion;
            //    oFactura.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
            //    oFactura.Vendedor = cmbVendedor.SelectedValue.ToString();
            //    oFactura.FormaPago = "";
            //    if (rbContado.Checked)
            //        oFactura.Tipo = "CONTADO";
            //    else
            //        oFactura.Tipo = "CREDITO";
            //    oFactura.IndiceDocumento = 0;
            //    oFactura.TipoDocumento = "";

            //    DataTable miArreglo = oFacturaDAO.Agregar(oFactura);
            //    if (oFacturaDAO.Error())
            //        MessageBox.Show("Ocurrio un error al crear la factura los datos: " + oFacturaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    oConexion.cerrarConexion();

            //    string numeroFactura = miArreglo.Rows[0].ItemArray[0].ToString();
            //    int indiceFactura = int.Parse(miArreglo.Rows[0].ItemArray[1].ToString());

            //    try
            //    {
            //        if (indiceFactura == 0)
            //        {
            //            MessageBox.Show("Seleccione la factura a la cual agregara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        if (txtEstado.Text.Equals("FACTURADA"))
            //        {
            //            MessageBox.Show("No se puede facturar la Proforma porque ya es ta en estado: FACTURADA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        if (txtCliente.Text.Equals("") || idCliente.Equals(""))
            //        {
            //            MessageBox.Show("Seleccione el cliente de la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        if (txtEstado.Text.Equals("ANULADA"))
            //        {
            //            MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        oConexion.cerrarConexion();
            //        if (oConexion.abrirConexion())
            //        {
            //            DataTable oDetalle = (DataTable)dgrDatos.DataSource;

            //            for (int x = 0; x < oDetalle.Rows.Count; x++)
            //            {
            //                double cantidad = 0;

            //                if (oDetalle.Rows[x]["DETFAC_TIPO"].ToString().Equals("ART"))
            //                {
            //                    DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT INV_CANTIDAD-INV_CANTIDAD_TRANSITO FROM TBL_INVENTARIO i where i.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  INV_COD_ARTICULO='" + oDetalle.Rows[x]["DETFAC_CODIGO"].ToString() + "' and INV_COD_PROVEEDOR=" + oDetalle.Rows[x]["DETFAC_PROVEEDOR"].ToString() + " and INV_COD_ALMACEN='" + oDetalle.Rows[x]["DETFAC_BODEGA"].ToString() + "' and INV_INDICE=" + oDetalle.Rows[x]["DETFAC_INDICEINVENTARIO"].ToString());
            //                    if (oTabla2.Rows.Count > 0)
            //                        existencia = int.Parse(oTabla2.Rows[0][0].ToString()) + cantidad2;

            //                    cantidad = int.Parse(oDetalle.Rows[x]["DETFAC_CANTIDAD"].ToString());

            //                    if (cantidad > existencia)
            //                        cantidad = existencia;
            //                }

            //                FacturaDetalleDAO oFacturaDetalleDAO = new FacturaDetalleDAO();
            //                FacturaDetalle oFacturaDetalle = new FacturaDetalle();

            //                oFacturaDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
            //                oFacturaDetalle.Bodega = oDetalle.Rows[x]["DETFAC_BODEGA"].ToString();
            //                oFacturaDetalle.CodArticulo = oDetalle.Rows[x]["DETFAC_CODIGO"].ToString();

            //                oFacturaDetalle.Cantidad = cantidad;
            //                oFacturaDetalle.PrecioUnitario = Double.Parse(oDetalle.Rows[x]["DETFAC_PRECIO_UNITARIO"].ToString());
            //                oFacturaDetalle.Subtotal = Double.Parse(oDetalle.Rows[x]["DETFAC_SUBTOTAL"].ToString());
            //                oFacturaDetalle.Descuento = double.Parse(oDetalle.Rows[x]["DETFAC_DESCUENTO"].ToString());
            //                double montoDescuento = oFacturaDetalle.Subtotal * (oFacturaDetalle.Descuento / 100);
            //                oFacturaDetalle.MontoIV = Double.Parse(oDetalle.Rows[x]["DETFAC_MONTO_IV"].ToString());
            //                oFacturaDetalle.PrecioTotal = Double.Parse(oDetalle.Rows[x]["DETFAC_PRECIO_TOTAL"].ToString());

            //                oFacturaDetalle.Descripcion = oDetalle.Rows[x]["DETFAC_DESCRIPCION"].ToString();
            //                oFacturaDetalle.TipoPrecio = 1;
            //                oFacturaDetalle.Medida = "UND";
            //                oFacturaDetalle.IndiceFactura = indiceFactura;
            //                oFacturaDetalle.UnidadesEmbalaje = 1;
            //                oFacturaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
            //                oFacturaDetalle.CostoCompra = 0;
            //                oFacturaDetalle.Tipo = oDetalle.Rows[x]["DETFAC_TIPO"].ToString();
            //                oFacturaDetalle.Proveedor = int.Parse(oDetalle.Rows[x]["DETFAC_PROVEEDOR"].ToString());
            //                oFacturaDetalle.IndiceInventario = int.Parse(oDetalle.Rows[x]["DETFAC_INDICEINVENTARIO"].ToString());
            //                oFacturaDetalle.Presentacion = int.Parse(oDetalle.Rows[x]["DETFAC_PRESENTACION"].ToString());
            //                oFacturaDetalle.IVI = oDetalle.Rows[x]["detfac_ivi"].ToString();

            //                oFacturaDetalleDAO.Agregar(oFacturaDetalle);
            //                if (oFacturaDetalleDAO.Error())
            //                    MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //            }


            //        }
            //        else
            //            MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        oConexion.cerrarConexion();
            //    }

            //    txtEstado.Text = "FACTURADA";
            //    modificarEstado();

            //    frmFacturacionRapida oFacturacion = frmFacturacionRapida.getInstance();
            //    oFacturacion.MdiParent = this.MdiParent;
            //    oFacturacion.Show();

            //    oFacturacion.cargaFactura(numeroFactura, "");

            //    this.Close();
            //}
            //else
            //    MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void cmbEmbalaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double total = 0;
            String cadena = "";
            if (!txtCantidad.Text.Equals("") && !txtCantidad.Text.Equals("0") && !txtPrecioUnitario.Text.Equals("") && !txtPrecioUnitario.Text.Equals("0"))
            {
                //if (cmbEmbalaje.SelectedIndex == 1)
                //    total = Double.Parse(txtCantidad.Text) * Double.Parse(txtUnidEmba.Text) * Double.Parse(txtCostoUnitario.Text);
                //else
                total = Double.Parse(txtCantidad.Text) * Double.Parse(txtPrecioUnitario.Text.Substring(1));
                if (cmbMoneda.Equals("COL"))
                    cadena = "¢";
                else if (cmbMoneda.Equals("USD"))
                    cadena = "$";
                else if (cmbMoneda.Equals("EUR"))
                    cadena = "€";

                txtTotalPorLinea.Text = cadena + " " + total.ToString("###,###,##0.##");
            }
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {

        }

        private void dgrdatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
            limpiarAbajo();
            if (dgrDatos.Rows.Count == 0)
            {
                btnGuardarDetalle.Text = " F3 - Guardar";
                btnGuardarDetalle.ImageIndex = 1;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {


        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                modificar();
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String sql = "";
                    if (idCliente.Equals(""))
                    {
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, '' codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, '' idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, ART_CODIGO codigoArticulo from TBL_PROFORMA F, TBL_PROFORMA_DETALLE df, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and ART_INDICE=DETFAC_CODIGO and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtProforma.Text + "' ORDER BY DETFAC_NUMEROLINEA";
                    }
                    else
                    {
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, cl.cli_id codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, cl.cli_identificacion idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, ART_CODIGO codigoArticulo from TBL_PROFORMA F, TBL_PROFORMA_DETALLE df, TBL_CLIENTES cl, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = cl.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and ART_INDICE=DETFAC_CODIGO and f.fac_cliente = cl.cli_linea and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtProforma.Text + "' ORDER BY DETFAC_NUMEROLINEA";
                    }

                    //DataTable oTabla = crearTabla(oReporteDAO.EjecutaSentencia(sql).Tables[0]);
                    //if (oTabla.Rows.Count > 0)
                    //{
                    //frmVisorReportesFactura oVisor = frmVisorReportesFactura.getInstance();
                    //oVisor.MdiParent = this.MdiParent;
                    //rptProforma oReporte = new rptProforma();
                    //oReporte.DataDefinition.FormulaFields["Proforma"].Text = "'" + txtProforma.Text + "'";
                    //oReporte.DataDefinition.FormulaFields["contado"].Text = "'" + (txtDias == 0 ? "CONTADO" : "CREDITO") + "'";
                    //oReporte.DataDefinition.FormulaFields["fechaPago"].Text = "'" + dtpFechaProforma.AddDays(txtDias).ToShortDateString() + "'";
                    //oReporte.DataDefinition.FormulaFields["totGrabado"].Text = double.Parse(txtGravado.Text.Substring(1)).ToString();
                    //oReporte.DataDefinition.FormulaFields["totExento"].Text = double.Parse(txtExento.Text.Substring(1)).ToString();
                    //oReporte.DataDefinition.FormulaFields["subtotal"].Text = double.Parse(txtSubTotal.Text.Substring(1)).ToString();
                    //oReporte.DataDefinition.FormulaFields["descuento"].Text = double.Parse(txtDescuento.Text.Substring(1)).ToString();
                    //oReporte.DataDefinition.FormulaFields["usuario"].Text = "'" + PROYECTO.Properties.Settings.Default.Usuario + "'";

                    //oReporte.SetDataSource(oTabla);
                    //oVisor.ReportSource(oReporte);
                    //oVisor.Show();
                    //}
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
            calcularTotalPorLinea();
        }
        private void txtProforma_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIndice_Enter(object sender, EventArgs e)
        {
            modificar();
        }

        private void txtPorcDecuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtPrecioUnitario.Text.Length; i++)
            {
                if (txtPrecioUnitario.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void txtIndice_Leave(object sender, EventArgs e)
        {
            modificar();
        }

        private DataTable crearTabla(DataTable oTabla)
        {
            try
            {
                DataTable oDataTable = new DataTable();
                DataRow oDataRow = null;
                //Boolean existe = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String nombreVendedor = "", inicialesVendedor = "";
                    DataTable oDatoVendedor = new DataTable();
                    Double adelantos = 0;
                    DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT SUM(RECFAC_MONTO) AS RECFAC_MONTO FROM TBL_RECIBOS_Proforma where RECFAC_Proforma= '" + txtProforma.Text + "'");
                    if (oTabla2.Rows.Count > 0)
                    {
                        try
                        {
                            adelantos = double.Parse(oTabla2.Rows[0]["RECFAC_MONTO"].ToString());
                        }
                        catch { }
                    }

                    oDataTable.Columns.Add("dia", typeof(string));
                    oDataTable.Columns.Add("nombre", typeof(string));
                    oDataTable.Columns.Add("telefono", typeof(string));
                    oDataTable.Columns.Add("ubicacion", typeof(string));
                    oDataTable.Columns.Add("cantidad", typeof(Int32));
                    oDataTable.Columns.Add("descripcion", typeof(string));
                    oDataTable.Columns.Add("costUnit", typeof(double));
                    oDataTable.Columns.Add("costTotal", typeof(double));
                    oDataTable.Columns.Add("Observación", typeof(string));
                    oDataTable.Columns.Add("montoLetras", typeof(string));
                    oDataTable.Columns.Add("subtotal", typeof(double));
                    oDataTable.Columns.Add("impuesto", typeof(double));
                    oDataTable.Columns.Add("excento", typeof(double));
                    oDataTable.Columns.Add("total", typeof(double));
                    oDataTable.Columns.Add("mes", typeof(string));
                    oDataTable.Columns.Add("anno", typeof(string));
                    oDataTable.Columns.Add("embalaje", typeof(string));
                    oDataTable.Columns.Add("moneda", typeof(string));
                    oDataTable.Columns.Add("adelanto", typeof(double));
                    oDataTable.Columns.Add("codigoCliente", typeof(string));
                    oDataTable.Columns.Add("pedido", typeof(string));
                    oDataTable.Columns.Add("idPersona", typeof(string));
                    oDataTable.Columns.Add("vendedor", typeof(string));
                    oDataTable.Columns.Add("codigoArticulo", typeof(string));
                    oDataTable.Columns.Add("indImpuesto", typeof(int));

                    oDataTable.Columns.Add("EMPR_IDENTIFICACION", typeof(string));
                    oDataTable.Columns.Add("logo", typeof(Byte[]));
                    oDataTable.Columns.Add("EMPR_NOMBRE", typeof(string));
                    oDataTable.Columns.Add("EMPR_DIRECCION", typeof(string));
                    oDataTable.Columns.Add("EMPR_TELEFONO", typeof(string));
                    oDataTable.Columns.Add("EMPR_CORREO", typeof(string));
                    oDataTable.Columns.Add("costototal", typeof(double));
                    oDataTable.Columns.Add("descuento", typeof(double));
                    oDataTable.Columns.Add("ARPRE_EMBALAJE", typeof(string));

                    foreach (DataRow oFila in oTabla.Rows)
                    {
                        oDataRow = oDataTable.NewRow();
                        oDataRow["dia"] = oFila["dia"].ToString();
                        oDataRow["nombre"] = oFila["nombre"].ToString();
                        oDataRow["telefono"] = oFila["telefono"].ToString();
                        oDataRow["ubicacion"] = oFila["ubicacion"].ToString();
                        oDataRow["cantidad"] = oFila["cantidad"].ToString();
                        oDataRow["descripcion"] = oFila["descripcion"].ToString(); ;
                        oDataRow["costUnit"] = oFila["costUnit"].ToString();
                        oDataRow["costTotal"] = oFila["costTotal"].ToString();
                        oDataRow["Observación"] = oFila["obcervacion"].ToString();
                        oDataRow["montoLetras"] = lblMontoEnLetras;
                        oDataRow["subtotal"] = oFila["subtotal"].ToString();
                        oDataRow["impuesto"] = oFila["impuesto"].ToString();
                        oDataRow["excento"] = oFila["excento"].ToString();
                        oDataRow["total"] = oFila["total"].ToString();
                        oDataRow["mes"] = oFila["mes"].ToString();
                        oDataRow["anno"] = oFila["anno"].ToString();
                        oDataRow["embalaje"] = oFila["embalaje"].ToString();
                        oDataRow["moneda"] = oFila["moneda"].ToString();
                        oDataRow["adelanto"] = adelantos;
                        oDataRow["codigoCliente"] = oFila["codigoCliente"].ToString();
                        oDataRow["pedido"] = oFila["pedido"].ToString();
                        oDataRow["idPersona"] = oFila["idPersona"].ToString();
                        oDatoVendedor = oConexion.EjecutaSentencia("select emp_nombre from TBL_EMPLEADO em WHERE em.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and emp_cedula = '" + oFila["vendedor"].ToString() + "'");
                        nombreVendedor = oDatoVendedor.Rows[0].ItemArray[0].ToString();
                        for (int i = 0; i < nombreVendedor.Length; i++)
                        {
                            try
                            {
                                if (i == 0)
                                    inicialesVendedor = nombreVendedor[i].ToString().ToUpper();
                                if (nombreVendedor[i].ToString().Equals(" "))
                                    inicialesVendedor += nombreVendedor[i + 1].ToString().ToUpper();
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        oDataRow["vendedor"] = inicialesVendedor;
                        oDataRow["codigoArticulo"] = oFila["codigoArticulo"].ToString();
                        oDataRow["indImpuesto"] = oFila["indImpuesto"].ToString();

                        byte[] imageBytes = new byte[10000];
                        imageBytes = (byte[])oFila["logo"];
                        oDataRow["EMPR_IDENTIFICACION"] = oFila["EMPR_IDENTIFICACION"].ToString();
                        oDataRow["logo"] = imageBytes;
                        oDataRow["EMPR_NOMBRE"] = oFila["EMPR_NOMBRE"].ToString();
                        oDataRow["EMPR_DIRECCION"] = oFila["EMPR_DIRECCION"].ToString();
                        oDataRow["EMPR_TELEFONO"] = oFila["EMPR_TELEFONO"].ToString();
                        oDataRow["EMPR_CORREO"] = oFila["EMPR_CORREO"].ToString();
                        oDataRow["costototal"] = oFila["costTotal"].ToString();
                        oDataRow["descuento"] = oFila["descuento"].ToString();
                        oDataRow["ARPRE_EMBALAJE"] = oFila["ARPRE_EMBALAJE"].ToString();
                        oDataTable.Rows.Add(oDataRow.ItemArray);
                    }
                }
                return oDataTable;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        private void txtDescArticulo_Enter(object sender, EventArgs e)
        {
            btnBusqArticulo.PerformClick();
        }

        private void btnRecibos_Click(object sender, EventArgs e)
        {

        }

        private void rbContado_CheckedChanged(object sender, EventArgs e)
        {
            modificar();
        }

        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            modificar();
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            modificar();
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            modificar();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text.Equals(""))
                    txtCantidad.Text = "0";

                calcularTotalPorLinea();
            }
            catch { }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals("0"))
                txtCantidad.Clear();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcDecuento_Leave(object sender, EventArgs e)
        {
            modificar();
        }

        public void Cargar()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    txtCliente.Clear();
                    cliente = 0;
                    txtDescArticulo.Clear();
                    llenarGrid();

                    IndiceDocumento = 0;

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    dtpFechaProforma = oConexion.fecha();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void CalculaEstado()
        {
            if (txtEstado.Text.Equals(""))
            {
                btnBProforma.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqArticulo.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimirTicket.Enabled = false;
            }
            else if (txtEstado.Text.Equals("ABIERTA"))
            {
                btnBProforma.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = true;
                btnFacturar.Enabled = true;
                btnNuevoDetalle.Enabled = true;
                btnBusqArticulo.Enabled = true;
                btnGuardarDetalle.Enabled = true;
                btnEliminarDetalle.Enabled = true;
                btnImprimirTicket.Enabled = true;
            }
            else if (txtEstado.Text.Equals("FACTURADA"))
            {
                btnBProforma.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqArticulo.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimirTicket.Enabled = false;
            }
            else if (txtEstado.Text.Equals("ANULADA"))
            {
                btnBProforma.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqArticulo.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimirTicket.Enabled = true;
            }
        }

        public void ImprimirTiquete(String nombre, double cancelacon, double vuelto, string formaPago, string documento)
        {
            //try
            //{
            //    PrintDocument pd = new PrintDocument();
            //    string name = pd.PrinterSettings.PrinterName;
            //    string nombreEmpresa = "", cedula = "", telefono = "", direccion = "", fax = "";
            //    int anchoTiquet = 0;
            //    // Byte[] bytes = null;

            //    oConexion.cerrarConexion();
            //    if (oConexion.abrirConexion())
            //    {
            //        DataTable oEmpresa = oConexion.EjecutaSentencia("select EMPR_NOMBRE, EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, EMPR_LOGO, NVL(anchotiquet,0) anchotiquet from TBL_EMPRESA em where no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");
            //        if (oEmpresa.Rows.Count > 0)
            //        {
            //            nombreEmpresa = oEmpresa.Rows[0]["EMPR_NOMBRE"].ToString();
            //            cedula = oEmpresa.Rows[0]["EMPR_IDENTIFICACION"].ToString();
            //            telefono = oEmpresa.Rows[0]["EMPR_TELEFONO"].ToString();
            //            direccion = oEmpresa.Rows[0]["EMPR_DIRECCION"].ToString();
            //            fax = oEmpresa.Rows[0]["EMPR_CORREO"].ToString();
            //            // bytes = (Byte[])oEmpresa.Rows[0]["EMPR_LOGO"];
            //            anchoTiquet = int.Parse(oEmpresa.Rows[0]["anchotiquet"].ToString());
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            //    }

            //    if (anchoTiquet <= 0)
            //    {
            //        MessageBox.Show("Configurar correctamente el ancho del tiquete de Factura.");
            //        return;
            //    }

            //    int y = 0;
            //    Ticket ticket = new Ticket("Impresion de Proforma");

            //    //Datos de Proforma
            //    // ticket.AddDatos(nombreEmpresa, "" + (20 - (nombreEmpresa.Length / 2)), y.ToString());

            //    string linea = nombreEmpresa, linea1 = "", linea2 = "", linea3 = "", linea4 = "";
            //    int renglon = 1, contador = 0;
            //    for (int x = 0; x < linea.Length; x++)
            //    {
            //        if (linea[x].Equals('|'))
            //        {
            //            contador = 0;
            //            renglon++;
            //        }
            //        else
            //        {
            //            contador++;
            //            if (renglon == 1)
            //                linea1 += linea[x];
            //            else if (renglon == 2)
            //                linea2 += linea[x];
            //            else if (renglon == 3)
            //                linea3 += linea[x];
            //            else if (renglon == 4)
            //                linea4 += linea[x];

            //            if (contador == 30 || (linea[x].Equals(' ') && contador > 25))
            //            {
            //                contador = 0;
            //                renglon++;
            //            }
            //        }
            //    }

            //    if (linea1.Length > 0)
            //    {
            //        linea = linea1;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }
            //    if (linea2.Length > 0)
            //    {
            //        linea = linea2;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y); ;
            //        y = y + 4;
            //    }
            //    if (linea3.Length > 0)
            //    {
            //        linea = linea3;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }
            //    if (linea4.Length > 0)
            //    {
            //        linea = linea4;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }


            //    //direccion = "Direccion: " + direccion;
            //    linea = direccion;
            //    linea1 = "";
            //    linea2 = "";
            //    linea3 = "";
            //    linea4 = "";
            //    renglon = 1;
            //    contador = 0;

            //    for (int x = 0; x < linea.Length; x++)
            //    {
            //        if (linea[x].Equals('|'))
            //        {
            //            contador = 0;
            //            renglon++;
            //        }
            //        else
            //        {
            //            contador++;
            //            if (renglon == 1)
            //                linea1 += linea[x];
            //            else if (renglon == 2)
            //                linea2 += linea[x];
            //            else if (renglon == 3)
            //                linea3 += linea[x];
            //            else if (renglon == 4)
            //                linea4 += linea[x];

            //            if (contador == 30 || (linea[x].Equals(' ') && contador > 25))
            //            {
            //                contador = 0;
            //                renglon++;
            //            }
            //        }
            //    }

            //    if (linea1.Length > 0)
            //    {
            //        linea = linea1;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }
            //    if (linea2.Length > 0)
            //    {
            //        linea = linea2;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y); ;
            //        y = y + 4;
            //    }
            //    if (linea3.Length > 0)
            //    {
            //        linea = linea3;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }
            //    if (linea4.Length > 0)
            //    {
            //        linea = linea4;
            //        ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //        y = y + 4;
            //    }

            //    cedula = "Ced: " + cedula;

            //    linea = cedula;
            //    ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //    //ticket.AddDatos(cedula, "" + (20 - (cedula.Length / 2)), y.ToString());
            //    y = y + 4;

            //    if (!telefono.Equals(""))
            //        telefono = "Tel: " + telefono;

            //    if (!telefono.Equals("") && !fax.Equals(""))
            //        telefono += "  /  Fax: " + fax;
            //    else if (telefono.Equals("") && !fax.Equals(""))
            //        telefono += "Fax: " + fax;

            //    linea = telefono;
            //    ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);
            //    //ticket.AddDatos(telefono, "" + 0, y.ToString());
            //    y = y + 2;


            //    //ticket.AddDatos("_____________________________________________", 0,y);

            //    oConexion.cerrarConexion();
            //    oConexion.abrirConexion();
            //    string fecha = oConexion.fecha().ToString();
            //    DataTable otfecha = oConexion.EjecutaSentencia("select FAC_FECHACREA from TBL_PROFORMA P where P.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and FAC_NUMERO=" + txtProforma.Text);
            //    if (otfecha.Rows.Count > 0)
            //        fecha = otfecha.Rows[0]["FAC_FECHACREA"].ToString();

            //    y = y + 4;
            //    linea = fecha;
            //    ticket.AddDatos(linea, 2,y);

            //    //ticket.AddDatos(fecha, 0,y);

            //    y = y + 4;
            //    string tipo = rbContado.Checked ? "CONTADO" : "CREDITO " + txtDias;

            //    linea = "Proforma: " + txtProforma.Text + "      " + tipo + "      Caj: " + txtUsuario.Text;
            //    ticket.AddDatos(linea, 2,y);
            //    y = y + 4;

            //    linea = "CLIENTE: " + nombre;
            //    ticket.AddDatos(linea, 2,y);

            //    y = y + 1;
            //    ticket.AddDatos("_____________________________________________", 0,y);

            //    y = y + 4;

            //    //linea = "Cant.   Descripcion                     Desc.   Subtotal";
            //    linea = "Cant.        Producto                         Desc.        Subtotal";
            //    ticket.AddDatos(linea, 0,y);

            //    y = y + 4;
            //    //Items
            //    int v = y;
            //    for (int x = 0; x < dgrDatos.Rows.Count; x++)
            //    {
            //        string Cant = dgrDatos.Rows[x].Cells["DETFAC_CANTIDAD"].Value.ToString();
            //        string embalaje = dgrDatos.Rows[x].Cells["ARPRE_EMBALAJE"].Value.ToString();
            //        string codigo = dgrDatos.Rows[x].Cells["ART_CODIGO"].Value.ToString();
            //        string descripcion = dgrDatos.Rows[x].Cells["DETFAC_DESCRIPCION"].Value.ToString();
            //        string Descripcion = descripcion; // dgrDatos.Rows[x].Cells["DETFAC_TIPO"].Value.ToString().Equals("ART") ? (embalaje + " - " + codigo + " - " + descripcion) : descripcion;
            //        string Desc = dgrDatos.Rows[x].Cells["DETFAC_DEScuento"].Value.ToString();

            //        string Subtotal = double.Parse(dgrDatos.Rows[x].Cells["DETFAC_PRECIO_TOTAL"].Value.ToString()).ToString("###,###,##0.##");

            //        double IV = double.Parse(dgrDatos.Rows[x].Cells["art_impuestos"].Value.ToString());
            //        String IVI = dgrDatos.Rows[x].Cells["detfac_ivi"].Value.ToString();

            //        if (IV <= 0)
            //            Subtotal += " *";
            //        else if (IV > 0)
            //        {
            //            if (IVI.Equals("S"))
            //                Subtotal += " **";
            //        }

            //        //ticket.AddItems(Cant + "?" + Descripcion + "?" + Desc + "?" + Subtotal, v.ToString());
            //        //y = y + 3;

            //        Cant = double.Parse(Cant).ToString("###,###,##0");
            //        ticket.AddItems(Cant + "?" + codigo + "?" + Desc + "?" + Subtotal, v.ToString());
            //        y = y + 3;

            //        ticket.AddItemDesc(embalaje + "?" + descripcion + "?" + "-" + "?" + "-", v.ToString());
            //        y = y + 3;

            //        ticket.AddItemDesc("" + "?" + "" + "?" + "" + "?" + "", v.ToString());
            //        y = y + 3;
            //    }

            //    y = y + 2;
            //    linea = "===========================================";
            //    ticket.AddDatos(linea, 0,y-1);
            //    y = y + 0;

            //    string simbolo = cmbMoneda.Equals("COL") ? "¢ " : "$ ";

            //    y = y + 4;
            //    ticket.AddDatos("SUBTOTAL :", 15,y);
            //    ticket.AddDatos(simbolo + double.Parse(txtSubTotal.Text.Substring(1)).ToString("###,###,##0.##"), 44,y);

            //    if (double.Parse(txtDescuento.Text.Substring(1)) > 0)
            //    {
            //        y = y + 4;
            //        ticket.AddDatos("DESCUENTO :", 15,y);
            //        ticket.AddDatos(simbolo + double.Parse(txtDescuento.Text.Substring(1)).ToString("###,###,##0.##"), 44,y);
            //    }

            //    y = y + 4;
            //    ticket.AddDatos("IV :", 15,y);
            //    ticket.AddDatos(simbolo + double.Parse(txtMonto_IV.Text.Substring(1)).ToString("###,###,##0.##"), 44,y);

            //    y = y + 4;
            //    ticket.AddDatos("TOTAL :", 15,y);
            //    ticket.AddDatos(simbolo + double.Parse(txtTotalProforma.Text.Substring(1)).ToString("###,###,##0.##"), 44,y);

            //    if (txtEstado.Text.Equals("ANULADA"))
            //    {
            //        y = y + 5;
            //        ticket.AddDatos("ANULADA", 15,y);
            //    }

            //    y = y + 7;

            //    linea = "*** MUCHAS GRACIAS POR PREFERIRNOS ***";
            //    ticket.AddDatos(linea, 0,y);
            //    y = y + 7;

            //    linea = "(*) Exento  |  (**) Impuesto de ventas Incluido";
            //    ticket.AddDatos(linea, 0,y);

            //    //ticket.AddDatos("* Producto Exento", 7,y);

            //    //y = y + 5;
            //    //linea = "* AUTORIZADO MEDIANTE RESOLUCION 11-97";
            //    //ticket.AddDatos(linea, 0,y);
            //    ////ticket.AddDatos("Autorizado mediante Oficio", "12", y.ToString());

            //    //y = y + 3;
            //    //linea = "DE DGT GACETA 171 DEL 05/09/97 *";
            //    //ticket.AddDatos(linea, ((anchoTiquet - linea.Length)), y);

            //    y = y + 5;
            //    oConexion.cerrarConexion();
            //    oConexion.abrirConexion();
            //    string vfecha = oConexion.fecha().ToString();
            //    linea = "** " + vfecha + " - ULTIMA LINEA **";
            //    ticket.AddDatos(linea, 4,y);

            //    ticket.PrintFactura(name);


            //    Boolean vCortaTicket = false;
            //    oConexion.cerrarConexion();
            //    if (oConexion.abrirConexion())
            //    {
            //        DataTable oMensajes = oConexion.EjecutaSentencia("select IND_CORTATICKET from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

            //        if (oMensajes.Rows.Count > 0)
            //            vCortaTicket = oMensajes.Rows[0]["IND_CORTATICKET"].ToString().Equals("S") ? true : false;

            //        oConexion.cerrarConexion();
            //    }

            //    ticket.CortaTicket(vCortaTicket);

            //    ticket.AbreCajon(false);
            //}
            //catch (Exception ex)
            //{
            //    oConexion.cerrarConexion();
            //}
        }

        private void calcularTotalPorLinea()
        {
            try
            {
                double porcDescuento = double.Parse(txtLineaDescuento.Text) / 100;
                double subtotal = Double.Parse(txtCantidad.Text) * Double.Parse(txtPrecioUnitario.Text.Substring(1));
                double sub = 0;
                double descuento = 0;

                //if (chkImpuesto.Checked)
                //    sub = subtotal - (subtotal * 0.13);
                //else
                sub = subtotal;

                descuento = (sub * porcDescuento);

                double total = subtotal - descuento;

                if (cmbMoneda.Equals("COL"))
                {
                    RedondearNumero oRedondear = new RedondearNumero();
                    total = oRedondear.Redondear(total);
                }

                switch (cmbMoneda.Trim())
                {
                    case "COL":
                        txtSubTotalLinea.Text = subtotal.ToString("¢ ###,###,##0.##");
                        txtTotalPorLinea.Text = total.ToString("¢ ###,###,##0.##");
                        break;
                    case "USD":
                        txtSubTotalLinea.Text = subtotal.ToString("$ ###,###,##0.##");
                        txtTotalPorLinea.Text = total.ToString("$ ###,###,##0.##");
                        break;
                    case "EUR":
                        txtSubTotalLinea.Text = subtotal.ToString("€ ###,###,##0.##");
                        txtTotalPorLinea.Text = total.ToString("€ ###,###,##0.##");
                        break;
                    default:
                        txtSubTotalLinea.Text = subtotal.ToString("###,###,##0.##");
                        txtTotalPorLinea.Text = total.ToString("###,###,##0.##");
                        break;
                }
            }
            catch (Exception ex) { }
        }

        private void txtLineaDescuento_Enter(object sender, EventArgs e)
        {
            txtLineaDescuento.Text = Double.Parse(txtLineaDescuento.Text).ToString("########0.##");
            if (txtLineaDescuento.Text.Equals("0"))
                txtLineaDescuento.Text = "";
        }

        private void txtLineaDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtLineaDescuento.Text.Length; i++)
            {
                if (txtLineaDescuento.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void txtLineaDescuento_Leave(object sender, EventArgs e)
        {
            if (txtLineaDescuento.Text.Equals(""))
                txtLineaDescuento.Text = "0";
            txtLineaDescuento.Text = Double.Parse(txtLineaDescuento.Text).ToString("###,###,##0.##");

            calcularTotalPorLinea();
        }

        private void frmCotizacioncion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8)
            {
                txtCodarticulo.Focus();

                if (e.KeyCode == Keys.F1)
                    btnNueva.PerformClick();
                else if (e.KeyCode == Keys.F2)
                    btnNuevoDetalle.PerformClick();
                else if (e.KeyCode == Keys.F3)
                {
                    btnGuardarDetalle.PerformClick();
                }
                else if (e.KeyCode == Keys.F4)
                    btnFacturar.PerformClick();
                else if (e.KeyCode == Keys.F5)
                    btnGuardar.PerformClick();
                //else if (e.KeyCode == Keys.F6)
                //    btnAnular.PerformClick();
                else if (e.KeyCode == Keys.F7)
                    btnEliminarDetalle.PerformClick();
                else if (e.KeyCode == Keys.F8)
                    btnImprimirTicket.PerformClick();
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            CalculaEstado();
        }

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            txtPrecioUnitario.Text = double.Parse(txtPrecioUnitario.Text.Substring(1)).ToString("########0.##");
            if (txtPrecioUnitario.Text.Equals("0"))
                txtPrecioUnitario.Clear();
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtPrecioUnitario.Text.Length; i++)
            {
                if (txtPrecioUnitario.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text.Equals(""))
                txtPrecioUnitario.Text = "0";
            txtPrecioUnitario.Text = double.Parse(txtPrecioUnitario.Text).ToString("¢ ###,###,##0.##");
            calcularTotalPorLinea();
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            ImprimirTiquete(txtANombreDe.Text, 0, 0, "", "");
        }

        private void BuscaCodigoArticulo()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    ServicioDAO oServicioDAO = new ServicioDAO();
                    DataTable oTabla = oServicioDAO.ConsultaCodigo(txtCodarticulo.Text, true, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oServicioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oTabla.Rows.Count > 1)
                        {
                            btnBusqArticulo.PerformClick();
                        }
                        else if (oTabla.Rows.Count > 0)
                        {
                            cargaArticulo(oTabla.Rows[0]["INV_COD_ARTICULO"].ToString(), oTabla.Rows[0]["ART_NOMBRE"].ToString(), oTabla.Rows[0]["INV_IVI"].ToString(), double.Parse(oTabla.Rows[0]["inv_impuesto_ventas"].ToString()));
                        }

                    }

                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtCodarticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                BuscaCodigoArticulo();
            }
        }

        private void btnProformaAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtProforma.Text.Equals("") && !txtProforma.Text.Equals("0"))
                    cargaProforma((int.Parse(txtProforma.Text) - 1).ToString(), "");
            }
            catch { }
        }

        private void btnProformaAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtProforma.Text.Equals(""))
                    cargaProforma((int.Parse(txtProforma.Text) + 1).ToString(), "");
            }
            catch { }
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHabilitarDescuento1_Click(object sender, EventArgs e)
        {
            tipoDescuento = 1;

            oProforma = new Proforma();

            oProforma.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
            oProforma.NumProforma = int.Parse(txtProforma.Text);
            oProforma.Indice = indiceProforma;
            oProforma.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
            oProforma.Cliente = idCliente;

            if (rbContado.Checked)
                oProforma.Tipo = "CONTADO";
            else
                oProforma.Tipo = "CREDITO";


            //if (PROYECTO.Properties.Settings.Default.Autorizacion.Equals("CODIGOBARRAS"))
            //{
            //    frmAutorizacionCodigoBarras oPantalla = frmAutorizacionCodigoBarras.getInstance(oProforma, "AUTORIZAR DESCUENTO", this.Name, "DESCUENTO");
            //    oPantalla.MdiParent = this.MdiParent;
            //    oPantalla.Show();
            //}
            //else
            //{
            //    MessageBox.Show("No existe metodo de autorización, por favor revisar la configuración.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }

        private void btnHabilitarDescuento2_Click(object sender, EventArgs e)
        {
            tipoDescuento = 2;

            oProforma = new Proforma();

            oProforma.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
            oProforma.NumProforma = int.Parse(txtProforma.Text);
            oProforma.Indice = indiceProforma;
            oProforma.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
            oProforma.Cliente = idCliente;

            if (rbContado.Checked)
                oProforma.Tipo = "CONTADO";
            else
                oProforma.Tipo = "CREDITO";


            //if (PROYECTO.Properties.Settings.Default.Autorizacion.Equals("CODIGOBARRAS"))
            //{
            //    frmAutorizacionCodigoBarras oPantalla = frmAutorizacionCodigoBarras.getInstance(oProforma, "AUTORIZAR DESCUENTO", this.Name, "DESCUENTO");
            //    oPantalla.MdiParent = this.MdiParent;
            //    oPantalla.Show();
            //}
            //else
            //{
            //    MessageBox.Show("No existe metodo de autorización, por favor revisar la configuración.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes cliente1 = frmClientes.getInstance();
            codigoAbrir = cliente1.Codigo;
            descripcionAbrir = cliente1.Descripcion;
            moduloAbrir = cliente1.Modulo;
            if (!TienePermiso())
            {
                cliente1.MdiParent = this.MdiParent;
                cliente1.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cliente1 = null;
            }
            this.Enabled = false;
        }

        private Boolean TienePermiso()
        {
            try
            {
                PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

                Boolean tienePermiso = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigoAbrir);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigoAbrir, moduloAbrir, descripcionAbrir, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigoAbrir, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
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
    }
}