namespace PROYECTO
{
    partial class frmTiposCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiposCambio));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDolar = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnObtenerTipoCambio = new System.Windows.Forms.Button();
            this.rboCompra = new System.Windows.Forms.RadioButton();
            this.rboVenta = new System.Windows.Forms.RadioButton();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMNuevo = new System.Windows.Forms.Button();
            this.tobSalir = new System.Windows.Forms.Button();
            this.btnMGuardar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 17);
            this.label1.TabIndex = 125;
            this.label1.Text = "Tipo de Cambio para el dolar   ¢";
            // 
            // txtDolar
            // 
            this.txtDolar.Location = new System.Drawing.Point(339, 105);
            this.txtDolar.Margin = new System.Windows.Forms.Padding(4);
            this.txtDolar.Name = "txtDolar";
            this.txtDolar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDolar.Size = new System.Drawing.Size(73, 22);
            this.txtDolar.TabIndex = 0;
            this.txtDolar.Text = "0";
            this.txtDolar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDolar_KeyPress);
            this.txtDolar.Leave += new System.EventHandler(this.txtDolar_Leave);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(452, 54);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 17);
            this.lblFecha.TabIndex = 130;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 28);
            this.button1.TabIndex = 131;
            this.button1.TabStop = false;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(384, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 28);
            this.button2.TabIndex = 132;
            this.button2.TabStop = false;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnObtenerTipoCambio
            // 
            this.btnObtenerTipoCambio.Location = new System.Drawing.Point(131, 180);
            this.btnObtenerTipoCambio.Margin = new System.Windows.Forms.Padding(4);
            this.btnObtenerTipoCambio.Name = "btnObtenerTipoCambio";
            this.btnObtenerTipoCambio.Size = new System.Drawing.Size(237, 52);
            this.btnObtenerTipoCambio.TabIndex = 139;
            this.btnObtenerTipoCambio.Text = "Obtener Tipo de Cambio BCCR";
            this.btnObtenerTipoCambio.UseVisualStyleBackColor = true;
            this.btnObtenerTipoCambio.Click += new System.EventHandler(this.btnObtenerTipoCambio_Click);
            // 
            // rboCompra
            // 
            this.rboCompra.AutoSize = true;
            this.rboCompra.Location = new System.Drawing.Point(172, 137);
            this.rboCompra.Margin = new System.Windows.Forms.Padding(4);
            this.rboCompra.Name = "rboCompra";
            this.rboCompra.Size = new System.Drawing.Size(78, 21);
            this.rboCompra.TabIndex = 140;
            this.rboCompra.TabStop = true;
            this.rboCompra.Text = "Compra";
            this.rboCompra.UseVisualStyleBackColor = true;
            this.rboCompra.CheckedChanged += new System.EventHandler(this.rboCompra_CheckedChanged);
            // 
            // rboVenta
            // 
            this.rboVenta.AutoSize = true;
            this.rboVenta.Location = new System.Drawing.Point(271, 137);
            this.rboVenta.Margin = new System.Windows.Forms.Padding(4);
            this.rboVenta.Name = "rboVenta";
            this.rboVenta.Size = new System.Drawing.Size(66, 21);
            this.rboVenta.TabIndex = 141;
            this.rboVenta.TabStop = true;
            this.rboVenta.Text = "Venta";
            this.rboVenta.UseVisualStyleBackColor = true;
            this.rboVenta.CheckedChanged += new System.EventHandler(this.rboVenta_CheckedChanged);
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
            this.groupBox2.Controls.Add(this.tobSalir);
            this.groupBox2.Controls.Add(this.btnMGuardar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(517, 85);
            this.groupBox2.TabIndex = 142;
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
            this.btnMNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // tobSalir
            // 
            this.tobSalir.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobSalir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobSalir.ImageKey = "salir2.ico";
            this.tobSalir.ImageList = this.imgMenu;
            this.tobSalir.Location = new System.Drawing.Point(348, 18);
            this.tobSalir.Margin = new System.Windows.Forms.Padding(4);
            this.tobSalir.Name = "tobSalir";
            this.tobSalir.Size = new System.Drawing.Size(147, 55);
            this.tobSalir.TabIndex = 15;
            this.tobSalir.Text = "Salir";
            this.tobSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobSalir.UseVisualStyleBackColor = true;
            this.tobSalir.Click += new System.EventHandler(this.tobSalir_Click);
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
            this.btnMGuardar.Click += new System.EventHandler(this.tobAgregar_Click);
            // 
            // frmTiposCambio
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(517, 284);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rboVenta);
            this.Controls.Add(this.rboCompra);
            this.Controls.Add(this.btnObtenerTipoCambio);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiposCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Cambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTiposCambio_FormClosing);
            this.Load += new System.EventHandler(this.frmTiposCambio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForma_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDolar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnObtenerTipoCambio;
        private System.Windows.Forms.RadioButton rboCompra;
        private System.Windows.Forms.RadioButton rboVenta;
        private System.Windows.Forms.ImageList imgMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMNuevo;
        private System.Windows.Forms.Button tobSalir;
        private System.Windows.Forms.Button btnMGuardar;
    }
}