using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_HistorialCitas : Clinica_Dental.Form_Herencia
    {
        public Form_HistorialCitas()
        {
            InitializeComponent();
        }

        private void btnRegresarMenuCliente_HistorialCitas_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuClientes();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnRegresarAgendar_HistorialCitas_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_AgendarCita();
            this.Hide();
            Form_regresar.Show();
        }
    }
}
