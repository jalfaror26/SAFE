namespace PROYECTO
{
    partial class frmUsuarioAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioAdministracion));
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdRutaImagen = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgFoto.ErrorImage")));
            this.imgFoto.Image = ((System.Drawing.Image)(resources.GetObject("imgFoto.Image")));
            this.imgFoto.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgFoto.InitialImage")));
            this.imgFoto.Location = new System.Drawing.Point(61, 81);
            this.imgFoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(200, 192);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 609;
            this.imgFoto.TabStop = false;
            this.imgFoto.Click += new System.EventHandler(this.imgFoto_Click);
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
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.ImageIndex = 2;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(339, 94);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(224, 44);
            this.btnGuardar.TabIndex = 447;
            this.btnGuardar.Text = " Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofdRutaImagen
            // 
            this.ofdRutaImagen.FileName = "openFileDialog1";
            this.ofdRutaImagen.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdRutaImagen_FileOk);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.ImageIndex = 6;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(339, 218);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 44);
            this.button1.TabIndex = 610;
            this.button1.Text = " Salir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Aceptar.ico");
            this.imageList2.Images.SetKeyName(1, "Salir 2.ico");
            this.imageList2.Images.SetKeyName(2, "CP 50.ico");
            this.imageList2.Images.SetKeyName(3, "stock_id.png");
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContraseña.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarContraseña.ImageIndex = 2;
            this.btnCambiarContraseña.ImageList = this.imageList2;
            this.btnCambiarContraseña.Location = new System.Drawing.Point(339, 146);
            this.btnCambiarContraseña.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(224, 44);
            this.btnCambiarContraseña.TabIndex = 611;
            this.btnCambiarContraseña.Text = " Cambiar Contraseña";
            this.btnCambiarContraseña.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // frmUsuarioAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 322);
            this.Controls.Add(this.btnCambiarContraseña);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgFoto);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioAdministracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPermisos2_FormClosing);
            this.Load += new System.EventHandler(this.frmPermisos2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.OpenFileDialog ofdRutaImagen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnCambiarContraseña;
    }
}