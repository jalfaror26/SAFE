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
    public partial class frmrptProveedores : Form
    {
        private static frmrptProveedores ofrmrptProveedores = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ReportesDAO oReporteDAO = null;
        private String codigo = "rpt_Proveedores", descripcion = "Reporte de proveedores.", modulo = "Reportes_Generales";

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


        public frmrptProveedores()
        {
            InitializeComponent();
        }

        public static frmrptProveedores getInstance()
        {
            if (ofrmrptProveedores == null)
                ofrmrptProveedores = new frmrptProveedores();
            return ofrmrptProveedores;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmrptProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmrptProveedores = null;
        }

        private void ejecutar()
        {
            try
            {
                String sql = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    sql = "SELECT PROV_ID, PROV_TIPO_ID, PROV_NOMBRE, PROV_TELEFONO, PROV_FAX, PROV_CONTACTO, PROV_TEL_CONTACTO, PROV_UBICACION, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_PROVEEDOR p, TBL_EMPRESA e where p.no_cia = e.no_cia and p.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and PROV_ESTADO=1 and prov_linea > 0";

                    oReporteDAO = new ReportesDAO();
                    DataTable oTable = oConexion.EjecutaSentencia(sql);
                    if (oTable.Rows.Count > 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptProveedores oReporte = new rptProveedores();
                        oReporte.SetDataSource(oTable);
                        oVisor.ReportSource(oReporte);
                        oVisor.Show();
                    }
                    else
                        MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Visible = false;
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void frmrptProveedores_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                timer1.Stop();
                ejecutar();
        }
    }
}