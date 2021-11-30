namespace PROYECTO
{
    partial class frmMovimientosCajaChica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientosCajaChica));
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.DETCAJ_FECHAMOVIMIENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_DOCUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_EMPLEADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_MOVIMIENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_JUSTIFICACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_CREDITO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETCAJ_DEBITO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDebito = new System.Windows.Forms.TextBox();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCajaChica = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.txtJustificacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMovimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            this.dgrDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgrDatos.ColumnHeadersHeight = 29;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DETCAJ_FECHAMOVIMIENTO,
            this.DETCAJ_DOCUMENTO,
            this.DETCAJ_EMPLEADO,
            this.emp_nombre,
            this.DETCAJ_MOVIMIENTO,
            this.DETCAJ_JUSTIFICACION,
            this.DETCAJ_CREDITO,
            this.DETCAJ_DEBITO});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrDatos.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgrDatos.GridColor = System.Drawing.Color.LightGray;
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dgrDatos.Location = new System.Drawing.Point(16, 209);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgrDatos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.ShowEditingIcon = false;
            this.dgrDatos.Size = new System.Drawing.Size(819, 222);
            this.dgrDatos.TabIndex = 419;
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            // 
            // DETCAJ_FECHAMOVIMIENTO
            // 
            this.DETCAJ_FECHAMOVIMIENTO.DataPropertyName = "DETCAJ_FECHAMOVIMIENTO";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DETCAJ_FECHAMOVIMIENTO.DefaultCellStyle = dataGridViewCellStyle18;
            this.DETCAJ_FECHAMOVIMIENTO.HeaderText = "Fecha";
            this.DETCAJ_FECHAMOVIMIENTO.MinimumWidth = 6;
            this.DETCAJ_FECHAMOVIMIENTO.Name = "DETCAJ_FECHAMOVIMIENTO";
            this.DETCAJ_FECHAMOVIMIENTO.ReadOnly = true;
            this.DETCAJ_FECHAMOVIMIENTO.Width = 70;
            // 
            // DETCAJ_DOCUMENTO
            // 
            this.DETCAJ_DOCUMENTO.DataPropertyName = "DETCAJ_DOCUMENTO";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DETCAJ_DOCUMENTO.DefaultCellStyle = dataGridViewCellStyle19;
            this.DETCAJ_DOCUMENTO.HeaderText = "Documento";
            this.DETCAJ_DOCUMENTO.MinimumWidth = 6;
            this.DETCAJ_DOCUMENTO.Name = "DETCAJ_DOCUMENTO";
            this.DETCAJ_DOCUMENTO.ReadOnly = true;
            this.DETCAJ_DOCUMENTO.Width = 95;
            // 
            // DETCAJ_EMPLEADO
            // 
            this.DETCAJ_EMPLEADO.DataPropertyName = "DETCAJ_EMPLEADO";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DETCAJ_EMPLEADO.DefaultCellStyle = dataGridViewCellStyle20;
            this.DETCAJ_EMPLEADO.HeaderText = "Empleado";
            this.DETCAJ_EMPLEADO.MinimumWidth = 6;
            this.DETCAJ_EMPLEADO.Name = "DETCAJ_EMPLEADO";
            this.DETCAJ_EMPLEADO.ReadOnly = true;
            this.DETCAJ_EMPLEADO.Visible = false;
            this.DETCAJ_EMPLEADO.Width = 75;
            // 
            // emp_nombre
            // 
            this.emp_nombre.DataPropertyName = "emp_nombre";
            this.emp_nombre.HeaderText = "";
            this.emp_nombre.MinimumWidth = 6;
            this.emp_nombre.Name = "emp_nombre";
            this.emp_nombre.ReadOnly = true;
            this.emp_nombre.Visible = false;
            this.emp_nombre.Width = 200;
            // 
            // DETCAJ_MOVIMIENTO
            // 
            this.DETCAJ_MOVIMIENTO.DataPropertyName = "DETCAJ_MOVIMIENTO";
            this.DETCAJ_MOVIMIENTO.HeaderText = "Movimiento";
            this.DETCAJ_MOVIMIENTO.MinimumWidth = 6;
            this.DETCAJ_MOVIMIENTO.Name = "DETCAJ_MOVIMIENTO";
            this.DETCAJ_MOVIMIENTO.ReadOnly = true;
            this.DETCAJ_MOVIMIENTO.Width = 125;
            // 
            // DETCAJ_JUSTIFICACION
            // 
            this.DETCAJ_JUSTIFICACION.DataPropertyName = "DETCAJ_JUSTIFICACION";
            this.DETCAJ_JUSTIFICACION.HeaderText = "Justificación";
            this.DETCAJ_JUSTIFICACION.MinimumWidth = 6;
            this.DETCAJ_JUSTIFICACION.Name = "DETCAJ_JUSTIFICACION";
            this.DETCAJ_JUSTIFICACION.ReadOnly = true;
            this.DETCAJ_JUSTIFICACION.Visible = false;
            this.DETCAJ_JUSTIFICACION.Width = 125;
            // 
            // DETCAJ_CREDITO
            // 
            this.DETCAJ_CREDITO.DataPropertyName = "DETCAJ_CREDITO";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = null;
            this.DETCAJ_CREDITO.DefaultCellStyle = dataGridViewCellStyle21;
            this.DETCAJ_CREDITO.HeaderText = "Credito";
            this.DETCAJ_CREDITO.MinimumWidth = 6;
            this.DETCAJ_CREDITO.Name = "DETCAJ_CREDITO";
            this.DETCAJ_CREDITO.ReadOnly = true;
            this.DETCAJ_CREDITO.Width = 80;
            // 
            // DETCAJ_DEBITO
            // 
            this.DETCAJ_DEBITO.DataPropertyName = "DETCAJ_DEBITO";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = null;
            this.DETCAJ_DEBITO.DefaultCellStyle = dataGridViewCellStyle22;
            this.DETCAJ_DEBITO.HeaderText = "Debito";
            this.DETCAJ_DEBITO.MinimumWidth = 6;
            this.DETCAJ_DEBITO.Name = "DETCAJ_DEBITO";
            this.DETCAJ_DEBITO.ReadOnly = true;
            this.DETCAJ_DEBITO.Width = 80;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 4;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(668, 143);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(160, 43);
            this.btnSalir.TabIndex = 420;
            this.btnSalir.Text = " Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(4, "salir.ico");
            this.imageList1.Images.SetKeyName(5, "Printer Inyect.ico");
            this.imageList1.Images.SetKeyName(6, "Window 03.ico");
            this.imageList1.Images.SetKeyName(7, "control_panel.ico");
            this.imageList1.Images.SetKeyName(8, "CP 50.ico");
            this.imageList1.Images.SetKeyName(9, "CP 45.ico");
            this.imageList1.Images.SetKeyName(10, "P&F 07.ico");
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(101, 30);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 20);
            this.label22.TabIndex = 421;
            this.label22.Text = "Caja Abierta: ";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCaja.Location = new System.Drawing.Point(248, 30);
            this.lblCaja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(32, 20);
            this.lblCaja.TabIndex = 422;
            this.lblCaja.Text = "No";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFecha.Location = new System.Drawing.Point(542, 30);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(77, 20);
            this.lblFecha.TabIndex = 424;
            this.lblFecha.Text = "--/--/----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 423;
            this.label2.Text = "Fecha Apertura: ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDebito
            // 
            this.txtDebito.BackColor = System.Drawing.Color.Bisque;
            this.txtDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebito.ForeColor = System.Drawing.Color.Black;
            this.txtDebito.Location = new System.Drawing.Point(662, 470);
            this.txtDebito.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebito.Name = "txtDebito";
            this.txtDebito.ReadOnly = true;
            this.txtDebito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDebito.Size = new System.Drawing.Size(155, 23);
            this.txtDebito.TabIndex = 488;
            // 
            // txtCredito
            // 
            this.txtCredito.BackColor = System.Drawing.Color.Bisque;
            this.txtCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredito.ForeColor = System.Drawing.Color.Black;
            this.txtCredito.Location = new System.Drawing.Point(662, 439);
            this.txtCredito.Margin = new System.Windows.Forms.Padding(4);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.ReadOnly = true;
            this.txtCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCredito.Size = new System.Drawing.Size(155, 23);
            this.txtCredito.TabIndex = 487;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(580, 443);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 489;
            this.label1.Text = "Créditos:";
            // 
            // btnCajaChica
            // 
            this.btnCajaChica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCajaChica.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCajaChica.ImageIndex = 6;
            this.btnCajaChica.ImageList = this.imageList1;
            this.btnCajaChica.Location = new System.Drawing.Point(668, 30);
            this.btnCajaChica.Margin = new System.Windows.Forms.Padding(4);
            this.btnCajaChica.Name = "btnCajaChica";
            this.btnCajaChica.Size = new System.Drawing.Size(160, 43);
            this.btnCajaChica.TabIndex = 490;
            this.btnCajaChica.Text = " Caja Chica";
            this.btnCajaChica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCajaChica.UseVisualStyleBackColor = true;
            this.btnCajaChica.Visible = false;
            this.btnCajaChica.Click += new System.EventHandler(this.btnCajaChica_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(580, 474);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 491;
            this.label3.Text = "Débitos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTipoMovimiento);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(346, 78);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(264, 69);
            this.groupBox1.TabIndex = 492;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE MOVIMIENTO";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Items.AddRange(new object[] {
            "TODOS",
            "GASTO",
            "REINTEGRO",
            "NOTAS DE DÉBITO",
            "NOTAS DE CRÉDITO",
            "AUMENTO"});
            this.cboTipoMovimiento.Location = new System.Drawing.Point(19, 27);
            this.cboTipoMovimiento.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(225, 25);
            this.cboTipoMovimiento.TabIndex = 0;
            this.cboTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.BackColor = System.Drawing.Color.Beige;
            this.txtJustificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJustificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJustificacion.ForeColor = System.Drawing.Color.Black;
            this.txtJustificacion.Location = new System.Drawing.Point(16, 160);
            this.txtJustificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.ReadOnly = true;
            this.txtJustificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJustificacion.Size = new System.Drawing.Size(632, 41);
            this.txtJustificacion.TabIndex = 518;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 519;
            this.label7.Text = "Justificación:";
            // 
            // txtMovimiento
            // 
            this.txtMovimiento.BackColor = System.Drawing.Color.Bisque;
            this.txtMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovimiento.ForeColor = System.Drawing.Color.Black;
            this.txtMovimiento.Location = new System.Drawing.Point(40, 107);
            this.txtMovimiento.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovimiento.Name = "txtMovimiento";
            this.txtMovimiento.ReadOnly = true;
            this.txtMovimiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMovimiento.Size = new System.Drawing.Size(244, 23);
            this.txtMovimiento.TabIndex = 520;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 521;
            this.label4.Text = "Movimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 458);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 525;
            this.label5.Text = "SALDO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 458);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 524;
            this.label6.Text = "MONTO:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.Bisque;
            this.txtSaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(357, 454);
            this.txtSaldo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldo.Size = new System.Drawing.Size(155, 23);
            this.txtSaldo.TabIndex = 523;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Bisque;
            this.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.Black;
            this.txtMonto.Location = new System.Drawing.Point(100, 454);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMonto.Size = new System.Drawing.Size(153, 23);
            this.txtMonto.TabIndex = 522;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.ImageIndex = 10;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(668, 87);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 43);
            this.btnImprimir.TabIndex = 532;
            this.btnImprimir.Text = " Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmMovimientosCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 510);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtMovimiento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCajaChica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebito);
            this.Controls.Add(this.txtCredito);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgrDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMovimientosCajaChica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Caja Chica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMovimientosCajaChica_FormClosing);
            this.Load += new System.EventHandler(this.frmMovimientosCajaChica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMovimientosCajaChica_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtDebito;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCajaChica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.TextBox txtJustificacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMovimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_FECHAMOVIMIENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_DOCUMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_EMPLEADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_MOVIMIENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_JUSTIFICACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_CREDITO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETCAJ_DEBITO;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ImageList imageList1;
    }
}