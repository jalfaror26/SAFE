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
    public partial class frmMenuSistema : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private frmPrincipal oPrincipal = frmPrincipal.getInstance();
        private static frmMenuSistema instance = null;

        public static frmMenuSistema getInstance()
        {
            if (instance == null)
                instance = new frmMenuSistema();
            return instance;
        }

        private frmMenuSistema()
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

        private void btnMenú1_Click(object sender, EventArgs e)
        {
            frmMenuSistema oMenu = frmMenuSistema.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void frmMenuSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPrincipal.MenuEstado();
            instance = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            oPrincipal.CerrarSesion();
        }

        private void btnFondoPantalla_Click(object sender, EventArgs e)
        {
            this.Close();
            oPrincipal.FondoPantalla();
        }

        private void btnUsuariosPermisos_Click(object sender, EventArgs e)
        {
            frmPermisos ofrm = frmPermisos.getInstance();
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
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda oFrm = frmAyuda.getInstance();
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();

            //this.Close();
        }

        private void btnDatosEmpresa_Click(object sender, EventArgs e)
        {
            frmEmpresa oCategorias = frmEmpresa.getInstance();
            codigo = oCategorias.Codigo;
            descripcion = oCategorias.Descripcion;
            modulo = oCategorias.Modulo;
            if (!TienePermiso())
            {
                oCategorias.MdiParent = this.MdiParent;
                oCategorias.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oCategorias = null;
            }
            this.Close();
        }

        private void btnAdministracionUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarioAdministracion orpt = frmUsuarioAdministracion.getInstance();
            orpt.MdiParent = this.MdiParent;
            orpt.Show();

            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

    }
}