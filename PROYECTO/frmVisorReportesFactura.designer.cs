namespace PROYECTO
{
    partial class frmVisorReportesFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisorReportesFactura));
            this.crvVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.prdImprimir = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // crvVisor
            // 
            this.crvVisor.ActiveViewIndex = -1;
            this.crvVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisor.Location = new System.Drawing.Point(0, 0);
            this.crvVisor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crvVisor.Name = "crvVisor";
            this.crvVisor.SelectionFormula = "";
            this.crvVisor.ShowExportButton = false;
            this.crvVisor.ShowGroupTreeButton = false;
            this.crvVisor.ShowPrintButton = false;
            this.crvVisor.Size = new System.Drawing.Size(1371, 697);
            this.crvVisor.TabIndex = 0;
            this.crvVisor.ToolPanelWidth = 267;
            this.crvVisor.ViewTimeSelectionFormula = "";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(481, 4);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 28);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // prdImprimir
            // 
            this.prdImprimir.UseEXDialog = true;
            // 
            // frmVisorReportesFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 697);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.crvVisor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisorReportesFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisorReportes_FormClosing);
            this.Load += new System.EventHandler(this.frmVisorReportesFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisor;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PrintDialog prdImprimir;
    }
}