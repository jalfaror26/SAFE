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
    public partial class frmFabricante : Form
    {
        private static frmFabricante instance = null;
        private ConexionDAO oConexion;
        private Fabricante_MC oFabricante_MC = null;
        private FabricanteDAO_MC oFabricanteDAO_MC = null;
        private int indi = 0;
        private String codigo = "par_Fabricante", descripcion = "Mantenimiento de fabricantes del sistema.", modulo = "Parametros_Generales";

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

        private frmFabricante()
        {
            InitializeComponent();
        }

        public static frmFabricante getInstance()
        {
            if (instance == null)
                instance = new frmFabricante();
            return instance;
        }

        private void frmLineaProducto_Load(object sender, EventArgs e)
        {
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = true;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = " Actual: Mantenimiento de Fabricante ";
            Llenar_Grid();
            btnMNuevo.PerformClick();
        }        

        private void LimpiarCampos()
        {
            indi = 0;
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBId.Clear();
            txtBDescripcion.Clear();
            dgrDatos.ClearSelection();
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFabricanteDAO_MC = new FabricanteDAO_MC();
                    dgrDatos.DataSource = oFabricanteDAO_MC.consultar(PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oFabricanteDAO_MC.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oFabricanteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oFabricanteDAO_MC = new FabricanteDAO_MC();
                    dgrDatos.DataSource = oFabricanteDAO_MC.Listar(tipo, palabra, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    if (oFabricanteDAO_MC.Error())
                    {
                        MessageBox.Show("Error al listar los datos:\n" + oFabricanteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dgrDatos["FAB_CODIGO", e.RowIndex].Value.ToString();
                txtNombre.Text = dgrDatos["FAB_NOMBRE", e.RowIndex].Value.ToString();
                txtDescripcion.Text = dgrDatos["FAB_DESCRIPCION", e.RowIndex].Value.ToString();
                indi = int.Parse(dgrDatos["FAB_INDICE", e.RowIndex].Value.ToString());
            }
            catch (Exception ex) {}
        }
        
        private Boolean ValidarDatos()
        {
            Boolean correcto = true;
            if (txtId.Text.Trim().Equals("") || txtNombre.Text.Trim().Equals(""))
                correcto = false;
            return correcto;
        }

        private void Agregar()
        {
            try
            {
                if (ValidarDatos())
                {
                    if (Existente())
                    {
                        MessageBox.Show("Error al agregar:\nCódigo del fabricante existente", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnMNuevo.PerformClick();
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    if (oConexion.abrirConexion())
                    {
                        oFabricante_MC = new Fabricante_MC();

                        oFabricante_MC.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFabricante_MC.Cod = txtId.Text;
                        oFabricante_MC.Descripcion = txtDescripcion.Text;
                        oFabricante_MC.Nombre = txtNombre.Text;
                        oFabricanteDAO_MC.Agregar(oFabricante_MC);
                        if (oFabricanteDAO_MC.Error())
                            MessageBox.Show("Error al agregar:\n" + oFabricanteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    MessageBox.Show("Error:\nExisten campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {}
        }

        private void Modificar()
        {
            try
            {
                if (ValidarDatos())
                {
                    if (dgrDatos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione el registro a Modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
                    oConexion.cerrarConexion();
                    if (oConexion.abrirConexion())
                    {
                        oFabricante_MC = new Fabricante_MC();

                        oFabricante_MC.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFabricante_MC.Indice = indi;
                        oFabricante_MC.Cod = txtId.Text;
                        oFabricante_MC.Descripcion = txtDescripcion.Text;
                        oFabricante_MC.Nombre = txtNombre.Text;
                        oFabricanteDAO_MC.Modificar(oFabricante_MC);
                        if (oFabricanteDAO_MC.Error())
                        {
                            MessageBox.Show("Error al Modificar:\n" + oFabricanteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Modificado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        Llenar_Grid();
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                    }
                }
                else
                {
                    MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (ValidarDatos())
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
                        oFabricante_MC = new Fabricante_MC();

                        oFabricante_MC.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                        oFabricante_MC.Indice = indi;
                        oFabricanteDAO_MC.Eliminar(oFabricante_MC);
                        if (oFabricanteDAO_MC.Error())
                        {
                            MessageBox.Show("Error al Eliminar la Marca:\n" + oFabricanteDAO_MC.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Eliminado correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        Llenar_Grid();
                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                    }

                }
                else
                {
                    MessageBox.Show("Error:\nExisten Campos requeridos sin llenar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBId.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(1, txtBId.Text);
        }

        private void txtBDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBDescripcion.Text.Trim().Equals(""))
                Llenar_Grid();
            else
                Llenar_Grid(2, txtBDescripcion.Text);
        }

        private void frmLineaProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stLinea4"].Visible = false;
            ((System.Windows.Forms.StatusStrip)this.MdiParent.Controls["stEstado"]).Items["stActual"].Text = "";
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
                if (oFila.Cells["FAB_CODIGO"].Value.ToString().Equals(txtId.Text))
                    existe = true;
            }
            return existe;
        }

        private void dgrDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnMNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnMGuardar_Click(object sender, EventArgs e)
        {
            if (indi == 0)
                Agregar();
            else
                Modificar();
        }

        private void btnMEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea ELIMINAR el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
            }
        }

        private void btnMSalir_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

    }
}