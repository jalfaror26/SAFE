namespace PROYECTO
{
    partial class frmConsultaCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaCliente));
            this.label2 = new System.Windows.Forms.Label();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.lDAOinea = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBCedula = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cli_cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dato1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dato2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dato3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(327, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 162;
            this.label2.Text = "Nombre";
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
            this.Id,
            this.cli_cedula,
            this.descripcion,
            this.dato1,
            this.dato2,
            this.dato3});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(16, 100);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.ShowEditingIcon = false;
            this.dgrDatos.Size = new System.Drawing.Size(717, 331);
            this.dgrDatos.TabIndex = 2;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellContentClick);
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
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 161;
            this.label1.Text = "Id";
            // 
            // txtBId
            // 
            this.txtBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBId.Location = new System.Drawing.Point(23, 59);
            this.txtBId.Margin = new System.Windows.Forms.Padding(4);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(84, 22);
            this.txtBId.TabIndex = 3;
            this.txtBId.Tag = "";
            this.txtBId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBId_KeyUp);
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
            this.lblBusqueda.Text = "B?squeda R?pida ....";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(124, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 439;
            this.label3.Text = "C?dula";
            // 
            // txtBCedula
            // 
            this.txtBCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBCedula.Location = new System.Drawing.Point(120, 59);
            this.txtBCedula.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCedula.Name = "txtBCedula";
            this.txtBCedula.Size = new System.Drawing.Size(180, 22);
            this.txtBCedula.TabIndex = 1;
            this.txtBCedula.Tag = "";
            this.txtBCedula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBCedula_KeyUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document.ico");
            this.imageList1.Images.SetKeyName(1, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(2, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(3, "services.ico");
            this.imageList1.Images.SetKeyName(4, "Aceptar.ico");
            this.imageList1.Images.SetKeyName(5, "file_find.ico");
            this.imageList1.Images.SetKeyName(6, "Write 01.ico");
            this.imageList1.Images.SetKeyName(7, "cruz_roja.png");
            this.imageList1.Images.SetKeyName(8, "App 23.ico");
            this.imageList1.Images.SetKeyName(9, "Salir 2.ico");
            this.imageList1.Images.SetKeyName(10, "Facturadora.png");
            this.imageList1.Images.SetKeyName(11, "file_search.png");
            this.imageList1.Images.SetKeyName(12, "Sign 04.ico");
            // 
            // txtBNombre
            // 
            this.txtBNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBNombre.Location = new System.Drawing.Point(319, 59);
            this.txtBNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(343, 22);
            this.txtBNombre.TabIndex = 2;
            this.txtBNombre.Tag = "";
            this.txtBNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBNombre_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "cod";
            this.Id.HeaderText = "";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 70;
            // 
            // cli_cedula
            // 
            this.cli_cedula.DataPropertyName = "cli_cedula";
            this.cli_cedula.HeaderText = "C?dula";
            this.cli_cedula.MinimumWidth = 6;
            this.cli_cedula.Name = "cli_cedula";
            this.cli_cedula.ReadOnly = true;
            this.cli_cedula.Width = 120;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Nombre";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 330;
            // 
            // dato1
            // 
            this.dato1.DataPropertyName = "dato1";
            this.dato1.HeaderText = "dato1";
            this.dato1.MinimumWidth = 6;
            this.dato1.Name = "dato1";
            this.dato1.ReadOnly = true;
            this.dato1.Visible = false;
            this.dato1.Width = 125;
            // 
            // dato2
            // 
            this.dato2.DataPropertyName = "dato2";
            this.dato2.HeaderText = "dato2";
            this.dato2.MinimumWidth = 6;
            this.dato2.Name = "dato2";
            this.dato2.ReadOnly = true;
            this.dato2.Visible = false;
            this.dato2.Width = 125;
            // 
            // dato3
            // 
            this.dato3.DataPropertyName = "dato3";
            this.dato3.HeaderText = "dato3";
            this.dato3.MinimumWidth = 6;
            this.dato3.Name = "dato3";
            this.dato3.ReadOnly = true;
            this.dato3.Visible = false;
            this.dato3.Width = 125;
            // 
            // frmConsultaCliente
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(752, 444);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBCedula);
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
            this.Name = "frmConsultaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultaCliente_FormClosing);
            this.Load += new System.EventHandler(this.frmConsultaCliente_Load);
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
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label lDAOinea;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_IDENTIFICACION;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBCedula;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cli_cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dato1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dato2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dato3;
    }
}