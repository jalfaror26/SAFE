namespace PROYECTO
{
    partial class frmPagosProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosProveedores));
            this.txtfechaactual = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtCodProveedor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMontoGuia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGuiaPago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoGasto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.txtDetalleComprobante = new System.Windows.Forms.TextBox();
            this.lblDetalleComprobante = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMontoenLetras = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtfechaactual
            // 
            this.txtfechaactual.BackColor = System.Drawing.Color.Beige;
            this.txtfechaactual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfechaactual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfechaactual.ForeColor = System.Drawing.Color.Black;
            this.txtfechaactual.Location = new System.Drawing.Point(595, 28);
            this.txtfechaactual.Margin = new System.Windows.Forms.Padding(4);
            this.txtfechaactual.Name = "txtfechaactual";
            this.txtfechaactual.ReadOnly = true;
            this.txtfechaactual.Size = new System.Drawing.Size(111, 23);
            this.txtfechaactual.TabIndex = 395;
            this.txtfechaactual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.Beige;
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtProveedor.Location = new System.Drawing.Point(175, 28);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(309, 23);
            this.txtProveedor.TabIndex = 392;
            // 
            // txtCodProveedor
            // 
            this.txtCodProveedor.BackColor = System.Drawing.Color.Beige;
            this.txtCodProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtCodProveedor.Location = new System.Drawing.Point(19, 28);
            this.txtCodProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodProveedor.Name = "txtCodProveedor";
            this.txtCodProveedor.ReadOnly = true;
            this.txtCodProveedor.Size = new System.Drawing.Size(145, 23);
            this.txtCodProveedor.TabIndex = 391;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(591, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 394;
            this.label11.Text = "Fecha Actual";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 393;
            this.label8.Text = "Proveedor";
            // 
            // txtMontoGuia
            // 
            this.txtMontoGuia.BackColor = System.Drawing.Color.Beige;
            this.txtMontoGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoGuia.ForeColor = System.Drawing.Color.Black;
            this.txtMontoGuia.Location = new System.Drawing.Point(239, 86);
            this.txtMontoGuia.Margin = new System.Windows.Forms.Padding(4);
            this.txtMontoGuia.Name = "txtMontoGuia";
            this.txtMontoGuia.ReadOnly = true;
            this.txtMontoGuia.Size = new System.Drawing.Size(133, 23);
            this.txtMontoGuia.TabIndex = 398;
            this.txtMontoGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 399;
            this.label2.Text = "Monto de la Guía";
            // 
            // txtGuiaPago
            // 
            this.txtGuiaPago.BackColor = System.Drawing.Color.Beige;
            this.txtGuiaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuiaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuiaPago.ForeColor = System.Drawing.Color.Black;
            this.txtGuiaPago.Location = new System.Drawing.Point(19, 86);
            this.txtGuiaPago.Margin = new System.Windows.Forms.Padding(4);
            this.txtGuiaPago.Name = "txtGuiaPago";
            this.txtGuiaPago.ReadOnly = true;
            this.txtGuiaPago.Size = new System.Drawing.Size(107, 23);
            this.txtGuiaPago.TabIndex = 396;
            this.txtGuiaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 397;
            this.label1.Text = "Guía de Pago";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.Color.Beige;
            this.txtMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.ForeColor = System.Drawing.Color.Black;
            this.txtMoneda.Location = new System.Drawing.Point(149, 86);
            this.txtMoneda.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(64, 23);
            this.txtMoneda.TabIndex = 401;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(145, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 400;
            this.label6.Text = "Moneda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 403;
            this.label3.Text = "Tipo de Gasto";
            // 
            // cboTipoGasto
            // 
            this.cboTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoGasto.FormattingEnabled = true;
            this.cboTipoGasto.Location = new System.Drawing.Point(339, 161);
            this.cboTipoGasto.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoGasto.Name = "cboTipoGasto";
            this.cboTipoGasto.Size = new System.Drawing.Size(353, 25);
            this.cboTipoGasto.TabIndex = 402;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 405;
            this.label4.Text = "Forma de Pago";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA",
            "TRANSFERENCIA",
            "SINPE MOVIL"});
            this.cboFormaPago.Location = new System.Drawing.Point(45, 161);
            this.cboFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(212, 25);
            this.cboFormaPago.TabIndex = 404;
            // 
            // txtDetalleComprobante
            // 
            this.txtDetalleComprobante.BackColor = System.Drawing.Color.White;
            this.txtDetalleComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalleComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleComprobante.Location = new System.Drawing.Point(25, 284);
            this.txtDetalleComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetalleComprobante.Multiline = true;
            this.txtDetalleComprobante.Name = "txtDetalleComprobante";
            this.txtDetalleComprobante.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleComprobante.Size = new System.Drawing.Size(696, 91);
            this.txtDetalleComprobante.TabIndex = 407;
            // 
            // lblDetalleComprobante
            // 
            this.lblDetalleComprobante.AutoSize = true;
            this.lblDetalleComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleComprobante.Location = new System.Drawing.Point(21, 264);
            this.lblDetalleComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetalleComprobante.Name = "lblDetalleComprobante";
            this.lblDetalleComprobante.Size = new System.Drawing.Size(160, 17);
            this.lblDetalleComprobante.TabIndex = 408;
            this.lblDetalleComprobante.Text = "Detalle Comprobante";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 203);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 17);
            this.label13.TabIndex = 409;
            this.label13.Text = "Monto en Letras de la Guía";
            // 
            // lblMontoenLetras
            // 
            this.lblMontoenLetras.AutoSize = true;
            this.lblMontoenLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoenLetras.ForeColor = System.Drawing.Color.Navy;
            this.lblMontoenLetras.Location = new System.Drawing.Point(41, 230);
            this.lblMontoenLetras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoenLetras.Name = "lblMontoenLetras";
            this.lblMontoenLetras.Size = new System.Drawing.Size(58, 17);
            this.lblMontoenLetras.TabIndex = 410;
            this.lblMontoenLetras.Text = "00/100";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 4;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(595, 395);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 36);
            this.btnSalir.TabIndex = 412;
            this.btnSalir.Text = " &Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.imageList2.Images.SetKeyName(7, "Sign 08.ico");
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageIndex = 7;
            this.btnAceptar.ImageList = this.imageList2;
            this.btnAceptar.Location = new System.Drawing.Point(447, 395);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(128, 37);
            this.btnAceptar.TabIndex = 411;
            this.btnAceptar.Text = " &Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(161, 400);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(277, 32);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 492;
            this.progressBar1.Visible = false;
            // 
            // frmPagosProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 457);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMontoenLetras);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDetalleComprobante);
            this.Controls.Add(this.lblDetalleComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoGasto);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMontoGuia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGuiaPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfechaactual);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.txtCodProveedor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagosProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación de Pago";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPagosProveedores_FormClosing);
            this.Load += new System.EventHandler(this.frmPagosProveedores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfechaactual;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtCodProveedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMontoGuia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGuiaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoGasto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.TextBox txtDetalleComprobante;
        private System.Windows.Forms.Label lblDetalleComprobante;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMontoenLetras;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}