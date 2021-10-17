
namespace Clinica_Dental
{
    partial class Form_AgendarCita
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
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaCita_AgendarCita = new System.Windows.Forms.DateTimePicker();
            this.btnRegresar_AgendarCita = new System.Windows.Forms.Button();
            this.btnHistorialCitas_AgendarCita = new System.Windows.Forms.Button();
            this.btnRegistrar_AgendarCita = new System.Windows.Forms.Button();
            this.comboBoxProcedimiento_AgendarCita = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Agendar Cita";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(489, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "¡Gracias por tu preferencia! Recuerda que nuestros horarios de \r\natención son de " +
    "6:00 am a 5:00 pm, sin cerrar al medio día.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(184, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de cita:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(184, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Procedimiento:";
            // 
            // dateTimePickerFechaCita_AgendarCita
            // 
            this.dateTimePickerFechaCita_AgendarCita.Location = new System.Drawing.Point(357, 227);
            this.dateTimePickerFechaCita_AgendarCita.Name = "dateTimePickerFechaCita_AgendarCita";
            this.dateTimePickerFechaCita_AgendarCita.Size = new System.Drawing.Size(309, 22);
            this.dateTimePickerFechaCita_AgendarCita.TabIndex = 7;
            // 
            // btnRegresar_AgendarCita
            // 
            this.btnRegresar_AgendarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar_AgendarCita.Location = new System.Drawing.Point(154, 423);
            this.btnRegresar_AgendarCita.Name = "btnRegresar_AgendarCita";
            this.btnRegresar_AgendarCita.Size = new System.Drawing.Size(130, 44);
            this.btnRegresar_AgendarCita.TabIndex = 9;
            this.btnRegresar_AgendarCita.Text = "Regresar";
            this.btnRegresar_AgendarCita.UseVisualStyleBackColor = true;
            this.btnRegresar_AgendarCita.Click += new System.EventHandler(this.btnRegresar_AgendarCita_Click);
            // 
            // btnHistorialCitas_AgendarCita
            // 
            this.btnHistorialCitas_AgendarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialCitas_AgendarCita.Location = new System.Drawing.Point(365, 423);
            this.btnHistorialCitas_AgendarCita.Name = "btnHistorialCitas_AgendarCita";
            this.btnHistorialCitas_AgendarCita.Size = new System.Drawing.Size(183, 78);
            this.btnHistorialCitas_AgendarCita.TabIndex = 10;
            this.btnHistorialCitas_AgendarCita.Text = "Historial de citas";
            this.btnHistorialCitas_AgendarCita.UseVisualStyleBackColor = true;
            this.btnHistorialCitas_AgendarCita.Click += new System.EventHandler(this.btnHistorialCitas_AgendarCita_Click);
            // 
            // btnRegistrar_AgendarCita
            // 
            this.btnRegistrar_AgendarCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar_AgendarCita.Location = new System.Drawing.Point(629, 423);
            this.btnRegistrar_AgendarCita.Name = "btnRegistrar_AgendarCita";
            this.btnRegistrar_AgendarCita.Size = new System.Drawing.Size(130, 44);
            this.btnRegistrar_AgendarCita.TabIndex = 11;
            this.btnRegistrar_AgendarCita.Text = "Registrar";
            this.btnRegistrar_AgendarCita.UseVisualStyleBackColor = true;
            // 
            // comboBoxProcedimiento_AgendarCita
            // 
            this.comboBoxProcedimiento_AgendarCita.FormattingEnabled = true;
            this.comboBoxProcedimiento_AgendarCita.Location = new System.Drawing.Point(353, 310);
            this.comboBoxProcedimiento_AgendarCita.Name = "comboBoxProcedimiento_AgendarCita";
            this.comboBoxProcedimiento_AgendarCita.Size = new System.Drawing.Size(313, 24);
            this.comboBoxProcedimiento_AgendarCita.TabIndex = 12;
            // 
            // Form_AgendarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.comboBoxProcedimiento_AgendarCita);
            this.Controls.Add(this.btnRegistrar_AgendarCita);
            this.Controls.Add(this.btnHistorialCitas_AgendarCita);
            this.Controls.Add(this.btnRegresar_AgendarCita);
            this.Controls.Add(this.dateTimePickerFechaCita_AgendarCita);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form_AgendarCita";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dateTimePickerFechaCita_AgendarCita, 0);
            this.Controls.SetChildIndex(this.btnRegresar_AgendarCita, 0);
            this.Controls.SetChildIndex(this.btnHistorialCitas_AgendarCita, 0);
            this.Controls.SetChildIndex(this.btnRegistrar_AgendarCita, 0);
            this.Controls.SetChildIndex(this.comboBoxProcedimiento_AgendarCita, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaCita_AgendarCita;
        private System.Windows.Forms.Button btnRegresar_AgendarCita;
        private System.Windows.Forms.Button btnHistorialCitas_AgendarCita;
        private System.Windows.Forms.Button btnRegistrar_AgendarCita;
        private System.Windows.Forms.ComboBox comboBoxProcedimiento_AgendarCita;
    }
}
