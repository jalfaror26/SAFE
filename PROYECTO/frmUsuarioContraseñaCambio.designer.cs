namespace PROYECTO
{
    partial class frmUsuarioContraseņaCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioContraseņaCambio));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCambiarContrasenna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContrasennaActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaContrasenna = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmNueva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.btnCambiarContrasenna.Location = new System.Drawing.Point(135, 256);
            this.btnCambiarContrasenna.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiarContrasenna.Name = "btnCambiarContrasenna";
            this.btnCambiarContrasenna.Size = new System.Drawing.Size(232, 54);
            this.btnCambiarContrasenna.TabIndex = 3;
            this.btnCambiarContrasenna.Text = " Cambiar Contraseņa";
            this.btnCambiarContrasenna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarContrasenna.UseVisualStyleBackColor = true;
            this.btnCambiarContrasenna.Click += new System.EventHandler(this.btnCambiarContrasenna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 544;
            this.label1.Text = "Contraseņa Actual";
            // 
            // txtContrasennaActual
            // 
            this.txtContrasennaActual.Location = new System.Drawing.Point(88, 92);
            this.txtContrasennaActual.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasennaActual.Name = "txtContrasennaActual";
            this.txtContrasennaActual.PasswordChar = '*';
            this.txtContrasennaActual.Size = new System.Drawing.Size(337, 22);
            this.txtContrasennaActual.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 548;
            this.label2.Text = "Nueva Contraseņa";
            // 
            // txtNuevaContrasenna
            // 
            this.txtNuevaContrasenna.Location = new System.Drawing.Point(88, 145);
            this.txtNuevaContrasenna.Margin = new System.Windows.Forms.Padding(4);
            this.txtNuevaContrasenna.Name = "txtNuevaContrasenna";
            this.txtNuevaContrasenna.PasswordChar = '*';
            this.txtNuevaContrasenna.Size = new System.Drawing.Size(337, 22);
            this.txtNuevaContrasenna.TabIndex = 1;
            this.txtNuevaContrasenna.Leave += new System.EventHandler(this.txtNuevaContrasenna_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 17);
            this.label3.TabIndex = 550;
            this.label3.Text = "Confirme la Nueva Contraseņa";
            // 
            // txtConfirmNueva
            // 
            this.txtConfirmNueva.Location = new System.Drawing.Point(88, 201);
            this.txtConfirmNueva.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmNueva.Name = "txtConfirmNueva";
            this.txtConfirmNueva.PasswordChar = '*';
            this.txtConfirmNueva.Size = new System.Drawing.Size(337, 22);
            this.txtConfirmNueva.TabIndex = 2;
            this.txtConfirmNueva.Leave += new System.EventHandler(this.txtConfirmNueva_Leave);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(503, 52);
            this.label4.TabIndex = 551;
            this.label4.Text = "Usuario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(65, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 32);
            this.label8.TabIndex = 552;
            this.label8.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(65, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 32);
            this.label5.TabIndex = 553;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(65, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 32);
            this.label6.TabIndex = 554;
            this.label6.Text = "*";
            // 
            // frmUsuarioContraseņaCambio
            // 
            this.AcceptButton = this.btnCambiarContrasenna;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 337);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmNueva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNuevaContrasenna);
            this.Controls.Add(this.btnCambiarContrasenna);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContrasennaActual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioContraseņaCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Contraseņa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsuarioAdministracion_FormClosing);
            this.Load += new System.EventHandler(this.frmUsuarioContraseņaCambio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarioContraseņaCambio_KeyDown);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}