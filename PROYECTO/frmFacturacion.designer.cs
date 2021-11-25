namespace PROYECTO
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtANombreDe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.grpDetalleFactura = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodCabys = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtLineaDescuento = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSubTotalLinea = new System.Windows.Forms.MaskedTextBox();
            this.txtPorcDecuento = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.chkDescuento = new System.Windows.Forms.CheckBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtMontoIV = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnNuevoDetalle = new System.Windows.Forms.Button();
            this.btnGuardarDetalle = new System.Windows.Forms.Button();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.txtTotalFactura = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dgrDatos = new System.Windows.Forms.DataGridView();
            this.detfac_numerolinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_cabys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETFAC_MONTO_IV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETFAC_PRECIO_UNITARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETFAC_SUBTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETFAC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detfac_ivi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SER_TIPO_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTotalPorLinea = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.btnBusqServicio = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDescServicio = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCodServicio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFormasPago = new System.Windows.Forms.GroupBox();
            this.chkOtros = new System.Windows.Forms.CheckBox();
            this.chkEfectivo = new System.Windows.Forms.CheckBox();
            this.chkCheque = new System.Windows.Forms.CheckBox();
            this.chkTransferencia = new System.Windows.Forms.CheckBox();
            this.chkTarjeta = new System.Windows.Forms.CheckBox();
            this.chkTerceros = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbDatosHacienda = new System.Windows.Forms.GroupBox();
            this.lblMjFacturaElectronica = new System.Windows.Forms.Label();
            this.pbFacturaElectronica = new System.Windows.Forms.ProgressBar();
            this.btnFE_Comprobar = new System.Windows.Forms.Button();
            this.lblFE_Comprobacion = new System.Windows.Forms.Label();
            this.lblFE_Recepcion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFE_Clave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFE_Consecutivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFacturaAtras = new System.Windows.Forms.Button();
            this.btnFacturaAdelante = new System.Windows.Forms.Button();
            this.btnBFactura = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnBusqCliente = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.timCreaFA = new System.Windows.Forms.Timer(this.components);
            this.timCompruebaFA = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.btnFE_Comprobar_NC = new System.Windows.Forms.Button();
            this.lblFE_Comprobacion_NC = new System.Windows.Forms.Label();
            this.lblFE_Recepcion_NC = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFE_Clave_NC = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFE_Consecutivo_NC = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.timCompruebaNC = new System.Windows.Forms.Timer(this.components);
            this.grpDetalleFactura.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbFormasPago.SuspendLayout();
            this.gbDatosHacienda.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document.ico");
            this.imageList1.Images.SetKeyName(1, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(2, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(3, "services.ico");
            this.imageList1.Images.SetKeyName(4, "Aceptar.ico");
            this.imageList1.Images.SetKeyName(5, "file_find.ico");
            this.imageList1.Images.SetKeyName(6, "Write 01.ico");
            this.imageList1.Images.SetKeyName(7, "cruz_roja.png");
            this.imageList1.Images.SetKeyName(8, "App 23.ico");
            this.imageList1.Images.SetKeyName(9, "Salir 2.ico");
            this.imageList1.Images.SetKeyName(10, "Facturadora.png");
            this.imageList1.Images.SetKeyName(11, "file_search.png");
            this.imageList1.Images.SetKeyName(12, "Sign 04.ico");
            this.imageList1.Images.SetKeyName(13, "key manager.ico");
            // 
            // rbContado
            // 
            this.rbContado.AutoSize = true;
            this.rbContado.Checked = true;
            this.rbContado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContado.Location = new System.Drawing.Point(13, 24);
            this.rbContado.Margin = new System.Windows.Forms.Padding(4);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(86, 22);
            this.rbContado.TabIndex = 0;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "Contado";
            this.rbContado.UseVisualStyleBackColor = true;
            this.rbContado.CheckedChanged += new System.EventHandler(this.rbContado_CheckedChanged);
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredito.Location = new System.Drawing.Point(13, 53);
            this.rbCredito.Margin = new System.Windows.Forms.Padding(4);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(77, 22);
            this.rbCredito.TabIndex = 1;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            this.rbCredito.CheckedChanged += new System.EventHandler(this.rbCredito_CheckedChanged);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.Beige;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(16, 181);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(119, 26);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TabStop = false;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(191, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "A Nombre De";
            // 
            // txtANombreDe
            // 
            this.txtANombreDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtANombreDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtANombreDe.Location = new System.Drawing.Point(185, 181);
            this.txtANombreDe.Margin = new System.Windows.Forms.Padding(4);
            this.txtANombreDe.Name = "txtANombreDe";
            this.txtANombreDe.Size = new System.Drawing.Size(394, 26);
            this.txtANombreDe.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "App 17.ico");
            this.imageList2.Images.SetKeyName(1, "Sign 25.ico");
            this.imageList2.Images.SetKeyName(2, "Sign 26.ico");
            this.imageList2.Images.SetKeyName(3, "CP 08.ico");
            this.imageList2.Images.SetKeyName(4, "file_search.png");
            this.imageList2.Images.SetKeyName(5, "facturar.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Factura";
            // 
            // txtFactura
            // 
            this.txtFactura.BackColor = System.Drawing.Color.Beige;
            this.txtFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.ForeColor = System.Drawing.Color.Black;
            this.txtFactura.Location = new System.Drawing.Point(21, 41);
            this.txtFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.ReadOnly = true;
            this.txtFactura.Size = new System.Drawing.Size(164, 30);
            this.txtFactura.TabIndex = 5;
            this.txtFactura.TabStop = false;
            this.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpDetalleFactura
            // 
            this.grpDetalleFactura.Controls.Add(this.label10);
            this.grpDetalleFactura.Controls.Add(this.txtCodCabys);
            this.grpDetalleFactura.Controls.Add(this.label8);
            this.grpDetalleFactura.Controls.Add(this.label27);
            this.grpDetalleFactura.Controls.Add(this.txtLineaDescuento);
            this.grpDetalleFactura.Controls.Add(this.label29);
            this.grpDetalleFactura.Controls.Add(this.txtSubTotalLinea);
            this.grpDetalleFactura.Controls.Add(this.txtPorcDecuento);
            this.grpDetalleFactura.Controls.Add(this.label31);
            this.grpDetalleFactura.Controls.Add(this.label30);
            this.grpDetalleFactura.Controls.Add(this.txtSubTotal);
            this.grpDetalleFactura.Controls.Add(this.chkDescuento);
            this.grpDetalleFactura.Controls.Add(this.txtDescuento);
            this.grpDetalleFactura.Controls.Add(this.txtMontoIV);
            this.grpDetalleFactura.Controls.Add(this.label32);
            this.grpDetalleFactura.Controls.Add(this.groupBox2);
            this.grpDetalleFactura.Controls.Add(this.txtTotalFactura);
            this.grpDetalleFactura.Controls.Add(this.label33);
            this.grpDetalleFactura.Controls.Add(this.txtCantidad);
            this.grpDetalleFactura.Controls.Add(this.dgrDatos);
            this.grpDetalleFactura.Controls.Add(this.label25);
            this.grpDetalleFactura.Controls.Add(this.txtTotalPorLinea);
            this.grpDetalleFactura.Controls.Add(this.label24);
            this.grpDetalleFactura.Controls.Add(this.txtPrecioUnitario);
            this.grpDetalleFactura.Controls.Add(this.btnBusqServicio);
            this.grpDetalleFactura.Controls.Add(this.label18);
            this.grpDetalleFactura.Controls.Add(this.txtDescServicio);
            this.grpDetalleFactura.Controls.Add(this.label19);
            this.grpDetalleFactura.Controls.Add(this.txtCodServicio);
            this.grpDetalleFactura.Controls.Add(this.label15);
            this.grpDetalleFactura.Controls.Add(this.label14);
            this.grpDetalleFactura.Controls.Add(this.label13);
            this.grpDetalleFactura.Location = new System.Drawing.Point(14, 234);
            this.grpDetalleFactura.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetalleFactura.Name = "grpDetalleFactura";
            this.grpDetalleFactura.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetalleFactura.Size = new System.Drawing.Size(1178, 476);
            this.grpDetalleFactura.TabIndex = 6;
            this.grpDetalleFactura.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 63);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 17);
            this.label10.TabIndex = 608;
            this.label10.Text = "Código CABYS";
            // 
            // txtCodCabys
            // 
            this.txtCodCabys.BackColor = System.Drawing.Color.Beige;
            this.txtCodCabys.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCabys.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCabys.ForeColor = System.Drawing.Color.Black;
            this.txtCodCabys.Location = new System.Drawing.Point(12, 82);
            this.txtCodCabys.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCabys.Name = "txtCodCabys";
            this.txtCodCabys.ReadOnly = true;
            this.txtCodCabys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodCabys.Size = new System.Drawing.Size(237, 22);
            this.txtCodCabys.TabIndex = 609;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(977, 355);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 607;
            this.label8.Text = "Monto IV";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(677, 62);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 17);
            this.label27.TabIndex = 604;
            this.label27.Text = "Desc %";
            // 
            // txtLineaDescuento
            // 
            this.txtLineaDescuento.Location = new System.Drawing.Point(677, 81);
            this.txtLineaDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.txtLineaDescuento.Name = "txtLineaDescuento";
            this.txtLineaDescuento.Size = new System.Drawing.Size(56, 22);
            this.txtLineaDescuento.TabIndex = 603;
            this.txtLineaDescuento.TabStop = false;
            this.txtLineaDescuento.Text = "0";
            this.txtLineaDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLineaDescuento.Enter += new System.EventHandler(this.txtLineaDescuento_Enter);
            this.txtLineaDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineaDescuento_KeyPress);
            this.txtLineaDescuento.Leave += new System.EventHandler(this.txtLineaDescuento_Leave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(533, 62);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(60, 17);
            this.label29.TabIndex = 602;
            this.label29.Text = "Subtotal";
            // 
            // txtSubTotalLinea
            // 
            this.txtSubTotalLinea.BackColor = System.Drawing.Color.Beige;
            this.txtSubTotalLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalLinea.ForeColor = System.Drawing.Color.Black;
            this.txtSubTotalLinea.Location = new System.Drawing.Point(533, 81);
            this.txtSubTotalLinea.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubTotalLinea.Name = "txtSubTotalLinea";
            this.txtSubTotalLinea.PromptChar = ' ';
            this.txtSubTotalLinea.ReadOnly = true;
            this.txtSubTotalLinea.Size = new System.Drawing.Size(121, 23);
            this.txtSubTotalLinea.TabIndex = 601;
            this.txtSubTotalLinea.TabStop = false;
            this.txtSubTotalLinea.Text = "¢ 0.00";
            this.txtSubTotalLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPorcDecuento
            // 
            this.txtPorcDecuento.Location = new System.Drawing.Point(977, 319);
            this.txtPorcDecuento.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorcDecuento.MaxLength = 99;
            this.txtPorcDecuento.Name = "txtPorcDecuento";
            this.txtPorcDecuento.ReadOnly = true;
            this.txtPorcDecuento.Size = new System.Drawing.Size(40, 22);
            this.txtPorcDecuento.TabIndex = 573;
            this.txtPorcDecuento.TabStop = false;
            this.txtPorcDecuento.Text = "0";
            this.txtPorcDecuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPorcDecuento.TextChanged += new System.EventHandler(this.txtPorcDecuento_TextChanged);
            this.txtPorcDecuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcDecuento_KeyPress);
            this.txtPorcDecuento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPorcDecuento_KeyUp);
            this.txtPorcDecuento.Leave += new System.EventHandler(this.txtPorcDecuento_Leave);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(977, 299);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(76, 17);
            this.label31.TabIndex = 570;
            this.label31.Text = "Descuento";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(977, 217);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 17);
            this.label30.TabIndex = 569;
            this.label30.Text = "SubTotal";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.Beige;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.Black;
            this.txtSubTotal.Location = new System.Drawing.Point(977, 235);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(173, 23);
            this.txtSubTotal.TabIndex = 568;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.Text = "¢ 0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkDescuento
            // 
            this.chkDescuento.AutoSize = true;
            this.chkDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescuento.Location = new System.Drawing.Point(979, 274);
            this.chkDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.chkDescuento.Name = "chkDescuento";
            this.chkDescuento.Size = new System.Drawing.Size(82, 21);
            this.chkDescuento.TabIndex = 566;
            this.chkDescuento.TabStop = false;
            this.chkDescuento.Text = "Desc. %";
            this.chkDescuento.UseVisualStyleBackColor = true;
            this.chkDescuento.CheckedChanged += new System.EventHandler(this.chkDescuento_CheckedChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.Beige;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.Black;
            this.txtDescuento.Location = new System.Drawing.Point(1022, 319);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(127, 23);
            this.txtDescuento.TabIndex = 565;
            this.txtDescuento.TabStop = false;
            this.txtDescuento.Text = "¢ 0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoIV
            // 
            this.txtMontoIV.BackColor = System.Drawing.Color.Beige;
            this.txtMontoIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoIV.ForeColor = System.Drawing.Color.Black;
            this.txtMontoIV.Location = new System.Drawing.Point(977, 375);
            this.txtMontoIV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMontoIV.Name = "txtMontoIV";
            this.txtMontoIV.ReadOnly = true;
            this.txtMontoIV.Size = new System.Drawing.Size(173, 23);
            this.txtMontoIV.TabIndex = 564;
            this.txtMontoIV.TabStop = false;
            this.txtMontoIV.Text = "¢ 0.00";
            this.txtMontoIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label32.Location = new System.Drawing.Point(979, 411);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(40, 17);
            this.label32.TabIndex = 572;
            this.label32.Text = "Total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnNuevoDetalle);
            this.groupBox2.Controls.Add(this.btnGuardarDetalle);
            this.groupBox2.Controls.Add(this.btnEliminarDetalle);
            this.groupBox2.Controls.Add(this.btnFacturar);
            this.groupBox2.Location = new System.Drawing.Point(973, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(185, 194);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.ImageKey = "Facturadora.png";
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(9, 144);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 39);
            this.btnImprimir.TabIndex = 30;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = " Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNuevoDetalle
            // 
            this.btnNuevoDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoDetalle.ImageKey = "document.ico";
            this.btnNuevoDetalle.ImageList = this.imageList1;
            this.btnNuevoDetalle.Location = new System.Drawing.Point(9, 15);
            this.btnNuevoDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevoDetalle.Name = "btnNuevoDetalle";
            this.btnNuevoDetalle.Size = new System.Drawing.Size(167, 39);
            this.btnNuevoDetalle.TabIndex = 0;
            this.btnNuevoDetalle.TabStop = false;
            this.btnNuevoDetalle.Text = " Nuevo";
            this.btnNuevoDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoDetalle.UseVisualStyleBackColor = true;
            this.btnNuevoDetalle.Click += new System.EventHandler(this.btnnuevoDetalle_Click);
            // 
            // btnGuardarDetalle
            // 
            this.btnGuardarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarDetalle.ImageKey = "Disc 01.ico";
            this.btnGuardarDetalle.ImageList = this.imageList1;
            this.btnGuardarDetalle.Location = new System.Drawing.Point(9, 58);
            this.btnGuardarDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarDetalle.Name = "btnGuardarDetalle";
            this.btnGuardarDetalle.Size = new System.Drawing.Size(167, 39);
            this.btnGuardarDetalle.TabIndex = 6;
            this.btnGuardarDetalle.Text = " Guardar";
            this.btnGuardarDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarDetalle.UseVisualStyleBackColor = true;
            this.btnGuardarDetalle.Click += new System.EventHandler(this.btnGuardarDetalle_Click);
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarDetalle.ImageKey = "Sign 06.ico";
            this.btnEliminarDetalle.ImageList = this.imageList1;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(9, 101);
            this.btnEliminarDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(167, 39);
            this.btnEliminarDetalle.TabIndex = 29;
            this.btnEliminarDetalle.TabStop = false;
            this.btnEliminarDetalle.Text = " Eliminar";
            this.btnEliminarDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarDetalle.UseVisualStyleBackColor = true;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturar.ImageKey = "Facturadora.png";
            this.btnFacturar.ImageList = this.imageList1;
            this.btnFacturar.Location = new System.Drawing.Point(9, 145);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(167, 39);
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.TabStop = false;
            this.btnFacturar.Text = " Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // txtTotalFactura
            // 
            this.txtTotalFactura.BackColor = System.Drawing.Color.Beige;
            this.txtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalFactura.ForeColor = System.Drawing.Color.Black;
            this.txtTotalFactura.Location = new System.Drawing.Point(976, 431);
            this.txtTotalFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalFactura.Name = "txtTotalFactura";
            this.txtTotalFactura.ReadOnly = true;
            this.txtTotalFactura.Size = new System.Drawing.Size(173, 23);
            this.txtTotalFactura.TabIndex = 571;
            this.txtTotalFactura.TabStop = false;
            this.txtTotalFactura.Text = "¢ 0.00";
            this.txtTotalFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalFactura.TextChanged += new System.EventHandler(this.txtTotalFactura_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(261, 63);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 17);
            this.label33.TabIndex = 18;
            this.label33.Text = "Cant";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(260, 81);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(61, 22);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.Enter += new System.EventHandler(this.txtCantidad_Enter);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // dgrDatos
            // 
            this.dgrDatos.AllowUserToAddRows = false;
            this.dgrDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.Gainsboro;
            this.dgrDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            this.dgrDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.dgrDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detfac_numerolinea,
            this.detfac_codigo,
            this.SER_CODIGO,
            this.Cod_cabys,
            this.detfac_cantidad,
            this.detfac_descripcion,
            this.DETFAC_MONTO_IV,
            this.detfac_medida,
            this.DETFAC_PRECIO_UNITARIO,
            this.DETFAC_SUBTOTAL,
            this.detfac_descuento,
            this.DETFAC_TIPO,
            this.detfac_total,
            this.SER_impuestos,
            this.detfac_ivi,
            this.SER_TIPO_CODIGO});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrDatos.DefaultCellStyle = dataGridViewCellStyle48;
            this.dgrDatos.Location = new System.Drawing.Point(11, 117);
            this.dgrDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDatos.MultiSelect = false;
            this.dgrDatos.Name = "dgrDatos";
            this.dgrDatos.ReadOnly = true;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dgrDatos.RowHeadersVisible = false;
            this.dgrDatos.RowHeadersWidth = 51;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.White;
            this.dgrDatos.RowsDefaultCellStyle = dataGridViewCellStyle50;
            this.dgrDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDatos.Size = new System.Drawing.Size(949, 330);
            this.dgrDatos.TabIndex = 31;
            this.dgrDatos.TabStop = false;
            this.dgrDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdatos_CellEnter);
            this.dgrDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdatos_CellEnter);
            this.dgrDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrdatos_DataBindingComplete);
            // 
            // detfac_numerolinea
            // 
            this.detfac_numerolinea.DataPropertyName = "detfac_numerolinea";
            this.detfac_numerolinea.HeaderText = "indice";
            this.detfac_numerolinea.MinimumWidth = 6;
            this.detfac_numerolinea.Name = "detfac_numerolinea";
            this.detfac_numerolinea.ReadOnly = true;
            this.detfac_numerolinea.Visible = false;
            this.detfac_numerolinea.Width = 125;
            // 
            // detfac_codigo
            // 
            this.detfac_codigo.DataPropertyName = "detfac_codigo";
            this.detfac_codigo.HeaderText = "CodServicio";
            this.detfac_codigo.MinimumWidth = 6;
            this.detfac_codigo.Name = "detfac_codigo";
            this.detfac_codigo.ReadOnly = true;
            this.detfac_codigo.Visible = false;
            this.detfac_codigo.Width = 75;
            // 
            // SER_CODIGO
            // 
            this.SER_CODIGO.DataPropertyName = "SER_CODIGO";
            this.SER_CODIGO.HeaderText = "CODIGO";
            this.SER_CODIGO.MinimumWidth = 6;
            this.SER_CODIGO.Name = "SER_CODIGO";
            this.SER_CODIGO.ReadOnly = true;
            this.SER_CODIGO.Width = 125;
            // 
            // Cod_cabys
            // 
            this.Cod_cabys.DataPropertyName = "Cod_cabys";
            this.Cod_cabys.HeaderText = "Cod_cabys";
            this.Cod_cabys.MinimumWidth = 6;
            this.Cod_cabys.Name = "Cod_cabys";
            this.Cod_cabys.ReadOnly = true;
            this.Cod_cabys.Visible = false;
            this.Cod_cabys.Width = 125;
            // 
            // detfac_cantidad
            // 
            this.detfac_cantidad.DataPropertyName = "detfac_cantidad";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.Format = "###,###,##0";
            this.detfac_cantidad.DefaultCellStyle = dataGridViewCellStyle43;
            this.detfac_cantidad.HeaderText = "CANT";
            this.detfac_cantidad.MinimumWidth = 6;
            this.detfac_cantidad.Name = "detfac_cantidad";
            this.detfac_cantidad.ReadOnly = true;
            this.detfac_cantidad.Width = 60;
            // 
            // detfac_descripcion
            // 
            this.detfac_descripcion.DataPropertyName = "detfac_descripcion";
            this.detfac_descripcion.HeaderText = "DESCRIPCIÓN";
            this.detfac_descripcion.MinimumWidth = 6;
            this.detfac_descripcion.Name = "detfac_descripcion";
            this.detfac_descripcion.ReadOnly = true;
            this.detfac_descripcion.Width = 250;
            // 
            // DETFAC_MONTO_IV
            // 
            this.DETFAC_MONTO_IV.DataPropertyName = "DETFAC_MONTO_IV";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle44.Format = "N2";
            this.DETFAC_MONTO_IV.DefaultCellStyle = dataGridViewCellStyle44;
            this.DETFAC_MONTO_IV.HeaderText = "Monto IV";
            this.DETFAC_MONTO_IV.MinimumWidth = 6;
            this.DETFAC_MONTO_IV.Name = "DETFAC_MONTO_IV";
            this.DETFAC_MONTO_IV.ReadOnly = true;
            this.DETFAC_MONTO_IV.Visible = false;
            this.DETFAC_MONTO_IV.Width = 80;
            // 
            // detfac_medida
            // 
            this.detfac_medida.DataPropertyName = "detfac_medida";
            this.detfac_medida.HeaderText = "Medida";
            this.detfac_medida.MinimumWidth = 6;
            this.detfac_medida.Name = "detfac_medida";
            this.detfac_medida.ReadOnly = true;
            this.detfac_medida.Visible = false;
            this.detfac_medida.Width = 125;
            // 
            // DETFAC_PRECIO_UNITARIO
            // 
            this.DETFAC_PRECIO_UNITARIO.DataPropertyName = "DETFAC_PRECIO_UNITARIO";
            this.DETFAC_PRECIO_UNITARIO.HeaderText = "Precio Unitario";
            this.DETFAC_PRECIO_UNITARIO.MinimumWidth = 6;
            this.DETFAC_PRECIO_UNITARIO.Name = "DETFAC_PRECIO_UNITARIO";
            this.DETFAC_PRECIO_UNITARIO.ReadOnly = true;
            this.DETFAC_PRECIO_UNITARIO.Visible = false;
            this.DETFAC_PRECIO_UNITARIO.Width = 125;
            // 
            // DETFAC_SUBTOTAL
            // 
            this.DETFAC_SUBTOTAL.DataPropertyName = "DETFAC_SUBTOTAL";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle45.Format = "###,###,##0.00";
            this.DETFAC_SUBTOTAL.DefaultCellStyle = dataGridViewCellStyle45;
            this.DETFAC_SUBTOTAL.HeaderText = "SUBTOTAL";
            this.DETFAC_SUBTOTAL.MinimumWidth = 6;
            this.DETFAC_SUBTOTAL.Name = "DETFAC_SUBTOTAL";
            this.DETFAC_SUBTOTAL.ReadOnly = true;
            this.DETFAC_SUBTOTAL.Width = 90;
            // 
            // detfac_descuento
            // 
            this.detfac_descuento.DataPropertyName = "detfac_descuento";
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.detfac_descuento.DefaultCellStyle = dataGridViewCellStyle46;
            this.detfac_descuento.HeaderText = "DESC";
            this.detfac_descuento.MinimumWidth = 6;
            this.detfac_descuento.Name = "detfac_descuento";
            this.detfac_descuento.ReadOnly = true;
            this.detfac_descuento.Width = 50;
            // 
            // DETFAC_TIPO
            // 
            this.DETFAC_TIPO.DataPropertyName = "DETFAC_TIPO";
            this.DETFAC_TIPO.HeaderText = "DETFAC_TIPO";
            this.DETFAC_TIPO.MinimumWidth = 6;
            this.DETFAC_TIPO.Name = "DETFAC_TIPO";
            this.DETFAC_TIPO.ReadOnly = true;
            this.DETFAC_TIPO.Visible = false;
            this.DETFAC_TIPO.Width = 125;
            // 
            // detfac_total
            // 
            this.detfac_total.DataPropertyName = "detfac_total";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.Format = "###,###,##0.00";
            this.detfac_total.DefaultCellStyle = dataGridViewCellStyle47;
            this.detfac_total.HeaderText = "TOTAL";
            this.detfac_total.MinimumWidth = 6;
            this.detfac_total.Name = "detfac_total";
            this.detfac_total.ReadOnly = true;
            this.detfac_total.Width = 90;
            // 
            // SER_impuestos
            // 
            this.SER_impuestos.DataPropertyName = "SER_impuestos";
            this.SER_impuestos.HeaderText = "SER_impuestos";
            this.SER_impuestos.MinimumWidth = 6;
            this.SER_impuestos.Name = "SER_impuestos";
            this.SER_impuestos.ReadOnly = true;
            this.SER_impuestos.Visible = false;
            this.SER_impuestos.Width = 125;
            // 
            // detfac_ivi
            // 
            this.detfac_ivi.DataPropertyName = "detfac_ivi";
            this.detfac_ivi.HeaderText = "detfac_ivi";
            this.detfac_ivi.MinimumWidth = 6;
            this.detfac_ivi.Name = "detfac_ivi";
            this.detfac_ivi.ReadOnly = true;
            this.detfac_ivi.Visible = false;
            this.detfac_ivi.Width = 125;
            // 
            // SER_TIPO_CODIGO
            // 
            this.SER_TIPO_CODIGO.DataPropertyName = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.HeaderText = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.MinimumWidth = 6;
            this.SER_TIPO_CODIGO.Name = "SER_TIPO_CODIGO";
            this.SER_TIPO_CODIGO.ReadOnly = true;
            this.SER_TIPO_CODIGO.Visible = false;
            this.SER_TIPO_CODIGO.Width = 125;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(740, 63);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 17);
            this.label25.TabIndex = 26;
            this.label25.Text = "Total";
            // 
            // txtTotalPorLinea
            // 
            this.txtTotalPorLinea.BackColor = System.Drawing.Color.Beige;
            this.txtTotalPorLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPorLinea.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPorLinea.Location = new System.Drawing.Point(740, 81);
            this.txtTotalPorLinea.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalPorLinea.Name = "txtTotalPorLinea";
            this.txtTotalPorLinea.PromptChar = ' ';
            this.txtTotalPorLinea.ReadOnly = true;
            this.txtTotalPorLinea.Size = new System.Drawing.Size(121, 23);
            this.txtTotalPorLinea.TabIndex = 5;
            this.txtTotalPorLinea.TabStop = false;
            this.txtTotalPorLinea.Text = "¢ 0.00";
            this.txtTotalPorLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPorLinea.Enter += new System.EventHandler(this.txtTotalPorLinea_Enter);
            this.txtTotalPorLinea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalPorLinea_KeyPress);
            this.txtTotalPorLinea.Leave += new System.EventHandler(this.txtTotalPorLinea_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(335, 63);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 17);
            this.label24.TabIndex = 24;
            this.label24.Text = "Precio Unitario";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.Beige;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(335, 81);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.ReadOnly = true;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(121, 23);
            this.txtPrecioUnitario.TabIndex = 4;
            this.txtPrecioUnitario.Text = "¢ 0.00";
            this.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioUnitario.Enter += new System.EventHandler(this.txtPrecioUnitario_Enter);
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            this.txtPrecioUnitario.Leave += new System.EventHandler(this.txtPrecioUnitario_Leave);
            // 
            // btnBusqServicio
            // 
            this.btnBusqServicio.ImageKey = "file_search.png";
            this.btnBusqServicio.ImageList = this.imageList2;
            this.btnBusqServicio.Location = new System.Drawing.Point(875, 28);
            this.btnBusqServicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusqServicio.Name = "btnBusqServicio";
            this.btnBusqServicio.Size = new System.Drawing.Size(80, 74);
            this.btnBusqServicio.TabIndex = 4;
            this.btnBusqServicio.TabStop = false;
            this.btnBusqServicio.UseVisualStyleBackColor = true;
            this.btnBusqServicio.Click += new System.EventHandler(this.btnBusqServicio_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(261, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "Servicio";
            // 
            // txtDescServicio
            // 
            this.txtDescServicio.BackColor = System.Drawing.Color.Beige;
            this.txtDescServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescServicio.ForeColor = System.Drawing.Color.Black;
            this.txtDescServicio.Location = new System.Drawing.Point(260, 36);
            this.txtDescServicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescServicio.Name = "txtDescServicio";
            this.txtDescServicio.ReadOnly = true;
            this.txtDescServicio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescServicio.Size = new System.Drawing.Size(601, 22);
            this.txtDescServicio.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 17);
            this.label19.TabIndex = 1;
            this.label19.Text = "Código";
            // 
            // txtCodServicio
            // 
            this.txtCodServicio.BackColor = System.Drawing.Color.White;
            this.txtCodServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodServicio.ForeColor = System.Drawing.Color.Black;
            this.txtCodServicio.Location = new System.Drawing.Point(12, 36);
            this.txtCodServicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodServicio.Name = "txtCodServicio";
            this.txtCodServicio.ReadOnly = true;
            this.txtCodServicio.Size = new System.Drawing.Size(237, 23);
            this.txtCodServicio.TabIndex = 2;
            this.txtCodServicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodServicio_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(436, 59);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 32);
            this.label15.TabIndex = 612;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(299, 59);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 32);
            this.label14.TabIndex = 611;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(64, 11);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 32);
            this.label13.TabIndex = 610;
            this.label13.Text = "*";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.Beige;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(419, 40);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(157, 24);
            this.txtEstado.TabIndex = 608;
            this.txtEstado.TabStop = false;
            this.txtEstado.Text = "ABIERTA";
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 609;
            this.label5.Text = "Estado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbContado);
            this.groupBox1.Controls.Add(this.rbCredito);
            this.groupBox1.Location = new System.Drawing.Point(682, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(111, 84);
            this.groupBox1.TabIndex = 610;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venta";
            // 
            // gbFormasPago
            // 
            this.gbFormasPago.Controls.Add(this.chkOtros);
            this.gbFormasPago.Controls.Add(this.chkEfectivo);
            this.gbFormasPago.Controls.Add(this.chkCheque);
            this.gbFormasPago.Controls.Add(this.chkTransferencia);
            this.gbFormasPago.Controls.Add(this.chkTarjeta);
            this.gbFormasPago.Controls.Add(this.chkTerceros);
            this.gbFormasPago.Controls.Add(this.label12);
            this.gbFormasPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFormasPago.Location = new System.Drawing.Point(799, 144);
            this.gbFormasPago.Margin = new System.Windows.Forms.Padding(4);
            this.gbFormasPago.Name = "gbFormasPago";
            this.gbFormasPago.Padding = new System.Windows.Forms.Padding(4);
            this.gbFormasPago.Size = new System.Drawing.Size(393, 84);
            this.gbFormasPago.TabIndex = 613;
            this.gbFormasPago.TabStop = false;
            this.gbFormasPago.Text = "Formas de Pago";
            // 
            // chkOtros
            // 
            this.chkOtros.AutoSize = true;
            this.chkOtros.Location = new System.Drawing.Point(98, 54);
            this.chkOtros.Name = "chkOtros";
            this.chkOtros.Size = new System.Drawing.Size(65, 21);
            this.chkOtros.TabIndex = 619;
            this.chkOtros.Text = "Otros";
            this.chkOtros.UseVisualStyleBackColor = true;
            // 
            // chkEfectivo
            // 
            this.chkEfectivo.AutoSize = true;
            this.chkEfectivo.Location = new System.Drawing.Point(12, 26);
            this.chkEfectivo.Name = "chkEfectivo";
            this.chkEfectivo.Size = new System.Drawing.Size(80, 21);
            this.chkEfectivo.TabIndex = 614;
            this.chkEfectivo.Text = "Efectivo";
            this.chkEfectivo.UseVisualStyleBackColor = true;
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Location = new System.Drawing.Point(12, 54);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(79, 21);
            this.chkCheque.TabIndex = 616;
            this.chkCheque.Text = "Cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            // 
            // chkTransferencia
            // 
            this.chkTransferencia.AutoSize = true;
            this.chkTransferencia.Location = new System.Drawing.Point(181, 26);
            this.chkTransferencia.Name = "chkTransferencia";
            this.chkTransferencia.Size = new System.Drawing.Size(202, 21);
            this.chkTransferencia.TabIndex = 617;
            this.chkTransferencia.Text = "Transferencia - dep. banco";
            this.chkTransferencia.UseVisualStyleBackColor = true;
            // 
            // chkTarjeta
            // 
            this.chkTarjeta.AutoSize = true;
            this.chkTarjeta.Location = new System.Drawing.Point(98, 26);
            this.chkTarjeta.Name = "chkTarjeta";
            this.chkTarjeta.Size = new System.Drawing.Size(75, 21);
            this.chkTarjeta.TabIndex = 615;
            this.chkTarjeta.Text = "Tarjeta";
            this.chkTarjeta.UseVisualStyleBackColor = true;
            // 
            // chkTerceros
            // 
            this.chkTerceros.AutoSize = true;
            this.chkTerceros.Location = new System.Drawing.Point(181, 54);
            this.chkTerceros.Name = "chkTerceros";
            this.chkTerceros.Size = new System.Drawing.Size(184, 21);
            this.chkTerceros.TabIndex = 618;
            this.chkTerceros.Text = "Recaudado por terceros";
            this.chkTerceros.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(119, -5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 32);
            this.label12.TabIndex = 616;
            this.label12.Text = "*";
            // 
            // gbDatosHacienda
            // 
            this.gbDatosHacienda.Controls.Add(this.pbFacturaElectronica);
            this.gbDatosHacienda.Controls.Add(this.lblMjFacturaElectronica);
            this.gbDatosHacienda.Controls.Add(this.label34);
            this.gbDatosHacienda.Controls.Add(this.btnFE_Comprobar_NC);
            this.gbDatosHacienda.Controls.Add(this.lblFE_Comprobacion_NC);
            this.gbDatosHacienda.Controls.Add(this.lblFE_Recepcion_NC);
            this.gbDatosHacienda.Controls.Add(this.label21);
            this.gbDatosHacienda.Controls.Add(this.label22);
            this.gbDatosHacienda.Controls.Add(this.txtFE_Clave_NC);
            this.gbDatosHacienda.Controls.Add(this.label23);
            this.gbDatosHacienda.Controls.Add(this.txtFE_Consecutivo_NC);
            this.gbDatosHacienda.Controls.Add(this.label26);
            this.gbDatosHacienda.Controls.Add(this.btnFE_Comprobar);
            this.gbDatosHacienda.Controls.Add(this.lblFE_Comprobacion);
            this.gbDatosHacienda.Controls.Add(this.lblFE_Recepcion);
            this.gbDatosHacienda.Controls.Add(this.label9);
            this.gbDatosHacienda.Controls.Add(this.label7);
            this.gbDatosHacienda.Controls.Add(this.txtFE_Clave);
            this.gbDatosHacienda.Controls.Add(this.label6);
            this.gbDatosHacienda.Controls.Add(this.txtFE_Consecutivo);
            this.gbDatosHacienda.Controls.Add(this.label1);
            this.gbDatosHacienda.Controls.Add(this.label35);
            this.gbDatosHacienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosHacienda.Location = new System.Drawing.Point(597, 9);
            this.gbDatosHacienda.Margin = new System.Windows.Forms.Padding(4);
            this.gbDatosHacienda.Name = "gbDatosHacienda";
            this.gbDatosHacienda.Padding = new System.Windows.Forms.Padding(4);
            this.gbDatosHacienda.Size = new System.Drawing.Size(595, 126);
            this.gbDatosHacienda.TabIndex = 614;
            this.gbDatosHacienda.TabStop = false;
            this.gbDatosHacienda.Text = "Datos Hacienda";
            // 
            // lblMjFacturaElectronica
            // 
            this.lblMjFacturaElectronica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMjFacturaElectronica.ForeColor = System.Drawing.Color.Red;
            this.lblMjFacturaElectronica.Location = new System.Drawing.Point(106, 86);
            this.lblMjFacturaElectronica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMjFacturaElectronica.Name = "lblMjFacturaElectronica";
            this.lblMjFacturaElectronica.Size = new System.Drawing.Size(397, 38);
            this.lblMjFacturaElectronica.TabIndex = 620;
            this.lblMjFacturaElectronica.Text = "Generando Factura Electrónica";
            this.lblMjFacturaElectronica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMjFacturaElectronica.Visible = false;
            // 
            // pbFacturaElectronica
            // 
            this.pbFacturaElectronica.Location = new System.Drawing.Point(143, 26);
            this.pbFacturaElectronica.Margin = new System.Windows.Forms.Padding(4);
            this.pbFacturaElectronica.Name = "pbFacturaElectronica";
            this.pbFacturaElectronica.Size = new System.Drawing.Size(321, 52);
            this.pbFacturaElectronica.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbFacturaElectronica.TabIndex = 615;
            this.pbFacturaElectronica.Visible = false;
            this.pbFacturaElectronica.VisibleChanged += new System.EventHandler(this.pbFacturaElectronica_VisibleChanged);
            // 
            // btnFE_Comprobar
            // 
            this.btnFE_Comprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFE_Comprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFE_Comprobar.ImageKey = "document.ico";
            this.btnFE_Comprobar.Location = new System.Drawing.Point(476, 20);
            this.btnFE_Comprobar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFE_Comprobar.Name = "btnFE_Comprobar";
            this.btnFE_Comprobar.Size = new System.Drawing.Size(107, 35);
            this.btnFE_Comprobar.TabIndex = 615;
            this.btnFE_Comprobar.Text = "Comprobar";
            this.btnFE_Comprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFE_Comprobar.UseVisualStyleBackColor = true;
            this.btnFE_Comprobar.Visible = false;
            this.btnFE_Comprobar.Click += new System.EventHandler(this.btnFE_Comprobar_Click);
            // 
            // lblFE_Comprobacion
            // 
            this.lblFE_Comprobacion.AutoSize = true;
            this.lblFE_Comprobacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFE_Comprobacion.Location = new System.Drawing.Point(403, 97);
            this.lblFE_Comprobacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFE_Comprobacion.Name = "lblFE_Comprobacion";
            this.lblFE_Comprobacion.Size = new System.Drawing.Size(0, 17);
            this.lblFE_Comprobacion.TabIndex = 619;
            // 
            // lblFE_Recepcion
            // 
            this.lblFE_Recepcion.AutoSize = true;
            this.lblFE_Recepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFE_Recepcion.Location = new System.Drawing.Point(137, 97);
            this.lblFE_Recepcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFE_Recepcion.Name = "lblFE_Recepcion";
            this.lblFE_Recepcion.Size = new System.Drawing.Size(0, 17);
            this.lblFE_Recepcion.TabIndex = 618;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(255, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 17);
            this.label9.TabIndex = 617;
            this.label9.Text = "Respuesta Hacienda:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 615;
            this.label7.Text = "Envío a Hacienda:";
            // 
            // txtFE_Clave
            // 
            this.txtFE_Clave.BackColor = System.Drawing.Color.Beige;
            this.txtFE_Clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Clave.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Clave.Location = new System.Drawing.Point(106, 61);
            this.txtFE_Clave.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Clave.Name = "txtFE_Clave";
            this.txtFE_Clave.ReadOnly = true;
            this.txtFE_Clave.Size = new System.Drawing.Size(477, 22);
            this.txtFE_Clave.TabIndex = 612;
            this.txtFE_Clave.TabStop = false;
            this.txtFE_Clave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 613;
            this.label6.Text = "Clave";
            // 
            // txtFE_Consecutivo
            // 
            this.txtFE_Consecutivo.BackColor = System.Drawing.Color.Beige;
            this.txtFE_Consecutivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Consecutivo.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Consecutivo.Location = new System.Drawing.Point(106, 27);
            this.txtFE_Consecutivo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Consecutivo.Name = "txtFE_Consecutivo";
            this.txtFE_Consecutivo.ReadOnly = true;
            this.txtFE_Consecutivo.Size = new System.Drawing.Size(358, 22);
            this.txtFE_Consecutivo.TabIndex = 610;
            this.txtFE_Consecutivo.TabStop = false;
            this.txtFE_Consecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 611;
            this.label1.Text = "Consecutivo";
            // 
            // btnFacturaAtras
            // 
            this.btnFacturaAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaAtras.ImageIndex = 1;
            this.btnFacturaAtras.ImageList = this.imageList2;
            this.btnFacturaAtras.Location = new System.Drawing.Point(286, 14);
            this.btnFacturaAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacturaAtras.Name = "btnFacturaAtras";
            this.btnFacturaAtras.Size = new System.Drawing.Size(54, 57);
            this.btnFacturaAtras.TabIndex = 612;
            this.btnFacturaAtras.TabStop = false;
            this.btnFacturaAtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturaAtras.UseVisualStyleBackColor = true;
            this.btnFacturaAtras.Click += new System.EventHandler(this.btnFacturaAtras_Click);
            // 
            // btnFacturaAdelante
            // 
            this.btnFacturaAdelante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaAdelante.ImageIndex = 2;
            this.btnFacturaAdelante.ImageList = this.imageList2;
            this.btnFacturaAdelante.Location = new System.Drawing.Point(346, 14);
            this.btnFacturaAdelante.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacturaAdelante.Name = "btnFacturaAdelante";
            this.btnFacturaAdelante.Size = new System.Drawing.Size(54, 57);
            this.btnFacturaAdelante.TabIndex = 611;
            this.btnFacturaAdelante.TabStop = false;
            this.btnFacturaAdelante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturaAdelante.UseVisualStyleBackColor = true;
            this.btnFacturaAdelante.Click += new System.EventHandler(this.btnFacturaAdelante_Click);
            // 
            // btnBFactura
            // 
            this.btnBFactura.ImageKey = "file_search.png";
            this.btnBFactura.ImageList = this.imageList2;
            this.btnBFactura.Location = new System.Drawing.Point(198, 14);
            this.btnBFactura.Margin = new System.Windows.Forms.Padding(4);
            this.btnBFactura.Name = "btnBFactura";
            this.btnBFactura.Size = new System.Drawing.Size(72, 57);
            this.btnBFactura.TabIndex = 3;
            this.btnBFactura.TabStop = false;
            this.btnBFactura.UseVisualStyleBackColor = true;
            this.btnBFactura.Click += new System.EventHandler(this.btnBusqFactura_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNueva.ImageKey = "document.ico";
            this.btnNueva.ImageList = this.imageList1;
            this.btnNueva.Location = new System.Drawing.Point(62, 90);
            this.btnNueva.Margin = new System.Windows.Forms.Padding(4);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(146, 42);
            this.btnNueva.TabIndex = 0;
            this.btnNueva.TabStop = false;
            this.btnNueva.Text = " Nueva";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBusqCliente
            // 
            this.btnBusqCliente.ImageKey = "file_search.png";
            this.btnBusqCliente.ImageList = this.imageList1;
            this.btnBusqCliente.Location = new System.Drawing.Point(140, 175);
            this.btnBusqCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusqCliente.Name = "btnBusqCliente";
            this.btnBusqCliente.Size = new System.Drawing.Size(40, 36);
            this.btnBusqCliente.TabIndex = 3;
            this.btnBusqCliente.TabStop = false;
            this.btnBusqCliente.UseVisualStyleBackColor = true;
            this.btnBusqCliente.Click += new System.EventHandler(this.btnBusqCliente_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.ImageKey = "Sign 06.ico";
            this.btnAnular.ImageList = this.imageList1;
            this.btnAnular.Location = new System.Drawing.Point(365, 90);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(146, 42);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.TabStop = false;
            this.btnAnular.Text = " Anular";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.ImageKey = "Disc 01.ico";
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(213, 90);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 42);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = " Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // timCreaFA
            // 
            this.timCreaFA.Tick += new System.EventHandler(this.timCreaFA_Tick);
            // 
            // timCompruebaFA
            // 
            this.timCompruebaFA.Tick += new System.EventHandler(this.timCompruebaFA_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(84, 153);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 32);
            this.label11.TabIndex = 615;
            this.label11.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(594, 158);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 20);
            this.label16.TabIndex = 617;
            this.label16.Text = "Moneda";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.BackColor = System.Drawing.Color.White;
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbMoneda.Items.AddRange(new object[] {
            "CRC",
            "USD"});
            this.cmbMoneda.Location = new System.Drawing.Point(592, 182);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(80, 24);
            this.cmbMoneda.TabIndex = 615;
            this.cmbMoneda.SelectedIndexChanged += new System.EventHandler(this.cmbMoneda_SelectedIndexChanged);
            // 
            // btnFE_Comprobar_NC
            // 
            this.btnFE_Comprobar_NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFE_Comprobar_NC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFE_Comprobar_NC.ImageKey = "document.ico";
            this.btnFE_Comprobar_NC.Location = new System.Drawing.Point(473, 153);
            this.btnFE_Comprobar_NC.Margin = new System.Windows.Forms.Padding(4);
            this.btnFE_Comprobar_NC.Name = "btnFE_Comprobar_NC";
            this.btnFE_Comprobar_NC.Size = new System.Drawing.Size(107, 35);
            this.btnFE_Comprobar_NC.TabIndex = 626;
            this.btnFE_Comprobar_NC.Text = "Comprobar";
            this.btnFE_Comprobar_NC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFE_Comprobar_NC.UseVisualStyleBackColor = true;
            this.btnFE_Comprobar_NC.Visible = false;
            this.btnFE_Comprobar_NC.Click += new System.EventHandler(this.btnFE_Comprobar_NC_Click);
            // 
            // lblFE_Comprobacion_NC
            // 
            this.lblFE_Comprobacion_NC.AutoSize = true;
            this.lblFE_Comprobacion_NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFE_Comprobacion_NC.Location = new System.Drawing.Point(400, 230);
            this.lblFE_Comprobacion_NC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFE_Comprobacion_NC.Name = "lblFE_Comprobacion_NC";
            this.lblFE_Comprobacion_NC.Size = new System.Drawing.Size(0, 17);
            this.lblFE_Comprobacion_NC.TabIndex = 630;
            // 
            // lblFE_Recepcion_NC
            // 
            this.lblFE_Recepcion_NC.AutoSize = true;
            this.lblFE_Recepcion_NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFE_Recepcion_NC.Location = new System.Drawing.Point(134, 230);
            this.lblFE_Recepcion_NC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFE_Recepcion_NC.Name = "lblFE_Recepcion_NC";
            this.lblFE_Recepcion_NC.Size = new System.Drawing.Size(0, 17);
            this.lblFE_Recepcion_NC.TabIndex = 629;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(252, 230);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 17);
            this.label21.TabIndex = 628;
            this.label21.Text = "Respuesta Hacienda:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 230);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 17);
            this.label22.TabIndex = 627;
            this.label22.Text = "Envío a Hacienda:";
            // 
            // txtFE_Clave_NC
            // 
            this.txtFE_Clave_NC.BackColor = System.Drawing.Color.Beige;
            this.txtFE_Clave_NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Clave_NC.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Clave_NC.Location = new System.Drawing.Point(103, 194);
            this.txtFE_Clave_NC.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Clave_NC.Name = "txtFE_Clave_NC";
            this.txtFE_Clave_NC.ReadOnly = true;
            this.txtFE_Clave_NC.Size = new System.Drawing.Size(477, 22);
            this.txtFE_Clave_NC.TabIndex = 623;
            this.txtFE_Clave_NC.TabStop = false;
            this.txtFE_Clave_NC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 197);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 17);
            this.label23.TabIndex = 624;
            this.label23.Text = "Clave";
            // 
            // txtFE_Consecutivo_NC
            // 
            this.txtFE_Consecutivo_NC.BackColor = System.Drawing.Color.Beige;
            this.txtFE_Consecutivo_NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFE_Consecutivo_NC.ForeColor = System.Drawing.Color.Black;
            this.txtFE_Consecutivo_NC.Location = new System.Drawing.Point(103, 160);
            this.txtFE_Consecutivo_NC.Margin = new System.Windows.Forms.Padding(4);
            this.txtFE_Consecutivo_NC.Name = "txtFE_Consecutivo_NC";
            this.txtFE_Consecutivo_NC.ReadOnly = true;
            this.txtFE_Consecutivo_NC.Size = new System.Drawing.Size(358, 22);
            this.txtFE_Consecutivo_NC.TabIndex = 621;
            this.txtFE_Consecutivo_NC.TabStop = false;
            this.txtFE_Consecutivo_NC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(8, 163);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 17);
            this.label26.TabIndex = 622;
            this.label26.Text = "Consecutivo";
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(21, 131);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(136, 19);
            this.label34.TabIndex = 632;
            this.label34.Text = "Nota de Crédito";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Location = new System.Drawing.Point(9, 143);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(577, 4);
            this.label35.TabIndex = 633;
            this.label35.Text = "label35";
            // 
            // timCompruebaNC
            // 
            this.timCompruebaNC.Tick += new System.EventHandler(this.timCompruebaNC_Tick);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 720);
            this.Controls.Add(this.gbDatosHacienda);
            this.Controls.Add(this.gbFormasPago);
            this.Controls.Add(this.btnFacturaAtras);
            this.Controls.Add(this.btnFacturaAdelante);
            this.Controls.Add(this.btnBFactura);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnBusqCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpDetalleFactura);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtANombreDe);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.label16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturacion_FormClosing);
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturacion_KeyDown);
            this.grpDetalleFactura.ResumeLayout(false);
            this.grpDetalleFactura.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFormasPago.ResumeLayout(false);
            this.gbFormasPago.PerformLayout();
            this.gbDatosHacienda.ResumeLayout(false);
            this.gbDatosHacienda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBusqCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtANombreDe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.GroupBox grpDetalleFactura;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridView dgrDatos;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.MaskedTextBox txtTotalPorLinea;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Button btnBusqServicio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDescServicio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCodServicio;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.TextBox txtPorcDecuento;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtTotalFactura;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtMontoIV;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtLineaDescuento;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.MaskedTextBox txtSubTotalLinea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnNuevoDetalle;
        private System.Windows.Forms.Button btnGuardarDetalle;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnFacturaAtras;
        private System.Windows.Forms.Button btnFacturaAdelante;
        private System.Windows.Forms.GroupBox gbFormasPago;
        private System.Windows.Forms.CheckBox chkOtros;
        private System.Windows.Forms.CheckBox chkEfectivo;
        private System.Windows.Forms.CheckBox chkCheque;
        private System.Windows.Forms.CheckBox chkTransferencia;
        private System.Windows.Forms.CheckBox chkTarjeta;
        private System.Windows.Forms.CheckBox chkTerceros;
        private System.Windows.Forms.GroupBox gbDatosHacienda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFE_Clave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFE_Consecutivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFE_Comprobacion;
        private System.Windows.Forms.Label lblFE_Recepcion;
        private System.Windows.Forms.Button btnFE_Comprobar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodCabys;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_numerolinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_cabys;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETFAC_MONTO_IV;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_medida;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETFAC_PRECIO_UNITARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETFAC_SUBTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETFAC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn detfac_ivi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SER_TIPO_CODIGO;
        private System.Windows.Forms.Timer timCreaFA;
        private System.Windows.Forms.Label lblMjFacturaElectronica;
        private System.Windows.Forms.ProgressBar pbFacturaElectronica;
        private System.Windows.Forms.Timer timCompruebaFA;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnFE_Comprobar_NC;
        private System.Windows.Forms.Label lblFE_Comprobacion_NC;
        private System.Windows.Forms.Label lblFE_Recepcion_NC;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFE_Clave_NC;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtFE_Consecutivo_NC;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Timer timCompruebaNC;
    }
}