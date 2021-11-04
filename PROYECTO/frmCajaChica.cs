using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using Entidades;

namespace PROYECTO
{
    public partial class frmCajaChica : Form
    {
        private static frmCajaChica instance = null;
        private CajaChicaDAO oChicaDAO = null;
        private CajaChica oChica = null;
        private CajaChicaDetalle oChicaDetalle = null;
        private CajaChicaDetalleDAO oChicaDetalleDAO = null;
        private ConexionDAO oConexion = null;
        private int timer = 0, val = 0, indice = 0;
        private char moned = '¢', moneda1 = '¢';
        private double dolar = 0, montos;
        private String codigo = "pro_cajachica", descripcion = "Administracion de caja chica.", modulo = "Procesos";

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

        private frmCajaChica()
        {
            InitializeComponent();
        }

        public static frmCajaChica getInstance()
        {
            if (instance == null)
                instance = new frmCajaChica();
            return instance;
        }

        private void frmCajaChica_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void btnCajaChica_Click(object sender, EventArgs e)
        {
            frmMovimientosCajaChica oMov = frmMovimientosCajaChica.getInstance();
            oMov.MdiParent = this.MdiParent;
            oMov.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (btnAbrirCaja.Enabled && val > 0)
            {
                if (MessageBox.Show("Advertencia:\nNo se ha Abierto la Caja.\n ¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }

        }

        private void AbrirCaja()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oChica = new CajaChica();
                    oChicaDAO = new CajaChicaDAO();
                    oChica.Monto = double.Parse(txtSaldo.Text.Substring(1)) + double.Parse(txtSaldoAnterior.Text.Substring(1));
                    oChica.Documento = txtDocumento.Text;

                    oChica.Saldo = double.Parse(txtSaldo.Text.Substring(1)) + double.Parse(txtSaldoAnterior.Text.Substring(1));
                    oChica.Moneda = cmbMoneda.Text;
                    indice = int.Parse(oChicaDAO.Abrir(oChica, PROYECTO.Properties.Settings.Default.No_cia).ToString());
                    if (oChicaDAO.Error())
                        MessageBox.Show("Error al Abrir Caja Chica:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Caja Chica Abierta Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCaja.Text = indice.ToString();
                    oConexion.cerrarConexion();

                    CrearMovimiento();
                    Listo();
                    llenarOtros();
                    LlenarDatos();

                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void ConvertirMontos()
        {
            try
            {
                double valor = 0;
                double dolar = 0;
                double monto = Convert.ToDouble(txtMonto.Text.Substring(1));
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); oConexion.abrirConexion();
                DataTable oTabla = new DataTable();
                oTabla = oChicaDAO.TipoCambio();
                oConexion.cerrarConexion();
                dolar = Convert.ToDouble(oTabla.Rows[0].ItemArray[0].ToString());
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }

        }

        private void CrearMovimiento()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oChicaDetalle = new CajaChicaDetalle();
                    oChicaDetalleDAO = new CajaChicaDetalleDAO();
                    oChicaDetalle.Caja = int.Parse(lblCaja.Text);
                    oChicaDetalle.Movimiento = "REINTEGRO";
                    oChicaDetalle.Credito = double.Parse(txtSaldo.Text.Substring(1)) + double.Parse(txtSaldoAnterior.Text.Substring(1));
                    oChicaDetalle.Debito = 0;
                    oChicaDetalle.Empleado = "CAJA CHICA";
                    oChicaDetalle.Documento = txtDocumento.Text;
                    oChicaDetalle.TipoMovimiento = "REINTEGRO";
                    oChicaDetalle.Justificacion = "APERTURA DE CAJA";

                    oChicaDetalleDAO.Insertar(oChicaDetalle, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oChicaDetalleDAO.Error())
                        MessageBox.Show("Error al Abrir Caja Chica:\n" + oChicaDetalleDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    Listo();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void frmCajaChica_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LlenarTipoCambio();
        }

        private void LlenarDatos()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oChicaDAO = new CajaChicaDAO();
                    DataTable oTabla = oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    txtDocumento.Text = oTabla.Rows[0].ItemArray[0].ToString();
                    cmbMoneda.SelectedItem = oTabla.Rows[0].ItemArray[4].ToString().ToString();
                    txtMonto.Text = moned + " " + double.Parse(oTabla.Rows[0].ItemArray[2].ToString()).ToString("###,###,##0.##");
                    txtSaldo.Text = moned + " " + double.Parse(oTabla.Rows[0].ItemArray[3].ToString()).ToString("###,###,##0.##");
                    indice = int.Parse(oTabla.Rows[0].ItemArray[5].ToString());
                    cmbMoneda.Enabled = false;
                    if (oChicaDAO.Error())
                        MessageBox.Show("Error al cargar la Caja Chica:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (val == 0)
            {
                val++;
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); oConexion.abrirConexion();
                nuevo();
                oConexion.cerrarConexion();
            }
            else
            {
                if (evaluar() != true)
                {
                    MessageBox.Show("Existen Campos Sin Llenar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                AbrirCaja();
                Listo();
                llenarOtros();
            }
        }

        private void llenarOtros()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDAO = new CajaChicaDAO();
                    try
                    {
                        lblCaja.Text = oChicaDAO.Caja(PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    catch (Exception ex)
                    {
                        Limpiar();
                    }
                    if (!lblCaja.Text.Trim().Equals("") && !lblCaja.Text.Trim().Equals("No") && val == 0)
                    {
                        lblFecha.Text = oChicaDAO.FechaAperturaCaja(lblCaja.Text, PROYECTO.Properties.Settings.Default.No_cia).ToShortDateString();
                        btnCerrar.Enabled = true;
                        btnMovimientos.Enabled = true;
                        btnOtros.Enabled = true;
                    }
                    else
                        btnAbrirCaja.Enabled = true;

                    if (oChicaDAO.Error())
                        MessageBox.Show("Error al Listar los datos:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer == 1)
            {
                timer1.Stop();
                llenarOtros();
                LlenarDatos();
            }
        }

        private void nuevo()
        {
            cmbMoneda.SelectedIndex = 0;
            cmbMoneda.Enabled = true;
            lblSaldoAnterior.Visible = true;
            txtSaldoAnterior.Visible = true;

            oConexion.cerrarConexion();
            oConexion.cerrarConexion(); oConexion.abrirConexion();
            lblFecha.Text = oChicaDAO.fecha().ToShortDateString();
            lblCaja.Text = "0";
            try
            {
                montos = double.Parse(oChicaDAO.ultimoSaldo(PROYECTO.Properties.Settings.Default.No_cia).ToString("###,###,##0.##"));
            }
            catch (Exception ex)
            {
                montos = 0;
            }
            txtSaldoAnterior.Text = moned + " " + montos.ToString("###,###,##0.##");
            if (oChicaDAO.ultimoMoneda(PROYECTO.Properties.Settings.Default.No_cia).Equals("CRC"))
            {
                moneda1 = '¢';
                moned = '¢';
                cmbMoneda.SelectedIndex = 0;
            }
            else if (oChicaDAO.ultimoMoneda(PROYECTO.Properties.Settings.Default.No_cia).Equals("USD"))
            {
                moneda1 = '$';
                moned = '$';
                cmbMoneda.SelectedIndex = 1;
            }
            oConexion.cerrarConexion();
            txtDocumento.ReadOnly = false;
            txtDocumento.ForeColor = System.Drawing.Color.Black;
            txtDocumento.BackColor = System.Drawing.Color.White;
            txtMonto.ReadOnly = false;
            txtMonto.ForeColor = System.Drawing.Color.Black;
            txtMonto.BackColor = System.Drawing.Color.White;
            btnCerrar.Enabled = false;
            btnMovimientos.Enabled = false;
            btnOtros.Enabled = false;
            txtDocumento.Focus();
        }

        private void Listo()
        {
            lblSaldoAnterior.Visible = false;
            txtSaldoAnterior.Visible = false;
            cmbMoneda.Enabled = false;
            txtDocumento.ReadOnly = true;
            txtDocumento.ForeColor = System.Drawing.Color.White;
            txtDocumento.BackColor = System.Drawing.Color.Blue;
            txtMonto.ReadOnly = true;
            txtMonto.ForeColor = System.Drawing.Color.White;
            txtMonto.BackColor = System.Drawing.Color.Blue;
            btnAbrirCaja.Enabled = false;
            btnCerrar.Enabled = true;
            btnMovimientos.Enabled = true;
            btnOtros.Enabled = true;
            val = 0;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Boolean evaluar()
        {
            Boolean val = true;
            if (txtMonto.Text.Trim().Equals("") || txtDocumento.Text.Trim().Equals(""))
                val = false;
            return val;
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (txtMonto.ReadOnly == false)
            {
                if (txtMonto.Text.Trim().Equals("") || txtMonto.Text.Trim().Equals("."))
                    txtMonto.Text = "0";
                string monto = "";
                for (int x = 0; x < txtMonto.Text.Length; x++)
                {
                    if (!txtMonto.Text[x].Equals(' '))
                        monto += txtMonto.Text[x];
                }
                txtMonto.Text = moned + " " + double.Parse(monto).ToString("###,###,##0.##");
                txtSaldo.Text = txtMonto.Text;
            }
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            if (txtMonto.ReadOnly == false)
            {
                txtMonto.Text = double.Parse(txtSaldo.Text.Substring(1)).ToString("###,###,##0.##");
            }
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            moneda1 = moned;
            if (cmbMoneda.Text.Equals("CRC"))
                moned = '¢';
            else if (cmbMoneda.Text.Equals("USD"))
                moned = '$';

            txtMonto.Text = moned + " " + double.Parse(txtMonto.Text.Substring(2)).ToString("###,###,##0.##");
            txtMonto.Text = moned + " " + ConvertirMontos(txtMonto.Text.Substring(1));
            txtSaldo.Text = txtMonto.Text;
            txtSaldoAnterior.Text = moned + " " + ConvertirMontos(txtSaldoAnterior.Text.Substring(1));
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void LlenarTipoCambio()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();

                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDAO = new CajaChicaDAO();
                    dolar = double.Parse(oChicaDAO.TipoCambio().Rows[0].ItemArray[0].ToString());
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string ConvertirMontos(string mont)
        {
            string valor = "";
            char monedaOrigen = moneda1;
            double monto = double.Parse(mont);

            if (monedaOrigen.Equals('¢') && moned.Equals('¢'))
                valor = monto.ToString("###,###,##0.##");
            else if (monedaOrigen.Equals('¢') && moned.Equals('$'))
            {
                double val = (monto / dolar);
                valor = val.ToString("###,###,##0.##"); ;
            }
            else if (monedaOrigen.Equals('$') && moned.Equals('$'))
            {
                valor = monto.ToString("###,###,##0.##");
            }
            else if (monedaOrigen.Equals('$') && moned.Equals('¢'))
            {
                double val = (monto * dolar);
                valor = val.ToString("###,###,##0.##");
            }

            return valor;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("     Advertencia:\n     Cerrar la Caja Chica.        \n      ¿Desea Continuar?          ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oChica = new CajaChica();
                        oChicaDAO = new CajaChicaDAO();
                        oChica.Linea = indice;

                        oChicaDAO.Cerrar(oChica, PROYECTO.Properties.Settings.Default.No_cia);
                        if (oChicaDAO.Error())
                        {
                            MessageBox.Show("Error al Cerrar Caja Chica:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            oConexion.cerrarConexion();
                            return;
                        }
                        else
                            MessageBox.Show("Caja Chica Cerrada Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        oConexion.cerrarConexion();
                        Limpiar();
                        val = 0;
                    }
                    else
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Limpiar()
        {
            lblCaja.Text = "No";
            lblFecha.Text = "--/--/----";
            cmbMoneda.SelectedIndex = 0;
            txtDocumento.Clear();
            txtMonto.Text = moned + " " + (0).ToString("###,###,##0.##");
            txtSaldo.Text = moned + " " + (0).ToString("###,###,##0.##");
            btnAbrirCaja.Enabled = true;
            btnCerrar.Enabled = false;
            btnMovimientos.Enabled = false;
            btnOtros.Enabled = false;
            cmbMoneda.Enabled = false;
            txtDocumento.ReadOnly = true;
            txtDocumento.ForeColor = System.Drawing.Color.White;
            txtDocumento.BackColor = System.Drawing.Color.Blue;
            txtMonto.ReadOnly = true;
            txtMonto.ForeColor = System.Drawing.Color.White;
            txtMonto.BackColor = System.Drawing.Color.Blue;
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            frmCajaChicaOtros oCaja = frmCajaChicaOtros.getInstance();
            oCaja.MdiParent = this.MdiParent;
            oCaja.Show();
            this.Close();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMonto.ReadOnly == false)
                {
                    int puntos = 0;
                    for (int i = 0; i < txtMonto.Text.Length; i++)
                    {
                        if (txtMonto.Text[i].Equals('.'))
                            puntos++;
                    }

                    if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                        e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                txtMonto.Text = moned + " 0";
                txtSaldo.Text = moned + " " + double.Parse(txtMonto.Text.Substring(1)).ToString("###,###,##0.##");
            }
        }

    }
}