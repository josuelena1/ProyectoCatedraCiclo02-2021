using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_AgendarCita : Clinica_Dental.Form_Herencia
    {
        public Form_AgendarCita()
        {
            InitializeComponent();
        }

        private void btnRegresar_AgendarCita_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuClientes();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnHistorialCitas_AgendarCita_Click(object sender, EventArgs e)
        {
            Form Form_irHistorialCitas = new Form_HistorialCitas();
            this.Hide();
            Form_irHistorialCitas.Show();
        }
    }
}
