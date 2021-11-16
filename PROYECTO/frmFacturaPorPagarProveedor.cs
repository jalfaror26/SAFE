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
    public partial class frmFacturaPorPagarProveedor : Form
    {

        private static frmFacturaPorPagarProveedor ofacturas = null;
        private ConexionDAO oConexion = null;
        private FacturasPagosDAO oFacturaDAO = null;
        private FacturasPago oFacturasPago = null;
        private TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
        private int indi = 0;
        private char simmoneda = ' ';
        private String codigo = "pro_facProveedor", descripcion = "Registro de facturas por proveedor.", modulo = "Procesos";

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



        private frmFacturaPorPagarProveedor()
        {
            InitializeComponent();
        }

        public static frmFacturaPorPagarProveedor getInstance()
        {
            if (ofacturas == null)
                ofacturas = new frmFacturaPorPagarProveedor();
            return ofacturas;
        }

        public void LlenarProveedor(String cod, String des)
        {

            limpiar();
            txtCodProveedor.Text = cod;
            txtProveedor.Text = des;
            llenarGrid();
            consultaDias();
            btnMNuevo.PerformClick();
        }

        public void consultaDias()
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                oFacturaDAO = new FacturasPagosDAO();

                txtDiasCredito.Text = oFacturaDAO.consultarDias(txtCodProveedor.Text, PROYECTO.Properties.Settings.Default.No_cia);
                if (oFacturaDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al extraer los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
            else
                MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LlenarGasto(String cod, String des)
        {
            txtCodGasto.Text = cod;
            txtGasto.Text = des;
        }

        public void llenarGrid()
        {
            try
            {
                Deshabilitar();
                btnBusqGasto.Enabled = false;

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFacturaDAO = new FacturasPagosDAO();
                    dgrDatos.DataSource = oFacturaDAO.Consultar(txtCodProveedor.Text, cboEstado.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    LlenarSaldos();
                }
                else
                    MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void habilitar()
        {
            try
            {
                limpiar();
                txtFechaEmision.Text = DateTime.Today.ToShortDateString();
                txtFechaVence.Text = DateTime.Parse(txtFechaEmision.Text).AddDays(int.Parse(txtDiasCredito.Text)).ToShortDateString();
                txtnumfactura.BackColor = System.Drawing.Color.White;
                txtnumfactura.ReadOnly = false;
                txtnumfactura.ForeColor = System.Drawing.Color.Black;
                txtmonto.BackColor = System.Drawing.Color.White;
                txtmonto.ReadOnly = false;
                txtmonto.ForeColor = System.Drawing.Color.Black;
                txtestado.Text = "FP";
                txtEstadoDesc.Text = "FACTURA PENDIENTE";
                cmbMoneda.Enabled = true;
                btnBusqGasto.Enabled = false;
                dtpEmision.Enabled = true;
                cboTipoGasto.Enabled = true;
                cmbMoneda.SelectedIndex = 0;
                cboTipoGasto.SelectedIndex = 0;
                dgrDatos.ClearSelection();

                Tipo_Cambio();
            }
            catch (Exception ex) { }
        }

        private void Deshabilitar()
        {
            txtnumfactura.BackColor = System.Drawing.Color.Beige;
            txtnumfactura.ReadOnly = true;
            txtnumfactura.ForeColor = System.Drawing.Color.Black;
            txtmonto.BackColor = System.Drawing.Color.Beige;
            txtmonto.ReadOnly = true;
            txtmonto.ForeColor = System.Drawing.Color.Black;
            cmbMoneda.Enabled = false;
            txtSaldoAdeudado.ReadOnly = true;
            btnBusqGasto.Enabled = false;
            dtpEmision.Enabled = false;
            txttipocambio.Visible = true;
            limpiar();
        }

        public void limpiar()
        {
            txtnumfactura.Clear();
            txtmonto.Text = simmoneda + " 0.00";
            txtSaldo.Text = simmoneda + " 0.00";
            txtestado.Clear();
            txtEstadoDesc.Clear();
            cboTipoGasto.SelectedIndex = 0;
            txtCodGasto.Clear();
            txtGasto.Clear();
            cmbMoneda.SelectedIndex = 0;
            txttipocambio.Clear();
            txtFechaVence.Clear();
            txtFechaEmision.Clear();
            txtfechaactual.Text = DateTime.Now.ToShortDateString();
        }

        private Boolean ValidarDatos()
        {
            Boolean correcto = true;
            if (txtnumfactura.Text.Trim().Equals("") || (Convert.ToDouble(txtmonto.Text.Substring(1).Trim()) <= 0) ||
            cboTipoGasto.Text.Trim().Equals("") || cboTipoGasto.Text.Trim().Equals("") || txtFechaVence.Text.Trim().Equals(""))
                correcto = false;
            if (cboTipoGasto.Text.Trim().Equals("200"))
                if (txtGasto.Text.Trim().Equals(""))
                    correcto = false;

            return correcto;
        }

        private void Agregar()
        {
            oFacturasPago.NumFactura = txtnumfactura.Text;
            oFacturasPago.CodProveedor = txtCodProveedor.Text;
            oFacturasPago.Responsable = txtCodProveedor.Text;
            oFacturasPago.Flujo = int.Parse(cboTipoGasto.Text);
            if (cboTipoGasto.Text.Equals("201"))
                oFacturasPago.TipoGasto = "NO APLICA";
            else
                oFacturasPago.TipoGasto = txtCodGasto.Text;
            oFacturasPago.FechaEmision = DateTime.Parse(txtFechaEmision.Text);
            oFacturasPago.FechaVence = DateTime.Parse(txtFechaVence.Text);
            oFacturasPago.Moneda = cmbMoneda.Text;
            oFacturasPago.Tipocambio = Double.Parse(txttipocambio.Text.Substring(1));
            oFacturasPago.Monto = Double.Parse(txtmonto.Text.Substring(1));
            oFacturasPago.Saldo = Double.Parse(txtSaldo.Text.Substring(1));
            oFacturasPago.Estado = "FP";
            oFacturasPago.Dias = int.Parse(txtDiasCredito.Text);
            oFacturaDAO.Insertar(oFacturasPago);
            if (oFacturaDAO.Error())
                MessageBox.Show("Ha ocurrido un error al guardar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Agregado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMNuevo.PerformClick();
            }
        }

        private void ModificarExistente()
        {
            oFacturasPago.NumFactura = txtnumfactura.Text;
            oFacturasPago.CodProveedor = txtCodProveedor.Text;
            oFacturasPago.Flujo = int.Parse(cboTipoGasto.Text);
            if (cboTipoGasto.Text.Trim().Equals("201"))
                oFacturasPago.TipoGasto = "NO APLICA";
            else
                oFacturasPago.TipoGasto = txtCodGasto.Text;
            oFacturasPago.FechaEmision = DateTime.Parse(txtFechaEmision.Text);
            oFacturasPago.FechaVence = DateTime.Parse(txtFechaVence.Text);
            oFacturasPago.Moneda = cmbMoneda.Text;
            oFacturasPago.Tipocambio = Double.Parse(txttipocambio.Text);
            oFacturasPago.Monto = Double.Parse(txtmonto.Text.Substring(1));
            oFacturasPago.Saldo = Double.Parse(txtSaldo.Text.Substring(1));
            oFacturasPago.Estado = "FP";
            oFacturasPago.Dias = int.Parse(txtDiasCredito.Text);
            oFacturaDAO.ModificarExistente(oFacturasPago);
            if (oFacturaDAO.Error())
                MessageBox.Show("Ha ocurrido un error al guardar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Modificado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMNuevo.PerformClick();
            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Deshabilitar();
            indi = int.Parse(dgrDatos["indic", e.RowIndex].Value.ToString());
            txtnumfactura.Text = dgrDatos["factura", e.RowIndex].Value.ToString();
            txtCodProveedor.Text = dgrDatos["codproveedor", e.RowIndex].Value.ToString();
            txtProveedor.Text = dgrDatos["proveedor", e.RowIndex].Value.ToString();
            txtmonto.Text = simmoneda + " " + double.Parse(dgrDatos["monto", e.RowIndex].Value.ToString()).ToString("###,###,##0.00"); ;
            txtSaldo.Text = simmoneda + " " + double.Parse(dgrDatos["saldo", e.RowIndex].Value.ToString()).ToString("###,###,##0.00");
            txtestado.Text = dgrDatos["estatus", e.RowIndex].Value.ToString();
            if (dgrDatos["estatus", e.RowIndex].Value.ToString().Equals("FP"))
                txtEstadoDesc.Text = "FACTURA PENDIENTE";
            else
                txtEstadoDesc.Text = "FACTURA CANCELADA";
            txtCodGasto.Text = dgrDatos["tipogasto", e.RowIndex].Value.ToString();
            txtGasto.Text = dgrDatos["gasto", e.RowIndex].Value.ToString();
            cmbMoneda.SelectedItem = dgrDatos["moneda", e.RowIndex].Value.ToString();

            txttipocambio.Text = Convert.ToDouble(dgrDatos["tipocambio", e.RowIndex].Value.ToString()).ToString("¢ ###,##0.00");
            txtFechaEmision.Text = DateTime.Parse(dgrDatos["emision", e.RowIndex].Value.ToString()).ToShortDateString();
            txtFechaVence.Text = DateTime.Parse(dgrDatos["vence", e.RowIndex].Value.ToString()).ToShortDateString();
            cboTipoGasto.SelectedItem = dgrDatos["flujo", e.RowIndex].Value.ToString();

        }

        private void LlenarSaldos()
        {
            double saldo = 0;
            foreach (DataGridViewRow oRow in dgrDatos.Rows)
            {
                saldo += Double.Parse(oRow.Cells["saldo"].Value.ToString());
            }
            txtSaldoAdeudado.Text = simmoneda + " " + saldo.ToString("###,###,##0.00");
        }

        private void frmFacturaPorPagarProveedor_Load(object sender, EventArgs e)
        {
            dtpEmision.Value = DateTime.Today;
            LlenarCombos();
        }

        public void LlenarCombos()
        {
            cboTipoGasto.Items.Clear();
            cboTipoGasto.Items.Add("200");
            cboTipoGasto.Items.Add("201");

            cboEstado.Items.Clear();
            cboEstado.Items.Add("FP");
            cboEstado.Items.Add("FC");
            cboEstado.SelectedIndex = 0;
        }

        private void frmFacturaPorPagarProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofacturas = null;
        }

        private void btnBusqProv_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("ProveedorPagos");
            oConsulta.Show();
        }

        private void btnBusqGasto_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("Gastos");
            oConsulta.Show();
        }

        private void dtpEmision_CloseUp_1(object sender, EventArgs e)
        {
            txtFechaEmision.Text = dtpEmision.Value.ToShortDateString();
            if (!txtDiasCredito.Text.Equals(""))
                txtFechaVence.Text = dtpEmision.Value.AddDays(Double.Parse(txtDiasCredito.Text)).ToShortDateString();
            else
                txtFechaVence.Text = dtpEmision.Value.ToShortDateString();
        }

        private void cboTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoGasto.SelectedIndex == 0)
            {
                btnBusqGasto.Enabled = true;
            }
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
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    double dolar = 0;

                    DataTable oTabla = new DataTable();
                    oTabla = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    oConexion.cerrarConexion();
                    dolar = Convert.ToDouble(oTabla.Rows[0].ItemArray[0].ToString());

                    switch (cmbMoneda.SelectedIndex)
                    {
                        case 0:
                            txttipocambio.Text = dolar.ToString("¢ ##0.00");
                            break;
                        case 1:
                            txttipocambio.Text = dolar.ToString("¢ ##0.00");
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cbomoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo_Cambio();
            switch (cmbMoneda.SelectedIndex)
            {
                case 0:
                    simmoneda = '¢';
                    break;
                case 1:
                    simmoneda = '$';
                    break;
            }
            txtmonto.Text = simmoneda + " " + double.Parse(txtmonto.Text.Substring(1)).ToString("###,###,##0.00");
            txtSaldo.Text = simmoneda + " " + double.Parse(txtSaldo.Text.Substring(1)).ToString("###,###,##0.00");
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGrid();
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
            txtSaldo.Text = txtmonto.Text;
        }

        private void txtmonto_Enter(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text.Substring(2);
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
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

        private void txtnumfactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
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
                    if (txttipocambio.Focused)
                        monto = Double.Parse(txttipocambio.Text);
                    else
                        monto = Double.Parse(txttipocambio.Text.Substring(1));
                    if (cmbMoneda.Text.Equals("USD") || cmbMoneda.Text.Equals("CRC"))
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
                    try
                    {
                        txttipocambio.Text = Double.Parse(txttipocambio.Text).ToString("¢ ###,###,##0.00");
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

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            if (!txtProveedor.Text.Trim().Equals(""))
                habilitar();
            else
                MessageBox.Show("Debe Seleccionar un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            try
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
                        otabla = oFacturaDAO.consultarFactura(txtnumfactura.Text, txtCodProveedor.Text, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                        for (int x = 0; x < otabla.Rows.Count; x++)
                        {
                            if (txtnumfactura.Text.Trim().Equals(otabla.Rows[x].ItemArray[0].ToString()))
                                pasa = 1;
                            if (txtnumfactura.ReadOnly == true)
                            {
                                if (pasa == 1)
                                    if (otabla.Rows[x].ItemArray[1].ToString().Equals("1"))
                                        tipo = 1;
                            }
                        }


                        if (pasa == 1)
                        {
                            if (tipo == 1)
                                ModificarExistente();
                            else
                                MessageBox.Show("Factura Ya Existente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            Agregar();

                        limpiar();
                        oConexion.cerrarConexion();
                        llenarGrid();
                        Deshabilitar();
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!txtestado.Text.Equals("FP"))
                    {
                        MessageBox.Show("No se puede Eliminar una factura que no este en estado pendiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dgrDatos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione la factura a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oFacturaDAO = new FacturasPagosDAO();
                        oFacturasPago = new FacturasPago();

                        oFacturasPago.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFacturasPago.Indice = indi;
                        oFacturasPago.NumFactura = txtnumfactura.Text;

                        oFacturaDAO.Eliminar(oFacturasPago);
                        if (oFacturaDAO.Error())
                            MessageBox.Show("Ha ocurrido un error al Eliminar los datos: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        llenarGrid();
                        Deshabilitar();
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}