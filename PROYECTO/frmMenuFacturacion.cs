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
    public partial class frmMenuFacturacion : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private frmPrincipal oPrincipal = frmPrincipal.getInstance();
        private static frmMenuFacturacion instance = null;

        public static frmMenuFacturacion getInstance()
        {
            if (instance == null)
                instance = new frmMenuFacturacion();
            return instance;
        }

        private frmMenuFacturacion()
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
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmMenuInvFact_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPrincipal.MenuEstado();
            instance = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            frmCotizacion orpt = frmCotizacion.getInstance();
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
            this.Close();
        }

      

        private void button23_Click(object sender, EventArgs e)
        {
            frmMenu oMenu = frmMenu.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void btnFacturacionRapida_Click(object sender, EventArgs e)
        {
            return;
            
            //frmFacturacionRapida oFactura = frmFacturacionRapida.getInstance();
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

    }
}