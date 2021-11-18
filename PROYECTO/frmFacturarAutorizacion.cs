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
    public partial class frmFacturarAutorizacion : Form
    {
        private ConexionDAO conexion;
        private String codigo, descripcion, modulo;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

        private string estado = "";
        private string cuenta = "";
        private string linea = "", comentario = "", origen = "";
        private int reloj = 0;
        private Factura oFactura = new Factura();
        private DataTable oDetalles = new DataTable();


        private static frmFacturarAutorizacion instance = null;

        public static frmFacturarAutorizacion getInstance(Factura oFactura, DataTable Detalles, string comentario, String pOrigen)
        {
            if (instance == null)
                instance = new frmFacturarAutorizacion(oFactura, Detalles, comentario, pOrigen);
            return instance;
        }

        public frmFacturarAutorizacion(Factura ofactura, DataTable detalles, string pcomentario, String pOrigen)
        {
            oFactura = ofactura;
            oDetalles = detalles;
            comentario = pcomentario;
            origen = pOrigen;
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtAdministrador.Text.Equals(""))
            {
                MessageBox.Show("Digite el usuario administrador");
                txtAdministrador.Focus();
                return;
            }
            if (this.txtClave.Text.Equals(""))
            {
                MessageBox.Show("Digite la contraseña del administrador");
                txtClave.Focus();
                return;
            }
            if (this.txtComentario.Text.Trim().Equals(""))
            {
                MessageBox.Show("Digite el comentario");
                txtComentario.Focus();
                return;
            }

            conexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            conexion.cerrarConexion();
            if (conexion.abrirConexion())
            {
                if (conexion.existeUsuarioAdministrador(txtAdministrador.Text, txtClave.Text, PROYECTO.Properties.Settings.Default.No_cia))
                {
                    string sql = "INSERT INTO TBL_FACTURA_AUTORIZACION fa VALUES ('" + oFactura.NumFactura + "', '" + oFactura.Cliente + "', user, '" + txtAdministrador.Text + "', '" + txtComentario.Text + "', 'AUTORIZAR FACTURA', sysdate, '" + oFactura.No_cia + "')";
                    conexion.EjecutaSentencia2(sql);

                    if (origen.Equals("frmFacturacion"))
                    {
                        frmFacturacion.getInstance().Enabled = true;
                        frmFacturacion.getInstance().facturar();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectas.");
                    txtClave.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
                txtAdministrador.Text = "";
                txtClave.Text = "";
            }
            conexion.cerrarConexion();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConexion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (origen.Equals("frmFacturacion"))
                frmFacturacion.getInstance().Enabled = true;
            instance = null;
        }

        private Boolean TienePermiso()
        {
            try
            {
                Boolean tienePermiso = false;
                conexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                conexion.cerrarConexion();
                if (conexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo, modulo, descripcion, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.Usuario);
                    if (odataset.Tables[0].Rows[0].ItemArray[0].ToString().Equals("0"))
                        tienePermiso = true;
                    conexion.cerrarConexion();
                }
                return tienePermiso;
            }
            catch (Exception ex)
            {
                conexion.cerrarConexion();
                return false;
            }
        }

        private void frmConexion_Load(object sender, EventArgs e)
        {
            this.Text += "N° " + oFactura.NumFactura;
            LlenarComentarios();
            txtComentario.Text = comentario;
        }

        private void LlenarComentarios()
        {
            try
            {
                conexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                conexion.cerrarConexion();
                if (conexion.abrirConexion())
                {
                    cboComentarios.DataSource = conexion.EjecutaSentencia("select distinct FACAU_DESCRIPCION from TBL_FACTURA_AUTORIZACION fa where fa.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and FACAU_TIPO='AUTORIZAR FACTURA' order by FACAU_DESCRIPCION");
                    cboComentarios.DisplayMember = "FACAU_DESCRIPCION";
                    cboComentarios.ValueMember = "FACAU_DESCRIPCION";

                    conexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            }
            catch (Exception ex)
            {
                conexion.cerrarConexion();
            }
        }

        private void timFecha_Tick(object sender, EventArgs e)
        {
            try
            {
                conexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (conexion.abrirConexion())
                {
                    this.Text = "Conexion al Sistema               " + conexion.fecha().ToString();
                    conexion.cerrarConexion();
                }
                else
                {
                    this.Text = "Conexion al Sistema               " + conexion.fecha().ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        private void cboComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtComentario.Text = cboComentarios.Text;
        }
    }
}