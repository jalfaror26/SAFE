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
    public partial class frmRollbackPagoProveedor : Form
    {
        private Double montoAnterior;
        private ConexionDAO oConexion = null;
        private PagosProveedoresDAO oPagosDAO = null;
        private FacturasPagosDAO oFacturaDAO = null;
        private char simMoneda = '¢';

        public frmRollbackPagoProveedor(String cod, String prov)
        {
            InitializeComponent();
            txtCodProveedor.Text = cod;
            txtProveedor.Text = prov;
            llenaGrid();
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

                    oFacturaDAO = new FacturasPagosDAO();
                    string moned = "";
                    if (rbtnCol.Checked)
                        moned = "CRC";
                    else if (rbtnUsd.Checked)
                        moned = "USD";


                    DataTable oDataTable = new DataTable();
                    oDataTable.Columns.Add("PRE_ID", typeof(string));
                    oDataTable.Columns.Add("PRE_PROVEEDOR", typeof(string));
                    oDataTable.Columns.Add("PRE_MONEDA", typeof(string));
                    oDataTable.Columns.Add("PRE_FECHA_REGISTRO", typeof(string));
                    oDataTable.Columns.Add("PRE_MONTO_TOTAL", typeof(string));
                    oDataTable.Columns.Add("facturas", typeof(string));


                    String facturas = "";

                    foreach (DataRow OFila in oFacturaDAO.ConsultarGuiasCanceladas(txtCodProveedor.Text, moned, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows)
                    {
                        facturas = "";
                        oDataRow = oDataTable.NewRow();
                        oDataRow["PRE_ID"] = OFila.ItemArray[0].ToString();
                        oDataRow["PRE_PROVEEDOR"] = OFila.ItemArray[1].ToString();
                        oDataRow["PRE_MONEDA"] = OFila.ItemArray[2].ToString();
                        oDataRow["PRE_FECHA_REGISTRO"] = OFila.ItemArray[3].ToString();
                        oDataRow["PRE_MONTO_TOTAL"] = simMoneda + double.Parse(OFila.ItemArray[4].ToString()).ToString(" ###,###,##0.##");

                        foreach (DataRow oFacturas in oConexion.EjecutaSentencia("SELECT distinct DETPRE_FACTURA from TBL_DETALLE_PREPAGO DPP WHERE dpp.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETPRE_PREPAGO= '" + OFila.ItemArray[0].ToString() + "' order by DETPRE_FACTURA").Rows)
                        {
                            if (!facturas.Equals(""))
                                facturas += ", ";
                            facturas += oFacturas.ItemArray[0].ToString();
                        }
                        oDataRow["facturas"] = facturas;

                        oDataTable.Rows.Add(oDataRow.ItemArray);
                    }

                    dgrDatos.DataSource = oDataTable;
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer las guias: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void llenaGrid(int tipo, String palabra)
        {
            try
            {
                DataRow oDataRow = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {

                    oFacturaDAO = new FacturasPagosDAO();
                    string moned = "";
                    if (rbtnCol.Checked)
                        moned = "CRC";
                    else                        if (rbtnUsd.Checked)
                        moned = "USD";
                             


                    DataTable oDataTable = new DataTable();
                    oDataTable.Columns.Add("PRE_ID", typeof(string));
                    oDataTable.Columns.Add("PRE_PROVEEDOR", typeof(string));
                    oDataTable.Columns.Add("PRE_MONEDA", typeof(string));
                    oDataTable.Columns.Add("PRE_FECHA_REGISTRO", typeof(string));
                    oDataTable.Columns.Add("PRE_MONTO_TOTAL", typeof(string));
                    oDataTable.Columns.Add("facturas", typeof(string));
                    String facturas = "";
                    foreach (DataRow OFila in oFacturaDAO.ConsultarGuiasCanceladas(txtCodProveedor.Text, moned, tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows)
                    {
                        facturas = "";
                        oDataRow = oDataTable.NewRow();
                        oDataRow["PRE_ID"] = OFila.ItemArray[0].ToString();
                        oDataRow["PRE_PROVEEDOR"] = OFila.ItemArray[1].ToString();
                        oDataRow["PRE_MONEDA"] = OFila.ItemArray[2].ToString();
                        oDataRow["PRE_FECHA_REGISTRO"] = OFila.ItemArray[3].ToString();
                        oDataRow["PRE_MONTO_TOTAL"] = simMoneda + double.Parse(OFila.ItemArray[4].ToString()).ToString(" ###,###,##0.##");

                        foreach (DataRow oFacturas in oConexion.EjecutaSentencia("SELECT distinct DETPRE_FACTURA from TBL_DETALLE_PREPAGO DPP WHERE dpp.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and DETPRE_PREPAGO= '" + OFila.ItemArray[0].ToString() + "' order by DETPRE_FACTURA").Rows)
                        {
                            if (!facturas.Equals(""))
                                facturas += ", ";
                            facturas += oFacturas.ItemArray[0].ToString();
                        }
                        oDataRow["facturas"] = facturas;

                        oDataTable.Rows.Add(oDataRow.ItemArray);
                    }

                    dgrDatos.DataSource = oDataTable;
                    if (oFacturaDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer las guias: " + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmRollbackPagoProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrepagoProveedor.getInstance().Enabled = true;
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnCol_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCol.Checked)
            {
                simMoneda = '¢';
                llenaGrid();
                txtBFecha.Clear();
                txtBFacturas.Clear();
                txtBGuia.Clear();
            }
        }

        private void rbtnUsd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUsd.Checked)
            {
                simMoneda = '$';
                llenaGrid();
                txtBFecha.Clear();
                txtBFacturas.Clear();
                txtBGuia.Clear();
            }
        }
        
        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnCancelarPagos.Enabled = true;
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnCancelarPagos.Enabled = false;
            dgrDatos.ClearSelection();
        }

        private void txtBGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtBGuia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtBFecha.Clear();
                txtBFacturas.Clear();
                if (txtBGuia.Text.Trim().Equals(""))
                    llenaGrid();
                else
                    llenaGrid(1, txtBGuia.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBFecha_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtBFacturas.Clear();
                txtBGuia.Clear();
                if (txtBFecha.Text.Trim().Equals(""))
                    llenaGrid();
                else
                    llenaGrid(2, txtBFecha.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBFacturas_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtBFecha.Clear();
                txtBGuia.Clear();

                if (txtBFacturas.Text.Trim().Equals(""))
                    llenaGrid();
                else
                    llenaGrid(3, txtBFacturas.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancelarPagos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro a Cancelar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Esta seguro que desea Cancelar el Pago de las facturas: " + dgrDatos.SelectedRows[0].Cells["facturas"].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oPagosDAO = new PagosProveedoresDAO();

                        oPagosDAO.Cancelar(int.Parse(dgrDatos.SelectedRows[0].Cells["PRE_ID"].Value.ToString()), PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);

                        if (oPagosDAO.Error())
                            MessageBox.Show("Ocurrió un error al Cancelar el pago.\n " + oPagosDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Realizado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        oConexion.cerrarConexion();
                        llenaGrid();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

    }
}