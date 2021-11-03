using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Xml;

namespace PROYECTO
{
    public partial class frmTiposCambio : Form
    {
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
        private TipoCambio oTipo = null;
        private int tipo = 0;
        private static frmTiposCambio instance = null;
        private String codigo, descripcion, modulo;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

        private frmTiposCambio(int ptipo)
        {
            InitializeComponent();
            tipo = ptipo;
        }

        public static frmTiposCambio getInstance(int ptipo)
        {
            if (instance == null)
                instance = new frmTiposCambio(ptipo);
            return instance;
        }

        public static frmTiposCambio restartInstance(int ptipo)
        {
            instance = new frmTiposCambio(ptipo);
            return instance;
        }


        private void tobAgregar_Click(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                Agregar();
            }
            else
            {
                Modificar();
            }
        }

        private void frmTiposCambio_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            String BuscaTC = "";
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    lblFecha.Text = oTipoCambioDAO.fecha().ToShortDateString();
                    DataTable oMensajes = oConexion.EjecutaSentencia("select BuscaTC from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    if (oMensajes.Rows.Count > 0)
                        BuscaTC = oMensajes.Rows[0]["BuscaTC"].ToString();

                    oConexion.cerrarConexion();
                }

                if (BuscaTC.Equals("Venta"))
                    rboVenta.Checked = true;
                else
                    rboCompra.Checked = true;
            }
            catch
            {
            }

            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Tipo de Cambio ";
            if (tipo == 0)
            {
                tobSalir.Visible = false;

                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                lblFecha.Text = oTipoCambioDAO.fecha().ToShortDateString();
                if (((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled)
                    ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = false;

                btnObtenerTipoCambio.PerformClick();
            }
            else
            {
                tobSalir.Visible = true;
                Llenar();
            }

        }

        private void Agregar()
        {
            if (txtDolar.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el tipo de cambio del dolar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDolar.Focus();
                return;
            }

            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                oTipoCambioDAO = new TipoCambioDAO();
                oTipo = new TipoCambio();

                oTipo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oTipo.Fecharegistro = DateTime.Now;
                oTipo.Dolar = Double.Parse(txtDolar.Text);
                oTipo.Usuario = PROYECTO.Properties.Settings.Default.Usuario.ToString();
                oTipoCambioDAO.Agregar(oTipo);
                if (oTipoCambioDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al guardar los datos: " + oTipoCambioDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EmpresaDAO oEmpresaDAO = new EmpresaDAO();
                oEmpresaDAO.ActualizaParametro(PROYECTO.Properties.Settings.Default.No_cia, "BUSCATC", rboCompra.Checked ? "Compra" : "Venta");

                oConexion.cerrarConexion();

                ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = true;


                try
                {
                    if (((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stTC"].Text.Equals("   Dólar: ¢ 0"))
                    {
                        oConexion.cerrarConexion();
                        if (oConexion.abrirConexion())
                        {
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stTC"].Text = "   Dolar: ¢ " + double.Parse(oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString()).ToString("###,###,##0.##");
                            oConexion.cerrarConexion();
                        }
                    }
                }
                catch { }


            }
            else
                MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos.", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Modificar()
        {
            if (txtDolar.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el tipo de cambio del dolar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDolar.Focus();
                return;
            }

            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion(); if (oConexion.abrirConexion())
            {
                oTipoCambioDAO = new TipoCambioDAO();
                oTipo = new TipoCambio();

                oTipo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oTipo.Fecharegistro = Convert.ToDateTime(lblFecha.Text);
                oTipo.Dolar = Double.Parse(txtDolar.Text);
                oTipo.Usuario = PROYECTO.Properties.Settings.Default.Usuario.ToString();
                oTipoCambioDAO.Modificar(oTipo);
                if (oTipoCambioDAO.Error())
                    MessageBox.Show("Ha ocurrido un error al Modificar los datos: " + oTipoCambioDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EmpresaDAO oEmpresaDAO = new EmpresaDAO();
                oEmpresaDAO.ActualizaParametro(PROYECTO.Properties.Settings.Default.No_cia, "BUSCATC", rboCompra.Checked ? "Compra" : "Venta");

                oConexion.cerrarConexion();



                ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = true;

                try
                {
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stTC"].Text = "   Dolar: ¢ " + double.Parse(oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString()).ToString("###,###,##0.##");
                        oConexion.cerrarConexion();
                    }
                }
                catch { }

                this.Close();

            }
            else
                MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos.", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tobSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Llenar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    DataTable oTabla = new DataTable();
                    oTipoCambioDAO = new TipoCambioDAO();
                    oTabla = oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    txtDolar.Text = oTabla.Rows[0].ItemArray[0].ToString();
                    lblFecha.Text = Convert.ToDateTime(oTabla.Rows[0].ItemArray[2].ToString()).ToShortDateString();
                    oConexion.cerrarConexion();
                }
                else
                {
                    oConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void tobNuevo_Click(object sender, EventArgs e)
        {
            txtDolar.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDolar.Text.Equals(""))
                {
                    MessageBox.Show("Ingrese el tipo de cambio del dolar.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDolar.Focus();
                    return;
                }

                if (tipo == 0)
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oTipoCambioDAO = new TipoCambioDAO();
                        oTipo = new TipoCambio();

                        oTipo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oTipo.Fecharegistro = DateTime.Now;
                        oTipo.Dolar = Double.Parse(txtDolar.Text);
                        oTipo.Usuario = PROYECTO.Properties.Settings.Default.Usuario.ToString();
                        oTipoCambioDAO.Agregar(oTipo);
                        if (oTipoCambioDAO.Error())
                            MessageBox.Show("Ha ocurrido un error al guardar los datos: " + oTipoCambioDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = true;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos.", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oTipoCambioDAO = new TipoCambioDAO();
                        oTipo = new TipoCambio();

                        oTipo.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oTipo.Fecharegistro = Convert.ToDateTime(lblFecha.Text);
                        oTipo.Dolar = Double.Parse(txtDolar.Text);
                        oTipo.Usuario = PROYECTO.Properties.Settings.Default.Usuario.ToString();
                        oTipoCambioDAO.Modificar(oTipo);
                        if (oTipoCambioDAO.Error())
                            MessageBox.Show("Ha ocurrido un error al Modificar los datos: " + oTipoCambioDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oConexion.cerrarConexion();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al conectarse a la base de datos.", "Error de oConexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void frmTiposCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
        }

        private void txtDolar_Leave(object sender, EventArgs e)
        {
            if (txtDolar.Text.Trim().Equals("") || txtDolar.Text.Trim().Equals("."))
                txtDolar.Text = "0";
            string monto = "";
            for (int x = 0; x < txtDolar.Text.Length; x++)
            {
                if (!txtDolar.Text[x].Equals(' '))
                    monto += txtDolar.Text[x];
            }
            txtDolar.Text = double.Parse(txtDolar.Text).ToString("###,###,##0.##");
        }

        private void txtDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtDolar.Text.Length; i++)
            {
                if (txtDolar.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnObtenerTipoCambio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(lblFecha.Text))
                {
                    //TipoCambioBCCR.wsIndicadoresEconomicos ws = new TipoCambioBCCR.wsIndicadoresEconomicos();
                    TipoCambioBCCR.wsindicadoreseconomicos ws = new TipoCambioBCCR.wsindicadoreseconomicos();

                    DataTable ot = new DataTable();

                    if (rboCompra.Checked)
                    {
                        DataSet resul1 = ws.ObtenerIndicadoresEconomicos("317", lblFecha.Text, lblFecha.Text, "Johnny Alfaro", "N", "jalfaror26@hotmail.com", "JM266FOHNF");

                        if (resul1 != null)
                        {
                            ot = resul1.Tables[0];
                            txtDolar.Text = Double.Parse(ot.Rows[0].ItemArray[2].ToString()).ToString("###,##0.##");
                        }
                    }
                    else if (rboVenta.Checked)
                    {
                        DataSet resul1 = ws.ObtenerIndicadoresEconomicos("318", lblFecha.Text, lblFecha.Text, "Johnny Alfaro", "N", "jalfaror26@hotmail.com", "JM266FOHNF");

                        if (resul1 != null)
                        {
                            ot = resul1.Tables[0];
                            txtDolar.Text = Double.Parse(ot.Rows[0].ItemArray[2].ToString()).ToString("###,##0.##");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rboCompra_CheckedChanged(object sender, EventArgs e)
        {
            btnObtenerTipoCambio.PerformClick();
        }

        private void rboVenta_CheckedChanged(object sender, EventArgs e)
        {
            btnObtenerTipoCambio.PerformClick();
        }

        private Boolean TienePermiso()
        {
            try
            {
                Boolean tienePermiso = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo, modulo, descripcion, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odataset.Tables[0].Rows[0].ItemArray[0].ToString().Equals("0"))
                        tienePermiso = true;
                    oConexion.cerrarConexion();
                }
                return tienePermiso;
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
                return false;
            }
        }

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (e.KeyCode == Keys.F1)
                    Ayuda();
            }
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t2");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }
    }
}