namespace PROYECTO
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rboVendedor = new System.Windows.Forms.RadioButton();
            this.rboAdministrador = new System.Windows.Forms.RadioButton();
            this.btnAsignarPermisos = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasenna2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontrasenna = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreusuario = new System.Windows.Forms.TextBox();
            this.dgrUsuarios = new System.Windows.Forms.DataGridView();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkTodasPantallas = new System.Windows.Forms.CheckBox();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.dgrPantallas = new System.Windows.Forms.DataGridView();
            this.pan_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pan_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pan_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPantallas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 444);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnAsignarPermisos);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtContrasenna2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtcontrasenna);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNombreusuario);
            this.tabPage1.Controls.Add(this.dgrUsuarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(740, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rboVendedor);
            this.groupBox2.Controls.Add(this.rboAdministrador);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 191);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(309, 49);
            this.groupBox2.TabIndex = 456;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rol";
            // 
            // rboVendedor
            // 
            this.rboVendedor.AutoSize = true;
            this.rboVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboVendedor.Location = new System.Drawing.Point(175, 20);
            this.rboVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.rboVendedor.Name = "rboVendedor";
            this.rboVendedor.Size = new System.Drawing.Size(91, 21);
            this.rboVendedor.TabIndex = 1;
            this.rboVendedor.Text = "Vendedor";
            this.rboVendedor.UseVisualStyleBackColor = true;
            // 
            // rboAdministrador
            // 
            this.rboAdministrador.AutoSize = true;
            this.rboAdministrador.Checked = true;
            this.rboAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAdministrador.Location = new System.Drawing.Point(31, 20);
            this.rboAdministrador.Margin = new System.Windows.Forms.Padding(4);
            this.rboAdministrador.Name = "rboAdministrador";
            this.rboAdministrador.Size = new System.Drawing.Size(116, 21);
            this.rboAdministrador.TabIndex = 0;
            this.rboAdministrador.TabStop = true;
            this.rboAdministrador.Text = "Administrador";
            this.rboAdministrador.UseVisualStyleBackColor = true;
            // 
            // btnAsignarPermisos
            // 
            this.btnAsignarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarPermisos.ImageIndex = 4;
            this.btnAsignarPermisos.ImageList = this.imageList1;
            this.btnAsignarPermisos.Location = new System.Drawing.Point(169, 316);
            this.btnAsignarPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsignarPermisos.Name = "btnAsignarPermisos";
            this.btnAsignarPermisos.Size = new System.Drawing.Size(149, 37);
            this.btnAsignarPermisos.TabIndex = 451;
            this.btnAsignarPermisos.TabStop = false;
            this.btnAsignarPermisos.Text = "&Asig Permisos";
            this.btnAsignarPermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarPermisos.UseVisualStyleBackColor = true;
            this.btnAsignarPermisos.Click += new System.EventHandler(this.btnAsignarPermisos_Click);
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
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.ImageIndex = 2;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(169, 265);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 37);
            this.btnGuardar.TabIndex = 447;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.ImageIndex = 3;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(12, 316);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 37);
            this.btnEliminar.TabIndex = 449;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.ImageIndex = 0;
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(12, 265);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(149, 37);
            this.btnNuevo.TabIndex = 448;
            this.btnNuevo.TabStop = false;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmación de Contraseña";
            // 
            // txtContrasenna2
            // 
            this.txtContrasenna2.Location = new System.Drawing.Point(8, 159);
            this.txtContrasenna2.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasenna2.Name = "txtContrasenna2";
            this.txtContrasenna2.PasswordChar = '*';
            this.txtContrasenna2.Size = new System.Drawing.Size(308, 22);
            this.txtContrasenna2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // txtcontrasenna
            // 
            this.txtcontrasenna.Location = new System.Drawing.Point(8, 102);
            this.txtcontrasenna.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontrasenna.Name = "txtcontrasenna";
            this.txtcontrasenna.PasswordChar = '*';
            this.txtcontrasenna.Size = new System.Drawing.Size(308, 22);
            this.txtcontrasenna.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de Usuario";
            // 
            // txtNombreusuario
            // 
            this.txtNombreusuario.Location = new System.Drawing.Point(8, 44);
            this.txtNombreusuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreusuario.Name = "txtNombreusuario";
            this.txtNombreusuario.Size = new System.Drawing.Size(308, 22);
            this.txtNombreusuario.TabIndex = 1;
            // 
            // dgrUsuarios
            // 
            this.dgrUsuarios.AllowUserToAddRows = false;
            this.dgrUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgrUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuario,
            this.rol});
            this.dgrUsuarios.Location = new System.Drawing.Point(357, 25);
            this.dgrUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgrUsuarios.MultiSelect = false;
            this.dgrUsuarios.Name = "dgrUsuarios";
            this.dgrUsuarios.RowHeadersVisible = false;
            this.dgrUsuarios.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrUsuarios.Size = new System.Drawing.Size(347, 325);
            this.dgrUsuarios.TabIndex = 0;
            this.dgrUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrUsuarios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrUsuarios.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "Nombre de Usuario";
            this.usuario.MinimumWidth = 6;
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 135;
            // 
            // rol
            // 
            this.rol.DataPropertyName = "rol";
            this.rol.HeaderText = "Rol";
            this.rol.MinimumWidth = 6;
            this.rol.Name = "rol";
            this.rol.ReadOnly = true;
            this.rol.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkTodasPantallas);
            this.tabPage2.Controls.Add(this.btnGuardarPermisos);
            this.tabPage2.Controls.Add(this.dgrPantallas);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(740, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Permisos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkTodasPantallas
            // 
            this.chkTodasPantallas.AutoSize = true;
            this.chkTodasPantallas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodasPantallas.Location = new System.Drawing.Point(300, 367);
            this.chkTodasPantallas.Margin = new System.Windows.Forms.Padding(4);
            this.chkTodasPantallas.Name = "chkTodasPantallas";
            this.chkTodasPantallas.Size = new System.Drawing.Size(165, 21);
            this.chkTodasPantallas.TabIndex = 450;
            this.chkTodasPantallas.Text = "Seleccionar Todos";
            this.chkTodasPantallas.UseVisualStyleBackColor = true;
            this.chkTodasPantallas.CheckedChanged += new System.EventHandler(this.chkTodasPantallas_CheckedChanged);
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarPermisos.ImageIndex = 4;
            this.btnGuardarPermisos.ImageList = this.imageList1;
            this.btnGuardarPermisos.Location = new System.Drawing.Point(503, 357);
            this.btnGuardarPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(177, 37);
            this.btnGuardarPermisos.TabIndex = 449;
            this.btnGuardarPermisos.TabStop = false;
            this.btnGuardarPermisos.Text = "Guardar Cambios";
            this.btnGuardarPermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // dgrPantallas
            // 
            this.dgrPantallas.AllowUserToAddRows = false;
            this.dgrPantallas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrPantallas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrPantallas.BackgroundColor = System.Drawing.Color.White;
            this.dgrPantallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPantallas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pan_id,
            this.pan_nombre,
            this.pan_modulo,
            this.acceso});
            this.dgrPantallas.Location = new System.Drawing.Point(25, 18);
            this.dgrPantallas.Margin = new System.Windows.Forms.Padding(4);
            this.dgrPantallas.MultiSelect = false;
            this.dgrPantallas.Name = "dgrPantallas";
            this.dgrPantallas.RowHeadersVisible = false;
            this.dgrPantallas.RowHeadersWidth = 51;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrPantallas.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrPantallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrPantallas.Size = new System.Drawing.Size(685, 322);
            this.dgrPantallas.TabIndex = 0;
            this.dgrPantallas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrPantallas_DataBindingComplete);
            // 
            // pan_id
            // 
            this.pan_id.DataPropertyName = "pan_id";
            this.pan_id.HeaderText = "Código";
            this.pan_id.MinimumWidth = 6;
            this.pan_id.Name = "pan_id";
            this.pan_id.ReadOnly = true;
            this.pan_id.Width = 90;
            // 
            // pan_nombre
            // 
            this.pan_nombre.DataPropertyName = "pan_nombre";
            this.pan_nombre.HeaderText = "Descripción";
            this.pan_nombre.MinimumWidth = 6;
            this.pan_nombre.Name = "pan_nombre";
            this.pan_nombre.ReadOnly = true;
            this.pan_nombre.Width = 220;
            // 
            // pan_modulo
            // 
            this.pan_modulo.DataPropertyName = "pan_modulo";
            this.pan_modulo.HeaderText = "Módulo";
            this.pan_modulo.MinimumWidth = 6;
            this.pan_modulo.Name = "pan_modulo";
            this.pan_modulo.ReadOnly = true;
            this.pan_modulo.Width = 130;
            // 
            // acceso
            // 
            this.acceso.DataPropertyName = "acceso";
            this.acceso.FalseValue = "0";
            this.acceso.HeaderText = "Acceso";
            this.acceso.MinimumWidth = 6;
            this.acceso.Name = "acceso";
            this.acceso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.acceso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.acceso.TrueValue = "1";
            this.acceso.Width = 50;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 436);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Permisos a Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPermisos_FormClosing);
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPantallas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContrasenna2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcontrasenna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreusuario;
        private System.Windows.Forms.DataGridView dgrUsuarios;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAsignarPermisos;
        private System.Windows.Forms.DataGridView dgrPantallas;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_modulo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn acceso;
        private System.Windows.Forms.CheckBox chkTodasPantallas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rboVendedor;
        private System.Windows.Forms.RadioButton rboAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn rol;
    }
}