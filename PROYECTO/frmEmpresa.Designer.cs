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
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(422, 295);
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
            this.label9.Location = new System.Drawing.Point(21, 94);
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
            this.label10.Location = new System.Drawing.Point(327, 94);
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
            this.label11.Location = new System.Drawing.Point(272, 295);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Teléfono";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(323, 113);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(471, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(267, 314);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 22);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(416, 314);
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
            this.cboTipoId.Location = new System.Drawing.Point(16, 113);
            this.cboTipoId.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(137, 24);
            this.cboTipoId.TabIndex = 1;
            this.cboTipoId.SelectedIndexChanged += new System.EventHandler(this.cboTipoId_SelectedIndexChanged);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Location = new System.Drawing.Point(165, 113);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(140, 22);
            this.txtIdentificacion.TabIndex = 2;
            this.txtIdentificacion.Enter += new System.EventHandler(this.txtIdentificacion_Enter);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            this.txtIdentificacion.Leave += new System.EventHandler(this.txtIdentificacion_Leave);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Location = new System.Drawing.Point(267, 223);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUbicacion.Multiline = true;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(525, 58);
            this.txtUbicacion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(272, 203);
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
            this.label17.Location = new System.Drawing.Point(171, 94);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 17);
            this.label17.TabIndex = 3;
            this.label17.Text = "Identificación";
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.Location = new System.Drawing.Point(16, 223);
            this.imgFoto.Margin = new System.Windows.Forms.Padding(4);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(229, 212);
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
            this.ttInformacion.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttInformacion.ToolTipTitle = "Información Importante";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMNuevo);
            this.groupBox1.Controls.Add(this.btnMSalir);
            this.groupBox1.Controls.Add(this.btnMGuardar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(812, 85);
            this.groupBox1.TabIndex = 614;
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
            this.btnMNuevo.Text = "Limpiar";
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
            this.btnMSalir.Location = new System.Drawing.Point(344, 18);
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
            // chkMultFacturasAbiertas
            // 
            this.chkMultFacturasAbiertas.AutoSize = true;
            this.chkMultFacturasAbiertas.Location = new System.Drawing.Point(267, 358);
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
            this.chkRedondearPrecioFactura.Location = new System.Drawing.Point(267, 414);
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
            this.chkImprimeAlFacturar.Location = new System.Drawing.Point(267, 386);
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
            this.cboProvincia.Location = new System.Drawing.Point(16, 167);
            this.cboProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(125, 24);
            this.cboProvincia.TabIndex = 4;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 148);
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
            this.cboCanton.Location = new System.Drawing.Point(152, 167);
            this.cboCanton.Margin = new System.Windows.Forms.Padding(4);
            this.cboCanton.Name = "cboCanton";
            this.cboCanton.Size = new System.Drawing.Size(205, 24);
            this.cboCanton.TabIndex = 5;
            this.cboCanton.SelectedIndexChanged += new System.EventHandler(this.cboCanton_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 148);
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
            this.cboDistrito.Location = new System.Drawing.Point(369, 167);
            this.cboDistrito.Margin = new System.Windows.Forms.Padding(4);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(205, 24);
            this.cboDistrito.TabIndex = 6;
            this.cboDistrito.SelectedIndexChanged += new System.EventHandler(this.cboDistrito_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(375, 148);
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
            this.cboBarrio.Location = new System.Drawing.Point(587, 167);
            this.cboBarrio.Margin = new System.Windows.Forms.Padding(4);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(205, 24);
            this.cboBarrio.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(591, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 628;
            this.label6.Text = "Barrio";
            // 
            // frmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 457);
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
        private System.Windows.Forms.Button btnMSalir;
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
    }
}