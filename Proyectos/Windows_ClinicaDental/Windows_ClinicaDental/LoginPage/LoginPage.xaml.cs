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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.LoginPage
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public static sqlLoginUser currentUser;
        public LoginPage()
        {
            this.InitializeComponent();
            PwdTip.IsOpen = true;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Password))
            {
                if (String.IsNullOrEmpty(username.Text) && String.IsNullOrEmpty(password.Password))
                {
                    var info = new infoBar();
                    info.Title = "Ocurrio un error";
                    info.Message = "Empty Box Error. No puedes dejar los campos 'Nombre de Usuario' y 'Contraseña' vacios.";
                    info.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error;
                    infoBar.CreateInfoBar(info);
                }
                else if (String.IsNullOrEmpty(password.Password))
                {
                    var info = new infoBar();
                    info.Title = "Ocurrio un error";
                    info.Message = "Empty Box Error. No puedes dejar el campo 'Contraseña' vacio.";
                    info.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error;
                    infoBar.CreateInfoBar(info);
                }
                else if (String.IsNullOrEmpty(username.Text))
                {
                    var info = new infoBar();
                    info.Title = "Ocurrio un error";
                    info.Message = "Empty Box Error. No puedes dejar el campo 'Nombre de Usuario' vacio.";
                    info.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error;
                    infoBar.CreateInfoBar(info);
                }
            }
            else
            {
                (bool sqlState, int message, sqlLoginUser userGet) = sqlLoginUser.Login(username.Text, password.Password);
                if (sqlState)
                {
                    var info = new infoBar();
                    switch (message)
                    {
                        case -1:
                            currentUser = userGet;
                            MainPage.Current.content.Navigate(typeof(HomePage.HomePageBase));
                            info = new infoBar()
                            {
                                Title = "Bienvenido, " + currentUser.Name + " " + currentUser.LastName,
                                Message = "Has iniciado sesion correctamente.",
                                Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Success
                            };
                            infoBar.CreateInfoBar(info);
                            break;
                        case 0:
                            info = new infoBar()
                            {
                                Title = "Ocurrio un error",
                                Message = "SQL Connection Error. No se ha logrado establecer una conexion con SQL Server.\n" +
                                "Verifica si los servicios estan ejecutandose o si el TCP/IP esta habilitado.",
                                Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                            };
                            infoBar.CreateInfoBar(info);
                            break;
                        case 1:
                            info = new infoBar()
                            {
                                Title = "Ocurrio un error",
                                Message = "Database Error. No se encontro en la base de datos al usuario requerido.",
                                Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                            };
                            infoBar.CreateInfoBar(info);
                            break;
                        case 2:
                            info = new infoBar()
                            {
                                Title = "Ocurrio un error",
                                Message = "Database Error. El usuario y la contraseña no coinciden.",
                                Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                            };
                            infoBar.CreateInfoBar(info);
                            break;
                    }
                }
                else
                {
                    _ = new infoBar()
                    {
                        Title = "Ocurrio un error",
                        Message = "SQL Connection Error. No se ha logrado establecer una conexion con SQL Server.\n" +
                                "Verifica si los servicios estan ejecutandose o si el TCP/IP esta habilitado.",
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                    };
                }
            }
        }

        private void password_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) login_Click(new object(), new RoutedEventArgs());
        }
    }
}
