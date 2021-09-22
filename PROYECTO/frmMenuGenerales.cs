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
    public partial class frmMenuGenerales : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private frmPrincipal oPrincipal = frmPrincipal.getInstance();
        private static frmMenuGenerales instance = null;

        public static frmMenuGenerales getInstance()
        {
            if (instance == null)
                instance = new frmMenuGenerales();
            return instance;
        }

        private frmMenuGenerales()
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

        private void frmMenuGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            oPrincipal.MenuEstado();
            instance = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenú1_Click(object sender, EventArgs e)
        {
            frmMenu oMenu = frmMenu.getInstance();
            oMenu.MdiParent = this.MdiParent;
            oMenu.Show();

            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes cliente1 = frmClientes.getInstance();
            codigo = cliente1.Codigo;
            descripcion = cliente1.Descripcion;
            modulo = cliente1.Modulo;
            if (!TienePermiso())
            {
                cliente1.MdiParent = this.MdiParent;
                cliente1.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cliente1 = null;
            }
            this.Close();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores oProveedor = frmProveedores.getInstance();
            codigo = oProveedor.Codigo;
            descripcion = oProveedor.Descripcion1;
            modulo = oProveedor.Modulo;
            if (!TienePermiso())
            {
                oProveedor.MdiParent = this.MdiParent;
                oProveedor.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oProveedor = null;
            }
            this.Close();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            frmServicios oArticulo = frmServicios.getInstance();
            codigo = oArticulo.Codigo;
            descripcion = oArticulo.Descripcion;
            modulo = oArticulo.Modulo;
            if (!TienePermiso())
            {
                oArticulo.MdiParent = this.MdiParent;
                oArticulo.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oArticulo = null;
            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmRecordatorio oFrmPantalla = frmRecordatorio.getInstance();
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
                MessageBox.Show("No tiene permiso para accesar esta pantalla, Comuniquese con el administrador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFrmPantalla = null;
            }
            this.Close();
        }

        private void btnVerRecordatorios_Click(object sender, EventArgs e)
        {
            frmRecordatorioVista oFrmPantalla = frmRecordatorioVista.getInstance();
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
                MessageBox.Show("No tiene permiso para accesar esta pantalla, Comuniquese con el administrador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oFrmPantalla = null;
            }
            this.Close();
        }
    }
}