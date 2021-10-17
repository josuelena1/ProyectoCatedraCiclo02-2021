
namespace Clinica_Dental
{
    partial class Form_MenuAdministrador
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConsultaDatos_MenuAdministracion = new System.Windows.Forms.Button();
            this.btnConsultarCitas_MenuAdministracion = new System.Windows.Forms.Button();
            this.btnCerrarSesion_MenuAdministracion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(266, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Menú Administración";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Consultar datos de clientes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Consultar citas agendadas:";
            // 
            // btnConsultaDatos_MenuAdministracion
            // 
            this.btnConsultaDatos_MenuAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaDatos_MenuAdministracion.Location = new System.Drawing.Point(462, 182);
            this.btnConsultaDatos_MenuAdministracion.Name = "btnConsultaDatos_MenuAdministracion";
            this.btnConsultaDatos_MenuAdministracion.Size = new System.Drawing.Size(109, 50);
            this.btnConsultaDatos_MenuAdministracion.TabIndex = 6;
            this.btnConsultaDatos_MenuAdministracion.Text = "Ir";
            this.btnConsultaDatos_MenuAdministracion.UseVisualStyleBackColor = true;
            this.btnConsultaDatos_MenuAdministracion.Click += new System.EventHandler(this.btnConsultaDatos_MenuAdministracion_Click);
            // 
            // btnConsultarCitas_MenuAdministracion
            // 
            this.btnConsultarCitas_MenuAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarCitas_MenuAdministracion.Location = new System.Drawing.Point(462, 273);
            this.btnConsultarCitas_MenuAdministracion.Name = "btnConsultarCitas_MenuAdministracion";
            this.btnConsultarCitas_MenuAdministracion.Size = new System.Drawing.Size(109, 50);
            this.btnConsultarCitas_MenuAdministracion.TabIndex = 7;
            this.btnConsultarCitas_MenuAdministracion.Text = "Ir";
            this.btnConsultarCitas_MenuAdministracion.UseVisualStyleBackColor = true;
            this.btnConsultarCitas_MenuAdministracion.Click += new System.EventHandler(this.btnConsultarCitas_MenuAdministracion_Click);
            // 
            // btnCerrarSesion_MenuAdministracion
            // 
            this.btnCerrarSesion_MenuAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion_MenuAdministracion.Location = new System.Drawing.Point(628, 368);
            this.btnCerrarSesion_MenuAdministracion.Name = "btnCerrarSesion_MenuAdministracion";
            this.btnCerrarSesion_MenuAdministracion.Size = new System.Drawing.Size(118, 69);
            this.btnCerrarSesion_MenuAdministracion.TabIndex = 8;
            this.btnCerrarSesion_MenuAdministracion.Text = "Cerrar\r\nsesión\r\n";
            this.btnCerrarSesion_MenuAdministracion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion_MenuAdministracion.Click += new System.EventHandler(this.btnCerrarSesion_MenuAdministracion_Click);
            // 
            // Form_MenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.btnCerrarSesion_MenuAdministracion);
            this.Controls.Add(this.btnConsultarCitas_MenuAdministracion);
            this.Controls.Add(this.btnConsultaDatos_MenuAdministracion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form_MenuAdministrador";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnConsultaDatos_MenuAdministracion, 0);
            this.Controls.SetChildIndex(this.btnConsultarCitas_MenuAdministracion, 0);
            this.Controls.SetChildIndex(this.btnCerrarSesion_MenuAdministracion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConsultaDatos_MenuAdministracion;
        private System.Windows.Forms.Button btnConsultarCitas_MenuAdministracion;
        private System.Windows.Forms.Button btnCerrarSesion_MenuAdministracion;
    }
}
