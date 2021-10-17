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
    class DatosUsuarios
    {
        public void mostrarUsuario(TextBox txtNombre_ConsultarDatosPersonales, TextBox txtEmail_ConsultarDatosPersonales, TextBox txtEdad_ConsultarDatosPersonales, TextBox txtUsuario_ConsultarDatosPersonales, TextBox txtDui_ConsultarDatosPersonales, TextBox txtTelefono_ConsultarDatosPersonales, TextBox txtGenero_ConsultarDatosPersonales)
        {
            Conexión registro = new Conexión();
            SqlConnection connection = registro.GetConnection();

            connection.Open();
            string strproc = "mostrar_Cliente";
            SqlCommand comando = new SqlCommand(strproc, connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", Login.datos_usuario);


            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                txtNombre_ConsultarDatosPersonales.Text = leer.GetValue(0).ToString();
                txtEmail_ConsultarDatosPersonales.Text = leer.GetValue(1).ToString();
                txtEdad_ConsultarDatosPersonales.Text = leer.GetValue(3).ToString();
                txtUsuario_ConsultarDatosPersonales.Text = Login.datos_usuario;
                txtDui_ConsultarDatosPersonales.Text = leer.GetValue(4).ToString();
                txtTelefono_ConsultarDatosPersonales.Text = leer.GetValue(5).ToString();
                txtGenero_ConsultarDatosPersonales.Text = leer.GetValue(6).ToString();

            }
            connection.Close();


        }
    }
}
