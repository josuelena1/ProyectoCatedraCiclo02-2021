using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace Clinica_Dental
{
    class Servicios
    {
        public void datos(DataGridView dgv_ServiciosDisponibles)
        {
            Conexión registro = new Conexión();
            SqlConnection connection = registro.GetConnection();

            string str = "select * from Procedimientos";
            SqlCommand comando = new SqlCommand(str, connection);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable table = new DataTable();
            adaptador.Fill(table);
            dgv_ServiciosDisponibles.DataSource = table;
        }
    }
}
