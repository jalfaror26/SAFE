using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;

namespace PROYECTO
{
    public partial class frmMovimientosCajaChica : Form
    {
        private static frmMovimientosCajaChica instance = null;
        private ConexionDAO oConexion = null;
        private CajaChicaDetalleDAO CajaChicaDAO = null;
        private int timer = 0;
        private char simmoneda = ' ';
        private String codigo = "pro_movCajaChica", descripcion = "Registro de movimientos de caja chica.", modulo = "Procesos";

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


        public static frmMovimientosCajaChica getInstance()
        {
            if (instance == null)
                instance = new frmMovimientosCajaChica();
            return instance;
        }

        private frmMovimientosCajaChica()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMovimientosCajaChica_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void frmMovimientosCajaChica_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void llenarOtros()
        {
            try
            {
                //frmCajaChica oCaja = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    CajaChicaDAO = new CajaChicaDetalleDAO();
                    try
                    {
                        string moneda = " ";

                        try
                        {
                            moneda = CajaChicaDAO.Moneda(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                        if (moneda.Equals("CRC"))
                            simmoneda = '¢';
                        else if (moneda.Equals("USD"))
                            simmoneda = '$';

                        lblCaja.Text = CajaChicaDAO.Caja(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString();
                        txtMonto.Text = simmoneda + " " + double.Parse(CajaChicaDAO.Caja(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[1].ToString()).ToString("###,###,##0.##");
                        txtSaldo.Text = simmoneda + " " + double.Parse(CajaChicaDAO.Caja(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[2].ToString()).ToString("###,###,##0.##");
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("No Existe una Caja Chica Abierta\n ¿Desea Abrir una?", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            //oCaja = frmCajaChica.getInstance();
                            //oCaja.MdiParent = this.MdiParent;
                            //oCaja.Show();
                            this.Close();
                        }
                    }
                    if (!lblCaja.Text.Trim().Equals("") && !lblCaja.Text.Trim().Equals("No"))
                        lblFecha.Text = CajaChicaDAO.FechaAperturaCaja(lblCaja.Text, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).ToShortDateString();
                    if (CajaChicaDAO.Error())
                        MessageBox.Show("Error al Listar los datos:\n" + CajaChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void LlenarGrid()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    CajaChicaDAO=new CajaChicaDetalleDAO();
                    
                    DataTable oTabla=new DataTable();
                    DataRow oRow=null;
                    oTabla.Columns.Add("DETCAJ_FECHAMOVIMIENTO");
                    oTabla.Columns.Add("DETCAJ_DOCUMENTO");
                    oTabla.Columns.Add("DETCAJ_EMPLEADO"); 
                    oTabla.Columns.Add("emp_nombre");
                    oTabla.Columns.Add("DETCAJ_MOVIMIENTO");
                    oTabla.Columns.Add("DETCAJ_CREDITO");
                    oTabla.Columns.Add("DETCAJ_DEBITO");
                    oTabla.Columns.Add("DETCAJ_JUSTIFICACION");
                    foreach (DataRow oFila in CajaChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows)
                    {
                       oRow = oTabla.NewRow();
                       oRow["DETCAJ_FECHAMOVIMIENTO"] = DateTime.Parse(oFila["DETCAJ_FECHAMOVIMIENTO"].ToString()).ToShortDateString() ;
                       oRow["DETCAJ_DOCUMENTO"] = oFila["DETCAJ_DOCUMENTO"].ToString();
                       oRow["DETCAJ_EMPLEADO"] = oFila["DETCAJ_EMPLEADO"].ToString();
                       oRow["emp_nombre"] = oFila["emp_nombre"].ToString();
                       oRow["DETCAJ_MOVIMIENTO"] = oFila["DETCAJ_MOVIMIENTO"].ToString();
                       oRow["DETCAJ_CREDITO"] = simmoneda + " " + double.Parse(oFila["DETCAJ_CREDITO"].ToString()).ToString("###,###,##0.##");
                       oRow["DETCAJ_DEBITO"] =simmoneda+" "+double.Parse(oFila["DETCAJ_DEBITO"].ToString()).ToString("###,###,##0.##");
                       oRow["DETCAJ_JUSTIFICACION"] = oFila["DETCAJ_JUSTIFICACION"].ToString();
                       oTabla.Rows.Add(oRow.ItemArray);

                   }
                   dgrDatos.DataSource = oTabla;
                    
                    if(CajaChicaDAO.Error())
                        MessageBox.Show("Error al Listar los datos:\n" + CajaChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    totales();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void LlenarGrid(string tipomovimiento)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    CajaChicaDAO = new CajaChicaDetalleDAO();
                    
                    DataTable oTabla = new DataTable();
                    DataRow oRow = null;
                    oTabla.Columns.Add("DETCAJ_FECHAMOVIMIENTO");
                    oTabla.Columns.Add("DETCAJ_DOCUMENTO");
                    oTabla.Columns.Add("DETCAJ_EMPLEADO");
                    oTabla.Columns.Add("emp_nombre");
                    oTabla.Columns.Add("DETCAJ_MOVIMIENTO");
                    oTabla.Columns.Add("DETCAJ_CREDITO");
                    oTabla.Columns.Add("DETCAJ_DEBITO");
                    oTabla.Columns.Add("DETCAJ_JUSTIFICACION");
                    foreach (DataRow oFila in CajaChicaDAO.Consultar(tipomovimiento, PROYECTO.Properties.Settings.Default.Usuario).Tables[0].Rows)
                    {
                        oRow = oTabla.NewRow();
                        oRow["DETCAJ_FECHAMOVIMIENTO"] = DateTime.Parse(oFila["DETCAJ_FECHAMOVIMIENTO"].ToString()).ToShortDateString();
                        oRow["DETCAJ_DOCUMENTO"] = oFila["DETCAJ_DOCUMENTO"].ToString();
                        oRow["DETCAJ_EMPLEADO"] = oFila["DETCAJ_EMPLEADO"].ToString();
                        oRow["emp_nombre"] = oFila["emp_nombre"].ToString();
                        oRow["DETCAJ_MOVIMIENTO"] = oFila["DETCAJ_MOVIMIENTO"].ToString();
                        oRow["DETCAJ_CREDITO"] = simmoneda + " " + double.Parse(oFila["DETCAJ_CREDITO"].ToString()).ToString("###,###,##0.##");
                        oRow["DETCAJ_DEBITO"] = simmoneda + " " + double.Parse(oFila["DETCAJ_DEBITO"].ToString()).ToString("###,###,##0.##");
                        oRow["DETCAJ_JUSTIFICACION"] = oFila["DETCAJ_JUSTIFICACION"].ToString();

                        oTabla.Rows.Add(oRow.ItemArray);

                    }
                    dgrDatos.DataSource = oTabla;

                    if (CajaChicaDAO.Error())
                        MessageBox.Show("Error al Listar los datos:\n" + CajaChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    totales();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer == 1)
            {
                timer1.Stop();
                llenarOtros();
                cboTipoMovimiento.SelectedIndex = 0;
            }
        }

        private void totales()
        {
            double deb = 0, cre = 0;
            for (int x = 0; x < dgrDatos.Rows.Count; x++)
            {
                deb += double.Parse(dgrDatos["DETCAJ_DEBITO", x].Value.ToString().Substring(1));
                cre += double.Parse(dgrDatos["DETCAJ_CREDITO", x].Value.ToString().Substring(1));
            }
            txtCredito.Text = simmoneda+" "+ cre.ToString("###,###,##0.##");
            txtDebito.Text = simmoneda + " " + deb.ToString("###,###,##0.##");
        }

        private void btnCajaChica_Click(object sender, EventArgs e)
        {
            frmCajaChica oCaja = frmCajaChica.getInstance();
            oCaja.MdiParent = this.MdiParent;
            oCaja.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTipoMovimiento.SelectedIndex==0)
            LlenarGrid();
            else
            LlenarGrid(cboTipoMovimiento.Text);

        if (dgrDatos.Rows.Count == 0)
        {
            txtJustificacion.Clear();
            txtMovimiento.Clear();
        }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtJustificacion.Text = dgrDatos["DETCAJ_JUSTIFICACION", e.RowIndex].Value.ToString();
            txtMovimiento.Text = dgrDatos["DETCAJ_MOVIMIENTO", e.RowIndex].Value.ToString();
        }
    }
}