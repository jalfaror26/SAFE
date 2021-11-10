using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using ENTIDADES;

namespace PROYECTO
{
    public partial class frmrptFactsRecibidasCategoria : Form
    {
        private static frmrptFactsRecibidasCategoria instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
        private ReportesDAO oReportesDAO = null;
        private int numero = 0;
        private String codigo = "rpt_FactsRecibidasCategoria", descripcion = "Reporte de facturas recibidas por periodo.", modulo = "Reportes_Pagos";

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

        public frmrptFactsRecibidasCategoria()
        {
            InitializeComponent();
        }

        public static frmrptFactsRecibidasCategoria getInstance()
        {
            if (instance == null)
                instance = new frmrptFactsRecibidasCategoria();
            return instance;
        }

        private void frmrptReportePagosRealizadosCategoria_Load(object sender, EventArgs e)
        {
            cmbMoneda.SelectedIndex = 0;
            cargaTiposdecambio();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaFinal.Text.Equals("") || txtFechaInicio.Text.Equals(""))
                {
                    MessageBox.Show("Seleccione un rango de fechas para el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private DataTable crearTabla(DataTable oTabla, DataTable oTabla2)
        {
            try
            {
                DataTable oDataTable = new DataTable();
                DataRow oDataRow = null;
                String sql = "";
                DataTable oDatos = new DataTable();
                Double montoCCSS = 0;
                ArrayList oArreglo = new ArrayList();
                int numveces = 0;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    double monto = 0;
                    oDataTable.Columns.Add("gasto", typeof(string));
                    oDataTable.Columns.Add("monto", typeof(double));

                    foreach (DataRow oFila in oTabla.Rows)
                    {
                        monto = 0;
                        foreach (DataRow oFila2 in oTabla2.Rows)
                        {
                            if (oFila.ItemArray[0].ToString().Equals(oFila2.ItemArray[0].ToString()))
                            {
                                if (double.Parse(oFila2.ItemArray[1].ToString()) != 0)
                                {
                                    if (cmbMoneda.Text.Equals("CRC"))
                                    {
                                        if (oFila2.ItemArray[2].ToString().Equals("CRC"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());

                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                                numveces++;
                                                if (numveces == numVecesCCSS(oTabla2))
                                                    monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));

                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                        }
                                        else if (oFila2.ItemArray[2].ToString().Equals("USD"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()));
                                                numveces++;
                                                if (numveces == numVecesCCSS(oTabla2))
                                                    monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));

                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// * Double.Parse(oFila2.ItemArray[3].ToString());
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString());
                                        }
                                        else if (oFila2.ItemArray[2].ToString().Equals("EUR"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()));
                                                numveces++;
                                                if (numveces == numVecesCCSS(oTabla2))
                                                    monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));

                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// * Double.Parse(oFila2.ItemArray[3].ToString());
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (oFila2.ItemArray[2].ToString().Equals("CRC"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else
                                                            if (i == 2)
                                                                montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                            else
                                                                if (i == 3)
                                                                    montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                    monto += (Double.Parse(oFila2.ItemArray[1].ToString()) / Double.Parse(oFila2.ItemArray[3].ToString()));
                                                    numveces++;
                                                    if (numveces == numVecesCCSS(oTabla2))
                                                        monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                                
                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// / Double.Parse(oFila2.ItemArray[3].ToString());
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString()) / Double.Parse(oFila2.ItemArray[3].ToString());
                                        }
                                        else if (oFila2.ItemArray[2].ToString().Equals("USD"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                    monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                                    numveces++;
                                                    if (numveces == numVecesCCSS(oTabla2))
                                                        monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                                
                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                        }
                                        else if (oFila2.ItemArray[2].ToString().Equals("EUR"))
                                        {
                                            if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            {
                                                if (oArreglo.Count < 3)
                                                {
                                                    for (int i = 1; i < 4; i++)
                                                    {
                                                        if (i == 1)
                                                            montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                        else if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                        oArreglo.Add(montoCCSS);
                                                    }
                                                }
                                                    monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1)));
                                                    numveces++;
                                                    if (numveces == numVecesCCSS(oTabla2))
                                                        monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                                
                                            }
                                            else if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                            {
                                                sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                oConexion.cerrarConexion();
                                                oConexion.abrirConexion();
                                                oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                oConexion.cerrarConexion();
                                                if (oDatos.Rows.Count > 0)
                                                    monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// *Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1));
                                            }
                                            else
                                                monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1));
                                        }
                                    }
                                }
                                else
                                    monto = 0;
                            }
                        }
                        oDataRow = oDataTable.NewRow();
                        oDataRow["gasto"] = oFila.ItemArray[0].ToString();
                        oDataRow["monto"] = monto;
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

        private int numVecesCCSS(DataTable oTabla)
        {
            try
            {
                int numero = 0;
                foreach (DataRow oFila in oTabla.Rows)
                {
                    if (oFila.ItemArray[4].ToString().Equals("CCSS"))
                        numero++;
                }
                return numero;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void ejecutar()
        {
            try
            {
                String sql = "", sql2 = "";
                string titulo = "'Consulta comprendida desde " + txtFechaInicio.Text + " hasta " + txtFechaFinal.Text + ". Moneda: " + cmbMoneda.Text + "'";

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    sql = "select gas_nombre, facpag_monto, facpag_moneda, facpag_tipo_cambio, gas_Tipo, facpag_num_factura from TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_GASTOS f where f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and fpp.no_cia = f.no_cia and facpag_estado = 1 and facpag_flujo = 200 and facpag_estatus <> 'AN' and facpag_tipo_gasto = gas_codigo and trunc(facpag_fecha_emision) between to_date('" + txtFechaInicio.Text + "','DD/MM/YYYY') and to_date('" + txtFechaFinal.Text + "','DD/MM/YYYY') and (gas_Tipo = 'PLANILLAS' OR gas_Tipo = 'GASTOS' OR gas_Tipo = 'CCSS' OR gas_Tipo = 'NINGUNO') order by gas_nombre,facpag_num_factura";
                    sql2 = "select gas_nombre from TBL_GASTOS g where g.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and gas_estado = 1 AND (gas_Tipo = 'PLANILLAS' OR gas_Tipo = 'GASTOS' OR gas_Tipo = 'CCSS' OR gas_Tipo = 'NINGUNO')";
                    oReportesDAO = new ReportesDAO();
                    DataTable oTabla = null;
                    oTabla = crearTabla(oReportesDAO.EjecutaSentencia(sql2).Tables[0], oReportesDAO.EjecutaSentencia(sql).Tables[0]);
                    if (oTabla.Rows.Count != 0)
                    {
                        if (!chkXML.Checked)
                        {
                            frmVisorReportes oVisor = frmVisorReportes.getInstance();
                            oVisor.MdiParent = this.MdiParent;
                            rptFacsRecibidasCategoria oReporte = new rptFacsRecibidasCategoria();
                            oReporte.DataDefinition.FormulaFields["titulo"].Text = titulo;
                            oReporte.DataDefinition.FormulaFields["moneda"].Text = "'" + cmbMoneda.Text + "'";
                            oReporte.SetDataSource(oTabla);
                            oVisor.ReportSource(oReporte);
                            oVisor.Show();
                        }
                        else
                        {
                            DataSet oDataSet = new DataSet();
                            oDataSet.Tables.Add(oTabla);
                            rutaGuardar.Filter = "Ficheros XML (*.xml)|*.xml";
                            if (rutaGuardar.ShowDialog() == DialogResult.OK)
                            {
                                String ruta = rutaGuardar.FileName;
                                oDataSet.WriteXml(ruta);
                                MessageBox.Show("Archivo generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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

        private void frmrptReportePagosRealizadosCategoria_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cargaTiposdecambio()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    txtTipoCambioDolar.Text = Double.Parse(oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString()).ToString("¢ ###,###,##0.00");
                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtTipoCambioDolar_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTipoCambioDolar.Text = Double.Parse(txtTipoCambioDolar.Text.Substring(1)).ToString("########0.##");
            }
            catch (Exception ex)
            {

            }
        }

        private void txtTipoCambioDolar_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
                        DataTable oTabla = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                        Double monto = 0;
                        if (txtTipoCambioDolar.Focused)
                            monto = Double.Parse(txtTipoCambioDolar.Text);
                        else
                            monto = Double.Parse(txtTipoCambioDolar.Text.Substring(1));
                        if (cmbMoneda.Text.Equals("USD") || cmbMoneda.Text.Equals("CRC"))
                        {
                            if (monto < Double.Parse(oTabla.Rows[0].ItemArray[3].ToString()))
                            {
                                txtTipoCambioDolar.Text = Double.Parse(oTabla.Rows[0].ItemArray[0].ToString()).ToString("¢ ###,###,##0.00");
                                MessageBox.Show("El tipo de cambio no puede ser menor al minimo establecido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        oConexion.cerrarConexion();
                        txtTipoCambioDolar.Text = Double.Parse(txtTipoCambioDolar.Text).ToString("¢ ###,###,##0.00");
                    }
                }
                catch (Exception ex)
                {
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtTipoCambioDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;

                for (int i = 0; i < txtTipoCambioDolar.Text.Length; i++)
                {
                    if (txtTipoCambioDolar.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private String InputBox(string title, string promptText)
        {
            String value = "0";
            //    {
            //    value = "0";
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            //   Button buttonCancel = new Button();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            buttonOk.Text = "OK";
            //     buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            //     buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(9, 20, 372, 13);
            //  textBox.SetBounds(12, 36, 372, 20);
            textBox.SetBounds(45, 46, 65, 20);
            buttonOk.SetBounds(228, 45, 75, 23);
            //    buttonCancel.SetBounds(309, 45, 75, 23);
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Anchor = textBox.Anchor | AnchorStyles.Left;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //      buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            form.ClientSize = new Size(396, 80);
            //      form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, buttonOk.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            //  form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            Double valor = 0;
            try
            {
                valor = double.Parse(textBox.Text);
                value = valor.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se permiten montos!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                value = "NO";
            }
            //   } while (!value.Equals("NO"))
            //        value = value + "";

            return value;
        }

        private DataTable crearTabla2(DataTable oTabla2)
        {
            try
            {
                DataTable oDataTable = new DataTable();
                DataRow oDataRow = null;
                String sql = "";
                DataTable oDatos = new DataTable();
                Double montoCCSS = 0;
                ArrayList oArreglo = new ArrayList();
                int numveces = 0;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    double monto = 0;
                    oDataTable.Columns.Add("Factura", typeof(string));
                    oDataTable.Columns.Add("Moneda", typeof(string));
                    oDataTable.Columns.Add("T/C", typeof(double));
                    oDataTable.Columns.Add("Fecha", typeof(string));
                    oDataTable.Columns.Add("TipoGasto", typeof(string));
                    oDataTable.Columns.Add("Gasto", typeof(string));
                    oDataTable.Columns.Add("Monto", typeof(double));
                    oDataTable.Columns.Add("Fecha_Emision", typeof(string));
                    oDataTable.Columns.Add("Fecha_Vencimiento", typeof(string));
                    oDataTable.Columns.Add("Fecha_Registro", typeof(string));
                    foreach (DataRow oFila2 in oTabla2.Rows)
                    {
                        monto = 0;
                        if (cmbMoneda.Text.Equals("CRC"))
                        {
                            if (oFila2.ItemArray[2].ToString().Equals("CRC"))
                            {
                                if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                {
                                    if (oArreglo.Count < 3)
                                    {
                                        for (int i = 1; i < 4; i++)
                                        {
                                            if (i == 1)
                                                montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                            else
                                                if (i == 2)
                                                    montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                else
                                                    if (i == 3)
                                                        montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                            oArreglo.Add(montoCCSS);
                                        }
                                        monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                        numveces++;
                                        if (numveces == numVecesCCSS(oTabla2))
                                            monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                    }
                                }
                                else
                                    if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                    {
                                        sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                        oConexion.cerrarConexion();
                                        oConexion.abrirConexion();
                                        oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                        oConexion.cerrarConexion();
                                        if (oDatos.Rows.Count > 0)
                                            monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());
                                    }
                                    else
                                        monto += Double.Parse(oFila2.ItemArray[1].ToString());
                            }
                            else
                                if (oFila2.ItemArray[2].ToString().Equals("USD"))
                                {
                                    if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                    {
                                        if (oArreglo.Count < 3)
                                        {
                                            for (int i = 1; i < 4; i++)
                                            {
                                                if (i == 1)
                                                    montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                else
                                                    if (i == 2)
                                                        montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                    else
                                                        if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                oArreglo.Add(montoCCSS);
                                            }
                                            monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()));
                                            numveces++;
                                            if (numveces == numVecesCCSS(oTabla2))
                                                monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                        }
                                    }
                                    else
                                        if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                        {
                                            sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                            oConexion.cerrarConexion();
                                            oConexion.abrirConexion();
                                            oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                            oConexion.cerrarConexion();
                                            if (oDatos.Rows.Count > 0)
                                                monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// *Double.Parse(oFila2.ItemArray[3].ToString());
                                        }
                                        else
                                            monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString());
                                }
                                else
                                    if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                    {
                                        if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                            if (oArreglo.Count < 3)
                                            {
                                                for (int i = 1; i < 4; i++)
                                                {
                                                    if (i == 1)
                                                        montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                    else
                                                        if (i == 2)
                                                            montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                        else
                                                            if (i == 3)
                                                                montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                    oArreglo.Add(montoCCSS);
                                                }
                                                monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()));
                                                numveces++;
                                                if (numveces == numVecesCCSS(oTabla2))
                                                    monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()));
                                            }
                                            else
                                                if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                                {
                                                    sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                                    oConexion.cerrarConexion();
                                                    oConexion.abrirConexion();
                                                    oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                                    oConexion.cerrarConexion();
                                                    if (oDatos.Rows.Count > 0)
                                                        monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// *Double.Parse(oFila2.ItemArray[3].ToString());
                                                }
                                                else
                                                    monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString());
                                    }
                        }
                        else
                        {
                            if (oFila2.ItemArray[2].ToString().Equals("CRC"))
                            {
                                if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                {
                                    if (oArreglo.Count < 3)
                                    {
                                        for (int i = 1; i < 4; i++)
                                        {
                                            if (i == 1)
                                                montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                            else
                                                if (i == 2)
                                                    montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                else
                                                    if (i == 3)
                                                        montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                            oArreglo.Add(montoCCSS);
                                        }
                                        monto += (Double.Parse(oFila2.ItemArray[1].ToString()) / Double.Parse(oFila2.ItemArray[3].ToString()));
                                        numveces++;
                                        if (numveces == numVecesCCSS(oTabla2))
                                            monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                    }
                                }

                                else
                                    if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                    {
                                        sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                        oConexion.cerrarConexion();
                                        oConexion.abrirConexion();
                                        oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                        oConexion.cerrarConexion();
                                        if (oDatos.Rows.Count > 0)
                                            monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// / Double.Parse(oFila2.ItemArray[3].ToString());
                                    }
                                    else
                                        monto += Double.Parse(oFila2.ItemArray[1].ToString()) / Double.Parse(oFila2.ItemArray[3].ToString());
                            }
                            else
                                if (oFila2.ItemArray[2].ToString().Equals("USD"))
                                {
                                    if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                    {
                                        if (oArreglo.Count < 3)
                                        {
                                            for (int i = 1; i < 4; i++)
                                            {
                                                if (i == 1)
                                                    montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                else
                                                    if (i == 2)
                                                        montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                    else
                                                        if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                oArreglo.Add(montoCCSS);
                                            }
                                            monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                            numveces++;
                                            if (numveces == numVecesCCSS(oTabla2))
                                                monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                        }
                                    }

                                    else
                                        if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                        {
                                            sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                            oConexion.cerrarConexion();
                                            oConexion.abrirConexion();
                                            oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                            oConexion.cerrarConexion();
                                            if (oDatos.Rows.Count > 0)
                                                monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());
                                        }
                                        else
                                            monto += Double.Parse(oFila2.ItemArray[1].ToString());
                                }
                                else
                                {
                                    if (oFila2.ItemArray[4].ToString().Equals("CCSS"))
                                    {
                                        if (oArreglo.Count < 3)
                                        {
                                            for (int i = 1; i < 4; i++)
                                            {
                                                if (i == 1)
                                                    montoCCSS = Double.Parse(InputBox("Monto IVMO", "Ingrese el monto IVMO").ToString());
                                                else
                                                    if (i == 2)
                                                        montoCCSS = Double.Parse(InputBox("Monto BPOO", "Ingrese el monto BPOO").ToString());
                                                    else
                                                        if (i == 3)
                                                            montoCCSS = Double.Parse(InputBox("Monto SEMO", "Ingrese el monto SEMO").ToString());
                                                oArreglo.Add(montoCCSS);
                                            }
                                            monto += (Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1)));
                                            numveces++;
                                            if (numveces == numVecesCCSS(oTabla2))
                                                monto -= (Double.Parse(oArreglo[0].ToString()) + Double.Parse(oArreglo[1].ToString()) + Double.Parse(oArreglo[2].ToString()));
                                        }
                                    }
                                    else
                                        if (oFila2.ItemArray[4].ToString().Equals("PLANILLAS"))
                                        {
                                            sql = "select (pla_total_hdobles + pla_total_hextras + pla_total_hordinarias+pla_comision+pla_atencion) - (pla_rebajo_acciones + pla_total_incapacidad) from tbl_planillas where pla_indice = '" + oFila2.ItemArray[5].ToString() + "'";
                                            oConexion.cerrarConexion();
                                            oConexion.abrirConexion();
                                            oDatos = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                                            oConexion.cerrarConexion();
                                            if (oDatos.Rows.Count > 0)
                                                monto += Double.Parse(oDatos.Rows[0].ItemArray[0].ToString());// *Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1));
                                        }
                                        else
                                            monto += Double.Parse(oFila2.ItemArray[1].ToString()) * Double.Parse(oFila2.ItemArray[3].ToString()) / Double.Parse(txtTipoCambioDolar.Text.Substring(1));
                                }
                        }
                        oDataRow = oDataTable.NewRow();
                        oDataRow["Factura"] = oFila2.ItemArray[5].ToString();
                        oDataRow["Moneda"] = oFila2.ItemArray[2].ToString();
                        oDataRow["T/C"] = Double.Parse(oFila2.ItemArray[3].ToString());
                        oDataRow["Fecha"] = oFila2.ItemArray[6].ToString();
                        oDataRow["TipoGasto"] = oFila2.ItemArray[4].ToString();
                        oDataRow["Gasto"] = oFila2.ItemArray[0].ToString();
                        oDataRow["Monto"] = monto;
                        oDataRow["Fecha_Emision"] = oFila2.ItemArray[7].ToString();
                        oDataRow["Fecha_Vencimiento"] = oFila2.ItemArray[8].ToString();
                        oDataRow["Fecha_Registro"] = oFila2.ItemArray[9].ToString();
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

        private void btnVerInfo_Click(object sender, EventArgs e)
        {
            if (txtFechaFinal.Text.Equals("") || txtFechaInicio.Text.Equals(""))
            {
                MessageBox.Show("Seleccione un rango de fechas para el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gbTipoInfo.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                gbTipoInfo.Visible = false;
                String sql = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oReportesDAO = new ReportesDAO();
                    DataTable oTabla = null;
                    if (rbSinded.Checked)
                    {
                        sql = "select FACPAG_NUM_FACTURA Factura, facpag_moneda Moneda, to_char(facpag_tipo_cambio,'999,999,999.99') \"T/C\", to_char(FACPAG_FECHA_EMISION,'dd/MM/yyyy') Fecha, gas_Tipo TipoGasto, gas_nombre Gasto, to_char(facpag_monto,'999,999,999.99') Monto, FACPAG_FECHA_EMISION Fecha_Emision, FACPAG_FECHA_VENCE Fecha_Vencimiento, FACPAG_FECHACREA fecha_Registro from TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_GASTOS g where g.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and fpp.no_cia = g.no_cia and facpag_estado = 1 and facpag_flujo = 200 and facpag_tipo_gasto = gas_codigo and to_date(to_char(facpag_fecha_emision,'dd/MM/yyyy'),'dd/MM/yyyy') between '" + DateTime.Parse(txtFechaInicio.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtFechaFinal.Text).ToShortDateString() + "' and (gas_Tipo = 'PLANILLAS' OR gas_Tipo = 'GASTOS' OR gas_Tipo = 'CCSS') order by gas_nombre";
                        oTabla = oReportesDAO.EjecutaSentencia(sql).Tables[0];
                    }
                    else
                    {
                        sql = "select gas_nombre, facpag_monto, facpag_moneda, facpag_tipo_cambio, gas_Tipo, FACPAG_NUM_FACTURA,to_char(FACPAG_FECHA_EMISION,'dd/MM/yyyy'), FACPAG_FECHA_EMISION Fecha_Emision, FACPAG_FECHA_VENCE Fecha_Vencimiento, FACPAG_FECHACREA fecha_Registro from TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_GASTOS g where g.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and fpp.no_cia = g.no_cia and facpag_estado = 1 and facpag_flujo = 200 and facpag_tipo_gasto = gas_codigo and to_date(to_char(facpag_fecha_emision,'dd/MM/yyyy'),'dd/MM/yyyy') between '" + DateTime.Parse(txtFechaInicio.Text).ToShortDateString() + "' and '" + DateTime.Parse(txtFechaFinal.Text).ToShortDateString() + "' and (gas_Tipo = 'PLANILLAS' OR gas_Tipo = 'GASTOS' OR gas_Tipo = 'CCSS') order by gas_nombre";
                        oTabla = crearTabla2(oReportesDAO.EjecutaSentencia(sql).Tables[0]);
                    }
                    if (oTabla.Rows.Count > 0)
                    {
                        DataSet oDataSet = new DataSet();
                        if (rbSinded.Checked)
                            oDataSet = oTabla.DataSet;
                        else
                            oDataSet.Tables.Add(oTabla);
                        rutaGuardar.Filter = "Ficheros XML (*.xml)|*.xml";
                        if (rutaGuardar.ShowDialog() == DialogResult.OK)
                        {
                            String ruta = rutaGuardar.FileName;
                            oDataSet.WriteXml(ruta);
                            MessageBox.Show("Archivo generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbTipoInfo.Visible = false;
        }
    }
}