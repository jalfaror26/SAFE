namespace PROYECTO
{
    partial class frmVisorReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisorReportes));
            this.crvVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVisor
            // 
            this.crvVisor.ActiveViewIndex = -1;
            this.crvVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisor.Location = new System.Drawing.Point(0, 0);
            this.crvVisor.Margin = new System.Windows.Forms.Padding(4);
            this.crvVisor.Name = "crvVisor";
            this.crvVisor.SelectionFormula = "";
            this.crvVisor.ShowCloseButton = false;
            this.crvVisor.ShowParameterPanelButton = false;
            this.crvVisor.ShowRefreshButton = false;
            this.crvVisor.ShowTextSearchButton = false;
            this.crvVisor.ShowZoomButton = false;
            this.crvVisor.Size = new System.Drawing.Size(1232, 653);
            this.crvVisor.TabIndex = 0;
            this.crvVisor.ToolPanelWidth = 267;
            this.crvVisor.ViewTimeSelectionFormula = "";
            // 
            // frmVisorReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 653);
            this.Controls.Add(this.crvVisor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisorReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor de Reportes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisorReportes_FormClosing);
            this.Load += new System.EventHandler(this.frmVisorReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisor;
    }
}