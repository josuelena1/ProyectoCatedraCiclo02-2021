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
//Extra Libraries
using Microsoft.Data.SqlClient;

// La plantilla de elemento del cuadro de diálogo de contenido está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings.Diags
{
    public sealed partial class JobPositions : ContentDialog
    {
        public JobPositions()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (String.IsNullOrEmpty(JobPosition.Text))
            {
                infoBar errorBar = new infoBar()
                {
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                    Title = "Ocurrio un error al agregar la posicion laboral",
                    Message = "Verifica si todas las casillas no estan vacias"
                };
                infoBar.CreateInfoBar(errorBar);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    string cmdStr = "IF NOT EXISTS (SELECT * FROM [JobPosition] WHERE [JobPosition].[Position] = @position)\n" +
                        "INSERT INTO[JobPosition] VALUES(@position)";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@position", JobPosition.Text);
                    cmd.ExecuteNonQuery();
                    HomePage.HomePageBase.Current.main.Navigate(typeof(SystemUserSettings));
                }
            }
        }
    }
}
