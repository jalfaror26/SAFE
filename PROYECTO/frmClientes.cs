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
    public partial class frmClientes : Form
    {
        private frmClientes()
        {
            InitializeComponent();
        }

        private ClienteDAO oClienteDAO = new ClienteDAO();
        private static frmClientes instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Cliente oCliente;
        private Int32 indice;
        private String codigo = "par_clientes", descripcion = "Registro de clientes del sistema.", modulo = "Mantenimientos";
        private string txtCodigo = "";
        private Hacienda_DireccionDAO oHacienda_DireccionDAO = new Hacienda_DireccionDAO();
        private readonly Ent_CW oControl = new Ent_CW();
        private int ttime = 0;

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

        public static frmClientes getInstance()
        {
            if (instance == null)
                instance = new frmClientes();
            return instance;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            btnDescargarClientes.Enabled = AplicaFE(out String pApiToken, out String pAccessToken);
            this.Text = this.Text + " - " + this.Name;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Clientes ";
            LlenaProvincias();
            Llenar_Grid();
            LlenarCombos();
            btnMNuevo.PerformClick();
            LimpiarCampos();
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

        private void LlenarCombos()
        {
            cboTipoId.Items.Clear();

            cboTipoId.Items.Add("Física");
            cboTipoId.Items.Add("Jurídica");
            cboTipoId.Items.Add("Pasaporte");
            cboTipoId.Items.Add("Residencia");
            cboTipoId.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            indice = 0;
            cboTipoId.Items.Clear();
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtContacto.Text = "";
            txtCorreo.Text = "";
            txtUbicacion.Text = "";
            txtDias.Text = "0";
            LlenarCombos();
            txtIdentificacion.Clear();
            dgrDatos.ClearSelection();
            cboLCMoneda.SelectedIndex = 0;
            txtLCLimite.Text = "0";
            cboProvincia.SelectedIndex = 0;
            /*************************************/
            txtBId.Text = "";
            txtBNombre.Text = "";
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oClienteDAO.Consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];


                    //Evaluar si ocurriió un Error
                    if (oClienteDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
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

        private void Llenar_Grid(int tipo, String palabra)
        {
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                dgrDatos.DataSource = oClienteDAO.Listar(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                if (oClienteDAO.Error())
                    MessageBox.Show("Error al listar los datos:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                indice = Convert.ToInt32(dgrDatos["CLI_LINEA", e.RowIndex].Value.ToString());
                txtCodigo = dgrDatos["CLI_ID", e.RowIndex].Value.ToString();
                switch (dgrDatos["CLI_TIPO_ID", e.RowIndex].Value.ToString())
                {
                    case "F": cboTipoId.Text = "Física"; break;
                    case "J": cboTipoId.Text = "Jurídica"; break;
                    case "P": cboTipoId.Text = "Pasaporte"; break;
                    case "R": cboTipoId.Text = "Residencia"; break;
                }
                txtNombre.Text = dgrDatos["CLI_NOMBRE", e.RowIndex].Value.ToString();
                txtTelefono.Text = dgrDatos["CLI_TELEFONO", e.RowIndex].Value.ToString();
                txtFax.Text = dgrDatos["CLI_FAX", e.RowIndex].Value.ToString();
                txtContacto.Text = dgrDatos["CLI_CONTACTO", e.RowIndex].Value.ToString();
                txtCorreo.Text = dgrDatos["CLI_CORREO", e.RowIndex].Value.ToString();
                txtUbicacion.Text = dgrDatos["CLI_UBICACION", e.RowIndex].Value.ToString();
                txtDias.Text = dgrDatos["CLI_DIAS", e.RowIndex].Value.ToString();
                txtIdentificacion.Text = dgrDatos["cli_identificacion", e.RowIndex].Value.ToString();

                cboLCMoneda.SelectedItem = dgrDatos["CLI_LC_MONEDA", e.RowIndex].Value.ToString();
                txtLCLimite.Text = double.Parse(dgrDatos["CLI_LC_LIMITE", e.RowIndex].Value.ToString()).ToString("###,###,##0.00");

                //LlenaProvincias();

                cboProvincia.SelectedValue = dgrDatos["PROVINCIA", e.RowIndex].Value.ToString();
                cboCanton.SelectedValue = dgrDatos["CANTON", e.RowIndex].Value.ToString();
                cboDistrito.SelectedValue = dgrDatos["DISTRITO", e.RowIndex].Value.ToString();
                cboBarrio.SelectedValue = dgrDatos["BARRIO", e.RowIndex].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private String EvaluarTipoID()
        {
            String ret = "";
            if (cboTipoId.Text.Equals("Jurídica"))
                ret = "J";
            if (cboTipoId.Text.Equals("Física"))
                ret = "F";
            if (cboTipoId.Text.Equals("Pasaporte"))
                ret = "P";
            if (cboTipoId.Text.Equals("Residencia"))
                ret = "R";
            return ret;
        }

        private void Guardar()
        {
            try
            {

                if (txtNombre.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (txtIdentificacion.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCliente = new Cliente();

                    oCliente.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCliente.Indice = indice;
                    oCliente.Id = "";//txtCodigo.Text;
                    oCliente.TipoId = EvaluarTipoID();
                    oCliente.Nombre = txtNombre.Text;
                    oCliente.Telefono = txtTelefono.Text;
                    oCliente.Fax = txtFax.Text;
                    oCliente.Contacto = txtContacto.Text;
                    oCliente.Correo = txtCorreo.Text;
                    oCliente.Ubicacion = txtUbicacion.Text;
                    oCliente.Identificacion = txtIdentificacion.Text;
                    if (txtDias.Text.Trim().Equals(""))
                        oCliente.Dias = 0;
                    else
                        oCliente.Dias = Convert.ToInt32(txtDias.Text);

                    oCliente.Almacen = 0;
                    oCliente.DescAlmacen = "";

                    oCliente.Lc_limite = double.Parse(txtLCLimite.Text);
                    oCliente.Lc_moneda = cboLCMoneda.SelectedItem.ToString();

                    oCliente.Provincia = ((KeyValuePair<string, string>)cboProvincia.SelectedItem).Key;
                    oCliente.Canton = ((KeyValuePair<string, string>)cboCanton.SelectedItem).Key;
                    oCliente.Distrito = ((KeyValuePair<string, string>)cboDistrito.SelectedItem).Key;
                    oCliente.Barrio = ((KeyValuePair<string, string>)cboBarrio.SelectedItem).Key;

                    if (indice == 0)
                        oClienteDAO.Agregar(oCliente, out indice);
                    else
                        oClienteDAO.Modificar(oCliente);

                    if (oClienteDAO.Error())
                        MessageBox.Show("Error al Guardar:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Guardado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Llenar_Grid();
                        btnMNuevo.PerformClick();
                    }
                    oConexion.cerrarConexion();
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

        private void Eliminar()
        {
            try
            {
                if (dgrDatos.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro a Eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCliente = new Cliente();

                    oCliente.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCliente.Indice = indice;
                    oClienteDAO.Eliminar(oCliente);
                    if (oClienteDAO.Error())
                    {
                        MessageBox.Show("Error al Eliminar:\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Eliminado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                oConexion.cerrarConexion();
            }
        }

        private Boolean esCorreo(String correo)
        {
            try
            {
                Boolean bandera = false;
                if (correo.Equals(""))
                    bandera = true;
                else
                {
                    for (int i = 0; i < correo.Length; i++)
                    {
                        if (correo[i].Equals('@'))
                            bandera = true;
                    }
                }
                return bandera;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                instance = null;
                ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
                ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
            }
            catch { }
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBId.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    Llenar_Grid(1, txtBId.Text);
            }
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
            else
            {
                if (txtBNombre.Text.Trim().Equals(""))
                    Llenar_Grid();
                else
                    Llenar_Grid(2, txtBNombre.Text);
            }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsWhiteSpace(e.KeyChar) && !Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('(') && !e.KeyChar.Equals(')') && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
                e.Handled = true;
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsWhiteSpace(e.KeyChar) && !Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('(') && !e.KeyChar.Equals(')') && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
                e.Handled = true;
        }

        private void dgrDatos_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void txtLCLimite_Enter(object sender, EventArgs e)
        {
            txtLCLimite.Text = double.Parse(txtLCLimite.Text).ToString("########0.00");
            if (txtLCLimite.Text.Equals("0"))
                txtLCLimite.Clear();
        }

        private void txtLCLimite_Leave(object sender, EventArgs e)
        {
            if (txtLCLimite.Text.Equals(""))
                txtLCLimite.Text = "0";
            txtLCLimite.Text = double.Parse(txtLCLimite.Text).ToString("###,###,##0.00");
        }

        private void txtLCLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtLCLimite.Text.Length; i++)
            {
                if (txtLCLimite.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaCantones();
        }

        private void cboCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaDistritos();
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaBarrios();
        }

        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Ayuda();
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t4");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }

        private void LlenaProvincias()
        {
            try
            {
                oHacienda_DireccionDAO = new Hacienda_DireccionDAO();

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oDatos = oHacienda_DireccionDAO.consulta_Provincias().Tables[0];
                    oConexion.cerrarConexion();

                    if (oDatos.Rows.Count > 0)
                    {
                        Dictionary<string, string> comboSource = new Dictionary<string, string>();

                        foreach (DataRow row in oDatos.Rows)
                        {
                            comboSource.Add(row[0].ToString(), row[1].ToString());
                        }

                        cboProvincia.DataSource = new BindingSource(comboSource, null);
                        cboProvincia.DisplayMember = "Value";
                        cboProvincia.ValueMember = "Key";

                        cboProvincia.SelectedIndex = 0;
                    }

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

        private void LlenaCantones()
        {
            try
            {
                String provincia = ((KeyValuePair<string, string>)cboProvincia.SelectedItem).Key;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oDatos = oHacienda_DireccionDAO.consulta_Cantones(provincia).Tables[0];
                    oConexion.cerrarConexion();

                    if (oDatos.Rows.Count > 0)
                    {
                        Dictionary<string, string> comboSource = new Dictionary<string, string>();

                        foreach (DataRow row in oDatos.Rows)
                        {
                            comboSource.Add(row[0].ToString(), row[1].ToString());
                        }

                        cboCanton.DataSource = new BindingSource(comboSource, null);
                        cboCanton.DisplayMember = "Value";
                        cboCanton.ValueMember = "Key";

                        cboCanton.SelectedIndex = 0;
                    }
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

        private void LlenaDistritos()
        {
            try
            {
                String provincia = ((KeyValuePair<string, string>)cboProvincia.SelectedItem).Key;
                String canton = ((KeyValuePair<string, string>)cboCanton.SelectedItem).Key;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oDatos = oHacienda_DireccionDAO.consulta_Distritos(provincia, canton).Tables[0];
                    oConexion.cerrarConexion();

                    if (oDatos.Rows.Count > 0)
                    {
                        Dictionary<string, string> comboSource = new Dictionary<string, string>();

                        foreach (DataRow row in oDatos.Rows)
                        {
                            comboSource.Add(row[0].ToString(), row[1].ToString());
                        }

                        cboDistrito.DataSource = new BindingSource(comboSource, null);
                        cboDistrito.DisplayMember = "Value";
                        cboDistrito.ValueMember = "Key";

                        cboDistrito.SelectedIndex = 0;
                    }
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

        private void LlenaBarrios()
        {
            try
            {
                String provincia = ((KeyValuePair<string, string>)cboProvincia.SelectedItem).Key;
                String canton = ((KeyValuePair<string, string>)cboCanton.SelectedItem).Key;
                String distrito = ((KeyValuePair<string, string>)cboDistrito.SelectedItem).Key;

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oDatos = oHacienda_DireccionDAO.consulta_Barrios(provincia, canton, distrito).Tables[0];
                    oConexion.cerrarConexion();

                    if (oDatos.Rows.Count > 0)
                    {
                        Dictionary<string, string> comboSource = new Dictionary<string, string>();

                        foreach (DataRow row in oDatos.Rows)
                        {
                            comboSource.Add(row[0].ToString(), row[1].ToString());
                        }

                        cboBarrio.DataSource = new BindingSource(comboSource, null);
                        cboBarrio.DisplayMember = "Value";
                        cboBarrio.ValueMember = "Key";

                        cboBarrio.SelectedIndex = 0;
                    }
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

        private void btnDescargarClientes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Si algún cliente ya existe, este será actualizado!!\n¿Seguro que desea continuar?", "Advertencia", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ttime = 0;
                progressBar1.Visible = true;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ttime == 5)
            {
                ttime = 0;
                timer1.Stop();
                ActualizarClientes();
                progressBar1.Visible = false;
            }
            ttime++;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

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

        private void ActualizarClientes()
        {
            try
            {
                if (Internet())
                {
                    if (!AplicaFE(out String pApiToken, out String pAccessToken))
                        return;

                    String oDatosJson = oControl.TraerClientes(out Boolean /*HttpStatusCode*/ vOut, out Boolean vTimeOut, pApiToken, pAccessToken);

                    if (vTimeOut)
                    {
                        progressBar1.Visible = false;
                        MessageBox.Show("A sucedido un problema de conexión, por favor intente nuevamente, si el problema persiste informe a Soporte Técnico.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    oDatosJson = oDatosJson.Replace(@"""codigoPais"":null", @"""codigoPais"":506");


                    var jobject = JsonConvert.DeserializeObject<Root>(oDatosJson);

                    if (vOut)/* == HttpStatusCode.OK)*/
                    {
                        Boolean vHayError = false;
                        int totalClientes = jobject.productos.Count;
                        int totalErrores = totalClientes;


                        oConexion.cerrarConexion();
                        if (oConexion.abrirConexion())
                        {
                            foreach (Producto oResultado in jobject.productos)
                            {
                                int vid = oResultado.id;
                                String vcedula = oResultado.cedula;
                                String vtipo = oResultado.tipo;
                                String vnombre = oResultado.nombre;
                                String vcorreoElectronico = oResultado.correoElectronico;
                                int vcodigoPais = oResultado.codigoPais;
                                String vtelefono = oResultado.telefono;
                                int vprovincia = oResultado.provincia;
                                int vcanton = oResultado.canton;
                                int vdistrito = oResultado.distrito;
                                String votrasSenas = oResultado.otrasSenas;
                                String vnombreComercial = oResultado.nombreComercial;

                                if (String.IsNullOrEmpty(vcedula))
                                    vcedula = "";
                                if (String.IsNullOrEmpty(vtipo))
                                    vtipo = "";
                                if (String.IsNullOrEmpty(vnombre))
                                    vnombre = "";
                                if (String.IsNullOrEmpty(vcorreoElectronico))
                                    vcorreoElectronico = "";
                                if (String.IsNullOrEmpty(votrasSenas))
                                    votrasSenas = "";
                                if (String.IsNullOrEmpty(vnombreComercial))
                                    vnombreComercial = "";
                                if (String.IsNullOrEmpty(vtelefono))
                                    vtelefono = "";

                                try
                                {
                                    if (String.IsNullOrEmpty(vcedula.Trim()) || String.IsNullOrEmpty(vtipo.Trim()) || String.IsNullOrEmpty(vnombre.Trim()))
                                        vHayError = true;
                                    else
                                    {
                                        oCliente = new Cliente();

                                        oCliente.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                                        oCliente.Indice = 0;
                                        oCliente.Id = vid.ToString();
                                        oCliente.TipoId = vtipo.ToUpper();
                                        oCliente.Nombre = vnombre.ToUpper();
                                        oCliente.Telefono = vtelefono;
                                        oCliente.Fax = "";
                                        oCliente.Contacto = "";
                                        oCliente.Correo = vcorreoElectronico;


                                        oCliente.Ubicacion = votrasSenas.ToUpper();
                                        oCliente.Identificacion = vcedula.ToUpper();
                                        oCliente.Dias = 0;

                                        oCliente.Almacen = 0;
                                        oCliente.DescAlmacen = "";

                                        oCliente.Lc_limite = 0;
                                        oCliente.Lc_moneda = "CRC";

                                        oCliente.Provincia = vprovincia.ToString("");
                                        oCliente.Canton = vcanton.ToString("####00");
                                        oCliente.Distrito = vdistrito.ToString("00");
                                        oCliente.Barrio = "";

                                        oClienteDAO.Agregar(oCliente, out indice);

                                        if (oClienteDAO.Error())
                                        {
                                            vHayError = true;
                                            progressBar1.Visible = false;
                                            MessageBox.Show("Error al Guardar el cliente: " + oCliente.Identificacion + " - " + oCliente.Nombre + "\n" + oClienteDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show("Proceso Finalizado con errores!!\nTotal clientes: " + totalClientes.ToString("###,###,##0") + "\nTotal errores: " + totalErrores.ToString("###,###,##0"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Proceso Finalizado correctamente!!\nTotal clientes: " + totalClientes.ToString("###,###,##0") + "\nTotal errores: " + totalErrores.ToString("###,###,##0"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }

                MessageBox.Show("Error al buscar API!!!\n\nError: " + mensaje, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}