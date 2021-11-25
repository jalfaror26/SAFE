namespace PROYECTO
{
    partial class frmrptEstadoCuentasClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptEstadoCuentasClientes));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkDias = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkClientes = new System.Windows.Forms.CheckBox();
            this.rboResumido = new System.Windows.Forms.RadioButton();
            this.rboDetallado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBusq2 = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.btnECliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document.ico");
            this.imageList1.Images.SetKeyName(1, "Sign 09.ico");
            this.imageList1.Images.SetKeyName(2, "Disc 01.ico");
            this.imageList1.Images.SetKeyName(3, "Sign 06.ico");
            this.imageList1.Images.SetKeyName(4, "services.ico");
            this.imageList1.Images.SetKeyName(5, "Aceptar.ico");
            this.imageList1.Images.SetKeyName(6, "Salir 2.ico");
            this.imageList1.Images.SetKeyName(7, "file_find.ico");
            this.imageList1.Images.SetKeyName(8, "C&M 17.ico");
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 6;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(385, 174);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(147, 39);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEjecutar.ImageIndex = 4;
            this.btnEjecutar.ImageList = this.imageList1;
            this.btnEjecutar.Location = new System.Drawing.Point(216, 174);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(147, 39);
            this.btnEjecutar.TabIndex = 20;
            this.btnEjecutar.Text = "&Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(216, 174);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(145, 39);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 350;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkDias
            // 
            this.chkDias.AutoSize = true;
            this.chkDias.Checked = true;
            this.chkDias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDias.Location = new System.Drawing.Point(16, 181);
            this.chkDias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDias.Name = "chkDias";
            this.chkDias.Size = new System.Drawing.Size(169, 21);
            this.chkDias.TabIndex = 351;
            this.chkDias.Text = " Agrupado por dias";
            this.chkDias.UseVisualStyleBackColor = true;
            this.chkDias.CheckedChanged += new System.EventHandler(this.chkDias_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkClientes);
            this.groupBox1.Controls.Add(this.rboResumido);
            this.groupBox1.Controls.Add(this.rboDetallado);
            this.groupBox1.Location = new System.Drawing.Point(51, 110);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(448, 57);
            this.groupBox1.TabIndex = 352;
            this.groupBox1.TabStop = false;
            // 
            // chkClientes
            // 
            this.chkClientes.AutoSize = true;
            this.chkClientes.Checked = true;
            this.chkClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClientes.Location = new System.Drawing.Point(319, 22);
            this.chkClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkClientes.Name = "chkClientes";
            this.chkClientes.Size = new System.Drawing.Size(93, 21);
            this.chkClientes.TabIndex = 353;
            this.chkClientes.Text = " Clientes";
            this.chkClientes.UseVisualStyleBackColor = true;
            this.chkClientes.Visible = false;
            this.chkClientes.CheckedChanged += new System.EventHandler(this.chkClientes_CheckedChanged);
            // 
            // rboResumido
            // 
            this.rboResumido.AutoSize = true;
            this.rboResumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboResumido.Location = new System.Drawing.Point(177, 21);
            this.rboResumido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rboResumido.Name = "rboResumido";
            this.rboResumido.Size = new System.Drawing.Size(110, 21);
            this.rboResumido.TabIndex = 1;
            this.rboResumido.Text = "RESUMIDO";
            this.rboResumido.UseVisualStyleBackColor = true;
            this.rboResumido.CheckedChanged += new System.EventHandler(this.rboResumido_CheckedChanged);
            // 
            // rboDetallado
            // 
            this.rboDetallado.AutoSize = true;
            this.rboDetallado.Checked = true;
            this.rboDetallado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboDetallado.Location = new System.Drawing.Point(24, 21);
            this.rboDetallado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rboDetallado.Name = "rboDetallado";
            this.rboDetallado.Size = new System.Drawing.Size(121, 21);
            this.rboDetallado.TabIndex = 0;
            this.rboDetallado.TabStop = true;
            this.rboDetallado.Text = "DETALLADO";
            this.rboDetallado.UseVisualStyleBackColor = true;
            this.rboDetallado.CheckedChanged += new System.EventHandler(this.rboDetallado_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(137, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 357;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(19, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 356;
            this.label4.Text = "Cliente";
            // 
            // btnBusq2
            // 
            this.btnBusq2.Image = ((System.Drawing.Image)(resources.GetObject("btnBusq2.Image")));
            this.btnBusq2.Location = new System.Drawing.Point(95, 30);
            this.btnBusq2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusq2.Name = "btnBusq2";
            this.btnBusq2.Size = new System.Drawing.Size(36, 32);
            this.btnBusq2.TabIndex = 353;
            this.btnBusq2.UseVisualStyleBackColor = true;
            this.btnBusq2.Click += new System.EventHandler(this.btnBusq2_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Beige;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(137, 33);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(359, 23);
            this.txtNombre.TabIndex = 355;
            this.txtNombre.TabStop = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.Beige;
            this.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtIdCliente.Location = new System.Drawing.Point(13, 33);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(75, 23);
            this.txtIdCliente.TabIndex = 354;
            this.txtIdCliente.TabStop = false;
            // 
            // btnECliente
            // 
            this.btnECliente.ImageKey = "Sign 06.ico";
            this.btnECliente.ImageList = this.imageList1;
            this.btnECliente.Location = new System.Drawing.Point(503, 30);
            this.btnECliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnECliente.Name = "btnECliente";
            this.btnECliente.Size = new System.Drawing.Size(36, 32);
            this.btnECliente.TabIndex = 358;
            this.btnECliente.UseVisualStyleBackColor = true;
            this.btnECliente.Click += new System.EventHandler(this.btnECliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(19, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 359;
            this.label1.Text = "Nota: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(76, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 32);
            this.label2.TabIndex = 360;
            this.label2.Text = "Si se selecciona cliente NO se mostrara el % que representa\r\ndel total de las CxC" +
    ".";
            // 
            // frmrptEstadoCuentasClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnECliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBusq2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkDias);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrptEstadoCuentasClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado de Cuenta por Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmrptSaldosFacturas_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkDias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboResumido;
        private System.Windows.Forms.RadioButton rboDetallado;
        private System.Windows.Forms.CheckBox chkClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBusq2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Button btnECliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}