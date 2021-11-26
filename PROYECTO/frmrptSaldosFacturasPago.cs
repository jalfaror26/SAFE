using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using CrystalDecisions.CrystalReports.Engine;
using ENTIDADES;

namespace PROYECTO
{
    public partial class frmrptSaldosFacturasPago : Form
    {
        private static frmrptSaldosFacturasPago ofrmSaldofacturaspago = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ReportesDAO oReporteDAO = null;
        private int numero = 0;
        private String codigo = "rpt_saldoFacturasPago", descripcion = "Reporte de saldos de facturas por proveedor.", modulo = "Reportes_Finacieros";

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


        public frmrptSaldosFacturasPago()
        {
            InitializeComponent();
        }

        public static frmrptSaldosFacturasPago getInstance()
        {
            if (ofrmSaldofacturaspago == null)
                ofrmSaldofacturaspago = new frmrptSaldosFacturasPago();
            return ofrmSaldofacturaspago;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmrptSaldosFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmSaldofacturaspago = null;
        }


        private void ejecutar()
        {
            try
            {
                String sql = "";
                ReportDocument oReporte = new rptSaldosFacturasPago();
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    sql = "select facpag_num_factura, PROV_ID, prov_nombre, facpag_moneda, to_char(facpag_fecha_emision,'dd/MM/yyyy') as facpag_fecha_emision, to_char(facpag_fecha_vence,'dd/MM/yyyy') as facpag_fecha_vence, facpag_monto, facpag_saldo, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario";

                    if (chkVerCategoria.Checked)
                        sql += ", gas_nombre gasto";
                    else
                    {
                        if (rbTodo.Checked)
                            sql += ", prov_nombre gasto";
                        else if (rbCompras.Checked)
                            sql += ", 'Compras' gasto";
                    }

                    sql += " from TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_PROVEEDOR p, TBL_EMPRESA e ";

                    if (chkVerCategoria.Checked)
                        sql += ", TBL_GASTOS g";

                    sql += " where p.no_cia = e.no_cia and p.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and p.no_cia = fpp.no_Cia and facpag_proveedor = prov_linea and facpag_estado = 1 and FACPAG_ESTATUS in ('FP','FT') AND ((facpag_saldo >1 and facpag_moneda='CRC') or (facpag_saldo>0 and facpag_moneda<>'CRC')) ";

                    if (rbCompras.Checked)
                        sql += " and facpag_flujo = 201 ";
                    else
                    {
                        if (chkVerCategoria.Checked)
                            sql += " and p.no_cia = g.no_Cia and facpag_flujo = 200 and facpag_tipo_gasto = gas_codigo ";

                        if (chkCategoria.Checked)
                            sql += "and FACPAG_TIPO_GASTO = '" + txtIdGasto.Text + "'";
                    }


                    //if (rbCategoria.Checked)
                    //{
                    //    if (rbResumido.Checked)
                    //        oReporte = new rptSaldosFacturasPagoResumidoCat();
                    //    else if (rbDetallado.Checked)
                    //        oReporte = new rptSaldosFacturasPagoDetalladoCat();
                    //}
                    //else if (rbCompras.Checked)
                    //{
                    //  
                    //    if (rbResumido.Checked)
                    //        oReporte = new rptSaldosFacturasPagoResumido();
                    //    else if (rbDetallado.Checked)
                    //        oReporte = new rptSaldosFacturasPagoDetallado();
                    //}

                    oReporteDAO = new ReportesDAO();
                    DataTable oTable = oReporteDAO.ConsultaSaldosFacturasPendientes(sql).Tables[0];
                    if (oTable.Rows.Count > 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        oReporte.DataDefinition.FormulaFields["tipoReporte"].Text = rbDetallado.Checked ? "'D'" : "'R'";
                        oReporte.SetDataSource(oTable);
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
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }


        private void frmrptSaldosFacturas_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                timer1.Stop();
                ejecutar();
            }
        }

        public void llenargasto(String cod, String des)
        {
            txtIdGasto.Text = cod;
            txtGasto.Text = des;
        }

        private void btnBusqGasto_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("GastosSaldosPagos");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        private void rbTodo_Click(object sender, EventArgs e)
        {
            //rbResumido.Enabled = false;
            //rbDetallado.Enabled = false;
            //chkCategoria.Enabled = false;
            //txtGasto.Text = "";
            //txtIdGasto.Text = "";
        }

        private void rbCategoria_Click(object sender, EventArgs e)
        {
            rbResumido.Enabled = true;
            rbDetallado.Enabled = true;
            chkCategoria.Enabled = true;
        }

        private void rbCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCompras.Checked)
            {
                chkCategoria.Checked = false;
                chkVerCategoria.Checked = false;
                chkVerCategoria.Enabled = false;
                chkCategoria.Enabled = false;
                txtIdGasto.Clear();
                txtGasto.Clear();
            }
            else
            {
                chkVerCategoria.Enabled = true;
                chkCategoria.Enabled = true;
            }
        }

        private void rbCompras_Click(object sender, EventArgs e)
        {
            rbResumido.Enabled = true;
            rbDetallado.Enabled = true;
            chkCategoria.Enabled = false;
            txtGasto.Text = "";
            txtIdGasto.Text = "";
        }

        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            btnBusqGasto.Enabled = !btnBusqGasto.Enabled;

            if (chkCategoria.Checked)
            {
                chkVerCategoria.Checked = true;
                chkVerCategoria.Enabled = false;
                rbCompras.Enabled = false;
            }
            else
            {
                chkVerCategoria.Enabled = true;
                rbCompras.Enabled = true;
            }
        }
    }
}