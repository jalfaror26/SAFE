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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCorreo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMAsignarPermisos = new System.Windows.Forms.Button();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMEliminar = new System.Windows.Forms.Button();
            this.grbRol = new System.Windows.Forms.GroupBox();
            this.rboFuncionario = new System.Windows.Forms.RadioButton();
            this.rboAdministrador = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasenna2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontrasenna = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodUsuario = new System.Windows.Forms.TextBox();
            this.dgrUsuarios = new System.Windows.Forms.DataGridView();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkTodasPantallas = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.btnMSalir2 = new System.Windows.Forms.Button();
            this.dgrPantallas = new System.Windows.Forms.DataGridView();
            this.pan_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pan_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pan_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(874, 558);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCorreo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtApellido2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtApellido1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtIdentificacion);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grbRol);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtContrasenna2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtcontrasenna);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCodUsuario);
            this.tabPage1.Controls.Add(this.dgrUsuarios);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(866, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(283, 219);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(224, 22);
            this.txtCorreo.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(288, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 465;
            this.label6.Text = "Correo electrónico";
            // 
            // txtApellido2
            // 
            this.txtApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido2.Location = new System.Drawing.Point(738, 161);
            this.txtApellido2.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(100, 22);
            this.txtApellido2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(744, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 464;
            this.label5.Text = "2do Apellido ";
            // 
            // txtApellido1
            // 
            this.txtApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido1.Location = new System.Drawing.Point(622, 161);
            this.txtApellido1.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(100, 22);
            this.txtApellido1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 462;
            this.label4.Text = "1er Apellido ";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Location = new System.Drawing.Point(283, 161);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(114, 22);
            this.txtIdentificacion.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(287, 141);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 17);
            this.label17.TabIndex = 458;
            this.label17.Text = "Identificación";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(412, 161);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(418, 141);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 460;
            this.label10.Text = "Nombre Completo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMAsignarPermisos);
            this.groupBox1.Controls.Add(this.btnMNuevo);
            this.groupBox1.Controls.Add(this.btnMSalir);
            this.groupBox1.Controls.Add(this.btnMGuardar);
            this.groupBox1.Controls.Add(this.btnMEliminar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(858, 85);
            this.groupBox1.TabIndex = 457;
            this.groupBox1.TabStop = false;
            // 
            // btnMAsignarPermisos
            // 
            this.btnMAsignarPermisos.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMAsignarPermisos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAsignarPermisos.ImageKey = "C&M 18.ico";
            this.btnMAsignarPermisos.ImageList = this.imgMenu;
            this.btnMAsignarPermisos.Location = new System.Drawing.Point(509, 18);
            this.btnMAsignarPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMAsignarPermisos.Name = "btnMAsignarPermisos";
            this.btnMAsignarPermisos.Size = new System.Drawing.Size(147, 55);
            this.btnMAsignarPermisos.TabIndex = 16;
            this.btnMAsignarPermisos.Text = "&Asig Permisos";
            this.btnMAsignarPermisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAsignarPermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMAsignarPermisos.UseVisualStyleBackColor = true;
            this.btnMAsignarPermisos.Click += new System.EventHandler(this.btnMAsignarPermisos_Click);
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
            this.imgMenu.Images.SetKeyName(5, "C&M 18.ico");
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
            this.btnMSalir.Location = new System.Drawing.Point(674, 18);
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
            // grbRol
            // 
            this.grbRol.Controls.Add(this.rboFuncionario);
            this.grbRol.Controls.Add(this.rboAdministrador);
            this.grbRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbRol.Location = new System.Drawing.Point(529, 200);
            this.grbRol.Margin = new System.Windows.Forms.Padding(4);
            this.grbRol.Name = "grbRol";
            this.grbRol.Padding = new System.Windows.Forms.Padding(4);
            this.grbRol.Size = new System.Drawing.Size(309, 49);
            this.grbRol.TabIndex = 456;
            this.grbRol.TabStop = false;
            this.grbRol.Text = "Rol";
            // 
            // rboFuncionario
            // 
            this.rboFuncionario.AutoSize = true;
            this.rboFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboFuncionario.Location = new System.Drawing.Point(175, 20);
            this.rboFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.rboFuncionario.Name = "rboFuncionario";
            this.rboFuncionario.Size = new System.Drawing.Size(103, 21);
            this.rboFuncionario.TabIndex = 10;
            this.rboFuncionario.Text = "Funcionario";
            this.rboFuncionario.UseVisualStyleBackColor = true;
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
            this.rboAdministrador.TabIndex = 9;
            this.rboAdministrador.TabStop = true;
            this.rboAdministrador.Text = "Administrador";
            this.rboAdministrador.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmación de Contraseña";
            // 
            // txtContrasenna2
            // 
            this.txtContrasenna2.Location = new System.Drawing.Point(28, 243);
            this.txtContrasenna2.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasenna2.Name = "txtContrasenna2";
            this.txtContrasenna2.PasswordChar = '*';
            this.txtContrasenna2.Size = new System.Drawing.Size(213, 22);
            this.txtContrasenna2.TabIndex = 3;
            this.txtContrasenna2.Leave += new System.EventHandler(this.txtContrasenna2_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // txtcontrasenna
            // 
            this.txtcontrasenna.Location = new System.Drawing.Point(28, 186);
            this.txtcontrasenna.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontrasenna.Name = "txtcontrasenna";
            this.txtcontrasenna.PasswordChar = '*';
            this.txtcontrasenna.Size = new System.Drawing.Size(213, 22);
            this.txtcontrasenna.TabIndex = 2;
            this.txtcontrasenna.Leave += new System.EventHandler(this.txtcontrasenna_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.Location = new System.Drawing.Point(28, 128);
            this.txtCodUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Size = new System.Drawing.Size(213, 22);
            this.txtCodUsuario.TabIndex = 1;
            // 
            // dgrUsuarios
            // 
            this.dgrUsuarios.AllowUserToAddRows = false;
            this.dgrUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgrUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuario,
            this.nombre,
            this.apellido1,
            this.Apellido2,
            this.rol,
            this.cedula,
            this.email});
            this.dgrUsuarios.Location = new System.Drawing.Point(28, 296);
            this.dgrUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgrUsuarios.MultiSelect = false;
            this.dgrUsuarios.Name = "dgrUsuarios";
            this.dgrUsuarios.RowHeadersVisible = false;
            this.dgrUsuarios.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgrUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrUsuarios.Size = new System.Drawing.Size(810, 213);
            this.dgrUsuarios.TabIndex = 0;
            this.dgrUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrUsuarios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrUsuarios.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "Usuario";
            this.usuario.MinimumWidth = 6;
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Width = 125;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // apellido1
            // 
            this.apellido1.DataPropertyName = "apellido1";
            this.apellido1.HeaderText = "1er Apellido";
            this.apellido1.MinimumWidth = 6;
            this.apellido1.Name = "apellido1";
            this.apellido1.ReadOnly = true;
            this.apellido1.Width = 125;
            // 
            // Apellido2
            // 
            this.Apellido2.DataPropertyName = "Apellido2";
            this.Apellido2.HeaderText = "2do Apellido";
            this.Apellido2.MinimumWidth = 6;
            this.Apellido2.Name = "Apellido2";
            this.Apellido2.ReadOnly = true;
            this.Apellido2.Width = 125;
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
            // cedula
            // 
            this.cedula.DataPropertyName = "cedula";
            this.cedula.HeaderText = "Cedula";
            this.cedula.MinimumWidth = 6;
            this.cedula.Name = "cedula";
            this.cedula.ReadOnly = true;
            this.cedula.Visible = false;
            this.cedula.Width = 125;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Visible = false;
            this.email.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkTodasPantallas);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgrPantallas);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(866, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Permisos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkTodasPantallas
            // 
            this.chkTodasPantallas.AutoSize = true;
            this.chkTodasPantallas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodasPantallas.Location = new System.Drawing.Point(688, 59);
            this.chkTodasPantallas.Margin = new System.Windows.Forms.Padding(4);
            this.chkTodasPantallas.Name = "chkTodasPantallas";
            this.chkTodasPantallas.Size = new System.Drawing.Size(165, 21);
            this.chkTodasPantallas.TabIndex = 450;
            this.chkTodasPantallas.Text = "Seleccionar Todos";
            this.chkTodasPantallas.UseVisualStyleBackColor = true;
            this.chkTodasPantallas.CheckedChanged += new System.EventHandler(this.chkTodasPantallas_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardarPermisos);
            this.groupBox2.Controls.Add(this.btnMSalir2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(858, 85);
            this.groupBox2.TabIndex = 458;
            this.groupBox2.TabStop = false;
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPermisos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarPermisos.ImageKey = "Disc 01.ico";
            this.btnGuardarPermisos.ImageList = this.imgMenu;
            this.btnGuardarPermisos.Location = new System.Drawing.Point(12, 18);
            this.btnGuardarPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(147, 55);
            this.btnGuardarPermisos.TabIndex = 13;
            this.btnGuardarPermisos.Text = "Guardar";
            this.btnGuardarPermisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarPermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // btnMSalir2
            // 
            this.btnMSalir2.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSalir2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir2.ImageKey = "salir2.ico";
            this.btnMSalir2.ImageList = this.imgMenu;
            this.btnMSalir2.Location = new System.Drawing.Point(179, 18);
            this.btnMSalir2.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSalir2.Name = "btnMSalir2";
            this.btnMSalir2.Size = new System.Drawing.Size(147, 55);
            this.btnMSalir2.TabIndex = 15;
            this.btnMSalir2.Text = "Salir";
            this.btnMSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMSalir2.UseVisualStyleBackColor = true;
            this.btnMSalir2.Click += new System.EventHandler(this.btnMSalir_Click);
            // 
            // dgrPantallas
            // 
            this.dgrPantallas.AllowUserToAddRows = false;
            this.dgrPantallas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrPantallas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrPantallas.BackgroundColor = System.Drawing.Color.White;
            this.dgrPantallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPantallas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pan_nombre,
            this.pan_modulo,
            this.acceso,
            this.pan_id});
            this.dgrPantallas.Location = new System.Drawing.Point(25, 108);
            this.dgrPantallas.Margin = new System.Windows.Forms.Padding(4);
            this.dgrPantallas.MultiSelect = false;
            this.dgrPantallas.Name = "dgrPantallas";
            this.dgrPantallas.RowHeadersVisible = false;
            this.dgrPantallas.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrPantallas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrPantallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrPantallas.Size = new System.Drawing.Size(811, 394);
            this.dgrPantallas.TabIndex = 0;
            // 
            // pan_nombre
            // 
            this.pan_nombre.DataPropertyName = "pan_nombre";
            this.pan_nombre.HeaderText = "Descripción";
            this.pan_nombre.MinimumWidth = 6;
            this.pan_nombre.Name = "pan_nombre";
            this.pan_nombre.ReadOnly = true;
            this.pan_nombre.Width = 300;
            // 
            // pan_modulo
            // 
            this.pan_modulo.DataPropertyName = "pan_modulo";
            this.pan_modulo.HeaderText = "Módulo";
            this.pan_modulo.MinimumWidth = 6;
            this.pan_modulo.Name = "pan_modulo";
            this.pan_modulo.ReadOnly = true;
            this.pan_modulo.Width = 180;
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
            this.acceso.Width = 125;
            // 
            // pan_id
            // 
            this.pan_id.DataPropertyName = "pan_id";
            this.pan_id.HeaderText = "Código";
            this.pan_id.MinimumWidth = 6;
            this.pan_id.Name = "pan_id";
            this.pan_id.ReadOnly = true;
            this.pan_id.Visible = false;
            this.pan_id.Width = 6;
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
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 557);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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
            this.groupBox1.ResumeLayout(false);
            this.grbRol.ResumeLayout(false);
            this.grbRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtCodUsuario;
        private System.Windows.Forms.DataGridView dgrUsuarios;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgrPantallas;
        private System.Windows.Forms.CheckBox chkTodasPantallas;
        private System.Windows.Forms.GroupBox grbRol;
        private System.Windows.Forms.RadioButton rboFuncionario;
        private System.Windows.Forms.RadioButton rboAdministrador;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMEliminar;
        private System.Windows.Forms.Button btnMAsignarPermisos;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtCorreo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.Button btnMSalir2;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_modulo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn acceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn pan_id;
    }
}