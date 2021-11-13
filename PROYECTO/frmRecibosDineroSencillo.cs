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
using System.IO;

namespace PROYECTO
{
    public partial class frmRecibosDineroSencillo : Form
    {
        private ConexionDAO oConexion = null;
        private static frmRecibosDineroSencillo oRecibosDinero = null;
        private RecibosDineroDAO oReciboDAO = null;
        private ReciboDinero oRecibo = null;
        private CancelacionFacturasDAO oCancelacionDAO = null;
        private Transaccion oTransaccion = null;
        private Boolean listo = false;
        private char simmoneda = '¢';
        private String codigo = "pro_RecDinero", descripcion = "Registro de recibos de dinero.", modulo = "Procesos";

        private Double montoAnterior;

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


        public frmRecibosDineroSencillo()
        {
            InitializeComponent();
        }

        public static frmRecibosDineroSencillo getInstance()
        {
            if (oRecibosDinero == null)
                oRecibosDinero = new frmRecibosDineroSencillo();
            return oRecibosDinero;
        }

        public void llenaDatosCliente(String id, String nombre)
        {
            txtIdCliente.Text = id;
            txtNombre.Text = nombre;
            // btnnuevo.PerformClick();

            llenaGridFacturas();

            if (txtNumRecibo.Text.Equals(""))
            {
                LlenarRecibo();
                txtNumRecibo.Focus();
            }
            else
                txtMonto.Focus();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("Cuentas");
            oConsulta.Show();
        }

        private void btnBusq2_Click(object sender, EventArgs e)
        {
            frmConsulta oConsulta = frmConsulta.getInstance("ClienteRecibo");
            oConsulta.MdiParent = frmPrincipal.getInstance().MdiParent;
            oConsulta.ShowDialog();
        }

        public void llenaGrid()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oReciboDAO = new RecibosDineroDAO();
                    int estado = 0;
                    if (cboFiltro.SelectedIndex == -1)
                        cboFiltro.SelectedIndex = 0;
                    estado = cboFiltro.SelectedIndex;

                    dgrDatos.DataSource = oReciboDAO.consultar(txtIdCliente.Text, estado, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oReciboDAO.Error())
                        MessageBox.Show("Ocurrió un error al listar lo datos: " + oReciboDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNumRecibo.Text = dgrDatos["Id", e.RowIndex].Value.ToString();
                cmbFormaPago.SelectedItem = dgrDatos["rec_forma_pago", e.RowIndex].Value.ToString();
                if (dgrDatos["rec_estatus", e.RowIndex].Value.ToString().Equals("SA"))
                    txtEstado.Text = "SIN ACREDITAR";
                else if (dgrDatos["rec_estatus", e.RowIndex].Value.ToString().Equals("AC"))
                    txtEstado.Text = "ACREDITADO";
                else if (dgrDatos["rec_estatus", e.RowIndex].Value.ToString().Equals("FH"))
                    txtEstado.Text = "EN HISTORIA";
                txtMonto.Text = simmoneda + " " + Double.Parse(dgrDatos["rec_monto", e.RowIndex].Value.ToString()).ToString("###,###,##0.00");

                txtIndice.Text = dgrDatos["REC_INDICE", e.RowIndex].Value.ToString();

                btnBusq2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al extraer los datos: " + ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void Agregar()
        {
            try
            {
                if (Existente())
                {
                    MessageBox.Show("Error al agregar:\nRecibo Existente", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnnuevo.PerformClick();
                    return;
                }
                else if (txtIdCliente.Text.Equals(""))
                {
                    MessageBox.Show("Seleccione el cliente del recibo.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtNumRecibo.Text.Equals(""))
                {
                    MessageBox.Show("Digite el numero del recibo.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (double.Parse(txtMonto.Text.Substring(1)) == 0)
                {
                    MessageBox.Show("El monto del recibo debe ser mayor a 0.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oRecibo = new ReciboDinero();
                    oReciboDAO = new RecibosDineroDAO();

                    oRecibo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oRecibo.Cliente = int.Parse(txtIdCliente.Text);
                    oRecibo.Numero = int.Parse(txtNumRecibo.Text);
                    oRecibo.FormaPago = cmbFormaPago.SelectedItem.ToString();
                    oRecibo.Moneda = cmbMoneda.Text;
                    oRecibo.Detalle = "";
                    oRecibo.TipoCambio = 1;
                    oRecibo.Monto = Double.Parse(txtMonto.Text.Trim().Substring(1));
                    oRecibo.FechaDoc = oConexion.fecha();
                    oRecibo.Estatus = "SA";
                    oRecibo.Saldo = Double.Parse(txtMonto.Text.Trim().Substring(1));
                    oRecibo.Tipodoc = "RD Recibo de Dinero";
                    oRecibo.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oRecibo.FechaRegistro = DateTime.Parse(txtfechaactual.Text);
                    oRecibo.TipoIngreso = "";
                    oReciboDAO.Agregar(oRecibo);
                    if (oReciboDAO.Error())
                    {
                        MessageBox.Show("Ocurrió un error al guardar lo datos: " + oReciboDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        MessageBox.Show("Guardado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gboPendientes.Visible = true;

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();

                    DataTable ot = oConexion.EjecutaSentencia("SELECT REC_NUMERO, rec_forma_pago, rec_estatus, rec_monto,REC_SALDO, REC_INDICE FROM TBL_RECIBOS_DINERO RD WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_NUMERO=(SELECT MAX(REC_NUMERO) FROM TBL_RECIBOS_DINERO RD WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_ESTADO=1)");
                    if (ot.Rows.Count > 0)
                    {
                        if (ot.Rows[0]["REC_NUMERO"].ToString().Equals(""))
                        {
                            txtNumRecibo.BackColor = System.Drawing.Color.White;
                            txtNumRecibo.ReadOnly = false;
                            txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            txtNumRecibo.Text = (int.Parse(ot.Rows[0]["REC_NUMERO"].ToString()) + 1) + "";

                            if (ot.Rows[0]["rec_estatus"].ToString().Equals("SA"))
                            {
                                cmbFormaPago.SelectedItem = ot.Rows[0]["rec_forma_pago"].ToString();
                                txtNumRecibo.Text = ot.Rows[0]["REC_NUMERO"].ToString();
                                txtMonto.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["rec_monto"].ToString()).ToString("###,###,##0.00");
                                txtDisponible.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["REC_SALDO"].ToString()).ToString("###,###,##0.00");

                                txtIndice.Text = ot.Rows[0]["REC_INDICE"].ToString();
                                txtEstado.Text = "SIN ACREDITAR";
                            }

                            txtNumRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                            txtNumRecibo.ReadOnly = true;
                            txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    else
                    {
                        txtNumRecibo.BackColor = System.Drawing.Color.White;
                        txtNumRecibo.ReadOnly = false;
                        txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                    }
                    CalculaTotalAbonos();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void frmRecibosDineroSencillo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                cmbTipoPago.Enabled = false;
                btnCancelar.Visible = false;
                txtDisponible.Text = "0.00";
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                oReciboDAO = new RecibosDineroDAO();
                DateTime fecha = DateTime.Parse(oReciboDAO.Fecha().ToShortDateString());
                txtfechaactual.Text = fecha.ToShortDateString();
                oConexion.cerrarConexion();
                limpiar();

                cmbTipoPago.SelectedIndex = 0;

                LlenarRecibo();
                CalculaTotalAbonos();
                listo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void frmRecibosDineroSencillo_FormClosing(object sender, FormClosingEventArgs e)
        {
            oRecibosDinero = null;
        }

        private void limpiar()
        {
            txtNumRecibo.Text = "";
            cmbFormaPago.SelectedIndex = 1;
            cmbMoneda.SelectedIndex = 0;
            txtEstado.Text = "";
            txtMonto.Text = "¢ 0";
            txtNumRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            txtNumRecibo.ReadOnly = true;
            txtNumRecibo.ForeColor = System.Drawing.Color.Black;

            dgrDatos.ClearSelection();
        }

        private void LlenarRecibo()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                DataTable ot = oConexion.EjecutaSentencia("SELECT REC_NUMERO, rec_forma_pago, rec_estatus, rec_monto, REC_SALDO, REC_INDICE, c.cli_linea, c.cli_nombre, rec_moneda FROM TBL_RECIBOS_DINERO RD, tbl_clientes c WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and rd.no_cia = c.no_cia and rd.rec_cliente = c.cli_linea and REC_NUMERO=(SELECT MAX(REC_NUMERO) FROM TBL_RECIBOS_DINERO RD WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_ESTADO=1)");
                if (ot.Rows.Count > 0)
                {
                    if (ot.Rows[0]["REC_NUMERO"].ToString().Equals(""))
                    {
                        txtNumRecibo.BackColor = System.Drawing.Color.White;
                        txtNumRecibo.ReadOnly = false;
                        txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        txtNumRecibo.Text = (int.Parse(ot.Rows[0]["REC_NUMERO"].ToString()) + 1) + "";

                        if (ot.Rows[0]["rec_estatus"].ToString().Equals("SA"))
                        {
                            cmbFormaPago.SelectedItem = ot.Rows[0]["rec_forma_pago"].ToString();
                            txtNumRecibo.Text = ot.Rows[0]["REC_NUMERO"].ToString();
                            txtMonto.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["rec_monto"].ToString()).ToString("###,###,##0.00");
                            txtDisponible.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["REC_SALDO"].ToString()).ToString("###,###,##0.00");

                            txtIndice.Text = ot.Rows[0]["REC_INDICE"].ToString();
                            txtEstado.Text = "SIN ACREDITAR";
                            cmbMoneda.SelectedItem = ot.Rows[0]["rec_moneda"].ToString();

                            llenaDatosCliente(ot.Rows[0]["cli_linea"].ToString(), ot.Rows[0]["cli_nombre"].ToString());
                        }

                        gboPendientes.Visible = true;
                    }
                }
                else
                {
                    gboPendientes.Visible = false;
                    txtNumRecibo.BackColor = System.Drawing.Color.White;
                    txtNumRecibo.ReadOnly = false;
                    txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            btnBusq2.Enabled = true;
            cboFiltro.SelectedIndex = 0;
            LlenarRecibo();
            if (txtNumRecibo.Text.Equals(""))
                txtNumRecibo.Focus();
        }

        private void Modificar()
        {
            try
            {
                //if (dgrDatos.SelectedCells.Count == 0)
                //{
                //    MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (txtIdCliente.Text.Equals(""))
                {
                    MessageBox.Show("Seleccione el cliente del recibo.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (double.Parse(txtMonto.Text.Substring(1)) == 0)
                {
                    MessageBox.Show("El monto del recibo debe ser mayor a 0.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtNumRecibo.Text.Equals(""))
                {
                    MessageBox.Show("Digite el numero del recibo.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!txtEstado.Text.Equals("SIN ACREDITAR"))
                {
                    MessageBox.Show("No se puede Modificar un recibo que no este en estado: SIN ACREDITAR.", "No se puede Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtIndice.Text.Equals(""))
                {
                    MessageBox.Show("Seleccione el registro a Modificar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oRecibo = new ReciboDinero();
                    oReciboDAO = new RecibosDineroDAO();

                    oRecibo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oRecibo.Numero = int.Parse(txtNumRecibo.Text);
                    oRecibo.Monto = Double.Parse(txtMonto.Text.Substring(1));
                    oRecibo.Moneda = cmbMoneda.Text;
                    oRecibo.Detalle = "";
                    oRecibo.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oRecibo.Indice = int.Parse(txtIndice.Text);
                    oRecibo.FormaPago = cmbFormaPago.SelectedItem.ToString();

                    oReciboDAO.Modificar(oRecibo);
                    if (oReciboDAO.Error())
                        MessageBox.Show("Ocurrió un error al guardar lo datos: " + oReciboDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Modificado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();

                    DataTable ot = oConexion.EjecutaSentencia("SELECT REC_NUMERO, rec_forma_pago, rec_estatus, rec_monto,REC_SALDO, REC_INDICE FROM TBL_RECIBOS_DINERO RD WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_NUMERO=(SELECT MAX(REC_NUMERO) FROM TBL_RECIBOS_DINERO RD WHERE rd.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_ESTADO=1)");
                    if (ot.Rows.Count > 0)
                    {
                        if (ot.Rows[0]["REC_NUMERO"].ToString().Equals(""))
                        {
                            txtNumRecibo.BackColor = System.Drawing.Color.White;
                            txtNumRecibo.ReadOnly = false;
                            txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            txtNumRecibo.Text = (int.Parse(ot.Rows[0]["REC_NUMERO"].ToString()) + 1) + "";

                            if (ot.Rows[0]["rec_estatus"].ToString().Equals("SA"))
                            {
                                cmbFormaPago.SelectedItem = ot.Rows[0]["rec_forma_pago"].ToString();
                                txtNumRecibo.Text = ot.Rows[0]["REC_NUMERO"].ToString();
                                txtMonto.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["rec_monto"].ToString()).ToString("###,###,##0.00");
                                txtDisponible.Text = simmoneda + " " + Double.Parse(ot.Rows[0]["REC_SALDO"].ToString()).ToString("###,###,##0.00");

                                txtIndice.Text = ot.Rows[0]["REC_INDICE"].ToString();
                                txtEstado.Text = "SIN ACREDITAR";
                            }

                            txtNumRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                            txtNumRecibo.ReadOnly = true;
                            txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    else
                    {
                        txtNumRecibo.BackColor = System.Drawing.Color.White;
                        txtNumRecibo.ReadOnly = false;
                        txtNumRecibo.ForeColor = System.Drawing.Color.Black;
                    }

                    gboPendientes.Visible = true;
                    CalculaTotalAbonos();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrDatos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtNumRecibo.Text.Equals(""))
                    {
                        MessageBox.Show("Digite el numero del recibo a Eliminar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (!txtEstado.Text.Equals("SIN ACREDITAR"))
                    {
                        MessageBox.Show("No se puede Eliminar un recibo que no este en estado: SIN ACREDITAR.", "No se puede Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (txtIndice.Text.Equals(""))
                    {
                        MessageBox.Show("Seleccione el registro a Modificar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oRecibo = new ReciboDinero();
                        oReciboDAO = new RecibosDineroDAO();

                        oRecibo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oRecibo.Numero = int.Parse(txtNumRecibo.Text);
                        oRecibo.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                        oRecibo.Indice = int.Parse(txtIndice.Text);
                        oReciboDAO.Eliminar(oRecibo);
                        if (oReciboDAO.Error())
                            MessageBox.Show("Ocurrió un error al Eliminar lo datos: " + oReciboDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Eliminado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        llenaGrid();
                        btnnuevo.PerformClick();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            oRecibosDinero = null;
            this.Close();
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private Boolean Existente()
        {
            Boolean existe = false;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
            {
                if (oFila.Cells["Id"].Value.ToString().Equals(txtNumRecibo.Text))
                    existe = true;
            }
            return existe;
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtMonto.ReadOnly == false)
                {
                    string monto = txtMonto.Text;
                    if (txtMonto.ReadOnly == false)
                    {
                        txtMonto.Text = double.Parse(monto.Substring(1)).ToString("#########0.00");

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string monto = "";
                int puntos = 0;
                for (int x = 0; x < txtMonto.Text.Length; x++)
                {
                    if (!txtMonto.Text[x].Equals(' '))
                        monto += txtMonto.Text[x];
                }

                if (txtMonto.Text.Length > 0)
                {
                    for (int i = 0; i < monto.Length; i++)
                    {
                        if (monto[i].Equals('.'))
                            puntos++;
                        if (Char.IsLetter(monto[i]) || Char.IsSymbol(monto[i]) || monto[i].Equals(',') || monto[i].Equals('.') && puntos > 1)
                        {
                            monto = monto.Remove(i, 1);
                        }
                    }
                    txtMonto.Text = monto;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            try
            {
                string monto = "";

                if (txtMonto.Text.Trim().Equals("") || txtMonto.Text.Trim().Equals("."))
                    txtMonto.Text = "0.00";
                for (int x = 0; x < txtMonto.Text.Length; x++)
                {
                    if (!txtMonto.Text[x].Equals(' '))
                        monto += txtMonto.Text[x];
                }
                txtMonto.Text = simmoneda + " " + double.Parse(monto).ToString("###,###,##0.00");

                if (!txtIndice.Text.Equals("") || (!txtNumRecibo.ReadOnly && !txtNumRecibo.Text.Equals("")) || (txtNumRecibo.ReadOnly && !txtNumRecibo.Text.Equals("")))
                    btnGuardar.PerformClick();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtNumRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltro.SelectedIndex == 0)
            {
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;
                gboCancelados.Visible = false;
                gboPendientes.Visible = true;
            }
            else
            {
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                if (!txtIdCliente.Text.Equals(""))
                    btnCancelar.Enabled = true;
                else
                    btnCancelar.Enabled = false;

                gboCancelados.Visible = true;
                gboPendientes.Visible = false;
                dgrDatos.Visible = true;
            }
            llenaGrid();
            llenaGridFacturas();
        }

        public void llenaGridFacturas()
        {
            try
            {
                txtDisponible.Text = txtMonto.Text;

                DataTable oDataTable = new DataTable();
                DataRow oDataRow = null;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oDataTable.Columns.Add("factura", typeof(string));
                    oDataTable.Columns.Add("moneda", typeof(string));
                    oDataTable.Columns.Add("tc", typeof(string));
                    oDataTable.Columns.Add("monto", typeof(string));
                    oDataTable.Columns.Add("retencion", typeof(string));
                    oDataTable.Columns.Add("montoRet", typeof(string));
                    oDataTable.Columns.Add("saldo", typeof(string));
                    oDataTable.Columns.Add("montoabono", typeof(string));
                    oDataTable.Columns.Add("saldoActual", typeof(string));
                    oDataTable.Columns.Add("fechaFac", typeof(string));
                    oDataTable.Columns.Add("fechavence", typeof(string));
                    oDataTable.Columns.Add("FACP_TIPODOCUMENTO", typeof(string));


                    oCancelacionDAO = new CancelacionFacturasDAO();
                    foreach (DataRow OFila in oCancelacionDAO.Consulta(txtIdCliente.Text, PROYECTO.Properties.Settings.Default.No_cia, cmbMoneda.Text).Tables[0].Rows)
                    {
                        oDataRow = oDataTable.NewRow();
                        oDataRow["factura"] = OFila.ItemArray[0].ToString();
                        oDataRow["moneda"] = OFila.ItemArray[1].ToString();
                        oDataRow["tc"] = OFila.ItemArray[2].ToString();
                        oDataRow["monto"] = OFila.ItemArray[3].ToString();
                        oDataRow["retencion"] = OFila.ItemArray[4].ToString();
                        oDataRow["montoRet"] = OFila.ItemArray[5].ToString();
                        oDataRow["saldo"] = OFila.ItemArray[6].ToString();
                        oDataRow["montoabono"] = "0";
                        oDataRow["saldoActual"] = OFila.ItemArray[6].ToString();
                        oDataRow["fechaFac"] = OFila.ItemArray[7].ToString();
                        oDataRow["fechavence"] = OFila.ItemArray[8].ToString();
                        oDataRow["FACP_TIPODOCUMENTO"] = OFila["FACP_TIPODOCUMENTO"].ToString();

                        oDataTable.Rows.Add(oDataRow.ItemArray);
                    }

                    dgrFacturas.DataSource = oDataTable;
                    if (oCancelacionDAO.Error())
                        MessageBox.Show("Ha ocurrido un error al extraer las facturas: " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();

                    CalculaTotalAbonos();
                }
                else
                    MessageBox.Show("Ha ocurrido al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumRecibo.Text.Equals(""))
                {
                    MessageBox.Show("Digite el numero del recibo a Eliminar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtIndice.Text.Equals(""))
                {
                    MessageBox.Show("Seleccione el registro a Modificar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oTabla = oConexion.EjecutaSentencia("SELECT tra_num_factura, tra_documento, tra_caja FROM TBL_TRANSACCION T where t.no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and tra_id_cliente= '" + txtIdCliente.Text + "'" + " and tra_documento= '" + txtNumRecibo.Text + "' AND TRA_ESTADO=1");

                    String facturas = "";
                    foreach (DataRow oFila in oTabla.Rows)
                    {
                        if (!facturas.Equals(""))
                            facturas += ", ";
                        facturas += oFila.ItemArray[0].ToString();
                    }

                    if (MessageBox.Show("¿Está seguro que desea cancelar las transacciones del registro?\n Facturas: " + facturas, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oConexion.cerrarConexion();
                        oConexion.abrirConexion();
                        oRecibo = new ReciboDinero();
                        oReciboDAO = new RecibosDineroDAO();

                        oRecibo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oRecibo.Numero = int.Parse(txtNumRecibo.Text);
                        oRecibo.Cliente = int.Parse(txtIdCliente.Text);
                        oReciboDAO.Cancelar(oRecibo);
                        if (oReciboDAO.Error())
                            MessageBox.Show("Ocurrió un error al cancelar las transacciones lo datos: " + oReciboDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Realizado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        oConexion.cerrarConexion();
                        llenaGrid();
                    }
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error verifique que los datos esten correctos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oConexion.cerrarConexion();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listo)
            {
                if (txtIndice.Text.Equals(""))
                    Agregar();
                else
                    Modificar();
            }
        }

        private void dgrFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            operacion(e.ColumnIndex, e.RowIndex);
        }

        private void operacion(int col, int fil)
        {
            try
            {
                if (col == 0)
                {
                    Double monto = 0;
                    DataTable oTable = new DataTable();
                    oTable = (DataTable)dgrFacturas.DataSource;
                    DataRow ofila = oTable.Rows[fil];
                    monto = Double.Parse(dgrFacturas.Rows[fil].Cells["dataGridViewTextBoxColumn3"].Value.ToString());
                    Double montoTotalRecibo = 0;
                    Double saldo = 0;
                    if (ofila["moneda"].ToString().Equals("CRC"))
                        montoTotalRecibo = Double.Parse(txtDisponible.Text.Substring(1));

                    if (dgrFacturas[7, fil].Value.ToString().Equals("0") || dgrFacturas[7, fil].Value.ToString().Equals(""))
                    {
                        if (montoTotalRecibo <= 0)
                        {
                            MessageBox.Show("Ya ha utilizado el monto del recibo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        saldo = Double.Parse(dgrFacturas[8, fil].Value.ToString());
                        if (montoTotalRecibo > saldo)
                        {
                            dgrFacturas[7, fil].Value = saldo.ToString();
                            dgrFacturas[8, fil].Value = Double.Parse("0").ToString();
                            dgrFacturas.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            dgrFacturas.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            saldo -= montoTotalRecibo;
                            dgrFacturas[7, fil].Value = montoTotalRecibo.ToString();
                            dgrFacturas[8, fil].Value = saldo.ToString();
                            dgrFacturas.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            dgrFacturas.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    else
                    {
                        if (Double.Parse(dgrFacturas[7, fil].Value.ToString()) > 0)
                        {
                            dgrFacturas[8, fil].Value = (Double.Parse(dgrFacturas[8, fil].Value.ToString()) + Double.Parse(dgrFacturas[7, fil].Value.ToString()));
                        }
                        dgrFacturas[7, fil].Value = Double.Parse("0").ToString();
                        dgrFacturas.Rows[fil].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dgrFacturas.Rows[fil].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    CalculaTotalAbonos();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgrFacturas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    String valor = dgrFacturas.Rows[e.RowIndex].Cells[7].Value.ToString();
                    for (int x = 0; x < valor.Length; x++)
                    {
                        if (!char.IsNumber(valor[x]))
                        {
                            valor = "0";
                            dgrFacturas.Rows[e.RowIndex].Cells[7].Value = valor;
                            break;
                        }
                    }

                    if (valor.Equals(""))
                        valor = "0";

                    Double montoAbono = Double.Parse(valor);
                    if (montoAbono != montoAnterior)
                    {
                        if (dgrFacturas.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("CRC"))
                        {
                            if (montoAbono > Double.Parse(dgrFacturas.Rows[e.RowIndex].Cells[6].Value.ToString()))
                            {
                                MessageBox.Show("No se puede realizar este abono, exede el saldo de la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgrFacturas.Rows[e.RowIndex].Cells[8].Value = dgrFacturas.Rows[e.RowIndex].Cells[6].Value;
                                dgrFacturas.Rows[e.RowIndex].Cells[7].Value = "0";
                                dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                                CalculaTotalAbonos();
                                return;
                            }
                            else if ((Double.Parse(txtTotalAbonos.Text.Substring(1)) - montoAnterior + montoAbono) <= Double.Parse(txtMonto.Text.Substring(1)))
                            {
                                dgrFacturas.Rows[e.RowIndex].Cells[8].Value = Double.Parse(dgrFacturas.Rows[e.RowIndex].Cells[6].Value.ToString()) - montoAbono;
                                if (montoAbono > 0)
                                {
                                    dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                                    dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                                }
                                else
                                {
                                    dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                    dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                                }

                                CalculaTotalAbonos();
                            }
                            else
                            {
                                MessageBox.Show("El monto del abono no puede ser mayor al disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgrFacturas.Rows[e.RowIndex].Cells[8].Value = dgrFacturas.Rows[e.RowIndex].Cells[6].Value;
                                dgrFacturas.Rows[e.RowIndex].Cells[7].Value = "0";
                                dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                dgrFacturas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                                CalculaTotalAbonos();
                                return;
                            }
                        }
                    }

                }
            }
            catch { }
        }

        private void CalculaTotalAbonos()
        {
            double disponible = 0;
            Double numero = 0;
            foreach (DataGridViewRow oFila in dgrFacturas.Rows)
            {
                String valor = oFila.Cells[7].Value.ToString();

                if (valor.Equals(""))
                    valor = "0";

                numero += Double.Parse(valor);
            }
            if (numero >= 1 || numero <= -1)
            {
                txtTotalAbonos.Text = simmoneda + numero.ToString(" ###,###,##0.00");
                disponible = Double.Parse(txtMonto.Text.Substring(1)) - numero;

                if (disponible >= 0)
                    txtDisponible.Text = simmoneda + disponible.ToString(" ###,###,##0.00");
                else
                {
                    txtDisponible.Text = simmoneda + " 0.00";
                    txtTotalAbonos.Text = txtMonto.Text;
                }
            }
            else
            {
                txtTotalAbonos.Text = simmoneda + " 0.00";
                txtDisponible.Text = txtMonto.Text;
                disponible = Double.Parse(txtDisponible.Text.Substring(1));
            }

            if (disponible == 0)
            {
                btnTransaccionar.Enabled = true;
                txtDisponible.BackColor = System.Drawing.Color.Green;
            }
            else if (disponible < 0)
            {
                btnTransaccionar.Enabled = false;
                txtDisponible.BackColor = System.Drawing.Color.Red;
            }
            else if (disponible > 0)
            {
                btnTransaccionar.Enabled = false;
                txtDisponible.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            }
        }

        private void dgrFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                montoAnterior = Double.Parse(dgrFacturas.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
            catch
            {
            }
        }

        private Double sumarAbonos()
        {
            try
            {
                Double abonos = 0;
                if (dgrFacturas.Rows.Count > 0)
                {
                    foreach (DataGridViewRow ofila in dgrFacturas.Rows)
                    {
                        abonos += Double.Parse(ofila.Cells["montoabono"].Value.ToString());
                    }
                }
                return abonos;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMoneda.SelectedIndex)
            {
                case 0:
                    simmoneda = '¢';
                    break;
                case 1:
                    simmoneda = '$';
                    break;
            }
            txtMonto.Text = simmoneda + " " + double.Parse(txtMonto.Text.Substring(1)).ToString("###,###,##0.00");

            if (!txtIndice.Text.Equals("") || (!txtNumRecibo.ReadOnly && !txtNumRecibo.Text.Equals("")) || (txtNumRecibo.ReadOnly && !txtNumRecibo.Text.Equals("")))
                btnGuardar.PerformClick();
        }

        private void btnTransaccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sumarAbonos() == 0)
                {
                    MessageBox.Show("No se pueden generar transacciones si no hay montos a abonar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    foreach (DataGridViewRow ofila in dgrFacturas.Rows)
                    {
                        if (Double.Parse(ofila.Cells[7].Value.ToString()) != 0)
                        {
                            oCancelacionDAO = new CancelacionFacturasDAO();
                            oTransaccion = new Transaccion();

                            oTransaccion.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                            oTransaccion.FechaRegistro = DateTime.Parse(txtfechaactual.Text);
                            oTransaccion.IdCliente = int.Parse(txtIdCliente.Text);
                            oTransaccion.NumFactura = ofila.Cells[0].Value.ToString();
                            oTransaccion.Tipotransaccion = "RD RECIBO DE DINERO";
                            oTransaccion.NumDocumento = int.Parse(txtNumRecibo.Text);
                            oTransaccion.Monto = Double.Parse(ofila.Cells[7].Value.ToString());
                            oTransaccion.Moneda = ofila.Cells[1].Value.ToString();

                            if (Double.Parse(ofila.Cells[8].Value.ToString()) == 0)
                                oTransaccion.Texto = "CANCELACION DE LA FACTURA";
                            else
                                oTransaccion.Texto = "ABONO A LA FACTURA";
                            oTransaccion.SaldoAnterior = Double.Parse(ofila.Cells[6].Value.ToString());
                            oTransaccion.SaldoActual = Double.Parse(ofila.Cells[8].Value.ToString());
                            oTransaccion.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                            oCancelacionDAO.insertar(oTransaccion);
                            if (oCancelacionDAO.Error())
                                MessageBox.Show("Ocurrió un error al guardar la transaccion de la factura " + oTransaccion.NumFactura.ToString() + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            oCancelacionDAO.modificaFacturas(oTransaccion, cmbTipoPago.Text.ToUpper());
                            if (oCancelacionDAO.Error())
                                MessageBox.Show("Ocurrió un error al Modificar el saldo de la factura " + oTransaccion.NumFactura.ToString() + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }


                    String cadena = "";
                    if (txtTotalAbonos.Text.StartsWith("-"))
                    {
                        if (txtTotalAbonos.Text.Substring(1).StartsWith("¢") || txtTotalAbonos.Text.Substring(1).StartsWith("$") || txtTotalAbonos.Text.Substring(1).StartsWith("€"))
                            cadena = "-" + txtTotalAbonos.Text.Substring(3);
                    }
                    else
                        if (txtTotalAbonos.Text.StartsWith("¢") || txtTotalAbonos.Text.StartsWith("$") || txtTotalAbonos.Text.StartsWith("€"))
                        cadena = txtTotalAbonos.Text.Substring(1);
                    else
                        cadena = txtTotalAbonos.Text;

                    double v = Double.Parse(txtMonto.Text.Substring(1)) - Double.Parse(cadena);

                    oCancelacionDAO.modificaRecibos(int.Parse(txtNumRecibo.Text), v, PROYECTO.Properties.Settings.Default.Usuario, cmbTipoPago.Text, PROYECTO.Properties.Settings.Default.No_cia);

                    if (oCancelacionDAO.Error())
                        MessageBox.Show("Ocurrió un error al Modificar el saldo del recibo " + txtNumRecibo.Text + ": " + oCancelacionDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Transacción Realizada Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    oConexion.cerrarConexion();

                    //llenaGrid();
                    //if (cmbTipoPago.Text.Equals("CANCELACION") || txtDisponible.Text.Equals("¢ 0"))
                    this.Close();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtNumRecibo_Leave(object sender, EventArgs e)
        {
            if (!txtNumRecibo.ReadOnly && !txtNumRecibo.Text.Equals(""))
            {
                if (double.Parse(txtMonto.Text.Substring(1)) == 0)
                    txtMonto.Focus();
                else
                    btnGuardar.PerformClick();
            }
        }

    }
}