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


namespace PROYECTO
{
    public partial class frmPagosProveedores : Form
    {
        string prov, codprov, guia, moneda, facturas;
        double monto, dolar;
        private DataTable aFacturas = new DataTable();
        private static frmPagosProveedores ofacturas = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private TipoCambioDAO oTipoCambioDAO = null;

        private PagosProveedoresDAO oPagoDAO = null;
        private PagosProveedores oPagos = null;
        private Cantidad_a_Letra oCantidad = new Cantidad_a_Letra();
        private ReportesDAO oReporteDAO = new ReportesDAO();
        private String codigo = "pro_pagoProveedores", descripcion = "Confirmacion de pagos.", modulo = "Procesos_Cuentas por Pagar";
        private int numero = 0;

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

        public static frmPagosProveedores getInstance(string pprov, string pcodprov, string pguia, string pmoneda, double pmonto, string pfacturas, DataTable paFacturas)
        {
            if (ofacturas == null)
                ofacturas = new frmPagosProveedores(pprov, pcodprov, pguia, pmoneda, pmonto, pfacturas, paFacturas);
            return ofacturas;
        }

        private frmPagosProveedores(string pprov, string pcodprov, string pguia, string pmoneda, double pmonto, string pfacturas, DataTable paFacturas)
        {
            prov = pprov;
            codprov = pcodprov;
            guia = pguia;
            moneda = pmoneda;
            monto = pmonto;
            facturas = pfacturas;
            aFacturas = paFacturas;
            InitializeComponent();
        }

        public static frmPagosProveedores getInstance()
        {
            if (ofacturas == null)
                ofacturas = new frmPagosProveedores();
            return ofacturas;
        }

        private frmPagosProveedores()
        {
        }

        private void frmPagosProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                string moned = "";
                txtCodProveedor.Text = codprov;
                txtProveedor.Text = prov;
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                txtfechaactual.Text = oConexion.fecha().ToShortDateString();
                oConexion.cerrarConexion();
                txtGuiaPago.Text = guia;
                txtMoneda.Text = moneda;
                if (moneda.Equals("CRC"))
                {
                    txtMontoGuia.Text = "¢ " + monto.ToString("###,###,##0.00");
                    moned = "colones";
                }
                else if (moneda.Equals("USD"))
                {
                    txtMontoGuia.Text = "$ " + monto.ToString("###,###,##0.00");
                    moned = "dolares";
                }

                string sRetorno = oCantidad.ConvertirCadena(Convert.ToDouble(txtMontoGuia.Text.Trim().Substring(1)), moned);
                if (sRetorno != "")
                {
                    lblMontoenLetras.Text = sRetorno.ToUpper()[0] + sRetorno.ToLower().Substring(1);
                }
                txtDetalleComprobante.Text = "PAGO/FACT: " + facturas;
                LlenarGasto();
                this.Focus();
            }
            catch (Exception ex)
            {
            }

        }

        private void frmPagosProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t13");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }


        private void LlenarGasto()
        {
            DataTable oTabla = new DataTable();
            oTabla.Columns.Add("codigo", typeof(string));
            oTabla.Columns.Add("gasto", typeof(string));
            DataRow oDataRow = null;
            oDataRow = oTabla.NewRow();
            oDataRow["codigo"] = "200";
            oDataRow["gasto"] = "200  | Gastos Operativos";
            oTabla.Rows.Add(oDataRow.ItemArray);
            oDataRow = oTabla.NewRow();
            oDataRow["codigo"] = "201";
            oDataRow["gasto"] = "201  | Compra de Materiales";
            oTabla.Rows.Add(oDataRow.ItemArray);

            cboTipoGasto.DataSource = oTabla;
            cboTipoGasto.DisplayMember = "gasto";
            cboTipoGasto.ValueMember = "codigo";
            cboTipoGasto.SelectedIndex = 0;

            cboFormaPago.SelectedIndex = 0;
        }

        private void frmPagosProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofacturas = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oPagoDAO = new PagosProveedoresDAO();
                    oPagos = new PagosProveedores();

                    oPagos.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oPagos.Proveedor = txtCodProveedor.Text;
                    oPagos.TipoPago = cboFormaPago.Text;
                    oPagos.Flujo = int.Parse(cboTipoGasto.SelectedValue.ToString());
                    oPagos.Documento = 0;
                    oPagos.Monto = double.Parse(txtMontoGuia.Text.Trim().Substring(1));
                    oPagos.DetallePago = txtDetalleComprobante.Text;

                    for (int x = 0; x < aFacturas.Rows.Count; x++)
                    {
                        oPagoDAO.Insertar(oPagos, txtGuiaPago.Text, aFacturas.Rows[x].ItemArray[0].ToString(), double.Parse(aFacturas.Rows[x].ItemArray[1].ToString()));
                        if (oPagoDAO.Error())
                        {
                            MessageBox.Show("Error: \n" + oPagoDAO.DescError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            oConexion.cerrarConexion();
                            return;
                        }
                    }
                    oPagoDAO.InsertarPago(oPagos, int.Parse(txtGuiaPago.Text));

                    if (oPagoDAO.Error())
                        MessageBox.Show("Error: \n" + oPagoDAO.DescError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Pago Realizado Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar1.Visible = true;
                        timer1.Start();
                    }
                    oConexion.cerrarConexion();
                    try
                    {
                        frmPrepagoProveedor oPrepago = frmPrepagoProveedor.getInstance();
                        oPrepago.llenaGrid();
                        oPrepago.llenaGrid2();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }

        }

        private void txtCompCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cboFormaPago.Text.Equals("CHEQUE"))
                if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                timer1.Stop();
                ejecutar();
                this.Close();
            }
        }

        private void ejecutar()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String sql = "SELECT DETPRE_PREPAGO guia, PROV_NOMBRE proveedor, DETPRE_FACTURA factura, DETPRE_MONTO monto, DETPRE_SALDO saldo, DETPRE_ABONO abono,to_char(sysdate,'DD/MM/YYYY') fecha , PRE_MONEDA moneda, GAS_NOMBRE gasto, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_DETALLE_PREPAGO DPP, TBL_PREPAGOS_PROVEEDORES PPP, TBL_PROVEEDOR p, TBL_GASTOS g, TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_PAGOS_PROVEEDORES PP, TBL_EMPRESA e where dpp.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and dpp.no_cia = ppp.no_cia and dpp.no_cia = p.no_cia and dpp.no_cia = g.no_cia and dpp.no_cia = fpp.no_cia and dpp.no_cia = pp.no_cia and fpp.no_cia = e.no_cia and pre_id = pag_id and DETPRE_FACTURA = FACPAG_NUM_FACTURA and GAS_CODIGO = FACPAG_TIPO_GASTO and prov_linea = PRE_PROVEEDOR and DETPRE_PREPAGO= " + txtGuiaPago.Text + " and DETPRE_ESTADO='FC'and detpre_prepago= ppp.pre_id and DETPRE_PROVEEDOR = " + txtCodProveedor.Text + " and facpag_proveedor= pre_proveedor";

                    DataTable oTable = oReporteDAO.EjecutaSentencia(sql).Tables[0];
                    if (oTable.Rows.Count > 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptPagoProveedor oReporte = new rptPagoProveedor();
                        oReporte.SetDataSource(oTable);
                        oVisor.ReportSource(oReporte);
                        oVisor.Show();
                    }
                    else
                        MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                    progressBar1.Visible = false;
                }
                else
                    MessageBox.Show("Error al conectarse a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

    }
}