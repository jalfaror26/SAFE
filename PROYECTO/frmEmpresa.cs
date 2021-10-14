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

namespace PROYECTO
{
    public partial class frmEmpresa : Form
    {
        private frmEmpresa()
        {
            InitializeComponent();
        }
        private string origen = "";

        private EmpresaDAO oEmpresaDAO = new EmpresaDAO();
        private static frmEmpresa instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Empresa oEmpresa;
        private String codigo = "par_datos_empresa", descripcion = "Registro de los datos de la empresa.", modulo = "Mantenimientos";
        private Hacienda_DireccionDAO oHacienda_DireccionDAO = new Hacienda_DireccionDAO();

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

        public static frmEmpresa getInstance()
        {
            if (instance == null)
                instance = new frmEmpresa();
            return instance;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;

            Boolean vFacturasAbiertas = false;

            LlenaTipoID();
            LlenaProvincias();
            //LlenaCantones();
            //LlenaDistritos();
            //LlenaBarrios();

            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oMensajes = oConexion.EjecutaSentencia("select ind_facturasabiertas from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    if (oMensajes.Rows.Count > 0)
                    {
                        vFacturasAbiertas = oMensajes.Rows[0]["ind_facturasabiertas"].ToString().Equals("S") ? true : false;
                    }


                    oConexion.cerrarConexion();
                }
            }
            catch
            {
            }

            chkMultFacturasAbiertas.Checked = vFacturasAbiertas;
            chkRedondearPrecioFactura.Checked = PROYECTO.Properties.Settings.Default.RedondearPrecioVenta;

            chkImprimeAlFacturar.Checked = PROYECTO.Properties.Settings.Default.ImprimeTiquetAlFacturar;

            Llenar_Grid();
        }

        private void LlenaTipoID()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("01", "Física");
            comboSource.Add("02", "Jurídica");
            comboSource.Add("03", "DIMEX");
            comboSource.Add("04", "NITE");

            cboTipoId.DataSource = new BindingSource(comboSource, null);
            cboTipoId.DisplayMember = "Value";
            cboTipoId.ValueMember = "Key";

            cboTipoId.SelectedIndex = 0;
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

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtUbicacion.Text = "";
            txtIdentificacion.Clear();
            cboProvincia.SelectedIndex = 0;
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    origen = "";
                    DataTable oEmpresa = oEmpresaDAO.consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    oConexion.cerrarConexion();

                    imgFoto.Image = null;
                    if (oEmpresa.Rows.Count > 0)
                    {
                        String tipoID = oEmpresa.Rows[0].ItemArray[0].ToString();

                        cboTipoId.SelectedValue = tipoID;

                        txtIdentificacion.Text = DefineMascaraID(tipoID, oEmpresa.Rows[0].ItemArray[1].ToString());
                        txtNombre.Text = oEmpresa.Rows[0].ItemArray[2].ToString();
                        txtTelefono.Text = oEmpresa.Rows[0].ItemArray[4].ToString();
                        txtCorreo.Text = oEmpresa.Rows[0].ItemArray[5].ToString();
                        txtUbicacion.Text = oEmpresa.Rows[0].ItemArray[3].ToString();

                        cboProvincia.SelectedValue = oEmpresa.Rows[0]["PROVINCIA"].ToString();
                        cboCanton.SelectedValue = oEmpresa.Rows[0]["CANTON"].ToString();
                        cboDistrito.SelectedValue = oEmpresa.Rows[0]["DISTRITO"].ToString();
                        cboBarrio.SelectedValue = oEmpresa.Rows[0]["BARRIO"].ToString();

                        if (oEmpresa.Rows[0].ItemArray[0] != null)
                        {
                            byte[] imageBytes = (byte[])oEmpresa.Rows[0].ItemArray[6];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
                              imageBytes.Length);

                            ms.Write(imageBytes, 0, imageBytes.Length);
                            Image image = Image.FromStream(ms, true);
                            imgFoto.Image = image;
                        }
                    }

                    //Evaluar si ocurriió un Error
                    if (oEmpresaDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oEmpresaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Agregar()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    string nombreLogo = "";
                    byte[] bLogo;

                    try
                    {
                        int p = 0;
                        for (int x = ofdRutaImagen.FileName.Length - 1; x > 0; x--)
                        {
                            string v = ofdRutaImagen.FileName[x].ToString();
                            if (v.Equals("\\"))
                            {
                                p = x;
                                x = 0;
                            }
                        }

                        if (p > 0)
                        {
                            nombreLogo = ofdRutaImagen.FileName.Substring(p, ofdRutaImagen.FileName.Length - p);
                        }

                        Image image = imgFoto.Image;

                        using (MemoryStream mStream = new MemoryStream())
                        {
                            image.Save(mStream, image.RawFormat);
                            bLogo = mStream.ToArray();
                            nombreLogo = image.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        nombreLogo = "";
                        bLogo = new MemoryStream().ToArray();
                    }

                    string key = ((KeyValuePair<string, string>)cboTipoId.SelectedItem).Key;
                    string value = ((KeyValuePair<string, string>)cboTipoId.SelectedItem).Value;

                    oEmpresa = new Empresa();
                    oEmpresa.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oEmpresa.TipoId = key;
                    oEmpresa.Nombre = txtNombre.Text;
                    oEmpresa.Telefono = txtTelefono.Text;
                    oEmpresa.Correo = txtCorreo.Text;
                    oEmpresa.Ubicacion = txtUbicacion.Text;
                    oEmpresa.Identificacion = txtIdentificacion.Text.Replace("-", "");
                    oEmpresa.NombreLogo = nombreLogo;

                    oEmpresa.Provincia = ((KeyValuePair<string, string>)cboProvincia.SelectedItem).Key;
                    oEmpresa.Canton = ((KeyValuePair<string, string>)cboCanton.SelectedItem).Key;
                    oEmpresa.Distrito = ((KeyValuePair<string, string>)cboDistrito.SelectedItem).Key;
                    oEmpresa.Barrio = ((KeyValuePair<string, string>)cboBarrio.SelectedItem).Key;

                    oEmpresaDAO.Agregar(oEmpresa, bLogo);

                    if (oEmpresaDAO.Error())
                        MessageBox.Show("Error al guardar:\n" + oEmpresaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        PROYECTO.Properties.Settings.Default.RedondearPrecioVenta = chkRedondearPrecioFactura.Checked;

                        PROYECTO.Properties.Settings.Default.ImprimeTiquetAlFacturar = chkImprimeAlFacturar.Checked;

                        EmpresaDAO oEmpresaDAO = new EmpresaDAO();

                        oEmpresaDAO.ActualizaParametro(PROYECTO.Properties.Settings.Default.No_cia, "IND_FACTURASABIERTAS", chkMultFacturasAbiertas.Checked ? "S" : "N");

                        MessageBox.Show("Guardado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Llenar_Grid();
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

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
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

        private void imgFoto_Click(object sender, EventArgs e)
        {
            try
            {
                ofdRutaImagen.Filter = "All Formats|*.JPG|JPEG (*.JPG)|*.JPG";
                if (ofdRutaImagen.ShowDialog() == DialogResult.OK)
                {
                    origen = ofdRutaImagen.FileName;
                    imgFoto.ImageLocation = ofdRutaImagen.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btnMGuardar.Visible = true;
        }

        private void ofdRutaImagen_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.FileInfo f2 = new System.IO.FileInfo(ofdRutaImagen.FileName);
            if (f2.Length > 32000)
            {
                MessageBox.Show("Solo se permiten imagenes jpeg con tamaño menor a 32kb");
                imgFoto.Image = null;
                ofdRutaImagen = new OpenFileDialog();
            }
        }

        private void txtIdentificacion_Enter(object sender, EventArgs e)
        {
            txtIdentificacion.Text = txtIdentificacion.Text.Replace("-", "");
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtIdentificacion.Text.Length; i++)
            {
                if (txtIdentificacion.Text[i].Equals('.'))
                    puntos++;
            }

            if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                e.Handled = true;
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)cboTipoId.SelectedItem).Key;
            txtIdentificacion.Text = DefineMascaraID(key, txtIdentificacion.Text);
        }

        private String DefineMascaraID(String pTipoID, String pID)
        {
            double vIdentificacion = 0;

            if (!string.IsNullOrEmpty(pID))
                vIdentificacion = double.Parse(pID);

            String vIdentificacion2 = "";

            switch (pTipoID)
            {
                case "01":
                    vIdentificacion2 = vIdentificacion.ToString("0-0000-0000");
                    break;
                case "02":
                    vIdentificacion2 = vIdentificacion.ToString("0-000-000000");
                    break;
                case "03":
                    vIdentificacion2 = vIdentificacion.ToString("00000000000");
                    break;
                case "04":
                    vIdentificacion2 = vIdentificacion.ToString("0000000000");
                    break;
            }

            return vIdentificacion2;
        }

        private void cboTipoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)cboTipoId.SelectedItem).Key;

            String vID = txtIdentificacion.Text.Replace("-", "");

            txtIdentificacion.Text = DefineMascaraID(key, vID);
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaCantones();
            //LlenaDistritos();
            //LlenaBarrios();
        }

        private void cboCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaDistritos();
            //LlenaBarrios();
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaBarrios();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea iniciar el Backup de la Base de Datos de forma manual?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        String rutaArchivoBackup = "";

                        DataTable oMensajes = oConexion.EjecutaSentencia("select rutaArchivoBackup from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                        if (oMensajes.Rows.Count > 0)
                        {
                            rutaArchivoBackup = oMensajes.Rows[0]["rutaArchivoBackup"].ToString();

                            if (File.Exists(rutaArchivoBackup))
                            {
                                System.Diagnostics.Process.Start(@"" + rutaArchivoBackup);

                                MessageBox.Show("Respaldo iniciado exitosamente!!\n\nGuardado en la carpeta (" + rutaArchivoBackup + ").",
                                  "Información", MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("La carpeta (" + rutaArchivoBackup + ") no existe.",
                                    "Carpeta no existe", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                        }
                        oConexion.cerrarConexion();


                    }
                }
                catch
                {
                }
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