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
    public partial class frmVistaBitacora : Form
    {
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

        private static frmVistaBitacora instance = null;
        private String vtema = "";
        private String codigo = "par_Bitacora", descripcion = "Vista de Bitácora de datos del sistema.", modulo = "Seguridad";
        String vNodeName = "";
        int vNodeLevel = 0;
        private DataTable oDatosGrid;

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

        private frmVistaBitacora()
        {
            vtema = "";

            InitializeComponent();
        }
        private frmVistaBitacora(String pTema)
        {
            vtema = pTema;

            InitializeComponent();
        }

        public static frmVistaBitacora getInstance()
        {
            if (instance == null)
                instance = new frmVistaBitacora();
            return instance;
        }

        public static frmVistaBitacora getInstance(String pTema)
        {
            if (instance == null)
                instance = new frmVistaBitacora(pTema);
            return instance;
        }

        private void frmVistaBitacora_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            LlenarNodos("");
        }

        private void LlenarNodos(String palabra)
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String psql = "SELECT UNIQUE TABLA, NOMBRE_TABLA, TIPO_TABLA FROM TBL_BITACORA where no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "'";

                    if (!String.IsNullOrEmpty(palabra))
                        psql += " and regexp_like(upper(NOMBRE_TABLA),'" + palabra.ToUpper() + "','i')";

                    psql += " order by NOMBRE_TABLA";

                    DataTable oTemas = oConexion.EjecutaSentencia(psql);
                    //DataTable ocategorias = new DataTable();
                    //DataTable oDetalles = new DataTable();

                    TreeNode oMantenimientos = new TreeNode();
                    oMantenimientos.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oMantenimientos.Name = "MANTENIMIENTOS";

                    trvLista.Nodes.Add(oMantenimientos);
                    trvLista.Nodes["MANTENIMIENTOS"].Text = "MANTENIMIENTOS";

                    TreeNode oLimpio = new TreeNode();
                    oLimpio.Name = "LIMPIO";
                    trvLista.Nodes.Add(oLimpio);

                    TreeNode oProcesos = new TreeNode();
                    oProcesos.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oProcesos.Name = "PROCESOS";

                    trvLista.Nodes.Add(oProcesos);
                    trvLista.Nodes["PROCESOS"].Text = "PROCESOS";

                    TreeNode oLimpio2 = new TreeNode();
                    oLimpio2.Name = "LIMPIO2";
                    trvLista.Nodes.Add(oLimpio2);

                    TreeNode oSeguridad = new TreeNode();
                    oSeguridad.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oSeguridad.Name = "SEGURIDAD";

                    trvLista.Nodes.Add(oSeguridad);
                    trvLista.Nodes["SEGURIDAD"].Text = "SEGURIDAD";

                    trvLista.ExpandAll();

                    String tema = "";
                    String categoria = "";
                    String detalle = "";

                    foreach (DataRow oFila in oTemas.Rows)
                    {
                        tema = oFila.ItemArray[0].ToString();
                        //    ocategorias = oConexion.EjecutaSentencia("SELECT TEMCAT_LINEA,TEMCAT_NOMBRE FROM TBL_BITACORA where TEMCAT_TEMA= '" + tema.Substring(1) + "' order by TEMCAT_LINEA");

                        TreeNode oNode = new TreeNode();
                        oNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
                        oNode.Name = tema;
                        oNode.Text = oFila.ItemArray[1].ToString();

                        if (oFila.ItemArray[2].ToString().Equals("PROCESOS"))
                            oProcesos.Nodes.Add(oNode);
                        else if (oFila.ItemArray[2].ToString().Equals("MANTENIMIENTOS"))
                            oMantenimientos.Nodes.Add(oNode);
                        else if (oFila.ItemArray[2].ToString().Equals("SEGURIDAD"))
                            oSeguridad.Nodes.Add(oNode);

                        //    foreach (DataRow oFila2 in ocategorias.Rows)
                        //    {
                        //        categoria = "c" + oFila2.ItemArray[0].ToString();
                        //        TreeNode oNode1 = new TreeNode();
                        //        oNode1.Text = oFila2.ItemArray[1].ToString();
                        //        oNode1.Name = categoria;
                        //        oNode.Nodes.Add(oNode1);
                        //        oDetalles = oConexion.EjecutaSentencia("SELECT TEMDA_IMAGEN,TEMDA_DETALLE,temda_linea FROM TBL_BITACORA_DETALLE where TEMDA_TEMA= '" + tema.Substring(1) + "' and TEMDA_CATEGORIA= '" + categoria.Substring(1) + "' order by temda_linea");

                        //        foreach (DataRow oFila3 in oDetalles.Rows)
                        //        {
                        //            detalle = "d" + oFila3.ItemArray[2].ToString();
                        //            TreeNode oNode2 = new TreeNode();
                        //            oNode2.Text = oFila3.ItemArray[1].ToString();
                        //            oNode2.Name = detalle;
                        //            oNode1.Nodes.Add(oNode2);
                        //        }
                        //    }
                    }

                    oConexion.cerrarConexion();

                    if (String.IsNullOrEmpty(vtema))
                    {
                        trvLista.Nodes["MANTENIMIENTOS"].Expand();
                        trvLista.Nodes["PROCESOS"].Expand();
                        trvLista.Nodes["SEGURIDAD"].Expand();
                    }
                    else
                        trvLista.ExpandAll();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");

                }
                progressBar1.Visible = false;

            }
            catch (Exception ex)
            {

            }
        }



        private void frmVistaBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void trvLista_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            vNodeName = e.Node.Name;
            vNodeLevel = e.Node.Level;

            txtFiltro1.Clear();
            txtFiltro2.Clear();

            LlenarDatos(vNodeName, vNodeLevel, txtFiltro1.Text, txtFiltro2.Text);
        }

        private void LlenarDatos(String pTabla, int nivel, String pFiltro1, String pFiltro2)
        {
            try
            {
                lblTitulo.Text = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (nivel == 0 && !pTabla.Equals("LIMPIO"))
                    {
                        String sql = "select unique movimiento, usuario, fecha, valores datos from tbl_bitacora where no_cia = '---'";
                        lblTitulo.Text = pTabla;

                        Llenar_Grid(sql);
                    }
                    else if (nivel == 1)
                    {
                        DataTable oTemas = oConexion.EjecutaSentencia("SELECT UNIQUE NOMBRE_TABLA from TBL_BITACORA where no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' AND TABLA= '" + pTabla + "'");

                        foreach (DataRow oFila in oTemas.Rows)
                        {
                            lblTitulo.Text = oFila.ItemArray[0].ToString();
                        }

                        String sql = "select unique movimiento, usuario, fecha, valores datos from tbl_bitacora where no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and TABLA= '" + pTabla + "' ";

                        if (!String.IsNullOrEmpty(pFiltro1))
                            sql += " and regexp_like(llave,'" + pFiltro1 + "','i')";

                        if (!String.IsNullOrEmpty(pFiltro2))
                            sql += " and regexp_like(VALORES,'" + pFiltro2 + "','i')";

                        sql += " order by fecha desc";

                        Llenar_Grid(sql);
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

        private void Llenar_Grid(String plsql)
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oDatosGrid = oConexion.EjecutaSentencia(plsql);
                    dgrDatos.DataSource = oDatosGrid;

                    //Evaluar si ocurriió un Error
                    if (oConexion.Error())
                        MessageBox.Show("Error al listar los datos:\n" + oConexion.DescError(), "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            trvLista.Nodes.Clear();
            progressBar1.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            trvLista.Refresh();
            if (txtBuscar.Text.Trim().Equals(""))
                LlenarNodos("");
            else
                LlenarNodos(txtBuscar.Text);

        }

        private void frmVistaBitacora_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBId_KeyUp(object sender, KeyEventArgs e)
        {
            LlenarDatos(vNodeName, vNodeLevel, txtFiltro1.Text, txtFiltro2.Text);
        }

        private void txtBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            LlenarDatos(vNodeName, vNodeLevel, txtFiltro1.Text, txtFiltro2.Text);
        }

        private void btnCrearXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (oDatosGrid.Rows.Count > 0)
                {
                    DataSet oDataSet = new DataSet();
                    oDataSet.Tables.Add(oDatosGrid);
                    rutaGuardar.Filter = "Ficheros XML (*.xml)|*.xml";
                    if (rutaGuardar.ShowDialog() == DialogResult.OK)
                    {
                        String ruta = rutaGuardar.FileName;
                        oDataSet.WriteXml(ruta);
                        MessageBox.Show("Archivo generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            lblTitulo.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

    }
}
