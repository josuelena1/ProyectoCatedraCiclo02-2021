using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Extra libraries
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewItemInvokedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.HomePage
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomePageBase : Page
    {
        public static HomePageBase Current;
        public HomePageBase()
        {
            this.InitializeComponent();
            Current = this;
            main.Navigate(typeof(PacientesCitas.AppointmentsPage));
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked) { }
            else
            {
                string page = args.InvokedItemContainer.Tag.ToString();
                switch (page)
                {
                    //Seccion Pacientes y ServicesPage
                    case "Patients":
                        main.Navigate(typeof(PacientesCitas.PatientsPage));
                        break;
                    case "Appt":
                        main.Navigate(typeof(PacientesCitas.AppointmentsPage));
                        break;
                    //Seccion Datos
                    case "PatientsData":
                        main.Navigate(typeof(Datos.PatientsDataPage));
                        break;
                    //Seccion Ajustes
                    case "SystemUserSettings":
                        main.Navigate(typeof(Settings.SystemUserSettings));
                        break;
                    case "Settings":
                        main.Navigate(typeof(Settings.Settings));
                        break;
                }
            }
        }
    }
}
