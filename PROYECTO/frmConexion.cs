using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Reflection;
using System.IO;
using Entidades;

namespace PROYECTO
{
    public partial class frmConexion : Form
    {

        private ConexionDAO oConexion;
        private int intentos = 0;
        private TipoCambioDAO oTipoCambioDAO = null;
        private frmTiposCambio oTipoCambio = null;

        private string usuario = "", clave = "";
        private int Conectado = 0;
        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();

        private Boolean empresasListo = false;
        private String codigo, descripcion, modulo;

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));

        public frmConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = txtUsuario.Text;
                clave = txtContrasena1.Text;

                PROYECTO.Properties.Settings.Default.No_cia = cboEmpresa.SelectedValue.ToString();

                if (usuario.Equals(""))
                {
                    MessageBox.Show("Digite el nombre del usuario");
                    intentos++;
                    return;
                }
                if (clave.Equals(""))
                {
                    MessageBox.Show("Digite la contraseña del usuario");
                    intentos++;
                    return;
                }

                if (PROYECTO.Properties.Settings.Default.No_cia.Equals(""))
                {
                    MessageBox.Show("Seleccione la Empresa");
                    cboEmpresa.Focus();
                    intentos++;
                    return;
                }

                PROYECTO.Properties.Settings.Default.UsuarioBD = PROYECTO.Properties.Settings.Default.UsuarioBD_PRINCIPAL;
                Conexion.getInstance().Clave = PROYECTO.Properties.Settings.Default.Clave;

                oConexion.cerrarConexion(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.QuitarInstance(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                oConexion.cerrarConexion(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (oConexion.abrirConexion())
                {
                    if (oConexion.existeUsuario(usuario, clave, PROYECTO.Properties.Settings.Default.No_cia))
                    {
                        oConexion.cerrarConexion(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                        oConexion.QuitarInstance(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                        oConexion = new ConexionDAO(usuario, PROYECTO.Properties.Settings.Default.Servidor, clave);

                        //oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                        if (oConexion.abrirConexion())
                        {


                            PROYECTO.Properties.Settings.Default.UsuarioBD = usuario;
                            Conexion.getInstance().Clave = clave;

                            ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = true;
                            PROYECTO.Properties.Settings.Default.Usuario = PROYECTO.Properties.Settings.Default.UsuarioBD;
                            //oCertificacionDAO = new CertificacionDAO();
                            oTipoCambioDAO = new TipoCambioDAO();
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stEtiqueta1"].Text = "   Cia: " + cboEmpresa.Text + " ";
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea1"].Visible = true;
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stFecha"].Text = "   Fecha: " + oConexion.fecha().ToShortDateString() + " ";
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea2"].Visible = true;
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stUsuario"].Text = "   Usuario: " + PROYECTO.Properties.Settings.Default.Usuario + " ";
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea3"].Visible = true;
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stTC"].Text = "   Dólar: ¢ 0";
                            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stVersion"].Text = " Versión: " + PROYECTO.Properties.Settings.Default.Version.ToString();

                            UsuarioDAO oUsuarioDAO = new UsuarioDAO();
                            Usuario oUsuario = new Usuario();

                            DataTable oDatos = oUsuarioDAO.consultaUsuario(usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                            oUsuario.CodUsuario = usuario;
                            oUsuario.Nombre = oDatos.Rows[0]["nombre"].ToString();
                            String ind_req_cambio = oDatos.Rows[0]["ind_req_cambio"].ToString();

                            if (ind_req_cambio.Equals("S"))
                            {

                                MessageBox.Show("Bienvenido " + oUsuario.Nombre + "!!\n\nEs requerido que se realice el cambio de contraseña!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmUsuarioContraseñaCambio oPantalla = frmUsuarioContraseñaCambio.getInstance(usuario, ind_req_cambio);
                                oPantalla.MdiParent = this.MdiParent;
                                oPantalla.Show();
                                this.Dispose();
                            }
                            else
                            {

                                if (oTipoCambioDAO.Consulta(PROYECTO.Properties.Settings.Default.No_cia))
                                {
                                    oTipoCambio = frmTiposCambio.getInstance(0);
                                    oTipoCambio.MdiParent = this.MdiParent;
                                    oTipoCambio.Show();
                                    this.Dispose();
                                }
                                else
                                {
                                    this.Dispose();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos\n\n" + oConexion.DescError());

                            oConexion.cerrarConexion();
                            oConexion.QuitarInstance(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

                            intentos++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectas.");
                        intentos++;
                        txtContrasena1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                    intentos++;
                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex) { }
        }


        public void LlenarEmpresas()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    EmpresaDAO oEmpresaDAO = new EmpresaDAO();

                    DataSet oDataSet = oEmpresaDAO.Busqueda_Consulta();
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        cboEmpresa.DataSource = oDataSet.Tables[0];
                        cboEmpresa.DisplayMember = "EMPR_NOMBRE";
                        cboEmpresa.ValueMember = "NO_CIA";

                        empresasListo = true;

                        TraeLogo();
                    }
                    else
                    {
                        MessageBox.Show("No hay empresas disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        oConexion.cerrarConexion();
                        //bandera = true;
                    }
                    if (oEmpresaDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oEmpresaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!PROYECTO.Properties.Settings.Default.No_cia.Equals(""))
                        cboEmpresa.SelectedValue = PROYECTO.Properties.Settings.Default.No_cia;
                    else
                        cboEmpresa.SelectedIndex = 0;

                    oConexion.cerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex) { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmConexion3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void frmConexion3_Load(object sender, EventArgs e)
        {
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stEtiqueta1"].Text = "   Estado: Conectando ";
            timFecha.Start();
        }

        private String MesLetras(int mes)
        {
            String cadena = "";
            switch (mes)
            {
                case 1:
                    cadena = "ENERO";
                    break;
                case 2:
                    cadena = "FEBRERO";
                    break;
                case 3:
                    cadena = "MARZO";
                    break;
                case 4:
                    cadena = "ABRIL";
                    break;
                case 5:
                    cadena = "MAYO";
                    break;
                case 6:
                    cadena = "JUNIO";
                    break;
                case 7:
                    cadena = "JULIO";
                    break;
                case 8:
                    cadena = "AGOSTO";
                    break;
                case 9:
                    cadena = "SETIEMBRE";
                    break;
                case 10:
                    cadena = "OCTUBRE";
                    break;
                case 11:
                    cadena = "NOVIEMBRE";
                    break;
                case 12:
                    cadena = "DICIEMBRE";
                    break;
            }
            return cadena;
        }
        private void timFecha_Tick(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(PROYECTO.Properties.Settings.Default.UsuarioBD))
                {
                    PROYECTO.Properties.Settings.Default.UsuarioBD = PROYECTO.Properties.Settings.Default.UsuarioBD_PRINCIPAL;
                    PROYECTO.Properties.Settings.Default.Clave = Conexion.getInstance().Clave;
                }

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (oConexion.abrirConexion())
                {
                    this.Text = "Conexion al Sistema             " + oConexion.fecha().ToShortDateString();

                    Conectado++;
                    try
                    {
                        oConexion.cerrarConexion();
                        if (Conectado == 1)
                        {
                            if (!empresasListo)
                                LlenarEmpresas();
                        }
                        oConexion.cerrarConexion();

                        timFecha.Stop();
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    this.Text = "Conexion al Sistema             - No hay Conexión";
                    oConexion.cerrarConexion();
                    oConexion.QuitarInstance(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    Conectado = 0;

                }
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
                    DataSet odataset = oPantallaPermisoDAO.existePantalla(codigo);
                    if (odataset.Tables[0].Rows.Count == 0)
                    {
                        oPantallaPermisoDAO.crearPantalla(codigo, modulo, descripcion, PROYECTO.Properties.Settings.Default.No_cia);
                    }
                    odataset = oPantallaPermisoDAO.tieneAcceso(codigo, PROYECTO.Properties.Settings.Default.No_cia);
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

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (empresasListo)
                {
                    timFecha.Stop();
                    oConexion.QuitarInstance(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    Conectado = 0;
                    timFecha.Start();

                    txtUsuario.Clear();
                    txtContrasena1.Clear();

                    TraeLogo();
                }
            }
            catch (Exception ex) { }
        }

        private void TraeLogo()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oTablaImagen = new DataTable();
                    oTablaImagen = oConexion.EjecutaSentencia("SELECT EMPR_IDENTIFICACION, EMPR_NOMBRE, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, EMPR_LOGO FROM TBL_EMPRESA em where em.no_cia = '" + cboEmpresa.SelectedValue.ToString() + "'");

                    if (oTablaImagen.Rows.Count > 0)
                    {
                        try
                        {
                            Bitmap imagen = null;
                            Byte[] bytes = (Byte[])oTablaImagen.Rows[0]["EMPR_LOGO"];
                            MemoryStream ms = new MemoryStream(bytes);
                            imagen = new Bitmap(ms);
                            this.pictureBox1.Image = imagen;
                        }
                        catch (Exception ex) { this.pictureBox1.Image = null; }
                    }
                    else
                    {
                        this.pictureBox1.Image = null;
                    }



                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
            }
        }


        private void frmForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (e.KeyCode == Keys.F1)
                    Ayuda();
            }
        }

        private void Ayuda()
        {
            frmAyuda oFrm = frmAyuda.getInstance("t1");
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }

    }
}