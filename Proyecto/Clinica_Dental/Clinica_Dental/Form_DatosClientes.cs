using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_DatosClientes : Clinica_Dental.Form_Herencia
    {
        public Form_DatosClientes()
        {
            InitializeComponent();
        }

        private void btnRegresar_DatosClientes_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuAdministrador();
            this.Hide();
            Form_regresar.Show();
        }
    }
}
