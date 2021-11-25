namespace PROYECTO
{
    partial class frmrptFacturasRecibidasPagadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptFacturasRecibidasPagadas));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkProv = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProv = new System.Windows.Forms.TextBox();
            this.txtIdProv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnPagadas = new System.Windows.Forms.RadioButton();
            this.rbtnRecibidas = new System.Windows.Forms.RadioButton();
            this.lblfecha = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnBusq2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document.ico");
            this.imageList1.Images.SetKeyName(1, "Sign 09.ico");
            this.imageList1.Images.SetKeyName(2, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(3, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(4, "services.ico");
            this.imageList1.Images.SetKeyName(5, "Sign 08.ico");
            this.imageList1.Images.SetKeyName(6, "Salir.ico");
            this.imageList1.Images.SetKeyName(7, "file_find.ico");
            this.imageList1.Images.SetKeyName(8, "C&M 17.ico");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(476, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 374;
            this.label4.Text = "Fecha Final";
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.Color.Beige;
            this.txtFechaFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFinal.ForeColor = System.Drawing.Color.Black;
            this.txtFechaFinal.Location = new System.Drawing.Point(505, 106);
            this.txtFechaFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.ReadOnly = true;
            this.txtFechaFinal.Size = new System.Drawing.Size(111, 23);
            this.txtFechaFinal.TabIndex = 373;
            this.txtFechaFinal.TabStop = false;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(480, 106);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(25, 22);
            this.dtpFechaFinal.TabIndex = 372;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(301, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 371;
            this.label3.Text = "Fecha de Inicio";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.Color.Beige;
            this.txtFechaInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.ForeColor = System.Drawing.Color.Black;
            this.txtFechaInicio.Location = new System.Drawing.Point(332, 106);
            this.txtFechaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.ReadOnly = true;
            this.txtFechaInicio.Size = new System.Drawing.Size(111, 23);
            this.txtFechaInicio.TabIndex = 370;
            this.txtFechaInicio.TabStop = false;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(305, 106);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(25, 22);
            this.dtpFechaInicio.TabIndex = 369;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(157, 174);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(155, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 368;
            this.progressBar1.Visible = false;
            // 
            // chkProv
            // 
            this.chkProv.AutoSize = true;
            this.chkProv.Location = new System.Drawing.Point(24, 38);
            this.chkProv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkProv.Name = "chkProv";
            this.chkProv.Size = new System.Drawing.Size(18, 17);
            this.chkProv.TabIndex = 365;
            this.chkProv.UseVisualStyleBackColor = true;
            this.chkProv.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(48, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 364;
            this.label5.Text = "Proveedor";
            // 
            // txtProv
            // 
            this.txtProv.BackColor = System.Drawing.Color.Beige;
            this.txtProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProv.ForeColor = System.Drawing.Color.Black;
            this.txtProv.Location = new System.Drawing.Point(231, 34);
            this.txtProv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProv.Name = "txtProv";
            this.txtProv.ReadOnly = true;
            this.txtProv.Size = new System.Drawing.Size(395, 23);
            this.txtProv.TabIndex = 363;
            this.txtProv.TabStop = false;
            // 
            // txtIdProv
            // 
            this.txtIdProv.BackColor = System.Drawing.Color.Beige;
            this.txtIdProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProv.ForeColor = System.Drawing.Color.Black;
            this.txtIdProv.Location = new System.Drawing.Point(52, 34);
            this.txtIdProv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdProv.Name = "txtIdProv";
            this.txtIdProv.ReadOnly = true;
            this.txtIdProv.Size = new System.Drawing.Size(127, 23);
            this.txtIdProv.TabIndex = 362;
            this.txtIdProv.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnPagadas);
            this.groupBox1.Controls.Add(this.rbtnRecibidas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(261, 87);
            this.groupBox1.TabIndex = 360;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturas";
            // 
            // rbtnPagadas
            // 
            this.rbtnPagadas.AutoSize = true;
            this.rbtnPagadas.Location = new System.Drawing.Point(20, 53);
            this.rbtnPagadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnPagadas.Name = "rbtnPagadas";
            this.rbtnPagadas.Size = new System.Drawing.Size(160, 21);
            this.rbtnPagadas.TabIndex = 1;
            this.rbtnPagadas.Text = "Facturas Pagadas";
            this.rbtnPagadas.UseVisualStyleBackColor = true;
            // 
            // rbtnRecibidas
            // 
            this.rbtnRecibidas.AutoSize = true;
            this.rbtnRecibidas.Checked = true;
            this.rbtnRecibidas.Location = new System.Drawing.Point(20, 25);
            this.rbtnRecibidas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnRecibidas.Name = "rbtnRecibidas";
            this.rbtnRecibidas.Size = new System.Drawing.Size(168, 21);
            this.rbtnRecibidas.TabIndex = 0;
            this.rbtnRecibidas.TabStop = true;
            this.rbtnRecibidas.Text = "Facturas Recibidas";
            this.rbtnRecibidas.UseVisualStyleBackColor = true;
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.Black;
            this.lblfecha.Location = new System.Drawing.Point(524, 11);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblfecha.Size = new System.Drawing.Size(0, 17);
            this.lblfecha.TabIndex = 375;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 6;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(475, 169);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 34);
            this.btnSalir.TabIndex = 367;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEjecutar.ImageIndex = 4;
            this.btnEjecutar.ImageList = this.imageList1;
            this.btnEjecutar.Location = new System.Drawing.Point(327, 169);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(140, 34);
            this.btnEjecutar.TabIndex = 366;
            this.btnEjecutar.Text = "&Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnBusq2
            // 
            this.btnBusq2.Enabled = false;
            this.btnBusq2.Image = ((System.Drawing.Image)(resources.GetObject("btnBusq2.Image")));
            this.btnBusq2.Location = new System.Drawing.Point(188, 31);
            this.btnBusq2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusq2.Name = "btnBusq2";
            this.btnBusq2.Size = new System.Drawing.Size(35, 30);
            this.btnBusq2.TabIndex = 361;
            this.btnBusq2.UseVisualStyleBackColor = true;
            this.btnBusq2.Click += new System.EventHandler(this.btnBusq2_Click);
            // 
            // frmrptFacturasRecibidasPagadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 220);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.chkProv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBusq2);
            this.Controls.Add(this.txtProv);
            this.Controls.Add(this.txtIdProv);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrptFacturasRecibidasPagadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Facturas Recibidas y Pagadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmrptFacturasRecibidasPagadas_FormClosing);
            this.Load += new System.EventHandler(this.frmrptFacturasRecibidasPagadas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.CheckBox chkProv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBusq2;
        private System.Windows.Forms.TextBox txtProv;
        private System.Windows.Forms.TextBox txtIdProv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnPagadas;
        private System.Windows.Forms.RadioButton rbtnRecibidas;
        private System.Windows.Forms.Label lblfecha;
    }
}