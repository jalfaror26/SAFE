namespace PROYECTO
{
    partial class frmFacturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturar));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rboEfectivo = new System.Windows.Forms.RadioButton();
            this.rboTarjeta = new System.Windows.Forms.RadioButton();
            this.rboCheque = new System.Windows.Forms.RadioButton();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAnombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.rboPagaDolares = new System.Windows.Forms.RadioButton();
            this.rboPagaColones = new System.Windows.Forms.RadioButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnFacturar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file_find.ico");
            this.imageList1.Images.SetKeyName(1, "C&M 17.ico");
            this.imageList1.Images.SetKeyName(2, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(3, "Consultar.ico");
            this.imageList1.Images.SetKeyName(4, "services.ico");
            this.imageList1.Images.SetKeyName(5, "File 07.ico");
            this.imageList1.Images.SetKeyName(6, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(7, "document.ico");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(603, 133);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(247, 47);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 518;
            this.progressBar1.Visible = false;
            // 
            // lblVuelto
            // 
            this.lblVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.ForeColor = System.Drawing.Color.Red;
            this.lblVuelto.Location = new System.Drawing.Point(3, 476);
            this.lblVuelto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(904, 134);
            this.lblVuelto.TabIndex = 514;
            this.lblVuelto.Text = "¢ 0";
            this.lblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblFecha.Location = new System.Drawing.Point(741, 26);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(90, 25);
            this.lblFecha.TabIndex = 500;
            this.lblFecha.Text = "--/--/----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(641, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 499;
            this.label6.Text = "Fecha: ";
            // 
            // rboEfectivo
            // 
            this.rboEfectivo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rboEfectivo.Checked = true;
            this.rboEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboEfectivo.Location = new System.Drawing.Point(16, 26);
            this.rboEfectivo.Margin = new System.Windows.Forms.Padding(4);
            this.rboEfectivo.Name = "rboEfectivo";
            this.rboEfectivo.Size = new System.Drawing.Size(153, 39);
            this.rboEfectivo.TabIndex = 2;
            this.rboEfectivo.TabStop = true;
            this.rboEfectivo.Text = "F1 - EFECTIVO";
            this.rboEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rboEfectivo.UseVisualStyleBackColor = true;
            this.rboEfectivo.CheckedChanged += new System.EventHandler(this.rboEfectivo_CheckedChanged);
            // 
            // rboTarjeta
            // 
            this.rboTarjeta.Appearance = System.Windows.Forms.Appearance.Button;
            this.rboTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboTarjeta.Location = new System.Drawing.Point(180, 26);
            this.rboTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.rboTarjeta.Name = "rboTarjeta";
            this.rboTarjeta.Size = new System.Drawing.Size(153, 39);
            this.rboTarjeta.TabIndex = 3;
            this.rboTarjeta.TabStop = true;
            this.rboTarjeta.Text = "F2 - TARJETA";
            this.rboTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rboTarjeta.UseVisualStyleBackColor = true;
            this.rboTarjeta.CheckedChanged += new System.EventHandler(this.rboTarjeta_CheckedChanged);
            // 
            // rboCheque
            // 
            this.rboCheque.Appearance = System.Windows.Forms.Appearance.Button;
            this.rboCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboCheque.Location = new System.Drawing.Point(347, 26);
            this.rboCheque.Margin = new System.Windows.Forms.Padding(4);
            this.rboCheque.Name = "rboCheque";
            this.rboCheque.Size = new System.Drawing.Size(153, 39);
            this.rboCheque.TabIndex = 4;
            this.rboCheque.TabStop = true;
            this.rboCheque.Text = "F3 - SINPE M.";
            this.rboCheque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rboCheque.UseVisualStyleBackColor = true;
            this.rboCheque.CheckedChanged += new System.EventHandler(this.rboCheque_CheckedChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rboCheque);
            this.gb1.Controls.Add(this.rboTarjeta);
            this.gb1.Controls.Add(this.rboEfectivo);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(48, 116);
            this.gb1.Margin = new System.Windows.Forms.Padding(4);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4);
            this.gb1.Size = new System.Drawing.Size(513, 75);
            this.gb1.TabIndex = 501;
            this.gb1.TabStop = false;
            this.gb1.Text = "FORMA DE PAGO";
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.ForeColor = System.Drawing.Color.Maroon;
            this.lblFactura.Location = new System.Drawing.Point(189, 26);
            this.lblFactura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(24, 25);
            this.lblFactura.TabIndex = 505;
            this.lblFactura.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 25);
            this.label7.TabIndex = 504;
            this.label7.Text = "Nº Factura:";
            // 
            // txtAnombre
            // 
            this.txtAnombre.Location = new System.Drawing.Point(48, 79);
            this.txtAnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnombre.Name = "txtAnombre";
            this.txtAnombre.Size = new System.Drawing.Size(600, 22);
            this.txtAnombre.TabIndex = 1;
            this.txtAnombre.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 59);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 513;
            this.label10.Text = "A nombre de:";
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagaCon.Location = new System.Drawing.Point(327, 143);
            this.txtPagaCon.Margin = new System.Windows.Forms.Padding(4);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(227, 36);
            this.txtPagaCon.TabIndex = 5;
            this.txtPagaCon.Text = "¢ 0";
            this.txtPagaCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPagaCon.TextChanged += new System.EventHandler(this.txtPagaCon_TextChanged);
            this.txtPagaCon.Enter += new System.EventHandler(this.txtPagaCon_Enter);
            this.txtPagaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagaCon_KeyPress);
            this.txtPagaCon.Leave += new System.EventHandler(this.txtPagaCon_Leave);
            // 
            // txtVuelto
            // 
            this.txtVuelto.Location = new System.Drawing.Point(203, 219);
            this.txtVuelto.Margin = new System.Windows.Forms.Padding(4);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(177, 23);
            this.txtVuelto.TabIndex = 6;
            this.txtVuelto.TabStop = false;
            this.txtVuelto.Text = "¢ 0";
            this.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVuelto.TextChanged += new System.EventHandler(this.txtVuelto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "PAGA CON:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "VUELTO:";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Enabled = false;
            this.txtComprobante.Location = new System.Drawing.Point(431, 219);
            this.txtComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(177, 23);
            this.txtComprobante.TabIndex = 7;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(435, 194);
            this.lblComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(131, 17);
            this.lblComprobante.TabIndex = 7;
            this.lblComprobante.Text = "COMPROBANTE:";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.txtMonto);
            this.gb2.Controls.Add(this.rboPagaDolares);
            this.gb2.Controls.Add(this.rboPagaColones);
            this.gb2.Controls.Add(this.lblComprobante);
            this.gb2.Controls.Add(this.txtComprobante);
            this.gb2.Controls.Add(this.label3);
            this.gb2.Controls.Add(this.label2);
            this.gb2.Controls.Add(this.txtVuelto);
            this.gb2.Controls.Add(this.txtPagaCon);
            this.gb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb2.Location = new System.Drawing.Point(48, 226);
            this.gb2.Margin = new System.Windows.Forms.Padding(4);
            this.gb2.Name = "gb2";
            this.gb2.Padding = new System.Windows.Forms.Padding(4);
            this.gb2.Size = new System.Drawing.Size(815, 258);
            this.gb2.TabIndex = 502;
            this.gb2.TabStop = false;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Beige;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.Black;
            this.txtMonto.Location = new System.Drawing.Point(56, 22);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(703, 98);
            this.txtMonto.TabIndex = 573;
            this.txtMonto.TabStop = false;
            this.txtMonto.Text = "¢ 0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rboPagaDolares
            // 
            this.rboPagaDolares.Appearance = System.Windows.Forms.Appearance.Button;
            this.rboPagaDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPagaDolares.Location = new System.Drawing.Point(624, 142);
            this.rboPagaDolares.Margin = new System.Windows.Forms.Padding(4);
            this.rboPagaDolares.Name = "rboPagaDolares";
            this.rboPagaDolares.Size = new System.Drawing.Size(40, 37);
            this.rboPagaDolares.TabIndex = 9;
            this.rboPagaDolares.Text = "$";
            this.rboPagaDolares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rboPagaDolares.UseVisualStyleBackColor = true;
            this.rboPagaDolares.CheckedChanged += new System.EventHandler(this.rboPagaDolares_CheckedChanged);
            // 
            // rboPagaColones
            // 
            this.rboPagaColones.Appearance = System.Windows.Forms.Appearance.Button;
            this.rboPagaColones.Checked = true;
            this.rboPagaColones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPagaColones.Location = new System.Drawing.Point(579, 142);
            this.rboPagaColones.Margin = new System.Windows.Forms.Padding(4);
            this.rboPagaColones.Name = "rboPagaColones";
            this.rboPagaColones.Size = new System.Drawing.Size(40, 37);
            this.rboPagaColones.TabIndex = 8;
            this.rboPagaColones.TabStop = true;
            this.rboPagaColones.Text = "¢";
            this.rboPagaColones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rboPagaColones.UseVisualStyleBackColor = true;
            this.rboPagaColones.CheckedChanged += new System.EventHandler(this.rboPagaColones_CheckedChanged);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "App 17.ico");
            this.imageList2.Images.SetKeyName(1, "Sign 25.ico");
            this.imageList2.Images.SetKeyName(2, "Sign 26.ico");
            this.imageList2.Images.SetKeyName(3, "facturar.png");
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturar.ImageKey = "facturar.png";
            this.btnFacturar.ImageList = this.imageList2;
            this.btnFacturar.Location = new System.Drawing.Point(589, 123);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(273, 68);
            this.btnFacturar.TabIndex = 515;
            this.btnFacturar.TabStop = false;
            this.btnFacturar.Text = " F4 - Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 607);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAnombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblVuelto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFacturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturar_FormClosing);
            this.Load += new System.EventHandler(this.frmFacturar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturar_KeyDown);
            this.gb1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rboEfectivo;
        private System.Windows.Forms.RadioButton rboTarjeta;
        private System.Windows.Forms.RadioButton rboCheque;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAnombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.RadioButton rboPagaColones;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rboPagaDolares;
    }
}