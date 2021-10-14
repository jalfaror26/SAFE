using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using ENTIDADES;
using System.Media;

namespace PROYECTO
{
    public partial class frmMensajeRecordatorio : Form
    {
        private String fecha;
        private int linea = 0;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor,Conexion.getInstance().Clave);
        private String mensaje;
        private RecordatorioDAO oRecordatorioDAC = new RecordatorioDAO();
        private Recordatorio oRecordatorio = new Recordatorio();

        public String Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Linea
        {
            get { return linea; }
            set { linea = value; }
        }

        public frmMensajeRecordatorio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComentario.Text.Trim().Equals("") || txtComentario.Text.Trim().Equals("Digite un comentario"))
                {
                    MessageBox.Show("Debe digitar el Comentario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComentario.Focus();
                    txtComentario.Clear();
                    return;
                }
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oRecordatorio.Linea = linea;
                    oRecordatorio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                    oRecordatorioDAC.CambiarEstado("MOS", linea, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oRecordatorioDAC.Error())
                    {
                        MessageBox.Show("Error al Guardar:\n" + oRecordatorioDAC.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    oRecordatorioDAC.CrearComentario(oRecordatorio, txtComentario.Text);
                    oConexion.cerrarConexion();
                    if (oRecordatorioDAC.Error())
                        MessageBox.Show("Error al Guardar:\n" + oRecordatorioDAC.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {
            }
            this.Close();
        }

        private void frmMensajeRecordatorio_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;

            lblFecha.Text = fecha;
            lblMensaje.Text = mensaje;
        }

        private void frmMensajeRecordatorio_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal.getInstance().MensajesAbiertos--;
        }

        private void btnPosponer_Click(object sender, EventArgs e)
        {
            if (txtComentario.Text.Trim().Equals("") || txtComentario.Text.Trim().Equals("Digite un comentario"))
            {
                MessageBox.Show("Debe digitar el Comentario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComentario.Focus();
                txtComentario.Clear();
                return;
            }
            panel1.Visible = true;
        }
                private void txtComentario_Enter(object sender, EventArgs e)
        {
            txtComentario.Clear();
        }
                private void btnPosponerRecordatorio_Click(object sender, EventArgs e)
        {
            try
            {
                oConexion.cerrarConexion();
                if (txtComentario.Text.Trim().Equals("") || txtComentario.Text.Trim().Equals("Digite un comentario"))
                {
                    MessageBox.Show("Debe digitar el Comentario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComentario.Focus();
                    txtComentario.Clear();
                    return;
                }
                if (oConexion.abrirConexion())
                {
                    DateTime fecha = DateTime.Today;
                    if (rboAM.Checked)
                        fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " am");
                    else
                        fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " pm");
                    oRecordatorio.Linea = linea;
                    oRecordatorio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;

                    oRecordatorio.FechaHora = fecha;
                    oRecordatorioDAC.Posponer(oRecordatorio);
                    oRecordatorioDAC.CrearComentario(oRecordatorio, txtComentario.Text);
                    oConexion.cerrarConexion();
                    if (oRecordatorioDAC.Error())
                        MessageBox.Show("Error al Posponer:\n" + oRecordatorioDAC.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos estén correctos");
                }
            }
            catch (Exception ex)
            {
            }
            this.Close();
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