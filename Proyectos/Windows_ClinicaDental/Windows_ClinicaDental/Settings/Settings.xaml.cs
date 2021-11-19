using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Extra libraries
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Windows.Storage;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        //ARREGLAR LA PUTA PAGINA QUE SE JODIO
        public static SettingsReader reader;
        public Settings()
        {
            this.InitializeComponent();
            reader = new SettingsReader();
            cnnServerMode.SelectedIndex = reader.sqlPingMode == "local" ? 0 : 1;
            cnnLoginMode.SelectedIndex = reader.sqlLoginMode == "Windows" ? 0 : 1;
            cnnIPInfo.Text = reader.sqlPingServer;
            cnnIPInfo.Visibility = cnnServerMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnPortInfo.Text = reader.sqlPingPort;
            cnnPortInfo.Visibility = cnnIPInfo.Visibility;
            tcpInfoBar.Visibility = cnnIPInfo.Visibility;
            //tcpInformation.IsOpen = cnnIPInfo.Visibility == Visibility.Visible ? true : false;
            cnnSqlUser.Text = reader.sqlUser;
            cnnSqlPwd.Password = reader.sqlPwd;
            cnnSqlUser.Visibility = cnnLoginMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnSqlPwd.Visibility = cnnSqlUser.Visibility;
        }

        private void cnnServerMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cnnIPInfo.Text = String.Empty;
            cnnPortInfo.Text = String.Empty;
            cnnIPInfo.Visibility = cnnServerMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnPortInfo.Visibility = cnnIPInfo.Visibility;
            tcpInfoBar.Visibility = cnnIPInfo.Visibility;
        }

        private void cnnLoginMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cnnSqlUser.Text = String.Empty;
            cnnSqlPwd.Password = String.Empty;
            cnnSqlUser.Visibility = cnnLoginMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnSqlPwd.Visibility = cnnSqlUser.Visibility;
        }

        private async void cnnTest_Click(object sender, RoutedEventArgs e)
        {
            string cnnString = "";
            cnnString = cnnServerMode.SelectedIndex == 0 ? "Data Source=(local);" : "Data Source=" + cnnIPInfo.Text + "," + cnnPortInfo.Text + ";";
            cnnString += "Initial Catalog=ClinicaDental;";
            cnnString += cnnLoginMode.SelectedIndex == 0 ? "Integrated Security=True;" : 
                "Integrated Security=False;User Id=" + cnnSqlUser.Text + ";Password=" + cnnSqlPwd.Password;
            SqlConnection cnn = new SqlConnection(cnnString);
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                infoBar error = new infoBar()
                {
                    Title = "Error al conectar a la base de datos.",
                    Message = "Pueda que las credenciales no sean las correctas, el servidor no exista o no se\n" +
                    "encuentre disponible, o incluso los servicios y/o configuracion TCP/IP de SQL Server no este\n" +
                    "habilitada. NO SE HA REALIZADO NINGUN CAMBIO.",
                    Severity = InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                ContentDiag diag = new ContentDiag()
                {
                    Title = "Conexion Exitosa.",
                    Content = "La conexion se ha realizado correctamente. ¿Deseas aplicar esta nueva configuracion " +
                    "desde ahora?\nEstos ajustes no se podra cambiar desde la aplicacion si no se logra la conexion al iniciarla.",
                    PrimBtnEnable = true,
                    PrimBtnText = "Guardar configuracion",
                    SecBtnEnable = false,
                    CloseBtnText = "No guardar",
                    DefaultBtn = 1            
                };
                ContentDialogResult result = await ContentDiag.DiagOpen(diag);
                if (result == ContentDialogResult.Primary)
                {
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["sqlPingMode"] = cnnServerMode.SelectedIndex == 0 ? "local" : "tcp/ip";
                    localSettings.Values["sqlPingServer"] = cnnIPInfo.Text;
                    localSettings.Values["sqlPingPort"] = cnnPortInfo.Text;
                    localSettings.Values["sqlLoginMode"] = cnnLoginMode.SelectedIndex == 0 ? "Windows" : "SQL";
                    localSettings.Values["sqlUser"] = cnnSqlUser.Text;
                    localSettings.Values["sqlPwd"] = cnnSqlPwd.Password;
                    HomePage.HomePageBase.Current.main.Navigate(typeof(Settings));
                    #region RELOAD ELEMENTS
                    SettingsReader checker = new SettingsReader();
                    cnnServerMode.SelectedIndex = reader.sqlPingMode == "local" ? 0 : 1;
                    cnnLoginMode.SelectedIndex = reader.sqlLoginMode == "Windows" ? 0 : 1;
                    cnnIPInfo.Text = reader.sqlPingServer;
                    cnnIPInfo.Visibility = cnnServerMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
                    cnnPortInfo.Text = reader.sqlPingPort;
                    cnnPortInfo.Visibility = cnnIPInfo.Visibility;
                    cnnSqlUser.Text = reader.sqlUser;
                    cnnSqlPwd.Password = reader.sqlPwd;
                    cnnSqlUser.Visibility = cnnLoginMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
                    cnnSqlPwd.Visibility = cnnSqlUser.Visibility;
                    #endregion
                    infoBar resultBar = new infoBar()
                    {
                        Title = "Datos guardados correctamente",
                        Message = "Se han guardado los datos correctamente. Esta es la nueva string de conexion:\n" +
                        SettingsReader.sqlCnnStringMaker(checker, "ClinicaDental"),
                        Severity = InfoBarSeverity.Success
                    };
                    infoBar.CreateInfoBar(resultBar);
                }
            }
        }
    }
}
