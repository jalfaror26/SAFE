namespace PROYECTO
{
    partial class frmConsultaFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFactura));
            this.label2 = new System.Windows.Forms.Label();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.lDAOinea = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.fac_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_CONSECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_RECEPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_COMPROBACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(235, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 162;
            this.label2.Text = "Descripción";
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
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
            this.fac_numero,
            this.fac_estado,
            this.fac_fecha,
            this.fac_nombre,
            this.FE_CONSECUTIVO,
            this.FE_RECEPCION,
            this.FE_COMPROBACION});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(16, 100);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.ShowEditingIcon = false;
            this.dgrDatos.Size = new System.Drawing.Size(1097, 368);
            this.dgrDatos.TabIndex = 2;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellDoubleClick);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            this.dgrDatos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgrDatos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 161;
            this.label1.Text = "Id";
            // 
            // txtBId
            // 
            this.txtBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBId.Location = new System.Drawing.Point(41, 59);
            this.txtBId.Margin = new System.Windows.Forms.Padding(4);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(140, 22);
            this.txtBId.TabIndex = 2;
            this.txtBId.Tag = "P.num_producto";
            this.txtBId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBId_KeyUp);
            // 
            // txtBNombre
            // 
            this.txtBNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBNombre.Location = new System.Drawing.Point(227, 59);
            this.txtBNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(352, 22);
            this.txtBNombre.TabIndex = 1;
            this.txtBNombre.Tag = "M.descripcion";
            this.txtBNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBNombre_KeyUp);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.Location = new System.Drawing.Point(37, 14);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(162, 20);
            this.lblBusqueda.TabIndex = 159;
            this.lblBusqueda.Text = "Búsqueda Rápida ....";
            // 
            // lDAOinea
            // 
            this.lDAOinea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDAOinea.Location = new System.Drawing.Point(239, 31);
            this.lDAOinea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDAOinea.Name = "lDAOinea";
            this.lDAOinea.Size = new System.Drawing.Size(360, 2);
            this.lDAOinea.TabIndex = 160;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(328, 154);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(15, 28);
            this.btnSalir.TabIndex = 436;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "button1";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(439, 154);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(15, 28);
            this.btnAceptar.TabIndex = 437;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "button1";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // fac_numero
            // 
            this.fac_numero.DataPropertyName = "fac_numero";
            this.fac_numero.HeaderText = "Factura";
            this.fac_numero.MinimumWidth = 6;
            this.fac_numero.Name = "fac_numero";
            this.fac_numero.ReadOnly = true;
            this.fac_numero.Width = 70;
            // 
            // fac_estado
            // 
            this.fac_estado.DataPropertyName = "fac_estado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fac_estado.DefaultCellStyle = dataGridViewCellStyle3;
            this.fac_estado.HeaderText = "Estado";
            this.fac_estado.MinimumWidth = 6;
            this.fac_estado.Name = "fac_estado";
            this.fac_estado.ReadOnly = true;
            this.fac_estado.Width = 80;
            // 
            // fac_fecha
            // 
            this.fac_fecha.DataPropertyName = "fac_fecha";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fac_fecha.DefaultCellStyle = dataGridViewCellStyle4;
            this.fac_fecha.HeaderText = "Fecha";
            this.fac_fecha.MinimumWidth = 6;
            this.fac_fecha.Name = "fac_fecha";
            this.fac_fecha.ReadOnly = true;
            this.fac_fecha.Width = 110;
            // 
            // fac_nombre
            // 
            this.fac_nombre.DataPropertyName = "fac_nombre";
            this.fac_nombre.HeaderText = "Nombre";
            this.fac_nombre.MinimumWidth = 6;
            this.fac_nombre.Name = "fac_nombre";
            this.fac_nombre.ReadOnly = true;
            this.fac_nombre.Width = 200;
            // 
            // FE_CONSECUTIVO
            // 
            this.FE_CONSECUTIVO.DataPropertyName = "FE_CONSECUTIVO";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FE_CONSECUTIVO.DefaultCellStyle = dataGridViewCellStyle5;
            this.FE_CONSECUTIVO.HeaderText = "Consecutivo Hacienda";
            this.FE_CONSECUTIVO.MinimumWidth = 6;
            this.FE_CONSECUTIVO.Name = "FE_CONSECUTIVO";
            this.FE_CONSECUTIVO.ReadOnly = true;
            this.FE_CONSECUTIVO.Width = 140;
            // 
            // FE_RECEPCION
            // 
            this.FE_RECEPCION.DataPropertyName = "FE_RECEPCION";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FE_RECEPCION.DefaultCellStyle = dataGridViewCellStyle6;
            this.FE_RECEPCION.HeaderText = "Envío Hacienda";
            this.FE_RECEPCION.MinimumWidth = 6;
            this.FE_RECEPCION.Name = "FE_RECEPCION";
            this.FE_RECEPCION.ReadOnly = true;
            // 
            // FE_COMPROBACION
            // 
            this.FE_COMPROBACION.DataPropertyName = "FE_COMPROBACION";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FE_COMPROBACION.DefaultCellStyle = dataGridViewCellStyle7;
            this.FE_COMPROBACION.HeaderText = "Respuesta Hacienda";
            this.FE_COMPROBACION.MinimumWidth = 6;
            this.FE_COMPROBACION.Name = "FE_COMPROBACION";
            this.FE_COMPROBACION.ReadOnly = true;
            // 
            // frmConsultaFactura
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1126, 487);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBId);
            this.Controls.Add(this.txtBNombre);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.lDAOinea);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsulta_FormClosing);
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label lDAOinea;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_CONSECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_RECEPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_COMPROBACION;
    }
}