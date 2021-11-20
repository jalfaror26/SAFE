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
    public partial class frmConsultaFactura : Form
    {
        /*Variables Estaticas*/
        private static String vfac_numero = "", vfac_nombre = "";
        private static frmConsultaFactura instance = null;
        /*DAO*/
        private FacturaDAO oFacturaDAO = new FacturaDAO();
        private ConexionDAO oConexion;

        public static frmConsultaFactura getInstance()
        {
            if (instance == null)
                instance = new frmConsultaFactura();
            return instance;
        }

        private frmConsultaFactura()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            Llenar_Grid();
        }

        private void Llenar_Grid(int tipoFiltro, String palabraFiltro)
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {
                dgrDatos.DataSource = oFacturaDAO.Consulta(tipoFiltro, palabraFiltro, PROYECTO.Properties.Settings.Default.No_cia);
                if (oFacturaDAO.Error())
                    MessageBox.Show("Error al listar los datos:\n" + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                oConexion.cerrarConexion();
            }
            else
            {
                MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
            }

        }

        private void Llenar_Grid()
        {
            oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
            oConexion.cerrarConexion();
            if (oConexion.abrirConexion())
            {

                dgrDatos.DataSource = oFacturaDAO.ConsultaFacturas(PROYECTO.Properties.Settings.Default.No_cia);
                if (oFacturaDAO.Error())
                    MessageBox.Show("Error al listar los datos:\n" + oFacturaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                vfac_numero = dgrDatos["fac_numero", e.RowIndex].Value.ToString();
                vfac_nombre = dgrDatos["fac_nombre", e.RowIndex].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void dgrDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Retornar(0);
        }

        private void Retornar(int tipo)
        {
            if (tipo == 1)
            {
                for (int x = 1; x < dgrDatos.Rows.Count; x++)
                {
                    if (dgrDatos[0, x].Selected && x + 1 < dgrDatos.Rows.Count)
                    {
                        vfac_numero = dgrDatos["fac_numero", x - 1].Value.ToString();
                        vfac_nombre = dgrDatos["fac_nombre", x - 1].Value.ToString();
                    }
                    if (dgrDatos[0, x].Selected && x + 1 == dgrDatos.Rows.Count)
                    {
                        vfac_numero = dgrDatos["fac_numero", x].Value.ToString();
                        vfac_nombre = dgrDatos["fac_nombre", x].Value.ToString();
                    }
                }
            }

            frmFacturacion.getInstance().cargaFactura(vfac_numero, vfac_nombre);

            this.Close();
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            txtBId.Clear();
            if (txtBNombre.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBNombre.Text);
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            txtBNombre.Clear();
            if (txtBId.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(1, txtBId.Text);
        }

        private void frmConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Retornar(0);
        }

        private void dgrDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            String val = e.KeyChar.ToString();
            if (val.Equals("\r"))
                Retornar(1);
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