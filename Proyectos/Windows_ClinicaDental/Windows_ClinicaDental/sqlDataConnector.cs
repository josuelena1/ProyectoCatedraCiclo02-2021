using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
//Extra libraries
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Windows.Storage;
using Windows.Networking.BackgroundTransfer;
using Windows.Foundation;

namespace Windows_ClinicaDental
{
    public class sqlDataConnector
    {
        public static SettingsReader sqlSettings = new SettingsReader();
        public static bool SQLServerCnnTest() //Prueba si se puede conectar SQL Server
        {
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings,"master"));
            cnn.Open();
            try
            {
            }
            catch (SqlException)
            {
                return false;
            }
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static (bool, bool) SSdbChecker()
        {
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "master"));
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                }
                catch (SqlException)
                {
                    return (false, false);
                }
            }
            if (cnn.State == ConnectionState.Open)
            {
                string checker = "SELECT DB_ID(@dbName)";
                SqlCommand cmd = new SqlCommand(checker, cnn);
                cmd.Parameters.AddWithValue("@dbName", "ClinicaDental");
                bool dbState = cmd.ExecuteScalar() is DBNull ? false : true;
                cnn.Close();
                return (true, dbState);
            }
            else return (false,false);
        }

        public static async Task<bool> SSdbCreator()
        {
            StorageFile sqlQuery;
            if (!File.Exists(ApplicationData.Current.LocalFolder.Path + @"\DB_Creator.sql"))
            {
                sqlQuery = await ApplicationData.Current.LocalFolder.CreateFileAsync("DB_Creator.sql");
            }
            else
            {
                sqlQuery = await ApplicationData.Current.LocalFolder.GetFileAsync("DB_Creator.sql");
            }
            try
            {
                Uri source = new Uri("https://raw.githubusercontent.com/Oscar-02/ProyectoPOO_MDB/master/Proyectos/Windows_ClinicaDental/Windows_ClinicaDental/DatabaseQuerys/DB_Creator.sql");
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, sqlQuery);
                await download.StartAsync();

            }
            catch (Exception)
            {
                return false;
            }
            var getfFile = await ApplicationData.Current.LocalFolder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByName);
            var foundfile = getfFile.FirstOrDefault(x => x.Name == "DB_Creator.sql");
            if (foundfile != null)
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "master"));
                try
                {
                    cnn.Open();
                }
                catch (SqlException)
                {
                    return false;
                }
                if (cnn.State == ConnectionState.Open)
                {
                    StorageFile query = await ApplicationData.Current.LocalFolder.GetFileAsync("DB_Creator.sql");
                    string data = await FileIO.ReadTextAsync(query);
                    Server server = new Server(new ServerConnection(cnn));
                    server.ConnectionContext.ExecuteNonQuery(data);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; }
        }
    }

    public class sqlLoginUser
    {
        public static SettingsReader sqlSettings = new SettingsReader();

        public string UserName {  get; set; }
        protected string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int JobPosition { get; set; }
        public int Role { get; set; }

        public static (bool,  int, sqlLoginUser) Login(string username, string password)
        {
            bool state = false;
            int message = 3;
            /*
             * message -1 : INICIO DE SESION CORRECTO
             * message 0 : Error - SQL Server
             * message 1 : Error - No username
             * message 2 : Error - pwd Incorrecta
             * message 3 : default
             */
            sqlLoginUser current = new sqlLoginUser();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "ClinicaDental"));
            try
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open) state = true;
            }
            catch (SqlException)
            {
                state = false;
                message = 0;
            }
            if (state)
            {
                string cmdText = "SELECT * FROM SystemUsers WHERE username = @username";
                SqlCommand cmd = new SqlCommand(cmdText, cnn);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        current.UserName = reader["username"].ToString();
                        current.Password = reader["password"].ToString();
                        current.Name = reader["Name"].ToString();
                        current.LastName = reader["LastName"].ToString();
                        current.JobPosition = int.Parse(reader["ID_JobPosition"].ToString());
                        current.Role = int.Parse(reader["Role"].ToString());
                    }
                }
                else
                {
                    message = 1;
                }
                if (message > 1)
                {
                    //Encripta la contraseña ingresada en la pagina
                    String pwdEncrypted = "";
                    StringBuilder stringBuilder = new StringBuilder();
                    SHA256 converter = SHA256Managed.Create();
                    Encoding utf8 = Encoding.UTF8;
                    Byte[] finish = converter.ComputeHash(utf8.GetBytes(password));
                    //Completa de nuevo la contraseña ya encriptada
                    foreach (byte b in finish) stringBuilder.Append(b.ToString("x2"));
                    pwdEncrypted = stringBuilder.ToString();

                    if (current.Password == pwdEncrypted)
                    {
                        message = -1;
                    }
                    else
                    {
                        message = 2;
                        current = null;
                    }
                }
            }
            return (state,  message , current);
        }
        
    }

    public class sqlSystemUsers
    {
        #region sqlSysUsersVar
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ID_Sex { get; set; }
        public DateTime DateBirth { get; set; }
        public int ID_JobPosition { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string LandLinePhone { get; set; }
        public int Role { get; set; }
        #endregion

        public static (bool,List<sqlSystemUsers>) GetTable() //Obtiene los datos de la tabla SystemUsers
        {
            List<sqlSystemUsers> sysUsersList = new List<sqlSystemUsers>();
            SettingsReader settings = new SettingsReader();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(settings, "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [SystemUsers]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlSystemUsers data = new sqlSystemUsers();
                    data.ID = int.Parse(reader["id"].ToString());
                    data.Username = reader["username"].ToString();
                    data.Password = reader["password"].ToString();
                    data.Name = reader["Name"].ToString();
                    data.LastName = reader["LastName"].ToString();
                    data.ID_Sex = int.Parse(reader["ID_Sex"].ToString());
                    data.DateBirth = reader.GetDateTime(6);
                    data.ID_JobPosition = int.Parse(reader["ID_JobPosition"].ToString());//INT
                    data.Address = reader["Address"].ToString();
                    data.Cellphone = reader["CellPhone"].ToString();//FORMAT
                    data.LandLinePhone = reader["LandLinePhone"].ToString();//FORMAT
                    data.Role = int.Parse(reader["Role"].ToString());//INT
                    sysUsersList.Add(data);
                }
                reader.Close();
                cnn.Close();
                if (sysUsersList.Count > 0)
                {
                    return (true, sysUsersList);
                }
                else return (false, null);
            }
            else return (false, null);
        }
    }

    public class sqlRoles
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static (bool, List<sqlRoles>) GetTable()
        {
            List<sqlRoles> listRoles = new List<sqlRoles>();
            SettingsReader settings = new SettingsReader();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(settings, "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch (SqlException) 
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Roles]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlRoles role = new sqlRoles()
                    {
                        ID = int.Parse(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    listRoles.Add(role);
                }
                reader.Close();
                cnn.Close();
                if (listRoles.Count > 0)
                {
                    return (true, listRoles);
                }
                else
                {
                    return (false, null);
                }
            }
            else
            {
                return (false, null);
            }
        }
    }

    public class sqlJobPosition
    {
        public int ID { get; set; }
        public string Position { get; set; }

        public static (bool, List<sqlJobPosition>) GetTable()
        {
            List<sqlJobPosition> listPosition = new List<sqlJobPosition>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [JobPosition]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlJobPosition position = new sqlJobPosition()
                    {
                        ID = int.Parse(reader["id"].ToString()),
                        Position = reader["Position"].ToString()
                    };
                    listPosition.Add(position);
                }
                if (listPosition.Count > 0)
                {
                    return(true, listPosition);
                }
                else return(false, null);
            }
            else return (false, null);
        }
    }

    public class sqlSex
    {
        public int ID { get; set; }
        public string Sex { get; set; }

        public static (bool, List<sqlSex>) GetTable()
        {
            List<sqlSex> listSex = new List<sqlSex>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Sex]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlSex sex = new sqlSex()
                    {
                        ID = int.Parse(reader["id"].ToString()),
                        Sex = reader["Sex"].ToString()
                    };
                    listSex.Add(sex);
                }
                if (listSex.Count > 0)
                {
                    return (true, listSex);
                }
                else return (false, null);
            }
            else return (false, null);
        }
    }

    public class sqlAllergies
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static (bool, List<sqlAllergies>) GetTable()
        {
            List<sqlAllergies> listAllergies = new List<sqlAllergies>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Allergies]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlAllergies data = new sqlAllergies()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString()
                    };
                    listAllergies.Add(data);
                }
                if (listAllergies.Count > 0)
                {
                    return (true, listAllergies);
                }
                else
                {
                    return (false, null);
                }
            }
            return (false, null);
        }
    }

    public class sqlTreatments
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public static (bool, List<sqlTreatments>) GetTable()
        {
            List<sqlTreatments> listTreatments = new List<sqlTreatments>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Treatments]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlTreatments data = new sqlTreatments()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = float.Parse(reader["Price"].ToString())
                    };
                    listTreatments.Add(data);
                };
                if (listTreatments.Count > 0)
                {
                    return (true, listTreatments);
                }
                else return (false, null);
            }
            return (false, null);
        }
    }
    
    public class sqlPatients
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ID_Sex { get; set; }
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string LandLinePhone { get; set; }
        public int ID_Treatments { get; set; }
        public int ID_Allergies { get; set; }

        public static (bool, List<sqlPatients>) GetTable()
        {
            List<sqlPatients> listPatients = new List<sqlPatients>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Patients]", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlPatients data = new sqlPatients()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        ID_Sex = int.Parse(reader["ID_Sex"].ToString()),
                        DateBirth = reader.GetDateTime(4),
                        Address = reader["Address"].ToString(),
                        CellPhone = reader["CellPhone"].ToString(),
                        LandLinePhone = reader["LandLinePhone"].ToString(),
                        ID_Treatments = int.Parse(reader["ID_Treatments"].ToString()),
                        ID_Allergies = int.Parse(reader["ID_Allergies"].ToString())
                    };
                    listPatients.Add(data);
                }
                if (listPatients.Count > 0)
                {
                    return(true, listPatients);
                }
                else
                {
                    return(false, null);
                }
            }
            else return (false, null);
        }
    }

    public class sqlAppointments
    {
        public int ID { get; set; }
        public int ID_Patient { get; set; }
        public int ID_SystemUser { get; set; }
        public int ID_Treatment { get; set; }
        public string Observations { get; set; }
        public DateTime Date { get; set; }

        public static (bool, List<sqlAppointments>) GetTable()
        {
            List<sqlAppointments> listApp = new List<sqlAppointments>();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
            try
            {
                cnn.Open();
            }
            catch
            {
                return (false, null);
            }
            if (cnn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Appointments] ORDER BY Date ASC", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlAppointments data = new sqlAppointments()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        ID_Patient = int.Parse(reader["ID_Patient"].ToString()),
                        ID_SystemUser = int.Parse(reader["ID_SystemUser"].ToString()),
                        ID_Treatment = int.Parse(reader["ID_Treatment"].ToString()),
                        Observations = reader["Observations"].ToString(),
                        Date = reader.GetDateTime(5)
                    };
                    listApp.Add(data);
                }
                if (listApp.Count > 0)
                {
                    return (true, listApp);
                }
                else return (false, null);
            }
            else return (false, null);
        }
    }
}
