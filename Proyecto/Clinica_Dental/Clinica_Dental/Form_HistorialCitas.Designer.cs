
namespace Clinica_Dental
{
    partial class Form_HistorialCitas
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
            this.dataGridView_HistorialCitas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegresarAgendar_HistorialCitas = new System.Windows.Forms.Button();
            this.btnRegresarMenuCliente_HistorialCitas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HistorialCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 44);
            this.label3.TabIndex = 3;
            this.label3.Text = "Historial de Citas";
            // 
            // dataGridView_HistorialCitas
            // 
            this.dataGridView_HistorialCitas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView_HistorialCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HistorialCitas.Location = new System.Drawing.Point(30, 178);
            this.dataGridView_HistorialCitas.Name = "dataGridView_HistorialCitas";
            this.dataGridView_HistorialCitas.RowHeadersWidth = 51;
            this.dataGridView_HistorialCitas.RowTemplate.Height = 24;
            this.dataGridView_HistorialCitas.Size = new System.Drawing.Size(822, 462);
            this.dataGridView_HistorialCitas.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 51);
            this.label4.TabIndex = 5;
            this.label4.Text = "Consulta le fecha y hora de todas tus consultas. Importante a la hora\r\nde llevar " +
    "un control sobre ti. Nos sirve, además, para conocer tu\r\nhistorial y mejorar el " +
    "servicio.\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresarAgendar_HistorialCitas
            // 
            this.btnRegresarAgendar_HistorialCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresarAgendar_HistorialCitas.Location = new System.Drawing.Point(83, 674);
            this.btnRegresarAgendar_HistorialCitas.Name = "btnRegresarAgendar_HistorialCitas";
            this.btnRegresarAgendar_HistorialCitas.Size = new System.Drawing.Size(235, 47);
            this.btnRegresarAgendar_HistorialCitas.TabIndex = 6;
            this.btnRegresarAgendar_HistorialCitas.Text = "Regresar a Agendar Cita";
            this.btnRegresarAgendar_HistorialCitas.UseVisualStyleBackColor = true;
            this.btnRegresarAgendar_HistorialCitas.Click += new System.EventHandler(this.btnRegresarAgendar_HistorialCitas_Click);
            // 
            // btnRegresarMenuCliente_HistorialCitas
            // 
            this.btnRegresarMenuCliente_HistorialCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresarMenuCliente_HistorialCitas.Location = new System.Drawing.Point(525, 675);
            this.btnRegresarMenuCliente_HistorialCitas.Name = "btnRegresarMenuCliente_HistorialCitas";
            this.btnRegresarMenuCliente_HistorialCitas.Size = new System.Drawing.Size(245, 46);
            this.btnRegresarMenuCliente_HistorialCitas.TabIndex = 7;
            this.btnRegresarMenuCliente_HistorialCitas.Text = "Regresar al Menú Cliente";
            this.btnRegresarMenuCliente_HistorialCitas.UseVisualStyleBackColor = true;
            this.btnRegresarMenuCliente_HistorialCitas.Click += new System.EventHandler(this.btnRegresarMenuCliente_HistorialCitas_Click);
            // 
            // Form_HistorialCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.btnRegresarMenuCliente_HistorialCitas);
            this.Controls.Add(this.btnRegresarAgendar_HistorialCitas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView_HistorialCitas);
            this.Controls.Add(this.label3);
            this.Name = "Form_HistorialCitas";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dataGridView_HistorialCitas, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnRegresarAgendar_HistorialCitas, 0);
            this.Controls.SetChildIndex(this.btnRegresarMenuCliente_HistorialCitas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HistorialCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_HistorialCitas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegresarAgendar_HistorialCitas;
        private System.Windows.Forms.Button btnRegresarMenuCliente_HistorialCitas;
    }
}
