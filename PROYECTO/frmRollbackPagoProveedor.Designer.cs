namespace PROYECTO
{
    partial class frmRollbackPagoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRollbackPagoProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtCodProveedor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnUsd = new System.Windows.Forms.RadioButton();
            this.rbtnCol = new System.Windows.Forms.RadioButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.PRE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_MONEDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_FECHA_REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_MONTO_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancelarPagos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBGuia = new System.Windows.Forms.TextBox();
            this.txtBFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBFacturas = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.Beige;
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtProveedor.Location = new System.Drawing.Point(177, 36);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(309, 23);
            this.txtProveedor.TabIndex = 364;
            // 
            // txtCodProveedor
            // 
            this.txtCodProveedor.BackColor = System.Drawing.Color.Beige;
            this.txtCodProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtCodProveedor.Location = new System.Drawing.Point(33, 36);
            this.txtCodProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodProveedor.Name = "txtCodProveedor";
            this.txtCodProveedor.ReadOnly = true;
            this.txtCodProveedor.Size = new System.Drawing.Size(135, 23);
            this.txtCodProveedor.TabIndex = 363;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 365;
            this.label8.Text = "Proveedor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnUsd);
            this.groupBox1.Controls.Add(this.rbtnCol);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(512, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(175, 54);
            this.groupBox1.TabIndex = 369;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Moneda";
            // 
            // rbtnUsd
            // 
            this.rbtnUsd.AutoSize = true;
            this.rbtnUsd.Location = new System.Drawing.Point(88, 21);
            this.rbtnUsd.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnUsd.Name = "rbtnUsd";
            this.rbtnUsd.Size = new System.Drawing.Size(61, 21);
            this.rbtnUsd.TabIndex = 371;
            this.rbtnUsd.Text = "USD";
            this.rbtnUsd.UseVisualStyleBackColor = true;
            this.rbtnUsd.CheckedChanged += new System.EventHandler(this.rbtnUsd_CheckedChanged);
            // 
            // rbtnCol
            // 
            this.rbtnCol.AutoSize = true;
            this.rbtnCol.Checked = true;
            this.rbtnCol.Location = new System.Drawing.Point(15, 22);
            this.rbtnCol.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnCol.Name = "rbtnCol";
            this.rbtnCol.Size = new System.Drawing.Size(60, 21);
            this.rbtnCol.TabIndex = 370;
            this.rbtnCol.TabStop = true;
            this.rbtnCol.Text = "CRC";
            this.rbtnCol.UseVisualStyleBackColor = true;
            this.rbtnCol.CheckedChanged += new System.EventHandler(this.rbtnCol_CheckedChanged);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "Disc 01.ico");
            this.imageList2.Images.SetKeyName(4, "Salir.ico");
            this.imageList2.Images.SetKeyName(5, "Printer Inyect.ico");
            this.imageList2.Images.SetKeyName(6, "Sign 09.ico");
            this.imageList2.Images.SetKeyName(7, "Sign 08.ico");
            this.imageList2.Images.SetKeyName(8, "Sign 04.ico");
            this.imageList2.Images.SetKeyName(9, "Sign 05.ico");
            this.imageList2.Images.SetKeyName(10, "File 07.ico");
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            this.dgrDatos.AllowUserToResizeColumns = false;
            this.dgrDatos.AllowUserToResizeRows = false;
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
            this.dgrDatos.ColumnHeadersHeight = 29;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRE_ID,
            this.PRE_PROVEEDOR,
            this.PRE_MONEDA,
            this.PRE_FECHA_REGISTRO,
            this.PRE_MONTO_TOTAL,
            this.facturas});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(43, 138);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(692, 209);
            this.dgrDatos.TabIndex = 473;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // PRE_ID
            // 
            this.PRE_ID.DataPropertyName = "PRE_ID";
            this.PRE_ID.HeaderText = "GUÍA";
            this.PRE_ID.MinimumWidth = 6;
            this.PRE_ID.Name = "PRE_ID";
            this.PRE_ID.ReadOnly = true;
            this.PRE_ID.Width = 125;
            // 
            // PRE_PROVEEDOR
            // 
            this.PRE_PROVEEDOR.DataPropertyName = "PRE_PROVEEDOR";
            this.PRE_PROVEEDOR.HeaderText = "PRE_PROVEEDOR";
            this.PRE_PROVEEDOR.MinimumWidth = 6;
            this.PRE_PROVEEDOR.Name = "PRE_PROVEEDOR";
            this.PRE_PROVEEDOR.ReadOnly = true;
            this.PRE_PROVEEDOR.Visible = false;
            this.PRE_PROVEEDOR.Width = 125;
            // 
            // PRE_MONEDA
            // 
            this.PRE_MONEDA.DataPropertyName = "PRE_MONEDA";
            this.PRE_MONEDA.HeaderText = "PRE_MONEDA";
            this.PRE_MONEDA.MinimumWidth = 6;
            this.PRE_MONEDA.Name = "PRE_MONEDA";
            this.PRE_MONEDA.ReadOnly = true;
            this.PRE_MONEDA.Visible = false;
            this.PRE_MONEDA.Width = 125;
            // 
            // PRE_FECHA_REGISTRO
            // 
            this.PRE_FECHA_REGISTRO.DataPropertyName = "PRE_FECHA_REGISTRO";
            this.PRE_FECHA_REGISTRO.HeaderText = "FECHA";
            this.PRE_FECHA_REGISTRO.MinimumWidth = 6;
            this.PRE_FECHA_REGISTRO.Name = "PRE_FECHA_REGISTRO";
            this.PRE_FECHA_REGISTRO.ReadOnly = true;
            this.PRE_FECHA_REGISTRO.Width = 125;
            // 
            // PRE_MONTO_TOTAL
            // 
            this.PRE_MONTO_TOTAL.DataPropertyName = "PRE_MONTO_TOTAL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PRE_MONTO_TOTAL.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRE_MONTO_TOTAL.HeaderText = "MONTO";
            this.PRE_MONTO_TOTAL.MinimumWidth = 6;
            this.PRE_MONTO_TOTAL.Name = "PRE_MONTO_TOTAL";
            this.PRE_MONTO_TOTAL.ReadOnly = true;
            this.PRE_MONTO_TOTAL.Width = 125;
            // 
            // facturas
            // 
            this.facturas.DataPropertyName = "facturas";
            this.facturas.HeaderText = "FACTURAS";
            this.facturas.MinimumWidth = 6;
            this.facturas.Name = "facturas";
            this.facturas.ReadOnly = true;
            this.facturas.Width = 200;
            // 
            // txtSalir
            // 
            this.txtSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSalir.ImageIndex = 4;
            this.txtSalir.ImageList = this.imageList2;
            this.txtSalir.Location = new System.Drawing.Point(465, 363);
            this.txtSalir.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalir.Name = "txtSalir";
            this.txtSalir.Size = new System.Drawing.Size(207, 39);
            this.txtSalir.TabIndex = 475;
            this.txtSalir.Text = "Salir";
            this.txtSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtSalir.UseVisualStyleBackColor = true;
            this.txtSalir.Click += new System.EventHandler(this.txtSalir_Click);
            // 
            // btnCancelarPagos
            // 
            this.btnCancelarPagos.Enabled = false;
            this.btnCancelarPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarPagos.ImageIndex = 0;
            this.btnCancelarPagos.ImageList = this.imageList2;
            this.btnCancelarPagos.Location = new System.Drawing.Point(232, 363);
            this.btnCancelarPagos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarPagos.Name = "btnCancelarPagos";
            this.btnCancelarPagos.Size = new System.Drawing.Size(207, 39);
            this.btnCancelarPagos.TabIndex = 494;
            this.btnCancelarPagos.Text = " Cancelar Pagos";
            this.btnCancelarPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarPagos.UseVisualStyleBackColor = true;
            this.btnCancelarPagos.Click += new System.EventHandler(this.btnCancelarPagos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(253, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 498;
            this.label2.Text = "FECHA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(68, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 497;
            this.label1.Text = "GUÍA";
            // 
            // txtBGuia
            // 
            this.txtBGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBGuia.Location = new System.Drawing.Point(72, 98);
            this.txtBGuia.Margin = new System.Windows.Forms.Padding(4);
            this.txtBGuia.Name = "txtBGuia";
            this.txtBGuia.Size = new System.Drawing.Size(141, 22);
            this.txtBGuia.TabIndex = 495;
            this.txtBGuia.TabStop = false;
            this.txtBGuia.Tag = "";
            this.txtBGuia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBGuia_KeyPress);
            this.txtBGuia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBGuia_KeyUp);
            // 
            // txtBFecha
            // 
            this.txtBFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBFecha.Location = new System.Drawing.Point(257, 98);
            this.txtBFecha.Margin = new System.Windows.Forms.Padding(4);
            this.txtBFecha.Name = "txtBFecha";
            this.txtBFecha.Size = new System.Drawing.Size(164, 22);
            this.txtBFecha.TabIndex = 496;
            this.txtBFecha.Tag = "";
            this.txtBFecha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBFecha_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(461, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 500;
            this.label3.Text = "FACTURA";
            // 
            // txtBFacturas
            // 
            this.txtBFacturas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBFacturas.Location = new System.Drawing.Point(465, 98);
            this.txtBFacturas.Margin = new System.Windows.Forms.Padding(4);
            this.txtBFacturas.Name = "txtBFacturas";
            this.txtBFacturas.Size = new System.Drawing.Size(249, 22);
            this.txtBFacturas.TabIndex = 499;
            this.txtBFacturas.Tag = "";
            this.txtBFacturas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBFacturas_KeyUp);
            // 
            // frmRollbackPagoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 426);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBFacturas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBGuia);
            this.Controls.Add(this.txtBFecha);
            this.Controls.Add(this.btnCancelarPagos);
            this.Controls.Add(this.txtSalir);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.txtCodProveedor);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRollbackPagoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Pagos Realizados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRollbackPagoProveedor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtCodProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnUsd;
        private System.Windows.Forms.RadioButton rbtnCol;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Button txtSalir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCancelarPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBGuia;
        private System.Windows.Forms.TextBox txtBFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRE_PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRE_MONEDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRE_FECHA_REGISTRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRE_MONTO_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBFacturas;
    }
}