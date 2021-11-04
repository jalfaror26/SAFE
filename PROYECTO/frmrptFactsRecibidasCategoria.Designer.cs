namespace PROYECTO
{
    partial class frmrptFactsRecibidasCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptFactsRecibidasCategoria));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoCambioDolar = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.rutaGuardar = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnVerInfo = new System.Windows.Forms.Button();
            this.gbTipoInfo = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.rbConded = new System.Windows.Forms.RadioButton();
            this.rbSinded = new System.Windows.Forms.RadioButton();
            this.gbTipoInfo.SuspendLayout();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(163, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 390;
            this.label4.Text = "Fecha Final";
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.Color.Beige;
            this.txtFechaFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFinal.ForeColor = System.Drawing.Color.Black;
            this.txtFechaFinal.Location = new System.Drawing.Point(192, 31);
            this.txtFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.ReadOnly = true;
            this.txtFechaFinal.Size = new System.Drawing.Size(111, 23);
            this.txtFechaFinal.TabIndex = 389;
            this.txtFechaFinal.TabStop = false;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(167, 31);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(25, 22);
            this.dtpFechaFinal.TabIndex = 388;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 387;
            this.label3.Text = "Fecha de Inicio";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.Color.Beige;
            this.txtFechaInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.ForeColor = System.Drawing.Color.Black;
            this.txtFechaInicio.Location = new System.Drawing.Point(47, 31);
            this.txtFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.ReadOnly = true;
            this.txtFechaInicio.Size = new System.Drawing.Size(111, 23);
            this.txtFechaInicio.TabIndex = 386;
            this.txtFechaInicio.TabStop = false;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(20, 31);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(25, 22);
            this.dtpFechaInicio.TabIndex = 385;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 116);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(208, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 384;
            this.progressBar1.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 6;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(369, 111);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(125, 34);
            this.btnSalir.TabIndex = 383;
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
            this.btnEjecutar.Location = new System.Drawing.Point(236, 111);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(125, 34);
            this.btnEjecutar.TabIndex = 382;
            this.btnEjecutar.Text = "&Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "CRC",
            "USD"});
            this.cmbMoneda.Location = new System.Drawing.Point(312, 30);
            this.cmbMoneda.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(85, 24);
            this.cmbMoneda.TabIndex = 391;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(308, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 392;
            this.label1.Text = "Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(403, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 414;
            this.label5.Text = "T/C Dolar";
            // 
            // txtTipoCambioDolar
            // 
            this.txtTipoCambioDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambioDolar.Location = new System.Drawing.Point(407, 30);
            this.txtTipoCambioDolar.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoCambioDolar.Name = "txtTipoCambioDolar";
            this.txtTipoCambioDolar.Size = new System.Drawing.Size(87, 23);
            this.txtTipoCambioDolar.TabIndex = 413;
            this.toolTip1.SetToolTip(this.txtTipoCambioDolar, "Tipo de cambio utilizado exclusivamente para los pagos realizados en euros.");
            this.txtTipoCambioDolar.Enter += new System.EventHandler(this.txtTipoCambioDolar_Enter);
            this.txtTipoCambioDolar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipoCambioDolar_KeyPress);
            this.txtTipoCambioDolar.Leave += new System.EventHandler(this.txtTipoCambioDolar_Leave);
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(20, 74);
            this.chkXML.Margin = new System.Windows.Forms.Padding(4);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(107, 21);
            this.chkXML.TabIndex = 417;
            this.chkXML.Text = "Generar xml";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Importante";
            // 
            // btnVerInfo
            // 
            this.btnVerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerInfo.ImageIndex = 7;
            this.btnVerInfo.ImageList = this.imageList1;
            this.btnVerInfo.Location = new System.Drawing.Point(369, 69);
            this.btnVerInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerInfo.Name = "btnVerInfo";
            this.btnVerInfo.Size = new System.Drawing.Size(125, 34);
            this.btnVerInfo.TabIndex = 418;
            this.btnVerInfo.Text = "&Ver Info";
            this.btnVerInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerInfo.UseVisualStyleBackColor = true;
            this.btnVerInfo.Click += new System.EventHandler(this.btnVerInfo_Click);
            // 
            // gbTipoInfo
            // 
            this.gbTipoInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbTipoInfo.Controls.Add(this.btnCancelar);
            this.gbTipoInfo.Controls.Add(this.btnAceptar);
            this.gbTipoInfo.Controls.Add(this.rbConded);
            this.gbTipoInfo.Controls.Add(this.rbSinded);
            this.gbTipoInfo.Location = new System.Drawing.Point(89, 9);
            this.gbTipoInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbTipoInfo.Name = "gbTipoInfo";
            this.gbTipoInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbTipoInfo.Size = new System.Drawing.Size(317, 129);
            this.gbTipoInfo.TabIndex = 419;
            this.gbTipoInfo.TabStop = false;
            this.gbTipoInfo.Text = "Tipo de Informacion";
            this.gbTipoInfo.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(29, 78);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 34);
            this.btnCancelar.TabIndex = 384;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageIndex = 4;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(163, 78);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 34);
            this.btnAceptar.TabIndex = 383;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rbConded
            // 
            this.rbConded.AutoSize = true;
            this.rbConded.Location = new System.Drawing.Point(143, 38);
            this.rbConded.Margin = new System.Windows.Forms.Padding(4);
            this.rbConded.Name = "rbConded";
            this.rbConded.Size = new System.Drawing.Size(163, 21);
            this.rbConded.TabIndex = 1;
            this.rbConded.Text = "Facturas modificadas";
            this.rbConded.UseVisualStyleBackColor = true;
            // 
            // rbSinded
            // 
            this.rbSinded.Checked = true;
            this.rbSinded.Location = new System.Drawing.Point(9, 26);
            this.rbSinded.Margin = new System.Windows.Forms.Padding(4);
            this.rbSinded.Name = "rbSinded";
            this.rbSinded.Size = new System.Drawing.Size(128, 44);
            this.rbSinded.TabIndex = 0;
            this.rbSinded.TabStop = true;
            this.rbSinded.Text = "Facturas sin modificar";
            this.rbSinded.UseVisualStyleBackColor = true;
            // 
            // frmrptFactsRecibidasCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 160);
            this.Controls.Add(this.gbTipoInfo);
            this.Controls.Add(this.btnVerInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipoCambioDolar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEjecutar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrptFactsRecibidasCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Montos Recibidos por Categoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmrptReportePagosRealizadosCategoria_FormClosing);
            this.Load += new System.EventHandler(this.frmrptReportePagosRealizadosCategoria_Load);
            this.gbTipoInfo.ResumeLayout(false);
            this.gbTipoInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipoCambioDolar;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.SaveFileDialog rutaGuardar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnVerInfo;
        private System.Windows.Forms.GroupBox gbTipoInfo;
        private System.Windows.Forms.RadioButton rbSinded;
        private System.Windows.Forms.RadioButton rbConded;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}