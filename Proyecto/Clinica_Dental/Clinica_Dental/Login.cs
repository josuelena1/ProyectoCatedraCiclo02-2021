using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;                //agregar
using System.Data.SqlClient;          //agregar
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;        //agregar
using System.Text.RegularExpressions;

namespace Clinica_Dental
{
    class Login
    {
        public static string datos_usuario;
        public void LogIn(TextBox txtUsuario_Login, TextBox txtContraseña_Login)
        {
            Conexión registro = new Conexión();
            SqlConnection connection = registro.GetConnection();
            connection.Open();
            string query = "select * from Usuarios where Usuario= '" + txtUsuario_Login.Text.Trim() + "' and Contraseña = '" + txtContraseña_Login.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            try
            {
                if (dtbl.Rows.Count != 1)
                {
                    MessageBox.Show("Usuario o contraseña incorrecta", "Error"); //Despues de la coma es el encabezado de la pestaña
                }
                else
                {
                    MessageBox.Show("Acceso permitido", "Acceso");
                    Form_Login inicio = new Form_Login();
                    inicio.Hide();
                    Login.datos_usuario = txtUsuario_Login.Text.Trim();
                    if (dtbl.Rows[0][1].ToString() == "administrador")
                    {
                        Form_MenuAdministrador menuAdministrador = new Form_MenuAdministrador();
                        menuAdministrador.Show();
                    }

                    else if (dtbl.Rows[0][1].ToString() == "Cliente")
                    {
                        Form_MenuClientes menuCLientes = new Form_MenuClientes();

                        menuCLientes.Show();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
