using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_MenuClientes : Clinica_Dental.Form_Herencia
    {
        public Form_MenuClientes()
        {
            InitializeComponent();
        }

        private void btnCerrarSesión_MenuClientes_Click(object sender, EventArgs e)
        {
            Form Form_regresarLogin = new Form_Login();
            this.Hide();
            Form_regresarLogin.Show();
        }

        private void btnConsultarDatos_MenuClientes_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_ConsultarDatosPersonales();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnServicioDisponibles_MenuClientes_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_ServiciosDisponibles();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnConsultarCitas_MenuClientes_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_AgendarCita();
            this.Hide();
            Form_regresar.Show();
        }
    }
}
