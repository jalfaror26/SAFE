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
    public partial class frmServicioImpuestos : Form
    {

        private frmServicioImpuestos(Servicio pServicio)
        {
            oServicio = pServicio;
            InitializeComponent();
        }

        private PantallasPermisosDAO oPantallaPermisoDAO = new PantallasPermisosDAO();
        public string origen = "";
        private ServicioImpuestos oServicioImpuestos;
        private ServicioImpuestosDAO oServicioImpuestosDAO = new ServicioImpuestosDAO();
        private Servicio oServicio;
        private static frmServicioImpuestos instance = null;
        private ConexionDAO oConexion;
        private int indice = 0;
        private String codigo = "par_Servicios_Impuestos", descripcion = "Asignación de impuestos a los servicios", modulo = "Mantenimientos";

        private String codigo2 = "", descripcion2 = "", modulo2 = "";
        private Boolean vArticulosCImagen = false;

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

        public static frmServicioImpuestos getInstance(Servicio pServicio)
        {
            if (instance == null)
                instance = new frmServicioImpuestos(pServicio);
            return instance;
        }

        public void LlenarImpuestos()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    ImpuestosDAO oImpuestosDAO = new ImpuestosDAO();
                    DataSet oDataSet = oImpuestosDAO.consultar2(PROYECTO.Properties.Settings.Default.No_cia);
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        cmbImpuestos.DataSource = oDataSet.Tables[0];
                        cmbImpuestos.DisplayMember = "descripcion";
                        cmbImpuestos.ValueMember = "clave";
                    }
                    else
                    {
                        MessageBox.Show("No hay embalajes disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        oConexion.cerrarConexion();
                    }
                    if (oImpuestosDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oImpuestosDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex) { }
        }

        private void frmArticuloPresentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            if (oServicio.Indice == 0)
                frmServicios.getInstance().Llenar_Grid();
        }

        private void frmArticuloPresentacion_Load(object sender, EventArgs e)
        {
            LlenarImpuestos();
            txtCodigoSer.Text = oServicio.Codigo.ToString();
            txtDesBreveSer.Text = oServicio.Descripcion;
            Llenar_Grid();
            btnMNuevo.PerformClick();

            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oMensajes = oConexion.EjecutaSentencia("select ind_articuloscimagen from TBL_EMPRESA e where e.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'");

                    if (oMensajes.Rows.Count > 0)
                    {
                        vArticulosCImagen = oMensajes.Rows[0]["ind_articuloscimagen"].ToString().Equals("S") ? true : false;
                    }

                    oConexion.cerrarConexion();
                }
            }
            catch
            {
            }

        }

        private void LimpiarCampos()
        {
            if (cmbImpuestos.Items.Count > 0)
                cmbImpuestos.SelectedIndex = 0;
            dgrDatos.ClearSelection();
            indice = 0;
            btnMGuardar.Enabled = true;

        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioImpuestosDAO.ConsultarEspecificoCodigo(oServicio.Indice.ToString(), PROYECTO.Properties.Settings.Default.No_cia);
                    if (oServicioImpuestosDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oServicioImpuestosDAO.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oConexion.cerrarConexion();

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

        private void Agregar()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicioImpuestos = new ServicioImpuestos();

                    oServicioImpuestos.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oServicioImpuestos.IndiceServicio = oServicio.Indice;
                    oServicioImpuestos.Clave = cmbImpuestos.SelectedValue.ToString();
                    oServicioImpuestos.AfectaVenta = "S";

                    oServicioImpuestosDAO.Agregar(oServicioImpuestos);
                    if (oServicioImpuestosDAO.Error())
                        MessageBox.Show("Error al guardar:\n" + oServicioImpuestosDAO.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Llenar_Grid();
                        LimpiarCampos();
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
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicioImpuestosDAO.Eliminar(oServicioImpuestos);
                    if (oServicioImpuestosDAO.Error())
                        MessageBox.Show("Error al eliminar:\n" + oServicioImpuestosDAO.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
            LimpiarCampos();
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oServicioImpuestos = new ServicioImpuestos();

                oServicioImpuestos.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                oServicioImpuestos.IndiceServicio = oServicio.Indice;
                oServicioImpuestos.Clave = dgrDatos["clave", e.RowIndex].Value.ToString();
                oServicioImpuestos.AfectaVenta = "S";

                cmbImpuestos.SelectedValue = dgrDatos["clave", e.RowIndex].Value.ToString();
                btnMGuardar.Enabled = false;
            }
            catch (Exception ex) { }
        }
        
        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            indice = 0;
        }

        private void dgrDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void frmServicioImpuestos_KeyDown(object sender, KeyEventArgs e)
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
        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Eliminar();
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
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

    }
}