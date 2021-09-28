using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
            newCnnStr.Text = DatabaseIO.sqlCnnStr;
            int hour = DateTime.Now.Hour;
            if (hour >= 7 && hour < 12) loginWelcome.Text = "Buenos Días";
            else if (hour >= 12 && hour < 19) loginWelcome.Text = "Buenas Tardes";
            else if (hour < 6 || hour >= 19) loginWelcome.Text = "Buenas Noches";
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pingDB_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            string exception = string.Empty;
            (error, exception) = DatabaseIO.PingDB();
            if (error)
            {
                if (notifBar.IsOpen) notifBar.IsOpen = false;
                notifBar.Title = "No se logro la conexion.";
                notifBar.Content = "No se logro conectar a la base de datos por medio de la cadena de conexion.\n" +
                    "Intenta cambiando la cadena por medio del boton 'Cambiar texto de conexion'\n\n" +
                    "Informacion del error: Revisa el Visor de Eventos\n";
                notifBar.IsTextScaleFactorEnabled = true;
                notifBar.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error;
                notifBar.IsOpen = true;
            }
            else
            {
                if (notifBar.IsOpen) notifBar.IsOpen = false;
                notifBar.Title = "Pre-conexion Exitosa";
                notifBar.Content = "Se logro conectar a la base de datos. Puedes iniciar sesion ahora.\n";
                notifBar.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Success;
                notifBar.IsOpen = true;
            }
        }

        private void changeCnnStr_Click(object sender, RoutedEventArgs e)
        {
            DatabaseIO.sqlCnnStr = newCnnStr.Text;
            changeCnnStrFlyout.Hide();
            if (notifBar.IsOpen) notifBar.IsOpen = false;
            notifBar.Title = "Cadena de conexion cambiada";
            notifBar.Content = "Antes de iniciar sesion, te recomiendo realizar una prueba de ping.\n";
            notifBar.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Success;
            notifBar.IsOpen = true;
        }
    }
}
