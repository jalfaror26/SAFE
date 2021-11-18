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
    public partial class frmConsultaCliente : Form
    {
        /*Variables Estaticas*/
        private static String palabra;
        private static String cod = "", des = "", cedula = "", Dato_1 = "", Dato_2 = "", Dato_3 = "";
        private static frmConsultaCliente instance = null;
        /*DAO*/
        private ClienteDAO oClienteDAO = new ClienteDAO();
        private ConexionDAO oConexion;

        /**/
        private String palabra2, palabra3;
        private String cajaabierta;
        private String codigoAbrir = "", descripcionAbrir = "", moduloAbrir = "";

        public static frmConsultaCliente getInstance(string ppalabra)
        {
            if (instance == null)
                instance = new frmConsultaCliente(ppalabra);
            return instance;
        }

        private frmConsultaCliente()
        {
            InitializeComponent();
        }

        private frmConsultaCliente(string ppalabra)
        {
            InitializeComponent();
            palabra = ppalabra;
        }

        public String Palabra2
        {
            get { return palabra2; }
            set { palabra2 = value; }
        }

        public String Palabra3
        {
            get { return palabra3; }
            set { palabra3 = value; }
        }

        public static frmConsultaCliente getInstance(string ppalabra, String cajaAbierta)
        {
            if (instance == null)
                instance = new frmConsultaCliente(ppalabra, cajaAbierta);
            return instance;
        }

        private frmConsultaCliente(string ppalabra, String pcajaAbierta)
        {
            InitializeComponent();
            palabra = ppalabra;
            cajaabierta = pcajaAbierta;
        }

        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            Llenar_Grid();
        }

        private void Llenar_Grid(int tipoFiltro, String palabraFiltro)
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                switch (palabra.ToUpper())
                {
                    case "CLIENTE":
                    case "CLIENTEPROYECCIONESTIMADA":
                    case "CLIENTEFACTURACION":
                    case "FRMFACTURACION":
                    case "CLIENTECAMBIOPRODUCTO":
                    case "CLIENTECONSIGNACION":
                    case "CLIENTEREPORTEPROYECESTIMADA":
                    case "CLIENTEREPORTECOMPARATIVO":
                    case "CLIENTERETENCION":
                    case "CLIENTERETENCIONES":
                    case "CLIENTECOTIZACION":
                    case "CLIENTECOTIZACIONCONSULTA":
                    case "CLIENTEPEDIDO":
                    case "CLIENTEAPARTADO":
                    case "FRMCOTIZACION":
                        {
                            dgrDatos.DataSource = oClienteDAO.Listar_Filtrado2(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;



                    /**********  F I N *****************/

                    default: break;
                }
                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
            }

        }

        private void Llenar_Grid()
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                switch (palabra.ToUpper())
                {
                    case "CLIENTE":
                    case "CLIENTEPROYECCIONESTIMADA":
                    case "CLIENTEFACTURACION":
                    case "FRMFACTURACION":
                    case "CLIENTECAMBIOPRODUCTO":
                    case "CLIENTECONSIGNACION":
                    case "CLIENTEREPORTEPROYECESTIMADA":
                    case "CLIENTEREPORTECOMPARATIVO":
                    case "CLIENTERETENCION":
                    case "CLIENTERETENCIONES":
                    case "CLIENTECOTIZACION":
                    case "CLIENTECOTIZACIONCONSULTA":
                    case "CLIENTERECIBO":
                    case "CLIENTEREPORTERECIBOS":
                    case "CLIENTEREPORTEFACTURACION":
                    case "CLIENTEREPORTEFACTURACIONPERIODO":
                    case "CLIENTEREPORTEDIFERENCIAL":
                    case "CLIENTEPEDIDO":
                    case "CLIENTEAPARTADO":
                    case "FRMCOTIZACION":
                        {
                            dgrDatos.DataSource = oClienteDAO.consultarReporte2(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;


                    default: break;
                }

                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
            }

        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cod = dgrDatos["id", e.RowIndex].Value.ToString();
                des = dgrDatos["descripcion", e.RowIndex].Value.ToString();
                cedula = dgrDatos["cli_cedula", e.RowIndex].Value.ToString();
                try
                {
                    if (dgrDatos.ColumnCount > 2)
                    {
                        Dato_1 = dgrDatos["dato1", e.RowIndex].Value.ToString();
                        Dato_2 = dgrDatos["dato2", e.RowIndex].Value.ToString();
                        Dato_3 = dgrDatos["dato3", e.RowIndex].Value.ToString();
                    }
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { }
        }

        private void dgrDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Retornar(0);
        }

        private void Retornar(int tipo)
        {
            if (tipo == 1)
            {
                for (int x = 1; x < dgrDatos.Rows.Count; x++)
                {
                    if (dgrDatos[0, x].Selected && x + 1 < dgrDatos.Rows.Count)
                    {
                        cod = dgrDatos["id", x - 1].Value.ToString();
                        des = dgrDatos["descripcion", x - 1].Value.ToString();
                        cedula = dgrDatos["cli_cedula", x - 1].Value.ToString();
                    }
                    if (dgrDatos[0, x].Selected && x + 1 == dgrDatos.Rows.Count)
                    {
                        cod = dgrDatos["id", x].Value.ToString();
                        des = dgrDatos["descripcion", x].Value.ToString();
                        cedula = dgrDatos["cli_cedula", x].Value.ToString();
                    }
                }
            }


            //if (palabra.Equals("Cliente"))
            //{
            //    frmFacturasPendientesCuentas oFactura = frmFacturasPendientesCuentas.getInstance();
            //    oFactura.Llenarcliente(cod, des);
            //    oFactura.llenarGrid(cod);
            //    oFactura.consultaDias(cod);
            //    oFactura.limpiar();
            //}

            else if (palabra.Equals("frmFacturacion"))
                frmFacturacion.getInstance().cargaCliente(cod, des);
            else if (palabra.Equals("frmCotizacion"))
                frmCotizacion.getInstance().cargaCliente(cod, des);

            //else if (palabra.Equals("ClienteRecibo"))
            //{
            //    frmRecibosDineroSencillo oRecibo2 = frmRecibosDineroSencillo.getInstance();
            //    oRecibo2.llenaDatosCliente(cod, des);
            //    oRecibo2.llenaGrid();

            //}

            //else if (palabra.Equals("ClienteReporteRecibos"))
            //    frmrptRecibosPorCliente.getInstance().cargaCliente(cod, des);
            //else if (palabra.Equals("ClienteReporteFacturacionPeriodo"))
            //    frmrptFacturacionPorPeriodo.getInstance().cargaCliente(cod, des);
            this.Close();
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBNombre.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBNombre.Text);
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBId.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(1, txtBId.Text);
        }

        private void frmConsultaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Retornar(0);
        }

        private void dgrDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            String val = e.KeyChar.ToString();
            if (val.Equals("\r"))
                Retornar(1);
        }

        private void dgrDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBCedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBCedula.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(3, txtBCedula.Text);
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes cliente1 = frmClientes.getInstance();
            codigoAbrir = cliente1.Codigo;
            descripcionAbrir = cliente1.Descripcion;
            moduloAbrir = cliente1.Modulo;
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

        private Boolean TienePermiso()
        {
            try
            {
                PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

                Boolean tienePermiso = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigoAbrir);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigoAbrir, moduloAbrir, descripcionAbrir, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigoAbrir, PROYECTO.Properties.Settings.Default.No_cia);
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

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance();
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }
    }
}