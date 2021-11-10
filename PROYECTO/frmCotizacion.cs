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
        private CotizacionDAO oCotizacionDAO = null;
        private Cotizacion oCotizacion = null;
        private CotizacionDetalleDAO oCotizacionDetalleDAO = null;
        private CotizacionDetalle oCotizacionDetalle = null;

        private TipoCambioDAO oTipoCambioDAO = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ServicioDAO oServicioDAO = null;
        private DataSet TipoCambio = null;
        private ReportesDAO oReporteDAO = new ReportesDAO();
        private Cantidad_a_Letra objeto;

        private String codigo = "pro_cotizacion", descripcion = "Cotización de Servicios.", modulo = "Procesos";

        private String tipoDocumento = "";
        private Double IndiceDocumento = 0, indiceServicio = 0;
        private int indiceCotizacion = 0;
        private String txtUbicacion = "", txtTelefono = "", lblMontoEnLetras = "", idCliente = "";

        private double cantidad2 = 0;
        //private DateTime dtpFechaCotizacion;
        private String IVI = "N";
        private double IV = 0;

        private int indiceDetalle = 0, txtDias = 0;

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
                    DateTime fecha = oConexion.fecha();
                    dtpFechaCotizacion.Text = fecha.ToShortDateString();

                    oTipoCambioDAO = new TipoCambioDAO();
                    TipoCambio = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia);
                    if (oTipoCambioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los tipos de cambio: " + oTipoCambioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        txtTipoCambio.Text = Double.Parse(TipoCambio.Tables[0].Rows[0]["cambio_dolar"].ToString()).ToString("###,###.00");
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
                    oCotizacionDAO = new CotizacionDAO();
                    DataTable odata = oCotizacionDAO.consultaCantProformas(PROYECTO.Properties.Settings.Default.No_cia);
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
            txtCodServicio.Text = "";
            indiceServicio = 0;
            txtPrecioUnitario.Text = "¢ 0";
            txtTotalPorLinea.Text = "¢ 0";
            txtDescServicio.Text = "";
            txtDescuento.Text = "¢ 0";
            txtEstado.Text = "ABIERTA";
            txtMonto_IV.Text = "¢ 0";
            txtSubTotal.Text = "¢ 0";
            indiceDetalle = 0;
            txtPorcDecuento.Text = "0";
            txtTelefono = "";
            txtTotalCotizacion.Text = "¢ 0";
            txtUbicacion = "";
            chkDescuento.Checked = false;
            idCliente = "";
            cmbMoneda.SelectedIndex = 0;
            oConexion.cerrarConexion();
            oConexion.abrirConexion();
            DateTime fecha = oConexion.fecha();
            dtpFechaCotizacion.Text = fecha.ToShortDateString();
            oConexion.cerrarConexion();
            limpiarAbajo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable miArreglo = new DataTable();

                if (MessageBox.Show("Desea crear una nueva Cotizacion?", "Observacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    obtieneTipoCambio();

                    txtUsuario.Text = PROYECTO.Properties.Settings.Default.Usuario;

                    if (txtCotizacion.BackColor == Color.White && txtCotizacion.Text.Equals(""))
                    {
                        MessageBox.Show("Digite el numero de Cotizacion con que iniciara el sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oCotizacionDAO = new CotizacionDAO();
                        oCotizacion = new Cotizacion();

                        oCotizacion.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oCotizacion.Cliente = "-1";
                        oCotizacion.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                        oCotizacion.Estado = txtEstado.Text;
                        oCotizacion.NumCotizacion = int.Parse(txtCotizacion.Text);
                        oCotizacion.FechaCotizacion = DateTime.Parse(dtpFechaCotizacion.Text);
                        oCotizacion.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                        oCotizacion.Moneda = cmbMoneda.Text;
                        oCotizacion.Nombre = txtANombreDe.Text;
                        oCotizacion.Observacion = "";
                        oCotizacion.Saldo = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                        oCotizacion.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                        oCotizacion.Telefono = txtTelefono;
                        oCotizacion.Tipocambio = Double.Parse(txtTipoCambio.Text);
                        oCotizacion.Total = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                        oCotizacion.Ubicacion = txtUbicacion;
                        if (rbContado.Checked)
                            oCotizacion.Tipo = "CONTADO";
                        else
                            oCotizacion.Tipo = "CREDITO";
                        oCotizacion.IndiceDocumento = 0;
                        oCotizacion.TipoDocumento = "";
                        miArreglo = oCotizacionDAO.Agregar(oCotizacion);
                        if (oCotizacionDAO.Error())
                            MessageBox.Show("Ocurrio un error al guardar los datos: " + oCotizacionDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        txtCotizacion.ReadOnly = true;
                        txtCotizacion.BackColor = Color.Blue;
                        txtCotizacion.ForeColor = Color.White;
                        txtCotizacion.Text = miArreglo.Rows[0].ItemArray[0].ToString();
                        indiceCotizacion = int.Parse(miArreglo.Rows[0].ItemArray[1].ToString());
                        btnBusqCliente.PerformClick();
                        lblMontoEnLetras = "";
                    }
                    else
                        MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnBusqCliente.PerformClick();
                    limpiar();
                    llenarGrid();
                    txtCodServicio.Focus();
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnnuevoDetalle_Click(object sender, EventArgs e)
        {
            limpiarAbajo();
            txtCodServicio.Focus();
        }

        private void limpiarAbajo()
        {
            txtCodServicio.ReadOnly = false;
            cantidad2 = 0;
            btnGuardarDetalle.Text = " Guardar";
            btnGuardarDetalle.ImageIndex = 1;
            txtCantidad.Text = "0";
            txtCodServicio.Text = "";
            indiceServicio = 0;
            txtDescServicio.Text = "";
            indiceDetalle = 0;
            txtSubTotalLinea.Text = cmbMoneda.Text.Equals("CRC") ? "¢ 0" : cmbMoneda.Text.Equals("USD") ? "$ 0" : "¢ 0";
            txtPrecioUnitario.Text = cmbMoneda.Text.Equals("CRC") ? "¢ 0" : cmbMoneda.Text.Equals("USD") ? "$ 0" : "¢ 0";
            txtTotalPorLinea.Text = cmbMoneda.Text.Equals("CRC") ? "¢ 0" : cmbMoneda.Text.Equals("USD") ? "$ 0" : "¢ 0";
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
                txtCotizacion.ReadOnly = false;
                txtCotizacion.BackColor = Color.White;
                txtCotizacion.ForeColor = Color.Black;
            }
            else
                txtCotizacion.Text = "0";
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
                    oCotizacionDAO = new CotizacionDAO();
                    DataTable odata = oCotizacionDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
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

        public void cargaCotizacion(String pCotizacion, String nombre)
        {
            try
            {
                string anterior = txtCotizacion.Text;

                String vCotizacion = pCotizacion[0].ToString();
                for (int x = 1; x < pCotizacion.Length; x++)
                {
                    if (char.IsNumber(pCotizacion[x]))
                        vCotizacion += pCotizacion[x];
                    else
                        x = pCotizacion.Length;
                }

                pCotizacion = vCotizacion;

                txtCotizacion.Text = pCotizacion;

                txtANombreDe.Text = nombre;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCotizacionDAO = new CotizacionDAO();
                    DataTable odata = oCotizacionDAO.ConsultaCotizacion(txtCotizacion.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        txtCotizacion.ReadOnly = true;
                        txtCotizacion.BackColor = Color.Beige;
                        txtCotizacion.ForeColor = Color.Black;

                        indiceCotizacion = int.Parse(odata.Rows[0]["fac_linea"].ToString());
                        dtpFechaCotizacion.Text = odata.Rows[0]["fac_fecha"].ToString();
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
                        cmbMoneda.SelectedItem = odata.Rows[0]["fac_moneda"].ToString();

                        txtTipoCambio.Text = double.Parse(odata.Rows[0]["fac_tipo_cambio"].ToString()).ToString("###,###,0.00");
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


                        switch (cmbMoneda.SelectedIndex)
                        {
                            case 0:
                                txtMonto_IV.Text = "¢ " + odata.Rows[0]["fac_subtotal"].ToString();
                                txtSubTotal.Text = "¢ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                                txtDescuento.Text = "¢ " + odata.Rows[0]["fac_descuento"].ToString();
                                txtTotalCotizacion.Text = "¢ " + odata.Rows[0]["fac_total"].ToString();
                                break;
                            case 1:
                                txtMonto_IV.Text = "$ " + odata.Rows[0]["fac_subtotal"].ToString();
                                txtSubTotal.Text = "$ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                                txtDescuento.Text = "$ " + odata.Rows[0]["fac_descuento"].ToString();
                                txtTotalCotizacion.Text = "$ " + odata.Rows[0]["fac_total"].ToString();
                                break;
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
                        if (!pCotizacion.Equals(anterior))
                            cargaCotizacion(anterior, "");
                        return;
                    }
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    odata = oCotizacionDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
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
                if (txtEstado.Text.Equals("EMITIDA"))
                {
                    cargaCotizacion(txtCotizacion.Text, txtANombreDe.Text);
                    return;
                }
                if (indiceCotizacion == 0)
                {
                    cargaCotizacion(txtCotizacion.Text, txtANombreDe.Text);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    cargaCotizacion(txtCotizacion.Text, txtANombreDe.Text);
                    return;
                }

                obtieneTipoCambio();

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCotizacionDAO = new CotizacionDAO();
                    oCotizacion = new Cotizacion();

                    oCotizacion.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCotizacion.Indice = indiceCotizacion;
                    oCotizacion.Cliente = idCliente;
                    oCotizacion.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oCotizacion.PorDescuento = Double.Parse(txtPorcDecuento.Text);
                    oCotizacion.Estado = txtEstado.Text;
                    oCotizacion.NumCotizacion = int.Parse(txtCotizacion.Text);
                    oCotizacion.FechaCotizacion = DateTime.Parse(dtpFechaCotizacion.Text);
                    oCotizacion.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                    oCotizacion.Moneda = cmbMoneda.Text;
                    oCotizacion.Nombre = txtANombreDe.Text;
                    String comentario = oCotizacionDAO.ConsultaCotizacion(txtCotizacion.Text, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["fac_observacion"].ToString();
                    oCotizacion.Observacion = comentario;
                    oCotizacion.Saldo = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                    oCotizacion.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oCotizacion.Telefono = txtTelefono;
                    oCotizacion.Tipocambio = Double.Parse(txtTipoCambio.Text);
                    oCotizacion.Total = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                    oCotizacion.Ubicacion = txtUbicacion;
                    if (rbContado.Checked)
                        oCotizacion.Tipo = "CONTADO";
                    else
                        oCotizacion.Tipo = "CREDITO";

                    oCotizacionDAO.Modificar(oCotizacion);
                    if (oCotizacionDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oCotizacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (indiceCotizacion == 0)
                {
                    cargaCotizacion(txtCotizacion.Text, txtANombreDe.Text);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    cargaCotizacion(txtCotizacion.Text, txtANombreDe.Text);
                    return;
                }
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCotizacionDAO = new CotizacionDAO();
                    oCotizacion = new Cotizacion();

                    oCotizacion.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCotizacion.Indice = indiceCotizacion;
                    oCotizacion.Cliente = idCliente;
                    oCotizacion.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oCotizacion.PorDescuento = Double.Parse(txtPorcDecuento.Text);
                    oCotizacion.Estado = txtEstado.Text;
                    oCotizacion.NumCotizacion = int.Parse(txtCotizacion.Text);
                    oCotizacion.FechaCotizacion = DateTime.Parse(dtpFechaCotizacion.Text);
                    oCotizacion.Impuesto = Double.Parse(txtMonto_IV.Text.Substring(1));
                    oCotizacion.Moneda = cmbMoneda.Text;
                    oCotizacion.Nombre = txtANombreDe.Text;
                    String comentario = oCotizacionDAO.ConsultaCotizacion(txtCotizacion.Text, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["fac_observacion"].ToString();
                    oCotizacion.Observacion = comentario;
                    oCotizacion.Saldo = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                    oCotizacion.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oCotizacion.Telefono = txtTelefono;
                    oCotizacion.Tipocambio = Double.Parse(txtTipoCambio.Text);
                    oCotizacion.Total = Double.Parse(txtTotalCotizacion.Text.Substring(1));
                    oCotizacion.Ubicacion = txtUbicacion;

                    if (rbContado.Checked)
                        oCotizacion.Tipo = "CONTADO";
                    else
                        oCotizacion.Tipo = "CREDITO";

                    oCotizacionDAO.ModificaEstadoProforma(oCotizacion);
                    if (oCotizacionDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oCotizacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void cargaServicio(String pindiceServicio, String pCodigo, String pDescripcion, String pIVI, double pIV)
        {
            try
            {
                IVI = pIVI;
                IV = pIV;

                txtPrecioUnitario.ForeColor = Color.Black;
                txtPrecioUnitario.BackColor = Color.White;

                txtPrecioUnitario.ReadOnly = false;

                txtCodServicio.Text = pCodigo;
                indiceServicio = double.Parse(pindiceServicio);
                txtDescServicio.Text = pDescripcion;

                txtPrecioUnitario.Text = cmbMoneda.Equals("CRC") ? double.Parse("0").ToString("¢ ###,###,##0.00") : cmbMoneda.Equals("USD") ? double.Parse("0").ToString("$ ###,###,##0.00") : double.Parse("0").ToString("¢ ###,###,##0.00");

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
                if (indiceCotizacion == 0)
                {
                    MessageBox.Show("Seleccione la Proforma a la cual agregara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtEstado.Text.Equals("EMITIDA"))
                {
                    MessageBox.Show("No se puede Modificar la Proforma porque ya está en estado: EMITIDA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (indiceServicio == 0)
                {
                    MessageBox.Show("Seleccione el servicio para guardar en la Proformar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPrecioUnitario.Text.Equals("") || txtPrecioUnitario.Text.Substring(1).Equals(" 0"))
                {
                    MessageBox.Show("Digite el precio unitario del servicio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    oCotizacionDetalleDAO = new CotizacionDetalleDAO();
                    oCotizacionDetalle = new CotizacionDetalle();

                    oCotizacionDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                    if (btnGuardarDetalle.Text.Equals(" Guardar"))
                    {
                        oCotizacionDetalle.CodServicio = indiceServicio.ToString();

                        oCotizacionDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oCotizacionDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oCotizacionDetalle.SubTotal = oCotizacionDetalle.PrecioUnitario * oCotizacionDetalle.Cantidad;
                        oCotizacionDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oCotizacionDetalle.SubTotal * (oCotizacionDetalle.Descuento / 100);
                        oCotizacionDetalle.Monto_IV = IVI.Equals("S") ? 0 : oCotizacionDetalle.SubTotal * (IV / 100);
                        oCotizacionDetalle.PrecioTotal = oCotizacionDetalle.SubTotal - montoDescuento + oCotizacionDetalle.Monto_IV;

                        oCotizacionDetalle.Descripcion = txtDescServicio.Text;
                        oCotizacionDetalle.TipoPrecio = 1;
                        oCotizacionDetalle.IndiceProforma = indiceCotizacion;

                        oCotizacionDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;

                        oCotizacionDetalle.Descuento = double.Parse(txtLineaDescuento.Text);

                        oCotizacionDetalle.IVI = IVI;

                        oCotizacionDetalleDAO.Agregar(oCotizacionDetalle);
                        if (oCotizacionDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oCotizacionDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (btnGuardarDetalle.Text.Equals(" Modificar"))
                    {
                        String embAnterior = "";
                        DataTable oEmba = oConexion.EjecutaSentencia("SELECT DETFAC_MEDIDA FROM TBL_PROFORMA_DETALLE pd where pd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_INDICEFACTURA='" + indiceCotizacion + "' and DETFAC_CODIGO='" + indiceServicio);
                        if (oEmba.Rows.Count > 0)
                        {
                            embAnterior = oEmba.Rows[0].ItemArray[0].ToString();
                        }

                        if (indiceDetalle == 0)
                        {
                            MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        oCotizacionDetalle.CodServicio = indiceServicio.ToString();

                        oCotizacionDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oCotizacionDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oCotizacionDetalle.SubTotal = oCotizacionDetalle.PrecioUnitario * oCotizacionDetalle.Cantidad;
                        oCotizacionDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oCotizacionDetalle.SubTotal * (oCotizacionDetalle.Descuento / 100);
                        oCotizacionDetalle.Monto_IV = IVI.Equals("S") ? 0 : oCotizacionDetalle.SubTotal * (IV / 100);
                        oCotizacionDetalle.PrecioTotal = oCotizacionDetalle.SubTotal - montoDescuento + oCotizacionDetalle.Monto_IV;

                        oCotizacionDetalle.Descripcion = txtDescServicio.Text;
                        oCotizacionDetalle.IndiceProforma = indiceCotizacion;

                        oCotizacionDetalle.TipoPrecio = 1;
                        oCotizacionDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                        oCotizacionDetalle.Indice = indiceDetalle;

                        oCotizacionDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        oCotizacionDetalle.IVI = IVI;

                        oCotizacionDetalleDAO.Modificar(oCotizacionDetalle);
                        if (oCotizacionDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oCotizacionDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (indiceCotizacion == 0)
                    {
                        MessageBox.Show("Seleccione la Proforma a la cual eliminara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (indiceDetalle == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("EMITIDA"))
                    {
                        MessageBox.Show("No se puede Modificar la Proforma porque ya está en estado: EMITIDA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        oCotizacionDetalleDAO = new CotizacionDetalleDAO();
                        oCotizacionDetalle = new CotizacionDetalle();

                        oCotizacionDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oCotizacionDetalle.IndiceProforma = indiceCotizacion;
                        oCotizacionDetalle.Indice = indiceDetalle;
                        oCotizacionDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oCotizacionDetalle.CodServicio = indiceServicio.ToString();

                        oCotizacionDetalleDAO.Eliminar(oCotizacionDetalle);
                        if (oCotizacionDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oCotizacionDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    oCotizacionDetalleDAO = new CotizacionDetalleDAO();

                    dgrDatos.DataSource = oCotizacionDetalleDAO.Consulta(indiceCotizacion, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oCotizacionDetalleDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oCotizacionDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                indiceServicio = double.Parse(dgrDatos["detfac_codigo", e.RowIndex].Value.ToString());
                txtCodServicio.Text = dgrDatos["art_codigo", e.RowIndex].Value.ToString();
                txtDescServicio.Text = dgrDatos["detfac_descripcion", e.RowIndex].Value.ToString();
                IVI = dgrDatos["detfac_ivi", e.RowIndex].Value.ToString();
                IV = double.Parse(dgrDatos["art_impuestos", e.RowIndex].Value.ToString());

                switch (cmbMoneda.SelectedIndex)
                {
                    case 0:
                        cadena = "¢ ";
                        break;
                    case 1:
                        cadena = "$ ";
                        break;
                    case 2:
                        cadena = "€ ";
                        break;
                }

                txtPrecioUnitario.Text = cadena + Double.Parse(dgrDatos["DETFAC_PRECIO_UNITARIO", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.00");
                txtSubTotalLinea.Text = cadena + Double.Parse(dgrDatos["DETFAC_SUBTOTAL", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.00");
                txtLineaDescuento.Text = Double.Parse(dgrDatos["detfac_descuento", e.RowIndex].Value.ToString()).ToString("###,###,##0.00");
                txtTotalPorLinea.Text = cadena + Double.Parse(dgrDatos["DETFAC_PRECIO_TOTAL", e.RowIndex].Value.ToString()).ToString(" ###,###,##0.00");


                btnGuardarDetalle.Text = " Modificar";
                txtCantidad.ReadOnly = true;
                txtCodServicio.ReadOnly = true;
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

                if (cmbMoneda.SelectedItem.ToString().Equals("CRC"))
                {
                    txtMonto_IV.Text = "¢ ";
                    txtSubTotal.Text = "¢ ";
                    txtDescuento.Text = "¢ ";
                    txtTotalCotizacion.Text = "¢ ";
                }
                else if (cmbMoneda.SelectedItem.ToString().Equals("USD"))
                {
                    txtMonto_IV.Text = "$ ";
                    txtSubTotal.Text = "$ ";
                    txtDescuento.Text = "$ ";
                    txtTotalCotizacion.Text = "$ ";
                }

                if (totalLinea > 0)
                    txtMonto_IV.Text += totalMonto_IV.ToString("###,###,##0.00");
                else
                    txtMonto_IV.Text += "0";

                if (subtotal > 0)
                    txtSubTotal.Text += subtotal.ToString("###,###,##0.00");
                else
                    txtSubTotal.Text += "0";

                if (descuento > 0)
                    txtDescuento.Text += descuento.ToString("###,###,##0.00");
                else
                    txtDescuento.Text += "0";

                if (granTotal > 0)
                {
                    if (cmbMoneda.Equals("CRC"))
                    {
                        RedondearNumero oRedondear = new RedondearNumero();
                        granTotal = oRedondear.Redondear(granTotal);
                    }
                    txtTotalCotizacion.Text += granTotal.ToString("###,###,##0.00");
                }
                else
                    txtTotalCotizacion.Text += "0";
            }
            catch (Exception ex)
            {

            }
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (txtEstado.Text.Equals("EMITIDA"))
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
            if (txtTotalCotizacion.Text.Length > 2)
            {
                if (Double.Parse(txtTotalCotizacion.Text.Substring(1)) > 0)
                {
                    if (cmbMoneda.Equals("CRC")) cadena = "colones";
                    else if (cmbMoneda.Equals("USD")) cadena = "dolares";

                    objeto = new Cantidad_a_Letra();
                    String montoenletras = objeto.ConvertirCadena(Double.Parse(txtTotalCotizacion.Text.Substring(1)), cadena);
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
            if (txtCotizacion.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el documento a Emitir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgrDatos.Rows.Count == 0)
            {
                MessageBox.Show("No se puede Emitir si no hay detalle en la Proforma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCliente.Text.Trim().Equals("") || idCliente.Equals(""))
            {
                MessageBox.Show("Seleccione el cliente de la Cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEstado.Text.Equals("EMITIDA"))
            {
                MessageBox.Show("Este documento ya fue Emitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEstado.Text.Equals("ANULADA"))
            {
                MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbCredito.Checked)
                if (MessageBox.Show("¿Está seguro que desea Emitir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            modificar();

            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {

                txtEstado.Text = "EMITIDA";
                modificarEstado();

            }
            else
                MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (cmbMoneda.Equals("CRC"))
                    cadena = "¢";
                else if (cmbMoneda.Equals("USD"))
                    cadena = "$";

                txtTotalPorLinea.Text = cadena + " " + total.ToString("###,###,##0.00");
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
                btnGuardarDetalle.Text = " Guardar";
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
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, '' codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, '' idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, ART_CODIGO codigoArticulo from TBL_PROFORMA F, TBL_PROFORMA_DETALLE df, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and ART_INDICE=DETFAC_CODIGO and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtCotizacion.Text + "' ORDER BY DETFAC_NUMEROLINEA";
                    }
                    else
                    {
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, cl.cli_id codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, cl.cli_identificacion idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, ART_CODIGO codigoArticulo from TBL_PROFORMA F, TBL_PROFORMA_DETALLE df, TBL_CLIENTES cl, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = cl.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and ART_INDICE=DETFAC_CODIGO and f.fac_cliente = cl.cli_linea and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtCotizacion.Text + "' ORDER BY DETFAC_NUMEROLINEA";
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
                    DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT SUM(RECFAC_MONTO) AS RECFAC_MONTO FROM TBL_RECIBOS_Proforma where RECFAC_Proforma= '" + txtCotizacion.Text + "'");
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
                    oDataTable.Columns.Add("codigoServicio", typeof(string));
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
                        oDataRow["codigoServicio"] = oFila["codigoServicio"].ToString();
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

                    txtDescServicio.Clear();
                    llenarGrid();

                    IndiceDocumento = 0;

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    dtpFechaCotizacion.Text = oConexion.fecha().ToShortDateString();
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
                btnBCotizacion.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnEmitir.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqCliente.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimir.Enabled = false;
            }
            else if (txtEstado.Text.Equals("ABIERTA"))
            {
                btnBCotizacion.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = true;
                btnEmitir.Enabled = true;
                btnNuevoDetalle.Enabled = true;
                btnBusqCliente.Enabled = true;
                btnBusqServicio.Enabled = true;
                btnGuardarDetalle.Enabled = true;
                btnEliminarDetalle.Enabled = true;
                btnImprimir.Enabled = false;
            }
            else if (txtEstado.Text.Equals("EMITIDA"))
            {
                btnBCotizacion.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnEmitir.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqCliente.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimir.Enabled = true;
            }
            else if (txtEstado.Text.Equals("ANULADA"))
            {
                btnBCotizacion.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnEmitir.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqCliente.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
                btnImprimir.Enabled = false;
            }
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

                if (cmbMoneda.Equals("CRC"))
                {
                    RedondearNumero oRedondear = new RedondearNumero();
                    total = oRedondear.Redondear(total);
                }

                switch (cmbMoneda.Text.Trim())
                {
                    case "CRC":
                        txtSubTotalLinea.Text = subtotal.ToString("¢ ###,###,##0.00");
                        txtTotalPorLinea.Text = total.ToString("¢ ###,###,##0.00");
                        break;
                    case "USD":
                        txtSubTotalLinea.Text = subtotal.ToString("$ ###,###,##0.00");
                        txtTotalPorLinea.Text = total.ToString("$ ###,###,##0.00");
                        break;
                    default:
                        txtSubTotalLinea.Text = subtotal.ToString("¢ ###,###,##0.00");
                        txtTotalPorLinea.Text = total.ToString("¢ ###,###,##0.00");
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
            txtLineaDescuento.Text = Double.Parse(txtLineaDescuento.Text).ToString("###,###,##0.00");

            calcularTotalPorLinea();
        }

        private void btnBusqServicio_Click(object sender, EventArgs e)
        {
            frmConsultaServicios oConsulta = new frmConsultaServicios("frmCotizacion");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        private void frmCotizacioncion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance();
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
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

        private void txtDescServicio_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void txtCodServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                BuscaCodigoServicio();
            }
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text.Equals(""))
                txtPrecioUnitario.Text = "0";
            txtPrecioUnitario.Text = double.Parse(txtPrecioUnitario.Text).ToString("¢ ###,###,##0.00");
            calcularTotalPorLinea();
        }

        private void BuscaCodigoServicio()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    ServicioDAO oServicioDAO = new ServicioDAO();
                    DataTable oTabla = oServicioDAO.ConsultaCodigo(txtCodServicio.Text, true, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oServicioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oTabla.Rows.Count == 0 || oTabla.Rows.Count > 1)
                        {
                            btnBusqServicio.PerformClick();
                        }
                        else if (oTabla.Rows.Count > 0)
                        {
                            cargaServicio(oTabla.Rows[0]["INV_COD_ARTICULO"].ToString(), oTabla.Rows[0]["ART_CODIGO"].ToString(), oTabla.Rows[0]["ART_NOMBRE"].ToString(), oTabla.Rows[0]["INV_IVI"].ToString(), double.Parse(oTabla.Rows[0]["inv_impuesto_ventas"].ToString()));
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

        private void btnProformaAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCotizacion.Text.Equals("") && !txtCotizacion.Text.Equals("0"))
                    cargaCotizacion((int.Parse(txtCotizacion.Text) - 1).ToString(), "");
            }
            catch { }
        }

        private void btnProformaAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCotizacion.Text.Equals(""))
                    cargaCotizacion((int.Parse(txtCotizacion.Text) + 1).ToString(), "");
            }
            catch { }
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {

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
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigoAbrir, PROYECTO.Properties.Settings.Default.No_cia);
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

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String cadena = "";
                switch (cmbMoneda.SelectedIndex)
                {
                    case 0:
                        // txtTipoCambio.Text = "¢ " + TipoCambio.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtSubTotal.Text = "¢ " + Double.Parse(txtSubTotal.Text.Substring(1));
                        txtDescuento.Text = "¢ " + Double.Parse(txtDescuento.Text.Substring(1));
                        txtMonto_IV.Text = "¢ " + Double.Parse(txtMonto_IV.Text.Substring(1));
                        txtTotalCotizacion.Text = "¢ " + Double.Parse(txtTotalCotizacion.Text.Substring(1));
                        cadena = "¢ ";
                        break;
                    case 1:
                        //txtTipoCambio.Text = "¢ " + TipoCambio.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtSubTotal.Text = "$ " + Double.Parse(txtSubTotal.Text.Substring(1));
                        txtDescuento.Text = "$ " + Double.Parse(txtDescuento.Text.Substring(1));
                        txtMonto_IV.Text = "$ " + Double.Parse(txtMonto_IV.Text.Substring(1));
                        txtTotalCotizacion.Text = "$ " + Double.Parse(txtTotalCotizacion.Text.Substring(1));
                        cadena = "$ ";
                        break;
                }
                if (txtTotalPorLinea.Text.Length == 2)
                    txtTotalPorLinea.Text = cadena;
                else
                    if (!txtTotalPorLinea.Text.Equals("") && !txtTotalPorLinea.Text.Equals("0"))
                    txtTotalPorLinea.Text = cadena + txtTotalPorLinea.Text.Substring(2);
            }
            catch { }
        }
    }
}