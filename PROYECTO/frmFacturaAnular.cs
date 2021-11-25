using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Net;
using Newtonsoft.Json;

namespace PROYECTO
{
    public partial class frmFacturaAnular : Form
    {
        private ConexionDAO oConexion;
        private String codigo, descripcion, modulo;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

        private int intentos = 0;
        private string linea = "", origen = "";
        private Factura oFactura = new Factura();
        private DataTable oDetalles = new DataTable();
        private readonly Ent_CW oControl = new Ent_CW();

        private static frmFacturaAnular instance = null;

        private int ttime = 0;
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

            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                if (oConexion.existeUsuarioAdministrador(txtAdministrador.Text, txtClave.Text, PROYECTO.Properties.Settings.Default.No_cia))
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

                    if (!AplicaFE(out String pApiToken, out String pAccessToken))
                    {
                        pbFacturaElectronica.Visible = false;
                        lblMjFacturaElectronica.Text = "";
                        AnularFactura();
                        return;
                    }

                    if (!oFactura.Fe_Comprobacion.Equals("ACEPTADO"))
                    {
                        MessageBox.Show("No se puede anular esta factura porque la Factura Electrónica no está en estado ACEPTADO!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    lblMjFacturaElectronica.Text = "Generando Nota de Crédito";
                    lblMjFacturaElectronica.Visible = true;
                    pbFacturaElectronica.Visible = true;
                    timCreaNC.Start();
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
            oConexion.cerrarConexion();

        }

        private void AnularFactura()
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                FacturasPendientesDAO ofacturaPendienteDAO = new FacturasPendientesDAO();
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                string monto = ofacturaPendienteDAO.ConsultaMontoSaldo(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia).Rows[0].ItemArray[0].ToString();
                string saldo = ofacturaPendienteDAO.ConsultaMontoSaldo(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia).Rows[0].ItemArray[1].ToString();
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                ofacturaPendienteDAO.Anular(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                if (ofacturaPendienteDAO.Error())
                {
                    MessageBox.Show("Ocurrio un Error al anular la factura: " + ofacturaPendienteDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                oConexion.cerrarConexion();
                oConexion.abrirConexion();

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
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
                intentos++;
                txtAdministrador.Text = "";
                txtClave.Text = "";
            }
            oConexion.cerrarConexion();
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
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo, modulo, descripcion, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.Usuario);
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

        private void frmConexion_Load(object sender, EventArgs e)
        {
            this.Text += "N° " + oFactura.NumFactura;
            LlenarComentarios();
        }

        private void frmFacturaAnular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t9");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }

        private void timCreaNC_Tick(object sender, EventArgs e)
        {
            if (ttime == 5)
            {
                ttime = 0;
                lblMjFacturaElectronica.Text = "Generando Nota de Crédito";
                lblMjFacturaElectronica.Visible = true;
                pbFacturaElectronica.Visible = true;

                timCreaNC.Stop();
                CrearNC();
                pbFacturaElectronica.Visible = false;
            }
            ttime++;
        }

        private void LlenarComentarios()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    cboComentarios.DataSource = oConexion.EjecutaSentencia("select distinct FAC_COMENTARIO from TBL_FACTURA F where f.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' order by FAC_COMENTARIO");
                    cboComentarios.DisplayMember = "FAC_COMENTARIO";
                    cboComentarios.ValueMember = "FAC_COMENTARIO";

                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void timFecha_Tick(object sender, EventArgs e)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (oConexion.abrirConexion())
                {
                    this.Text = "Conexion al Sistema               " + oConexion.fecha().ToString();
                    oConexion.cerrarConexion();
                }
                else
                {
                    this.Text = "Conexion al Sistema               " + oConexion.fecha().ToString();
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

        public Boolean Internet()
        {
            try
            {
                Boolean internet = false;

                //Revisar la conexión a la Red local
                bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

                if (RedActiva)
                {
                    //Ahora si estamos conectados a la Red podemos enviar un ping a una pagina en Internet para asegurar la conexión.
                    Uri Url = new System.Uri("https://www.google.com/");

                    WebRequest WebRequest;
                    WebRequest = System.Net.WebRequest.Create(Url);
                    WebResponse objetoResp;

                    try
                    {
                        objetoResp = WebRequest.GetResponse();
                        internet = true;
                        objetoResp.Close();
                    }
                    catch (Exception e)
                    {
                        internet = false;
                    }
                    WebRequest = null;
                }

                return internet;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Boolean AplicaFE(out String pApiToken, out String pAccessToken)
        {
            try
            {
                pApiToken = "";
                pAccessToken = "";

                Boolean vAplicaFE = false;
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oDatosGeneral = oConexion.EjecutaSentencia("select IND_FACT_ELECT, API_TOKEN_WS_FE, ACCESS_TOKEN_WS_FE from TBL_EMPRESA where no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    String vIND_FACT_ELECT = "N";

                    foreach (DataRow ofila in oDatosGeneral.Rows)
                    {
                        vIND_FACT_ELECT = ofila["IND_FACT_ELECT"].ToString();
                        pApiToken = ofila["API_TOKEN_WS_FE"].ToString();
                        pAccessToken = ofila["ACCESS_TOKEN_WS_FE"].ToString();
                    }

                    if (vIND_FACT_ELECT.Equals("S"))
                        vAplicaFE = true;
                }
                return vAplicaFE;
            }
            catch (Exception ex)
            {
                pApiToken = "";
                pAccessToken = "";
                return false;
            }
        }

        private void CrearNC()
        {
            try
            {
                FacturaDAO oFacturaDAO = new FacturaDAO();

                if (oFactura.Indice == 0 || String.IsNullOrEmpty(oFactura.Fe_Clave) || !oFactura.Estado.Equals("FACTURADA") || oFactura.Fe_Comprobacion.Equals("POR COMPROBAR"))
                {
                    pbFacturaElectronica.Visible = false;
                    lblMjFacturaElectronica.Text = "";
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable odata = oFacturaDAO.ConsultaFactura(oFactura.NumFactura.ToString(), PROYECTO.Properties.Settings.Default.No_cia);

                    String usa_FE = odata.Rows[0]["FAC_CREA_FE"].ToString();
                    if (usa_FE.Equals("N"))
                    {
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    DataTable oDatosGeneral = oConexion.EjecutaSentencia("select CODIGO_ACTIVIDAD, SUCURSAL, CAJA from TBL_EMPRESA where no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");
                    String vsucursal = "001";
                    String vtipo_documento = "01";
                    String vrazon = "01";
                    String vpunto = "00001";
                    String vactividad = "";
                    String vcondicion_venta = "";

                    foreach (DataRow ofila in oDatosGeneral.Rows)
                    {
                        vsucursal = ofila["SUCURSAL"].ToString();
                        vpunto = ofila["CAJA"].ToString();
                        vactividad = ofila["CODIGO_ACTIVIDAD"].ToString();
                    }

                    List<Linea> oListLineas = new List<Linea>();

                    FacturaDetalleDAO oFacturaDetalleDAO = new FacturaDetalleDAO();

                    DataTable oDetalle = oFacturaDetalleDAO.Consulta(oFactura.Indice, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    foreach (DataRow ofila in oDetalle.Rows)
                    {
                        Impuestos oImpuestos = new Impuestos();
                        DataTable oDtImpuestos = oConexion.EjecutaSentencia("SELECT i.EQUIV_IMP_FE FROM TBL_SERVICIO_IMPUESTOS si, TBL_IMPUESTOS i WHERE si.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and si.no_cia = i.no_cia and si.CODIGO_SERVICIO = '" + ofila["detfac_codigo"].ToString() + "' and si.clave = i.clave");

                        foreach (DataRow ofilaImp in oDtImpuestos.Rows)
                        {
                            _01 im01 = new _01
                            {
                                tarifa = ofilaImp["EQUIV_IMP_FE"].ToString()
                            };

                            oImpuestos = new Impuestos
                            {
                                _01 = im01
                            };
                        }

                        if (String.IsNullOrEmpty(ofila["SER_CODIGO"].ToString()))
                        {
                            MessageBox.Show("El código del servicio es requerido para la Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }

                        if (String.IsNullOrEmpty(ofila["Cod_cabys"].ToString()))
                        {
                            MessageBox.Show("El código CABYS del servicio (" + ofila["SER_CODIGO"].ToString() + ") es requerido para la Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }

                        if (String.IsNullOrEmpty(ofila["detfac_descripcion"].ToString()))
                        {
                            MessageBox.Show("La descripción del servicio (" + ofila["SER_CODIGO"].ToString() + ") es requerida para la Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }

                        if (String.IsNullOrEmpty(ofila["detfac_cantidad"].ToString()))
                        {
                            MessageBox.Show("La cantidad del servicio (" + ofila["SER_CODIGO"].ToString() + ") es requerida para la Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }

                        if (String.IsNullOrEmpty(ofila["DETFAC_PRECIO_UNITARIO"].ToString()))
                        {
                            MessageBox.Show("El precio del servicio (" + ofila["SER_CODIGO"].ToString() + ") es requerido para la Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }


                        Linea oLinea = new Linea
                        {
                            codigo = ofila["SER_CODIGO"].ToString(),
                            codigoCabys = ofila["Cod_cabys"].ToString(),
                            partidaArancelaria = null,
                            descripcion = ofila["detfac_descripcion"].ToString(),
                            cantidad = ofila["detfac_cantidad"].ToString(),
                            unidad = "Unid",//ofila["detfac_medida"].ToString(),
                            precioUnitario = ofila["DETFAC_PRECIO_UNITARIO"].ToString(),
                            descuento = ofila["DETFAC_DESCUENTO"].ToString(),
                            naturalezaDescuento = "",
                            impuestos = oImpuestos
                        };

                        oListLineas.Add(oLinea);
                    }


                    if (oFacturaDetalleDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oFacturaDetalleDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    String vtipo_cedula = "";
                    String vcedula = "";
                    String vcorreo = "";
                    String vmoneda = "";
                    Double vtipo_cambio = 0;
                    String vnombre = "";
                    String vNumFactura = "";

                    List<string> medio_pagos = new List<string>();




                    if (String.IsNullOrEmpty(odata.Rows[0]["fac_tipo"].ToString()))
                    {
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (odata.Rows.Count > 0)
                    {
                        DataTable oDTTipoID = oConexion.EjecutaSentencia("select EQUIV_ID_FE, CLI_IDENTIFICACION, CLI_CORREO from TBL_CLIENTES c, TBL_TIPOS_ID t where no_Cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and cli_linea = '" + odata.Rows[0]["fac_cliente"].ToString() + "' and t.CODIGO = c.CLI_TIPO_ID");

                        if (oDTTipoID.Rows.Count > 0)
                        {
                            vtipo_cedula = oDTTipoID.Rows[0]["EQUIV_ID_FE"].ToString();
                            vcedula = oDTTipoID.Rows[0]["CLI_IDENTIFICACION"].ToString();
                            vcorreo = oDTTipoID.Rows[0]["CLI_CORREO"].ToString();
                        }

                        //if (odata.Rows[0]["fac_tipo"].ToString().Equals("CONTADO"))
                        vcondicion_venta = "01";
                        // else
                        //    vcondicion_venta = "02";

                        vmoneda = odata.Rows[0]["fac_moneda"].ToString();
                        vtipo_cambio = double.Parse(odata.Rows[0]["fac_tipo_cambio"].ToString());
                        vnombre = odata.Rows[0]["fac_nombre"].ToString();
                        vNumFactura = odata.Rows[0]["fac_numero"].ToString();

                        String tipopago = odata.Rows[0]["fac_tipopago"].ToString();

                        //chkEfectivo
                        if (tipopago.Substring(0, 2).Equals("01"))
                            medio_pagos.Add("01");
                        //chkTarjeta
                        if (tipopago.Substring(2, 2).Equals("02"))
                            medio_pagos.Add("02");
                        //chkCheque
                        if (tipopago.Substring(4, 2).Equals("03"))
                            medio_pagos.Add("03");
                        //chkTransferencia
                        if (tipopago.Substring(6, 2).Equals("04"))
                            medio_pagos.Add("04");
                        //chkTerceros
                        if (tipopago.Substring(8, 2).Equals("05"))
                            medio_pagos.Add("05");
                        //chkOtros
                        if (tipopago.Substring(10, 2).Equals("99"))
                            medio_pagos.Add("99");
                    }

                    if (String.IsNullOrEmpty(vsucursal))
                    {
                        MessageBox.Show("Falta parametrizar el campo SUCURSAL para los datos de Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }
                    if (String.IsNullOrEmpty(vtipo_documento))
                    {
                        MessageBox.Show("Falta parametrizar el campo TIPO DE DOCUMENTO para los datos de Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }
                    if (String.IsNullOrEmpty(vpunto))
                    {
                        MessageBox.Show("Falta parametrizar el campo CAJA para los datos de Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }
                    if (String.IsNullOrEmpty(vactividad))
                    {
                        MessageBox.Show("Falta parametrizar el campo CÓDIGO DE ACTIVIDAD para los datos de Factura Electrónica!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vtipo_cedula))
                    {
                        MessageBox.Show("No se encuentra el dato de tipo de cédula del cliente!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vcedula))
                    {
                        MessageBox.Show("No se encuentra el dato de cédula del cliente!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vcorreo))
                    {
                        MessageBox.Show("No se encuentra el dato de correo electrónico del cliente!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vcondicion_venta))
                    {
                        MessageBox.Show("No se encuentra el dato de condición de venta de la factura!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vmoneda))
                    {
                        MessageBox.Show("No se encuentra el dato de moneda de la factura!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (vtipo_cambio == 0)
                    {
                        MessageBox.Show("No se encuentra el dato de Tipo de Cambio de la factura!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (String.IsNullOrEmpty(vnombre))
                    {
                        MessageBox.Show("No se encuentra el dato de A nombre de en la factura!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }

                    if (medio_pagos.Count == 0)
                    {
                        MessageBox.Show("Se debe seleccionar al menos un tipo de pago de la factura!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbFacturaElectronica.Visible = false;
                        return;
                    }


                    RootFE oRootFE = new RootFE
                    {
                        sucursal = vsucursal,
                        //tipo_documento = vtipo_documento,
                        razon = vrazon,
                        punto = vpunto,
                        actividad = vactividad,
                        medio_pago = medio_pagos,
                        condicion_venta = vcondicion_venta,
                        moneda = vmoneda,
                        tipo_cambio = vmoneda.Equals("CRC") ? 1 : vtipo_cambio,
                        //tipo_cedula = vtipo_cedula,
                        //cedula = vcedula,
                        //nombre = vnombre,
                        //nombre_comercial = "",
                        //correo = vcorreo,
                        lineas = oListLineas,
                        comentarios = "Nota de Crédito Realizada con SAFE - Factura Local No: " + vNumFactura
                    };

                    var json = JsonConvert.SerializeObject(oRootFE);

                    String jfinal = json.Replace("_01", "01");

                    if (Internet())
                    {
                        if (!AplicaFE(out String pApiToken, out String pAccessToken))
                            return;

                        String oDatosJson = oControl.CrearNC(jfinal, oFactura.Fe_Clave, out Boolean /*HttpStatusCode*/ vOut, out Boolean vTimeOut, pApiToken, pAccessToken);

                        if (vTimeOut)
                        {
                            MessageBox.Show("A sucedido un problema de conexión, por favor intente nuevamente, si el problema persiste informe a Soporte Técnico.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pbFacturaElectronica.Visible = false;
                            return;
                        }

                        var jobject = JsonConvert.DeserializeObject<Root>(oDatosJson);

                        if (vOut)/* == HttpStatusCode.OK)*/
                        {
                            int vcodigo = jobject.codigo;
                            string vclave_NC = jobject.documento.clave;
                            string vconsecutivo_NC = jobject.documento.consecutivo;
                            string vrecepcion_NC = jobject.documento.recepcion;
                            string vcomprobacion_NC = jobject.documento.comprobacion;

                            if (String.IsNullOrEmpty(vclave_NC))
                                vclave_NC = "";
                            if (String.IsNullOrEmpty(vconsecutivo_NC))
                                vconsecutivo_NC = "";
                            if (String.IsNullOrEmpty(vrecepcion_NC))
                                vrecepcion_NC = "";
                            if (String.IsNullOrEmpty(vcomprobacion_NC))
                                vcomprobacion_NC = "";

                            try
                            {
                                if (vcodigo == 200)
                                {
                                    oFactura.Fe_Clave_NC = vclave_NC;
                                    oFactura.Fe_Consecutivo_NC = vconsecutivo_NC;
                                    oFactura.Fe_Recepcion_NC = vrecepcion_NC;
                                    oFactura.Fe_Comprobacion_NC = vcomprobacion_NC;

                                    if (oFacturaDAO.ModificaEstadoCreaFactura_FE_NC(oFactura) > 0)
                                    {
                                        lblMjFacturaElectronica.Text = "Comprobando Factura Electrónica";
                                        lblMjFacturaElectronica.Visible = true;
                                        pbFacturaElectronica.Visible = true;

                                        timCompruebaNC.Start();
                                    }
                                    else
                                        MessageBox.Show("Ocurrió un error al guardar los datos: " + oFacturaDAO.DescError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch { }

                            oConexion.cerrarConexion();
                        }
                        else
                            MessageBox.Show("Perdida de conexión con API de Facturador Virtual.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Sin conexión a internet!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                    pbFacturaElectronica.Visible = false;
                    return;
                }

                pbFacturaElectronica.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar API!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }
                pbFacturaElectronica.Visible = false;
            }
        }

        public class RootFE
        {
            public string sucursal { get; set; }
            // public string tipo_documento { get; set; }
            public string punto { get; set; }
            public string actividad { get; set; }
            public string razon { get; set; }
            public List<string> medio_pago { get; set; }
            public string condicion_venta { get; set; }
            public string moneda { get; set; }
            public double tipo_cambio { get; set; }
            //public string tipo_cedula { get; set; }
            //public string cedula { get; set; }
            //public string nombre { get; set; }
            //public string nombre_comercial { get; set; }
            //public string correo { get; set; }
            public List<Linea> lineas { get; set; }
            public string comentarios { get; set; }
        }

        private void timCompruebaNC_Tick(object sender, EventArgs e)
        {
            if (ttime == 5)
            {
                ttime = 0;
                lblMjFacturaElectronica.Text = "Comprobando Nota de Crédito";
                lblMjFacturaElectronica.Visible = true;
                pbFacturaElectronica.Visible = true;

                timCompruebaNC.Stop();
                ComprobarNC();
                pbFacturaElectronica.Visible = false;
            }
            ttime++;
        }

        private void ComprobarNC()
        {
            try
            {
                if (String.IsNullOrEmpty(oFactura.Fe_Clave_NC))
                    return;

                if (Internet())
                {
                    if (!AplicaFE(out String pApiToken, out String pAccessToken))
                        return;

                    String oDatosJson = oControl.ComprobarFE(oFactura.Fe_Clave_NC, out Boolean /*HttpStatusCode*/ vOut, out Boolean vTimeOut, pApiToken, pAccessToken);

                    if (vTimeOut)
                    {
                        MessageBox.Show("A sucedido un problema de conexión, por favor intente nuevamente, si el problema persiste informe a Soporte Técnico.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    var jobject = JsonConvert.DeserializeObject<Root>(oDatosJson);

                    if (vOut)/* == HttpStatusCode.OK)*/
                    {
                        oConexion.cerrarConexion();
                        if (oConexion.abrirConexion())
                        {
                            int vcodigo = jobject.codigo;
                            string vestado = jobject.estado;
                            string vmensaje = jobject.mensaje;
                            string vrespuesta = jobject.respuesta;

                            if (String.IsNullOrEmpty(vestado))
                                vestado = "";
                            if (String.IsNullOrEmpty(vmensaje))
                                vmensaje = "";
                            if (String.IsNullOrEmpty(vrespuesta))
                                vrespuesta = "";

                            try
                            {
                                if (vcodigo == 200)
                                {
                                    //oFactura.Fe_Codigo = vcodigo.ToString();
                                    //oFactura.Fe_ContenidoXml = vrespuesta;
                                    //oFactura.Fe_Errores = vmensaje;
                                    oFactura.Fe_Comprobacion_NC = vestado;

                                    FacturaDAO oFacturaDAO = new FacturaDAO();
                                    oFacturaDAO.ModificaEstadoFactura_FE_NC(oFactura);
                                }

                                AnularFactura();
                            }
                            catch { }

                            oConexion.cerrarConexion();


                        }
                        else
                        {
                            MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Perdida de conexión con API de Facturador Virtual.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Sin conexión a internet!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar API!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }

            }
        }


        public class Linea
        {
            public string codigo { get; set; }
            public string codigoCabys { get; set; }
            public object partidaArancelaria { get; set; }
            public string descripcion { get; set; }
            public string cantidad { get; set; }
            public string unidad { get; set; }
            public string precioUnitario { get; set; }
            public string descuento { get; set; }
            public string naturalezaDescuento { get; set; }

            public Impuestos impuestos { get; set; }
        }

        public class Impuestos
        {
            public _01 _01 { get; set; }
        }

        public class _01
        {
            public string tarifa { get; set; }
        }
    }
}