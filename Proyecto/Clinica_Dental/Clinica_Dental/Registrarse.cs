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
    class Registrarse
    {
        public void Registrar(TextBox txtUsuario_Login, TextBox txtContraseña_Login, TextBox txtTelefono_Registrarse, TextBox txtEmail_Registrarse, TextBox txtGenero_Registrarse, TextBox txtNombre_Registrarse, TextBox txtDui_Registrarse, DateTimePicker dateTimePickerNacimiento_Registrarse)
        {
            Conexión registro = new Conexión();
            SqlConnection connection = registro.GetConnection();

            string strcomando = "Insert_Usuarios";
            string strcomando2 = "Insert_Cliente";
            connection.Open();

            SqlCommand comando = new SqlCommand(strcomando, connection);
            SqlCommand comando2 = new SqlCommand(strcomando2, connection);
            DateTime fecha = DateTime.Today;
            int edad;

            try
            {

                comando.CommandType = CommandType.StoredProcedure;


                comando.Parameters.AddWithValue("@Usuario", txtUsuario_Login.Text);
                comando.Parameters.AddWithValue("@Tipo", "Cliente");
                comando.Parameters.AddWithValue("@Contraseña", txtContraseña_Login.Text);
                comando.ExecuteNonQuery();

                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.AddWithValue("@Us", txtUsuario_Login.Text);
                comando2.Parameters.AddWithValue("@Telefono", int.Parse(txtTelefono_Registrarse.Text));
                comando2.Parameters.AddWithValue("@correo", txtEmail_Registrarse.Text);
                comando2.Parameters.AddWithValue("@genero", txtGenero_Registrarse.Text);
                comando2.Parameters.AddWithValue("@nombre", txtNombre_Registrarse.Text);
                comando2.Parameters.AddWithValue("@edad", edad = fecha.Year - dateTimePickerNacimiento_Registrarse.Value.Year);
                comando2.Parameters.AddWithValue("@dui", int.Parse(txtDui_Registrarse.Text));


                comando2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registros agregados, por favor inicie sesión", "Proceso exitoso");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
    }
}
