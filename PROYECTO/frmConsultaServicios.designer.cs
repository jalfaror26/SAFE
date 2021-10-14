namespace PROYECTO
{
    partial class frmConsultaServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaServicios));
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.INV_COD_ARTICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INV_IVI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INV_IMPUESTO_VENTAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(232, 22);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(609, 22);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INV_COD_ARTICULO,
            this.ART_CODIGO,
            this.ART_NOMBRE,
            this.INV_IVI,
            this.INV_IMPUESTO_VENTAS});
            this.dgrDatos.Location = new System.Drawing.Point(16, 54);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrDatos.RowTemplate.Height = 28;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(827, 384);
            this.dgrDatos.TabIndex = 2;
            this.dgrDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellDoubleClick);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            this.dgrDatos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgrDatos_KeyPress);
            this.dgrDatos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrDatos_KeyUp);
            // 
            // INV_COD_ARTICULO
            // 
            this.INV_COD_ARTICULO.DataPropertyName = "INV_COD_ARTICULO";
            this.INV_COD_ARTICULO.HeaderText = "";
            this.INV_COD_ARTICULO.MinimumWidth = 6;
            this.INV_COD_ARTICULO.Name = "INV_COD_ARTICULO";
            this.INV_COD_ARTICULO.ReadOnly = true;
            this.INV_COD_ARTICULO.Visible = false;
            this.INV_COD_ARTICULO.Width = 50;
            // 
            // ART_CODIGO
            // 
            this.ART_CODIGO.DataPropertyName = "ART_CODIGO";
            this.ART_CODIGO.HeaderText = "CODIGO";
            this.ART_CODIGO.MinimumWidth = 6;
            this.ART_CODIGO.Name = "ART_CODIGO";
            this.ART_CODIGO.ReadOnly = true;
            this.ART_CODIGO.Width = 150;
            // 
            // ART_NOMBRE
            // 
            this.ART_NOMBRE.DataPropertyName = "ART_NOMBRE";
            this.ART_NOMBRE.HeaderText = "Descripción";
            this.ART_NOMBRE.MinimumWidth = 6;
            this.ART_NOMBRE.Name = "ART_NOMBRE";
            this.ART_NOMBRE.ReadOnly = true;
            this.ART_NOMBRE.Width = 400;
            // 
            // INV_IVI
            // 
            this.INV_IVI.DataPropertyName = "INV_IVI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INV_IVI.DefaultCellStyle = dataGridViewCellStyle3;
            this.INV_IVI.HeaderText = "IVI";
            this.INV_IVI.MinimumWidth = 6;
            this.INV_IVI.Name = "INV_IVI";
            this.INV_IVI.ReadOnly = true;
            this.INV_IVI.Width = 50;
            // 
            // INV_IMPUESTO_VENTAS
            // 
            this.INV_IMPUESTO_VENTAS.DataPropertyName = "INV_IMPUESTO_VENTAS";
            this.INV_IMPUESTO_VENTAS.HeaderText = "INV_IMPUESTO_VENTAS";
            this.INV_IMPUESTO_VENTAS.MinimumWidth = 6;
            this.INV_IMPUESTO_VENTAS.Name = "INV_IMPUESTO_VENTAS";
            this.INV_IMPUESTO_VENTAS.ReadOnly = true;
            this.INV_IMPUESTO_VENTAS.Visible = false;
            this.INV_IMPUESTO_VENTAS.Width = 125;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(376, 121);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(15, 28);
            this.btnSalir.TabIndex = 438;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "button1";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(487, 121);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(15, 28);
            this.btnAceptar.TabIndex = 439;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "button1";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(17, 22);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(196, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // frmConsultaServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(863, 449);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de servicios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultaArticulos_FormClosing);
            this.Load += new System.EventHandler(this.frmConsultaArticulos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn INV_COD_ARTICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INV_IVI;
        private System.Windows.Forms.DataGridViewTextBoxColumn INV_IMPUESTO_VENTAS;
    }
}