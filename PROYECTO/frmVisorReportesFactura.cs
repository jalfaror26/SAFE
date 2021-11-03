using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace PROYECTO
{
    public partial class frmVisorReportesFactura : Form
    {
        private static frmVisorReportesFactura oVisor = null;
        private ReportDocument oReporte = null;
        private PrintDocument oImpresion = null;

        public frmVisorReportesFactura()
        {
            InitializeComponent();
        }

        public static frmVisorReportesFactura getInstance()
        {
            if (oVisor == null)
                oVisor = new frmVisorReportesFactura();
            return oVisor;
        }

        public string TituloReporte
        {
            set { this.Text = value; }
            get { return this.Text.ToString(); }
        }

        //public void ReportSource(rptFactura rptReporte)
        //{
        //    oReporte = rptReporte;
        //    crvVisor.ReportSource = rptReporte;
        //}

        private void frmVisorReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            oVisor = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                        oReporte.DataDefinition.FormulaFields["tipo"].Text = "'ORIGINAL'";
                    else if (i == 1)
                        oReporte.DataDefinition.FormulaFields["tipo"].Text = "'COPIA'";
                    else if (i == 2)
                        oReporte.DataDefinition.FormulaFields["tipo"].Text = "'CONTABILIDAD'";
                    else if (i == 3)
                        oReporte.DataDefinition.FormulaFields["tipo"].Text = "'ARCHIVO'";

                    oReporte.PrintToPrinter(1, false, 1, 5);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmVisorReportesFactura_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height;

            this.Size = new Size(x - 20, y - 80);
            this.Location = new Point(0, 10);
        }
    }
}