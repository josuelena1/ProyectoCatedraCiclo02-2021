using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Windows_ClinicaDental
{
    internal class DatabaseIO
    {
        public static string sqlCnnStr = "Data Source=127.0.0.1;Initial Catalog=ClinicaDental;Persist Security Info=True;User ID=sa;Password=Canas13-7";
        public static SqlConnection cnn = new SqlConnection();
        public static (bool, string) StartDB()
        {
            bool error = false;
            string exception = string.Empty;
            cnn.ConnectionString = sqlCnnStr;
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                error = true;
                exception = ex.Message;
            }
            return (error, exception);
        }

        public static bool CloseDB()
        {
            bool state = true;
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
                state = false;
            }
            return state;
        }

        public static (bool, string) PingDB()
        {
            bool error = false;
            string exception = string.Empty;
            (error, exception) = StartDB();
            if (cnn.State == System.Data.ConnectionState.Open) CloseDB();
            return (error, exception);
        }
    }
}
