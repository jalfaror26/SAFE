namespace PROYECTO
{
    partial class frmProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.PROV_LINEA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_TIPO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_TELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_FAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_CONTACTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_TEL_CONTACTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_UBICACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_DIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_CATEGORIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prov_refBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROV_DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.txtTelContacto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtrefbancaria = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.btnMSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.btnMEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(16, 229);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(201, 24);
            this.cboCategoria.TabIndex = 17;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(119, 174);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(97, 22);
            this.txtFax.TabIndex = 11;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(16, 174);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(96, 22);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Location = new System.Drawing.Point(16, 283);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(713, 22);
            this.txtUbicacion.TabIndex = 21;
            // 
            // txtContacto
            // 
            this.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContacto.Location = new System.Drawing.Point(225, 174);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(339, 22);
            this.txtContacto.TabIndex = 13;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(225, 117);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(431, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Location = new System.Drawing.Point(119, 117);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(97, 22);
            this.txtId.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(217, 154);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Contacto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(117, 154);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Fax";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 154);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Teléfono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(217, 97);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Identificación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 209);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Categoría";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ubicación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(177, 404);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 27;
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
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgrDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROV_LINEA,
            this.PROV_ID,
            this.PROV_TIPO_ID,
            this.PROV_NOMBRE,
            this.PROV_TELEFONO,
            this.PROV_FAX,
            this.PROV_CONTACTO,
            this.PROV_TEL_CONTACTO,
            this.PROV_UBICACION,
            this.PROV_DIAS,
            this.PROV_CATEGORIA,
            this.prov_refBancaria,
            this.PROV_DESCRIPCION});
            this.dgrDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgrDatos.Location = new System.Drawing.Point(16, 455);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            this.dgrDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(724, 218);
            this.dgrDatos.TabIndex = 29;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.VirtualMode = true;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDatos_CellEnter);
            this.dgrDatos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrDatos_ColumnHeaderMouseClick);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrDatos_DataBindingComplete);
            // 
            // PROV_LINEA
            // 
            this.PROV_LINEA.DataPropertyName = "PROV_LINEA";
            this.PROV_LINEA.HeaderText = "Linea";
            this.PROV_LINEA.MinimumWidth = 6;
            this.PROV_LINEA.Name = "PROV_LINEA";
            this.PROV_LINEA.ReadOnly = true;
            this.PROV_LINEA.Visible = false;
            this.PROV_LINEA.Width = 125;
            // 
            // PROV_ID
            // 
            this.PROV_ID.DataPropertyName = "Prov_Id";
            this.PROV_ID.HeaderText = "Identificación";
            this.PROV_ID.MinimumWidth = 6;
            this.PROV_ID.Name = "PROV_ID";
            this.PROV_ID.ReadOnly = true;
            this.PROV_ID.Width = 120;
            // 
            // PROV_TIPO_ID
            // 
            this.PROV_TIPO_ID.DataPropertyName = "PROV_TIPO_ID";
            this.PROV_TIPO_ID.HeaderText = "Tipo ID";
            this.PROV_TIPO_ID.MinimumWidth = 6;
            this.PROV_TIPO_ID.Name = "PROV_TIPO_ID";
            this.PROV_TIPO_ID.ReadOnly = true;
            this.PROV_TIPO_ID.Visible = false;
            this.PROV_TIPO_ID.Width = 125;
            // 
            // PROV_NOMBRE
            // 
            this.PROV_NOMBRE.DataPropertyName = "Prov_Nombre";
            this.PROV_NOMBRE.HeaderText = "Nombre";
            this.PROV_NOMBRE.MinimumWidth = 6;
            this.PROV_NOMBRE.Name = "PROV_NOMBRE";
            this.PROV_NOMBRE.ReadOnly = true;
            this.PROV_NOMBRE.Width = 400;
            // 
            // PROV_TELEFONO
            // 
            this.PROV_TELEFONO.DataPropertyName = "Prov_Telefono";
            this.PROV_TELEFONO.HeaderText = "Teléfono";
            this.PROV_TELEFONO.MinimumWidth = 6;
            this.PROV_TELEFONO.Name = "PROV_TELEFONO";
            this.PROV_TELEFONO.ReadOnly = true;
            this.PROV_TELEFONO.Visible = false;
            this.PROV_TELEFONO.Width = 125;
            // 
            // PROV_FAX
            // 
            this.PROV_FAX.DataPropertyName = "Prov_Fax";
            this.PROV_FAX.HeaderText = "Fax";
            this.PROV_FAX.MinimumWidth = 6;
            this.PROV_FAX.Name = "PROV_FAX";
            this.PROV_FAX.ReadOnly = true;
            this.PROV_FAX.Visible = false;
            this.PROV_FAX.Width = 125;
            // 
            // PROV_CONTACTO
            // 
            this.PROV_CONTACTO.DataPropertyName = "Prov_Contacto";
            this.PROV_CONTACTO.HeaderText = "Contacto";
            this.PROV_CONTACTO.MinimumWidth = 6;
            this.PROV_CONTACTO.Name = "PROV_CONTACTO";
            this.PROV_CONTACTO.ReadOnly = true;
            this.PROV_CONTACTO.Visible = false;
            this.PROV_CONTACTO.Width = 125;
            // 
            // PROV_TEL_CONTACTO
            // 
            this.PROV_TEL_CONTACTO.DataPropertyName = "PROV_TEL_CONTACTO";
            this.PROV_TEL_CONTACTO.HeaderText = "tel_Contacto";
            this.PROV_TEL_CONTACTO.MinimumWidth = 6;
            this.PROV_TEL_CONTACTO.Name = "PROV_TEL_CONTACTO";
            this.PROV_TEL_CONTACTO.ReadOnly = true;
            this.PROV_TEL_CONTACTO.Visible = false;
            this.PROV_TEL_CONTACTO.Width = 125;
            // 
            // PROV_UBICACION
            // 
            this.PROV_UBICACION.DataPropertyName = "Prov_Ubicacion";
            this.PROV_UBICACION.HeaderText = "Ubicacion";
            this.PROV_UBICACION.MinimumWidth = 6;
            this.PROV_UBICACION.Name = "PROV_UBICACION";
            this.PROV_UBICACION.ReadOnly = true;
            this.PROV_UBICACION.Visible = false;
            this.PROV_UBICACION.Width = 125;
            // 
            // PROV_DIAS
            // 
            this.PROV_DIAS.DataPropertyName = "Prov_DIAS";
            this.PROV_DIAS.HeaderText = "Dias";
            this.PROV_DIAS.MinimumWidth = 6;
            this.PROV_DIAS.Name = "PROV_DIAS";
            this.PROV_DIAS.ReadOnly = true;
            this.PROV_DIAS.Visible = false;
            this.PROV_DIAS.Width = 125;
            // 
            // PROV_CATEGORIA
            // 
            this.PROV_CATEGORIA.DataPropertyName = "PROV_CATEGORIA";
            this.PROV_CATEGORIA.HeaderText = "Categoría";
            this.PROV_CATEGORIA.MinimumWidth = 6;
            this.PROV_CATEGORIA.Name = "PROV_CATEGORIA";
            this.PROV_CATEGORIA.ReadOnly = true;
            this.PROV_CATEGORIA.Visible = false;
            this.PROV_CATEGORIA.Width = 125;
            // 
            // prov_refBancaria
            // 
            this.prov_refBancaria.DataPropertyName = "prov_refBancaria";
            this.prov_refBancaria.HeaderText = "Ref Bancaria";
            this.prov_refBancaria.MinimumWidth = 6;
            this.prov_refBancaria.Name = "prov_refBancaria";
            this.prov_refBancaria.ReadOnly = true;
            this.prov_refBancaria.Visible = false;
            this.prov_refBancaria.Width = 125;
            // 
            // PROV_DESCRIPCION
            // 
            this.PROV_DESCRIPCION.DataPropertyName = "PROV_DESCRIPCION";
            this.PROV_DESCRIPCION.HeaderText = "des";
            this.PROV_DESCRIPCION.MinimumWidth = 6;
            this.PROV_DESCRIPCION.Name = "PROV_DESCRIPCION";
            this.PROV_DESCRIPCION.ReadOnly = true;
            this.PROV_DESCRIPCION.Visible = false;
            this.PROV_DESCRIPCION.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Identificación";
            // 
            // txtBId
            // 
            this.txtBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBId.Location = new System.Drawing.Point(16, 423);
            this.txtBId.Margin = new System.Windows.Forms.Padding(4);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(156, 22);
            this.txtBId.TabIndex = 26;
            this.txtBId.TabStop = false;
            this.txtBId.Tag = "P.num_producto";
            this.txtBId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBId_KeyUp);
            // 
            // txtBNombre
            // 
            this.txtBNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBNombre.Location = new System.Drawing.Point(181, 423);
            this.txtBNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(548, 22);
            this.txtBNombre.TabIndex = 28;
            this.txtBNombre.TabStop = false;
            this.txtBNombre.Tag = "M.descripcion";
            this.txtBNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBNombre_KeyUp);
            // 
            // txtTelContacto
            // 
            this.txtTelContacto.Location = new System.Drawing.Point(569, 174);
            this.txtTelContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelContacto.Name = "txtTelContacto";
            this.txtTelContacto.Size = new System.Drawing.Size(160, 22);
            this.txtTelContacto.TabIndex = 15;
            this.txtTelContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelContacto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(565, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Teléfono Contacto";
            // 
            // txtrefbancaria
            // 
            this.txtrefbancaria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrefbancaria.Location = new System.Drawing.Point(16, 338);
            this.txtrefbancaria.Margin = new System.Windows.Forms.Padding(4);
            this.txtrefbancaria.Name = "txtrefbancaria";
            this.txtrefbancaria.Size = new System.Drawing.Size(715, 22);
            this.txtrefbancaria.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 319);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Referencia Bancaria";
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(16, 373);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(162, 20);
            this.lblBusqueda.TabIndex = 24;
            this.lblBusqueda.Text = "Búsqueda Rápida ....";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(221, 231);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(508, 22);
            this.txtDescripcion.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Descripción adicional";
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(661, 117);
            this.txtDias.Margin = new System.Windows.Forms.Padding(4);
            this.txtDias.Name = "txtDias";
            this.txtDias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDias.Size = new System.Drawing.Size(68, 22);
            this.txtDias.TabIndex = 7;
            this.txtDias.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(661, 97);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Días Cred";
            // 
            // cboTipoId
            // 
            this.cboTipoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoId.DropDownWidth = 110;
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(16, 116);
            this.cboTipoId.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(96, 24);
            this.cboTipoId.TabIndex = 2;
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
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(756, 85);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
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
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 687);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cboTipoId);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtrefbancaria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelContacto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgrDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBId);
            this.Controls.Add(this.txtBNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProveedores_FormClosing);
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.TextBox txtTelContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtrefbancaria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboTipoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_LINEA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_TIPO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_TELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_FAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_CONTACTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_TEL_CONTACTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_UBICACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_DIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_CATEGORIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn prov_refBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_DESCRIPCION;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button btnMSalir;
        private System.Windows.Forms.Button btnMGuardar;
        private System.Windows.Forms.Button btnMEliminar;
    }
}