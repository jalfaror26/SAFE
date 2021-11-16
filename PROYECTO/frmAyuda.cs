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
    public partial class frmAyuda : Form
    {
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);

        private static frmAyuda instance = null;
        private String vtema = "";

        private frmAyuda()
        {
            vtema = "";

            InitializeComponent();
        }
        private frmAyuda(String pTema)
        {
            vtema = pTema;

            InitializeComponent();
        }

        public static frmAyuda getInstance()
        {
            if (instance == null)
                instance = new frmAyuda();
            return instance;
        }

        public static frmAyuda getInstance(String pTema)
        {
            if (instance == null)
                instance = new frmAyuda(pTema);
            return instance;
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            LlenarNodos();
        }

        private void LlenarNodos()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    lblEtiqueta.Visible = false;

                    String psql = "SELECT TEM_LINEA,TEM_TITULO,tem_tipo FROM TBL_TEMA";

                    if (!String.IsNullOrEmpty(vtema))
                        psql += " where TEM_LINEA = '" + vtema + "'";

                    psql += " order by TEM_TITULO";

                    DataTable oTemas = oConexion.EjecutaSentencia(psql);
                    DataTable ocategorias = new DataTable();
                    DataTable oDetalles = new DataTable();

                    TreeNode oMANTENIMIENTOS = new TreeNode();
                    oMANTENIMIENTOS.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oMANTENIMIENTOS.Name = "MANTENIMIENTOS";

                    trvLista.Nodes.Add(oMANTENIMIENTOS);
                    trvLista.Nodes["MANTENIMIENTOS"].Text = "MANTENIMIENTOS";

                    TreeNode oLimpio = new TreeNode();
                    oLimpio.Name = "LIMPIO";
                    trvLista.Nodes.Add(oLimpio);

                    TreeNode oProcesos = new TreeNode();
                    oProcesos.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oProcesos.Name = "PROCESOS";

                    trvLista.Nodes.Add(oProcesos);
                    trvLista.Nodes["PROCESOS"].Text = "PROCESOS";


                    trvLista.ExpandAll();

                    String tema = "";
                    String categoria = "";
                    String detalle = "";
                    foreach (DataRow oFila in oTemas.Rows)
                    {
                        tema = "t" + oFila.ItemArray[0].ToString();
                        ocategorias = oConexion.EjecutaSentencia("SELECT TEMCAT_LINEA,TEMCAT_NOMBRE FROM TBL_TEMA_CATEGORIA where TEMCAT_TEMA= '" + tema.Substring(1) + "' order by TEMCAT_LINEA");

                        TreeNode oNode = new TreeNode();
                        oNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
                        oNode.Name = tema;
                        oNode.Text = oFila.ItemArray[1].ToString();

                        if (oFila.ItemArray[2].ToString().Equals("PROCESOS"))
                            oProcesos.Nodes.Add(oNode);
                        else if (oFila.ItemArray[2].ToString().Equals("MANTENIMIENTOS"))
                            oMANTENIMIENTOS.Nodes.Add(oNode);


                        foreach (DataRow oFila2 in ocategorias.Rows)
                        {
                            categoria = "c" + oFila2.ItemArray[0].ToString();
                            TreeNode oNode1 = new TreeNode();
                            oNode1.Text = oFila2.ItemArray[1].ToString();
                            oNode1.Name = categoria;
                            oNode.Nodes.Add(oNode1);
                            oDetalles = oConexion.EjecutaSentencia("SELECT TEMDA_IMAGEN,TEMDA_DETALLE,temda_linea FROM TBL_TEMA_CATEGORIA_DETALLE where TEMDA_TEMA= '" + tema.Substring(1) + "' and TEMDA_CATEGORIA= '" + categoria.Substring(1) + "' order by temda_linea");

                            foreach (DataRow oFila3 in oDetalles.Rows)
                            {
                                detalle = "d" + oFila3.ItemArray[2].ToString();
                                TreeNode oNode2 = new TreeNode();
                                oNode2.Text = oFila3.ItemArray[1].ToString();
                                oNode2.Name = detalle;
                                oNode1.Nodes.Add(oNode2);
                            }
                        }
                    }
                    oConexion.cerrarConexion();

                    if (String.IsNullOrEmpty(vtema))
                    {
                        trvLista.Nodes["MANTENIMIENTOS"].Expand();
                        trvLista.Nodes["PROCESOS"].Expand();
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

        private void LlenarNodos(String palabra)
        {
            try
            {
                lblEtiqueta.Visible = false;
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    String psql = "SELECT TEM_LINEA,TEM_TITULO,tem_tipo FROM TBL_TEMA where regexp_like(upper(TEM_TITULO),'" + palabra.ToUpper() + "','i')";

                    if (!String.IsNullOrEmpty(vtema))
                        psql += " and TEM_LINEA = '" + vtema + "'";

                    psql += " order by TEM_LINEA, TEM_TITULO";

                    DataTable oTemas = oConexion.EjecutaSentencia(psql);
                    DataTable ocategorias = new DataTable();
                    DataTable oDetalles = new DataTable();

                    TreeNode oMANTENIMIENTOS = new TreeNode();
                    oMANTENIMIENTOS.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oMANTENIMIENTOS.Name = "MANTENIMIENTOS";
                    oMANTENIMIENTOS.Expand();
                    trvLista.Nodes.Add(oMANTENIMIENTOS);
                    trvLista.Nodes["MANTENIMIENTOS"].Text = "MANTENIMIENTOS";

                    TreeNode oLimpio = new TreeNode();
                    oLimpio.Name = "LIMPIO";
                    trvLista.Nodes.Add(oLimpio);

                    TreeNode oProcesos = new TreeNode();
                    oProcesos.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    oProcesos.Name = "PROCESOS";
                    oProcesos.Expand();
                    trvLista.Nodes.Add(oProcesos);
                    trvLista.Nodes["PROCESOS"].Text = "PROCESOS";

                    String tema = "";
                    String categoria = "";
                    String detalle = "";
                    foreach (DataRow oFila in oTemas.Rows)
                    {
                        tema = "t" + oFila.ItemArray[0].ToString();
                        ocategorias = oConexion.EjecutaSentencia("SELECT TEMCAT_LINEA,TEMCAT_NOMBRE FROM TBL_TEMA_CATEGORIA where TEMCAT_TEMA= '" + tema.Substring(1) + "' order by TEMCAT_LINEA");

                        TreeNode oNode = new TreeNode();
                        oNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold);
                        oNode.Name = tema;
                        oNode.Text = oFila.ItemArray[1].ToString();

                        if (oFila.ItemArray[2].ToString().Equals("PROCESOS"))
                            oProcesos.Nodes.Add(oNode);
                        else if (oFila.ItemArray[2].ToString().Equals("MANTENIMIENTOS"))
                            oMANTENIMIENTOS.Nodes.Add(oNode);

                        foreach (DataRow oFila2 in ocategorias.Rows)
                        {
                            categoria = "c" + oFila2.ItemArray[0].ToString();
                            TreeNode oNode1 = new TreeNode();
                            oNode1.Text = oFila2.ItemArray[1].ToString();
                            oNode1.Name = categoria;
                            oNode.Nodes.Add(oNode1);
                            oDetalles = oConexion.EjecutaSentencia("SELECT TEMDA_IMAGEN,TEMDA_DETALLE,temda_linea FROM TBL_TEMA_CATEGORIA_DETALLE where TEMDA_TEMA= '" + tema.Substring(1) + "' and TEMDA_CATEGORIA= '" + categoria.Substring(1) + "' order by temda_linea");

                            foreach (DataRow oFila3 in oDetalles.Rows)
                            {
                                detalle = "d" + oFila3.ItemArray[2].ToString();
                                TreeNode oNode2 = new TreeNode();
                                oNode2.Text = oFila3.ItemArray[1].ToString();
                                oNode2.Name = detalle;
                                oNode1.Nodes.Add(oNode2);
                            }
                        }
                    }
                    oConexion.cerrarConexion();

                    if (String.IsNullOrEmpty(vtema))
                    {
                        trvLista.Nodes["MANTENIMIENTOS"].Expand();
                        trvLista.Nodes["PROCESOS"].Expand();
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

        private void frmAyuda_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void trvLista_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LlenarDatos(e.Node.Name.Substring(1), e.Node.Level);
        }

        private void LlenarDatos(String tema, int nivel)
        {
            try
            {
                lblEtiqueta.Visible = false;
                pbImagen.Size = new Size(500, 200);
                pbImagen.Image = null;
                lblTexto.Text = "";
                lblTitulo.Text = "";
                lblSubTitulo.Text = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (nivel == 0 && !tema.Equals("IMPIO"))
                    {
                        DataTable oTemas = oConexion.EjecutaSentencia("SELECT TEM_TITULO from TBL_TEMA where tem_tipo='P" + tema + "' order by TEM_TITULO");
                        lblTitulo.Text = "P" + tema;
                        foreach (DataRow oFila in oTemas.Rows)
                        {
                            lblSubTitulo.Text += oFila.ItemArray[0].ToString() + "\n";
                        }
                    }
                    else if (nivel == 1)
                    {
                        DataTable oTemas = oConexion.EjecutaSentencia("SELECT TEM_TITULO from TBL_TEMA where TEM_LINEA= '" + tema + "'");
                        DataTable ocategorias = new DataTable();
                        foreach (DataRow oFila in oTemas.Rows)
                        {
                            ocategorias = oConexion.EjecutaSentencia("SELECT TEMCAT_NOMBRE FROM TBL_TEMA_CATEGORIA WHERE TEMCAT_TEMA= '" + tema + "' order by TEMCAT_LINEA");
                            lblTitulo.Text = oFila.ItemArray[0].ToString();

                            foreach (DataRow oFila2 in ocategorias.Rows)
                            {
                                lblSubTitulo.Text += oFila2.ItemArray[0].ToString() + "\n";
                            }
                        }
                    }
                    else if (nivel == 2)
                    {
                        DataTable ocategorias = new DataTable();
                        DataTable oDetalles = new DataTable();
                        ocategorias = oConexion.EjecutaSentencia("SELECT TEMCAT_NOMBRE,TEMCAT_TEMA FROM tbl_tema_categoria where TEMCAT_LINEA= '" + tema + "'");
                        foreach (DataRow oFila in ocategorias.Rows)
                        {
                            DataTable oTema = oConexion.EjecutaSentencia("SELECT TEM_TITULO from TBL_TEMA where TEM_LINEA= '" + oFila.ItemArray[1].ToString() + "'");
                            lblTitulo.Text = oTema.Rows[0].ItemArray[0].ToString();
                            lblSubTitulo.Text = oFila.ItemArray[0].ToString();

                            oDetalles = oConexion.EjecutaSentencia("SELECT temda_detalle from tbl_tema_categoria_detalle where TEMDA_CATEGORIA= '" + tema + "' order by temda_linea");

                            foreach (DataRow oFila2 in oDetalles.Rows)
                            {
                                lblTexto.Text += oFila2.ItemArray[0].ToString() + "\n";
                            }
                        }
                    }
                    else if (nivel == 3)
                    {
                        lblEtiqueta.Visible = true;
                        DataTable oDetalles = oConexion.EjecutaSentencia("SELECT TEMDA_TEMA,TEMDA_CATEGORIA,TEMDA_DETALLE,temda_imagen from TBL_TEMA_CATEGORIA_DETALLE where TEMDA_linea='" + tema + "'");

                        foreach (DataRow oFila in oDetalles.Rows)
                        {
                            DataTable ocategoria = oConexion.EjecutaSentencia("SELECT TEMCAT_NOMBRE FROM TBL_TEMA_CATEGORIA where TEMCAT_LINEA= '" + oFila.ItemArray[1].ToString() + "'");
                            DataTable oTema = oConexion.EjecutaSentencia("SELECT TEM_TITULO from TBL_TEMA where TEM_LINEA= '" + oFila.ItemArray[0].ToString() + "'");
                            lblTitulo.Text = oTema.Rows[0].ItemArray[0].ToString();
                            lblSubTitulo.Text = ocategoria.Rows[0].ItemArray[0].ToString();
                            lblTexto.Text = oFila.ItemArray[2].ToString();

                            pbImagen.Image = null;

                            byte[] imageBytes = (byte[])oDetalles.Rows[0].ItemArray[3];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
                              imageBytes.Length);

                            ms.Write(imageBytes, 0, imageBytes.Length);
                            Image image = Image.FromStream(ms, true);

                            pbImagen.Image = image;
                            pbImagen.Size = image.Size;
                            int punto = (630 - image.Size.Width) / 2;
                            punto = punto < 0 ? 0 : punto;
                            pbImagen.Location = new Point(punto, 0);
                        }
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
                LlenarNodos();
            else
                LlenarNodos(txtBuscar.Text);

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            lblTexto.Text = "";
            lblTitulo.Text = "";
            lblSubTitulo.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void pbImagen_DoubleClick(object sender, EventArgs e)
        {
            if (pbImagen.Image != null)
            {
                frmAyudaAgrandar oPantalla = frmAyudaAgrandar.getInstance(pbImagen.Image, lblTitulo.Text + " - " + lblSubTitulo.Text + " - " + lblTexto.Text);
                oPantalla.MdiParent = this.MdiParent;
                oPantalla.Show();
                this.Enabled = false;
            }
        }
    }
}
