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
    public partial class frmrptFacturasRecibidasPagadas : Form
    {
        private static frmrptFacturasRecibidasPagadas instance = null;
        private ConexionDAO oConexion = new ConexionDAO(Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
        private ReportesDAO oReportesDAO = null;
        private int numero = 0;
        private String codigo = "rpt_FacturasPagadasRecibidas", descripcion = "Reporte de Facturas canceladas y recibidas por periodo.", modulo = "Reportes CxP";

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

        public frmrptFacturasRecibidasPagadas()
        {
            InitializeComponent();
        }

        public static frmrptFacturasRecibidasPagadas getInstance()
        {
            if (instance == null)
                instance = new frmrptFacturasRecibidasPagadas();
            return instance;
        }

        private void frmrptFacturasRecibidasPagadas_Load(object sender, EventArgs e)
        {
            try
            {
                oConexion.abrirConexion();
                //lblfecha.Text = oConexion.fecha().ToShortDateString();
                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProv.Checked)
            {
                btnBusq2.Enabled = true;
            }
            else
            {
                btnBusq2.Enabled = false;
                txtIdProv.Clear();
                txtProv.Clear();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkProv.Checked && txtIdProv.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Seleccione el cliente a consultar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private double obtieneTipoCambio()
        {
            try
            {
                double dolar = 0;
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
                    DataSet TipoCambio = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia);
                    if (oTipoCambioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los tipos de cambio: " + oTipoCambioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        dolar = Double.Parse(TipoCambio.Tables[0].Rows[0]["cambio_dolar"].ToString());
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dolar;
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
                return 0;
            }
        }

        private DataTable creaTabla(DataTable oTabla)
        {
            try
            {
                DataTable oDataTable = new DataTable();
                DataRow oDataRow = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    double monto = 0;
                    string moneda = "";
                    string fechareg = "";
                    double dolar = obtieneTipoCambio();

                    oDataTable.Columns.Add("fechareg", typeof(string));
                    oDataTable.Columns.Add("factura", typeof(string));
                    oDataTable.Columns.Add("prov", typeof(string));
                    oDataTable.Columns.Add("nombreprov", typeof(string));
                    oDataTable.Columns.Add("estado", typeof(string));
                    oDataTable.Columns.Add("mes", typeof(string));
                    oDataTable.Columns.Add("anno", typeof(string));
                    oDataTable.Columns.Add("hoy", typeof(string));
                    oDataTable.Columns.Add("montodolares", typeof(double));
                    oDataTable.Columns.Add("montocolones", typeof(double));
                    oDataTable.Columns.Add("tcd", typeof(double));
                    oDataTable.Columns.Add("EMPR_NOMBRE", typeof(string));
                    oDataTable.Columns.Add("EMPR_LOGO", typeof(byte[]));
                    oDataTable.Columns.Add("EMPR_OTROS", typeof(string));
                    oDataTable.Columns.Add("usuario", typeof(string));

                    foreach (DataRow oFila in oTabla.Rows)
                    {
                        oDataRow = oDataTable.NewRow();
                        monto = double.Parse(oFila.ItemArray[2].ToString());

                        if (rbtnRecibidas.Checked)
                            dolar = double.Parse(oFila["tcd"].ToString());

                        moneda = oFila["moneda"].ToString();
                        fechareg = oFila.ItemArray[0].ToString();

                        oDataRow["fechareg"] = oFila.ItemArray[0].ToString();
                        oDataRow["factura"] = oFila.ItemArray[1].ToString();
                        oDataRow["prov"] = oFila.ItemArray[3].ToString();
                        oDataRow["nombreprov"] = oFila["PROV_NOMBRE"].ToString();
                        oDataRow["estado"] = oFila.ItemArray[5].ToString();
                        oDataRow["mes"] = oFila.ItemArray[6].ToString();
                        oDataRow["anno"] = oFila.ItemArray[7].ToString();
                        oDataRow["hoy"] = oFila.ItemArray[8].ToString();
                        if (moneda.Equals("CRC"))
                        {
                            oDataRow["montodolares"] = monto / dolar;
                            oDataRow["montocolones"] = monto;
                        }
                        else if (moneda.Equals("USD"))
                        {
                            oDataRow["montodolares"] = monto;
                            oDataRow["montocolones"] = monto * dolar;
                        }
                        oDataRow["tcd"] = dolar;

                        oDataRow["EMPR_NOMBRE"] = oFila["EMPR_NOMBRE"].ToString();
                        oDataRow["EMPR_LOGO"] = oFila["EMPR_LOGO"];
                        oDataRow["EMPR_OTROS"] = oFila["EMPR_OTROS"].ToString();
                        oDataRow["usuario"] = oFila["usuario"].ToString();

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

        private void ejecutar()
        {
            try
            {
                String sql = "";
                string titulo1 = "", titulo2 = "'Consulta comprendida desde " + txtFechaInicio.Text + " hasta " + txtFechaFinal.Text + "'";

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (rbtnRecibidas.Checked)
                    {
                        sql = "SELECT to_char(FACPAG_FECHA_EMISION,'DD/MM/YYYY'),FACPAG_NUM_FACTURA,FACPAG_MONTO, FACPAG_PROVEEDOR, (select PROV_NOMBRE from TBL_PROVEEDOR where no_cia= e.no_cia and PROV_LINEA = FACPAG_PROVEEDOR) PROV_NOMBRE, FACPAG_ESTATUS, to_char(FACPAG_FECHA_EMISION,'MM'), to_char(FACPAG_FECHA_EMISION,'YYYY'), to_char(sysdate,'DD/MM/YYYY'), facpag_moneda moneda, FACPAG_TIPO_CAMBIO tcd, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_EMPRESA e where fpp.no_cia = e.no_cia and fpp.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and facpag_estado=1 and trunc(FACPAG_FECHA_EMISION) between to_date('" + txtFechaInicio.Text + "','DD/MM/YYYY') and to_date('" + txtFechaFinal.Text + "','DD/MM/YYYY') ";
                        if (chkProv.Checked)
                            sql += " and FACPAG_proveedor='" + txtIdProv.Text + "'";
                        titulo1 = "'Facturas Recibidas'";
                        sql += " order by FACPAG_NUM_FACTURA";
                    }
                    else if (rbtnPagadas.Checked)
                    {
                        sql = "SELECT to_char(pre_fecha_registro,'DD/MM/YYYY') fechareg, detpre_factura factura, detpre_monto monto, detpre_proveedor prov, (select PROV_NOMBRE from TBL_PROVEEDOR where no_cia= e.no_cia and PROV_LINEA = detpre_proveedor) PROV_NOMBRE, PRE_ESTADO estado, to_char(pre_fecha_registro,'MM') mes, to_char(pre_fecha_registro,'YYYY') anno, to_char(sysdate,'DD/MM/YYYY') hoy, PRE_MONEDA moneda, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_PREPAGOS_PROVEEDORES PPP, TBL_DETALLE_PREPAGO DPP, TBL_EMPRESA e WHERE ppp.no_cia = e.no_cia and dpp.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and dpp.no_cia = ppp.no_cia and PRE_ESTADO='GC' and detpre_prepago=pre_id and trunc(PRE_FECHA_REGISTRO) between to_date('" + txtFechaInicio.Text + "','DD/MM/YYYY') and to_date('" + txtFechaFinal.Text + "','DD/MM/YYYY')";
                        titulo1 = "'Facturas Canceladas'";
                        if (chkProv.Checked)
                            sql += " and detpre_proveedor='" + txtIdProv.Text + "'";
                        sql += " order by PRE_ID, detpre_factura";
                    }


                    oReportesDAO = new ReportesDAO();
                    DataTable oTabla = creaTabla(oReportesDAO.EjecutaSentencia(sql).Tables[0]);
                    if (oTabla.Rows.Count != 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptFacturasCanceladasRecibidas oReporte = new rptFacturasCanceladasRecibidas();
                        oReporte.DataDefinition.FormulaFields["SUBTITULOFACTURAS"].Text = titulo1;
                        oReporte.DataDefinition.FormulaFields["PERIODO"].Text = titulo2;
                        oReporte.SetDataSource(oTabla);
                        oVisor.ReportSource(oReporte);
                        oVisor.Show();
                    }
                    else
                        MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Visible = false;
            }
            catch (Exception ex) { oConexion.cerrarConexion(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                timer1.Stop();
                ejecutar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusq2_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("ProveedorReporteFacturasPC");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        public void cargaProveedor(String cod, String nombre)
        {
            txtIdProv.Text = cod;
            txtProv.Text = nombre;
        }

        private void frmrptFacturasRecibidasPagadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = dtpFechaInicio.Value.ToShortDateString();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            txtFechaFinal.Text = dtpFechaFinal.Value.ToShortDateString();
        }


    }
}