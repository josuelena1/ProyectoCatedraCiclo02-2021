
namespace Clinica_Dental
{
    partial class Form_ServiciosDisponibles
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
            this.dgv_ServiciosDisponibles = new System.Windows.Forms.DataGridView();
            this.btnRegresar_ServicioDisponibles = new System.Windows.Forms.Button();
            this.btnAgendarCita_ServiciosDisponibles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ServiciosDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Servicios Disponibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 34);
            this.label4.TabIndex = 4;
            this.label4.Text = "Te recomendamos revisar constantemente los servicios disponibles,\r\npara estar al " +
    "día con la actualización de los precio y servicios.\r\n";
            // 
            // dgv_ServiciosDisponibles
            // 
            this.dgv_ServiciosDisponibles.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_ServiciosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ServiciosDisponibles.Location = new System.Drawing.Point(36, 195);
            this.dgv_ServiciosDisponibles.Name = "dgv_ServiciosDisponibles";
            this.dgv_ServiciosDisponibles.RowHeadersWidth = 51;
            this.dgv_ServiciosDisponibles.RowTemplate.Height = 24;
            this.dgv_ServiciosDisponibles.Size = new System.Drawing.Size(809, 386);
            this.dgv_ServiciosDisponibles.TabIndex = 5;
            // 
            // btnRegresar_ServicioDisponibles
            // 
            this.btnRegresar_ServicioDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar_ServicioDisponibles.Location = new System.Drawing.Point(188, 641);
            this.btnRegresar_ServicioDisponibles.Name = "btnRegresar_ServicioDisponibles";
            this.btnRegresar_ServicioDisponibles.Size = new System.Drawing.Size(133, 60);
            this.btnRegresar_ServicioDisponibles.TabIndex = 6;
            this.btnRegresar_ServicioDisponibles.Text = "Regresar";
            this.btnRegresar_ServicioDisponibles.UseVisualStyleBackColor = true;
            this.btnRegresar_ServicioDisponibles.Click += new System.EventHandler(this.btnRegresar_ServicioDisponibles_Click);
            // 
            // btnAgendarCita_ServiciosDisponibles
            // 
            this.btnAgendarCita_ServiciosDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgendarCita_ServiciosDisponibles.Location = new System.Drawing.Point(540, 641);
            this.btnAgendarCita_ServiciosDisponibles.Name = "btnAgendarCita_ServiciosDisponibles";
            this.btnAgendarCita_ServiciosDisponibles.Size = new System.Drawing.Size(133, 57);
            this.btnAgendarCita_ServiciosDisponibles.TabIndex = 7;
            this.btnAgendarCita_ServiciosDisponibles.Text = "Agendar cita";
            this.btnAgendarCita_ServiciosDisponibles.UseVisualStyleBackColor = true;
            this.btnAgendarCita_ServiciosDisponibles.Click += new System.EventHandler(this.btnAgendarCita_ServiciosDisponibles_Click);
            // 
            // Form_ServiciosDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.btnAgendarCita_ServiciosDisponibles);
            this.Controls.Add(this.btnRegresar_ServicioDisponibles);
            this.Controls.Add(this.dgv_ServiciosDisponibles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form_ServiciosDisponibles";
            this.Load += new System.EventHandler(this.Form_ServiciosDisponibles_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dgv_ServiciosDisponibles, 0);
            this.Controls.SetChildIndex(this.btnRegresar_ServicioDisponibles, 0);
            this.Controls.SetChildIndex(this.btnAgendarCita_ServiciosDisponibles, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ServiciosDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_ServiciosDisponibles;
        private System.Windows.Forms.Button btnRegresar_ServicioDisponibles;
        private System.Windows.Forms.Button btnAgendarCita_ServiciosDisponibles;
    }
}
