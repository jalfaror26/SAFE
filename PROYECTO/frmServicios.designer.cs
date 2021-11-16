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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnMEliminar = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodCabys = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboExento = new System.Windows.Forms.RadioButton();
            this.rboGravado = new System.Windows.Forms.RadioButton();
            this.btnImpuestos = new System.Windows.Forms.Button();
            this.SER_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_DESC_BREVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_IMPUESTOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_VENTA_IVI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_TIPO_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_INDICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CABYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SER_CODIGO,
            this.SER_DESC_BREVE,
            this.SER_IMPUESTOS,
            this.SER_VENTA_IVI,
            this.SER_TIPO,
            this.SER_ESTADO,
            this.SER_NOMBRE,
            this.SER_TIPO_CODIGO,
            this.SER_INDICE,
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
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle10;
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
            this.chkIVI.Location = new System.Drawing.Point(118, 45);
            this.chkIVI.Margin = new System.Windows.Forms.Padding(4);
            this.chkIVI.Name = "chkIVI";
            this.chkIVI.Size = new System.Drawing.Size(45, 21);
            this.chkIVI.TabIndex = 49;
            this.chkIVI.Tag = "Impuesto de Ventas Incluido para la Venta";
            this.chkIVI.Text = "IVI";
            this.chkIVI.UseVisualStyleBackColor = true;
            this.chkIVI.Visible = false;
            this.chkIVI.CheckedChanged += new System.EventHandler(this.chkIVI_CheckedChanged);
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
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(30, 118);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(205, 22);
            this.txtCodigo.TabIndex = 44;
            this.txtCodigo.TabStop = false;
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
            this.label1.Location = new System.Drawing.Point(253, 95);
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
            this.txtCodCabys.Location = new System.Drawing.Point(251, 117);
            this.txtCodCabys.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCabys.Name = "txtCodCabys";
            this.txtCodCabys.Size = new System.Drawing.Size(207, 22);
            this.txtCodCabys.TabIndex = 1;
            this.txtCodCabys.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImpuestos);
            this.groupBox1.Controls.Add(this.rboGravado);
            this.groupBox1.Controls.Add(this.rboExento);
            this.groupBox1.Controls.Add(this.chkIVI);
            this.groupBox1.Location = new System.Drawing.Point(485, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 73);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            // 
            // rboExento
            // 
            this.rboExento.AutoSize = true;
            this.rboExento.Checked = true;
            this.rboExento.Location = new System.Drawing.Point(16, 15);
            this.rboExento.Name = "rboExento";
            this.rboExento.Size = new System.Drawing.Size(72, 21);
            this.rboExento.TabIndex = 50;
            this.rboExento.TabStop = true;
            this.rboExento.Text = "Exento";
            this.rboExento.UseVisualStyleBackColor = true;
            this.rboExento.CheckedChanged += new System.EventHandler(this.rboExento_CheckedChanged);
            // 
            // rboGravado
            // 
            this.rboGravado.AutoSize = true;
            this.rboGravado.Location = new System.Drawing.Point(16, 44);
            this.rboGravado.Name = "rboGravado";
            this.rboGravado.Size = new System.Drawing.Size(84, 21);
            this.rboGravado.TabIndex = 51;
            this.rboGravado.Text = "Gravado";
            this.rboGravado.UseVisualStyleBackColor = true;
            this.rboGravado.CheckedChanged += new System.EventHandler(this.rboGravado_CheckedChanged);
            // 
            // btnImpuestos
            // 
            this.btnImpuestos.Enabled = false;
            this.btnImpuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpuestos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImpuestos.ImageIndex = 11;
            this.btnImpuestos.ImageList = this.imageList2;
            this.btnImpuestos.Location = new System.Drawing.Point(144, 26);
            this.btnImpuestos.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpuestos.Name = "btnImpuestos";
            this.btnImpuestos.Size = new System.Drawing.Size(133, 39);
            this.btnImpuestos.TabIndex = 52;
            this.btnImpuestos.TabStop = false;
            this.btnImpuestos.Text = " Impuestos";
            this.btnImpuestos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImpuestos.UseVisualStyleBackColor = true;
            this.btnImpuestos.Click += new System.EventHandler(this.btnImpuestos_Click);
            // 
            // SER_CODIGO
            // 
            this.SER_CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SER_CODIGO.DataPropertyName = "SER_CODIGO";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SER_CODIGO.DefaultCellStyle = dataGridViewCellStyle8;
            this.SER_CODIGO.HeaderText = "Código";
            this.SER_CODIGO.MinimumWidth = 6;
            this.SER_CODIGO.Name = "SER_CODIGO";
            this.SER_CODIGO.ReadOnly = true;
            this.SER_CODIGO.Width = 150;
            // 
            // SER_DESC_BREVE
            // 
            this.SER_DESC_BREVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SER_DESC_BREVE.DataPropertyName = "SER_DESC_BREVE";
            this.SER_DESC_BREVE.HeaderText = "Descripción";
            this.SER_DESC_BREVE.MinimumWidth = 6;
            this.SER_DESC_BREVE.Name = "SER_DESC_BREVE";
            this.SER_DESC_BREVE.ReadOnly = true;
            this.SER_DESC_BREVE.Width = 400;
            // 
            // SER_IMPUESTOS
            // 
            this.SER_IMPUESTOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SER_IMPUESTOS.DataPropertyName = "SER_IMPUESTOS";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "###,###0.##";
            dataGridViewCellStyle9.NullValue = "0";
            this.SER_IMPUESTOS.DefaultCellStyle = dataGridViewCellStyle9;
            this.SER_IMPUESTOS.HeaderText = "TipoIV";
            this.SER_IMPUESTOS.MinimumWidth = 6;
            this.SER_IMPUESTOS.Name = "SER_IMPUESTOS";
            this.SER_IMPUESTOS.ReadOnly = true;
            this.SER_IMPUESTOS.Visible = false;
            this.SER_IMPUESTOS.Width = 65;
            // 
            // SER_VENTA_IVI
            // 
            this.SER_VENTA_IVI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SER_VENTA_IVI.DataPropertyName = "SER_VENTA_IVI";
            this.SER_VENTA_IVI.HeaderText = "IVI";
            this.SER_VENTA_IVI.MinimumWidth = 6;
            this.SER_VENTA_IVI.Name = "SER_VENTA_IVI";
            this.SER_VENTA_IVI.ReadOnly = true;
            this.SER_VENTA_IVI.Visible = false;
            this.SER_VENTA_IVI.Width = 40;
            // 
            // SER_TIPO
            // 
            this.SER_TIPO.DataPropertyName = "SER_TIPO";
            this.SER_TIPO.HeaderText = "SER_TIPO";
            this.SER_TIPO.MinimumWidth = 2;
            this.SER_TIPO.Name = "SER_TIPO";
            this.SER_TIPO.ReadOnly = true;
            this.SER_TIPO.Visible = false;
            this.SER_TIPO.Width = 2;
            // 
            // SER_ESTADO
            // 
            this.SER_ESTADO.DataPropertyName = "SER_ESTADO";
            this.SER_ESTADO.HeaderText = "SER_ESTADO";
            this.SER_ESTADO.MinimumWidth = 2;
            this.SER_ESTADO.Name = "SER_ESTADO";
            this.SER_ESTADO.ReadOnly = true;
            this.SER_ESTADO.Visible = false;
            this.SER_ESTADO.Width = 2;
            // 
            // SER_NOMBRE
            // 
            this.SER_NOMBRE.DataPropertyName = "SER_NOMBRE";
            this.SER_NOMBRE.HeaderText = "Descripción";
            this.SER_NOMBRE.MinimumWidth = 2;
            this.SER_NOMBRE.Name = "SER_NOMBRE";
            this.SER_NOMBRE.ReadOnly = true;
            this.SER_NOMBRE.Visible = false;
            this.SER_NOMBRE.Width = 2;
            // 
            // SER_TIPO_CODIGO
            // 
            this.SER_TIPO_CODIGO.DataPropertyName = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.HeaderText = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.MinimumWidth = 2;
            this.SER_TIPO_CODIGO.Name = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.ReadOnly = true;
            this.SER_TIPO_CODIGO.Visible = false;
            this.SER_TIPO_CODIGO.Width = 2;
            // 
            // SER_INDICE
            // 
            this.SER_INDICE.DataPropertyName = "SER_INDICE";
            this.SER_INDICE.HeaderText = "SER_INDICE";
            this.SER_INDICE.MinimumWidth = 2;
            this.SER_INDICE.Name = "SER_INDICE";
            this.SER_INDICE.ReadOnly = true;
            this.SER_INDICE.Visible = false;
            this.SER_INDICE.Width = 2;
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
            this.Controls.Add(this.groupBox1);
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodigo);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnMEliminar;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodCabys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboGravado;
        private System.Windows.Forms.RadioButton rboExento;
        private System.Windows.Forms.Button btnImpuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_DESC_BREVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_IMPUESTOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_VENTA_IVI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_TIPO_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_INDICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CABYS;
    }
}