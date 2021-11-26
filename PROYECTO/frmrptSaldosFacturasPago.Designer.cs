namespace PROYECTO
{
    partial class frmrptSaldosFacturasPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptSaldosFacturasPago));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCompras = new System.Windows.Forms.RadioButton();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGasto = new System.Windows.Forms.TextBox();
            this.txtIdGasto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDetallado = new System.Windows.Forms.RadioButton();
            this.rbResumido = new System.Windows.Forms.RadioButton();
            this.btnBusqGasto = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.chkVerCategoria = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(5, "Sign 08.ico");
            this.imageList1.Images.SetKeyName(6, "Salir.ico");
            this.imageList1.Images.SetKeyName(7, "file_find.ico");
            this.imageList1.Images.SetKeyName(8, "C&M 17.ico");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(69, 165);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 350;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkVerCategoria);
            this.groupBox1.Controls.Add(this.rbCompras);
            this.groupBox1.Controls.Add(this.rbTodo);
            this.groupBox1.Location = new System.Drawing.Point(16, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(348, 70);
            this.groupBox1.TabIndex = 351;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Reporte";
            // 
            // rbCompras
            // 
            this.rbCompras.AutoSize = true;
            this.rbCompras.Location = new System.Drawing.Point(85, 28);
            this.rbCompras.Margin = new System.Windows.Forms.Padding(4);
            this.rbCompras.Name = "rbCompras";
            this.rbCompras.Size = new System.Drawing.Size(117, 21);
            this.rbCompras.TabIndex = 2;
            this.rbCompras.Text = "Solo Compras";
            this.rbCompras.UseVisualStyleBackColor = true;
            this.rbCompras.CheckedChanged += new System.EventHandler(this.rbCompras_CheckedChanged);
            this.rbCompras.Click += new System.EventHandler(this.rbCompras_Click);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Checked = true;
            this.rbTodo.Location = new System.Drawing.Point(15, 28);
            this.rbTodo.Margin = new System.Windows.Forms.Padding(4);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(62, 21);
            this.rbTodo.TabIndex = 0;
            this.rbTodo.TabStop = true;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.Click += new System.EventHandler(this.rbTodo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 384;
            this.label5.Text = "Categoría";
            // 
            // txtGasto
            // 
            this.txtGasto.BackColor = System.Drawing.Color.Beige;
            this.txtGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasto.ForeColor = System.Drawing.Color.Black;
            this.txtGasto.Location = new System.Drawing.Point(195, 37);
            this.txtGasto.Margin = new System.Windows.Forms.Padding(4);
            this.txtGasto.Name = "txtGasto";
            this.txtGasto.ReadOnly = true;
            this.txtGasto.Size = new System.Drawing.Size(363, 23);
            this.txtGasto.TabIndex = 383;
            this.txtGasto.TabStop = false;
            // 
            // txtIdGasto
            // 
            this.txtIdGasto.BackColor = System.Drawing.Color.Beige;
            this.txtIdGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdGasto.ForeColor = System.Drawing.Color.Black;
            this.txtIdGasto.Location = new System.Drawing.Point(16, 37);
            this.txtIdGasto.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdGasto.Name = "txtIdGasto";
            this.txtIdGasto.ReadOnly = true;
            this.txtIdGasto.Size = new System.Drawing.Size(127, 23);
            this.txtIdGasto.TabIndex = 382;
            this.txtIdGasto.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDetallado);
            this.groupBox2.Controls.Add(this.rbResumido);
            this.groupBox2.Location = new System.Drawing.Point(373, 70);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(217, 70);
            this.groupBox2.TabIndex = 352;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Reporte";
            // 
            // rbDetallado
            // 
            this.rbDetallado.AutoSize = true;
            this.rbDetallado.Location = new System.Drawing.Point(116, 28);
            this.rbDetallado.Margin = new System.Windows.Forms.Padding(4);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(89, 21);
            this.rbDetallado.TabIndex = 1;
            this.rbDetallado.Text = "Detallado";
            this.rbDetallado.UseVisualStyleBackColor = true;
            // 
            // rbResumido
            // 
            this.rbResumido.AutoSize = true;
            this.rbResumido.Checked = true;
            this.rbResumido.Location = new System.Drawing.Point(15, 28);
            this.rbResumido.Margin = new System.Windows.Forms.Padding(4);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(92, 21);
            this.rbResumido.TabIndex = 0;
            this.rbResumido.TabStop = true;
            this.rbResumido.Text = "Resumido";
            this.rbResumido.UseVisualStyleBackColor = true;
            // 
            // btnBusqGasto
            // 
            this.btnBusqGasto.Enabled = false;
            this.btnBusqGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnBusqGasto.Image")));
            this.btnBusqGasto.Location = new System.Drawing.Point(152, 33);
            this.btnBusqGasto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusqGasto.Name = "btnBusqGasto";
            this.btnBusqGasto.Size = new System.Drawing.Size(35, 30);
            this.btnBusqGasto.TabIndex = 381;
            this.btnBusqGasto.UseVisualStyleBackColor = true;
            this.btnBusqGasto.Click += new System.EventHandler(this.btnBusqGasto_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageIndex = 6;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(451, 160);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 34);
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
            this.btnEjecutar.Location = new System.Drawing.Point(303, 160);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(140, 34);
            this.btnEjecutar.TabIndex = 20;
            this.btnEjecutar.Text = "&Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Location = new System.Drawing.Point(568, 41);
            this.chkCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(18, 17);
            this.chkCategoria.TabIndex = 385;
            this.chkCategoria.UseVisualStyleBackColor = true;
            this.chkCategoria.CheckedChanged += new System.EventHandler(this.chkCategoria_CheckedChanged);
            // 
            // chkVerCategoria
            // 
            this.chkVerCategoria.AutoSize = true;
            this.chkVerCategoria.Location = new System.Drawing.Point(217, 29);
            this.chkVerCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.chkVerCategoria.Name = "chkVerCategoria";
            this.chkVerCategoria.Size = new System.Drawing.Size(117, 21);
            this.chkVerCategoria.TabIndex = 386;
            this.chkVerCategoria.Text = "Ver Categoría";
            this.chkVerCategoria.UseVisualStyleBackColor = true;
            // 
            // frmrptSaldosFacturasPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 209);
            this.Controls.Add(this.chkCategoria);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBusqGasto);
            this.Controls.Add(this.txtGasto);
            this.Controls.Add(this.txtIdGasto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEjecutar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrptSaldosFacturasPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Saldos de Facturas por Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmrptSaldosFacturas_FormClosing);
            this.Load += new System.EventHandler(this.frmrptSaldosFacturas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCompras;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBusqGasto;
        private System.Windows.Forms.TextBox txtGasto;
        private System.Windows.Forms.TextBox txtIdGasto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDetallado;
        private System.Windows.Forms.RadioButton rbResumido;
        private System.Windows.Forms.CheckBox chkCategoria;
        private System.Windows.Forms.CheckBox chkVerCategoria;
    }
}