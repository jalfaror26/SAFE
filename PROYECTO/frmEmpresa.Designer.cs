namespace PROYECTO
{
    partial class frmEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresa));
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.MaskedTextBox();
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.ofdRutaImagen = new System.Windows.Forms.OpenFileDialog();
            this.ttInformacion = new System.Windows.Forms.ToolTip(this.components);
            this.btnMSalir = new System.Windows.Forms.Button();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMBackup = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMultFacturasAbiertas = new System.Windows.Forms.CheckBox();
            this.chkRedondearPrecioFactura = new System.Windows.Forms.CheckBox();
            this.chkImprimeAlFacturar = new System.Windows.Forms.CheckBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCanton = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFE_Access_Token = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFE_Api_Token = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFE_Caja = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFE_Sucursal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFE_ActividadComercial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkFE_Ind_Fact_Elect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 244);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Correo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(231, 101);
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
            this.label10.Location = new System.Drawing.Point(502, 101);
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
            this.label11.Location = new System.Drawing.Point(231, 244);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Teléfono";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(498, 120);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(421, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(226, 263);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 22);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(375, 263);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(376, 22);
            this.txtCorreo.TabIndex = 10;
            // 
            // cboTipoId
            // 
            this.cboTipoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoId.DropDownWidth = 110;
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(226, 120);
            this.cboTipoId.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(137, 24);
            this.cboTipoId.TabIndex = 1;
            this.cboTipoId.SelectedIndexChanged += new System.EventHandler(this.cboTipoId_SelectedIndexChanged);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Location = new System.Drawing.Point(375, 120);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(115, 22);
            this.txtIdentificacion.TabIndex = 2;
            this.txtIdentificacion.Text = "3-1235-12563333";
            this.txtIdentificacion.Enter += new System.EventHandler(this.txtIdentificacion_Enter);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            this.txtIdentificacion.Leave += new System.EventHandler(this.txtIdentificacion_Leave);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Location = new System.Drawing.Point(226, 184);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUbicacion.Multiline = true;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(693, 39);
            this.txtUbicacion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ubicación";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(381, 101);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 17);
            this.label17.TabIndex = 3;
            this.label17.Text = "Identificación";
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.Location = new System.Drawing.Point(13, 96);
            this.imgFoto.Margin = new System.Windows.Forms.Padding(4);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(200, 200);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 608;
            this.imgFoto.TabStop = false;
            this.imgFoto.Click += new System.EventHandler(this.imgFoto_Click);
            // 
            // ofdRutaImagen
            // 
            this.ofdRutaImagen.FileName = "openFileDialog1";
            this.ofdRutaImagen.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdRutaImagen_FileOk);
            // 
            // ttInformacion
            // 
            this.ttInformacion.IsBalloon = true;
            // 
            // btnMSalir
            // 
            this.btnMSalir.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSalir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir.ImageKey = "salir2.ico";
            this.btnMSalir.ImageList = this.imgMenu;
            this.btnMSalir.Location = new System.Drawing.Point(511, 18);
            this.btnMSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSalir.Name = "btnMSalir";
            this.btnMSalir.Size = new System.Drawing.Size(147, 55);
            this.btnMSalir.TabIndex = 16;
            this.btnMSalir.Text = "Salir";
            this.btnMSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttInformacion.SetToolTip(this.btnMSalir, "Presione para SALIR");
            this.btnMSalir.UseVisualStyleBackColor = true;
            this.btnMSalir.Click += new System.EventHandler(this.btnMSalir_Click);
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "document.ico");
            this.imgMenu.Images.SetKeyName(1, "Disc 01.ico");
            this.imgMenu.Images.SetKeyName(2, "Sign 06.ico");
            this.imgMenu.Images.SetKeyName(3, "salir2.ico");
            this.imgMenu.Images.SetKeyName(4, "enable_server.ico");
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
            this.btnMNuevo.Text = "Limpiar";
            this.btnMNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttInformacion.SetToolTip(this.btnMNuevo, "Presione para LIMPIAR los campos");
            this.btnMNuevo.UseVisualStyleBackColor = true;
            this.btnMNuevo.Click += new System.EventHandler(this.btnMNuevo_Click);
            // 
            // btnMBackup
            // 
            this.btnMBackup.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMBackup.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMBackup.ImageKey = "enable_server.ico";
            this.btnMBackup.ImageList = this.imgMenu;
            this.btnMBackup.Location = new System.Drawing.Point(344, 18);
            this.btnMBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnMBackup.Name = "btnMBackup";
            this.btnMBackup.Size = new System.Drawing.Size(147, 55);
            this.btnMBackup.TabIndex = 15;
            this.btnMBackup.Text = "Backup de BD";
            this.btnMBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttInformacion.SetToolTip(this.btnMBackup, "Presione para iniciar el respaldo de la Base de Datos");
            this.btnMBackup.UseVisualStyleBackColor = true;
            this.btnMBackup.Click += new System.EventHandler(this.btnMBackup_Click);
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
            this.ttInformacion.SetToolTip(this.btnMGuardar, "Presione para GUARDAR los datos");
            this.btnMGuardar.UseVisualStyleBackColor = true;
            this.btnMGuardar.Click += new System.EventHandler(this.btnMGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMSalir);
            this.groupBox1.Controls.Add(this.btnMNuevo);
            this.groupBox1.Controls.Add(this.btnMBackup);
            this.groupBox1.Controls.Add(this.btnMGuardar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(936, 85);
            this.groupBox1.TabIndex = 614;
            this.groupBox1.TabStop = false;
            // 
            // chkMultFacturasAbiertas
            // 
            this.chkMultFacturasAbiertas.AutoSize = true;
            this.chkMultFacturasAbiertas.Location = new System.Drawing.Point(30, 383);
            this.chkMultFacturasAbiertas.Margin = new System.Windows.Forms.Padding(4);
            this.chkMultFacturasAbiertas.Name = "chkMultFacturasAbiertas";
            this.chkMultFacturasAbiertas.Size = new System.Drawing.Size(201, 21);
            this.chkMultFacturasAbiertas.TabIndex = 617;
            this.chkMultFacturasAbiertas.TabStop = false;
            this.chkMultFacturasAbiertas.Text = "Multiple Facturas Abiertas?";
            this.chkMultFacturasAbiertas.UseVisualStyleBackColor = true;
            // 
            // chkRedondearPrecioFactura
            // 
            this.chkRedondearPrecioFactura.AutoSize = true;
            this.chkRedondearPrecioFactura.Location = new System.Drawing.Point(30, 439);
            this.chkRedondearPrecioFactura.Margin = new System.Windows.Forms.Padding(4);
            this.chkRedondearPrecioFactura.Name = "chkRedondearPrecioFactura";
            this.chkRedondearPrecioFactura.Size = new System.Drawing.Size(194, 21);
            this.chkRedondearPrecioFactura.TabIndex = 618;
            this.chkRedondearPrecioFactura.TabStop = false;
            this.chkRedondearPrecioFactura.Text = "Redondear Precio Venta?";
            this.chkRedondearPrecioFactura.UseVisualStyleBackColor = true;
            // 
            // chkImprimeAlFacturar
            // 
            this.chkImprimeAlFacturar.AutoSize = true;
            this.chkImprimeAlFacturar.Location = new System.Drawing.Point(30, 411);
            this.chkImprimeAlFacturar.Margin = new System.Windows.Forms.Padding(4);
            this.chkImprimeAlFacturar.Name = "chkImprimeAlFacturar";
            this.chkImprimeAlFacturar.Size = new System.Drawing.Size(159, 21);
            this.chkImprimeAlFacturar.TabIndex = 621;
            this.chkImprimeAlFacturar.TabStop = false;
            this.chkImprimeAlFacturar.Text = "Imprime al Facturar?";
            this.chkImprimeAlFacturar.UseVisualStyleBackColor = true;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.DropDownWidth = 110;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(13, 328);
            this.cboProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(220, 24);
            this.cboProvincia.TabIndex = 4;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 309);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 622;
            this.label1.Text = "Provincia";
            // 
            // cboCanton
            // 
            this.cboCanton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanton.DropDownWidth = 150;
            this.cboCanton.FormattingEnabled = true;
            this.cboCanton.Location = new System.Drawing.Point(241, 328);
            this.cboCanton.Margin = new System.Windows.Forms.Padding(4);
            this.cboCanton.Name = "cboCanton";
            this.cboCanton.Size = new System.Drawing.Size(220, 24);
            this.cboCanton.TabIndex = 5;
            this.cboCanton.SelectedIndexChanged += new System.EventHandler(this.cboCanton_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 624;
            this.label2.Text = "Cantón";
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.DropDownWidth = 110;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(470, 328);
            this.cboDistrito.Margin = new System.Windows.Forms.Padding(4);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(220, 24);
            this.cboDistrito.TabIndex = 6;
            this.cboDistrito.SelectedIndexChanged += new System.EventHandler(this.cboDistrito_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(476, 309);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 626;
            this.label5.Text = "Distrito";
            // 
            // cboBarrio
            // 
            this.cboBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarrio.DropDownWidth = 110;
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(699, 328);
            this.cboBarrio.Margin = new System.Windows.Forms.Padding(4);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(220, 24);
            this.cboBarrio.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(703, 309);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 628;
            this.label6.Text = "Barrio";
            // 
            // txtFE_Access_Token
            // 
            this.txtFE_Access_Token.BackColor = System.Drawing.Color.White;
            this.txtFE_Access_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Access_Token.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Access_Token.Location = new System.Drawing.Point(146, 102);
            this.txtFE_Access_Token.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Access_Token.Name = "txtFE_Access_Token";
            this.txtFE_Access_Token.Size = new System.Drawing.Size(475, 22);
            this.txtFE_Access_Token.TabIndex = 612;
            this.txtFE_Access_Token.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 613;
            this.label7.Text = "ACCESS TOKEN";
            // 
            // txtFE_Api_Token
            // 
            this.txtFE_Api_Token.BackColor = System.Drawing.Color.White;
            this.txtFE_Api_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Api_Token.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Api_Token.Location = new System.Drawing.Point(146, 70);
            this.txtFE_Api_Token.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Api_Token.Name = "txtFE_Api_Token";
            this.txtFE_Api_Token.Size = new System.Drawing.Size(475, 22);
            this.txtFE_Api_Token.TabIndex = 610;
            this.txtFE_Api_Token.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 611;
            this.label8.Text = "API TOKEN";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFE_Caja);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtFE_Sucursal);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtFE_ActividadComercial);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.chkFE_Ind_Fact_Elect);
            this.groupBox3.Controls.Add(this.txtFE_Access_Token);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtFE_Api_Token);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(273, 365);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(646, 197);
            this.groupBox3.TabIndex = 629;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Hacienda";
            // 
            // txtFE_Caja
            // 
            this.txtFE_Caja.BackColor = System.Drawing.Color.White;
            this.txtFE_Caja.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Caja.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Caja.Location = new System.Drawing.Point(435, 162);
            this.txtFE_Caja.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Caja.Name = "txtFE_Caja";
            this.txtFE_Caja.Size = new System.Drawing.Size(189, 22);
            this.txtFE_Caja.TabIndex = 635;
            this.txtFE_Caja.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(438, 141);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 636;
            this.label14.Text = "Caja";
            // 
            // txtFE_Sucursal
            // 
            this.txtFE_Sucursal.BackColor = System.Drawing.Color.White;
            this.txtFE_Sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Sucursal.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Sucursal.Location = new System.Drawing.Point(231, 162);
            this.txtFE_Sucursal.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Sucursal.Name = "txtFE_Sucursal";
            this.txtFE_Sucursal.Size = new System.Drawing.Size(189, 22);
            this.txtFE_Sucursal.TabIndex = 633;
            this.txtFE_Sucursal.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(234, 141);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 634;
            this.label13.Text = "Sucursal";
            // 
            // txtFE_ActividadComercial
            // 
            this.txtFE_ActividadComercial.BackColor = System.Drawing.Color.White;
            this.txtFE_ActividadComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_ActividadComercial.ForeColor = System.Drawing.Color.Black;
            this.txtFE_ActividadComercial.Location = new System.Drawing.Point(26, 162);
            this.txtFE_ActividadComercial.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_ActividadComercial.Name = "txtFE_ActividadComercial";
            this.txtFE_ActividadComercial.Size = new System.Drawing.Size(189, 22);
            this.txtFE_ActividadComercial.TabIndex = 631;
            this.txtFE_ActividadComercial.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 141);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 17);
            this.label12.TabIndex = 632;
            this.label12.Text = "Actividad Comercial";
            // 
            // chkFE_Ind_Fact_Elect
            // 
            this.chkFE_Ind_Fact_Elect.AutoSize = true;
            this.chkFE_Ind_Fact_Elect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFE_Ind_Fact_Elect.Location = new System.Drawing.Point(26, 32);
            this.chkFE_Ind_Fact_Elect.Margin = new System.Windows.Forms.Padding(4);
            this.chkFE_Ind_Fact_Elect.Name = "chkFE_Ind_Fact_Elect";
            this.chkFE_Ind_Fact_Elect.Size = new System.Drawing.Size(342, 24);
            this.chkFE_Ind_Fact_Elect.TabIndex = 630;
            this.chkFE_Ind_Fact_Elect.TabStop = false;
            this.chkFE_Ind_Fact_Elect.Text = "Utiliza módulo de Facturación Electrónica";
            this.chkFE_Ind_Fact_Elect.UseVisualStyleBackColor = true;
            this.chkFE_Ind_Fact_Elect.CheckedChanged += new System.EventHandler(this.chkFE_Ind_Fact_Elect_CheckedChanged);
            // 
            // frmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 579);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cboBarrio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCanton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkImprimeAlFacturar);
            this.Controls.Add(this.chkRedondearPrecioFactura);
            this.Controls.Add(this.chkMultFacturasAbiertas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgFoto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboTipoId);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUbicacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de la empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClientes_FormClosing);
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.MaskedTextBox txtCorreo;
        private System.Windows.Forms.ComboBox cboTipoId;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.OpenFileDialog ofdRutaImagen;
        private System.Windows.Forms.ToolTip ttInformacion;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button btnMBackup;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.CheckBox chkMultFacturasAbiertas;
        private System.Windows.Forms.CheckBox chkRedondearPrecioFactura;
        private System.Windows.Forms.CheckBox chkImprimeAlFacturar;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCanton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.TextBox txtFE_Access_Token;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFE_Api_Token;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkFE_Ind_Fact_Elect;
        private System.Windows.Forms.TextBox txtFE_Caja;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFE_Sucursal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFE_ActividadComercial;
        private System.Windows.Forms.Label label12;
    }
}