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
    public partial class frmPrepagoProveedor : Form
    {
        private Double montoAnterior;
        private static frmPrepagoProveedor ofacturas = null;
        private ConexionDAO oConexion = null;
        private FacturasPagosDAO oFacturaDAO = null;
        private FacturasPago oFacturasPago = null;
        private TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
        private char simMoneda = '¢';
        private DataTable oDataTable;
        private DataTable oDataTable1 = new DataTable();
        private GuiaPrepagoProveedorDAO oGuiaPrepagoProveedorDAO = null;
        private GuiaPrepagoProveedor oGuiaPrepagoProveedor = null;
        private DetallePrepagoDAO oDetalleDAO = null;
        private DetallePrepago oDetalle = null;
        private String codigo = "par_pagoProveedores", descripcion = "Prepago a proveedores.", modulo = "Procesos";
        private int numero = 0;
        private double monto, saldo;

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

        public String Codigo1
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private frmPrepagoProveedor()
        {
            InitializeComponent();
        }

        public static frmPrepagoProveedor getInstance()
        {
            if (ofacturas == null)
                ofacturas = new frmPrepagoProveedor();
            return ofacturas;
        }

        public void LlenarProveedor(String cod, String des)
        {
            txtCodProveedor.Text = cod;
            txtProveedor.Text = des;
            rbtnCol.Checked = true;

            if (!cod.Equals(""))
            {
                btnCancelarPagos.Enabled = true;
                btnAgregarFactura.Enabled = true;
            }

            BuscarGuia();
            llenaGrid();
            llenaGrid2();

            btnAgregarFactura.Enabled = true;
            btnEliminar.Enabled = true;
        }

        public void llenaGrid()
        {
            try
            {
                DataRow oDataRow = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    CrearTabla();
                    CrearTabla1();
                    oFacturaDAO = new FacturasPagosDAO();
                    string moned = "";
                    if (rbtnCol.Checked)
                        moned = "CRC";
                    else if (rbtnUsd.Checked)
                        moned = "USD";


                    foreach (DataRow OFila in oFacturaDAO.Busqueda_Consulta(txtCodProveedor.Text, "FP", moned, "0", PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows)
                    {
                        oDataRow = oDataTable.NewRow();
                        oDataRow["facpag_num_factura"] = OFila.ItemArray[0].ToString();
                        oDataRow["facpag_moneda"] = OFila.ItemArray[6].ToString();
                        oDataRow["FACPAG_INDICE"] = OFila.ItemArray[13].ToString();
                        oDataRow["gas_nombre"] = OFila.ItemArray[5].ToString();
                        oDataRow["facpag_monto"] = OFila.ItemArray[10].ToString();
                        oDataRow["facpag_saldo"] = OFila.ItemArray[11].ToString();
                        oDataRow["Abono"] = "0";
                        oDataRow["saldo_actual"] = OFila.ItemArray[11].ToString();
                        oDataRow["facpag_proveedor"] = OFila.ItemArray[1].ToString();
                        oDataRow["facpag_fecha_emision"] = DateTime.Parse(OFila.ItemArray[8].ToString()).ToShortDateString();
                        oDataRow["facpag_fecha_vence"] = DateTime.Parse(OFila.ItemArray[9].ToString()).ToShortDateString();
                        oDataRow["facpag_tipo_cambio"] = OFila.ItemArray[7].ToString();
                        oDataRow["facpag_estatus"] = OFila.ItemArray[12].ToString();
                        oDataRow["prov_nombre"] = OFila.ItemArray[2].ToString();
                        oDataRow["facpag_flujo"] = OFila.ItemArray[3].ToString();
                        oDataRow["facpag_tipo_gasto"] = OFila.ItemArray[4].ToString();

                        oDataTable.Rows.Add(oDataRow.ItemArray);
                    }

                    dgrDatos.DataSource = oDataTable;
                    llenarMontos();
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer las facturas: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ha ocurrido al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        public void llenaGrid2()
        {
            try
            {
                DataRow oDataRow = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oDetalleDAO = new DetallePrepagoDAO();
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturaDAO = new FacturasPagosDAO();
                    string moned = "";
                    if (rbtnCol.Checked)
                        moned = "CRC";
                    else if (rbtnUsd.Checked)
                        moned = "USD";

                    BuscarGuia();
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    oDataTable1.Rows.Clear();
                    dgrDatos2.DataSource = oDataTable1;
                    llenarMontos2();
                    foreach (DataRow OFila in oDetalleDAO.consultar(txtCodProveedor.Text, Double.Parse(txtGuiaPago.Text), moned, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows)
                    {
                        oDataRow = oDataTable1.NewRow();
                        oDataRow["detpre_factura"] = OFila.ItemArray[2].ToString();
                        oDataRow["moneda"] = moned;
                        oDataRow["detpre_monto"] = OFila.ItemArray[3].ToString();
                        oDataRow["detpre_saldo"] = OFila.ItemArray[5].ToString();
                        oDataRow["detpre_Abono"] = OFila.ItemArray[4].ToString();
                        oDataRow["saldoactual"] = (double.Parse(OFila.ItemArray[5].ToString()) - double.Parse(OFila.ItemArray[4].ToString())) + "";
                        oDataRow["detpre_prepago"] = OFila.ItemArray[0].ToString();
                        oDataRow["detpre_INDICE"] = OFila.ItemArray[6].ToString();
                        oDataRow["detpre_proveedor"] = OFila.ItemArray[1].ToString();
                        oDataTable1.Rows.Add(oDataRow.ItemArray);
                    }

                    dgrDatos2.DataSource = oDataTable1;
                    llenarMontos2();
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer las facturas: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ha ocurrido al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void frmPrepagoProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofacturas = null;
        }

        private void btnBusqProv_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("ProveedorPrepago");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
            //btnCancelarPagos.Enabled = false;
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            string moneda = "";
            if (rbtnCol.Checked)
                moneda = "CRC";
            else if (rbtnUsd.Checked)
                moneda = "USD";

            frmFacturaPorPagarProveedorRapida oRapida = frmFacturaPorPagarProveedorRapida.getInstance(txtCodProveedor.Text, txtProveedor.Text, moneda);
            oRapida.MdiParent = this.MdiParent;
            oRapida.Show();
        }

        private void rbtnCol_CheckedChanged(object sender, EventArgs e)
        {
            simMoneda = '¢';
            llenaGrid();
            llenaGrid2();
        }

        private void rbtnUsd_CheckedChanged(object sender, EventArgs e)
        {
            simMoneda = '$';
            llenaGrid();
            llenaGrid2();
        }

        private void CrearTabla()
        {
            oDataTable = new DataTable();
            oDataTable.Columns.Add("facpag_num_factura", typeof(string));
            oDataTable.Columns.Add("facpag_moneda", typeof(string));
            oDataTable.Columns.Add("FACPAG_INDICE", typeof(string));
            oDataTable.Columns.Add("gas_nombre", typeof(string));
            oDataTable.Columns.Add("facpag_monto", typeof(double));
            oDataTable.Columns.Add("facpag_saldo", typeof(double));
            oDataTable.Columns.Add("Abono", typeof(double));
            oDataTable.Columns.Add("saldo_actual", typeof(double));
            oDataTable.Columns.Add("facpag_proveedor", typeof(string));
            oDataTable.Columns.Add("facpag_fecha_emision", typeof(string));
            oDataTable.Columns.Add("facpag_fecha_vence", typeof(string));
            oDataTable.Columns.Add("facpag_tipo_cambio", typeof(string));
            oDataTable.Columns.Add("facpag_estatus", typeof(string));
            oDataTable.Columns.Add("prov_nombre", typeof(string));
            oDataTable.Columns.Add("facpag_flujo", typeof(string));
            oDataTable.Columns.Add("facpag_tipo_gasto", typeof(string));
        }

        private void CrearTabla1()
        {
            oDataTable1 = new DataTable();
            oDataTable1.Columns.Add("detpre_factura", typeof(string));
            oDataTable1.Columns.Add("moneda", typeof(string));
            oDataTable1.Columns.Add("detpre_monto", typeof(double));
            oDataTable1.Columns.Add("detpre_saldo", typeof(double));
            oDataTable1.Columns.Add("detpre_Abono", typeof(double));
            oDataTable1.Columns.Add("saldoactual", typeof(double));
            oDataTable1.Columns.Add("detpre_prepago", typeof(string));
            oDataTable1.Columns.Add("detpre_INDICE", typeof(string));
            oDataTable1.Columns.Add("detpre_proveedor", typeof(string));
        }

        private void frmPrepagoProveedor_Load(object sender, EventArgs e)
        {
            txtfechaactual.Text = DateTime.Today.ToShortDateString();
        }

        private void llenarMontos()
        {
            double sal = 0;
            double mon = 0;
            double abo = 0;
            double saldactual = 0;
            foreach (DataGridViewRow oRow in dgrDatos.Rows)
            {
                sal += Double.Parse(oRow.Cells["facpag_saldo"].Value.ToString());
                mon += Double.Parse(oRow.Cells["facpag_monto"].Value.ToString());
                abo += Double.Parse(oRow.Cells["Abono"].Value.ToString());
                saldactual += Double.Parse(oRow.Cells["saldo_actual"].Value.ToString());
            }

            txtMonto.Text = simMoneda + " " + mon.ToString("###,###,##0.00");
            txtSAldo.Text = simMoneda + " " + sal.ToString("###,###,##0.00");
            txtAbono.Text = simMoneda + " " + abo.ToString("###,###,##0.00");
            txtSaldoActual.Text = simMoneda + " " + saldactual.ToString("###,###,##0.00");

        }

        private void llenarMontos2()
        {
            double sal = 0.0;
            double mon = 0.0;
            double abo = 0.0;
            foreach (DataGridViewRow oRow in dgrDatos2.Rows)
            {
                sal += Double.Parse(oRow.Cells["detpre_saldo"].Value.ToString());
                mon += Double.Parse(oRow.Cells["detpre_monto"].Value.ToString());
                abo += Double.Parse(oRow.Cells["detpre_Abono"].Value.ToString());
            }

            txtMonto2.Text = simMoneda + " " + mon.ToString("###,###,##0.00");
            txtSaldo2.Text = simMoneda + " " + sal.ToString("###,###,##0.00");
            txtAbono2.Text = simMoneda + " " + abo.ToString("###,###,##0.00");

        }

        private void dgrDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            operacion(e.ColumnIndex, e.RowIndex);
        }

        private void operacion(int col, int fil)
        {
            try
            {
                if (col == 0)
                {
                    Double monto = 0;
                    DataTable oTable = new DataTable();
                    oTable = (DataTable)dgrDatos.DataSource;
                    DataRow ofila = oTable.Rows[fil];
                    monto = Double.Parse(dgrDatos.Rows[fil].Cells["facpag_saldo"].Value.ToString());
                    Double montoTotalRecibo = 0;
                    Double saldo = 0;
                    montoTotalRecibo = Double.Parse(txtSaldoActual.Text.Substring(1));

                    if (dgrDatos["Abono", fil].Value.ToString().Equals("0") || dgrDatos["Abono", fil].Value.ToString().Equals(""))
                    {
                        if (montoTotalRecibo <= 0)
                        {
                            MessageBox.Show("Ya ha utilizado el monto de la Factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        saldo = Double.Parse(dgrDatos["saldo_actual", fil].Value.ToString());
                        if (montoTotalRecibo >= saldo)
                        {
                            dgrDatos["Abono", fil].Value = saldo.ToString();
                            dgrDatos["saldo_actual", fil].Value = Double.Parse("0").ToString();
                            dgrDatos.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            dgrDatos.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            saldo = montoTotalRecibo - saldo;
                        }
                        else
                        {
                            saldo -= montoTotalRecibo;
                            dgrDatos["Abono", fil].Value = montoTotalRecibo.ToString();
                            dgrDatos["saldo_actual", fil].Value = saldo.ToString();
                            dgrDatos.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            dgrDatos.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    else
                    {
                        if (Double.Parse(dgrDatos["Abono", fil].Value.ToString()) > 0)
                        {
                            dgrDatos["saldo_actual", fil].Value = (Double.Parse(dgrDatos["saldo_actual", fil].Value.ToString()) + Double.Parse(dgrDatos["Abono", fil].Value.ToString()));
                        }
                        dgrDatos["Abono", fil].Value = Double.Parse("0").ToString();
                        dgrDatos.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dgrDatos.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        saldo = Double.Parse(dgrDatos["Abono", fil].Value.ToString());
                    }

                    CalculaTotalAbonos();
                    CalculaTotalSaldosActuales();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CalculaTotalAbonos()
        {
            Double abonos = 0;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
                abonos += Double.Parse(oFila.Cells["Abono"].Value.ToString());

            if (abonos > 0)
                txtAbono.Text = simMoneda + " " + abonos.ToString("###,###,##0.00");
            else
                txtAbono.Text = simMoneda + " 0";

            if (txtSaldoActual.Text.Trim().Substring(1).Equals("0,00"))
                txtAbono.Text = txtMonto.Text;
        }

        private void CalculaTotalSaldosActuales()
        {
            Double saldos = 0;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
                saldos += Double.Parse(oFila.Cells["saldo_actual"].Value.ToString());

            if (saldos > 0)
                txtSaldoActual.Text = simMoneda + " " + saldos.ToString("###,###,##0.00");
            else
                txtSaldoActual.Text = simMoneda + " 0";
        }

        private void dgrDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                try
                {
                    if (dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString().Trim().Equals(""))
                        dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value = "0";
                    Double montoAbono = Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString());
                    if (montoAbono != montoAnterior)
                    {
                        if (montoAbono > Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["facpag_saldo"].Value.ToString()))
                        {
                            MessageBox.Show("No se puede realizar este abono, exede el saldo de la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgrDatos.Rows[e.RowIndex].Cells["saldo_actual"].Value = dgrDatos.Rows[e.RowIndex].Cells["facpag_saldo"].Value;
                            dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value = "0";
                            dgrDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            dgrDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            CalculaTotalAbonos();
                            CalculaTotalSaldosActuales();
                            return;
                        }
                        else
                            if ((Double.Parse(txtAbono.Text.Substring(1)) - montoAnterior + Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString())) <= Double.Parse(txtMonto.Text.Substring(1)))
                        {
                            dgrDatos.Rows[e.RowIndex].Cells["saldo_actual"].Value = double.Parse(Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["facpag_saldo"].Value.ToString()) - Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString()) + "");
                            if (Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString()) > 0)
                            {
                                dgrDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                                dgrDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                dgrDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                dgrDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            }

                            CalculaTotalAbonos();
                            CalculaTotalSaldosActuales();
                        }
                        else
                        {
                            MessageBox.Show("El monto del abono no puede ser mayor al disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgrDatos.Rows[e.RowIndex].Cells["saldo_actual"].Value = dgrDatos.Rows[e.RowIndex].Cells["facpag_saldo"].Value;
                            dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value = "0";
                            dgrDatos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            dgrDatos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            CalculaTotalAbonos();
                            CalculaTotalSaldosActuales();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value = "0";
                }

            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                monto = Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["facpag_monto"].Value.ToString());
                saldo = Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["facpag_saldo"].Value.ToString());

                montoAnterior = Double.Parse(dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value.ToString());
            }
            catch (Exception ex)
            {
                dgrDatos.Rows[e.RowIndex].Cells["Abono"].Value = "0";
            }
        }

        private void bnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos.Rows.Count > 0)
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    if (oConexion.abrirConexion())
                    {
                        BuscarGuia();
                        CrearGuia();
                        for (int x = 0; x < dgrDatos.Rows.Count; x++)
                        {
                            if (Double.Parse(dgrDatos["Abono", x].Value.ToString()) > 0)
                            {
                                oConexion.cerrarConexion();
                                oConexion.abrirConexion();
                                oFacturaDAO = new FacturasPagosDAO();
                                oFacturasPago = new FacturasPago();

                                oFacturasPago.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                                if (double.Parse(dgrDatos["saldo_actual", x].Value.ToString()) == 0)
                                    oFacturaDAO.Vincular(dgrDatos[2, x].Value.ToString(), dgrDatos[0, x].Value.ToString(), 1, PROYECTO.Properties.Settings.Default.No_cia);

                                oFacturasPago.Indice = int.Parse(dgrDatos["FACPAG_INDICE", x].Value.ToString());
                                oFacturasPago.NumFactura = dgrDatos["facpag_num_factura", x].Value.ToString();
                                oFacturasPago.Saldo = double.Parse(dgrDatos["saldo_actual", x].Value.ToString());

                                oFacturaDAO.Modificar(oFacturasPago);

                                AgregarDetalle(dgrDatos["facpag_num_factura", x].Value.ToString(), Double.Parse(dgrDatos["facpag_monto", x].Value.ToString()), Double.Parse(dgrDatos["facpag_saldo", x].Value.ToString()), Double.Parse(dgrDatos["Abono", x].Value.ToString()), int.Parse(dgrDatos["FACPAG_INDICE", x].Value.ToString()));
                                BuscarGuia();

                            }

                        }
                        oConexion.cerrarConexion();

                        llenaGrid();
                        llenaGrid2();

                    }
                }

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void BuscarGuia()
        {
            try
            {
                string guia = "";
                double monto = 0;
                DataTable oTabla = new DataTable();
                string moneda = "";

                oGuiaPrepagoProveedorDAO = new GuiaPrepagoProveedorDAO();
                if (rbtnCol.Checked)
                    moneda = "CRC";
                else if (rbtnUsd.Checked)
                    moneda = "USD";

                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                oTabla = oGuiaPrepagoProveedorDAO.ConsultarExistente(moneda, txtCodProveedor.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                oConexion.cerrarConexion();
                if (oTabla.Rows.Count > 0)
                {
                    guia = oTabla.Rows[0].ItemArray[0].ToString();
                    monto = double.Parse(oTabla.Rows[0].ItemArray[1].ToString());
                }
                txtGuiaPago.Text = guia;
                txtMontoGuia.Text = simMoneda + " " + monto.ToString("###,###,##0.00");
            }
            catch (Exception ex)
            {

            }
        }

        private void CrearGuia()
        {
            try
            {

                string guia = "";
                double monto = 0;
                DataTable oTabla = new DataTable();
                string moneda = "";
                BuscarGuia();
                oGuiaPrepagoProveedorDAO = new GuiaPrepagoProveedorDAO();
                if (rbtnCol.Checked)
                    moneda = "CRC";
                else if (rbtnUsd.Checked)
                    moneda = "USD";

                if (txtGuiaPago.Text.Trim().Equals(""))
                {
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    oGuiaPrepagoProveedor = new GuiaPrepagoProveedor();

                    oGuiaPrepagoProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oGuiaPrepagoProveedor.Proveedor = txtCodProveedor.Text;
                    oGuiaPrepagoProveedor.Moneda = moneda;

                    oGuiaPrepagoProveedorDAO.Agregar(oGuiaPrepagoProveedor);
                    if (oGuiaPrepagoProveedorDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al crear el nuevo Prepago Proveedor: " + oGuiaPrepagoProveedorDAO.DescError(), "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guia = oGuiaPrepagoProveedorDAO.ConsultarExistente(moneda, txtCodProveedor.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString();
                    monto = double.Parse(oGuiaPrepagoProveedorDAO.ConsultarExistente(moneda, txtCodProveedor.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[1].ToString());
                    txtGuiaPago.Text = guia;
                    txtMontoGuia.Text = simMoneda + " " + monto.ToString("###,###,##0.00");
                    oConexion.cerrarConexion();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void AgregarDetalle(string factura, double monto, double saldo, double abono, int indice)
        {
            try
            {
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                oDetalleDAO = new DetallePrepagoDAO();
                oGuiaPrepagoProveedorDAO = new GuiaPrepagoProveedorDAO();
                oGuiaPrepagoProveedor = new GuiaPrepagoProveedor();
                oDetalle = new DetallePrepago();

                oDetalle.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oDetalle.Prepago = int.Parse(txtGuiaPago.Text);
                oDetalle.CodProveedor = int.Parse(txtCodProveedor.Text);
                oDetalle.NumFactura = factura;
                oDetalle.Monto = monto;
                oDetalle.Abono = abono;
                oDetalle.Saldo = saldo;
                oDetalle.Indice = indice;
                oDetalleDAO.Agregar(oDetalle);

                oGuiaPrepagoProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oGuiaPrepagoProveedor.Id = Double.Parse(txtGuiaPago.Text);
                oGuiaPrepagoProveedor.Monto = (double.Parse(txtMontoGuia.Text.Trim().Substring(1)) + abono);

                oGuiaPrepagoProveedorDAO.Modificar(oGuiaPrepagoProveedor);
                if (oDetalleDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al crear el nuevo Prepago Proveedor: " + oDetalleDAO.DescError(), "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void QuitarDetalle(Double indice, double abono)
        {
            try
            {
                oDetalleDAO = new DetallePrepagoDAO();
                oDetalleDAO.Quitar(indice, PROYECTO.Properties.Settings.Default.No_cia);
                oGuiaPrepagoProveedorDAO = new GuiaPrepagoProveedorDAO();
                oGuiaPrepagoProveedor = new GuiaPrepagoProveedor();

                oGuiaPrepagoProveedor.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oGuiaPrepagoProveedor.Id = Double.Parse(txtGuiaPago.Text);
                oGuiaPrepagoProveedor.Monto = (double.Parse(txtMontoGuia.Text.Trim().Substring(1)) - abono);
                // oGuiaPrepagoProveedor.Monto = abono;

                oGuiaPrepagoProveedorDAO.Modificar(oGuiaPrepagoProveedor);
                if (oDetalleDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al crear el nuevo Prepago Proveedor: " + oDetalleDAO.DescError(), "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos2.Rows.Count > 0)
                {

                    oConexion.cerrarConexion();
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    if (oConexion.abrirConexion())
                    {
                        double abonos = 0;
                        double saldoFactura = 0;


                        foreach (DataGridViewRow oFila in dgrDatos2.Rows)
                        {
                            if (oFila.Selected)
                            {
                                for (int x = 0; x < dgrDatos.Rows.Count; x++)
                                {
                                    if (dgrDatos["facpag_num_factura", x].Value.ToString().Equals(oFila.Cells["DETPRE_FACTURA"].Value.ToString()))
                                        saldoFactura = double.Parse(dgrDatos["saldo_actual", x].Value.ToString());
                                }

                                for (int x = 0; x < dgrDatos2.Rows.Count; x++)
                                {
                                    if (dgrDatos2["DETPRE_FACTURA", x].Value.ToString().Equals(oFila.Cells["DETPRE_FACTURA"].Value.ToString()))
                                        abonos += double.Parse(dgrDatos2["DETPRE_Abono", x].Value.ToString());
                                }
                                oFacturasPago = new FacturasPago();
                                oFacturaDAO = new FacturasPagosDAO();

                                oFacturasPago.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                                oFacturaDAO.Vincular(oFila.Cells["DETPRE_INDICE"].Value.ToString(), oFila.Cells["DETPRE_FACTURA"].Value.ToString(), 0, PROYECTO.Properties.Settings.Default.No_cia);

                                oFacturasPago.Indice = int.Parse(oFila.Cells["DETPRE_INDICE"].Value.ToString());
                                oFacturasPago.NumFactura = oFila.Cells["DETPRE_FACTURA"].Value.ToString();
                                oFacturasPago.Saldo = abonos + saldoFactura;

                                oFacturaDAO.Modificar(oFacturasPago);
                                QuitarDetalle(Double.Parse(oFila.Cells["DETPRE_INDICE"].Value.ToString()), abonos);
                                CrearGuia();
                            }
                        }
                        oConexion.cerrarConexion();

                        llenaGrid();
                        llenaGrid2();
                    }
                }

            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }


        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos2.Rows.Count > 0)
                {
                    string mon = "";
                    string facturas = "";
                    DataTable oTabla = new DataTable();
                    DataRow oRow = null;
                    oTabla.Columns.Add("Factura");
                    oTabla.Columns.Add("Saldo");
                    if (rbtnCol.Checked)
                        mon = "CRC";
                    else if (rbtnUsd.Checked)
                        mon = "USD";

                    for (int x = 0; x < dgrDatos2.Rows.Count; x++)
                    {
                        oRow = oTabla.NewRow();
                        oRow["Factura"] = dgrDatos2["DETPRE_FACTURA", x].Value.ToString();
                        oRow["Saldo"] = dgrDatos2["saldoactual", x].Value.ToString();
                        oTabla.Rows.Add(oRow.ItemArray);
                        facturas += dgrDatos2["DETPRE_FACTURA", x].Value.ToString();
                        if (x != dgrDatos2.Rows.Count - 1)
                            facturas += " - ";
                    }

                    frmPagosProveedores oPagos = frmPagosProveedores.getInstance(txtProveedor.Text, txtCodProveedor.Text, txtGuiaPago.Text, mon, (Double.Parse(txtMontoGuia.Text.Trim().Substring(1))), facturas, oTabla);
                    oPagos.MdiParent = this.MdiParent;
                    oPagos.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos2.Rows.Count == 0)
                {
                    MessageBox.Show("No ha facturas disponibles para imprimir el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                progressBar1.Visible = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            numero++;
            if (numero == 1)
            {
                timer1.Stop();
                ejecutar();
                numero = 0;
            }
        }

        private void ejecutar()
        {
            try
            {

                if (dgrDatos2.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos que mostrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string moned = "";
                if (rbtnCol.Checked)
                    moned = "CRC";
                else if (rbtnUsd.Checked)
                    moned = "USD";

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oDetalleDAO = new DetallePrepagoDAO();
                    DataTable oTable = oDetalleDAO.Busqueda_Consulta(txtCodProveedor.Text, Double.Parse(txtGuiaPago.Text), moned, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oTable.Rows.Count > 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptPrepagoProveedor oReporte = new rptPrepagoProveedor();
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

        private void dgrDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void frmPrepagoProveedor_KeyDown(object sender, KeyEventArgs e)
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


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgrDatos.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay facturas disponibles para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dgrDatos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione la factura a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (saldo < monto)
                    {
                        MessageBox.Show("No se puede Eliminar, ya tiene pagos aplicados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    if (oConexion.abrirConexion())
                    {
                        oFacturaDAO = new FacturasPagosDAO();
                        oFacturasPago = new FacturasPago();

                        oFacturasPago.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFacturasPago.Indice = int.Parse(dgrDatos.SelectedCells[2].Value.ToString());
                        oFacturasPago.NumFactura = dgrDatos.SelectedCells[0].Value.ToString();

                        oFacturaDAO.Eliminar(oFacturasPago);
                        if (oFacturaDAO.Error())
                            MessageBox.Show("Ocurrió un error al eliminar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Factura eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        llenaGrid();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtAbono_TextChanged(object sender, EventArgs e)
        {
            if (Double.Parse(txtAbono.Text.Substring(1)) != 0)
                bnAgregar.Enabled = true;
            else
                bnAgregar.Enabled = false;
        }

        private void btnCancelarPagos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                frmRollbackPagoProveedor oPanta = new frmRollbackPagoProveedor(txtCodProveedor.Text, txtProveedor.Text);
                oPanta.MdiParent = this.MdiParent;
                oPanta.Show();
            }
            catch { }
        }

    }
}