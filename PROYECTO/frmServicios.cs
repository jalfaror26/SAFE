using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace PROYECTO
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        private ServicioDAO oServicioDAO = new ServicioDAO();
        private ProveedorDAO oProveedorDAO = new ProveedorDAO();
        private static frmServicios instance = null;
        private Boolean nuevo = false;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Servicio oServicio;
        private double indice = 0;
        private readonly Ent_CW oControl = new Ent_CW();
        private int ttime = 0;

        private String codigo = "par_Servicios", descripcion = "Mantenimiento de servicios", modulo = "Mantenimientos";

        private String codigo2 = "", descripcion2 = "", modulo2 = "";

        public String Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public static frmServicios getInstance()
        {
            if (instance == null)
                instance = new frmServicios();
            return instance;
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            try
            {
                btnDescargarClientes.Enabled = AplicaFE(out String pApiToken, out String pAccessToken);
                btnMNuevo.PerformClick();
                Llenar_Grid();
            }
            catch (Exception ex)
            {

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

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtCodigo.ReadOnly = false;
            txtCodigo.BackColor = Color.White;
            indice = 0;

            nuevo = true;
            /*Codigos*/
            /*Descripciones*/
            txtDesBreveArt.Clear();
            txtCodCabys.Clear();
            /*Precios*/
            txtPrecioCosto.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            rboExento.Checked = true;
            btnImpuestos.Enabled = false;
        }

        private void Agregar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicio = new Servicio();
                    oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oServicio.Tipo = "SER";
                    oServicio.Impuestos = rboExento.Checked ? 0 : 1;
                    oServicio.Cod_cabys = txtCodCabys.Text;

                    oServicio.Venta_IVI = "N";

                    oServicio.Indice = indice;
                    oServicio.Codigo = txtCodigo.Text;
                    oServicio.Descripcion = txtDesBreveArt.Text;

                    oServicio.Nombre = txtDesBreveArt.Text;
                    oServicio.TipoCodigo = "EX";

                    indice = double.Parse(oServicioDAO.Agregar(oServicio));

                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al guardar:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oServicio.Impuestos == 1 && nuevo)
                        {
                            btnImpuestos.Enabled = true;
                            btnImpuestos.PerformClick();

                            Llenar_Grid();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Llenar_Grid();
                            LimpiarCampos();
                        }

                        nuevo = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Modificar()
        {
            try
            {
                if (txtDesBreveArt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite la descripción del servicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Agregar();
            }
            catch (Exception ex) { }
        }

        private void Eliminar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicio = new Servicio();
                    oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oServicio.Tipo = "SER";
                    oServicio.Indice = indice;

                    oServicioDAO.Eliminar(oServicio);
                    if (oServicioDAO.Error())
                    {
                        MessageBox.Show("Error al eliminar:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                    Llenar_Grid();
                    btnMNuevo.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                instance = null;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtCantEmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;
                for (int i = 0; i < txtPrecioCosto.Text.Length; i++)
                {
                    if (txtPrecioCosto.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                txtPrecioCosto.Text = "0.00";
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int puntos = 0;
                for (int i = 0; i < txtPrecioVenta.Text.Length; i++)
                {
                    if (txtPrecioVenta.Text[i].Equals('.'))
                        puntos++;
                }

                if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                txtPrecioVenta.Text = "0.00";
            }
        }

        private void txtPrecioCosto_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrecioCosto.Text = Double.Parse(txtPrecioCosto.Text.Substring(1)).ToString("########0.00");

                if (txtPrecioCosto.Text.Equals("0.00"))
                    txtPrecioCosto.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioVenta_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrecioVenta.Text = Double.Parse(txtPrecioVenta.Text.Substring(1)).ToString("########0.00");
                if (txtPrecioVenta.Text.Equals("0.00"))
                    txtPrecioVenta.Clear();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecioVenta.Text.Trim().Equals(""))
                    txtPrecioVenta.Text = "0.00";

                txtPrecioVenta.Text = Double.Parse(txtPrecioVenta.Text).ToString("###,###,##0.00");
                //ponerSimbolos();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioCosto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecioCosto.Text.Trim().Equals(""))
                    txtPrecioCosto.Text = "0.00";

                txtPrecioCosto.Text = Double.Parse(txtPrecioCosto.Text).ToString("###,###,##0.00");
                //ponerSimbolos();
            }
            catch (Exception ex)
            {

            }
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
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo2);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo2, modulo2, descripcion2, PROYECTO.Properties.Settings.Default.No_cia);
                    }

                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo2, PROYECTO.Properties.Settings.Default.No_cia);
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

        public void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioDAO.ConsultarTodo(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indice = double.Parse(dgrDatos["SER_INDICE", e.RowIndex].Value.ToString());
                txtCodigo.Text = dgrDatos["SER_CODIGO", e.RowIndex].Value.ToString();
                txtDesBreveArt.Text = dgrDatos["SER_DESC_BREVE", e.RowIndex].Value.ToString();
                txtCodCabys.Text = dgrDatos["COD_CABYS", e.RowIndex].Value.ToString();
                String tipoImpuesto = dgrDatos["SER_IMPUESTOS", e.RowIndex].Value.ToString();

                if (dgrDatos["SER_TIPO_CODIGO", e.RowIndex].Value.ToString().Equals("IN"))
                {
                    txtCodigo.ReadOnly = false;
                    txtCodigo.BackColor = Color.White;
                }
                else
                {
                    txtCodigo.ReadOnly = true;
                    txtCodigo.BackColor = Color.Beige;
                }

                if (tipoImpuesto.Equals("0"))
                    rboExento.Checked = true;
                else
                    rboGravado.Checked = true;

                nuevo = false;

                txtDesBreveArt.Focus();

            }
            catch (Exception ex) { }
        }

        private void dgrDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void txtFiltroCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtFiltroDescBreve.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    filtrarGrid(1, txtFiltroCodigo.Text);
            }
        }

        private void txtFiltroDescBreve_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtFiltroDescBreve.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    filtrarGrid(2, txtFiltroDescBreve.Text);
            }
        }

        private void filtrarGrid(int ind, string palabraFiltro)
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioDAO.Listar(ind, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oServicioDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex) { }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();

        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void rboExento_CheckedChanged(object sender, EventArgs e)
        {
            btnImpuestos.Enabled = false;
        }

        private void rboGravado_CheckedChanged(object sender, EventArgs e)
        {
            if (indice > 0)
                btnImpuestos.Enabled = true;
        }

        private void btnImpuestos_Click(object sender, EventArgs e)
        {
            oServicio = new Servicio();

            oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
            oServicio.Codigo = txtCodigo.Text;
            oServicio.Indice = indice;
            oServicio.Descripcion = txtDesBreveArt.Text;

            frmServicioImpuestos ofrmArticulosPresentacion = frmServicioImpuestos.getInstance(oServicio);
            codigo2 = ofrmArticulosPresentacion.Codigo;
            descripcion2 = ofrmArticulosPresentacion.Descripcion;
            modulo2 = ofrmArticulosPresentacion.Modulo;
            if (!TienePermiso())
            {
                ofrmArticulosPresentacion.MdiParent = this.MdiParent;
                ofrmArticulosPresentacion.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso para accesar esta pantalla, comuníquese con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ofrmArticulosPresentacion = null;
            }
        }

        private void btnDescargarClientes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Si algún servicio ya existe, este será actualizado!!\n¿Seguro que desea continuar?", "Advertencia", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ttime = 0;
                progressBar1.Visible = true;
                timer1.Start();
            }
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtDesBreveArt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La descripción del artículo está vacía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Eliminar();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ttime == 5)
            {
                ttime = 0;
                timer1.Stop();
                ActualizarServicios();
                progressBar1.Visible = false;
            }
            ttime++;
        }

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t3");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
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

        private void ActualizarServicios()
        {
            try
            {
                if (Internet())
                {
                    if (!AplicaFE(out String pApiToken, out String pAccessToken))
                    {
                        progressBar1.Visible = false;
                        return;
                    }


                    String oDatosJson = oControl.TraerServicios(out Boolean /*HttpStatusCode*/ vOut, out Boolean vTimeOut, pApiToken, pAccessToken);

                    if (vTimeOut)
                    {
                        progressBar1.Visible = false;
                        MessageBox.Show("A sucedido un problema de conexión, por favor intente nuevamente, si el problema persiste informe a Soporte Técnico.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var jobject = JsonConvert.DeserializeObject<Root>(oDatosJson);

                    if (vOut)/* == HttpStatusCode.OK)*/
                    {
                        Boolean vHayError = false;
                        int totalServicios = jobject.productos.Count;
                        int totalErrores = totalServicios;


                        oConexion.cerrarConexion();
                        if (oConexion.abrirConexion())
                        {
                            foreach (Producto oResultado in jobject.productos)
                            {
                                int vid = oResultado.id;
                                string vcodigo = oResultado.codigo;
                                String vcodigoComercial = oResultado.codigoComercial;
                                String vdescripcionGeneral = oResultado.descripcionGeneral;
                                String vunidad = oResultado.unidad;
                                double vprecio = oResultado.precio;
                                double vcantidad = oResultado.cantidad;
                                string vdetalle = oResultado.detalle;
                                String vcodigo_barra = oResultado.codigo_barra;


                                if (String.IsNullOrEmpty(vcodigo))
                                    vcodigo = "";
                                if (String.IsNullOrEmpty(vcodigoComercial))
                                    vcodigoComercial = "";
                                if (String.IsNullOrEmpty(vdescripcionGeneral))
                                    vdescripcionGeneral = "";
                                if (String.IsNullOrEmpty(vunidad))
                                    vunidad = "";
                                if (String.IsNullOrEmpty(vdetalle))
                                    vdetalle = "";
                                if (String.IsNullOrEmpty(vcodigo_barra))
                                    vcodigo_barra = "";

                                try
                                {
                                    if (String.IsNullOrEmpty(vcodigo.Trim()) || String.IsNullOrEmpty(vdetalle.Trim()) || String.IsNullOrEmpty(vunidad.Trim()))
                                        vHayError = true;
                                    else
                                    {
                                        oServicio = new Servicio();
                                        oServicio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                                        oServicio.Tipo = "SER";
                                        oServicio.Impuestos = 1;
                                        oServicio.Cod_cabys = vcodigoComercial;
                                        oServicio.Venta_IVI = "N";
                                        oServicio.Indice = 0;
                                        oServicio.Codigo = vcodigo.ToUpper();
                                        oServicio.Descripcion = vdetalle.ToUpper();
                                        oServicio.Nombre = vdescripcionGeneral;
                                        oServicio.TipoCodigo = "EX";

                                        indice = double.Parse(oServicioDAO.Agregar(oServicio));

                                        if (oServicioDAO.Error())
                                        {
                                            vHayError = true;
                                            progressBar1.Visible = false;
                                            MessageBox.Show("Error al Guardar el Servicio: " + oServicio.Codigo + " - " + oServicio.Nombre + "\n" + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                            totalErrores--;
                                    }
                                }
                                catch { }
                            }
                            oConexion.cerrarConexion();

                            progressBar1.Visible = false;
                            if (vHayError)
                                MessageBox.Show("Proceso Finalizado con errores!!\nTotal servicios: " + totalServicios.ToString("###,###,##0") + "\nTotal errores: " + totalErrores.ToString("###,###,##0"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Proceso Finalizado correctamente!!\nTotal servicios: " + totalServicios.ToString("###,###,##0") + "\nTotal errores: " + totalErrores.ToString("###,###,##0"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            progressBar1.Visible = false;
                            MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                            return;
                        }
                    }
                    else
                    {
                        progressBar1.Visible = false;
                        MessageBox.Show("Error al extraer datos!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    progressBar1.Visible = false;
                    Llenar_Grid();
                    btnMNuevo.PerformClick();
                }
                else
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("Sin conexión a internet!!!", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
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

    }
}