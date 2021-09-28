using System;
using System.Windows;
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
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace Windows_ClinicaDental
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Verifica si el tamaño de la pantalla es de 1024x768
            if (!(DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels < 1024 &&
                DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels < 768))
            {
                content.Navigate(typeof(AccountPage));
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Verifica y reajusta el tamaño de la ventana
            Window.Current.CoreWindow.SizeChanged += (s, arg) =>
            {
                double width, height;
                (width, height) = (this.ActualWidth, this.ActualHeight);
                if (width < 900 || height < 600)
                {
                    if (notifBar.IsOpen)
                    {
                        notifBar.IsOpen = false;
                    }
                    notifBar.Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Warning;
                    notifBar.Title = "Error en dimensiones de la ventana";
                    notifBar.Content = "La ventana debe poseer como tamaño minimo la resolucion 900x600\n";
                    notifBar.IsOpen = true;
                    ApplicationView.GetForCurrentView().TryResizeView(new Size(900, 600));
                }
                arg.Handled = true;
            };
        }
    }
}
