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
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.PacientesCitas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            this.InitializeComponent();
            GetPatientsList();
            patientsList.ItemsSource = uiList();
            infoP.Visibility = Visibility.Collapsed;
            ComboBoxSource();
            dateBirthP.MaxDate = DateTimeOffset.Now;
            viewEdit.IsEnabled = false;
            delete.IsEnabled = false;
            CommandBarButtonsCaller();
        }
        private async void save_Click(object sender, RoutedEventArgs e)
        {
            if (controlsState())
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
                (_, var listS) = sqlSex.GetTable();
                (_, var listT) = sqlTreatments.GetTable();
                (_, var listA) = sqlAllergies.GetTable();
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                string cmdStr;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                if (edit == null)
                {
                    cmdStr = "IF NOT EXISTS (SELECT * FROM [Patients] WHERE Name = @name)\n" +
                        "INSERT INTO [Patients] (Name, LastName, ID_Sex, DateBirth, Address, CellPhone, LandLinePhone, ID_Treatments, ID_Allergies)\n" +
                        "VALUES (@name, @lastname, @sex, @datebirth, @address, @cellphone, @landlinephone, @treatment, @allergy)";
                    cmd.CommandText = cmdStr;
                    cmd.Parameters.AddWithValue("@name", nameP.Text);
                    cmd.Parameters.AddWithValue("@lastname", lastNameP.Text);
                    foreach (var item in listS)
                    {
                        if (item.Sex == sexP.SelectedItem as string) cmd.Parameters.AddWithValue("@sex", item.ID);
                    }
                    cmd.Parameters.AddWithValue("@datebirth", dateBirthP.Date.Value.Date);
                    cmd.Parameters.AddWithValue("@address", addressP.Text);
                    cmd.Parameters.AddWithValue("@cellphone", cellPhoneP.Text);
                    cmd.Parameters.AddWithValue("@landlinephone", landLinePhoneP.Text);
                    foreach (var item in listT)
                    {
                        if (item.Name == treatmentsP.SelectedItem as string) cmd.Parameters.AddWithValue("@treatment", item.ID);
                    }
                    foreach (var item in listA)
                    {
                        if (item.Name == allergiesP.SelectedItem as string) cmd.Parameters.AddWithValue("@allergy", item.ID);
                    }
                    await cmd.ExecuteNonQueryAsync();
                    HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsPage));
                }
                else
                {
                    cmdStr = "IF EXISTS (SELECT * FROM [Patients] WHERE Name = @name)\n" +
                        "DELETE FROM [Patients] WHERE Name = @name";
                    cmd.CommandText = cmdStr;
                    cmd.Parameters.AddWithValue("@name", edit.Name);
                    await cmd.ExecuteNonQueryAsync();
                    //
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmdStr = "IF NOT EXISTS (SELECT * FROM [Patients] WHERE Name = @name)\n" +
                        "INSERT INTO [Patients] (Name, LastName, ID_Sex, DateBirth, Address, CellPhone, LandLinePhone, ID_Treatments, ID_Allergies)\n" +
                        "VALUES (@name, @lastname, @sex, @datebirth, @address, @cellphone, @landlinephone, @treatment, @allergy)";
                    cmd.CommandText = cmdStr;
                    cmd.Parameters.AddWithValue("@name", nameP.Text);
                    cmd.Parameters.AddWithValue("@lastname", lastNameP.Text);
                    foreach (var item in listS)
                    {
                        if (item.Sex == sexP.SelectedItem as string) cmd.Parameters.AddWithValue("@sex", item.ID);
                    }
                    cmd.Parameters.AddWithValue("@datebirth", dateBirthP.Date.Value.Date);
                    cmd.Parameters.AddWithValue("@address", addressP.Text);
                    cmd.Parameters.AddWithValue("@cellphone", cellPhoneP.Text);
                    cmd.Parameters.AddWithValue("@landlinephone", landLinePhoneP.Text);
                    foreach (var item in listT)
                    {
                        if (item.Name == treatmentsP.SelectedItem as string) cmd.Parameters.AddWithValue("@treatment", item.ID);
                    }
                    foreach (var item in listA)
                    {
                        if (item.Name == allergiesP.SelectedItem as string) cmd.Parameters.AddWithValue("@allergy", item.ID);
                    }
                    await cmd.ExecuteNonQueryAsync();
                    HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsPage));
                }
            }
        }

        public bool controlsState()
        {
            bool state = 
                String.IsNullOrEmpty(nameP.Text) || String.IsNullOrEmpty(lastNameP.Text) ||
                String.IsNullOrEmpty(addressP.Text) || String.IsNullOrEmpty(cellPhoneP.Text) ||
                String.IsNullOrEmpty(landLinePhoneP.Text) || sexP.SelectedIndex == -1 ||
                treatmentsP.SelectedIndex == -1 || allergiesP.SelectedIndex == -1 ||
                !dateBirthP.Date.HasValue ? true : false;
            return state;
        }

        public Patients edit = new Patients();
        public void CommandBarButtonsCaller ()
        {
            add.Click += (sender, e) =>
            {
                edit = null;
                nameP.Text = String.Empty;
                lastNameP.Text = String.Empty;
                sexP.SelectedIndex = -1;
                dateBirthP.Date = null;
                addressP.Text = String.Empty;
                cellPhoneP.Text = String.Empty;
                landLinePhoneP.Text = String.Empty;
                treatmentsP.SelectedIndex = -1;
                allergiesP.SelectedIndex = -1;
                infoP.Visibility = Visibility.Visible;

            };
            viewEdit.Click += (sender, e) =>
            {
                (_, var listS) = sqlSex.GetTable();
                (_, var listT) = sqlTreatments.GetTable();
                (_, var listA) = sqlAllergies.GetTable();
                var selected = patientsList.SelectedItem as PatientsPageBase;
                Patients data = new Patients();
                foreach (var item in listPatients)
                {
                    if (item.Name + " " + item.LastName == selected.Name) data = item;
                }
                edit = data;
                nameP.Text = data.Name;
                lastNameP.Text = data.LastName;
                sexP.SelectedItem = data.Sex;
                dateBirthP.Date = data.DateBirth;
                addressP.Text = data.Address;
                cellPhoneP.Text = data.CellPhone;
                landLinePhoneP.Text = data.LandLinePhone;
                treatmentsP.SelectedItem = data.Treatments;
                allergiesP.SelectedItem = data.Allergies;
                infoP.Visibility = Visibility.Visible;
            };
            delete.Click += async (sender, e) =>
            {
                ContentDiag diag = new ContentDiag()
                {
                    Title = "Eliminar Paciente",
                    Content = "¿Estas seguro que quieres eliminar este paciente?\n" +
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
                    var delete = patientsList.SelectedItem as PatientsPageBase;
                    Patients data = new Patients();
                    foreach (var item in listPatients)
                    {
                        if (item.Name + " " + item.LastName == delete.Name) data = item;
                    }
                    SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                    cnn.Open();
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        string cmdStr = "IF EXISTS (SELECT * FROM [Patients] WHERE Name = @name)\n" +
                        "DELETE FROM [Patients] WHERE Name = @name";
                        SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                        cmd.Parameters.AddWithValue("@name", data.Name);
                        await cmd.ExecuteNonQueryAsync();
                    }
                    HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsPage));
                }
            };
        }

        public void ComboBoxSource()
        {
            List<string> listSex = new List<string>();
            List<string> listTreatments = new List<string>();
            List<string> listAllergies = new List<string>();
            (_, var listS) = sqlSex.GetTable();
            (_, var listT) = sqlTreatments.GetTable();
            (_, var listA) = sqlAllergies.GetTable();
            foreach (var item in listS)
            {
                listSex.Add(item.Sex);
            }
            foreach (var item in listT)
            {
                listTreatments.Add(item.Name);
            }
            foreach (var item in listA)
            {
                listAllergies.Add(item.Name);
            }
            sexP.ItemsSource = listSex;
            treatmentsP.ItemsSource = listTreatments;
            allergiesP.ItemsSource = listAllergies;
        }

        public List<Patients> listPatients = new List<Patients>();
        public void GetPatientsList()
        {
            (_, var listP) = sqlPatients.GetTable();
            (_, var listS) = sqlSex.GetTable();
            (_, var listT) = sqlTreatments.GetTable();
            (_, var listA) = sqlAllergies.GetTable();
            foreach (var patient in listP)
            {
                Patients data = new Patients();
                data.Name = patient.Name;
                data.LastName = patient.LastName;
                foreach (var sex in listS)
                {
                    if (sex.ID == patient.ID) data.Sex = sex.Sex;
                }
                data.DateBirth = patient.DateBirth;
                data.Address = patient.Address;
                data.CellPhone = patient.CellPhone;
                data.LandLinePhone = patient.LandLinePhone;
                foreach (var treat in listT)
                {
                    if (treat.ID == patient.ID_Treatments) data.Treatments = treat.Name; 
                }
                foreach (var allergy in listA)
                {
                    if (allergy.ID == patient.ID_Allergies) data.Allergies = allergy.Name;
                }
                listPatients.Add(data);
            }
        }

        public List<PatientsPageBase> uiList()
        {
            List<PatientsPageBase> list = new List<PatientsPageBase>();
            foreach (var patient in listPatients)
            {
                var data = new PatientsPageBase();
                data.Name = patient.Name + " " + patient.LastName;
                data.Treatments = patient.Treatments;
                list.Add(data);
            }
            return list;
        }

        public class Patients
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Sex { get; set; }
            public DateTime DateBirth { get; set; }
            public string Address { get; set; }
            public string CellPhone { get; set; }
            public string LandLinePhone { get; set; }
            public string Treatments { get; set; }
            public string Allergies { get; set; }
        }

        public class PatientsPageBase
        {
            public string Name { get; set; }
            public string Treatments { get; set; }
        }

        private void patientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientsList.SelectedIndex == -1)
            {
                viewEdit.IsEnabled = false;
                delete.IsEnabled = false;
            }
            else
            {
                viewEdit.IsEnabled = true;
                delete.IsEnabled = true;
            }
        }

    }
}
