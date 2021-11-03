using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using System.IO;
using System.Xml;
using ENTIDADES;
using System.Net.Mail;
using System.Net;

namespace PROYECTO
{
    public partial class frmPrincipal : Form
    {
        private String codigo, descripcion, modulo;
        private ConexionDAO oConexion;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
        private static frmPrincipal instance = null;
        private frmMenu oMenu = null;
        public int MensajesAbiertos = 0;

        public static frmPrincipal getInstance()
        {
            if (instance == null)
                instance = new frmPrincipal();
            return instance;
        }
        private frmPrincipal()
        {
            InitializeComponent();
        }

        private Boolean TienePermiso()
        {
            try
            {
                Boolean tienePermiso = false;
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (oConexion.abrirConexion())
                {
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo, modulo, descripcion, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!PROYECTO.Properties.Settings.Default.Usuario.Equals(""))
            {
                timer1.Stop();
                try
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    oConexion.abrirConexion();
                    string ruta = oPantallaPermisoDAO.RutaImagen(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
                    try
                    {
                        if (!ruta.Equals(""))
                        {
                            this.BackgroundImage = Image.FromFile(ruta);
                            PROYECTO.Properties.Settings.Default.RutaImagen = ruta;
                        }
                        else
                        {
                            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
                            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    oConexion.cerrarConexion();


                }
                catch (Exception ex)
                {
                    oConexion.cerrarConexion();
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PROYECTO.Properties.Settings.Default.Clave = Conexion.getInstance().Clave;

            mnuPrincipal.Visible = false;
            chkMenu.Checked = false;

            //1 Conexion sencilla
            //2 Conexion grafica
            if (PROYECTO.Properties.Settings.Default.FormaConectar.Equals("1"))
            {
                frmConexion ofrmConexion = new frmConexion();
                ofrmConexion.MdiParent = this;
                ofrmConexion.Show();
            }
            else
            {
                frmConexionGrafico ofrmConexion = new frmConexionGrafico();
                ofrmConexion.MdiParent = this;
                ofrmConexion.Show();
            }


            timer1.Start();
        }

        public void MenuEstado()
        {
            chkMenu.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (mnuPrincipal.Enabled)
            {
                oMenu = frmMenu.getInstance();
                if (chkMenu.Checked)
                {
                    oMenu.MdiParent = this;
                    oMenu.Show();
                }
                else
                {
                    oMenu.Close();
                }
            }
        }

        public static void CopyDirectory(string Origen, string Destino)
        {
            //Creamos el directorio de la aplicacion
            DirectoryInfo dir = new DirectoryInfo(Origen);

            //Comprobamos si el directorio destino existe
            if (Directory.Exists(Destino))
            {
                string nom = dir.Name;
                Origen = Origen.Replace(nom, "");
                dir = new DirectoryInfo(Origen);
                string _archivo = string.Empty;
                string _directory = Destino;

                //Creamos la ruta del directorio donde vamos a copiar
                //string _directory = To + "\\" + dir.Name;
                if (!(Directory.Exists(_directory)))
                {
                    //Creamos el directorio
                    Directory.CreateDirectory(_directory);
                }

                //Recorremos todos los archivos
                foreach (FileInfo _file in dir.GetFiles())
                {
                    _archivo = Path.Combine(_directory, _file.Name);
                    //Si no existe el archivo 
                    if (!(File.Exists(_archivo)))
                    {
                        //Copiamos el archivo en el directorio
                        if (_file.Name.Equals(nom))
                            _file.CopyTo(_archivo);
                    }
                }
                PROYECTO.Properties.Settings.Default.RutaImagen = Path.Combine(_directory, nom);

            }

        }

        private void timFecha_Tick(object sender, EventArgs e)
        {
            try
            {
                TipoCambioDAO oTipoCambioDAO = new TipoCambioDAO();
                if (oConexion.abrirConexion())
                {
                    if (stEstado.Items["stFecha"].Text.Equals(""))
                        stEstado.Items["stFecha"].Text = "   Fecha: " + oConexion.fecha().ToShortDateString() + " ";

                    if (stEstado.Items["stTC"].Text.Equals("   Dólar: ¢ 0"))
                    {
                        stEstado.Items["stTC"].Text = "   Dolar: ¢ " + double.Parse(oTipoCambioDAO.TipoCambio(PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString()).ToString("###,###,##0.##");// +" -- Euro: ¢ " + double.Parse(oTipoDAO.TipoCambio().Tables[0].Rows[0].ItemArray[1].ToString()).ToString("###,###,##0.##") + " ";
                    }

                    if (MensajesAbiertos <= 0)
                    {
                        DataTable oMensajes = oConexion.EjecutaSentencia("select rec_indice, rec_detalle, to_char(rec_fecha,'dd/mm/yyyy HH:mi:ss am'),rec_detalleproviene from  TBL_RECORDATORIO r where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  rec_fecha<=sysdate and rec_usuario ='" + PROYECTO.Properties.Settings.Default.Usuario + "' AND rec_estado ='PEN' AND rec_estadoregistro =1 ORDER BY rec_fecha desc");
                        for (int x = 0; x < oMensajes.Rows.Count; x++)
                        {
                            frmMensajeRecordatorio oPantalla = new frmMensajeRecordatorio();
                            oPantalla.MdiParent = this;
                            oPantalla.Linea = int.Parse(oMensajes.Rows[x].ItemArray[0].ToString());
                            oPantalla.Mensaje = oMensajes.Rows[x].ItemArray[1].ToString();
                            oPantalla.Fecha = DateTime.Parse(oMensajes.Rows[x].ItemArray[2].ToString()).ToString();
                            oPantalla.Show();
                            MensajesAbiertos++;
                        }
                    }

                    oConexion.cerrarConexion();
                }
                //else
                //{
                //    stEstado.Items["stFecha"].Text = "   Fecha: " + oConexion.fecha().ToString() + " ";
                //    stEstado.Items["stTC"].Text = "   Dolar: ¢ " + double.Parse(oTipoDAO.TipoCambio().Tables[0].Rows[0].ItemArray[0].ToString()).ToString("###,###,##0.##") + " -- Euro: ¢ " + double.Parse(oTipoDAO.TipoCambio().Tables[0].Rows[0].ItemArray[1].ToString()).ToString("###,###,##0.##") + " ";
                //}

                if (MensajesAbiertos <= 0)
                {
                    if (MdiChildren.Length == 0)
                        chkMenu.Checked = true;
                }

                if (chkMenu.Enabled)
                {
                    try
                    {
                        if (MensajesAbiertos <= 0)
                        {
                            DataTable oMensajes = oConexion.EjecutaSentencia("select rec_indice, rec_detalle, to_char(rec_fecha,'dd/mm/yyyy HH:mi:ss am'),rec_detalleproviene from TBL_RECORDATORIO r where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and rec_fecha<=sysdate and rec_usuario ='" + PROYECTO.Properties.Settings.Default.Usuario + "' AND rec_estado ='PEN' AND rec_estadoregistro =1 ORDER BY rec_fecha desc");
                            for (int x = 0; x < oMensajes.Rows.Count; x++)
                            {
                                frmMensajeRecordatorio oPantalla = new frmMensajeRecordatorio();
                                oPantalla.MdiParent = this;
                                oPantalla.Linea = int.Parse(oMensajes.Rows[x].ItemArray[0].ToString());
                                oPantalla.Mensaje = oMensajes.Rows[x].ItemArray[1].ToString();
                                oPantalla.Fecha = DateTime.Parse(oMensajes.Rows[x].ItemArray[2].ToString()).ToString();
                                oPantalla.Show();
                                MensajesAbiertos++;
                            }
                        }
                        else
                        {
                            int cont = this.MdiChildren.Length;
                            if (cont == 0)
                            {
                                oMenu = frmMenu.getInstance();
                                oMenu.MdiParent = this;
                                oMenu.Show();
                                oConexion.cerrarConexion();
                            }
                        }
                    }
                    catch { }
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void mnuPrincipal_EnabledChanged(object sender, EventArgs e)
        {
            if (mnuPrincipal.Enabled)
                timFecha.Start();
            else
                timFecha.Stop();
        }


        public void CerrarSesion(Boolean pConsultar)
        {
            try
            {
                Boolean vCerrarSesion = false;

                if (pConsultar)
                {
                    if (MessageBox.Show("¿Desea Cerrar la Sesión: " + PROYECTO.Properties.Settings.Default.Usuario + "?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        vCerrarSesion = true;
                }
                else
                    vCerrarSesion = true;

                if (vCerrarSesion)
                {
                    try
                    {
                        int cont = this.MdiChildren.Length;
                        for (int i = 0; i <= cont; i++)
                        {
                            if (!this.MdiChildren[0].Name.Equals("frmUsuarioContraseñaCambio"))
                                this.MdiChildren[0].Close();
                        }
                    }
                    catch { }


                    PROYECTO.Properties.Settings.Default.Usuario = "";
                    mnuPrincipal.Visible = false;
                    chkMenu.Checked = false;
                    mnuPrincipal.Enabled = false;
                    stEstado.Items["stEtiqueta1"].Text = "   Estado: Conectando ";
                    stEstado.Items["stLinea1"].Visible = false;
                    stEstado.Items["stFecha"].Text = "";
                    stEstado.Items["stLinea2"].Visible = false;
                    stEstado.Items["stUsuario"].Text = "";
                    stEstado.Items["stLinea3"].Visible = false;
                    stEstado.Items["stTC"].Text = "";
                    stEstado.Items["stLinea5"].Visible = false;
                    stEstado.Items["stVersion"].Text = "";
                    stEstado.Items["stLinea4"].Visible = false;
                    stEstado.Items["stActual"].Text = "";

                    this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    PROYECTO.Properties.Settings.Default.UsuarioBD = PROYECTO.Properties.Settings.Default.UsuarioBD_PRINCIPAL;
                    Conexion.getInstance().Clave = PROYECTO.Properties.Settings.Default.Clave;

                    ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();

                    //1 Conexion sencilla
                    //2 Conexion grafica
                    if (PROYECTO.Properties.Settings.Default.FormaConectar.Equals("1"))
                    {
                        frmConexion ofrmConexion = new frmConexion();
                        ofrmConexion.MdiParent = this;
                        ofrmConexion.Show();
                    }

                    else
                    {
                        frmConexionGrafico ofrmConexion = new frmConexionGrafico();
                        ofrmConexion.MdiParent = this;
                        ofrmConexion.Show();
                    }

                    timer1.Start();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cerrarSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesion(true);
        }

        public void FondoPantalla()
        {
            mnuPrincipal.Visible = false;
            chkMenu.Checked = false;
            DirectoryInfo DIR = new DirectoryInfo("C:/SAFE/FondoSistema");
            string Origen = "";
            string Destino = "C:/SAFE/FondoSistema";

            if (DIR.Exists)
            {
                foreach (FileInfo _file in DIR.GetFiles())
                {
                    if (File.Exists(Path.Combine(Destino, _file.Name)))
                    {
                        try
                        {
                            _file.Delete();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            else
            {
                try
                {
                    DIR.Create();
                }
                catch
                {
                    MessageBox.Show("No se puede crear la carpeta C:/SAFE/FondoSistema.\nPor permisos. Favor crear manualmente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            opfImagen.FileName = "";
            opfImagen.Filter = "All Formats|*.JPG|JPEG (*.JPG)|*.JPG";
            opfImagen.ShowDialog();
            if (!opfImagen.FileName.Equals(""))
            {
                Origen = opfImagen.FileName;
            }
            if (!Origen.Equals(""))
                CopyDirectory(Origen, Destino);
            try
            {
                this.BackgroundImage = Image.FromFile(PROYECTO.Properties.Settings.Default.RutaImagen);
                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                oPantallaPermisoDAO.InsertarFondo(PROYECTO.Properties.Settings.Default.RutaImagen, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia);
                oConexion.cerrarConexion();
            }
            catch (Exception ex) { }
        }

        private void salirDelProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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


}