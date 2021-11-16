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
using System.Net.Mail;
using System.Net;

namespace PROYECTO
{
    public partial class frmFacturacionRapida : Form
    {
        private static frmFacturacionRapida frmfactura = null;
        private FacturaDAO oFacturaDAO = null;
        private Factura oFactura = null;
        private FacturaDetalleDAO oFacturaDetalleDAO = null;
        private FacturaDetalle oFacturaDetalle = null;
        private FacturasPendientes ofacturaPendiente = null;
        private FacturasPendientesDAO ofacturaPendienteDAO = null;
        private TipoCambioDAO oTipoCambioDAO = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ServicioDAO oAticuloDAO = null;
        private DataSet TipoCambio = null;

        private ReportesDAO oReporteDAO = new ReportesDAO();
        private Cantidad_a_Letra objeto;

        private String codigo = "pro_facturacion", descripcion = "Facturacion de servicios.", modulo = "Procesos";

        private String tipoDocumento = "";
        private Double IndiceDocumento = 0, indiceServicio = 0, txtCredDisponible = 0;
        private int indiceFactura = 0;
        private String tipoCliente = "", txtUbicacion = "", txtTelefono = "", cmbMoneda = "CRC", lblMontoEnLetras = "", idCliente = "";
        private double LimiteSaldo = 0, SaldoUsado = 0, SaldoLibre = 0, txtTipoCambio = 0, txtAdelantos = 0, cantidad2 = 0;
        private DateTime dtpFechaFactura;

        private int indiceDetalle = 0, cliente = 0, txtDias = 0, tipoDescuento = 0;

        private String IVI = "N";
        private double IV = 0;

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

        public frmFacturacionRapida()
        {
            InitializeComponent();
        }

        public static frmFacturacionRapida getInstance()
        {
            if (frmfactura == null)
                frmfactura = new frmFacturacionRapida();
            return frmfactura;
        }

        private void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmfactura = null;
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
            frmfactura = null;
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
                    oFacturaDAO = new FacturaDAO();
                    DataTable odata = oFacturaDAO.consultaCantFacturas(PROYECTO.Properties.Settings.Default.No_cia);
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
            txtPrecioUnitario.Text = "¢ 0.00";
            txtTotalPorLinea.Text = "¢ 0.00";
            txtDescServicio.Text = "";
            txtDescuento.Text = "¢ 0.00";

            txtEstado.Text = "ABIERTA";
            txtMontoIV.Text = "¢ 0.00";
            txtSubTotal.Text = "¢ 0.00";
            indiceDetalle = 0;
            txtPorcDecuento.Text = "0.00";
            txtTelefono = "";
            txtTotalFactura.Text = "¢ 0.00";
            txtUbicacion = "";
            chkDescuento.Checked = false;
            cmbMoneda = "CRC";
            oConexion.cerrarConexion();
            oConexion.abrirConexion();
            DateTime fecha = oConexion.fecha();
            dtpFechaFactura = fecha;
            chkDescuento.Enabled = false;
            idCliente = "";
            IVI = "N";
            IV = 0;
            oConexion.cerrarConexion();
            limpiarAbajo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean vFacturasAbiertas = false;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oMensajes = oConexion.EjecutaSentencia("select ind_facturasabiertas from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    if (oMensajes.Rows.Count > 0)
                        vFacturasAbiertas = oMensajes.Rows[0]["ind_facturasabiertas"].ToString().Equals("S") ? true : false;

                    oConexion.cerrarConexion();
                }

                DataTable miArreglo = new DataTable();

                if (!vFacturasAbiertas)
                {
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {

                        DataTable ot = oConexion.EjecutaSentencia("select FAC_NUMERO, FAC_NOMBRE from TBL_FACTURA F where f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and FAC_ESTADO = 'ABIERTA' and FAC_USUARIOMODIFICA ='" + PROYECTO.Properties.Settings.Default.Usuario + "' order by FAC_NUMERO");

                        if (ot.Rows.Count > 0)
                        {
                            cargaFactura(ot.Rows[0]["fac_numero"].ToString(), ot.Rows[0]["FAC_NOMBRE"].ToString());
                            txtCodServicio.Focus();
                            return;
                        }
                    }
                }

                // if (MessageBox.Show("Desea crear una nueva factura?", "Observacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtFactura.BackColor == Color.White && txtFactura.Text.Equals(""))
                    {
                        MessageBox.Show("Digite el numero de factura con que iniciara el sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oFacturaDAO = new FacturaDAO();
                        oFactura = new Factura();

                        oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFactura.Cliente = "-1";
                        oFactura.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                        oFactura.Estado = txtEstado.Text;
                        oFactura.NumFactura = int.Parse(txtFactura.Text);
                        oFactura.FechaFactura = dtpFechaFactura;
                        oFactura.Impuesto = Double.Parse(txtMontoIV.Text.Substring(1));
                        oFactura.Moneda = cmbMoneda;
                        oFactura.Nombre = txtANombreDe.Text;
                        oFactura.Observacion = "";
                        oFactura.Saldo = rbCredito.Checked ? Double.Parse(txtTotalFactura.Text.Substring(1)) : 0;
                        oFactura.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                        oFactura.Telefono = txtTelefono;
                        oFactura.Tipocambio = txtTipoCambio;
                        oFactura.Total = Double.Parse(txtTotalFactura.Text.Substring(1));
                        oFactura.Adelanto = Double.Parse(txtTotalFactura.Text.Substring(1));
                        oFactura.Ubicacion = txtUbicacion;
                        oFactura.FormaPago = "";
                        if (rbContado.Checked)
                            oFactura.Tipo = "CONTADO";
                        else
                            oFactura.Tipo = "CREDITO";
                        oFactura.IndiceDocumento = 0;
                        oFactura.TipoDocumento = "";
                        miArreglo = oFacturaDAO.Agregar(oFactura);
                        if (oFacturaDAO.Error())
                            MessageBox.Show("Ocurrio un error al guardar los datos: " + oFacturaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        txtFactura.ReadOnly = true;
                        txtFactura.BackColor = Color.Blue;
                        txtFactura.ForeColor = Color.White;
                        txtFactura.Text = miArreglo.Rows[0].ItemArray[0].ToString();
                        indiceFactura = int.Parse(miArreglo.Rows[0].ItemArray[1].ToString());
                        //btnBusqCliente.PerformClick();
                        cargaCliente("-1", "CONTADO");
                        lblMontoEnLetras = "";
                    }
                    else
                        MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //btnBusqCliente.PerformClick();                
                limpiar();
                cargaCliente("-1", "CONTADO");
                llenarGrid();
                txtCodServicio.Focus();
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
            btnGuardarDetalle.Text = " F3 - Guardar";
            btnGuardarDetalle.ImageIndex = 1;
            txtCantidad.Text = "0";
            txtCodServicio.Text = "";
            indiceServicio = 0;
            txtDescServicio.Text = "";
            indiceDetalle = 0;
            txtSubTotalLinea.Text = cmbMoneda.Equals("CRC") ? "¢ 0.00" : cmbMoneda.Equals("USD") ? "$ 0.00" : "¢ 0.00";
            txtPrecioUnitario.Text = cmbMoneda.Equals("CRC") ? "¢ 0.00" : cmbMoneda.Equals("USD") ? "$ 0.00" : "¢ 0.00";
            txtTotalPorLinea.Text = cmbMoneda.Equals("CRC") ? "¢ 0.00" : cmbMoneda.Equals("USD") ? "$ 0.00" : "¢ 0.00";
            txtLineaDescuento.Text = "0";

            dgrDatos.ClearSelection();
            txtCantidad.ReadOnly = false;
            txtLineaDescuento.ReadOnly = true;
        }

        public void HabilitarDescuento()
        {
            switch (tipoDescuento)
            {
                case 1:
                    txtLineaDescuento.ReadOnly = false;
                    txtLineaDescuento.Focus();
                    break;
                case 2:
                    txtPorcDecuento.ReadOnly = false;
                    chkDescuento.Enabled = true;
                    chkDescuento.Checked = true;
                    txtPorcDecuento.Focus();
                    break;
            }

        }

        public void HabilitarPrecio()
        {
            txtPrecioUnitario.ReadOnly = false;
            txtPrecioUnitario.Focus();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            btnGuardar.Visible = true;
            obtieneTipoCambio();

            limpiar();
            if (!cantidadRegistros())
            {
                txtFactura.ReadOnly = false;
                txtFactura.BackColor = Color.White;
                txtFactura.ForeColor = Color.Black;
            }
            else
                txtFactura.Text = "0";
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
                    oFacturaDAO = new FacturaDAO();
                    DataTable odata = oFacturaDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
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

                    CalculaSaldos();

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

        public void cargaFactura(String factura, String nombre)
        {
            try
            {
                string anterior = txtFactura.Text;

                String pfactura = factura[0].ToString();
                for (int x = 1; x < factura.Length; x++)
                {
                    if (char.IsNumber(factura[x]))
                        pfactura += factura[x];
                    else
                        x = factura.Length;
                }

                factura = pfactura;

                txtFactura.Text = factura;

                txtANombreDe.Text = nombre;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturaDAO = new FacturaDAO();
                    DataTable odata = oFacturaDAO.ConsultaFactura(txtFactura.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odata.Rows.Count > 0)
                    {
                        indiceFactura = int.Parse(odata.Rows[0]["fac_linea"].ToString());
                        dtpFechaFactura = DateTime.Parse(odata.Rows[0]["fac_fecha"].ToString());
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
                            porcentaje = "0.00";
                        else if (porcentaje.Equals("0.00"))
                            chkDescuento.Checked = false;
                        else
                            chkDescuento.Checked = true;
                        txtPorcDecuento.Text = porcentaje;

                        if (cmbMoneda.Equals("CRC"))
                        {
                            txtMontoIV.Text = "¢ " + odata.Rows[0]["fac_subtotal"].ToString();
                            txtSubTotal.Text = "¢ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                            txtDescuento.Text = "¢ " + odata.Rows[0]["fac_descuento"].ToString();
                            txtTotalFactura.Text = "¢ " + odata.Rows[0]["fac_total"].ToString();
                            txtAdelantos = double.Parse(odata.Rows[0]["fac_adelanto"].ToString());
                        }
                        else if (cmbMoneda.Equals("USD"))
                        {
                            txtMontoIV.Text = "$ " + odata.Rows[0]["fac_subtotal"].ToString();
                            txtSubTotal.Text = "$ " + (Double.Parse(odata.Rows[0]["fac_excento"].ToString()) + Double.Parse(odata.Rows[0]["fac_subtotal"].ToString()));
                            txtDescuento.Text = "$ " + odata.Rows[0]["fac_descuento"].ToString();
                            txtTotalFactura.Text = "$ " + odata.Rows[0]["fac_total"].ToString();
                            txtAdelantos = double.Parse(odata.Rows[0]["fac_adelanto"].ToString());
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
                        if (!factura.Equals(anterior))
                            cargaFactura(anterior, "");
                        return;
                    }
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    odata = oFacturaDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia);
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
                    CalculaSaldos();
                    chkDescuento.Enabled = false;
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

        private void btnBusqFactura_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("FACTURACIONRAPIDA");
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
                    cargaFactura(txtFactura.Text, txtANombreDe.Text);
                    return;
                }
                if (indiceFactura == 0)
                {
                    cargaFactura(txtFactura.Text, txtANombreDe.Text);
                    return;
                }
                if (txtEstado.Text.Equals("ANULADA"))
                {
                    cargaFactura(txtFactura.Text, txtANombreDe.Text);
                    return;
                }
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    chkDescuento.Enabled = false;
                    txtPorcDecuento.ReadOnly = true;

                    Double adelantos = 0;
                    DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT nvl(sum(RECFAC_MONTO),0) RECFAC_MONTO FROM TBL_RECIBOS_FACTURA rf where rf.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and RECFAC_FACTURA= '" + txtFactura.Text + "'");
                    if (oTabla2.Rows.Count > 0)
                    {
                        try
                        {
                            adelantos = double.Parse(oTabla2.Rows[0]["RECFAC_MONTO"].ToString());
                        }
                        catch { }
                    }
                    oFacturaDAO = new FacturaDAO();
                    oFactura = new Factura();

                    oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oFactura.Indice = indiceFactura;
                    oFactura.Cliente = idCliente;
                    oFactura.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oFactura.PorDescuento = Double.Parse(txtPorcDecuento.Text);
                    oFactura.Estado = txtEstado.Text;
                    oFactura.NumFactura = int.Parse(txtFactura.Text);
                    oFactura.DiasCredito = txtDias;
                    oFactura.FechaFactura = dtpFechaFactura;
                    oFactura.Moneda = cmbMoneda;
                    oFactura.Nombre = txtANombreDe.Text;
                    String comentario = "";
                    DataTable ot = oFacturaDAO.ConsultaFactura(txtFactura.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (ot.Rows.Count > 0)
                        comentario = ot.Rows[0]["fac_observacion"].ToString();

                    oFactura.Observacion = comentario;
                    oFactura.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oFactura.Saldo = rbCredito.Checked ? Double.Parse(txtTotalFactura.Text.Substring(1)) : 0;
                    oFactura.Impuesto = Double.Parse(txtMontoIV.Text.Substring(1));
                    oFactura.Telefono = txtTelefono;
                    oFactura.Tipocambio = txtTipoCambio;
                    oFactura.Total = Double.Parse(txtTotalFactura.Text.Substring(1));
                    oFactura.Adelanto = adelantos;
                    oFactura.Ubicacion = txtUbicacion;
                    oFactura.DiasCredito = txtDias;
                    oFactura.FormaPago = "";
                    if (rbContado.Checked)
                        oFactura.Tipo = "CONTADO";
                    else
                        oFactura.Tipo = "CREDITO";

                    oFacturaDAO.Modificar(oFactura);
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();

                    txtAdelantos = adelantos;
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
            limpiarAbajo();

            frmConsultaServicios oConsulta = new frmConsultaServicios("frmFacturacionRapida");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        public void cargaServicio(String pIndiceServicio, String pDescripcion, String pIVI, double pIV)
        {
            try
            {
                txtPrecioUnitario.ForeColor = Color.Black;
                txtPrecioUnitario.BackColor = Color.White;

                txtPrecioUnitario.ReadOnly = false;
                txtCodServicio.Text = pIndiceServicio;
                indiceServicio = double.Parse(pIndiceServicio);
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

        private void SeleccionarUltimaLinea(int fila)
        {
            try
            {
                indiceServicio = double.Parse(dgrDatos["detfac_codigo", fila].Value.ToString());

                if (indiceServicio < 0)
                {
                    limpiarAbajo();
                    indiceServicio = 0;
                    dgrDatos.Rows[fila].Selected = false;
                    return;
                }

                dgrDatos.Rows[fila].Selected = true;
                String cadena = "";

                indiceDetalle = int.Parse(dgrDatos["detfac_numerolinea", fila].Value.ToString());

                txtCantidad.Text = dgrDatos["detfac_cantidad", fila].Value.ToString();
                cantidad2 = Double.Parse(dgrDatos["detfac_cantidad", fila].Value.ToString());

                txtCodServicio.Text = dgrDatos["SER_codigo", fila].Value.ToString();
                txtDescServicio.Text = dgrDatos["detfac_descripcion", fila].Value.ToString();

                IVI = dgrDatos["detfac_ivi", fila].Value.ToString();
                IV = double.Parse(dgrDatos["SER_impuestos", fila].Value.ToString());

                if (cmbMoneda.Equals("CRC")) cadena = "¢";
                else if (cmbMoneda.Equals("USD")) cadena = "$";

                txtPrecioUnitario.Text = cadena + Double.Parse(dgrDatos["DETFAC_PRECIO_UNITARIO", fila].Value.ToString()).ToString(" ###,###,##0.00");

                txtSubTotalLinea.Text = cadena + Double.Parse(dgrDatos["DETFAC_SUBTOTAL", fila].Value.ToString()).ToString(" ###,###,##0.00");
                txtLineaDescuento.Text = Double.Parse(dgrDatos["detfac_descuento", fila].Value.ToString()).ToString("###,###,##0.00");
                txtTotalPorLinea.Text = cadena + Double.Parse(dgrDatos["detfac_total", fila].Value.ToString()).ToString(" ###,###,##0.00");

                btnGuardarDetalle.Text = " F3 - Modificar";
                txtCantidad.ReadOnly = true;
                txtCodServicio.ReadOnly = true;
                btnGuardarDetalle.ImageIndex = 4;

                txtCantidad.ReadOnly = false;
                txtCantidad.Focus();

                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {

            }
        }

        private void GuardarDetalle()
        {
            try
            {
                if (indiceFactura == 0)
                {
                    MessageBox.Show("Seleccione la factura a la cual agregara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtEstado.Text.Equals("FACTURADA"))
                {
                    MessageBox.Show("No se puede Modificar la factura porque ya está en estado: FACTURADA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (indiceServicio == 0 && dgrDatos.Rows.Count > 0)
                {
                    dgrDatos.Rows[0].Selected = true;
                    SeleccionarUltimaLinea(0);

                    return;
                }

                if (indiceServicio == 0)
                {
                    MessageBox.Show("Seleccione el artículo a facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPrecioUnitario.Text.Equals("") || txtPrecioUnitario.Text.Substring(1).Equals(" 0.00"))
                {
                    MessageBox.Show("Digite el costo unitario del artículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCantidad.Text.Equals("") || txtCantidad.Text.Equals("0"))
                {
                    MessageBox.Show("Digite la cantidad del artículo a facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCliente.Text.Equals("") || idCliente.Equals(""))
                {
                    MessageBox.Show("Seleccione el cliente de la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    oFacturaDetalleDAO = new FacturaDetalleDAO();
                    oFacturaDetalle = new FacturaDetalle();

                    oFacturaDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    if (btnGuardarDetalle.Text.Equals(" F3 - Guardar"))
                    {
                        oFacturaDetalle.CodServicio = indiceServicio.ToString();

                        oFacturaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oFacturaDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oFacturaDetalle.Subtotal = oFacturaDetalle.PrecioUnitario * oFacturaDetalle.Cantidad;
                        oFacturaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oFacturaDetalle.Subtotal * (oFacturaDetalle.Descuento / 100);
                        oFacturaDetalle.MontoIV = oFacturaDetalle.Subtotal * (IV / 100);// IVI.Equals("S") ? 0 : oFacturaDetalle.Subtotal * (IV / 100);
                        oFacturaDetalle.PrecioTotal = oFacturaDetalle.Subtotal - montoDescuento + (IVI.Equals("S") ? 0 : oFacturaDetalle.MontoIV);

                        oFacturaDetalle.Descripcion = txtDescServicio.Text;
                        oFacturaDetalle.Medida = "UND";
                        oFacturaDetalle.IndiceFactura = indiceFactura;
                        oFacturaDetalle.IVI = IVI;

                        oFacturaDetalleDAO.Agregar(oFacturaDetalle);
                        if (oFacturaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (btnGuardarDetalle.Text.Equals(" F3 - Modificar"))
                    {
                        String embAnterior = "";
                        DataTable oEmba = oConexion.EjecutaSentencia("SELECT DETFAC_MEDIDA FROM TBL_FACTURA_DETALLE fd where fd.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  DETFAC_INDICEFACTURA='" + indiceFactura + "' and DETFAC_CODIGO='" + indiceServicio + "'");
                        if (oEmba.Rows.Count > 0)
                        {
                            embAnterior = oEmba.Rows[0].ItemArray[0].ToString();
                        }

                        if (indiceDetalle == 0)
                        {
                            MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        oFacturaDetalle.CodServicio = indiceServicio.ToString();

                        oFacturaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oFacturaDetalle.PrecioUnitario = Double.Parse(txtPrecioUnitario.Text.Substring(1));
                        oFacturaDetalle.Subtotal = oFacturaDetalle.PrecioUnitario * oFacturaDetalle.Cantidad;
                        oFacturaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        double montoDescuento = oFacturaDetalle.Subtotal * (oFacturaDetalle.Descuento / 100);
                        oFacturaDetalle.MontoIV = oFacturaDetalle.Subtotal * (IV / 100);// IVI.Equals("S") ? 0 : oFacturaDetalle.Subtotal * (IV / 100);
                        oFacturaDetalle.PrecioTotal = oFacturaDetalle.Subtotal - montoDescuento + (IVI.Equals("S") ? 0 : oFacturaDetalle.MontoIV);

                        oFacturaDetalle.Descripcion = txtDescServicio.Text;
                        oFacturaDetalle.Medida = "UND";
                        oFacturaDetalle.IndiceFactura = indiceFactura;
                        oFacturaDetalle.Indice = indiceDetalle;
                        oFacturaDetalle.Descuento = double.Parse(txtLineaDescuento.Text);
                        oFacturaDetalle.IVI = IVI;

                        oFacturaDetalleDAO.Modificar(oFacturaDetalle);
                        if (oFacturaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (indiceFactura == 0)
                    {
                        MessageBox.Show("Seleccione la factura a la cual eliminara el detalle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (indiceDetalle == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("FACTURADA"))
                    {
                        MessageBox.Show("No se puede Modificar la factura porque ya es ta en estado: FACTURADA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        oFacturaDetalleDAO = new FacturaDetalleDAO();
                        oFacturaDetalle = new FacturaDetalle();

                        oFacturaDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFacturaDetalle.IndiceFactura = indiceFactura;
                        oFacturaDetalle.Indice = indiceDetalle;
                        oFacturaDetalle.Cantidad = Double.Parse(txtCantidad.Text);
                        oFacturaDetalle.CodServicio = indiceServicio.ToString();

                        oFacturaDetalleDAO.Eliminar(oFacturaDetalle);
                        if (oFacturaDetalleDAO.Error())
                            MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    oFacturaDetalleDAO = new FacturaDetalleDAO();

                    dgrDatos.DataSource = oFacturaDetalleDAO.Consulta(indiceFactura, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oFacturaDetalleDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SeleccionarUltimaLinea(e.RowIndex);
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
                String IVI = "N";
                Double totalMonto_IV = 0, granTotal = 0, totalLinea = 0, descuento = 0, subtotal = 0, porcDescuento = 0, cantidad = 0;

                foreach (DataGridViewRow ofila in dgrDatos.Rows)
                {
                    IVI = ofila.Cells["detfac_ivi"].Value.ToString();
                    cantidad = Double.Parse(ofila.Cells["detfac_cantidad"].Value.ToString());
                    totalLinea += Double.Parse(ofila.Cells["detfac_total"].Value.ToString());
                    totalMonto_IV += IVI.Equals("S") ? 0 : Double.Parse(ofila.Cells["DETFAC_MONTO_IV"].Value.ToString());
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

                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                double adelantos = 0;
                DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT nvl(sum(RECFAC_MONTO), 0) FROM TBL_RECIBOS_FACTURA rf where rf.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  RECFAC_FACTURA= '" + txtFactura.Text + "'");

                if (oTabla2.Rows.Count > 0)
                {
                    try
                    {
                        adelantos = double.Parse(oTabla2.Rows[0].ItemArray[0].ToString());
                    }
                    catch { }
                }

                granTotal = granTotal - adelantos;

                if (cmbMoneda.Equals("CRC"))
                {
                    txtMontoIV.Text = "¢ ";
                    txtSubTotal.Text = "¢ ";
                    txtDescuento.Text = "¢ ";
                    txtTotalFactura.Text = "¢ ";
                }
                else if (cmbMoneda.Equals("USD"))
                {
                    txtMontoIV.Text = "$ ";
                    txtSubTotal.Text = "$ ";
                    txtDescuento.Text = "$ ";
                    txtTotalFactura.Text = "$ ";
                }

                if (totalMonto_IV > 0)
                    txtMontoIV.Text += totalMonto_IV.ToString("###,###,##0.00");
                else
                    txtMontoIV.Text += "0.00";

                if (subtotal > 0)
                    txtSubTotal.Text += subtotal.ToString("###,###,##0.00");
                else
                    txtSubTotal.Text += "0.00";

                if (descuento > 0)
                    txtDescuento.Text += descuento.ToString("###,###,##0.00");
                else
                    txtDescuento.Text += "0.00";

                if (granTotal > 0)
                {
                    if (cmbMoneda.Equals("CRC"))
                    {
                        RedondearNumero oRedondear = new RedondearNumero();
                        granTotal = oRedondear.Redondear(granTotal);
                    }
                    txtTotalFactura.Text += granTotal.ToString("###,###,##0.00");
                }
                else
                    txtTotalFactura.Text += "0.00";
                if (adelantos > 0)
                    txtAdelantos += adelantos;
                else
                    txtAdelantos += 0;
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
            txtPorcDecuento.Text = "0.00";

        }

        private void txtTotalFactura_TextChanged(object sender, EventArgs e)
        {
            String cadena = "";
            if (txtTotalFactura.Text.Length > 2)
            {
                if (Double.Parse(txtTotalFactura.Text.Substring(1)) > 0)
                {
                    if (cmbMoneda.Equals("CRC")) cadena = "colones";
                    else if (cmbMoneda.Equals("USD")) cadena = "dolares";

                    objeto = new Cantidad_a_Letra();
                    String montoenletras = objeto.ConvertirCadena(Double.Parse(txtTotalFactura.Text.Substring(1)), cadena);
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

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (txtFactura.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el documento a facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgrDatos.Rows.Count == 0)
            {
                MessageBox.Show("No se puede facturar si no hay detalle en la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCliente.Text.Trim().Equals("") || idCliente.Equals(""))
            {
                MessageBox.Show("Seleccione el cliente de la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEstado.Text.Equals("FACTURADA"))
            {
                MessageBox.Show("Este documento ya fue facturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEstado.Text.Equals("ANULADA"))
            {
                MessageBox.Show("Este documento fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbCredito.Checked)
                if (MessageBox.Show("¿Está seguro que desea facturar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;


            modificar();
            if (rbCredito.Checked)
            {
                int tipo = 0;
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oPendientes = oConexion.EjecutaSentencia("select FACP_NUMERO_FACTURA from TBL_FACTURAS_PENDIENTES_CTA FPC where fpc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and FACP_ESTATUS='PE' and FACP_FECHA_VENCE < sysdate and FACP_CLIENTE=" + idCliente + " and FACP_estado=1");
                    if (oPendientes.Rows.Count > 0)
                        tipo = 1;
                }

                if (double.Parse(txtTotalFactura.Text.Substring(1)) > SaldoLibre)
                {
                    if (tipo == 0)
                        tipo = 2;
                    else
                        tipo = 3;
                }

                switch (tipo)
                {
                    case 0: break;
                    case 1:
                        if (MessageBox.Show("El cliente tiene facturas pendientes y vencidas.\nTiene autorización de continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmFacturarAutorizacion oPantalla = frmFacturarAutorizacion.getInstance(oFactura, (DataTable)dgrDatos.DataSource, "EL CLIENTE TIENE FACTURAS PENDIENTES Y VENCIDAS", this.Name);
                            oPantalla.MdiParent = this.MdiParent;
                            oPantalla.Show();

                            this.Enabled = false;
                        }
                        return;
                    case 2:
                        if (MessageBox.Show("El Credito disponible es menor al monto de la factura.\nTiene autorización de continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmFacturarAutorizacion oPantalla = frmFacturarAutorizacion.getInstance(oFactura, (DataTable)dgrDatos.DataSource, "EL CREDITO DISPONIBLE ES MENOR AL MONTO DE LA FACTURA", this.Name);
                            oPantalla.MdiParent = this.MdiParent;
                            oPantalla.Show();

                            this.Enabled = false;
                        }
                        return;
                    case 3:
                        if (MessageBox.Show("El cliente tiene facturas pendientes y vencidas,\nademas el credito disponible es menor al monto de la factura.\nTiene autorización de continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmFacturarAutorizacion oPantalla = frmFacturarAutorizacion.getInstance(oFactura, (DataTable)dgrDatos.DataSource, "EL CLIENTE TIENE FACTURAS PENDIENTES Y VENCIDAS, ADEMAS EL CREDITO DISPONIBLE ES MENOR AL MONTO DE LA FACTURA", this.Name);
                            oPantalla.MdiParent = this.MdiParent;
                            oPantalla.Show();

                            this.Enabled = false;
                        }
                        return;
                }
            }

            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                DataTable oTabla = oConexion.EjecutaSentencia("Select CLI_TIPOCliente from TBL_CLIENTES c WHERE c.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and cli_lINEA='" + idCliente + "'");
                if (oTabla.Rows.Count > 0)
                    tipoCliente = oTabla.Rows[0]["CLI_TIPOCliente"].ToString();
            }

            if (rbContado.Checked)
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    frmFacturar oPantalla = frmFacturar.getInstance(oFactura, (DataTable)dgrDatos.DataSource, txtTipoCambio, "frmFacturacionRapida");
                    oPantalla.MdiParent = this.MdiParent;
                    oPantalla.Show();
                    this.Enabled = false;
                }
                else
                    MessageBox.Show("Ocurrio un error al conectarse a la base de datos.", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                facturar();
        }

        public void facturar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturaDAO = new FacturaDAO();
                    ofacturaPendienteDAO = new FacturasPendientesDAO();
                    ofacturaPendiente = new FacturasPendientes();

                    ofacturaPendiente.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                    ofacturaPendiente.Anombrede1 = txtANombreDe.Text;

                    ofacturaPendiente.Dias = txtDias;
                    ofacturaPendiente.Estatus = "PE";
                    ofacturaPendiente.Exento = 0;
                    ofacturaPendiente.FechaActual = DateTime.Now;
                    ofacturaPendiente.FechaEmision = dtpFechaFactura;
                    ofacturaPendiente.FechaVence = dtpFechaFactura.AddDays(txtDias);
                    ofacturaPendiente.IdCliente = int.Parse(idCliente);
                    ofacturaPendiente.Impuesto = 0;
                    ofacturaPendiente.Moneda = cmbMoneda;
                    ofacturaPendiente.Monto = Double.Parse(txtTotalFactura.Text.Substring(1)) + txtAdelantos;
                    ofacturaPendiente.Nombre = oFacturaDAO.ConsultaCliente(idCliente, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["cli_nombre"].ToString();
                    ofacturaPendiente.NumFactura = txtFactura.Text;
                    ofacturaPendiente.Observacion = oFacturaDAO.ConsultaFactura(txtFactura.Text, PROYECTO.Properties.Settings.Default.No_cia).Rows[0]["fac_observacion"].ToString();
                    ofacturaPendiente.Saldo = ofacturaPendiente.Monto;
                    ofacturaPendiente.Subtotal = Double.Parse(txtMontoIV.Text.Substring(1));
                    ofacturaPendiente.Tipocambio = txtTipoCambio;
                    ofacturaPendiente.TipoDocumento = "FAC - Factura";

                    ofacturaPendienteDAO.insertar(ofacturaPendiente);
                    if (ofacturaPendienteDAO.Error())
                        MessageBox.Show("Ocurrió un error al insertar el detalle de la factura a las cuentas pendientes: " + ofacturaPendienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ReciboFacturaDAO oReciboFacturaDAO = new ReciboFacturaDAO();

                    DataTable oRecibos = oConexion.EjecutaSentencia("select REC_NUMERO, FAC_MONEDA, recfac_monto, REC_FORMA_PAGO, RECFAC_MONTO_ORIGINAL from TBL_RECIBOS_FACTURA rf, TBL_RECIBOS_DINERO rd, TBL_FACTURA F where rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and rd.no_cia = rf.no_cia and rd.no_Cia = f.no_cia and REC_INDICE=recfac_recibo  and FAC_NUMERO=RECFAC_FACTURA and RECFAC_FACTURA = '" + txtFactura.Text + "'");

                    double saldoAnterior = ofacturaPendiente.Saldo;
                    double saldoActual = ofacturaPendiente.Saldo;
                    foreach (DataRow ofila in oRecibos.Rows)
                    {
                        try
                        {
                            CancelacionFacturasDAO oCancelacionDAO = new CancelacionFacturasDAO();
                            Transaccion oTransaccion = new Transaccion();

                            oTransaccion.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                            oTransaccion.FechaRegistro = oConexion.fecha();
                            oTransaccion.IdCliente = int.Parse(idCliente);
                            oTransaccion.NumFactura = txtFactura.Text;
                            oTransaccion.Tipotransaccion = "RD RECIBO DE DINERO";
                            oTransaccion.NumDocumento = int.Parse(ofila["REC_NUMERO"].ToString());
                            oTransaccion.Monto = Double.Parse(ofila["recfac_monto"].ToString());
                            oTransaccion.Moneda = ofila["FAC_MONEDA"].ToString();

                            if (oTransaccion.Monto == ofacturaPendiente.Saldo)
                                oTransaccion.Texto = "CANCELACION DE LA FACTURA";
                            else
                                oTransaccion.Texto = "ABONO A LA FACTURA";

                            saldoAnterior = saldoActual;
                            saldoActual = saldoActual - oTransaccion.Monto;

                            oTransaccion.SaldoAnterior = saldoAnterior;
                            oTransaccion.SaldoActual = saldoActual;
                            oTransaccion.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                            oCancelacionDAO.insertar(oTransaccion);
                            if (oCancelacionDAO.Error())
                                MessageBox.Show("Ocurrió un error al guardar la transaccion de la factura " + oTransaccion.NumFactura.ToString() + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            oCancelacionDAO.modificaFacturas(oTransaccion, ofila["REC_FORMA_PAGO"].ToString());
                            if (oCancelacionDAO.Error())
                                MessageBox.Show("Ocurrió un error al Modificar el saldo de la factura " + oTransaccion.NumFactura.ToString() + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            oCancelacionDAO.modificaRecibos(oTransaccion.NumDocumento, (Double.Parse(ofila["RECFAC_MONTO_ORIGINAL"].ToString()) - Double.Parse(ofila["RECFAC_MONTO"].ToString())), PROYECTO.Properties.Settings.Default.Usuario, ofila["REC_FORMA_PAGO"].ToString(), PROYECTO.Properties.Settings.Default.No_cia);

                            if (oCancelacionDAO.Error())
                                MessageBox.Show("Ocurrió un error al Modificar el saldo del recibo " + oTransaccion.NumDocumento + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch { }
                    }

                    oFactura = new Factura();

                    oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oFactura.NumFactura = int.Parse(txtFactura.Text);
                    oFactura.Nombre = txtANombreDe.Text;
                    oFactura.Indice = indiceFactura;
                    oFactura.SubTotal = Double.Parse(txtSubTotal.Text.Substring(1));
                    oFactura.Impuesto = Double.Parse(txtMontoIV.Text.Substring(1));
                    oFactura.Descuento = Double.Parse(txtDescuento.Text.Substring(1));
                    oFactura.Adelanto = txtAdelantos;
                    oFactura.Total = Double.Parse(txtTotalFactura.Text.Substring(1));

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();

                    if (oFacturaDAO.ModificaEstadoFactura(oFactura) > 0)
                    {
                        txtEstado.Text = "FACTURADA";

                        MessageBox.Show("El documento se facturó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Ocurrió un error al Modificar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbEmbalaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double total = 0;
            String cadena = "";
            if (!txtCantidad.Text.Equals("") && !txtCantidad.Text.Equals("0") && !txtPrecioUnitario.Text.Equals("") && !txtPrecioUnitario.Text.Equals("0.00"))
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
                btnGuardarDetalle.Text = " F3 - Guardar";
                btnGuardarDetalle.ImageIndex = 1;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Está seguro que desea ANULAR la factura?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (indiceFactura == 0)
                    {
                        MessageBox.Show("Seleccione la factura a anular.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("ABIERTA"))
                    {
                        MessageBox.Show("Este documento no se puede anular porque no ha sido facturado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtEstado.Text.Equals("ANULADA"))
                    {
                        MessageBox.Show("Este documento ya fue anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    modificar();


                    oFactura = new Factura();

                    oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oFactura.NumFactura = int.Parse(txtFactura.Text);
                    oFactura.Indice = indiceFactura;
                    oFactura.Cliente = idCliente;
                    if (rbContado.Checked)
                        oFactura.Tipo = "CONTADO";
                    else
                        oFactura.Tipo = "CREDITO";

                    frmFacturaAnular oPantalla = frmFacturaAnular.getInstance(oFactura, (DataTable)dgrDatos.DataSource, this.Name);
                    oPantalla.MdiParent = this.MdiParent;
                    oPantalla.Show();

                    this.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
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
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, '' codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, '' idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, SER_CODIGO codigoArticulo from TBL_FACTURA F, TBL_FACTURA_DETALLE df, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and SER_INDICE=DETFAC_CODIGO and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtFactura.Text + "' ORDER BY DETFAC_NUMEROLINEA";
                    }
                    else
                    {
                        sql = "select fac_nombre as nombre, fac_telefono as telefono, to_char(fac_fecha,'dd') as dia, to_char(fac_fecha,'MM') as mes, to_char(fac_fecha,'yyyy') as anno, fac_observacion as obcervacion, fac_subtotal as subtotal, fac_impuesto as impuesto, fac_excento as excento, fac_total as total, fac_moneda as moneda, detfac_cantidad as cantidad, detfac_medida as embalaje, DETFAC_DESCRIPCION as descripcion, DETFAC_PRECIO_UNITARIO as costUnit, (detfac_cantidad*DETFAC_PRECIO_UNITARIO) as costTotal, fac_ubicacion AS ubicacion, fac_adelanto adelanto, cl.cli_id codigoCliente, case when f.fac_tipodocumento = 'PED' then to_char(f.fac_indicedocumento) else ' ' end pedido, cl.cli_identificacion idPersona, f.fac_vendedor vendedor, '', '' vence, case when df.DETFAC_SUBTOTAL = 0 then '1' else '0' end indImpuesto,EMPR_NOMBRE, EMPR_LOGO Logo,EMPR_IDENTIFICACION, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, (DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)- ((DETFAC_CANTIDAD*DETFAC_PRECIO_UNITARIO)* (DETFAC_DESCUENTO/100)) as costTotal, DETFAC_DESCUENTO descuento, (SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, SER_CODIGO codigoArticulo from TBL_FACTURA F, TBL_FACTURA_DETALLE df, TBL_CLIENTES cl, TBL_EMPRESA em, TBL_ARTICULOS ar WHERE f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and f.no_cia = df.no_cia and f.no_cia = cl.no_cia and f.no_cia = em.no_cia and f.no_cia = ar.no_cia and SER_INDICE=DETFAC_CODIGO and f.fac_cliente = cl.cli_linea and FAC_LINEA = DETFAC_INDICEFACTURA and fac_numero ='" + txtFactura.Text + "' ORDER BY DETFAC_NUMEROLINEA";
                    }

                    DataTable oTabla = crearTabla(oReporteDAO.EjecutaSentencia(sql).Tables[0]);
                    if (oTabla.Rows.Count > 0)
                    {
                        frmVisorReportesFactura oVisor = frmVisorReportesFactura.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptFactura oReporte = new rptFactura();
                        oReporte.DataDefinition.FormulaFields["factura"].Text = "'" + txtFactura.Text + "'";
                        oReporte.DataDefinition.FormulaFields["contado"].Text = "'" + (txtDias == 0 ? "CONTADO" : "CREDITO") + "'";
                        oReporte.DataDefinition.FormulaFields["fechaPago"].Text = "'" + dtpFechaFactura.AddDays(txtDias).ToShortDateString() + "'";
                        oReporte.DataDefinition.FormulaFields["totGrabado"].Text = double.Parse(txtMontoIV.Text.Substring(1)).ToString();
                        oReporte.DataDefinition.FormulaFields["totExento"].Text = "0.00";
                        oReporte.DataDefinition.FormulaFields["subtotal"].Text = double.Parse(txtSubTotal.Text.Substring(1)).ToString();
                        oReporte.DataDefinition.FormulaFields["descuento"].Text = double.Parse(txtDescuento.Text.Substring(1)).ToString();
                        oReporte.DataDefinition.FormulaFields["usuario"].Text = "'" + PROYECTO.Properties.Settings.Default.Usuario + "'";

                        oReporte.SetDataSource(oTabla);
                        oVisor.ReportSource(oReporte);
                        oVisor.Show();
                    }
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || //Char.IsPunctuation(e.KeyChar) || 
                Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
            calcularTotalPorLinea("CANTIDAD");
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIndice_Enter(object sender, EventArgs e)
        {
            modificar();
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
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
                    DataTable oTabla2 = oConexion.EjecutaSentencia("SELECT SUM(RECFAC_MONTO) AS RECFAC_MONTO FROM TBL_RECIBOS_FACTURA rf where rf.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and RECFAC_FACTURA= '" + txtFactura.Text + "'");
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
                        oDatoVendedor = oConexion.EjecutaSentencia("select emp_nombre from TBL_EMPLEADO em WHERE em.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  emp_cedula = '" + oFila["vendedor"].ToString() + "'");
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
            btnBusqServicio.PerformClick();
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

                calcularTotalPorLinea("CANTIDAD");
            }
            catch { }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals("0"))
                txtCantidad.Clear();
        }

        private void txtTotalPorLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtTotalPorLinea.Text.Length; i++)
            {
                if (txtTotalPorLinea.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }
        
        private void txtTotalPorLinea_Enter(object sender, EventArgs e)
        {
            txtTotalPorLinea.Text = double.Parse(txtTotalPorLinea.Text.Substring(1)).ToString("########0.00");
            if (txtTotalPorLinea.Text.Equals("0.00"))
                txtTotalPorLinea.Clear();
        }

        private void txtTotalPorLinea_Leave(object sender, EventArgs e)
        {
            if (txtTotalPorLinea.Text.Equals(""))
                txtTotalPorLinea.Text = "0.00";
            txtTotalPorLinea.Text = double.Parse(txtTotalPorLinea.Text).ToString("¢ ###,###,##0.00");
            calcularTotalPorLinea("MONTO");
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
                    idCliente = "";
                    cliente = 0;
                    txtDescServicio.Clear();
                    llenarGrid();

                    IndiceDocumento = 0;
                    dtpFechaFactura = oConexion.fecha();
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
                btnBFactura.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnAnular.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
            }
            else if (txtEstado.Text.Equals("ABIERTA"))
            {
                btnBFactura.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = true;
                btnFacturar.Enabled = true;
                btnAnular.Enabled = false;
                btnNuevoDetalle.Enabled = true;
                btnBusqServicio.Enabled = true;
                btnGuardarDetalle.Enabled = true;
                btnEliminarDetalle.Enabled = true;
            }
            else if (txtEstado.Text.Equals("FACTURADA"))
            {
                btnBFactura.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnAnular.Enabled = true;
                btnNuevoDetalle.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
            }
            else if (txtEstado.Text.Equals("ANULADA"))
            {
                btnBFactura.Enabled = true;
                btnNueva.Enabled = true;
                btnGuardar.Enabled = false;
                btnFacturar.Enabled = false;
                btnAnular.Enabled = false;
                btnNuevoDetalle.Enabled = false;
                btnBusqServicio.Enabled = false;
                btnGuardarDetalle.Enabled = false;
                btnEliminarDetalle.Enabled = false;
            }
        }

        private void calcularTotalPorLinea(String pTipo)//CANTIDAD / MONTO
        {
            try
            {
                double porcDescuento = double.Parse(txtLineaDescuento.Text) / 100;
                double subtotal = 0;
                double montoDescuento = 0;
                double montoIV = 0;

                if (pTipo.Equals("CANTIDAD"))
                {
                    subtotal = Double.Parse(txtCantidad.Text) * Double.Parse(txtPrecioUnitario.Text.Substring(1));
                    montoDescuento = (subtotal * porcDescuento);
                    montoIV = IVI.Equals("S") ? 0 : subtotal * (IV / 100);

                    double total = subtotal - montoDescuento + montoIV;

                    if (cmbMoneda.Equals("CRC"))
                    {
                        RedondearNumero oRedondear = new RedondearNumero();
                        total = oRedondear.Redondear(total);
                    }

                    switch (cmbMoneda.Trim())
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
                            txtSubTotalLinea.Text = subtotal.ToString("###,###,##0.00");
                            txtTotalPorLinea.Text = total.ToString("###,###,##0.00");
                            break;
                    }
                }
                else if (pTipo.Equals("MONTO"))
                {
                    double cantidad = Math.Round(Double.Parse(txtTotalPorLinea.Text.Substring(1)) / Double.Parse(txtPrecioUnitario.Text.Substring(1)), 4);


                    txtCantidad.Text = cantidad.ToString("###,###,##0.00##");

                    subtotal = cantidad * Double.Parse(txtPrecioUnitario.Text.Substring(1));
                    montoDescuento = (subtotal * porcDescuento);
                    montoIV = IVI.Equals("S") ? 0 : subtotal * (IV / 100);

                    double total = subtotal - montoDescuento + montoIV;

                    if (cmbMoneda.Equals("CRC"))
                    {
                        RedondearNumero oRedondear = new RedondearNumero();
                        total = oRedondear.Redondear(total);
                    }

                    switch (cmbMoneda.Trim())
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
                            txtSubTotalLinea.Text = subtotal.ToString("###,###,##0.00");
                            txtTotalPorLinea.Text = total.ToString("###,###,##0.00");
                            break;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void txtLineaDescuento_Enter(object sender, EventArgs e)
        {
            txtLineaDescuento.Text = Double.Parse(txtLineaDescuento.Text).ToString("########0.00");
            if (txtLineaDescuento.Text.Equals("0.00"))
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
                txtLineaDescuento.Text = "0.00";
            txtLineaDescuento.Text = Double.Parse(txtLineaDescuento.Text).ToString("###,###,##0.00");

            calcularTotalPorLinea("CANTIDAD");
        }

        public void CalculaSaldos()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    string monedaSaldo = cmbMoneda;
                    string monedaFactura = cmbMoneda;
                    double tc = txtTipoCambio;
                    LimiteSaldo = 0;
                    SaldoUsado = 0;

                    DataTable oLimiteSaldo = oConexion.EjecutaSentencia("SELECT CLI_LC_MONEDA,CLI_LC_LIMITE FROM TBL_CLIENTES c WHERE c.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and CLI_LINEA=" + idCliente);

                    if (oLimiteSaldo.Rows.Count > 0)
                    {
                        monedaSaldo = oLimiteSaldo.Rows[0]["CLI_LC_MONEDA"].ToString();
                        if (monedaSaldo.Equals(cmbMoneda))
                            LimiteSaldo = double.Parse(oLimiteSaldo.Rows[0]["CLI_LC_LIMITE"].ToString());
                        else if (monedaSaldo.Equals("CRC") && cmbMoneda.Equals("USD"))
                            LimiteSaldo = double.Parse(oLimiteSaldo.Rows[0]["CLI_LC_LIMITE"].ToString()) / tc;
                        else if (monedaSaldo.Equals("USD") && cmbMoneda.Equals("CRC"))
                            LimiteSaldo = double.Parse(oLimiteSaldo.Rows[0]["CLI_LC_LIMITE"].ToString()) * tc;
                    }

                    DataTable oSaldoUsado = oConexion.EjecutaSentencia("SELECT FACP_MONEDA,FACP_SALDO FROM TBL_FACTURAS_PENDIENTES_CTA FPC where fpc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and FACP_CLIENTE='" + idCliente + "' and FACP_ESTATUS='PE' and facp_estado = 1");

                    foreach (DataRow ofila in oSaldoUsado.Rows)
                    {
                        monedaFactura = ofila["FACP_MONEDA"].ToString();

                        if (monedaFactura.Equals(cmbMoneda))
                            SaldoUsado += double.Parse(ofila["FACP_SALDO"].ToString());
                        else if (monedaFactura.Equals("CRC") && cmbMoneda.Equals("USD"))
                            SaldoUsado += double.Parse(ofila["FACP_SALDO"].ToString()) / tc;
                        else if (monedaFactura.Equals("USD") && cmbMoneda.Equals("CRC"))
                            SaldoUsado += double.Parse(ofila["FACP_SALDO"].ToString()) * tc;
                    }

                    SaldoLibre = LimiteSaldo - SaldoUsado;

                    if (cmbMoneda.Equals("USD"))
                        txtCredDisponible = SaldoLibre;//.ToString("$ ###,###,##0.00");
                    else if (cmbMoneda.Equals("CRC"))
                        txtCredDisponible = SaldoLibre;//.ToString("¢ ###,###,##0.00");
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

        private void frmFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8)
            {
                txtCodServicio.Focus();

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
                else if (e.KeyCode == Keys.F6)
                    btnAnular.PerformClick();
                else if (e.KeyCode == Keys.F7)
                    btnEliminarDetalle.PerformClick();
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            CalculaEstado();
        }

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            txtPrecioUnitario.Text = double.Parse(txtPrecioUnitario.Text.Substring(1)).ToString("########0.00");
            if (txtPrecioUnitario.Text.Equals("0.00"))
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
                txtPrecioUnitario.Text = "0.00";
            txtPrecioUnitario.Text = double.Parse(txtPrecioUnitario.Text).ToString("¢ ###,###,##0.00");
            calcularTotalPorLinea("CANTIDAD");
        }

        private void BuscaCodigoArticulo()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    ServicioDAO oServicioDAO = new ServicioDAO();
                    DataTable oTabla = oServicioDAO.ConsultaCodigo(txtCodServicio.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oServicioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oTabla.Rows.Count > 1)
                        {
                            btnBusqServicio.PerformClick();
                        }
                        else if (oTabla.Rows.Count > 0)
                        {
                            cargaServicio(oTabla.Rows[0]["SER_INDICE"].ToString(), oTabla.Rows[0]["SER_NOMBRE"].ToString(), oTabla.Rows[0]["INV_IVI"].ToString(), double.Parse(oTabla.Rows[0]["INV_IMPUESTO_VENTAS"].ToString()));
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

        private void btnFacturaAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtFactura.Text.Equals("") && !txtFactura.Text.Equals("0"))
                    cargaFactura((int.Parse(txtFactura.Text) - 1).ToString(), "");
            }
            catch { }
        }

        private void btnFacturaAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtFactura.Text.Equals(""))
                    cargaFactura((int.Parse(txtFactura.Text) + 1).ToString(), "");
            }
            catch { }
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
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigoAbrir, PROYECTO.Properties.Settings.Default.Usuario);
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