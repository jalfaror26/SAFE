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
    public partial class frmRecordatorio : Form
    {
        private String tipo = "";
        private int persona;

        private frmRecordatorio()
        {
            InitializeComponent();
        }

        private frmRecordatorio(String ptipo, int pPersona)
        {
            InitializeComponent();
            tipo = ptipo;
            persona = pPersona;
        }

        private static frmRecordatorio instance = null;
        private ConexionDAO oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Servidor, Conexion.getInstance().Clave);
        private String codigo = "par_Recordatorio", descripcion = "Creacion de Recordatorios.", modulo = "Recordatorios";
        private RecordatorioDAO oRecordatorioDAO = new RecordatorioDAO();
        private Recordatorio oRecordatorio = new Recordatorio();
        private DateTime hoy = new DateTime();
        private int linea = 0;
        private String detalle = "";

        public String Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

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

        public static frmRecordatorio getInstance(String ptipo, int pPersona)
        {
            if (instance == null)
                instance = new frmRecordatorio(ptipo, pPersona);
            return instance;
        }

        public static frmRecordatorio getInstance()
        {
            if (instance == null)
                instance = new frmRecordatorio();
            return instance;
        }

        private void frmRecordatorio_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void frmRecordatorio_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.Name;
            Llenar_Grid();
            timer1.Start();
        }

        private DataTable CrearTabla()
        {
            DataTable oHoras = new DataTable();
            oHoras.Columns.Add("REC_INDICE");
            oHoras.Columns.Add("HORA");
            oHoras.Columns.Add("REC_DETALLE");
            DataRow oFila = null;
            DateTime toda = new DateTime();

            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    toda = new DateTime();
                    if (h < 12)
                        toda = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + h.ToString("00") + ":" + m.ToString("00") + ":00 a.m.");
                    else
                        toda = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + h.ToString("00") + ":" + m.ToString("00") + ":00 p.m.");
                    oFila = oHoras.NewRow();
                    oFila["REC_INDICE"] = "0";
                    oFila["hora"] = toda.ToShortTimeString();
                    oFila["REC_DETALLE"] = "";
                    oHoras.Rows.Add(oFila.ItemArray);
                }
            }
            return oHoras;
        }

        private void Llenar_Grid()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    hoy = oConexion.fecha();
                    DataTable oHoras = new DataTable();
                    oHoras.Columns.Add("REC_INDICE");
                    oHoras.Columns.Add("HORA");
                    oHoras.Columns.Add("REC_DETALLE");
                    DataRow oFila = null;

                    DataTable oTabla2 = oRecordatorioDAO.Consultar(mthFecha.SelectionStart, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    foreach (DataRow oFila2 in oTabla2.Rows)
                    {
                        oFila = oHoras.NewRow();
                        oFila["REC_INDICE"] = oFila2.ItemArray[0].ToString();
                        oFila["REC_DETALLE"] = oFila2.ItemArray[1].ToString();
                        oFila["HORA"] = oFila2.ItemArray[2].ToString().ToLower();
                        oHoras.Rows.Add(oFila.ItemArray);
                    }
                    dgrDatos.DataSource = oHoras;
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

        private void txtInicio_Leave(object sender, EventArgs e)
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

                DateTime fecha = new DateTime();
                if (rboAM.Checked)
                    fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " am");
                else
                    fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " pm");

                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                hoy = oConexion.fecha();
                if (fecha <= hoy)
                {
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = true;
                }


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

        private void mthFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            Llenar_Grid();
            //DateTime hoy2 = DateTime.Parse(hoy.ToShortDateString());
            //if (mthFecha.SelectionStart < hoy2)
            //{
            //    btnNuevo.Enabled = false;
            //    btnGuardar.Enabled = false;
            //    btnEliminar.Enabled = false;
            //}
            //else
            //    btnNuevo.Enabled = true;
        }

        private void dgrDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String hora = dgrDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDetalle.Text = dgrDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                linea = int.Parse(dgrDatos.Rows[e.RowIndex].Cells[0].Value.ToString());

                oConexion.cerrarConexion();
                oConexion.abrirConexion();
                hoy = oConexion.fecha();

                DateTime horaRec = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + hora);


                String hor = "";
                for (int x = 0; x < hora.Length - 1; x++)
                {
                    if (char.IsNumber(hora[x]))
                        hor += hora[x].ToString();
                    else
                    {
                        if (hora[x].Equals('a') && hora[x + 1].Equals('m'))
                            rboAM.Checked = true;
                        else if (hora[x].Equals('p') && hora[x + 1].Equals('m'))
                            rboPM.Checked = true;
                    }
                }
                btnNuevo.Enabled = true;
                txtHora.Text = hor;

                if (horaRec < hoy)
                {
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void dgrDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            limpiar();
            dgrDatos.ClearSelection();
            txtDetalle.Text = detalle;
        }

        private void limpiar()
        {
            try
            {
                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    hoy = oConexion.fecha();
                    hoy = hoy.AddMinutes(1);
                    txtHora.Text = hoy.ToShortTimeString();
                    for (int x = 0; x < hoy.ToShortTimeString().Length - 1; x++)
                    {
                        if (hoy.ToShortTimeString().ToUpper()[x].Equals('A') && hoy.ToShortTimeString().ToUpper()[x + 2].Equals('M'))
                            rboAM.Checked = true;
                        else if (hoy.ToShortTimeString().ToUpper()[x].Equals('P') && hoy.ToShortTimeString().ToUpper()[x + 2].Equals('M'))
                            rboPM.Checked = true;
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
            linea = 0;
            txtDetalle.Clear();
            btnEliminar.Enabled = false;
        }

        private void rboAM_CheckedChanged(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime();
            if (rboAM.Checked)
                fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " am");
            else
                fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " pm");

            oConexion.cerrarConexion();
            oConexion.abrirConexion();
            hoy = oConexion.fecha();
            if (fecha <= hoy)
            {
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = true;
            }
        }

        private void rboPM_CheckedChanged(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime();
            if (rboAM.Checked)
                fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " am");
            else
                fecha = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " pm");

            oConexion.cerrarConexion();
            oConexion.abrirConexion();
            hoy = oConexion.fecha();
            if (fecha <= hoy)
            {
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            detalle = "";
            limpiar();
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtDetalle.Focus();
            timGuardar.Start();
        }

        private void Guardar()
        {
            try
            {
                if (txtDetalle.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe digitar un Detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDetalle.Focus();
                    return;
                }

                oConexion.cerrarConexion();
                if (oConexion.abrirConexion())
                {
                    oRecordatorio = new Recordatorio();

                    oRecordatorio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oRecordatorio.Linea = linea;
                    if (rboAM.Checked)
                        oRecordatorio.FechaHora = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " am");
                    else
                        oRecordatorio.FechaHora = DateTime.Parse(mthFecha.SelectionStart.ToShortDateString() + " " + txtHora.Text + " pm");
                    oRecordatorio.Detalle = txtDetalle.Text;
                    oRecordatorio.DetalleProviene = "";
                    oRecordatorio.IndiceProviene = linea;
                    oRecordatorio.Persona = persona;
                    oRecordatorio.Tipo = tipo;
                    oRecordatorioDAO.Guardar(oRecordatorio);
                    detalle = "";
                    if (oRecordatorioDAO.Error())
                        MessageBox.Show("Error al Guardar:\n" + oRecordatorioDAO.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Guardado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Llenar_Grid();
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

        private void timGuardar_Tick(object sender, EventArgs e)
        {
            timGuardar.Stop();
            Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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
                    oRecordatorio = new Recordatorio();

                    oRecordatorio.No_cia = PROYECTO.Properties.Settings.Default.No_cia;
                    oRecordatorio.Linea = linea;

                    oRecordatorioDAO.Eliminar(oRecordatorio);

                    if (oRecordatorioDAO.Error())
                        MessageBox.Show("Error al Eliminar:\n" + oRecordatorioDAO.DescError(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Llenar_Grid();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            btnNuevo.Enabled = true;
            txtDetalle.Text = detalle;
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