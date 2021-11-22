namespace PROYECTO
{
    partial class frmRecordatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecordatorio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mthFecha = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboPM = new System.Windows.Forms.RadioButton();
            this.rboAM = new System.Windows.Forms.RadioButton();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.REC_INDICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timGuardar = new System.Windows.Forms.Timer(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // mthFecha
            // 
            this.mthFecha.Location = new System.Drawing.Point(16, 15);
            this.mthFecha.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.mthFecha.Name = "mthFecha";
            this.mthFecha.TabIndex = 161;
            this.mthFecha.TitleBackColor = System.Drawing.Color.Blue;
            this.mthFecha.TitleForeColor = System.Drawing.Color.White;
            this.mthFecha.TrailingForeColor = System.Drawing.Color.Blue;
            this.mthFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mthFecha_DateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboPM);
            this.groupBox1.Controls.Add(this.rboAM);
            this.groupBox1.Controls.Add(this.txtHora);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(370, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(172, 69);
            this.groupBox1.TabIndex = 162;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hora";
            // 
            // rboPM
            // 
            this.rboPM.AutoSize = true;
            this.rboPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPM.Location = new System.Drawing.Point(107, 38);
            this.rboPM.Margin = new System.Windows.Forms.Padding(4);
            this.rboPM.Name = "rboPM";
            this.rboPM.Size = new System.Drawing.Size(50, 21);
            this.rboPM.TabIndex = 165;
            this.rboPM.Text = "pm";
            this.rboPM.UseVisualStyleBackColor = true;
            this.rboPM.CheckedChanged += new System.EventHandler(this.rboPM_CheckedChanged);
            // 
            // rboAM
            // 
            this.rboAM.AutoSize = true;
            this.rboAM.Checked = true;
            this.rboAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAM.Location = new System.Drawing.Point(107, 16);
            this.rboAM.Margin = new System.Windows.Forms.Padding(4);
            this.rboAM.Name = "rboAM";
            this.rboAM.Size = new System.Drawing.Size(50, 21);
            this.rboAM.TabIndex = 164;
            this.rboAM.TabStop = true;
            this.rboAM.Text = "am";
            this.rboAM.UseVisualStyleBackColor = true;
            this.rboAM.CheckedChanged += new System.EventHandler(this.rboAM_CheckedChanged);
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(15, 25);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4);
            this.txtHora.Mask = "00 : 00";
            this.txtHora.Name = "txtHora";
            this.txtHora.PromptChar = ' ';
            this.txtHora.Size = new System.Drawing.Size(77, 23);
            this.txtHora.TabIndex = 1;
            this.txtHora.Text = "0100";
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            this.txtHora.Leave += new System.EventHandler(this.txtInicio_Leave);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(366, 108);
            this.txtDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetalle.MaxLength = 300;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(572, 96);
            this.txtDetalle.TabIndex = 163;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(370, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 164;
            this.label1.Text = "Detalle";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Aceptar.ico");
            this.imageList1.Images.SetKeyName(1, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(2, "document.ico");
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.REC_INDICE,
            this.hora,
            this.REC_DETALLE});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(19, 228);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersWidth = 20;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(919, 197);
            this.dgrDatos.TabIndex = 160;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // REC_INDICE
            // 
            this.REC_INDICE.DataPropertyName = "REC_INDICE";
            this.REC_INDICE.HeaderText = "linea";
            this.REC_INDICE.MinimumWidth = 6;
            this.REC_INDICE.Name = "REC_INDICE";
            this.REC_INDICE.ReadOnly = true;
            this.REC_INDICE.Visible = false;
            this.REC_INDICE.Width = 125;
            // 
            // hora
            // 
            this.hora.DataPropertyName = "hora";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hora.DefaultCellStyle = dataGridViewCellStyle3;
            this.hora.HeaderText = "   HORA";
            this.hora.MinimumWidth = 6;
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 80;
            // 
            // REC_DETALLE
            // 
            this.REC_DETALLE.DataPropertyName = "REC_DETALLE";
            this.REC_DETALLE.HeaderText = "DETALLE";
            this.REC_DETALLE.MinimumWidth = 6;
            this.REC_DETALLE.Name = "REC_DETALLE";
            this.REC_DETALLE.ReadOnly = true;
            this.REC_DETALLE.Width = 548;
            // 
            // timGuardar
            // 
            this.timGuardar.Tick += new System.EventHandler(this.timGuardar_Tick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.ImageKey = "document.ico";
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(560, 33);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(124, 44);
            this.btnNuevo.TabIndex = 167;
            this.btnNuevo.Text = "  Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.ImageKey = "Sign 06.ico";
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(816, 33);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 44);
            this.btnEliminar.TabIndex = 166;
            this.btnEliminar.Text = "  Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.ImageKey = "Aceptar.ico";
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(688, 33);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(124, 44);
            this.btnGuardar.TabIndex = 165;
            this.btnGuardar.Text = "  Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(342, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 32);
            this.label8.TabIndex = 553;
            this.label8.Text = "*";
            // 
            // frmRecordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 439);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mthFecha);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecordatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recordatorios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecordatorio_FormClosing);
            this.Load += new System.EventHandler(this.frmRecordatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mthFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private System.Windows.Forms.RadioButton rboPM;
        private System.Windows.Forms.RadioButton rboAM;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_INDICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_DETALLE;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Timer timGuardar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
    }
}