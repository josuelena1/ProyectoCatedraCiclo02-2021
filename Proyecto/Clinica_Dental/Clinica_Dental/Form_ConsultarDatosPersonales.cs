using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Dental
{
    public partial class Form_ConsultarDatosPersonales : Clinica_Dental.Form_Herencia
    {
        public Form_ConsultarDatosPersonales()
        {
            InitializeComponent();
        }

        private void btnRegresar_ConsultarDatosPersonales_Click(object sender, EventArgs e)
        {
            Form Form_regresar = new Form_MenuClientes();
            this.Hide();
            Form_regresar.Show();
        }

        private void Form_ConsultarDatosPersonales_Load(object sender, EventArgs e)
        {
            DatosUsuarios usuario = new DatosUsuarios();
            usuario.mostrarUsuario(txtNombre_ConsultarDatosPersonales, txtEmail_ConsultarDatosPersonales, txtEdad_ConsultarDatosPersonales, txtUsuario_ConsultarDatosPersonales, txtDui_ConsultarDatosPersonales, txtTelefono_ConsultarDatosPersonales, txtGenero_ConsultarDatosPersonales);
        }
    }
}
