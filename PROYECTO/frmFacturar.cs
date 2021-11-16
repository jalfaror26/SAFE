using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Drawing.Printing;

namespace PROYECTO
{
    public partial class frmFacturar : Form
    {
        private static frmFacturar instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private FacturaDAO oFacturaDAO = new FacturaDAO();
        private Factura oFactura = new Factura();
        private int agenda = 0, factura = 0, paciente = 0, tipoFactura = 0;
        private String nombre, origen = "";
        private DataTable oDetalles = new DataTable();
        private Double tc = 1;

        private String codigo = "pro_Facturacion", descripcion = "Facturación.", modulo = "Procesos";

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

        private frmFacturar(Factura ofactura, DataTable detalles, Double pTC, String pOrigen)
        {
            oFactura = ofactura;
            oDetalles = detalles;
            tc = pTC;
            origen = pOrigen;
            InitializeComponent();
        }

        private void LlenarDatos()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    lblFecha.Text = oFactura.FechaFactura.ToShortDateString();
                    txtMonto.Text = oFactura.Total.ToString("¢ ###,###,##0.00");

                    rboEfectivo.Checked = true;

                    txtAnombre.ReadOnly = false;

                    btnFacturar.Visible = true;
                    btnFacturar.Enabled = true;

                    gb1.Enabled = true;
                    gb2.Enabled = true;

                    oConexion.cerrarConexion();

                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        public static frmFacturar getInstance(Factura oFactura, DataTable Detalles, Double pTc, String pOrigen)
        {
            if (instance == null)
                instance = new frmFacturar(oFactura, Detalles, pTc, pOrigen);
            return instance;
        }

        private void frmFacturar_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            if (origen.Equals("frmFacturacionRapida"))
            {
                frmFacturacionRapida.getInstance().Enabled = true;
                frmFacturacionRapida.getInstance().cargaFactura(oFactura.NumFactura.ToString(), oFactura.Nombre);
            }
        }

        private void DistinguirPago()
        {
            txtComprobante.Clear();
            if (rboEfectivo.Checked)
            {
                txtPagaCon.ReadOnly = false;
                txtComprobante.Enabled = false;
                lblComprobante.Text = "COMPROBANTE:";
                lblVuelto.Visible = true;
            }
            else if (rboTarjeta.Checked)
            {
                txtPagaCon.ReadOnly = true;
                txtPagaCon.Text = "¢ 0";
                txtComprobante.Enabled = true;
                lblComprobante.Text = "COMPROBANTE:";
                lblVuelto.Visible = false;
            }
            else if (rboCheque.Checked)
            {
                txtPagaCon.ReadOnly = true;
                txtPagaCon.Text = "¢ 0";
                txtComprobante.Enabled = true;
                lblComprobante.Text = "Nº CHEQUE:";
                lblVuelto.Visible = false;
            }
            calcularVuelto();
        }

        private void calcularVuelto()
        {
            try
            {
                double monto = double.Parse(txtMonto.Text.Substring(1));
                double pagacon = double.Parse(txtPagaCon.Text.Substring(1));
                double vuelto = 0;


                vuelto = pagacon - monto;

                if (rboTarjeta.Checked || rboCheque.Checked)
                {
                    vuelto = monto;
                }

                RedondearNumero oRedondear = new RedondearNumero();
                if (vuelto > 0)
                    vuelto = oRedondear.Redondear(vuelto);
                else
                    vuelto = oRedondear.Redondear(vuelto * -1) * -1;

                txtPagaCon.Text = pagacon.ToString("¢ ###,###,##0.00");
                txtVuelto.Text = vuelto.ToString("¢ ###,###,##0.00");



                if (vuelto > 0)
                    btnFacturar.Enabled = true;
                else
                    btnFacturar.Enabled = false;
                //txtVuelto.Text = "¢ 0";

            }
            catch
            {
            }
        }

        private void txtPagaCon_Leave(object sender, EventArgs e)
        {
            if (rboEfectivo.Checked)
            {
                try
                {
                    double pagacon = 0;
                    try
                    {
                        pagacon = double.Parse(txtPagaCon.Text);
                    }
                    catch
                    {
                        pagacon = double.Parse(txtPagaCon.Text.Substring(1));
                    }

                    txtPagaCon.Text = pagacon.ToString();

                    if (rboPagaDolares.Checked)
                        pagacon = pagacon * tc;

                    double monto = double.Parse(txtMonto.Text.Substring(1));
                    double vuelto = 0;

                    //if (pagacon < monto)
                    //    pagacon = monto;

                    vuelto = pagacon - monto;

                    RedondearNumero oRedondear = new RedondearNumero();
                    if (vuelto > 0)
                        vuelto = oRedondear.Redondear(vuelto);
                    else
                        vuelto = oRedondear.Redondear(vuelto * -1) * -1;

                    txtPagaCon.Text = rboPagaColones.Checked ? double.Parse(txtPagaCon.Text).ToString("¢ ###,###,##0.00") : double.Parse(txtPagaCon.Text).ToString("$ ###,###,##0.00");

                    txtVuelto.Text = vuelto.ToString("¢ ###,###,##0.00");

                    if (vuelto > 0 || pagacon == monto)
                        btnFacturar.Enabled = true;
                    else
                        btnFacturar.Enabled = false;
                    //txtVuelto.Text = "¢ 0";
                }
                catch
                {
                }
            }
        }

        private void txtPagaCon_Enter(object sender, EventArgs e)
        {
            if (rboEfectivo.Checked)
            {
                txtPagaCon.Text = double.Parse(txtPagaCon.Text.Substring(1)).ToString("########0.00");
                if (txtPagaCon.Text.Equals("0"))
                    txtPagaCon.Clear();
            }
        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtPagaCon.ReadOnly == false)
                {
                    int puntos = 0;
                    for (int i = 0; i < txtPagaCon.Text.Length; i++)
                    {
                        if (txtPagaCon.Text[i].Equals('.'))
                            puntos++;
                    }

                    if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                        e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                txtPagaCon.Text = rboPagaColones.Checked ? "¢ 0" : "$ 0";
            }
        }

        private void rboEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            DistinguirPago();
            txtPagaCon.Focus();
        }

        private void rboTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            DistinguirPago();
            txtComprobante.Focus();
        }

        private void rboCheque_CheckedChanged(object sender, EventArgs e)
        {
            DistinguirPago();
            txtComprobante.Focus();
        }

        public void Facturar()
        {
            try
            {
                txtVuelto.Focus();
                if (double.Parse(txtMonto.Text.Substring(1)) <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor a ¢0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Focus();
                    return;
                }
                if (rboTarjeta.Checked && txtComprobante.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComprobante.Focus();
                    return;
                }
                if (rboCheque.Checked && txtComprobante.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el Nº de Cheque.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComprobante.Focus();
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String tipopago = "";
                    if (rboEfectivo.Checked)
                        tipopago = "EFECTIVO";
                    else if (rboTarjeta.Checked)
                        tipopago = "TARJETA";
                    else if (rboCheque.Checked)
                        tipopago = "CHEQUE";


                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();

                    oFactura.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oFactura.Comprobante = txtComprobante.Text;
                    oFactura.Tipopago = tipopago;
                    oFactura.Tarjeta = 0;

                    if (oFacturaDAO.ModificaEstadoFactura(oFactura) > 0)
                    {
                        //   MessageBox.Show("El documento se facturó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmFacturarVuelto oPantalla = frmFacturarVuelto.getInstance(txtMonto.Text, txtVuelto.Text, origen);
                        oPantalla.MdiParent = this.MdiParent;
                        oPantalla.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ocurrio un error al Modificar los datos: " + oFacturaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            txtMonto.Focus();
            if (!oFactura.NumFactura.Equals("0"))
                Facturar();
        }

        private void frmFacturar_Load(object sender, EventArgs e)
        {
            lblFactura.Text = oFactura.NumFactura.ToString();
            txtAnombre.Text = oFactura.Nombre;
            LlenarDatos();
            txtPagaCon.Focus();
            timer1.Start();
        }
        
        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            if (rboEfectivo.Checked)
            {
                try
                {
                    double pagacon = 0;
                    try
                    {
                        pagacon = double.Parse(txtPagaCon.Text);
                    }
                    catch
                    {
                        pagacon = double.Parse(txtPagaCon.Text.Substring(1));
                    }

                    if (rboPagaDolares.Checked)
                        pagacon = pagacon * tc;

                    double monto = double.Parse(txtMonto.Text.Substring(1));
                    double vuelto = 0;

                    //if (pagacon < monto)
                    //    pagacon = monto;

                    vuelto = pagacon - monto;

                    RedondearNumero oRedondear = new RedondearNumero();
                    if (vuelto > 0)
                        vuelto = oRedondear.Redondear(vuelto);
                    else
                        vuelto = oRedondear.Redondear(vuelto * -1) * -1;

                    txtVuelto.Text = vuelto.ToString("¢ ###,###,##0.00");

                    if (vuelto > 0 || pagacon == monto)
                        btnFacturar.Enabled = true;
                    else
                        btnFacturar.Enabled = false;
                    //txtVuelto.Text = "¢ 0";
                }
                catch
                {
                }
            }
        }

        private void txtVuelto_TextChanged(object sender, EventArgs e)
        {
            lblVuelto.Text = txtVuelto.Text;
        }

        private void rboPagaColones_CheckedChanged(object sender, EventArgs e)
        {
            //txtPagaCon.Text = "0";
            txtPagaCon.Focus();
            txtPagaCon.Text = "";
        }

        private void rboPagaDolares_CheckedChanged(object sender, EventArgs e)
        {
            //txtPagaCon.Text = "0";
            txtPagaCon.Focus();
            txtPagaCon.Text = "";
        }

        private void frmFacturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4)
            {
                if (e.KeyCode == Keys.F1)
                {
                    rboEfectivo.Checked = true;
                    txtPagaCon.Focus();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    rboTarjeta.Checked = true;
                    txtComprobante.Focus();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    rboCheque.Checked = true;
                    txtComprobante.Focus();
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnFacturar.Focus();
                    btnFacturar.PerformClick();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            txtPagaCon.Focus();
        }
    }
}