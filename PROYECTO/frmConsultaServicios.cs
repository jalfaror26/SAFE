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
    public partial class frmConsultaServicios : Form
    {
        private ServicioDAO oServicioDAO = null;
        private static frmConsultaServicios ofrmConsultaServicios = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private String indiceServicio, codigoServicio, descripcionServicio, palabra, IVI;
        private String vOrigen = "";

        private double IV;

        public frmConsultaServicios(String ppalabra)
        {
            palabra = ppalabra;
            InitializeComponent();
        }

        public static frmConsultaServicios getInstance(String ppalabra)
        {
            if (ofrmConsultaServicios == null)
                ofrmConsultaServicios = new frmConsultaServicios(ppalabra);
            return ofrmConsultaServicios;
        }

        private void llenarGrid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oServicioDAO = new ServicioDAO();

                    dgrDatos.DataSource = oServicioDAO.ConsultarInventario(vOrigen, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oServicioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void llenarGrid(string codigo, string descripcion)
        {
            try
            {
                if (codigo.Equals("") && descripcion.Equals(""))
                {
                    llenarGrid();
                    return;
                }
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oServicioDAO.ListarInventario(vOrigen, codigo, descripcion, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];

                    if (oServicioDAO.Error())
                        MessageBox.Show("Ocurrió un error al extraer los datos: " + oServicioDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Ocurrió un error al conectarse a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                oConexion.cerrarConexion();
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            txtCodigo.Clear();


            llenarGrid(txtCodigo.Text, txtDescripcion.Text);

            if (e.KeyCode == Keys.Enter)
            {
                Retornar(0);
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            txtDescripcion.Clear();

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                llenarGrid(txtCodigo.Text, txtDescripcion.Text);
            }
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indiceServicio = dgrDatos.Rows[e.RowIndex].Cells["SER_INDICE"].Value.ToString();
                codigoServicio = dgrDatos.Rows[e.RowIndex].Cells["SER_CODIGO"].Value.ToString();
                descripcionServicio = dgrDatos.Rows[e.RowIndex].Cells["SER_NOMBRE"].Value.ToString();
                IVI = dgrDatos.Rows[e.RowIndex].Cells["INV_IVI"].Value.ToString();
                IV = double.Parse(dgrDatos.Rows[e.RowIndex].Cells["INV_IMPUESTO_VENTAS"].Value.ToString());
            }
            catch (Exception ex) { }
        }

        private void frmConsultaArticulos_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            try
            {
                if (palabra.Equals("frmFacturacion"))
                    vOrigen = "F";
                else if (palabra.Equals("frmCotizacion"))
                    vOrigen = "C";

                llenarGrid();
                txtCodigo.Focus();

            }
            catch (Exception ex) { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgrDatos.Focused)
                Retornar(0);
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void Retornar(int tipo)
        {
            try
            {
                if (tipo == 1)
                {
                    for (int x = 1; x < dgrDatos.Rows.Count; x++)
                    {
                        if (dgrDatos[0, x].Selected && x + 1 < dgrDatos.Rows.Count)
                        {
                            indiceServicio = dgrDatos.Rows[x - 1].Cells["SER_INDICE"].Value.ToString();
                            codigoServicio = dgrDatos.Rows[x - 1].Cells["SER_CODIGO"].Value.ToString();
                            descripcionServicio = dgrDatos.Rows[x - 1].Cells["SER_NOMBRE"].Value.ToString();
                            IVI = dgrDatos.Rows[x - 1].Cells["INV_IVI"].Value.ToString();
                            IV = double.Parse(dgrDatos.Rows[x - 1].Cells["INV_IMPUESTO_VENTAS"].Value.ToString());
                        }
                        if (dgrDatos[0, x].Selected && x + 1 == dgrDatos.Rows.Count)
                        {
                            indiceServicio = dgrDatos.Rows[x].Cells["SER_INDICE"].Value.ToString();
                            codigoServicio = dgrDatos.Rows[x].Cells["SER_CODIGO"].Value.ToString();
                            descripcionServicio = dgrDatos.Rows[x].Cells["SER_NOMBRE"].Value.ToString();
                            IVI = dgrDatos.Rows[x].Cells["INV_IVI"].Value.ToString();
                            IV = double.Parse(dgrDatos.Rows[x].Cells["INV_IMPUESTO_VENTAS"].Value.ToString());
                        }
                    }
                }

                if (palabra.Equals("frmFacturacion"))
                    frmFacturacion.getInstance().cargaServicio(indiceServicio, descripcionServicio, IVI, IV);
                //else if (palabra.Equals("cambioproducto"))
                //    frmCambioProducto.getInstance().cargaArticulo(indiceArticulo, descripcionArticulo, almacen, cadena, existencia, proveedor, indiceInventario, presentacion, embalaje);
                //else if (palabra.Equals("Apartado"))
                //    frmApartados.getInstance().cargaArticulo(indiceArticulo, descripcionArticulo, almacen, cadena, existencia, proveedor, indiceInventario, presentacion, embalaje, IVI, IV);

                //else if (palabra.Equals("traspasos"))
                //    frmTraspasoEBodegas.getInstance().cargaArticulo(indiceArticulo, descripcionArticulo, existencia, proveedor, indiceInventario, presentacion, embalaje);
                //else if (palabra.Equals("MovimientoProducto"))
                //    frmMovimientoProducto.getInstance().cargaArticulo(indiceArticulo, descripcionArticulo, almacen, cadena, existencia, proveedor, indiceInventario, presentacion, embalaje);

                //else
                if (palabra.Equals("frmCotizacion"))
                    frmCotizacion.getInstance().cargaServicio(indiceServicio, codigoServicio, descripcionServicio, IVI, IV);
                //else if (palabra.Equals("TRAS_E_CEN_ABIERTOS"))
                //    frmTraspasoECentros_Crear.getInstance().cargaArticulo(indiceArticulo, descripcionArticulo, existencia, proveedor, indiceInventario, presentacion, embalaje);


                this.Close();
            }
            catch (Exception ex) { }
        }

        private void dgrDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            String val = e.KeyChar.ToString();
            if (val.Equals("\r"))
                Retornar(1);
        }

        private void frmConsultaArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofrmConsultaServicios = null;
        }

        private void dgrDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Retornar(0);
        }

        private void dgrDatos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                Retornar(0);
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
