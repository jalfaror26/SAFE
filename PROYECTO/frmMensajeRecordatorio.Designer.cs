namespace PROYECTO
{
    partial class frmMensajeRecordatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensajeRecordatorio));
            this.lblMensaje = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnPosponer = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPosponerRecordatorio = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboPM = new System.Windows.Forms.RadioButton();
            this.rboAM = new System.Windows.Forms.RadioButton();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.mthFecha = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(176, 53);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(573, 91);
            this.lblMensaje.TabIndex = 5;
            this.lblMensaje.Text = "label1";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Aceptar.ico");
            this.imageList1.Images.SetKeyName(1, "Sign 12.ico");
            // 
            // btnPosponer
            // 
            this.btnPosponer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPosponer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosponer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosponer.ImageKey = "Sign 12.ico";
            this.btnPosponer.ImageList = this.imageList1;
            this.btnPosponer.Location = new System.Drawing.Point(399, 224);
            this.btnPosponer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPosponer.Name = "btnPosponer";
            this.btnPosponer.Size = new System.Drawing.Size(159, 39);
            this.btnPosponer.TabIndex = 4;
            this.btnPosponer.Text = "  Posponer";
            this.btnPosponer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosponer.UseVisualStyleBackColor = true;
            this.btnPosponer.Click += new System.EventHandler(this.btnPosponer_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageKey = "Aceptar.ico";
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(585, 224);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(159, 39);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "  Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFecha.Location = new System.Drawing.Point(176, 7);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(576, 48);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "label1";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(195, 169);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtComentario.MaxLength = 500;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(551, 47);
            this.txtComentario.TabIndex = 1;
            this.txtComentario.Text = "Digite un comentario";
            this.txtComentario.Enter += new System.EventHandler(this.txtComentario_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Comentario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPosponerRecordatorio);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.mthFecha);
            this.panel1.Location = new System.Drawing.Point(181, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 210);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // btnPosponerRecordatorio
            // 
            this.btnPosponerRecordatorio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPosponerRecordatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosponerRecordatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosponerRecordatorio.ImageKey = "Sign 12.ico";
            this.btnPosponerRecordatorio.ImageList = this.imageList1;
            this.btnPosponerRecordatorio.Location = new System.Drawing.Point(343, 85);
            this.btnPosponerRecordatorio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPosponerRecordatorio.Name = "btnPosponerRecordatorio";
            this.btnPosponerRecordatorio.Size = new System.Drawing.Size(159, 39);
            this.btnPosponerRecordatorio.TabIndex = 165;
            this.btnPosponerRecordatorio.Text = "  Posponer";
            this.btnPosponerRecordatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosponerRecordatorio.UseVisualStyleBackColor = true;
            this.btnPosponerRecordatorio.Click += new System.EventHandler(this.btnPosponerRecordatorio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboPM);
            this.groupBox1.Controls.Add(this.rboAM);
            this.groupBox1.Controls.Add(this.txtHora);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(340, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(172, 69);
            this.groupBox1.TabIndex = 164;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hora";
            // 
            // rboPM
            // 
            this.rboPM.AutoSize = true;
            this.rboPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPM.Location = new System.Drawing.Point(107, 38);
            this.rboPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rboPM.Name = "rboPM";
            this.rboPM.Size = new System.Drawing.Size(50, 21);
            this.rboPM.TabIndex = 165;
            this.rboPM.Text = "pm";
            this.rboPM.UseVisualStyleBackColor = true;
            // 
            // rboAM
            // 
            this.rboAM.AutoSize = true;
            this.rboAM.Checked = true;
            this.rboAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAM.Location = new System.Drawing.Point(107, 16);
            this.rboAM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rboAM.Name = "rboAM";
            this.rboAM.Size = new System.Drawing.Size(50, 21);
            this.rboAM.TabIndex = 164;
            this.rboAM.TabStop = true;
            this.rboAM.Text = "am";
            this.rboAM.UseVisualStyleBackColor = true;
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(15, 25);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHora.Mask = "00 : 00";
            this.txtHora.Name = "txtHora";
            this.txtHora.PromptChar = ' ';
            this.txtHora.Size = new System.Drawing.Size(77, 23);
            this.txtHora.TabIndex = 1;
            this.txtHora.Text = "0100";
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            // 
            // mthFecha
            // 
            this.mthFecha.Location = new System.Drawing.Point(9, 5);
            this.mthFecha.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.mthFecha.Name = "mthFecha";
            this.mthFecha.TabIndex = 163;
            this.mthFecha.TitleBackColor = System.Drawing.Color.Blue;
            this.mthFecha.TitleForeColor = System.Drawing.Color.White;
            this.mthFecha.TrailingForeColor = System.Drawing.Color.Blue;
            // 
            // frmMensajeRecordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 272);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnPosponer);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensajeRecordatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECORDATORIO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMensajeRecordatorio_FormClosing);
            this.Load += new System.EventHandler(this.frmMensajeRecordatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnPosponer;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPosponerRecordatorio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboPM;
        private System.Windows.Forms.RadioButton rboAM;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private System.Windows.Forms.MonthCalendar mthFecha;
    }
}