using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Agregar libreria

namespace Clinica_Dental
{
    class Conexión
    {
        public SqlConnection GetConnection()
        {

            string str = "server=(localdb)\\MSSQLLocalDB; uid= ; pwd= ; database= Clinica_Dental_Doctor; Trusted_Connection=True; MultipleActiveResultSets=True";
            SqlConnection connection = new SqlConnection(str);
            return connection;
        }
    }
}
