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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiposCambio));
            this.toolBarraBotones = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.tobAgregar = new System.Windows.Forms.ToolStripButton();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.tssSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tobSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDolar = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnObtenerTipoCambio = new System.Windows.Forms.Button();
            this.rboCompra = new System.Windows.Forms.RadioButton();
            this.rboVenta = new System.Windows.Forms.RadioButton();
            this.toolBarraBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarraBotones
            // 
            this.toolBarraBotones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBarraBotones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBarraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.tobAgregar,
            this.tobModificar,
            this.tssSeparador,
            this.tobSalir});
            this.toolBarraBotones.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolBarraBotones.Location = new System.Drawing.Point(0, 0);
            this.toolBarraBotones.Name = "toolBarraBotones";
            this.toolBarraBotones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolBarraBotones.Size = new System.Drawing.Size(373, 44);
            this.toolBarraBotones.TabIndex = 123;
            this.toolBarraBotones.Text = "Barra de Botones";
            // 
            // tobNuevo
            // 
            this.tobNuevo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tobNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tobNuevo.Image")));
            this.tobNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.Size = new System.Drawing.Size(62, 41);
            this.tobNuevo.Text = "Limpiar";
            this.tobNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobNuevo.ToolTipText = "Nuevo registro...";
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // tobAgregar
            // 
            this.tobAgregar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tobAgregar.Image = ((System.Drawing.Image)(resources.GetObject("tobAgregar.Image")));
            this.tobAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobAgregar.Name = "tobAgregar";
            this.tobAgregar.Size = new System.Drawing.Size(68, 41);
            this.tobAgregar.Text = "Agregar";
            this.tobAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobAgregar.ToolTipText = "Agregar registro...";
            this.tobAgregar.Click += new System.EventHandler(this.tobAgregar_Click);
            // 
            // tobModificar
            // 
            this.tobModificar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tobModificar.Image = ((System.Drawing.Image)(resources.GetObject("tobModificar.Image")));
            this.tobModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(74, 41);
            this.tobModificar.Text = "Modificar";
            this.tobModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobModificar.ToolTipText = "Modificar registro...";
            this.tobModificar.Visible = false;
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // tssSeparador
            // 
            this.tssSeparador.Name = "tssSeparador";
            this.tssSeparador.Size = new System.Drawing.Size(6, 44);
            this.tssSeparador.Visible = false;
            // 
            // tobSalir
            // 
            this.tobSalir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tobSalir.Image = ((System.Drawing.Image)(resources.GetObject("tobSalir.Image")));
            this.tobSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSalir.Name = "tobSalir";
            this.tobSalir.Size = new System.Drawing.Size(41, 41);
            this.tobSalir.Text = "Salir";
            this.tobSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobSalir.ToolTipText = "Salir del mantenimiento...";
            this.tobSalir.Visible = false;
            this.tobSalir.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 17);
            this.label1.TabIndex = 125;
            this.label1.Text = "Tipo de Cambio para el dolar   ¢";
            // 
            // txtDolar
            // 
            this.txtDolar.Location = new System.Drawing.Point(276, 62);
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
            this.lblFecha.Location = new System.Drawing.Point(389, 11);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 17);
            this.lblFecha.TabIndex = 130;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 5);
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
            this.button2.Location = new System.Drawing.Point(321, 5);
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
            this.btnObtenerTipoCambio.Location = new System.Drawing.Point(68, 124);
            this.btnObtenerTipoCambio.Margin = new System.Windows.Forms.Padding(4);
            this.btnObtenerTipoCambio.Name = "btnObtenerTipoCambio";
            this.btnObtenerTipoCambio.Size = new System.Drawing.Size(237, 36);
            this.btnObtenerTipoCambio.TabIndex = 139;
            this.btnObtenerTipoCambio.Text = "Obtener Tipos de Cambio BCCR";
            this.btnObtenerTipoCambio.UseVisualStyleBackColor = true;
            this.btnObtenerTipoCambio.Click += new System.EventHandler(this.btnObtenerTipoCambio_Click);
            // 
            // rboCompra
            // 
            this.rboCompra.AutoSize = true;
            this.rboCompra.Location = new System.Drawing.Point(109, 94);
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
            this.rboVenta.Location = new System.Drawing.Point(208, 94);
            this.rboVenta.Margin = new System.Windows.Forms.Padding(4);
            this.rboVenta.Name = "rboVenta";
            this.rboVenta.Size = new System.Drawing.Size(66, 21);
            this.rboVenta.TabIndex = 141;
            this.rboVenta.TabStop = true;
            this.rboVenta.Text = "Venta";
            this.rboVenta.UseVisualStyleBackColor = true;
            this.rboVenta.CheckedChanged += new System.EventHandler(this.rboVenta_CheckedChanged);
            // 
            // frmTiposCambio
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(373, 208);
            this.ControlBox = false;
            this.Controls.Add(this.rboVenta);
            this.Controls.Add(this.rboCompra);
            this.Controls.Add(this.btnObtenerTipoCambio);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBarraBotones);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiposCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de Cambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTiposCambio_FormClosing);
            this.Load += new System.EventHandler(this.frmTiposCambio_Load);
            this.toolBarraBotones.ResumeLayout(false);
            this.toolBarraBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBarraBotones;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripButton tobAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDolar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator tssSeparador;
        private System.Windows.Forms.ToolStripButton tobSalir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnObtenerTipoCambio;
        private System.Windows.Forms.RadioButton rboCompra;
        private System.Windows.Forms.RadioButton rboVenta;
    }
}