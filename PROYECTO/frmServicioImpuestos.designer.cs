namespace PROYECTO
{
    partial class frmServicioImpuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicioImpuestos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbImpuestos = new System.Windows.Forms.ComboBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.txtDesBreveSer = new System.Windows.Forms.TextBox();
            this.txtCodigoSer = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMEliminar = new System.Windows.Forms.Button();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imp_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(7, "C&M 17.ico");
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDatos.ColumnHeadersHeight = 25;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clave,
            this.imp_descripcion});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(21, 271);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            this.dgrDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrDatos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(629, 201);
            this.dgrDatos.TabIndex = 10;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            this.dgrDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgrDatos_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbImpuestos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 188);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(637, 66);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impuestos";
            // 
            // cmbImpuestos
            // 
            this.cmbImpuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImpuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImpuestos.FormattingEnabled = true;
            this.cmbImpuestos.Location = new System.Drawing.Point(33, 27);
            this.cmbImpuestos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbImpuestos.Name = "cmbImpuestos";
            this.cmbImpuestos.Size = new System.Drawing.Size(573, 25);
            this.cmbImpuestos.TabIndex = 12;
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
            this.imageList2.Images.SetKeyName(7, "services.ico");
            this.imageList2.Images.SetKeyName(8, "Sign 12.ico");
            this.imageList2.Images.SetKeyName(9, "C&M 07.ico");
            this.imageList2.Images.SetKeyName(10, "dinero.png");
            this.imageList2.Images.SetKeyName(11, "file_find.ico");
            this.imageList2.Images.SetKeyName(12, "lineasProducto.png");
            // 
            // txtDesBreveSer
            // 
            this.txtDesBreveSer.BackColor = System.Drawing.Color.Beige;
            this.txtDesBreveSer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesBreveSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesBreveSer.ForeColor = System.Drawing.Color.Black;
            this.txtDesBreveSer.Location = new System.Drawing.Point(169, 122);
            this.txtDesBreveSer.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesBreveSer.Multiline = true;
            this.txtDesBreveSer.Name = "txtDesBreveSer";
            this.txtDesBreveSer.ReadOnly = true;
            this.txtDesBreveSer.Size = new System.Drawing.Size(484, 57);
            this.txtDesBreveSer.TabIndex = 18;
            // 
            // txtCodigoSer
            // 
            this.txtCodigoSer.BackColor = System.Drawing.Color.Beige;
            this.txtCodigoSer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoSer.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoSer.Location = new System.Drawing.Point(17, 122);
            this.txtCodigoSer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoSer.Name = "txtCodigoSer";
            this.txtCodigoSer.ReadOnly = true;
            this.txtCodigoSer.Size = new System.Drawing.Size(140, 23);
            this.txtCodigoSer.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(172, 102);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 17);
            this.label14.TabIndex = 16;
            this.label14.Text = "Descripción";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 102);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Código";
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "document.ico");
            this.imgMenu.Images.SetKeyName(1, "Disc 01.ico");
            this.imgMenu.Images.SetKeyName(2, "Sign 06.ico");
            this.imgMenu.Images.SetKeyName(3, "salir2.ico");
            this.imgMenu.Images.SetKeyName(4, "App 17.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMNuevo);
            this.groupBox1.Controls.Add(this.btnMSalir);
            this.groupBox1.Controls.Add(this.btnMGuardar);
            this.groupBox1.Controls.Add(this.btnMEliminar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(673, 85);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnMNuevo
            // 
            this.btnMNuevo.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMNuevo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMNuevo.ImageKey = "document.ico";
            this.btnMNuevo.ImageList = this.imgMenu;
            this.btnMNuevo.Location = new System.Drawing.Point(12, 18);
            this.btnMNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnMNuevo.Name = "btnMNuevo";
            this.btnMNuevo.Size = new System.Drawing.Size(147, 55);
            this.btnMNuevo.TabIndex = 12;
            this.btnMNuevo.Text = "Nuevo";
            this.btnMNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMNuevo.UseVisualStyleBackColor = true;
            this.btnMNuevo.Click += new System.EventHandler(this.btnMNuevo_Click);
            // 
            // btnMSalir
            // 
            this.btnMSalir.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSalir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir.ImageKey = "salir2.ico";
            this.btnMSalir.ImageList = this.imgMenu;
            this.btnMSalir.Location = new System.Drawing.Point(508, 18);
            this.btnMSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSalir.Name = "btnMSalir";
            this.btnMSalir.Size = new System.Drawing.Size(147, 55);
            this.btnMSalir.TabIndex = 15;
            this.btnMSalir.Text = "Salir";
            this.btnMSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMSalir.UseVisualStyleBackColor = true;
            this.btnMSalir.Click += new System.EventHandler(this.btnMSalir_Click);
            // 
            // btnMGuardar
            // 
            this.btnMGuardar.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMGuardar.ImageKey = "Disc 01.ico";
            this.btnMGuardar.ImageList = this.imgMenu;
            this.btnMGuardar.Location = new System.Drawing.Point(179, 18);
            this.btnMGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMGuardar.Name = "btnMGuardar";
            this.btnMGuardar.Size = new System.Drawing.Size(147, 55);
            this.btnMGuardar.TabIndex = 13;
            this.btnMGuardar.Text = "Guardar";
            this.btnMGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMGuardar.UseVisualStyleBackColor = true;
            this.btnMGuardar.Click += new System.EventHandler(this.btnMGuardar_Click);
            // 
            // btnMEliminar
            // 
            this.btnMEliminar.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMEliminar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMEliminar.ImageKey = "Sign 06.ico";
            this.btnMEliminar.ImageList = this.imgMenu;
            this.btnMEliminar.Location = new System.Drawing.Point(344, 18);
            this.btnMEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMEliminar.Name = "btnMEliminar";
            this.btnMEliminar.Size = new System.Drawing.Size(147, 55);
            this.btnMEliminar.TabIndex = 14;
            this.btnMEliminar.Text = "Eliminar";
            this.btnMEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMEliminar.UseVisualStyleBackColor = true;
            this.btnMEliminar.Click += new System.EventHandler(this.btnMEliminar_Click);
            // 
            // clave
            // 
            this.clave.DataPropertyName = "clave";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clave.DefaultCellStyle = dataGridViewCellStyle3;
            this.clave.HeaderText = "Clave";
            this.clave.MinimumWidth = 6;
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            // 
            // imp_descripcion
            // 
            this.imp_descripcion.DataPropertyName = "descripcion";
            this.imp_descripcion.HeaderText = "Descripción";
            this.imp_descripcion.MinimumWidth = 6;
            this.imp_descripcion.Name = "imp_descripcion";
            this.imp_descripcion.ReadOnly = true;
            this.imp_descripcion.Width = 350;
            // 
            // frmServicioImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDesBreveSer);
            this.Controls.Add(this.txtCodigoSer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgrDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServicioImpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos de los Servicios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticuloPresentacion_FormClosing);
            this.Load += new System.EventHandler(this.frmArticuloPresentacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmServicioImpuestos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbImpuestos;
        private System.Windows.Forms.TextBox txtDesBreveSer;
        private System.Windows.Forms.TextBox txtCodigoSer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMEliminar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn imp_descripcion;
    }
}