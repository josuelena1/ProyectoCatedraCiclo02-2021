using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_MenuAdministrador : Clinica_Dental.Form_Herencia
    {
        public Form_MenuAdministrador()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_MenuAdministracion_Click(object sender, EventArgs e)
        {
            Form Form_regresarLogin = new Form_Login();
            this.Hide();
            Form_regresarLogin.Show();
        }

        private void btnConsultaDatos_MenuAdministracion_Click(object sender, EventArgs e)
        {
            Form Form_irDatosClientes = new Form_DatosClientes();
            this.Hide();
            Form_irDatosClientes.Show();
        }

        private void btnConsultarCitas_MenuAdministracion_Click(object sender, EventArgs e)
        {
            Form Form_irCitasAgendadas = new Form_CitasAgendadas();
            this.Hide();
            Form_irCitasAgendadas.Show();
        }
    }
}
