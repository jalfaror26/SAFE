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
    public partial class frmConsulta : Form
    {
        /*Variables Estaticas*/
        private static String palabra;
        private static String cod = "", des = "", Dato_1 = "", Dato_2 = "", Dato_3 = "";
        private static frmConsulta instance = null;
        /*BLL*/
        private ServicioDAO oServicioDAO = new ServicioDAO();

        private ProveedorDAO oProveedorDAO = new ProveedorDAO();

        private ClienteDAO oClienteDAO = new ClienteDAO();
        //private FacturaDAO oFacturaDAO = new FacturaDAO();
        private ConexionDAO oConexion;
        private GastoDAO oGastosDAO = new GastoDAO();
        private ProformaDAO oProformaDAO = new ProformaDAO();

        /**/
        private String palabra2, palabra3;
        private String cajaabierta;

        public static frmConsulta getInstance(string ppalabra)
        {
            if (instance == null)
                instance = new frmConsulta(ppalabra);
            return instance;
        }

        private frmConsulta()
        {
            InitializeComponent();
        }

        private frmConsulta(string ppalabra)
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

        public static frmConsulta getInstance(string ppalabra, String cajaAbierta)
        {
            if (instance == null)
                instance = new frmConsulta(ppalabra, cajaAbierta);
            return instance;
        }

        private frmConsulta(string ppalabra, String pcajaAbierta)
        {
            InitializeComponent();
            palabra = ppalabra;
            cajaabierta = pcajaAbierta;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
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
                    case "PROFORMA":
                        {
                            dgrDatos.DataSource = oProformaDAO.Consulta(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia);
                            if (oProformaDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oProformaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "ARTICULO_ARTICULOS":
                    case "ARTICULOSCOMPRA":
                    case "ARTICULOPROYECCION":
                    case "MOVIMIENTOARTICULOS":
                    case "MOVIMIENTOARTICULOS2":
                    case "ARTICULOCONSIGNACION":
                    case "REPORTEARTICULOPRECIOS":
                    case "REPORTEARTICULOSMOVIMIENTOS":
                    case "REPORTEARTICULOSCOMPRAS":
                    case "ARTICULOREPORTEPROYECESTIMADA":
                    case "ARTICULOREPORTEPROYECESTIMADA2":
                    case "ARTICULOPARALOTE":
                    case "PROVEEDOR_ARTICULOS":
                    case "PROVEEDORPAGOS":
                    case "PROVEEDORCOMPRAS":
                    case "PROVEEDORPREPAGO":
                    case "PROVEEDORPROYECCION":
                    case "PROVEEDORPROYECCION2":
                    case "PROVEEDORREPORTEFACTURASPC":
                    case "PROVEEDORPROYECCIONESTIMADA":
                    case "PROVEEDORREPORTEPROYECESTIMADA":
                    case "PROVEEDORRENTA":
                    case "PROVEEDORORDENCOMPRA":
                    case "PROVEEDOR_INGRESO_INVENTARIO":
                        {
                            dgrDatos.DataSource = oProveedorDAO.Listar_Filtrado(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oProveedorDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "CLIENTE":
                    case "CLIENTEPROYECCIONESTIMADA":
                    case "CLIENTEFACTURACION":
                    case "CLIENTEFACTURACIONRAPIDA":
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
                    case "CLIENTEPROFORMA":
                        {
                            dgrDatos.DataSource = oClienteDAO.Listar_Filtrado(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;


                    case "PROVEEDORGASTO":
                        {
                            dgrDatos.DataSource = oConexion.EjecutaSentencia("SELECT distinct '' as cod,GASDET_PROVEEDOR as descripcion FROM TBL_CH_GASTO_DETALLE where  regexp_like(GASDET_PROVEEDOR,'" + palabraFiltro + "','i') order by GASDET_PROVEEDOR");
                        }
                        break;

                    case "CLIENTERECIBO":
                    case "CLIENTEREPORTERECIBOS":
                        {
                            dgrDatos.DataSource = oClienteDAO.Listar3(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "CLIENTEREPORTEFACTURACION":
                    case "CLIENTEREPORTEFACTURACIONPERIODO":
                    case "CLIENTEREPORTEDIFERENCIAL":
                        {
                            dgrDatos.DataSource = oClienteDAO.ListarReporte(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    //case "FACTURACION":
                    //case "FACTURACIONRAPIDA":
                    //    {
                    //        dgrDatos.DataSource = oFacturaDAO.Consulta(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia, PROYECTO.Properties.Settings.Default.Centro);
                    //        if (oFacturaDAO.Error())
                    //            MessageBox.Show("Error al listar los datos:\n" + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    break;


                    case "Gastos":
                    case "GastosRapidos":
                    case "GastosRapidos2":
                        {
                            dgrDatos.DataSource = oGastosDAO.Listar2(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oGastosDAO.Error())
                                MessageBox.Show("Error al Listar los datos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case "PROFORMA":
                        {
                            dgrDatos.DataSource = oProformaDAO.ConsultaProformas(PROYECTO.Properties.Settings.Default.No_cia);
                            if (oProformaDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oProformaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "ARTICULO_ARTICULOS":
                    case "ARTICULOSCOMPRA":
                    case "ARTICULOPROYECCION":
                    case "MOVIMIENTOARTICULOS":
                    case "MOVIMIENTOARTICULOS2":
                    case "ARTICULOCONSIGNACION":
                    case "REPORTEARTICULOPRECIOS":
                    case "REPORTEARTICULOSMOVIMIENTOS":
                    case "REPORTEARTICULOSCOMPRAS":
                    case "ARTICULOREPORTEPROYECESTIMADA":
                    case "ARTICULOREPORTEPROYECESTIMADA2":
                    case "ARTICULOPARALOTE":
                    case "PROVEEDOR_ARTICULOS":
                    case "PROVEEDORPAGOS":
                    case "PROVEEDORCOMPRAS":
                    case "PROVEEDORPREPAGO":
                    case "PROVEEDORPROYECCION":
                    case "PROVEEDORPROYECCION2":
                    case "PROVEEDORREPORTEFACTURASPC":
                    case "PROVEEDORPROYECCIONESTIMADA":
                    case "PROVEEDORREPORTEPROYECESTIMADA":
                    case "PROVEEDORRENTA":
                    case "PROVEEDORORDENCOMPRA":
                    case "PROVEEDOR_INGRESO_INVENTARIO":
                        {
                            dgrDatos.DataSource = oProveedorDAO.Busqueda_Consulta(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oProveedorDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oProveedorDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;


                    case "CLIENTE":
                    case "CLIENTEPROYECCIONESTIMADA":
                    case "CLIENTEFACTURACION":
                    case "CLIENTEFACTURACIONRAPIDA":
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
                    case "CLIENTEPROFORMA":
                        {
                            dgrDatos.DataSource = oClienteDAO.consultarReporte(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                            if (oClienteDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                        
                    case "REPORTEINVENTARIOARTICULO2":
                        {
                            dgrDatos.DataSource = oServicioDAO.Busqueda_Consulta(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oServicioDAO.Error())
                                MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    //case "FACTURACION":
                    //case "FACTURACIONRAPIDA":
                    //    {
                    //        dgrDatos.DataSource = oFacturaDAO.ConsultaFacturas(PROYECTO.Properties.Settings.Default.No_cia, PROYECTO.Properties.Settings.Default.Centro);
                    //        if (oFacturaDAO.Error())
                    //            MessageBox.Show("Error al listar los datos:\n" + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    break;

                    case "PROVEEDORGASTO":
                        {
                            dgrDatos.DataSource = oConexion.EjecutaSentencia("SELECT distinct '' cod, GASDET_PROVEEDOR descripcion FROM TBL_CH_GASTO_DETALLE order by GASDET_PROVEEDOR");
                        }
                        break;

                    case "GASTOS":
                    case "GASTOSRAPIDOS":
                    case "GASTOSRAPIDOS2":
                        {
                            dgrDatos.DataSource = oGastosDAO.Consultar2(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oGastosDAO.Error())
                                MessageBox.Show("Error al Listar los datos:\n" + oGastosDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "ARTICULOORDENCOMPRA":
                        {
                            dgrDatos.DataSource = oServicioDAO.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            if (oServicioDAO.Error())
                                MessageBox.Show("Error al Listar los datos:\n" + oServicioDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                    if (dgrDatos[0, x].Selected && x + 1 == dgrDatos.Rows.Count)
                    {
                        cod = dgrDatos["id", x].Value.ToString();
                        des = dgrDatos["descripcion", x].Value.ToString();
                    }
                }
            }

            if (palabra.Equals("PROFORMA"))
                frmCotizacion.getInstance().cargaProforma(cod, des);
            //else if (palabra.Equals("ProveedorReporteFacturasPC"))
            //    frmrptFacturasRecibidasPagadas.getInstance().cargaProveedor(cod, des);
            //else if (palabra.Equals("GastoReporte"))
            //    frmrptPagosRealizadosCategoria.getInstance().cargaGasto(cod, des);
            //else if (palabra.Equals("puestoReporteFacturacionPeriodo"))
            //    frmrptFacturacionPorPeriodo.getInstance().cargaCliente(cod, des);
   
            //else if (palabra.Equals("ProveedorPagos"))
            //    frmFacturaPorPagarProveedor.getInstance().LlenarProveedor(cod, des);
            //else if (palabra.Equals("ProveedorPrepago"))
            //    frmPrepagoProveedor.getInstance().LlenarProveedor(cod, des);
            //else if (palabra.Equals("Cliente"))
            //{
            //    frmFacturasPendientesCuentas oFactura = frmFacturasPendientesCuentas.getInstance();
            //    oFactura.Llenarcliente(cod, des);
            //    oFactura.llenarGrid(cod);
            //    oFactura.consultaDias(cod);
            //    oFactura.limpiar();
            //}

            //else if (palabra.Equals("ClienteFacturacionRapida"))
            //    frmFacturacionRapida.getInstance().cargaCliente(cod, des);
            else if (palabra.Equals("ClienteProforma"))
                frmCotizacion.getInstance().cargaCliente(cod, des);
         
          
            //else if (palabra.Equals("FACTURACIONRAPIDA"))
            //    frmFacturacionRapida.getInstance().cargaFactura(cod, des);
        
            //else if (palabra.Equals("ClienteRecibo"))
            //{
            //    frmRecibosDineroSencillo oRecibo2 = frmRecibosDineroSencillo.getInstance();
            //    oRecibo2.llenaDatosCliente(cod, des);
            //    oRecibo2.llenaGrid();

            //    frmApartadosAbonoSencillo oAbono = frmApartadosAbonoSencillo.getInstance();
            //    oAbono.llenaDatosCliente(cod, des);
            //    oAbono.llenaGridFacturas("");
            //}
            //else if (palabra.Equals("Gastos"))
            //    frmFacturaPorPagarProveedor.getInstance().LlenarGasto(cod, des);
            //else if (palabra.Equals("GastosRapidos"))
            //    frmFacturaPorPagarProveedorRapida.getInstance().LlenarGasto(cod, des);
            //else if (palabra.Equals("BancoPagos"))
            //    frmPagosProveedores.getInstance().LlenarBancoPagos(cod, des);
            //else if (palabra.Equals("ClienteReporteRecibos"))
            //    frmrptRecibosPorCliente.getInstance().cargaCliente(cod, des);
            //else if (palabra.Equals("ClienteReporteFacturacionPeriodo"))
            //    frmrptFacturacionPorPeriodo.getInstance().cargaCliente(cod, des);
            //else if (palabra.Equals("ReporteArticuloPrecios"))
            //    frmrptHisPrecios.getInstance().cargaArticulo(cod, des);
         
          
            //else if (palabra.Equals("ReporteArticulosMovimientos"))
            //    frmrptInventarioDetalle.getInstance().cargaArtiuculo(cod, des);
            //else if (palabra.Equals("GastosSaldosPagos"))
            //    frmrptSaldosFacturasPago.getInstance().llenargasto(cod, des);
            
           
          
            this.Close();
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            txtBId.Clear();
            if (txtBNombre.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBNombre.Text);
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            txtBNombre.Clear();
            if (txtBId.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(1, txtBId.Text);
        }

        private void frmConsulta_FormClosing(object sender, FormClosingEventArgs e)
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