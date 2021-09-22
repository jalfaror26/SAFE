namespace PROYECTO
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.label2 = new System.Windows.Forms.Label();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.cli_identificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLI_DIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Tipo_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLI_LC_MONEDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLI_LC_LIMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.MaskedTextBox();
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboLCMoneda = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLCLimite = new System.Windows.Forms.TextBox();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(228, 354);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nombre";
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            this.dgrDatos.AllowUserToResizeColumns = false;
            this.dgrDatos.AllowUserToResizeRows = false;
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
            this.cli_identificacion,
            this.Cli_Id,
            this.CLI_DIAS,
            this.Cli_Linea,
            this.Cli_Tipo_ID,
            this.Cli_Nombre,
            this.Cli_Telefono,
            this.Cli_Fax,
            this.Cli_Contacto,
            this.Cli_Correo,
            this.Cli_Ubicacion,
            this.Cli_Credito,
            this.CLI_LC_MONEDA,
            this.CLI_LC_LIMITE});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(13, 412);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dgrDatos.Size = new System.Drawing.Size(800, 229);
            this.dgrDatos.TabIndex = 40;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // cli_identificacion
            // 
            this.cli_identificacion.DataPropertyName = "cli_identificacion";
            this.cli_identificacion.HeaderText = "IDENTIFICACION";
            this.cli_identificacion.MinimumWidth = 6;
            this.cli_identificacion.Name = "cli_identificacion";
            this.cli_identificacion.ReadOnly = true;
            this.cli_identificacion.Width = 140;
            // 
            // Cli_Id
            // 
            this.Cli_Id.DataPropertyName = "Cli_Id";
            this.Cli_Id.HeaderText = "Cli_Id";
            this.Cli_Id.MinimumWidth = 6;
            this.Cli_Id.Name = "Cli_Id";
            this.Cli_Id.ReadOnly = true;
            this.Cli_Id.Visible = false;
            this.Cli_Id.Width = 140;
            // 
            // CLI_DIAS
            // 
            this.CLI_DIAS.DataPropertyName = "CLI_DIAS";
            this.CLI_DIAS.HeaderText = "Dias";
            this.CLI_DIAS.MinimumWidth = 6;
            this.CLI_DIAS.Name = "CLI_DIAS";
            this.CLI_DIAS.ReadOnly = true;
            this.CLI_DIAS.Visible = false;
            this.CLI_DIAS.Width = 125;
            // 
            // Cli_Linea
            // 
            this.Cli_Linea.DataPropertyName = "Cli_Linea";
            this.Cli_Linea.HeaderText = "Línea";
            this.Cli_Linea.MinimumWidth = 6;
            this.Cli_Linea.Name = "Cli_Linea";
            this.Cli_Linea.ReadOnly = true;
            this.Cli_Linea.Visible = false;
            this.Cli_Linea.Width = 125;
            // 
            // Cli_Tipo_ID
            // 
            this.Cli_Tipo_ID.DataPropertyName = "Cli_Tipo_ID";
            this.Cli_Tipo_ID.HeaderText = "TipoId";
            this.Cli_Tipo_ID.MinimumWidth = 6;
            this.Cli_Tipo_ID.Name = "Cli_Tipo_ID";
            this.Cli_Tipo_ID.ReadOnly = true;
            this.Cli_Tipo_ID.Visible = false;
            this.Cli_Tipo_ID.Width = 125;
            // 
            // Cli_Nombre
            // 
            this.Cli_Nombre.DataPropertyName = "Cli_Nombre";
            this.Cli_Nombre.HeaderText = "NOMBRE";
            this.Cli_Nombre.MinimumWidth = 6;
            this.Cli_Nombre.Name = "Cli_Nombre";
            this.Cli_Nombre.ReadOnly = true;
            this.Cli_Nombre.Width = 440;
            // 
            // Cli_Telefono
            // 
            this.Cli_Telefono.DataPropertyName = "Cli_Telefono";
            this.Cli_Telefono.HeaderText = "Teléfono";
            this.Cli_Telefono.MinimumWidth = 6;
            this.Cli_Telefono.Name = "Cli_Telefono";
            this.Cli_Telefono.ReadOnly = true;
            this.Cli_Telefono.Visible = false;
            this.Cli_Telefono.Width = 75;
            // 
            // Cli_Fax
            // 
            this.Cli_Fax.DataPropertyName = "Cli_Fax";
            this.Cli_Fax.HeaderText = "Fax";
            this.Cli_Fax.MinimumWidth = 6;
            this.Cli_Fax.Name = "Cli_Fax";
            this.Cli_Fax.ReadOnly = true;
            this.Cli_Fax.Visible = false;
            this.Cli_Fax.Width = 125;
            // 
            // Cli_Contacto
            // 
            this.Cli_Contacto.DataPropertyName = "Cli_Contacto";
            this.Cli_Contacto.HeaderText = "Contacto";
            this.Cli_Contacto.MinimumWidth = 6;
            this.Cli_Contacto.Name = "Cli_Contacto";
            this.Cli_Contacto.ReadOnly = true;
            this.Cli_Contacto.Visible = false;
            this.Cli_Contacto.Width = 125;
            // 
            // Cli_Correo
            // 
            this.Cli_Correo.DataPropertyName = "Cli_Correo";
            this.Cli_Correo.HeaderText = "Correo";
            this.Cli_Correo.MinimumWidth = 6;
            this.Cli_Correo.Name = "Cli_Correo";
            this.Cli_Correo.ReadOnly = true;
            this.Cli_Correo.Visible = false;
            this.Cli_Correo.Width = 125;
            // 
            // Cli_Ubicacion
            // 
            this.Cli_Ubicacion.DataPropertyName = "Cli_Ubicacion";
            this.Cli_Ubicacion.HeaderText = "Ubicacion";
            this.Cli_Ubicacion.MinimumWidth = 6;
            this.Cli_Ubicacion.Name = "Cli_Ubicacion";
            this.Cli_Ubicacion.ReadOnly = true;
            this.Cli_Ubicacion.Visible = false;
            this.Cli_Ubicacion.Width = 125;
            // 
            // Cli_Credito
            // 
            this.Cli_Credito.DataPropertyName = "Cli_Credito";
            this.Cli_Credito.HeaderText = "Credito";
            this.Cli_Credito.MinimumWidth = 6;
            this.Cli_Credito.Name = "Cli_Credito";
            this.Cli_Credito.ReadOnly = true;
            this.Cli_Credito.Visible = false;
            this.Cli_Credito.Width = 125;
            // 
            // CLI_LC_MONEDA
            // 
            this.CLI_LC_MONEDA.DataPropertyName = "CLI_LC_MONEDA";
            this.CLI_LC_MONEDA.HeaderText = "CLI_LC_MONEDA";
            this.CLI_LC_MONEDA.MinimumWidth = 6;
            this.CLI_LC_MONEDA.Name = "CLI_LC_MONEDA";
            this.CLI_LC_MONEDA.ReadOnly = true;
            this.CLI_LC_MONEDA.Visible = false;
            this.CLI_LC_MONEDA.Width = 125;
            // 
            // CLI_LC_LIMITE
            // 
            this.CLI_LC_LIMITE.DataPropertyName = "CLI_LC_LIMITE";
            this.CLI_LC_LIMITE.HeaderText = "CLI_LC_LIMITE";
            this.CLI_LC_LIMITE.MinimumWidth = 6;
            this.CLI_LC_LIMITE.Name = "CLI_LC_LIMITE";
            this.CLI_LC_LIMITE.ReadOnly = true;
            this.CLI_LC_LIMITE.Visible = false;
            this.CLI_LC_LIMITE.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(28, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Identificación";
            // 
            // txtBId
            // 
            this.txtBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBId.Location = new System.Drawing.Point(28, 374);
            this.txtBId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(172, 22);
            this.txtBId.TabIndex = 37;
            this.txtBId.TabStop = false;
            this.txtBId.Tag = "P.num_producto";
            this.txtBId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBId_KeyUp);
            // 
            // txtBNombre
            // 
            this.txtBNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBNombre.Location = new System.Drawing.Point(213, 374);
            this.txtBNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(581, 22);
            this.txtBNombre.TabIndex = 39;
            this.txtBNombre.TabStop = false;
            this.txtBNombre.Tag = "M.descripcion";
            this.txtBNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBNombre_KeyUp);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(16, 326);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(162, 20);
            this.lblBusqueda.TabIndex = 35;
            this.lblBusqueda.Text = "Búsqueda Rápida ....";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 271);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Correo electrónico";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tipo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(311, 96);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 150);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Teléfono";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(153, 150);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 9;
            this.label12.Text = "Fax";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 272);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Contacto";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(305, 116);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(491, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // txtContacto
            // 
            this.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContacto.Location = new System.Drawing.Point(16, 290);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(233, 22);
            this.txtContacto.TabIndex = 24;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(16, 170);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(119, 22);
            this.txtTelefono.TabIndex = 8;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(148, 170);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(101, 22);
            this.txtFax.TabIndex = 10;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(259, 290);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(211, 22);
            this.txtCorreo.TabIndex = 26;
            // 
            // cboTipoId
            // 
            this.cboTipoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoId.DropDownWidth = 110;
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(16, 114);
            this.cboTipoId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(124, 24);
            this.cboTipoId.TabIndex = 2;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Location = new System.Drawing.Point(153, 116);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(136, 22);
            this.txtIdentificacion.TabIndex = 4;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Location = new System.Drawing.Point(16, 222);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUbicacion.Multiline = true;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(780, 43);
            this.txtUbicacion.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ubicación";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(264, 151);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "D. Crédito";
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(263, 171);
            this.txtDias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDias.Name = "txtDias";
            this.txtDias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDias.Size = new System.Drawing.Size(84, 22);
            this.txtDias.TabIndex = 12;
            this.txtDias.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(157, 96);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 17);
            this.label17.TabIndex = 3;
            this.label17.Text = "Identificación";
            // 
            // cboLCMoneda
            // 
            this.cboLCMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLCMoneda.DropDownWidth = 110;
            this.cboLCMoneda.FormattingEnabled = true;
            this.cboLCMoneda.Items.AddRange(new object[] {
            "COL",
            "USD"});
            this.cboLCMoneda.Location = new System.Drawing.Point(13, 23);
            this.cboLCMoneda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLCMoneda.Name = "cboLCMoneda";
            this.cboLCMoneda.Size = new System.Drawing.Size(105, 24);
            this.cboLCMoneda.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLCLimite);
            this.groupBox1.Controls.Add(this.cboLCMoneda);
            this.groupBox1.Location = new System.Drawing.Point(381, 148);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(252, 59);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limite de crédito";
            // 
            // txtLCLimite
            // 
            this.txtLCLimite.Location = new System.Drawing.Point(136, 23);
            this.txtLCLimite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLCLimite.Name = "txtLCLimite";
            this.txtLCLimite.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLCLimite.Size = new System.Drawing.Size(97, 22);
            this.txtLCLimite.TabIndex = 43;
            this.txtLCLimite.Text = "0";
            this.txtLCLimite.Enter += new System.EventHandler(this.txtLCLimite_Enter);
            this.txtLCLimite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLCLimite_KeyPress);
            this.txtLCLimite.Leave += new System.EventHandler(this.txtLCLimite_Leave);
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "document.ico");
            this.imgMenu.Images.SetKeyName(1, "Disc 01.ico");
            this.imgMenu.Images.SetKeyName(2, "Sign 06.ico");
            this.imgMenu.Images.SetKeyName(3, "salir2.ico");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMNuevo);
            this.groupBox2.Controls.Add(this.btnMSalir);
            this.groupBox2.Controls.Add(this.btnMGuardar);
            this.groupBox2.Controls.Add(this.btnMEliminar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(812, 85);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            // 
            // btnMNuevo
            // 
            this.btnMNuevo.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMNuevo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMNuevo.ImageKey = "document.ico";
            this.btnMNuevo.ImageList = this.imgMenu;
            this.btnMNuevo.Location = new System.Drawing.Point(12, 18);
            this.btnMNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnMSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnMGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnMEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMEliminar.Name = "btnMEliminar";
            this.btnMEliminar.Size = new System.Drawing.Size(147, 55);
            this.btnMEliminar.TabIndex = 14;
            this.btnMEliminar.Text = "Eliminar";
            this.btnMEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMEliminar.UseVisualStyleBackColor = true;
            this.btnMEliminar.Click += new System.EventHandler(this.btnMEliminar_Click);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 652);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboTipoId);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBId);
            this.Controls.Add(this.txtBNombre);
            this.Controls.Add(this.lblBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClientes_FormClosing);
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.MaskedTextBox txtCorreo;
        private System.Windows.Forms.ComboBox cboTipoId;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboLCMoneda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLCLimite;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cli_identificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_DIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Tipo_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_LC_MONEDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_LC_LIMITE;
    }
}