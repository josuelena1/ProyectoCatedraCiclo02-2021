using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Dental
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Login_Click(object sender, EventArgs e)
        {
            Form Form_registrarse = new Form_Registrarse();
            this.Hide();
            Form_registrarse.Show();          
        }

        private void btnIniciarSesion_Login_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.LogIn(txtUsuario_Login, txtContraseña_Login);
            this.Hide();
        }
    }
}
