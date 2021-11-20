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
    public partial class frmMenu : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private frmPrincipal oPrincipal = frmPrincipal.getInstance();
        private static frmMenu instance = null;

        public static frmMenu getInstance()
        {
            if (instance == null)
                instance = new frmMenu();
            return instance;
        }

        public void QuitarTodos(String pPanelVisible)
        {
            try
            {
                if (!pPrincipal.Name.Equals(pPanelVisible))
                    pPrincipal.Visible = false;
                if (!pReportes.Name.Equals(pPanelVisible))
                    pReportes.Visible = false;
                if (!pRepPagos.Name.Equals(pPanelVisible))
                    pRepPagos.Visible = false;
                if (!pRepFinancieros.Name.Equals(pPanelVisible))
                    pRepFinancieros.Visible = false;
                if (!pRepInvFact.Name.Equals(pPanelVisible))
                    pRepInvFact.Visible = false;
                if (!pRepGenerales.Name.Equals(pPanelVisible))
                    pRepGenerales.Visible = false;
            }
            catch
            {
            }
        }

        private frmMenu()
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

        private void btnMenú1_Click(object sender, EventArgs e)
        {
            pPrincipal.Visible = true;
            QuitarTodos(pPrincipal.Name.ToString());
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPrincipal.MenuEstado();
            instance = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblGenerales_Click(object sender, EventArgs e)
        {
            frmMenuGenerales oMenu = frmMenuGenerales.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void lblInventarios_Click(object sender, EventArgs e)
        {
            frmMenuFacturacion oMenu = frmMenuFacturacion.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void lblFinancieros_Click(object sender, EventArgs e)
        {
            frmMenuFinancieros oMenu = frmMenuFinancieros.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void lblReportes_Click(object sender, EventArgs e)
        {
            pReportes.Visible = true;
            QuitarTodos(pReportes.Name.ToString());
        }

        private void lblSistema_Click(object sender, EventArgs e)
        {
            frmMenuSistema oMenu = frmMenuSistema.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void btnReportes1_Click(object sender, EventArgs e)
        {
            pReportes.Visible = true;
            QuitarTodos(pReportes.Name.ToString());
        }

        private void btnRepFinancieros_Click(object sender, EventArgs e)
        {
            pRepFinancieros.Visible = true;
            QuitarTodos(pRepFinancieros.Name.ToString());
        }

        private void btnRepInvFac_Click(object sender, EventArgs e)
        {
            pRepInvFact.Visible = true;
            QuitarTodos(pRepInvFact.Name.ToString());
        }

        private void btnRepPagos_Click(object sender, EventArgs e)
        {
            pRepPagos.Visible = true;
            QuitarTodos(pRepPagos.Name.ToString());
        }

        private void btnRepGtsPorCategoria_Click(object sender, EventArgs e)
        {
            frmrptMontosPorGasto ofrm = frmrptMontosPorGasto.getInstance();
            codigo = ofrm.Codigo;
            descripcion = ofrm.Descripcion;
            modulo = ofrm.Modulo;
            if (!TienePermiso())
            {
                ofrm.MdiParent = this.MdiParent;
                ofrm.Show();
            }
            else
            {
                ofrm = null;
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void btnRepFacRecPag_Click(object sender, EventArgs e)
        {
            /*frmrptFacturasRecibidasPagadas orpt = frmrptFacturasRecibidasPagadas.getInstance();
            codigo = orpt.Codigo;
            descripcion = orpt.Descripcion;
            modulo = orpt.Modulo;
            if (!TienePermiso())
            {
                orpt.MdiParent = this.MdiParent;
                orpt.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                orpt = null;
            }
            this.Close();*/
        }

        private void btnRepPagReaCate_Click(object sender, EventArgs e)
        {
            /*   frmrptPagosRealizadosCategoria orpt = frmrptPagosRealizadosCategoria.getInstance();
               codigo = orpt.Codigo;
               descripcion = orpt.Descripcion;
               modulo = orpt.Modulo;
               if (!TienePermiso())
               {
                   orpt.MdiParent = this.MdiParent;
                   orpt.Show();
               }
               else
               {
                   MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   orpt = null;
               }
               this.Close();*/
        }

        private void btnRepPagReaCuenta_Click(object sender, EventArgs e)
        {
            /*  frmrptPagosCuenta orpt = frmrptPagosCuenta.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnRepSalPenPago_Click(object sender, EventArgs e)
        {
            /* frmrptSaldosFacturasPago ofrm = frmrptSaldosFacturasPago.getInstance();
             codigo = ofrm.Codigo;
             descripcion = ofrm.Descripcion;
             modulo = ofrm.Modulo;
             if (!TienePermiso())
             {
                 ofrm.MdiParent = this.MdiParent;
                 ofrm.Show();
             }
             else
             {
                 MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 ofrm = null;
             }
             this.Close();*/
        }

        private void btnRepRecDinero_Click(object sender, EventArgs e)
        {
            /* frmrptRecibosPorCliente orpt = frmrptRecibosPorCliente.getInstance();
             codigo = orpt.Codigo;
             descripcion = orpt.Descripcion;
             modulo = orpt.Modulo;
             if (!TienePermiso())
             {
                 orpt.MdiParent = this.MdiParent;
                 orpt.Show();
             }
             else
             {
                 MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 orpt = null;
             }
             this.Close();*/
        }

        private void btnRepTransacc_Click(object sender, EventArgs e)
        {
            /* frmrptReciboTransacciones orpt = frmrptReciboTransacciones.getInstance();
             codigo = orpt.Codigo;
             descripcion = orpt.Descripcion;
             modulo = orpt.Modulo;
             if (!TienePermiso())
             {
                 orpt.MdiParent = this.MdiParent;
                 orpt.Show();
             }
             else
             {
                 MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 orpt = null;
             }
             this.Close();*/
        }


        private void btnRepHisPrecios_Click(object sender, EventArgs e)
        {
            /*  frmrptHisPrecios orpt = frmrptHisPrecios.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnRepFacMoneda_Click(object sender, EventArgs e)
        {
            /*  frmrptFacturasMoneda orpt = frmrptFacturasMoneda.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnRepFacPeriodo_Click(object sender, EventArgs e)
        {
            /*   frmrptFacturacionPorPeriodo orpt = frmrptFacturacionPorPeriodo.getInstance();
               codigo = orpt.Codigo;
               descripcion = orpt.Descripcion;
               modulo = orpt.Modulo;
               if (!TienePermiso())
               {
                   orpt.MdiParent = this.MdiParent;
                   orpt.Show();
               }
               else
               {
                   MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   orpt = null;
               }
               this.Close();*/
        }

        private void btnRepFacCliente_Click(object sender, EventArgs e)
        {
            /* frmrptHisFacturacionCliente orpt = frmrptHisFacturacionCliente.getInstance();
             codigo = orpt.Codigo;
             descripcion = orpt.Descripcion;
             modulo = orpt.Modulo;
             if (!TienePermiso())
             {
                 orpt.MdiParent = this.MdiParent;
                 orpt.Show();
             }
             else
             {
                 MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 orpt = null;
             }
             this.Close();*/
        }

        private void btnRepSalFact_Click(object sender, EventArgs e)
        {
            /* frmrptEstadoCuentasClientes orpt = frmrptEstadoCuentasClientes.getInstance();
             codigo = orpt.Codigo;
             descripcion = orpt.Descripcion;
             modulo = orpt.Modulo;
             if (!TienePermiso())
             {
                 orpt.MdiParent = this.MdiParent;
                 orpt.Show();
             }
             else
             {
                 MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 orpt = null;
             }
             this.Close();*/
        }


        private void btnFacturacionXmesAno_Click(object sender, EventArgs e)
        {
            /*frmrptFacturaContable oFrm = frmrptFacturaContable.getInstance();
            codigo = oFrm.Codigo;
            descripcion = oFrm.Descripcion;
            modulo = oFrm.Modulo;
            if (!TienePermiso())
            {
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFrm = null;
            }*/
        }


        private void btnVentas_Click(object sender, EventArgs e)
        {
            /*  frmrptVentas oFrmPantalla = frmrptVentas.getInstance();
              codigo = oFrmPantalla.Codigo;
              descripcion = oFrmPantalla.Descripcion;
              modulo = oFrmPantalla.Modulo;
              if (!TienePermiso())
              {
                  oFrmPantalla.MdiParent = this.MdiParent;
                  oFrmPantalla.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  oFrmPantalla = null;
              }
              this.Close();*/
        }

        private void btnrptsGenerales_Click(object sender, EventArgs e)
        {
            pRepGenerales.Visible = true;
            QuitarTodos(pRepGenerales.Name.ToString());
        }

        private void btnRepClientes_Click(object sender, EventArgs e)
        {
            frmrptClientes oFrm = frmrptClientes.getInstance();
            codigo = oFrm.Codigo;
            descripcion = oFrm.Descripcion;
            modulo = oFrm.Modulo;
            if (!TienePermiso())
            {
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFrm = null;
            }
            this.Close();
        }

        private void btnRepProveedores_Click(object sender, EventArgs e)
        {
            frmrptProveedores oFrm = frmrptProveedores.getInstance();
            codigo = oFrm.Codigo;
            descripcion = oFrm.Descripcion;
            modulo = oFrm.Modulo;
            if (!TienePermiso())
            {
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFrm = null;
            }
            this.Close();
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            /*  frmrptCajas orpt = frmrptCajas.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnAdministracionUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnRepFacImpuestoVentas_Click(object sender, EventArgs e)
        {
            /*  frmrptImpuestoVentas orpt = frmrptImpuestoVentas.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnProdPendientesCobro_Click(object sender, EventArgs e)
        {
            /*  frmrptProductosPendienteCobro orpt = frmrptProductosPendienteCobro.getInstance();
              codigo = orpt.Codigo;
              descripcion = orpt.Descripcion;
              modulo = orpt.Modulo;
              if (!TienePermiso())
              {
                  orpt.MdiParent = this.MdiParent;
                  orpt.Show();
              }
              else
              {
                  MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  orpt = null;
              }
              this.Close();*/
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda oFrm = frmAyuda.getInstance();
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();

            //this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            oPrincipal.CerrarSesion(true);
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                if (e.KeyCode == Keys.F1)
                    btnAyuda.PerformClick();
                if (e.KeyCode == Keys.F2)
                    btnCerrarSesion.PerformClick();
            }
        }
    }
}