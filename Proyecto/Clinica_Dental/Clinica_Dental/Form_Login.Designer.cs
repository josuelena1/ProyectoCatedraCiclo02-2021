
namespace Clinica_Dental
{
    partial class Form_Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrarse_Login = new System.Windows.Forms.Button();
            this.btnIniciarSesion_Login = new System.Windows.Forms.Button();
            this.txtContraseña_Login = new System.Windows.Forms.TextBox();
            this.txtUsuario_Login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnRegistrarse_Login);
            this.panel1.Controls.Add(this.btnIniciarSesion_Login);
            this.panel1.Controls.Add(this.txtContraseña_Login);
            this.panel1.Controls.Add(this.txtUsuario_Login);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(132, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 359);
            this.panel1.TabIndex = 0;
            // 
            // btnRegistrarse_Login
            // 
            this.btnRegistrarse_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse_Login.Location = new System.Drawing.Point(271, 285);
            this.btnRegistrarse_Login.Name = "btnRegistrarse_Login";
            this.btnRegistrarse_Login.Size = new System.Drawing.Size(94, 51);
            this.btnRegistrarse_Login.TabIndex = 7;
            this.btnRegistrarse_Login.Text = "Registrarse";
            this.btnRegistrarse_Login.UseVisualStyleBackColor = true;
            this.btnRegistrarse_Login.Click += new System.EventHandler(this.btnRegistrarse_Login_Click);
            // 
            // btnIniciarSesion_Login
            // 
            this.btnIniciarSesion_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion_Login.Location = new System.Drawing.Point(104, 285);
            this.btnIniciarSesion_Login.Name = "btnIniciarSesion_Login";
            this.btnIniciarSesion_Login.Size = new System.Drawing.Size(102, 51);
            this.btnIniciarSesion_Login.TabIndex = 6;
            this.btnIniciarSesion_Login.Text = "Iniciar\r\nSesión";
            this.btnIniciarSesion_Login.UseVisualStyleBackColor = true;
            this.btnIniciarSesion_Login.Click += new System.EventHandler(this.btnIniciarSesion_Login_Click);
            // 
            // txtContraseña_Login
            // 
            this.txtContraseña_Login.Location = new System.Drawing.Point(209, 224);
            this.txtContraseña_Login.Name = "txtContraseña_Login";
            this.txtContraseña_Login.Size = new System.Drawing.Size(156, 22);
            this.txtContraseña_Login.TabIndex = 5;
            // 
            // txtUsuario_Login
            // 
            this.txtUsuario_Login.Location = new System.Drawing.Point(209, 182);
            this.txtUsuario_Login.Name = "txtUsuario_Login";
            this.txtUsuario_Login.Size = new System.Drawing.Size(156, 22);
            this.txtUsuario_Login.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Tooth";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(184, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 463);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.Text = "Doctor Tooth";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarse_Login;
        private System.Windows.Forms.Button btnIniciarSesion_Login;
        private System.Windows.Forms.TextBox txtContraseña_Login;
        private System.Windows.Forms.TextBox txtUsuario_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

