namespace PROYECTO
{
    partial class frmRecordatorioVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecordatorioVista));
            this.trvLista = new System.Windows.Forms.TreeView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRecordatorios = new System.Windows.Forms.Label();
            this.grbBusqueda = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rboPM = new System.Windows.Forms.RadioButton();
            this.rboAM = new System.Windows.Forms.RadioButton();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.chkOtro = new System.Windows.Forms.CheckBox();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkHora = new System.Windows.Forms.CheckBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbBusqueda.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvLista
            // 
            this.trvLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvLista.FullRowSelect = true;
            this.trvLista.Location = new System.Drawing.Point(8, 9);
            this.trvLista.Margin = new System.Windows.Forms.Padding(4);
            this.trvLista.Name = "trvLista";
            this.trvLista.Size = new System.Drawing.Size(364, 552);
            this.trvLista.TabIndex = 0;
            this.trvLista.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvLista_NodeMouseClick);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(39, 85);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 26);
            this.lblUsuario.TabIndex = 2;
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentarios.Location = new System.Drawing.Point(85, 165);
            this.lblComentarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(0, 20);
            this.lblComentarios.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRecordatorios
            // 
            this.lblRecordatorios.AutoSize = true;
            this.lblRecordatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordatorios.Location = new System.Drawing.Point(61, 127);
            this.lblRecordatorios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordatorios.Name = "lblRecordatorios";
            this.lblRecordatorios.Size = new System.Drawing.Size(0, 24);
            this.lblRecordatorios.TabIndex = 5;
            // 
            // grbBusqueda
            // 
            this.grbBusqueda.Controls.Add(this.btnBuscar);
            this.grbBusqueda.Controls.Add(this.rboPM);
            this.grbBusqueda.Controls.Add(this.rboAM);
            this.grbBusqueda.Controls.Add(this.txtHora);
            this.grbBusqueda.Controls.Add(this.chkOtro);
            this.grbBusqueda.Controls.Add(this.txtOtro);
            this.grbBusqueda.Controls.Add(this.dtpFecha);
            this.grbBusqueda.Controls.Add(this.chkHora);
            this.grbBusqueda.Controls.Add(this.chkFecha);
            this.grbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBusqueda.Location = new System.Drawing.Point(536, 15);
            this.grbBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.grbBusqueda.Name = "grbBusqueda";
            this.grbBusqueda.Padding = new System.Windows.Forms.Padding(4);
            this.grbBusqueda.Size = new System.Drawing.Size(496, 25);
            this.grbBusqueda.TabIndex = 6;
            this.grbBusqueda.TabStop = false;
            this.grbBusqueda.Text = "Busqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "file_find.ico";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(308, 134);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(161, 37);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "  Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Sign 18.ico");
            this.imageList1.Images.SetKeyName(1, "Sign 17.ico");
            this.imageList1.Images.SetKeyName(2, "file_find.ico");
            // 
            // rboPM
            // 
            this.rboPM.AutoSize = true;
            this.rboPM.Enabled = false;
            this.rboPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPM.Location = new System.Drawing.Point(280, 60);
            this.rboPM.Margin = new System.Windows.Forms.Padding(4);
            this.rboPM.Name = "rboPM";
            this.rboPM.Size = new System.Drawing.Size(50, 21);
            this.rboPM.TabIndex = 168;
            this.rboPM.Text = "pm";
            this.rboPM.UseVisualStyleBackColor = true;
            // 
            // rboAM
            // 
            this.rboAM.AutoSize = true;
            this.rboAM.Checked = true;
            this.rboAM.Enabled = false;
            this.rboAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAM.Location = new System.Drawing.Point(217, 60);
            this.rboAM.Margin = new System.Windows.Forms.Padding(4);
            this.rboAM.Name = "rboAM";
            this.rboAM.Size = new System.Drawing.Size(50, 21);
            this.rboAM.TabIndex = 167;
            this.rboAM.TabStop = true;
            this.rboAM.Text = "am";
            this.rboAM.UseVisualStyleBackColor = true;
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(131, 58);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4);
            this.txtHora.Mask = "00 : 00";
            this.txtHora.Name = "txtHora";
            this.txtHora.PromptChar = ' ';
            this.txtHora.Size = new System.Drawing.Size(77, 23);
            this.txtHora.TabIndex = 166;
            this.txtHora.Text = "0100";
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            this.txtHora.Leave += new System.EventHandler(this.txtHora_Leave);
            // 
            // chkOtro
            // 
            this.chkOtro.AutoSize = true;
            this.chkOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtro.Location = new System.Drawing.Point(23, 92);
            this.chkOtro.Margin = new System.Windows.Forms.Padding(4);
            this.chkOtro.Name = "chkOtro";
            this.chkOtro.Size = new System.Drawing.Size(81, 21);
            this.chkOtro.TabIndex = 17;
            this.chkOtro.Text = "Detalle";
            this.chkOtro.UseVisualStyleBackColor = true;
            this.chkOtro.CheckedChanged += new System.EventHandler(this.chkOtro_CheckedChanged);
            // 
            // txtOtro
            // 
            this.txtOtro.Enabled = false;
            this.txtOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtro.Location = new System.Drawing.Point(131, 90);
            this.txtOtro.Margin = new System.Windows.Forms.Padding(4);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(337, 23);
            this.txtOtro.TabIndex = 16;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(131, 26);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(337, 23);
            this.dtpFecha.TabIndex = 15;
            // 
            // chkHora
            // 
            this.chkHora.AutoSize = true;
            this.chkHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHora.Location = new System.Drawing.Point(23, 60);
            this.chkHora.Margin = new System.Windows.Forms.Padding(4);
            this.chkHora.Name = "chkHora";
            this.chkHora.Size = new System.Drawing.Size(65, 21);
            this.chkHora.TabIndex = 14;
            this.chkHora.Text = "Hora";
            this.chkHora.UseVisualStyleBackColor = true;
            this.chkHora.CheckedChanged += new System.EventHandler(this.chkHora_CheckedChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFecha.Location = new System.Drawing.Point(23, 30);
            this.chkFecha.Margin = new System.Windows.Forms.Padding(4);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(74, 21);
            this.chkFecha.TabIndex = 12;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // btnAbrir
            // 
            this.btnAbrir.ImageKey = "Sign 18.ico";
            this.btnAbrir.ImageList = this.imageList1;
            this.btnAbrir.Location = new System.Drawing.Point(1039, 21);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(44, 41);
            this.btnAbrir.TabIndex = 7;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageKey = "Sign 17.ico";
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(1040, 21);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(44, 41);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.lblComentarios);
            this.panel1.Controls.Add(this.lblRecordatorios);
            this.panel1.Location = new System.Drawing.Point(379, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 571);
            this.panel1.TabIndex = 9;
            // 
            // frmRecordatorioVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 567);
            this.Controls.Add(this.grbBusqueda);
            this.Controls.Add(this.trvLista);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecordatorioVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recordatorios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecordatorioVista2_FormClosing);
            this.Load += new System.EventHandler(this.frmRecordatorioVista2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecordatorioVista_KeyDown);
            this.grbBusqueda.ResumeLayout(false);
            this.grbBusqueda.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvLista;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRecordatorios;
        private System.Windows.Forms.GroupBox grbBusqueda;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox chkHora;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.CheckBox chkOtro;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.RadioButton rboPM;
        private System.Windows.Forms.RadioButton rboAM;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
    }
}