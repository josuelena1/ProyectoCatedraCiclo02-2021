using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_CitasAgendadas : Clinica_Dental.Form_Herencia
    {
        public Form_CitasAgendadas()
        {
            InitializeComponent();
        }

        private void btnRegresar_CitasAgendadas_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuAdministrador();
            this.Hide();
            Form_regresar.Show();
        }
    }
}
