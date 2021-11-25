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
    public partial class frmrptClientes : Form
    {
        private static frmrptClientes ofrmrptClientes = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private ReportesDAO oReporteDAO = null;
        private int numero = 0;
        private String codigo = "rpt_Clientes", descripcion = "Reporte de clientes.", modulo = "Reportes Mantenimientos";
        private int cambiar = 0, cambiar2 = 0;

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


        public frmrptClientes()
        {
            InitializeComponent();
        }

        public static frmrptClientes getInstance()
        {
            if (ofrmrptClientes == null)
                ofrmrptClientes = new frmrptClientes();
            return ofrmrptClientes;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmrptClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmrptClientes = null;
        }

        private void ejecutar()
        {
            try
            {
                String sql = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    sql = "SELECT CLI_LINEA,CLI_TIPO_ID,CLI_IDENTIFICACION, CLI_NOMBRE, CLI_TELEFONO, CLI_FAX, CLI_CONTACTO, CLI_CORREO, CLI_UBICACION, CLI_DIAS, CLI_ID , CLI_TIPOCLIENTE, CLI_LC_MONEDA, CLI_LC_LIMITE, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_CLIENTES c, TBL_EMPRESA e where c.no_cia = e.no_cia and c.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and CLI_ESTADO = 1 and CLI_LINEA > 0";

                    sql += " order by CLI_NOMBRE";

                    oReporteDAO = new ReportesDAO();
                    DataTable oTable = oConexion.EjecutaSentencia(sql);

                    if (oConexion.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oConexion.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (oTable.Rows.Count > 0)
                    {
                        frmVisorReportes oVisor = frmVisorReportes.getInstance();
                        oVisor.MdiParent = this.MdiParent;
                        rptClientes oReporte = new rptClientes();
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

        private void frmrptClientes_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                timer1.Stop();
                ejecutar();
            }
        }
    }
}