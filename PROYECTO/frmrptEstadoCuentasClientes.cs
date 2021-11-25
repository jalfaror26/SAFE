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
    public partial class frmrptEstadoCuentasClientes : Form
    {
        private static frmrptEstadoCuentasClientes ofrmSaldofacturas = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ReportesDAO oReporteDAO = null;
        private int numero = 0;
        private String codigo = "rpt_saldoFacturas", descripcion = "Reporte de saldos de facturas por cliente.", modulo = "Reportes Facturción";

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


        public frmrptEstadoCuentasClientes()
        {
            InitializeComponent();
        }

        public static frmrptEstadoCuentasClientes getInstance()
        {
            if (ofrmSaldofacturas == null)
                ofrmSaldofacturas = new frmrptEstadoCuentasClientes();
            return ofrmSaldofacturas;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmrptSaldosFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmSaldofacturas = null;
        }

        private void ejecutar()
        {
            try
            {
                String sql = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    Boolean mostrar = true;
                    sql = "select facp_numero_factura, CLI_IDENTIFICACION facp_cliente, facp_nombre, facp_moneda, to_char(facp_fecha_factura,'dd/MM/yyyy') as facp_fecha_factura, to_char(facp_fecha_vence,'dd/MM/yyyy') as facp_fecha_vence, facp_monto, facp_saldo, facp_anombrede,'' dias, sysdate, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario from TBL_FACTURAS_PENDIENTES_CTA FPC, TBL_EMPRESA e, TBL_CLIENTES c where CLI_LINEA = FACP_CLIENTE and fpc.no_cia = c.no_cia and fpc.no_cia = e.no_cia and fpc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and facp_estado = 1 ";
                    if (!txtIdCliente.Text.Equals(""))
                    {
                        sql += "and facp_cliente = '" + txtIdCliente.Text + "' ";
                        mostrar = false;
                    }
                    sql += "and facp_estatus in ('PE','FT') ";
                    sql += " order by facp_nombre ";
                    oReporteDAO = new ReportesDAO();

                    DataTable oTable = oReporteDAO.ConsultaSaldosFacturasPendientes(sql).Tables[0];

                    if (chkDias.Checked)
                    {
                        if (oTable.Rows.Count > 0)
                        {
                            for (int x = 0; x < oTable.Rows.Count; x++)
                            {
                                int dias = 0;
                                TimeSpan oT1 = DateTime.Parse(oTable.Rows[x].ItemArray[10].ToString()) - DateTime.Parse(oTable.Rows[x].ItemArray[5].ToString());
                                dias = oT1.Days;
                                if (dias < 0)
                                    oTable.Rows[x]["dias"] = "SIN VENCER";
                                else if (dias <= 30)
                                    oTable.Rows[x]["dias"] = "1 - 30 Días";
                                else if (dias <= 60)
                                    oTable.Rows[x]["dias"] = "31 - 60 Días";
                                else if (dias <= 90)
                                    oTable.Rows[x]["dias"] = "61 - 90 Días";
                                else if (dias > 90)
                                    oTable.Rows[x]["dias"] = "Más de 90 Días";
                            }

                            ReportDocument oReporte = new rptSaldosFacturasDias();
                            frmVisorReportes oVisor = frmVisorReportes.getInstance();
                            oVisor.MdiParent = this.MdiParent;

                            oReporte.DataDefinition.FormulaFields["tipoReporte"].Text = rboDetallado.Checked ? "'D'" : "'R'";
                            oReporte.DataDefinition.FormulaFields["conCliente"].Text = "'S'";

                            if (rboResumido.Checked && !chkClientes.Checked)
                                oReporte.DataDefinition.FormulaFields["conCliente"].Text = "'N'";

                            oReporte.DataDefinition.FormulaFields["titulo"].Text = "'SALDOS DE FACTURAS POR CLIENTE'";
                            oReporte.DataDefinition.FormulaFields["mostrarPorc"].Text = "'" + mostrar.ToString().ToUpper() + "'";
                            oReporte.SetDataSource(oTable);
                            oVisor.ReportSource(oReporte);
                            oVisor.Show();
                        }
                        else
                            MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                    }
                    else
                    {
                        if (oTable.Rows.Count > 0)
                        {
                            ReportDocument oReporte = new rptSaldosFacturasSinDias();
                            frmVisorReportes oVisor = frmVisorReportes.getInstance();
                            oVisor.MdiParent = this.MdiParent;

                            oReporte.DataDefinition.FormulaFields["tipoReporte"].Text = rboDetallado.Checked ? "'D'" : "'R'";
                            oReporte.DataDefinition.FormulaFields["conCliente"].Text = "'S'";

                            if (rboResumido.Checked && !chkClientes.Checked)
                                oReporte.DataDefinition.FormulaFields["conCliente"].Text = "'N'";

                            oReporte.DataDefinition.FormulaFields["titulo"].Text = "'SALDOS DE FACTURAS POR CLIENTE'";
                            oReporte.DataDefinition.FormulaFields["mostrarPorc"].Text = "'" + mostrar.ToString().ToUpper() + "'";
                            oReporte.SetDataSource(oTable);
                            oVisor.ReportSource(oReporte);
                            oVisor.Show();
                        }
                        else
                            MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                    }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                timer1.Stop();
                ejecutar();
            }
        }

        private void rboDetallado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDias.Checked)
            {
                chkClientes.Visible = false;
                chkDias.Enabled = true;
            }
        }

        private void rboResumido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDias.Checked)
                chkClientes.Visible = true;

        }

        private void chkDias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDias.Checked && rboResumido.Checked)
                chkClientes.Visible = true;
        }

        private void btnBusq2_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("ClienteReporteRecibos");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        public void cargaCliente(String cod, String nombre)
        {
            txtIdCliente.Text = cod;
            txtNombre.Text = nombre;
        }

        private void btnECliente_Click(object sender, EventArgs e)
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
        }

        private void chkClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClientes.Checked)
                chkDias.Enabled = true;
            else
                chkDias.Enabled = false;
        }
    }
}