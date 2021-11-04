namespace PROYECTO
{
    partial class frmServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPrecioCosto = new System.Windows.Forms.TextBox();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroDescBreve = new System.Windows.Forms.TextBox();
            this.txtFiltroCodigo = new System.Windows.Forms.TextBox();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtDesBreveArt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkIVI = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMEliminar = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodCabys = new System.Windows.Forms.TextBox();
            this.ART_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_DESC_BREVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_IMPUESTOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_VENTA_IVI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_TIPO_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ART_INDICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CABYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(569, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 28);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file_find.ico");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Enabled = false;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(248, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "¿Tiene impuesto?";
            this.label18.Visible = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Enabled = false;
            this.txtPrecioVenta.Location = new System.Drawing.Point(332, 201);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioVenta.TabIndex = 12;
            this.txtPrecioVenta.Text = "¢ 0";
            this.txtPrecioVenta.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1, 185);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Precio Venta";
            this.label21.Visible = false;
            // 
            // txtPrecioCosto
            // 
            this.txtPrecioCosto.Enabled = false;
            this.txtPrecioCosto.Location = new System.Drawing.Point(95, 201);
            this.txtPrecioCosto.Name = "txtPrecioCosto";
            this.txtPrecioCosto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioCosto.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioCosto.TabIndex = 10;
            this.txtPrecioCosto.Text = "¢ 0";
            this.txtPrecioCosto.Visible = false;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 294);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 17);
            this.label7.TabIndex = 53;
            this.label7.Text = "Descripción General";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Código";
            // 
            // txtFiltroDescBreve
            // 
            this.txtFiltroDescBreve.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltroDescBreve.Location = new System.Drawing.Point(256, 314);
            this.txtFiltroDescBreve.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroDescBreve.Name = "txtFiltroDescBreve";
            this.txtFiltroDescBreve.Size = new System.Drawing.Size(279, 22);
            this.txtFiltroDescBreve.TabIndex = 54;
            this.txtFiltroDescBreve.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroDescBreve_KeyUp);
            // 
            // txtFiltroCodigo
            // 
            this.txtFiltroCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltroCodigo.Location = new System.Drawing.Point(47, 314);
            this.txtFiltroCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroCodigo.Name = "txtFiltroCodigo";
            this.txtFiltroCodigo.Size = new System.Drawing.Size(188, 22);
            this.txtFiltroCodigo.TabIndex = 52;
            this.txtFiltroCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroCodigo_KeyUp);
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            this.dgrDatos.AllowUserToResizeColumns = false;
            this.dgrDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.ART_CODIGO,
            this.ART_DESC_BREVE,
            this.ART_IMPUESTOS,
            this.ART_VENTA_IVI,
            this.ART_TIPO,
            this.ART_ESTADO,
            this.ART_NOMBRE,
            this.ART_TIPO_CODIGO,
            this.ART_INDICE,
            this.COD_CABYS});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(18, 352);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(784, 306);
            this.dgrDatos.TabIndex = 55;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(31, 256);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(162, 20);
            this.lblBusqueda.TabIndex = 50;
            this.lblBusqueda.Text = "Búsqueda Rápida ....";
            // 
            // txtDesBreveArt
            // 
            this.txtDesBreveArt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesBreveArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesBreveArt.Location = new System.Drawing.Point(30, 171);
            this.txtDesBreveArt.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesBreveArt.Multiline = true;
            this.txtDesBreveArt.Name = "txtDesBreveArt";
            this.txtDesBreveArt.Size = new System.Drawing.Size(764, 66);
            this.txtDesBreveArt.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(32, 151);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 17);
            this.label14.TabIndex = 43;
            this.label14.Text = "Descripción";
            // 
            // chkIVI
            // 
            this.chkIVI.AutoSize = true;
            this.chkIVI.Enabled = false;
            this.chkIVI.Location = new System.Drawing.Point(749, 117);
            this.chkIVI.Margin = new System.Windows.Forms.Padding(4);
            this.chkIVI.Name = "chkIVI";
            this.chkIVI.Size = new System.Drawing.Size(45, 21);
            this.chkIVI.TabIndex = 49;
            this.chkIVI.Tag = "Impuesto de Ventas Incluido para la Venta";
            this.chkIVI.Text = "IVI";
            this.chkIVI.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "%";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(30, 118);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(249, 22);
            this.txtCodigo.TabIndex = 44;
            this.txtCodigo.TabStop = false;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuesto.Location = new System.Drawing.Point(630, 115);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpuesto.MaxLength = 5;
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(69, 26);
            this.txtImpuesto.TabIndex = 46;
            this.txtImpuesto.TabStop = false;
            this.txtImpuesto.Text = "0";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImpuesto.Enter += new System.EventHandler(this.txtImpuesto_Enter);
            this.txtImpuesto.Leave += new System.EventHandler(this.txtImpuesto_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(596, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "IV";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMNuevo);
            this.groupBox2.Controls.Add(this.btnMSalir);
            this.groupBox2.Controls.Add(this.btnMGuardar);
            this.groupBox2.Controls.Add(this.btnMEliminar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(820, 85);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "Código Cabys";
            // 
            // txtCodCabys
            // 
            this.txtCodCabys.BackColor = System.Drawing.Color.White;
            this.txtCodCabys.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCabys.Location = new System.Drawing.Point(316, 117);
            this.txtCodCabys.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCabys.Name = "txtCodCabys";
            this.txtCodCabys.Size = new System.Drawing.Size(249, 22);
            this.txtCodCabys.TabIndex = 1;
            this.txtCodCabys.TabStop = false;
            // 
            // ART_CODIGO
            // 
            this.ART_CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ART_CODIGO.DataPropertyName = "ART_CODIGO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ART_CODIGO.DefaultCellStyle = dataGridViewCellStyle3;
            this.ART_CODIGO.HeaderText = "Código";
            this.ART_CODIGO.MinimumWidth = 6;
            this.ART_CODIGO.Name = "ART_CODIGO";
            this.ART_CODIGO.ReadOnly = true;
            this.ART_CODIGO.Width = 125;
            // 
            // ART_DESC_BREVE
            // 
            this.ART_DESC_BREVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ART_DESC_BREVE.DataPropertyName = "ART_DESC_BREVE";
            this.ART_DESC_BREVE.HeaderText = "Descripción";
            this.ART_DESC_BREVE.MinimumWidth = 6;
            this.ART_DESC_BREVE.Name = "ART_DESC_BREVE";
            this.ART_DESC_BREVE.ReadOnly = true;
            this.ART_DESC_BREVE.Width = 340;
            // 
            // ART_IMPUESTOS
            // 
            this.ART_IMPUESTOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ART_IMPUESTOS.DataPropertyName = "ART_IMPUESTOS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "###,###0.##";
            dataGridViewCellStyle4.NullValue = "0";
            this.ART_IMPUESTOS.DefaultCellStyle = dataGridViewCellStyle4;
            this.ART_IMPUESTOS.HeaderText = "% IV";
            this.ART_IMPUESTOS.MinimumWidth = 6;
            this.ART_IMPUESTOS.Name = "ART_IMPUESTOS";
            this.ART_IMPUESTOS.ReadOnly = true;
            this.ART_IMPUESTOS.Width = 65;
            // 
            // ART_VENTA_IVI
            // 
            this.ART_VENTA_IVI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ART_VENTA_IVI.DataPropertyName = "ART_VENTA_IVI";
            this.ART_VENTA_IVI.HeaderText = "IVI";
            this.ART_VENTA_IVI.MinimumWidth = 6;
            this.ART_VENTA_IVI.Name = "ART_VENTA_IVI";
            this.ART_VENTA_IVI.ReadOnly = true;
            this.ART_VENTA_IVI.Width = 40;
            // 
            // ART_TIPO
            // 
            this.ART_TIPO.DataPropertyName = "ART_TIPO";
            this.ART_TIPO.HeaderText = "ART_TIPO";
            this.ART_TIPO.MinimumWidth = 2;
            this.ART_TIPO.Name = "ART_TIPO";
            this.ART_TIPO.ReadOnly = true;
            this.ART_TIPO.Visible = false;
            this.ART_TIPO.Width = 2;
            // 
            // ART_ESTADO
            // 
            this.ART_ESTADO.DataPropertyName = "ART_ESTADO";
            this.ART_ESTADO.HeaderText = "ART_ESTADO";
            this.ART_ESTADO.MinimumWidth = 2;
            this.ART_ESTADO.Name = "ART_ESTADO";
            this.ART_ESTADO.ReadOnly = true;
            this.ART_ESTADO.Visible = false;
            this.ART_ESTADO.Width = 2;
            // 
            // ART_NOMBRE
            // 
            this.ART_NOMBRE.DataPropertyName = "ART_NOMBRE";
            this.ART_NOMBRE.HeaderText = "Descripción";
            this.ART_NOMBRE.MinimumWidth = 2;
            this.ART_NOMBRE.Name = "ART_NOMBRE";
            this.ART_NOMBRE.ReadOnly = true;
            this.ART_NOMBRE.Visible = false;
            this.ART_NOMBRE.Width = 2;
            // 
            // ART_TIPO_CODIGO
            // 
            this.ART_TIPO_CODIGO.DataPropertyName = "ART_TIPO_CODIGO";
            this.ART_TIPO_CODIGO.HeaderText = "ART_TIPO_CODIGO";
            this.ART_TIPO_CODIGO.MinimumWidth = 2;
            this.ART_TIPO_CODIGO.Name = "ART_TIPO_CODIGO";
            this.ART_TIPO_CODIGO.ReadOnly = true;
            this.ART_TIPO_CODIGO.Visible = false;
            this.ART_TIPO_CODIGO.Width = 2;
            // 
            // ART_INDICE
            // 
            this.ART_INDICE.DataPropertyName = "ART_INDICE";
            this.ART_INDICE.HeaderText = "ART_INDICE";
            this.ART_INDICE.MinimumWidth = 2;
            this.ART_INDICE.Name = "ART_INDICE";
            this.ART_INDICE.ReadOnly = true;
            this.ART_INDICE.Visible = false;
            this.ART_INDICE.Width = 2;
            // 
            // COD_CABYS
            // 
            this.COD_CABYS.DataPropertyName = "COD_CABYS";
            this.COD_CABYS.HeaderText = "COD_CABYS";
            this.COD_CABYS.MinimumWidth = 6;
            this.COD_CABYS.Name = "COD_CABYS";
            this.COD_CABYS.ReadOnly = true;
            this.COD_CABYS.Visible = false;
            this.COD_CABYS.Width = 125;
            // 
            // frmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(820, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodCabys);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltroDescBreve);
            this.Controls.Add(this.txtFiltroCodigo);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtDesBreveArt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkIVI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Servicios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticulos_FormClosing);
            this.Load += new System.EventHandler(this.frmServicios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPrecioCosto;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltroDescBreve;
        private System.Windows.Forms.TextBox txtFiltroCodigo;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtDesBreveArt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkIVI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMEliminar;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodCabys;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_DESC_BREVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_IMPUESTOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_VENTA_IVI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_TIPO_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ART_INDICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CABYS;
    }
}