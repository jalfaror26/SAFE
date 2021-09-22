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

namespace PROYECTO
{
    public partial class frmConexionGrafico : Form
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

        public frmConexionGrafico()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
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

                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (oConexion.existeUsuario(usuario, clave, PROYECTO.Properties.Settings.Default.No_cia))
                    {
                        oConexion.cerrarConexion();
                        oConexion.abrirConexion();

                        String sql = "select EMP_CEDULA from TBL_EMPLEADO em WHERE em.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and EMP_USUARIO = '" + usuario + "'";

                        DataTable oTabla = oConexion.EjecutaSentencia(sql);

                        if (oTabla.Rows.Count > 0)
                            PROYECTO.Properties.Settings.Default.Cedula = oTabla.Rows[0].ItemArray[0].ToString();
                        else
                            PROYECTO.Properties.Settings.Default.Cedula = "";

                        ((System.Windows.Forms.MenuStrip)this.MdiParent.Controls["mnuPrincipal"]).Enabled = true;
                        PROYECTO.Properties.Settings.Default.Usuario = usuario;
                        //oCertificacionDAO = new CertificacionDAO();
                        oTipoCambioDAO = new TipoCambioDAO();
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stEtiqueta1"].Text = "   Cia: " + cboEmpresa.Text + " ";
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea1"].Visible = true;
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stFecha"].Text = "   Fecha: " + oConexion.fecha().ToShortDateString() + " ";
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea2"].Visible = true;
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stUsuario"].Text = "   Usuario: " + usuario + " ";
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea3"].Visible = true;
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stTC"].Text = "   Dólar: ¢ 0";
                        ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stVersion"].Text = " Versión: " + PROYECTO.Properties.Settings.Default.Version.ToString();

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

                        timFecha.Stop();
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectas.");
                        intentos++;
                        txtContrasena1.Clear();
                        txtContrasena2.Clear();
                        txtContrasena3.Clear();
                        txtContrasena4.Clear();
                        txtContrasena5.Clear();
                        txtContrasena6.Clear();
                        txtContrasena7.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                    intentos++;
                    QuitarTodos();
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

                        TraerUsuarios();
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

                    TraerUsuarios();

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

        private void frmConexionGrafico3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void frmConexionGrafico3_Load(object sender, EventArgs e)
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

        private void TraerUsuarios()
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

                    DataTable oUsuarios = oConexion.EjecutaSentencia("select usuario from TBUSUARIO u where u.no_cia = '" + cboEmpresa.SelectedValue.ToString() + "' and estado = 1 order by usuario");

                    for (int x = 0; x < oUsuarios.Rows.Count; x++)
                    {
                        switch (x)
                        {
                            case 0:
                                lblNombre1.Visible = true;
                                lblNombre1.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                this.Size = new Size(600, 455);
                                panel.Location = new Point(362, 170);
                                break;
                            case 1:
                                lblNombre2.Visible = true;
                                lblNombre2.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                panel.Location = new Point(362, 130);
                                break;
                            case 2:
                                lblNombre3.Visible = true;
                                lblNombre3.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                panel.Location = new Point(362, 100);
                                break;
                            case 3:
                                lblNombre4.Visible = true;
                                lblNombre4.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                panel.Location = new Point(362, 70);
                                break;
                            case 4:
                                lblNombre5.Visible = true;
                                lblNombre5.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                panel.Location = new Point(362, 40);
                                break;
                            case 5:
                                lblNombre6.Visible = true;
                                lblNombre6.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                panel.Location = new Point(362, 4);
                                break;
                            case 6:
                                lblNombre7.Visible = true;
                                lblNombre7.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                this.Size = new Size(810, 455);
                                break;
                            case 7:
                                lblNombre8.Visible = true;
                                lblNombre8.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                break;
                            case 8:
                                lblNombre9.Visible = true;
                                lblNombre9.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                break;
                            case 9:
                                lblNombre10.Visible = true;
                                lblNombre10.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                break;
                            case 10:
                                lblNombre11.Visible = true;
                                lblNombre11.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                break;
                            case 11:
                                lblNombre12.Visible = true;
                                lblNombre12.Text = oUsuarios.Rows[x].ItemArray[0].ToString();
                                break;
                        }
                    }
                }
                oConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
            }
        }


        private void QuitarTodos()
        {
            txtContrasena1.Visible = false;
            txtContrasena2.Visible = false;
            txtContrasena3.Visible = false;
            txtContrasena4.Visible = false;
            txtContrasena5.Visible = false;
            txtContrasena6.Visible = false;
            txtContrasena7.Visible = false;
            txtContrasena8.Visible = false;
            txtContrasena9.Visible = false;
            txtContrasena10.Visible = false;
            txtContrasena11.Visible = false;
            txtContrasena12.Visible = false;


            txtContrasena1.Clear();
            txtContrasena2.Clear();
            txtContrasena3.Clear();
            txtContrasena4.Clear();
            txtContrasena5.Clear();
            txtContrasena6.Clear();
            txtContrasena7.Clear();
            txtContrasena8.Clear();
            txtContrasena9.Clear();
            txtContrasena10.Clear();
            txtContrasena11.Clear();
            txtContrasena12.Clear();

            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
            p11.Visible = false;
            p12.Visible = false;

            lblNombre1.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre2.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre3.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre4.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre5.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre6.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre7.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre8.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre9.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre10.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre11.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre12.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void QuitarVisibleTodos()
        {
            txtContrasena1.Visible = false;
            txtContrasena2.Visible = false;
            txtContrasena3.Visible = false;
            txtContrasena4.Visible = false;
            txtContrasena5.Visible = false;
            txtContrasena6.Visible = false;
            txtContrasena7.Visible = false;
            txtContrasena8.Visible = false;
            txtContrasena9.Visible = false;
            txtContrasena10.Visible = false;
            txtContrasena11.Visible = false;
            txtContrasena12.Visible = false;


            txtContrasena1.Clear();
            txtContrasena2.Clear();
            txtContrasena3.Clear();
            txtContrasena4.Clear();
            txtContrasena5.Clear();
            txtContrasena6.Clear();
            txtContrasena7.Clear();
            txtContrasena8.Clear();
            txtContrasena9.Clear();
            txtContrasena10.Clear();
            txtContrasena11.Clear();
            txtContrasena12.Clear();

            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
            p11.Visible = false;
            p12.Visible = false;

            lblNombre1.Visible = false;
            lblNombre2.Visible = false;
            lblNombre3.Visible = false;
            lblNombre4.Visible = false;
            lblNombre5.Visible = false;
            lblNombre6.Visible = false;
            lblNombre7.Visible = false;
            lblNombre8.Visible = false;
            lblNombre9.Visible = false;
            lblNombre10.Visible = false;
            lblNombre11.Visible = false;
            lblNombre12.Visible = false;

            lblNombre1.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre2.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre3.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre4.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre5.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre6.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre7.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre8.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre9.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre10.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre11.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre12.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void timFecha_Tick(object sender, EventArgs e)
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                if (oConexion.abrirConexion())
                {
                    this.Text = "Conexion al Sistema             " + oConexion.fecha().ToString();

                    Conectado++;
                    try
                    {
                        oConexion.cerrarConexion();
                        if (Conectado == 1)
                        {
                            if (!empresasListo)
                                LlenarEmpresas();
                            else
                                TraerUsuarios();
                        }
                        oConexion.cerrarConexion();
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    this.Text = "Conexion al Sistema             - No hay Conexión";
                    oConexion.cerrarConexion();
                    oConexion.QuitarInstance();
                    Conectado = 0;

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void pcImage1_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena1.Visible = true;
            p1.Visible = true;
            txtContrasena1.Focus();
            lblNombre1.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage2_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena2.Visible = true;
            p2.Visible = true;
            txtContrasena2.Focus();
            lblNombre2.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage3_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena3.Visible = true;
            p3.Visible = true;
            txtContrasena3.Focus();
            lblNombre3.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage4_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena4.Visible = true;
            p4.Visible = true;
            txtContrasena4.Focus();
            lblNombre4.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage5_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena5.Visible = true;
            p5.Visible = true;
            txtContrasena5.Focus();
            lblNombre5.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage6_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena6.Visible = true;
            p6.Visible = true;
            txtContrasena6.Focus();
            lblNombre6.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void pcImage7_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena7.Visible = true;
            p7.Visible = true;
            txtContrasena7.Focus();
            lblNombre7.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void txtContrasena1_KeyUp(object sender, KeyEventArgs e)
        {
            usuario = lblNombre1.Text;
            clave = txtContrasena1.Text;
        }

        private void txtContrasena2_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre2.Text;
            clave = txtContrasena2.Text;
        }

        private void txtContrasena3_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre3.Text;
            clave = txtContrasena3.Text;
        }

        private void txtContrasena4_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre4.Text;
            clave = txtContrasena4.Text;
        }

        private void txtContrasena5_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre5.Text;
            clave = txtContrasena5.Text;
        }

        private void txtContrasena6_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre6.Text;
            clave = txtContrasena6.Text;
        }

        private void txtContrasena7_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre7.Text;
            clave = txtContrasena7.Text;
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

        private void txtContrasena8_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre8.Text;
            clave = txtContrasena8.Text;
        }

        private void txtContrasena9_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre9.Text;
            clave = txtContrasena9.Text;
        }

        private void txtContrasena10_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre10.Text;
            clave = txtContrasena10.Text;
        }

        private void txtContrasena11_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre11.Text;
            clave = txtContrasena11.Text;
        }

        private void txtContrasena12_TextChanged(object sender, EventArgs e)
        {
            usuario = lblNombre12.Text;
            clave = txtContrasena12.Text;
        }

        private void lblNombre8_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena8.Visible = true;
            p8.Visible = true;
            txtContrasena8.Focus();
            lblNombre8.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (empresasListo)
                {
                    TraerUsuarios();
                    timFecha.Stop();
                    QuitarVisibleTodos();
                    oConexion.QuitarInstance();
                    Conectado = 0;
                    timFecha.Start();
                }
            }
            catch (Exception ex) { }
        }

        private void cboCentros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (empresasListo)
                {
                    TraerUsuarios();
                }
            }
            catch (Exception ex) { }
        }

        private void lblNombre9_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena9.Visible = true;
            p9.Visible = true;
            txtContrasena9.Focus();
            lblNombre9.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void lblNombre10_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena10.Visible = true;
            p10.Visible = true;
            txtContrasena10.Focus();
            lblNombre10.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void lblNombre11_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena11.Visible = true;
            p11.Visible = true;
            txtContrasena11.Focus();
            lblNombre11.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void lblNombre12_Click(object sender, EventArgs e)
        {
            QuitarTodos();
            txtContrasena12.Visible = true;
            p12.Visible = true;
            txtContrasena12.Focus();
            lblNombre12.TextAlign = ContentAlignment.MiddleCenter;
        }




    }
}