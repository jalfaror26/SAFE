namespace PROYECTO
{
    partial class frmUsuarioCodigoBarrasCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioCodigoBarrasCambio));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCambiarContrasenna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContrasennaActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaContrasenna = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmNueva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "services.ico");
            this.imageList1.Images.SetKeyName(1, "Aceptar.ico");
            // 
            // btnCambiarContrasenna
            // 
            this.btnCambiarContrasenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContrasenna.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarContrasenna.ImageIndex = 1;
            this.btnCambiarContrasenna.ImageList = this.imageList1;
            this.btnCambiarContrasenna.Location = new System.Drawing.Point(92, 230);
            this.btnCambiarContrasenna.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCambiarContrasenna.Name = "btnCambiarContrasenna";
            this.btnCambiarContrasenna.Size = new System.Drawing.Size(267, 39);
            this.btnCambiarContrasenna.TabIndex = 3;
            this.btnCambiarContrasenna.Text = " Cambiar Codigo de Barras";
            this.btnCambiarContrasenna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarContrasenna.UseVisualStyleBackColor = true;
            this.btnCambiarContrasenna.Click += new System.EventHandler(this.btnCambiarContrasenna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 17);
            this.label1.TabIndex = 544;
            this.label1.Text = "Contraseña o Codigo de Barras Actual";
            // 
            // txtContrasennaActual
            // 
            this.txtContrasennaActual.Location = new System.Drawing.Point(20, 84);
            this.txtContrasennaActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContrasennaActual.Name = "txtContrasennaActual";
            this.txtContrasennaActual.PasswordChar = '*';
            this.txtContrasennaActual.Size = new System.Drawing.Size(337, 22);
            this.txtContrasennaActual.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 17);
            this.label2.TabIndex = 548;
            this.label2.Text = "Nuevo Codigo de Barras";
            // 
            // txtNuevaContrasenna
            // 
            this.txtNuevaContrasenna.Location = new System.Drawing.Point(20, 137);
            this.txtNuevaContrasenna.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNuevaContrasenna.Name = "txtNuevaContrasenna";
            this.txtNuevaContrasenna.PasswordChar = '*';
            this.txtNuevaContrasenna.Size = new System.Drawing.Size(337, 22);
            this.txtNuevaContrasenna.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 17);
            this.label3.TabIndex = 550;
            this.label3.Text = "Confirme el Nuevo Codigo de Barras";
            // 
            // txtConfirmNueva
            // 
            this.txtConfirmNueva.Location = new System.Drawing.Point(20, 192);
            this.txtConfirmNueva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirmNueva.Name = "txtConfirmNueva";
            this.txtConfirmNueva.PasswordChar = '*';
            this.txtConfirmNueva.Size = new System.Drawing.Size(337, 22);
            this.txtConfirmNueva.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 52);
            this.label4.TabIndex = 551;
            this.label4.Text = "Usuario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmUsuarioCodigoBarrasCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 281);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmNueva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNuevaContrasenna);
            this.Controls.Add(this.btnCambiarContrasenna);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContrasennaActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioCodigoBarrasCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Codigo de Barras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsuarioAdministracion_FormClosing);
            this.Load += new System.EventHandler(this.frmUsuarioContraseñaCambio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCambiarContrasenna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContrasennaActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevaContrasenna;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmNueva;
        private System.Windows.Forms.Label label4;
    }
}