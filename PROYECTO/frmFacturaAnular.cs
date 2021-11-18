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
    public partial class frmFacturaAnular : Form
    {
        private ConexionDAO conexion;
        private String codigo, descripcion, modulo;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

        private int intentos = 0;
        private string estado = "";
        private string cuenta = "";
        private string linea = "", origen = "";
        private int reloj = 0;
        private Factura oFactura = new Factura();
        private DataTable oDetalles = new DataTable();


        private static frmFacturaAnular instance = null;

        public static frmFacturaAnular getInstance(Factura oFactura, DataTable Detalles, String pOrigen)
        {
            if (instance == null)
                instance = new frmFacturaAnular(oFactura, Detalles, pOrigen);
            return instance;
        }

        public frmFacturaAnular(Factura ofactura, DataTable detalles, String pOrigen)
        {
            oFactura = ofactura;
            oDetalles = detalles;
            origen = pOrigen;
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtAdministrador.Text.Equals(""))
            {
                MessageBox.Show("Digite el nombre del usuario");
                txtAdministrador.Focus();
                intentos++;
                return;
            }
            if (this.txtClave.Text.Equals(""))
            {
                MessageBox.Show("Digite la contraseña del usuario");
                txtClave.Focus();
                intentos++;
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
                    if (oFactura.Tipo.Equals("CREDITO"))
                    {
                        FacturasPendientesDAO ofacturaPendienteDAO = new FacturasPendientesDAO();
                        DataSet oDataSet = ofacturaPendienteDAO.ConsultarEstado(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                        if (!oDataSet.Tables[0].Rows[0].ItemArray[0].ToString().Equals("PE"))
                        {
                            MessageBox.Show("No se puede anular esta factura porque tiene transacciones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    conexion.cerrarConexion();
                    conexion.abrirConexion();

                    if (!oFactura.Tipo.Equals("CONTADO"))
                    {
                        FacturasPendientesDAO ofacturaPendienteDAO = new FacturasPendientesDAO();
                        conexion.cerrarConexion();
                        conexion.abrirConexion();
                        string monto = ofacturaPendienteDAO.ConsultaMontoSaldo(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia).Rows[0].ItemArray[0].ToString();
                        string saldo = ofacturaPendienteDAO.ConsultaMontoSaldo(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia).Rows[0].ItemArray[1].ToString();
                        conexion.cerrarConexion();
                        conexion.abrirConexion();
                        ofacturaPendienteDAO.Anular(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                        if (ofacturaPendienteDAO.Error())
                        {
                            MessageBox.Show("Ocurrio un Error al anular la factura: " + ofacturaPendienteDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    conexion.cerrarConexion();
                    conexion.abrirConexion();

                    FacturaDAO oFacturaDAO = new FacturaDAO();
                    oFactura.Comentario = txtComentario.Text;
                    oFacturaDAO.Anular(oFactura, txtAdministrador.Text, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oFacturaDAO.Error())
                    {
                        MessageBox.Show("Ocurrio un Error al anular la factura: " + oFacturaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Documento anulado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (origen.Equals("frmFacturacion"))
                            frmFacturacion.getInstance().cargaFactura(oFactura.NumFactura.ToString(), oFactura.Nombre);

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectas.");
                    intentos++;
                    txtClave.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
                intentos++;
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
        }

        private void LlenarComentarios()
        {
            try
            {
                conexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                conexion.cerrarConexion();
                if (conexion.abrirConexion())
                {
                    cboComentarios.DataSource = conexion.EjecutaSentencia("select distinct FAC_COMENTARIO from TBL_FACTURA F where f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' order by FAC_COMENTARIO");
                    cboComentarios.DisplayMember = "FAC_COMENTARIO";
                    cboComentarios.ValueMember = "FAC_COMENTARIO";

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