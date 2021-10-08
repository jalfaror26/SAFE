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
    public partial class frmRecordatorioVista : Form
    {
        private frmRecordatorioVista()
        {
            InitializeComponent();
        }
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private String codigo = "par_vista", descripcion = "Vista de recordatorios del sistema.", modulo = "Recordatorios";
        private static frmRecordatorioVista instance = null;

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

        public static frmRecordatorioVista getInstance()
        {
            if (instance == null)
                instance = new frmRecordatorioVista();
            return instance;
        }

        private void frmRecordatorioVista2_Load(object sender, EventArgs e)
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
                    DataTable oRecordatorios = new DataTable();
                    DataTable oComentarios = new DataTable();
                    String usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    String recordatorio = "";
                    String comentario = "";

                    oRecordatorios = oConexion.EjecutaSentencia("SELECT REC_INDICE,to_char(REC_FECHA_CREA,'dd/mm/yyyy hh:mi:ss am')|| '.  -  '  ||REC_DETALLE FROM TBL_RECORDATORIO r where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_USUARIO='" + usuario + "' order by REC_FECHA_CREA");

                    //TreeNode oNode = new TreeNode();
                    //oNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    //oNode.Name = usuario;
                    //trvLista.Nodes.Add(oNode);
                    //trvLista.Nodes[usuario].Text = oFila.ItemArray[0].ToString();

                    foreach (DataRow oFila2 in oRecordatorios.Rows)
                    {
                        recordatorio = oFila2.ItemArray[0].ToString();

                        TreeNode oNode1 = new TreeNode();
                        oNode1.Name = recordatorio;
                        oNode1.Text = oFila2.ItemArray[1].ToString();
                        trvLista.Nodes.Add(oNode1);

                        //oNode.Nodes.Add(oNode1);
                        oComentarios = oConexion.EjecutaSentencia("SELECT RECOM_RECORDATORIO||to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am')||RECOM_COMENTARIO, to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am')|| '.  -  '  ||RECOM_COMENTARIO FROM TBL_RECORDATORIO_COMENTARIO rc where rc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  RECOM_RECORDATORIO= '" + recordatorio + "' order by RECOM_FECHA_HORA");

                        foreach (DataRow oFila3 in oComentarios.Rows)
                        {
                            comentario = oFila3.ItemArray[0].ToString();
                            TreeNode oNode2 = new TreeNode();
                            oNode2.Text = oFila3.ItemArray[1].ToString();
                            oNode2.Name = comentario;
                            oNode1.Nodes.Add(oNode2);
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

        private void LlenarNodos2()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    DataTable oRecordatorios = new DataTable();
                    DataTable oComentarios = new DataTable();
                    String usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    String recordatorio = "";
                    String comentario = "";
                    String sql = "";

                    DateTime fecha = new DateTime();
                    if (rboAM.Checked)
                        fecha = DateTime.Parse(dtpFecha.Value.ToShortDateString() + " " + txtHora.Text + " am");
                    else
                        fecha = DateTime.Parse(dtpFecha.Value.ToShortDateString() + " " + txtHora.Text + " pm");


                    sql = "SELECT REC_INDICE,to_char(REC_FECHA_CREA,'dd/mm/yyyy hh:mi:ss am')|| '.  -  '  ||REC_DETALLE FROM TBL_RECORDATORIO r where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and REC_USUARIO='" + usuario + "' ";
                    if (chkFecha.Checked)
                        sql += " and trunc(REC_FECHA_CREA) = '" + dtpFecha.Value.ToShortDateString() + "'";
                    if (chkHora.Checked)
                    {
                        sql += " and to_char(REC_FECHA_CREA,'hh:mi:ss am') = '" + fecha.ToShortTimeString().Substring(0, 5) + ":00 ";
                        if (rboAM.Checked)
                            sql += "AM'";
                        else
                            sql += "PM'";
                    }
                    if (chkOtro.Checked && !txtOtro.Text.Trim().Equals(""))
                        sql += " and regexp_like(upper(REC_DETALLE),'" + txtOtro.Text.ToUpper() + "','i') ";

                    sql += " order by REC_FECHA_CREA";

                    oRecordatorios = oConexion.EjecutaSentencia(sql);

                    //TreeNode oNode = new TreeNode();
                    //oNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    //oNode.Name = usuario;
                    //trvLista.Nodes.Add(oNode);
                    //trvLista.Nodes[usuario].Text = oFila.ItemArray[0].ToString();

                    foreach (DataRow oFila2 in oRecordatorios.Rows)
                    {
                        recordatorio = oFila2.ItemArray[0].ToString();
                        TreeNode oNode1 = new TreeNode();
                        oNode1.Text = oFila2.ItemArray[1].ToString();
                        oNode1.Name = recordatorio;
                        trvLista.Nodes.Add(oNode1);
                        //oNode.Nodes.Add(oNode1);
                        oComentarios = oConexion.EjecutaSentencia("SELECT RECOM_RECORDATORIO||to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am')||RECOM_COMENTARIO, to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am')|| '.  -  '  ||RECOM_COMENTARIO FROM TBL_RECORDATORIO_COMENTARIO rc where rc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  RECOM_RECORDATORIO= '" + recordatorio + "' order by RECOM_FECHA_HORA");

                        foreach (DataRow oFila3 in oComentarios.Rows)
                        {
                            comentario = oFila3.ItemArray[0].ToString();
                            TreeNode oNode2 = new TreeNode();
                            oNode2.Text = oFila3.ItemArray[1].ToString();
                            oNode2.Name = comentario;
                            oNode1.Nodes.Add(oNode2);
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

        private void frmRecordatorioVista2_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void trvLista_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LlenarDatos(e.Node.Name, e.Node.Level);
        }

        private void LlenarDatos(String tema, int nivel)
        {
            try
            {
                lblComentarios.Text = "";
                lblUsuario.Text = "";
                lblRecordatorios.Text = "";
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    if (nivel == 0)
                    {
                        DataTable oComentarios = new DataTable();
                        DataTable oRecordatorio = oConexion.EjecutaSentencia("SELECT lower(to_char(REC_FECHA_CREA,'dd/mm/yyyy hh:mi:ss am'))|| '.  -  '  ||REC_DETALLE,REC_USUARIO FROM TBL_RECORDATORIO r where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  REC_INDICE= '" + tema + "'");
                        foreach (DataRow oFila in oRecordatorio.Rows)
                        {
                            lblUsuario.Text = oFila.ItemArray[1].ToString();
                            lblRecordatorios.Text = oFila.ItemArray[0].ToString();
                            oComentarios = oConexion.EjecutaSentencia("SELECT lower(to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am'))|| '.  -  '  ||RECOM_COMENTARIO FROM TBL_RECORDATORIO_COMENTARIO rc where rc.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and  RECOM_RECORDATORIO= '" + tema + "' order by RECOM_FECHA_HORA");

                            foreach (DataRow oFila2 in oComentarios.Rows)
                            {
                                lblComentarios.Text += "* " + oFila2.ItemArray[0].ToString() + "\n";
                            }
                        }
                    }
                    else if (nivel == 1)
                    {
                        DataTable oComentarios = oConexion.EjecutaSentencia("select rec_usuario, lower(to_char(REC_FECHA_CREA,'dd/mm/yyyy hh:mi:ss am'))|| '.  -  '||rec_detalle, lower(to_char(recom_fecha_hora,'dd/mm/yyyy hh:mi:ss am'))|| '.  -  '  ||recom_comentario from TBL_RECORDATORIO r, TBL_RECORDATORIO_COMENTARIO rc where r.no_cia = '" + PROYECTO.Properties.Settings.Default.No_cia + "' and r.no_cia = rc.no_Cia and recom_recordatorio=rec_indice and (RECOM_RECORDATORIO||to_char(RECOM_FECHA_HORA,'dd/mm/yyyy hh:mi:ss am')||RECOM_COMENTARIO)='" + tema + "'");

                        foreach (DataRow oFila in oComentarios.Rows)
                        {
                            lblUsuario.Text = oFila.ItemArray[0].ToString();
                            lblRecordatorios.Text = oFila.ItemArray[1].ToString();
                            lblComentarios.Text = "* " + oFila.ItemArray[2].ToString();
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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            trvLista.Refresh();
            //  if (txtBuscar.Text.Trim().Equals(""))
            //      LlenarNodos();
            //  else
            //       LlenarNodos(txtBuscar.Text);

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            lblComentarios.Text = "";
            lblUsuario.Text = "";
            lblRecordatorios.Text = "";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            btnCerrar.Visible = true;
            btnAbrir.Visible = false;
            grbBusqueda.Size = new Size(372, 163);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            btnAbrir.Visible = true;
            btnCerrar.Visible = false;
            grbBusqueda.Size = new Size(372, 19);
        }

        private void txtHora_Leave(object sender, EventArgs e)
        {
            try
            {
                int horIni = HoraInicio();
                int minIni = MinutoInicio();

                switch (horIni)
                {
                    case 0:
                        horIni = 12;
                        rboAM.Checked = true;
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        break;
                    case 13:
                        horIni = 1;
                        rboPM.Checked = true;
                        break;
                    case 14:
                        horIni = 2;
                        rboPM.Checked = true;
                        break;
                    case 15:
                        horIni = 3;
                        rboPM.Checked = true;
                        break;
                    case 16:
                        horIni = 4;
                        rboPM.Checked = true;
                        break;
                    case 17:
                        horIni = 5;
                        rboPM.Checked = true;
                        break;
                    case 18:
                        horIni = 6;
                        rboPM.Checked = true;
                        break;
                    case 19:
                        horIni = 7;
                        rboPM.Checked = true;
                        break;
                    case 20:
                        horIni = 8;
                        rboPM.Checked = true;
                        break;
                    case 21:
                        horIni = 9;
                        rboPM.Checked = true;
                        break;
                    case 22:
                        horIni = 10;
                        rboPM.Checked = true;
                        break;
                    case 23:
                        horIni = 11;
                        rboPM.Checked = true;
                        break;
                    case 24:
                        horIni = 12;
                        rboPM.Checked = true;
                        break;
                    default:
                        horIni = 12;
                        rboPM.Checked = true;
                        break;
                }
                if (minIni > 59)
                    minIni = 59;

                txtHora.Text = horIni.ToString("00") + "" + minIni.ToString("00");

            }
            catch (Exception ex)
            {
            }
        }

        private int HoraInicio()
        {
            int hora = 1;
            try
            {
                hora = DateTime.Parse(txtHora.Text).Hour;
            }
            catch (Exception ex)
            {
            }

            return hora;
        }

        private int MinutoInicio()
        {
            int min = 0;
            try
            {
                min = DateTime.Parse(txtHora.Text).Minute;
            }
            catch (Exception ex)
            {
            }
            return min;
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chkFecha.Checked;
        }

        private void chkHora_CheckedChanged(object sender, EventArgs e)
        {
            txtHora.Enabled = chkHora.Checked;
            rboAM.Enabled = chkHora.Checked;
            rboPM.Enabled = chkHora.Checked;
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = chkOtro.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblComentarios.Text = "";
            lblUsuario.Text = "";
            lblRecordatorios.Text = "";

            btnCerrar.PerformClick();
            trvLista.Nodes.Clear();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            LlenarNodos2();
        }
    }
}
