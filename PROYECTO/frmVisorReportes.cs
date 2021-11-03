using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace PROYECTO
{
    public partial class frmVisorReportes : Form
    {
        private static frmVisorReportes oVisor = null;
        public frmVisorReportes()
        {
            InitializeComponent();
        }

        public static frmVisorReportes getInstance()
        {
            if (oVisor == null)
                oVisor = new frmVisorReportes();
            return oVisor;
        }

        public string TituloReporte
        {
            set { this.Text = value; }
            get { return this.Text.ToString(); }
        }

        public void ReportSource(ReportDocument rptReporte)
        {
            crvVisor.ReportSource = rptReporte;
        }

        private void frmVisorReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            oVisor = null;
        }

        private void frmVisorReportes_Load(object sender, EventArgs e)
        {
            int x = frmPrincipal.getInstance().Size.Width;
            int y = frmPrincipal.getInstance().Size.Height;

            this.Size = new Size(x - 40, y - 100);
            this.Location = new Point(10, 10);
        }

    }
}