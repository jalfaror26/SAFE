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
    public partial class frmCategorias : Form
    {
        int row = -1;
        private CategoriaDAO oCategoriaDAO = new CategoriaDAO();
        private static frmCategorias instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private Categoria oCategoria;
        private Int32 indice;
        private String codigo = "par_categorias", descripcion = "Registro de Categorías.", modulo = "Parametros_Generales";
        private string formulario = "";

        /*Constructores*/
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

        public static frmCategorias fgetInstance()
        {
            if (instance == null)
                instance = new frmCategorias();
            return instance;
        }

        public static frmCategorias getInstance(string formName)
        {
            if (instance == null)
                instance = new frmCategorias(formName);
            return instance;
        }

        private frmCategorias()
        {
            InitializeComponent();
            formulario = "";
        }

        public frmCategorias(string formName)
        {
            InitializeComponent();
            formulario = formName;
        }

        /*Metodos*/
        private void frmClientes_Load(object sender, EventArgs e)
        {
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Categorías";
            Llenar_Grid();
            btnMNuevo.PerformClick();
        }

        private void LimpiarCampos()
        {
            indice = 0;
            txtDescripcion.Text = "";
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    dgrDatos.DataSource = oCategoriaDAO.Busqueda_Consulta( PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oCategoriaDAO.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oCategoriaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgrDatos.DataSource = oCategoriaDAO.Listar_Filtrado(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                if (oCategoriaDAO.Error())
                {
                    MessageBox.Show("Error al listar los datos:\n" + oCategoriaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                indice = Convert.ToInt32(dgrDatos["CAT_INDICE", e.RowIndex].Value.ToString());
                txtDescripcion.Text = dgrDatos["CAT_DESCRIPCION", e.RowIndex].Value.ToString();
            }
            catch { }
        }
        
        private void Guardar()
        {
            try
            {
                if (txtDescripcion.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Digite una descripción valida para la Categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oCategoria = new Categoria();

                    oCategoria.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCategoria.Indice = indice;
                    oCategoria.Descripcion = txtDescripcion.Text;
                    if (indice == 0)
                        oCategoriaDAO.Agregar(oCategoria);
                    else
                        oCategoriaDAO.Modificar(oCategoria);
                    if (oCategoriaDAO.Error())
                    {
                        MessageBox.Show("Error al Guardar:\n" + oCategoriaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Guardado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    oCategoria = new Categoria();

                    oCategoria.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oCategoria.Indice = indice;
                    oCategoriaDAO.Eliminar(oCategoria);
                    if (oCategoriaDAO.Error())
                    {
                        MessageBox.Show("Error al eliminar:\n" + oCategoriaDAO.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
            if (formulario.Equals(""))
            {
                frmServicios.getInstance().LlenarCategorias();
                //frmArticulosRapido.getInstance().LlenarCategorias();
            }
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBDescripcion.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBDescripcion.Text);
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgrDatos.ClearSelection();
            LimpiarCampos();
        }

        private Boolean Existente()
        {
            Boolean existe = false;
            foreach (DataGridViewRow oFila in dgrDatos.Rows)
            {
                if (oFila.Cells["CAT_DESCRIPCION"].Value.ToString().Equals(txtDescripcion.Text))
                    existe = true;
            }
            return existe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtDescripcion.Focus();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            txtDescripcion.Focus();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
                txtDescripcion.Focus();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }


    }
}