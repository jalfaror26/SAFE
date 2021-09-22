namespace PROYECTO
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.chkMenu = new System.Windows.Forms.CheckBox();
            this.stEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stEtiqueta1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLinea1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLinea2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLinea3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stTC = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLinea5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLinea4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stActual = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.opfImagen = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timFecha = new System.Windows.Forms.Timer(this.components);
            this.ttMJ = new System.Windows.Forms.ToolTip(this.components);
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.stEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(196, 161);
            // 
            // chkMenu
            // 
            this.chkMenu.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMenu.ForeColor = System.Drawing.Color.Black;
            this.chkMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMenu.ImageIndex = 0;
            this.chkMenu.Location = new System.Drawing.Point(-1, 0);
            this.chkMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMenu.Name = "chkMenu";
            this.chkMenu.Size = new System.Drawing.Size(195, 42);
            this.chkMenu.TabIndex = 1;
            this.chkMenu.Text = "Menú";
            this.chkMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkMenu.UseVisualStyleBackColor = true;
            this.chkMenu.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // stEstado
            // 
            this.stEstado.AutoSize = false;
            this.stEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.stEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.stEtiqueta1,
            this.stLinea1,
            this.stFecha,
            this.stLinea2,
            this.stUsuario,
            this.stLinea3,
            this.stTC,
            this.stLinea5,
            this.stVersion,
            this.stLinea4,
            this.stActual});
            this.stEstado.Location = new System.Drawing.Point(0, 0);
            this.stEstado.Name = "stEstado";
            this.stEstado.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stEstado.Size = new System.Drawing.Size(1051, 41);
            this.stEstado.TabIndex = 27;
            this.stEstado.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(148, 35);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // stEtiqueta1
            // 
            this.stEtiqueta1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stEtiqueta1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stEtiqueta1.Name = "stEtiqueta1";
            this.stEtiqueta1.Size = new System.Drawing.Size(79, 35);
            this.stEtiqueta1.Text = "Estado: ";
            // 
            // stLinea1
            // 
            this.stLinea1.AutoSize = false;
            this.stLinea1.BackColor = System.Drawing.Color.White;
            this.stLinea1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLinea1.Name = "stLinea1";
            this.stLinea1.Size = new System.Drawing.Size(4, 35);
            this.stLinea1.Visible = false;
            // 
            // stFecha
            // 
            this.stFecha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.stFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stFecha.Name = "stFecha";
            this.stFecha.Size = new System.Drawing.Size(0, 35);
            // 
            // stLinea2
            // 
            this.stLinea2.AutoSize = false;
            this.stLinea2.BackColor = System.Drawing.Color.White;
            this.stLinea2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLinea2.Name = "stLinea2";
            this.stLinea2.Size = new System.Drawing.Size(4, 35);
            this.stLinea2.Visible = false;
            // 
            // stUsuario
            // 
            this.stUsuario.BackColor = System.Drawing.Color.Transparent;
            this.stUsuario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stUsuario.Name = "stUsuario";
            this.stUsuario.Size = new System.Drawing.Size(0, 35);
            // 
            // stLinea3
            // 
            this.stLinea3.AutoSize = false;
            this.stLinea3.BackColor = System.Drawing.Color.White;
            this.stLinea3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLinea3.Name = "stLinea3";
            this.stLinea3.Size = new System.Drawing.Size(4, 35);
            this.stLinea3.Visible = false;
            // 
            // stTC
            // 
            this.stTC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.stTC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stTC.Name = "stTC";
            this.stTC.Size = new System.Drawing.Size(0, 35);
            // 
            // stLinea5
            // 
            this.stLinea5.AutoSize = false;
            this.stLinea5.BackColor = System.Drawing.Color.White;
            this.stLinea5.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLinea5.Name = "stLinea5";
            this.stLinea5.Size = new System.Drawing.Size(4, 35);
            this.stLinea5.Visible = false;
            // 
            // stVersion
            // 
            this.stVersion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.stVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stVersion.Name = "stVersion";
            this.stVersion.Size = new System.Drawing.Size(0, 35);
            // 
            // stLinea4
            // 
            this.stLinea4.AutoSize = false;
            this.stLinea4.BackColor = System.Drawing.Color.White;
            this.stLinea4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLinea4.Name = "stLinea4";
            this.stLinea4.Size = new System.Drawing.Size(4, 35);
            this.stLinea4.Visible = false;
            // 
            // stActual
            // 
            this.stActual.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stActual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stActual.Name = "stActual";
            this.stActual.Size = new System.Drawing.Size(0, 35);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-9, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43689, 2);
            this.label1.TabIndex = 24;
            // 
            // opfImagen
            // 
            this.opfImagen.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timFecha
            // 
            this.timFecha.Tick += new System.EventHandler(this.timFecha_Tick);
            // 
            // ttMJ
            // 
            this.ttMJ.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ttMJ.ForeColor = System.Drawing.Color.Black;
            this.ttMJ.IsBalloon = true;
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.AutoSize = false;
            this.mnuPrincipal.BackColor = System.Drawing.Color.White;
            this.mnuPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mnuPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPrincipal.Enabled = false;
            this.mnuPrincipal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 41);
            this.mnuPrincipal.Margin = new System.Windows.Forms.Padding(0, 0, 13, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuPrincipal.Size = new System.Drawing.Size(193, 187);
            this.mnuPrincipal.TabIndex = 2;
            this.mnuPrincipal.Text = "menuStrip1";
            this.mnuPrincipal.Visible = false;
            this.mnuPrincipal.EnabledChanged += new System.EventHandler(this.mnuPrincipal_EnabledChanged);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 692);
            this.Controls.Add(this.mnuPrincipal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkMenu);
            this.Controls.Add(this.stEstado);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrativo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.stEstado.ResumeLayout(false);
            this.stEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMenu;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.StatusStrip stEstado;
        private System.Windows.Forms.ToolStripStatusLabel stEtiqueta1;
        private System.Windows.Forms.ToolStripStatusLabel stLinea1;
        private System.Windows.Forms.ToolStripStatusLabel stUsuario;
        private System.Windows.Forms.ToolStripStatusLabel stLinea2;
        private System.Windows.Forms.ToolStripStatusLabel stActual;
        private System.Windows.Forms.ToolStripStatusLabel stLinea3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog opfImagen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel stFecha;
        private System.Windows.Forms.ToolStripStatusLabel stLinea4;
        private System.Windows.Forms.Timer timFecha;
        private System.Windows.Forms.ToolStripStatusLabel stTC;
        private System.Windows.Forms.ToolTip ttMJ;
        private System.Windows.Forms.ToolStripStatusLabel stVersion;
        private System.Windows.Forms.ToolStripStatusLabel stLinea5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
    }
}