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
    public partial class frmMenuFinancieros : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private frmPrincipal oPrincipal = frmPrincipal.getInstance();
        private static frmMenuFinancieros instance = null;

        public static frmMenuFinancieros getInstance()
        {
            if (instance == null)
                instance = new frmMenuFinancieros();
            return instance;
        }

        private frmMenuFinancieros()
        {
            InitializeComponent();
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
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.No_cia);
                    if (odataset.Tables[0].Rows[0]["PER_ACCESO"].ToString().Equals("0"))
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenuFinancieros_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPrincipal.MenuEstado();
            instance = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            frmMenu oMenu = frmMenu.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }


        private void btnFacturaCliente_Click(object sender, EventArgs e)
        {
            //frmFacturasPendientesCuentas oFactura = frmFacturasPendientesCuentas.getInstance();
            //codigo = oFactura.Codigo;
            //descripcion = oFactura.Descripcion;
            //modulo = oFactura.Modulo;
            //if (!TienePermiso())
            //{
            //    oFactura.MdiParent = this.MdiParent;
            //    oFactura.Show();
            //}
            //else
            //{
            //    MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    oFactura = null;
            //}
            //this.Close();
        }


        private void btnRecibosDinero_Click(object sender, EventArgs e)
        {
            frmRecibosDineroSencillo oRecibo = frmRecibosDineroSencillo.getInstance();
            codigo = oRecibo.Codigo;
            descripcion = oRecibo.Descripcion;
            modulo = oRecibo.Modulo;
            if (!TienePermiso())
            {
                oRecibo.MdiParent = this.MdiParent;
                oRecibo.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oRecibo = null;
            }
            this.Close();
        }

        private void btnTipoCambio_Click(object sender, EventArgs e)
        {
            try
            {
                frmTiposCambio oTipo = frmTiposCambio.getInstance(1);
                oTipo.MdiParent = this.MdiParent;
                oTipo.Show();

                this.Close();
            }
            catch
            {
                frmTiposCambio oTipo = frmTiposCambio.restartInstance(1);
                oTipo.MdiParent = this.MdiParent;
                oTipo.Show();

                this.Close();
            }
        }

        private void btnCajaChica_Click(object sender, EventArgs e)
        {

            frmCajaChica oPantalla = frmCajaChica.getInstance();
            codigo = oPantalla.Codigo;
            descripcion = oPantalla.Descripcion;
            modulo = oPantalla.Modulo;
            if (!TienePermiso())
            {
                oPantalla.MdiParent = this.MdiParent;
                oPantalla.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oPantalla = null;
            }
            this.Close();
        }

        private void btnFacturaPagoProveedor_Click(object sender, EventArgs e)
        {
            frmFacturaPorPagarProveedor oFactura = frmFacturaPorPagarProveedor.getInstance();
            codigo = oFactura.Codigo;
            descripcion = oFactura.Descripcion;
            modulo = oFactura.Modulo;
            if (!TienePermiso())
            {
                oFactura.MdiParent = this.MdiParent;
                oFactura.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFactura = null;
            }
            this.Close();
        }

        private void btnPagoProveedor_Click(object sender, EventArgs e)
        {
            frmPrepagoProveedor oPrepago = frmPrepagoProveedor.getInstance();
            codigo = oPrepago.Codigo1;
            descripcion = oPrepago.Descripcion;
            modulo = oPrepago.Modulo;
            if (!TienePermiso())
            {
                oPrepago.MdiParent = this.MdiParent;
                oPrepago.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oPrepago = null;
            }
            this.Close();
        }

    }
}