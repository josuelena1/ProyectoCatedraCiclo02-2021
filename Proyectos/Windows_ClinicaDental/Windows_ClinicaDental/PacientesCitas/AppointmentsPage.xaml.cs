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
//Extra libraries
using Microsoft.Data.SqlClient;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.PacientesCitas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AppointmentsPage : Page
    {
        public AppointmentsPage()
        {
            this.InitializeComponent();
            appGetList();
            appList.ItemsSource = uiList(0);
            viewEdit.IsEnabled = false;
            delete.IsEnabled = false;
            infoA.Visibility = Visibility.Collapsed;
            ButtonsActionCaller();
            ComboLoader();
            dateA.MinDate = DateTime.Now.AddDays(1);
        }

        private async void save_Click(object sender, RoutedEventArgs e)
        {
            bool state = 
                patientA.SelectedIndex == -1 || systemUserA.SelectedIndex == -1 ||
                treatmentA.SelectedIndex == -1 || String.IsNullOrEmpty(observationA.Text) ||
                !dateA.Date.HasValue || hourA.SelectedTime == null ? true: false;
            if (state)
            {
                infoBar error = new infoBar()
                {
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                    Title = "Error con el paciente en cuestion",
                    Message = "Revisa si existe un campo en blanco, opciones seleccionadas o fecha establecida antes de guardar."
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                (_, var listP) = sqlPatients.GetTable();
                (_, var listsu) = sqlSystemUsers.GetTable();
                (_, var listT) = sqlTreatments.GetTable();
                var P = patientA.SelectedItem as Patient;
                var sysU = systemUserA.SelectedItem as SU;
                string T = treatmentA.SelectedItem as string;
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                string cmdStr;
                if (selected == null)
                {
                    cmdStr = "INSERT INTO [Appointments] (ID_Patient, ID_SystemUser, ID_Treatment, Observations, Date) VALUES\n" +
                        "(@patient, @su, @treat, @observation, @date)";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    foreach (var element in listP)
                    {
                        if (element.Name == P.Name) cmd.Parameters.Add("@patient", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    foreach (var element in listsu)
                    {
                        if (element.Name == sysU.Name) cmd.Parameters.Add("@su", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    foreach (var element in listT)
                    {
                        if (element.Name == T) cmd.Parameters.Add("@treat", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    cmd.Parameters.AddWithValue("@observation", observationA.Text);
                    cmd.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = dateA.Date.Value.Date + hourA.Time;
                    await cmd.ExecuteNonQueryAsync();
                    HomePage.HomePageBase.Current.main.Navigate(typeof(AppointmentsPage));
                }
                else
                {
                    cmdStr = "IF EXISTS (SELECT * FROM [Appointments] WHERE ID_Patient = @bpatient AND Date = @bdate)\n" +
                        "UPDATE [Appointments] SET ID_Patient = @patient, ID_SystemUser = @su, ID_Treatment = @treat, Observations = @obs, Date = @date\n" +
                        "WHERE ID_Patient = @bpatient AND Date = @bdate";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    foreach (var element in listP)
                    {
                        if (selected.PatientName == element.Name) cmd.Parameters.Add("@bpatient", System.Data.SqlDbType.Int).Value = element.ID;
                        if (element.Name == P.Name) cmd.Parameters.Add("@patient", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    cmd.Parameters.Add("@bdate", System.Data.SqlDbType.DateTime).Value = selected.Date;
                    foreach (var element in listsu)
                    {
                        if (element.Name == sysU.Name) cmd.Parameters.Add("@su", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    foreach (var element in listT)
                    {
                        if (element.Name == T) cmd.Parameters.Add("@treat", System.Data.SqlDbType.Int).Value = element.ID;
                    }
                    cmd.Parameters.AddWithValue("@obs", observationA.Text);
                    cmd.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = dateA.Date.Value.Date + hourA.Time;
                    await cmd.ExecuteNonQueryAsync();
                    HomePage.HomePageBase.Current.main.Navigate(typeof(AppointmentsPage));
                }
            }
        }

        Appointment selected = new Appointment();
        public void ButtonsActionCaller()
        {
            add.Click += (sender, e) =>
            {
                selected = null;
                patientA.SelectedIndex = -1;
                systemUserA.SelectedIndex = -1;
                treatmentA.SelectedIndex = -1;
                observationA.Text = String.Empty;
                dateA.Date = null;
                hourA.SelectedTime = null;
                infoA.Visibility = Visibility.Visible;
            };
            viewEdit.Click += (sender, e) =>
            {
                var editBase = appList.SelectedItem as AppointmentBase;
                foreach(var item in listAppointments)
                {
                    if (editBase.Name == item.PatientName) selected = item;
                }
                foreach (var item in patients)
                {
                    if (item.Name == selected.PatientName) patientA.SelectedItem = item;
                }
                foreach (var item in su)
                {
                    if (item.Name == selected.SystemUser) systemUserA.SelectedItem = item;
                }
                foreach (string item in treat)
                {
                    if (item == selected.Treatment) treatmentA.SelectedItem = item;
                }
                observationA.Text = selected.Observation;
                dateA.Date = selected.Date;
                hourA.Time = selected.Date.TimeOfDay;
                infoA.Visibility = Visibility.Visible;

            };
            delete.Click += async (sender, e) =>
            {
                ContentDiag diag = new ContentDiag()
                {
                    Title = "Eliminar Cita",
                    Content = "¿Estas seguro que quieres eliminar esta cita?\n" +
                    "Esta accion no se puede deshacer una vez finalizado.",
                    PrimBtnEnable = true,
                    SecBtnEnable = false,
                    PrimBtnText = "Eliminar",
                    CloseBtnText = "Cancelar",
                    DefaultBtn = 0
                };
                var result = await ContentDiag.DiagOpen(diag);
                if (result == ContentDialogResult.Primary)
                {
                    var selectedItem = appList.SelectedItem as AppointmentBase;
                    Appointment data = new Appointment();
                    foreach (Appointment item1 in listAppointments)
                    {
                        if (item1.PatientName == selectedItem.Name) data = item1;
                    }
                    SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                    cnn.Open();
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        string cmdStr = "IF EXISTS (SELECT * FROM [Appointments] WHERE ID_Patient = @patient)\n" +
                                                "DELETE FROM [Appointments] WHERE ID_Patient = @patient";
                        SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                        (_, var listP) = sqlPatients.GetTable();
                        foreach (var item2 in listP)
                        {
                            if (item2.Name == data.PatientName && item2.LastName == data.PatientLastName)
                                cmd.Parameters.Add("@patient", System.Data.SqlDbType.Int).Value = item2.ID;
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }
                    HomePage.HomePageBase.Current.main.Navigate(typeof(AppointmentsPage));
                }
            };
        }


        List<Patient> patients = new List<Patient>();
        List<SU> su = new List<SU>();
        List<string> treat = new List<string>();
        public void ComboLoader()
        {
            (_, var listP) = sqlPatients.GetTable();
            (_, var listSU) = sqlSystemUsers.GetTable();
            (_, var listT) = sqlTreatments.GetTable();
            (_, var listPos) = sqlJobPosition.GetTable();
            foreach (var item in listP)
            {
                Patient data = new Patient()
                {
                    Name = item.Name,
                    LastName = item.LastName
                };
                patients.Add(data);
            }
            foreach (var item in listSU)
            {
                SU data = new SU();
                data.Name = item.Name;
                foreach (var item2 in listPos)
                {
                    if (item.ID_JobPosition == item2.ID) data.Position = item2.Position;
                }
                su.Add(data);
            }
            foreach (var item in listT)
            {
                treat.Add(item.Name);
            }
            patientA.ItemsSource = patients;
            systemUserA.ItemsSource = su;
            treatmentA.ItemsSource = treat;
            
        }
        public class Patient 
        {
            public string Name { get; set; }
            public string LastName { get; set; }
        }

        public class SU
        {
            public string Name { get; set; }
            public string Position { get; set; }
        }

        private void viewMode_Toggled(object sender, RoutedEventArgs e)
        {
            if (viewMode.IsOn) appList.ItemsSource = uiList(1);
            else appList.ItemsSource = uiList(0);
        }

        private void appList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appList.SelectedIndex == -1)
            {
                viewEdit.IsEnabled = false;
                delete.IsEnabled= false;
            }
            else
            {
                viewEdit.IsEnabled = true;
                delete.IsEnabled = true;
            }
        }

        List<Appointment> listAppointments = new List<Appointment>();
        public void appGetList()
        {
            (_, var listApp) = sqlAppointments.GetTable();
            (_, var listP) = sqlPatients.GetTable();
            (_, var listSU) = sqlSystemUsers.GetTable();
            (_, var listT) = sqlTreatments.GetTable();
            foreach(var item in listApp)
            {
                Appointment data = new Appointment();
                foreach (var subI in listP)
                {
                    if (subI.ID == item.ID_Patient)
                    {
                        data.PatientName = subI.Name; 
                        data.PatientLastName = subI.LastName;
                    }
                }
                foreach (var subI in listSU)
                {
                    if (subI.ID == item.ID_SystemUser) data.SystemUser = subI.Name;
                }
                foreach (var subI in listT)
                {
                    if (subI.ID == item.ID_Treatment) data.Treatment = subI.Name;
                }
                data.Observation = item.Observations;
                data.Date = item.Date;
                listAppointments.Add(data);
            }
        }

        public List<AppointmentBase> uiList(int mode)
        {
            List<AppointmentBase> list = new List<AppointmentBase>();
            foreach (var item in listAppointments)
            {
                if (mode == 0)
                {
                    var data = new AppointmentBase();
                    data.Name = item.PatientName;
                    data.LastName = item.PatientLastName;
                    data.Date = item.Date;
                    data.Treatment = item.Treatment;
                    data.SystemUser = item.SystemUser;
                    list.Add(data);
                }
                else if (mode == 1 && item.Date >= DateTime.Now)
                {
                    var data = new AppointmentBase();
                    data.Name = item.PatientName;
                    data.LastName = item.PatientLastName;
                    data.Date = item.Date;
                    data.Treatment = item.Treatment;
                    data.SystemUser = item.SystemUser;
                    list.Add(data);
                }
            }
            return list;
        }

        public class Appointment
        {
            public string PatientName { get; set; }
            public string PatientLastName { get; set; }
            public string SystemUser { get; set; }
            public string Treatment { get; set; }
            public string Observation { get; set; }
            public DateTime Date { get; set; }
        }

        public class AppointmentBase
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string SystemUser { get; set; }
            public string Treatment { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
