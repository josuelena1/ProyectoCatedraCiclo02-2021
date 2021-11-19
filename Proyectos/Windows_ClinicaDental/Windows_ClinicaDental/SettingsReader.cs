using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Extra Libraries
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace Windows_ClinicaDental
{
    public class SettingsReader
    {
        #region SQL Settings Variables
        public string sqlLoginMode { get; }
        public string sqlPingMode { get; }
        public string sqlPingServer { get; }
        public string sqlPingPort { get; }
        public string sqlUser { get; }
        public string sqlPwd { get; }
        #endregion


        public SettingsReader()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            sqlPingMode = localSettings.Values["sqlPingMode"].ToString();
            sqlPingServer = localSettings.Values["sqlPingServer"].ToString();
            sqlPingPort = localSettings.Values["sqlPingPort"].ToString();
            sqlLoginMode = localSettings.Values["sqlLoginMode"].ToString();
            sqlUser = localSettings.Values["sqlUser"].ToString();
            sqlPwd = localSettings.Values["sqlPwd"].ToString();
        }

        //"Integrated Security=true; Initial Catalog=master; server=127.0.0.1,1433"
        public static string sqlCnnStringMaker(SettingsReader settings, string CatalogInit)
        {
            string authMode = settings.sqlLoginMode == "Windows" ? "Integrated Security=True" : "Integrated Security=False";
            string server = settings.sqlPingMode == "local" ? "Data Source=(local)" : "Data Source=" + settings.sqlPingServer + "," + settings.sqlPingPort;
            string intialCat = "Initial Catalog=" + CatalogInit;
            string cnnStr = server + "; TrustServerCertificate=True;" + authMode + ";" + intialCat + ";";
            if (settings.sqlLoginMode != "Windows")
            {
                cnnStr += "User Id=" + settings.sqlUser + ";" + "Password=" + settings.sqlPwd + ";";
            }
            return cnnStr;
        }
    }
}
