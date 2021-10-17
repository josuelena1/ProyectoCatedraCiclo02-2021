using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Clinica_Dental
{
    public partial class Form_Registrarse : Clinica_Dental.Form_Herencia
    {
        public Form_Registrarse()
        {
            InitializeComponent();
        }

        private void btnRegresar_Registrarse_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_Login();
            this.Hide();
            Form_regresar.Show();
        }

        private void btnRegistrarse_Registrarse_Click(object sender, EventArgs e)
        {
            Form_ConsultarDatosPersonales fdorm4 = new Form_ConsultarDatosPersonales();
            Registrarse registro = new Registrarse();
            registro.Registrar(txtUsuario_Registrarse, txtContraseña_Registrarse, txtTelefono_Registrarse, txtEmail_Registrarse, txtGenero_Registrarse, txtNombre_Registrarse, txtDui_Registrarse, dateTimePickerNacimiento_Registrarse);

            this.Hide();
            Form_Login form = new Form_Login();
            form.Show();
        }

        private void txtGenero_Registrarse_Leave(object sender, EventArgs e)
        {
            Regex genero = new Regex("^M(asculino)?$|^F(emenino)?$|^N(o binario)?$|n(o binario)^M(ASCULINO)?$|^F(EMENINO)?$|");
            if (genero.IsMatch(txtGenero_Registrarse.Text))
            {

            }

            else
                MessageBox.Show("Ingrese un género valido (MASCULINO, FEMENINO, No binario)");
        }
    }
}
