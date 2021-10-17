using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_ServiciosDisponibles : Clinica_Dental.Form_Herencia
    {
        public Form_ServiciosDisponibles()
        {
            InitializeComponent();
        }

        private void btnRegresar_ServicioDisponibles_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuClientes();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnAgendarCita_ServiciosDisponibles_Click(object sender, EventArgs e)
        {
            Form Form_irAgendarCita = new Form_AgendarCita();
            this.Hide();
            Form_irAgendarCita.Show();
        }

        private void Form_ServiciosDisponibles_Load(object sender, EventArgs e)
        {
            Servicios servicios = new Servicios();
            servicios.datos(dgv_ServiciosDisponibles);
        }
    }
}
