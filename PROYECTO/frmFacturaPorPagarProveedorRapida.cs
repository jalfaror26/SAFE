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
    public partial class frmFacturaPorPagarProveedorRapida : Form
    {
        private string codprov, prov, moneda;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private FacturasPagosDAO oFacturaDAO = null;
        private FacturasPago oFacturasPago = null;
        private TipoCambioDAO oTipoCambioDAO = null;

        private int dias = 0;
        private char simmoneda = '¢';

        private frmFacturaPorPagarProveedorRapida(string pcodprov, string pprov, string pmoneda)
        {
            codprov = pcodprov;
            prov = pprov;
            moneda = pmoneda;
            InitializeComponent();
        }

        private frmFacturaPorPagarProveedorRapida()
        {
            InitializeComponent();
        }

        private static frmFacturaPorPagarProveedorRapida ofacturas = null;

        public static frmFacturaPorPagarProveedorRapida getInstance(string codprov, string prov, string moneda)
        {
            if (ofacturas == null)
                ofacturas = new frmFacturaPorPagarProveedorRapida(codprov, prov, moneda);
            return ofacturas;
        }

        public static frmFacturaPorPagarProveedorRapida getInstance()
        {
            if (ofacturas == null)
                ofacturas = new frmFacturaPorPagarProveedorRapida();
            return ofacturas;
        }

        private void frmFacturaPorPagarProveedorRapida_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofacturas = null;
        }

        private void frmFacturaPorPagarProveedorRapida_Load(object sender, EventArgs e)
        {
            consultaDias();
            txtfechaactual.Text = DateTime.Today.ToShortDateString();
            dtpEmision.Value = DateTime.Today;
            txtFechaEmision.Text = DateTime.Today.ToShortDateString();
            LlenarCombos();
            Tipo_Cambio();
            txtCodProveedor.Text = codprov;
            txttipocambio.ReadOnly = false;
            txtProveedor.Text = prov;
            txtMoneda.Text = moneda;
            if (moneda.Equals("CRC"))
                simmoneda = '¢';
            else if (moneda.Equals("USD"))
                simmoneda = '$';
           
            txtmonto.Text = simmoneda + " 0.00";
        }

        public void consultaDias()
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                oFacturaDAO = new FacturasPagosDAO();
                dias = int.Parse(oFacturaDAO.consultarDias(codprov, PROYECTO.Properties.Settings.Default.No_cia));
                if (oFacturaDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al extraer los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        public void LlenarGasto(String cod, String des)
        {
            txtCodGasto.Text = cod;
            txtGasto.Text = des;
        }

        private Boolean ValidarDatos()
        {
            Boolean correcto = true;
            if (txtnumfactura.Text.Trim().Equals("") || (Convert.ToDouble(txtmonto.Text.Substring(1).Trim()) <= 0) ||
            cboTipoGasto.SelectedIndex == -1 || txttipocambio.Text.Trim().Equals(""))
                correcto = false;
            if (cboTipoGasto.SelectedIndex == 0)
                if (txtGasto.Text.Trim().Equals(""))
                    correcto = false;

            return correcto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturaDAO = new FacturasPagosDAO();
                    oFacturasPago = new FacturasPago();

                    oFacturasPago.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    int pasa = 0;
                    int tipo = 0;
                    DataTable otabla = new DataTable();
                    otabla = oFacturaDAO.consultarFactura(txtnumfactura.Text, codprov, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    for (int x = 0; x < otabla.Rows.Count; x++)
                    {
                        if (txtnumfactura.Text.Trim().Equals(otabla.Rows[x].ItemArray[0].ToString()))
                            pasa = 1;
                        if (pasa == 1)
                            if (otabla.Rows[x].ItemArray[1].ToString().Equals("0"))
                                tipo = 1;
                    }

                    if (pasa == 1)
                    {
                        if (tipo == 1)
                        {
                            ModificarExistente();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Factura Ya Existente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Agregar();
                        this.Close();
                    }


                    oConexion.cerrarConexion();
                    frmPrepagoProveedor oPrepago = frmPrepagoProveedor.getInstance();
                    oPrepago.llenaGrid();

                }
                else
                    MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Agregar()
        {
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                oFacturasPago.NumFactura = txtnumfactura.Text;
                oFacturasPago.CodProveedor = txtCodProveedor.Text;
                oFacturasPago.Flujo = int.Parse(cboTipoGasto.Text);
                if (cboTipoGasto.Text.Equals("201"))
                    oFacturasPago.TipoGasto = "NO APLICA";
                else
                    oFacturasPago.TipoGasto = txtCodGasto.Text;
                oFacturasPago.FechaEmision = DateTime.Parse(txtFechaEmision.Text);
                oFacturasPago.FechaVence = DateTime.Parse(DateTime.Parse(txtFechaEmision.Text).AddDays(dias).ToShortDateString());
                oFacturasPago.Moneda = txtMoneda.Text;
                oFacturasPago.Tipocambio = Double.Parse(txttipocambio.Text.Substring(1));
                oFacturasPago.Monto = Double.Parse(txtmonto.Text.Substring(1));
                oFacturasPago.Saldo = Double.Parse(txtmonto.Text.Substring(1));
                oFacturasPago.Estado = "FP";
                oFacturasPago.Responsable = txtCodProveedor.Text;
                oFacturaDAO.Insertar(oFacturasPago);
                if (oFacturaDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al guardar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Agregado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oConexion.cerrarConexion();
            }
        }

        private void ModificarExistente()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturasPago.NumFactura = txtnumfactura.Text;
                    oFacturasPago.CodProveedor = txtCodProveedor.Text;
                    oFacturasPago.Flujo = int.Parse(cboTipoGasto.Text);
                    if (cboTipoGasto.SelectedIndex == 1)
                        oFacturasPago.TipoGasto = " ";
                    else
                        oFacturasPago.TipoGasto = txtCodGasto.Text;
                    oFacturasPago.FechaEmision = DateTime.Parse(txtFechaEmision.Text);
                    oFacturasPago.FechaVence = DateTime.Parse(DateTime.Parse(txtFechaEmision.Text).AddDays(dias).ToShortDateString());
                    oFacturasPago.Moneda = txtMoneda.Text;
                    oFacturasPago.Tipocambio = Double.Parse(txttipocambio.Text.Substring(1));
                    oFacturasPago.Monto = Double.Parse(txtmonto.Text.Substring(1));
                    oFacturasPago.Saldo = Double.Parse(txtmonto.Text.Substring(1));
                    oFacturasPago.Estado = "FP";

                    oFacturaDAO.ModificarExistente(oFacturasPago);
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al Modificar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Modificado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        public void LlenarCombos()
        {
            cboTipoGasto.Items.Clear();
            cboTipoGasto.Items.Add("200");
            cboTipoGasto.Items.Add("201");
            cboTipoGasto.SelectedIndex = 0;
        }

        private void btnBusqGasto_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("GastosRapidos");
            oConsulta.Show();
        }

        private void cboTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoGasto.SelectedIndex == 0)
                btnBusqGasto.Enabled = true;
            else
            {
                txtCodGasto.Text = "";
                txtGasto.Text = "";
                btnBusqGasto.Enabled = false;
            }
        }

        private void Tipo_Cambio()
        {
            try
            {
                oTipoCambioDAO = new TipoCambioDAO();
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    double dolar = 0;
                    
                    DataTable oTabla = new DataTable();
                    oTabla = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    oConexion.cerrarConexion();
                    dolar = Convert.ToDouble(oTabla.Rows[0].ItemArray[0].ToString());
                    
                    if (moneda.Trim().Equals("CRC"))
                        txttipocambio.Text = dolar.ToString("¢ ###,###,##0.00");
                    else if (moneda.Trim().Equals("USD"))
                        txttipocambio.Text = dolar.ToString("¢ ###,###,##0.00");
              
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text.Substring(2);
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtmonto.Text.Length; i++)
            {
                if (txtmonto.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            if (txtmonto.Text.Trim().Equals("") || txtmonto.Text.Trim().Equals("."))
                txtmonto.Text = "0.00";
            string monto = "";
            for (int x = 0; x < txtmonto.Text.Length; x++)
            {
                if (!txtmonto.Text[x].Equals(' '))
                    monto += txtmonto.Text[x];
            }
            txtmonto.Text = simmoneda + " " + double.Parse(monto).ToString("###,###,##0.00");
        }

        private void txtnumfactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void dtpEmision_CloseUp(object sender, EventArgs e)
        {
            txtFechaEmision.Text = dtpEmision.Value.ToShortDateString();
        }

        private void txttipocambio_TextChanged(object sender, EventArgs e)
        {
            if (txttipocambio.Text.Trim().Equals(""))
            {
                if (txttipocambio.Focused)
                    txttipocambio.Text = "0.00";
                else
                    txttipocambio.Text = "¢ 0.00";
            }
        }

        private void txttipocambio_Leave(object sender, EventArgs e)
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
                    //if (txttipocambio.Focused)
                    monto = Double.Parse(txttipocambio.Text);
                    //else
                    //    monto = Double.Parse(txttipocambio.Text.Substring(1));
                    if (txtMoneda.Text.Equals("USD") || txtMoneda.Text.Equals("CRC"))
                    {
                        if (monto < Double.Parse(oTabla.Rows[0].ItemArray[3].ToString()))
                        {
                            txttipocambio.Text = Double.Parse(oTabla.Rows[0].ItemArray[0].ToString()).ToString("¢ ###,###,##0.00");
                            MessageBox.Show("El tipo de cambio no puede ser menor al minimo establecido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (monto < Double.Parse(oTabla.Rows[0].ItemArray[4].ToString()))
                        {
                            txttipocambio.Text = Double.Parse(oTabla.Rows[0].ItemArray[1].ToString()).ToString("¢ ###,###,##0.00");
                            MessageBox.Show("El tipo de cambio no puede ser menor al minimo establecido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    oConexion.cerrarConexion();
                    txttipocambio.Text = Double.Parse(txttipocambio.Text).ToString("¢ ###,###,##0.00");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txttipocambio_Enter(object sender, EventArgs e)
        {
            try
            {
                txttipocambio.Text = Double.Parse(txttipocambio.Text.Substring(1)).ToString("########0.00");
            }
            catch (Exception ex)
            {

            }
        }

        private void txttipocambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;

                for (int i = 0; i < txttipocambio.Text.Length; i++)
                {
                    if (txttipocambio.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

    }
}