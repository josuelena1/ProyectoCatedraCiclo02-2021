using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Extra librarys
using Microsoft.Win32;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Drawing.Text;
using System.Diagnostics;
using Windows.Storage;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.BeforeLogin
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ReqCheckPage : Page
    {
        public static ReqCheckPage Current;
        public ReqCheckPage()
        {
            this.InitializeComponent();
            Current = this;
            checker();
        }

        //
        //Current.progressBar.ShowError = true;
        //Current.errorInfo.Text = "Actualmente no tienes instalado SQL Server o tu instalacion esta incorrecta\n" +
        //"Intenta instalar o reinstalar SQL Server con su ultima version.\n";
        //Current.errorBox.Visibility = Visibility.Visible;

        public static async void checker()
        {
            Current.actualProcessInfo.Text = "Verificando si existen llaves de configuracion del sistema.";
            await Task.Delay(1000);
            if (await AppConfigCheck())
            {
                Current.actualProcessInfo.Text = "Verificando la instalacion de SQL Server";
                await Task.Delay(1000);
                if (SQLServerCheck())
                {
                    Current.actualProcessInfo.Text = "Verificando la conexion a SQL Server";
                    await Task.Delay(1000);
                    if (sqlDataConnector.SQLServerCnnTest())
                    {
                        Current.actualProcessInfo.Text = "Verificando la integridad de conexion a la base de datos";
                        await Task.Delay(1000);
                        (bool status, bool dbStatus) = sqlDataConnector.SSdbChecker();
                        if (status)
                        {
                            if (dbStatus)
                            {
                                Current.actualProcessInfo.Text = "Verificando si existen las fuentes requeridas";
                                await Task.Delay(1000);
                                await RequiredFontCheck();
                                Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                                await Task.Delay(1000);
                                MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                            }
                            else
                            {
                                Current.actualProcessInfo.Text = "Descargando e instalando la base de datos. Por favor no desconecte la red, esto terminara enseguida.";
                                await Task.Delay(1000);
                                if (await sqlDataConnector.SSdbCreator())
                                {
                                    Current.actualProcessInfo.Text = "Verificando si existen las fuentes requeridas";
                                    await Task.Delay(1000);
                                    await RequiredFontCheck();
                                    Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                                    await Task.Delay(1000);
                                    MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                                }
                                else
                                {
                                    Current.progressBar.ShowError = true;
                                    Current.errorInfo.Text = "No se ha logrado crear y conectar con la base de datos.\n" +
                                    "Comunica al desarrollador sobre el problema.";
                                    Current.errorBox.Visibility = Visibility.Visible;
                                }
                            }
                        }
                        else
                        {
                            Current.progressBar.ShowError = true;
                            Current.errorInfo.Text = "No se ha logrado la conexion con SQL Server.\n" +
                            "Puede que la configuracion del servidor sea erronea, los servicios referenciados a SQL Server\n" +
                            "no se hallan iniciado, el servidor no se encuentre disponible o habilitado; o la configuracion\n" +
                            "TCP/IP de SQL Server no se encuentre habilitada en el dispositivo.";
                            Current.errorBox.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        Current.progressBar.ShowError = true;
                        Current.errorInfo.Text = "No se ha logrado la conexion con SQL Server.\n" +
                        "Puede que la configuracion del servidor sea erronea, los servicios referenciados a SQL Server\n" +
                        "no se hallan iniciado, el servidor no se encuentre disponible o habilitado; o la configuracion\n" +
                        "TCP/IP de SQL Server no se encuentre habilitada en el dispositivo.";
                        Current.errorBox.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Current.progressBar.ShowError = true;
                    Current.errorInfo.Text = "No se ha detectado ninguna instalacion de SQL Server. Puede que la instalacion" +
                        "sea erronea o incorrecta.\n" +
                    "Intenta instalar o reinstalar SQL Server con su ultima version.\n";
                    Current.errorBox.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Current.progressBar.ShowError = true;
                Current.errorInfo.Text = "No se ha logrado establecer las llaves predeterminadas de la aplicacion\n" +
                "Comuniquese con s.\n";
                Current.errorBox.Visibility = Visibility.Visible;
            }
        }

        public static async Task<bool> AppConfigCheck() //Revisando si la configuracion de la aplicacion se encuentra disponible
        {
            bool finalState = false;
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("sqlPwd"))
            {
                finalState = true;
            }
            else
            {
                Current.actualProcessInfo.Text = "Creando llaves de configuracion del sistema.";
                await Task.Delay(1000);
                localSettings.Values.Clear();
                Current.actualProcessInfo.Text = "Creando las llaves de configuracion. Espere un momento.";
                localSettings.Values.Add("sqlPingMode", "local");
                localSettings.Values.Add("sqlPingServer", "");
                localSettings.Values.Add("sqlPingPort", "");
                localSettings.Values.Add("sqlLoginMode", "Windows");
                localSettings.Values.Add("sqlUser", "");
                localSettings.Values.Add("sqlPwd", "");
                if (localSettings.Values.ContainsKey("sqlPwd")) finalState = true;
                else finalState = false;
            }
            return finalState;
        }

        public static bool SQLServerCheck() //Revisando si SQL Server se encuentra instalado en la PC
        {

            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server", false);
                if (instanceKey != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static async Task<bool> RequiredFontCheck() //Revisando si existen las fuentes necesarias
        {
            bool fontState = false;
            var fonts = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();
            foreach (var font in fonts)
            {
                if (font == "Segoe Fluent Icons") fontState = true;
            }
            if (!fontState)
            {
                Uri launch = new Uri(@"https://aka.ms/SegoeFluentIcons");
                await Windows.System.Launcher.LaunchUriAsync(launch);
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Instalar nueva fuente";
                dialog.Content = "Antes de continuar...\n\n" +
                    "En estos momentos se acaba de mostrar una ventana de descarga desde el navegador. " +
                    "Esto significa que en estos momentos no tienes la fuente requerida instalada en tu " +
                    "PC / Cuenta de Usuario.\n\n" +
                    "Para que puedas ver los iconos de la aplicacion de manera completa, necesitamos que instales la fuente. Solo debes decomprimir el archivo\n" +
                    "e instalar el archivo .ttf\n\nNo te preocupes, la descarga se realiza desde la pagina oficial de Microsoft.";
                dialog.CloseButtonText = "Listo";
                dialog.IsPrimaryButtonEnabled = false;
                dialog.IsSecondaryButtonEnabled = false;
                var close = await dialog.ShowAsync();
                fontState = true;
            }
            return fontState;
        } 
    }
}
