
namespace Clinica_Dental
{
    partial class Form_CitasAgendadas
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
            this.dateTimePickerFecha_CitasAgendadas = new System.Windows.Forms.DateTimePicker();
            this.txtIdCitas_CitasAgendadas = new System.Windows.Forms.TextBox();
            this.dataGridView_CitasAgendadas = new System.Windows.Forms.DataGridView();
            this.btnRegresar_CitasAgendadas = new System.Windows.Forms.Button();
            this.btnActualizar_CitasAgendadas = new System.Windows.Forms.Button();
            this.btnModificar_CitasAgendadas = new System.Windows.Forms.Button();
            this.btnVer_CitasAgendadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CitasAgendadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 44);
            this.label3.TabIndex = 3;
            this.label3.Text = "Citas Agendadas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(448, 54);
            this.label4.TabIndex = 4;
            this.label4.Text = "Recuerde revisar las citas constantemente, y sobre todo, modificar\r\nlos cambios e" +
    "n las mismas, si se dan.\r\n\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(199, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de citas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(199, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "ID Cita:";
            // 
            // dateTimePickerFecha_CitasAgendadas
            // 
            this.dateTimePickerFecha_CitasAgendadas.Location = new System.Drawing.Point(357, 212);
            this.dateTimePickerFecha_CitasAgendadas.Name = "dateTimePickerFecha_CitasAgendadas";
            this.dateTimePickerFecha_CitasAgendadas.Size = new System.Drawing.Size(285, 22);
            this.dateTimePickerFecha_CitasAgendadas.TabIndex = 7;
            // 
            // txtIdCitas_CitasAgendadas
            // 
            this.txtIdCitas_CitasAgendadas.Location = new System.Drawing.Point(357, 260);
            this.txtIdCitas_CitasAgendadas.Name = "txtIdCitas_CitasAgendadas";
            this.txtIdCitas_CitasAgendadas.Size = new System.Drawing.Size(285, 22);
            this.txtIdCitas_CitasAgendadas.TabIndex = 8;
            // 
            // dataGridView_CitasAgendadas
            // 
            this.dataGridView_CitasAgendadas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView_CitasAgendadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CitasAgendadas.Location = new System.Drawing.Point(25, 310);
            this.dataGridView_CitasAgendadas.Name = "dataGridView_CitasAgendadas";
            this.dataGridView_CitasAgendadas.RowHeadersWidth = 51;
            this.dataGridView_CitasAgendadas.RowTemplate.Height = 24;
            this.dataGridView_CitasAgendadas.Size = new System.Drawing.Size(828, 354);
            this.dataGridView_CitasAgendadas.TabIndex = 9;
            // 
            // btnRegresar_CitasAgendadas
            // 
            this.btnRegresar_CitasAgendadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar_CitasAgendadas.Location = new System.Drawing.Point(49, 686);
            this.btnRegresar_CitasAgendadas.Name = "btnRegresar_CitasAgendadas";
            this.btnRegresar_CitasAgendadas.Size = new System.Drawing.Size(126, 45);
            this.btnRegresar_CitasAgendadas.TabIndex = 10;
            this.btnRegresar_CitasAgendadas.Text = "Regresar";
            this.btnRegresar_CitasAgendadas.UseVisualStyleBackColor = true;
            this.btnRegresar_CitasAgendadas.Click += new System.EventHandler(this.btnRegresar_CitasAgendadas_Click);
            // 
            // btnActualizar_CitasAgendadas
            // 
            this.btnActualizar_CitasAgendadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar_CitasAgendadas.Location = new System.Drawing.Point(263, 686);
            this.btnActualizar_CitasAgendadas.Name = "btnActualizar_CitasAgendadas";
            this.btnActualizar_CitasAgendadas.Size = new System.Drawing.Size(128, 45);
            this.btnActualizar_CitasAgendadas.TabIndex = 11;
            this.btnActualizar_CitasAgendadas.Text = "Actualizar";
            this.btnActualizar_CitasAgendadas.UseVisualStyleBackColor = true;
            // 
            // btnModificar_CitasAgendadas
            // 
            this.btnModificar_CitasAgendadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar_CitasAgendadas.Location = new System.Drawing.Point(497, 686);
            this.btnModificar_CitasAgendadas.Name = "btnModificar_CitasAgendadas";
            this.btnModificar_CitasAgendadas.Size = new System.Drawing.Size(110, 45);
            this.btnModificar_CitasAgendadas.TabIndex = 12;
            this.btnModificar_CitasAgendadas.Text = "Modificar";
            this.btnModificar_CitasAgendadas.UseVisualStyleBackColor = true;
            // 
            // btnVer_CitasAgendadas
            // 
            this.btnVer_CitasAgendadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer_CitasAgendadas.Location = new System.Drawing.Point(710, 686);
            this.btnVer_CitasAgendadas.Name = "btnVer_CitasAgendadas";
            this.btnVer_CitasAgendadas.Size = new System.Drawing.Size(110, 45);
            this.btnVer_CitasAgendadas.TabIndex = 13;
            this.btnVer_CitasAgendadas.Text = "Ver";
            this.btnVer_CitasAgendadas.UseVisualStyleBackColor = true;
            // 
            // Form_CitasAgendadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.btnVer_CitasAgendadas);
            this.Controls.Add(this.btnModificar_CitasAgendadas);
            this.Controls.Add(this.btnActualizar_CitasAgendadas);
            this.Controls.Add(this.btnRegresar_CitasAgendadas);
            this.Controls.Add(this.dataGridView_CitasAgendadas);
            this.Controls.Add(this.txtIdCitas_CitasAgendadas);
            this.Controls.Add(this.dateTimePickerFecha_CitasAgendadas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form_CitasAgendadas";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dateTimePickerFecha_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.txtIdCitas_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.dataGridView_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.btnRegresar_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.btnActualizar_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.btnModificar_CitasAgendadas, 0);
            this.Controls.SetChildIndex(this.btnVer_CitasAgendadas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CitasAgendadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha_CitasAgendadas;
        private System.Windows.Forms.TextBox txtIdCitas_CitasAgendadas;
        private System.Windows.Forms.DataGridView dataGridView_CitasAgendadas;
        private System.Windows.Forms.Button btnRegresar_CitasAgendadas;
        private System.Windows.Forms.Button btnActualizar_CitasAgendadas;
        private System.Windows.Forms.Button btnModificar_CitasAgendadas;
        private System.Windows.Forms.Button btnVer_CitasAgendadas;
    }
}
