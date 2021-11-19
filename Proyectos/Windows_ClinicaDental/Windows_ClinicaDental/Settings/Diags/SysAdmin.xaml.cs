using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data;

// La plantilla de elemento del cuadro de diálogo de contenido está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings.Diags
{
    public sealed partial class SysAdmin : ContentDialog
    {
        public static List<sqlSex> sex;
        public static List<sqlJobPosition> job;
        public static List<sqlRoles> role;
        public SysAdmin()
        {
            this.InitializeComponent();
            DateBirth.MaxDate = DateTime.Now.AddYears(-18);
            OldPassword.Visibility = Visibility.Collapsed;
            Password.PlaceholderText = "Password";
            #region ItemsFiller
            (_,sex) = sqlSex.GetTable();
            (_, job) = sqlJobPosition.GetTable();
            (_, role) = sqlRoles.GetTable();
            List<string> listSex = new List<string>();
            List<string> listJobPosition = new List<string>();
            List<string> listRole = new List<string>();
            foreach (var item in sex)
            {
                listSex.Add(item.Sex);
            }
            foreach (var item in job)
            {
                listJobPosition.Add(item.Position);
            }
            foreach (var item in role)
            {
                listRole.Add(item.Name);
            }
            Sex.ItemsSource = listSex;
            JobPosition.ItemsSource = listJobPosition;
            Role.ItemsSource = listRole;
            if (ItemSender.modifyEnabled == true)
            {
                var fill = ItemSender.element;
                Name.Text = fill.Name;
                LastName.Text = fill.LastName;
                foreach (var item in sex)
                {
                    if (item.ID == fill.ID_Sex)
                    {
                        Sex.SelectedIndex = Sex.Items.IndexOf(item.Sex);
                    }
                }
                DateBirth.Date = fill.DateBirth;
                Address.Text = fill.Address;
                CellPhone.Text = fill.Cellphone;
                LandLinePhone.Text = fill.LandLinePhone;
                foreach (var item in job)
                {
                    if (item.ID == fill.ID_JobPosition)
                    {
                        JobPosition.SelectedIndex = JobPosition.Items.IndexOf(item.Position);
                    }
                }
                foreach (var item in role)
                {
                    if (item.ID == fill.Role)
                    {
                        Role.SelectedIndex = Role.Items.IndexOf(item.Name);
                    }
                }
                Username.Text = fill.Username;
                OldPassword.Visibility = Visibility.Visible;
                Password.PlaceholderText = "Vacio si no quiere cambiarla";
            }
            #endregion
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (ItemSender.modifyEnabled)
            {
                bool status =
                String.IsNullOrEmpty(Name.Text) || String.IsNullOrEmpty(LastName.Text) ||
                Sex.SelectedIndex == -1 || DateBirth.Date == null ||
                String.IsNullOrEmpty(Address.Text) || String.IsNullOrEmpty(CellPhone.Text) ||
                String.IsNullOrEmpty(LandLinePhone.Text) || JobPosition.SelectedIndex == -1 ||
                Role.SelectedIndex == -1 || String.IsNullOrEmpty(Username.Text) ||
                String.IsNullOrEmpty(OldPassword.Password) 
                ? false : true;

                //Encripta la contraseña ingresada en la pagina
                String pwdEncrypted = "";
                StringBuilder stringBuilder = new StringBuilder();
                SHA256 converter = SHA256Managed.Create();
                Encoding utf8 = Encoding.UTF8;
                Byte[] finish = converter.ComputeHash(utf8.GetBytes(OldPassword.Password));
                //Completa de nuevo la contraseña ya encriptada
                foreach (byte b in finish) stringBuilder.Append(b.ToString("x2"));
                pwdEncrypted = stringBuilder.ToString();

                if (pwdEncrypted != ItemSender.element.Password) status = false;

                if (!status)
                {
                    infoBar errorBar = new infoBar()
                    {
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                        Title = "Ocurrio un error al modificar el usuario seleccionado",
                        Message = "Verifica si todas las casillas no estan vacias, que todas las listas tengan un\n" +
                        "elemento seleccionado y la contraseña no sea incorrecta."
                    };
                    infoBar.CreateInfoBar(errorBar);
                }
                else
                {
                    string cmdInsert;
                    cmdInsert = "IF EXISTS (SELECT * FROM [SystemUsers] WHERE username = '" + ItemSender.element.Username + "')\n" +
                        "DELETE FROM [SystemUsers] WHERE username = '" + ItemSender.element.Username + "'";

                    SettingsReader settings = new SettingsReader();
                    SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(settings, "ClinicaDental"));
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(cmdInsert, cnn);
                    cmd.ExecuteNonQuery();
                    cmdInsert = String.Empty;
                    cmdInsert = "INSERT INTO [SystemUsers] (username, password, Name, LastName, ID_Sex, DateBirth, ID_JobPosition, Address, CellPhone, LandLinePhone, Role)\n" +
                        "VALUES (@username, @password, @name, @lastname, @sex, @datebirth, @jobposition, @address, @cellphone, @landlinephone, @role)";
                    if (cnn.State == System.Data.ConnectionState.Open)
                    {
                        cmd = new SqlCommand(cmdInsert, cnn);
                        cmd.Parameters.AddWithValue("@username", Username.Text);
                        if (String.IsNullOrEmpty(Password.Password))
                            cmd.Parameters.AddWithValue("@password", ItemSender.element.Password);
                        else
                        {
                            //Encripta la contraseña ingresada en la pagina
                            String newPwdEncrypted = "";
                            StringBuilder strBuild = new StringBuilder();
                            SHA256 convert = SHA256Managed.Create();
                            Encoding utf_8 = Encoding.UTF8;
                            Byte[] finished = convert.ComputeHash(utf_8.GetBytes(Password.Password));
                            //Completa de nuevo la contraseña ya encriptada
                            foreach (byte b in finished) strBuild.Append(b.ToString("x2"));
                            newPwdEncrypted = strBuild.ToString();
                            cmd.Parameters.AddWithValue("@password", newPwdEncrypted);
                        }
                        cmd.Parameters.AddWithValue("@name", Name.Text);
                        cmd.Parameters.AddWithValue("@lastname", LastName.Text);
                        foreach (var items in sex) if (items.Sex == Sex.SelectedItem as string) cmd.Parameters.AddWithValue("@sex", items.ID);
                        cmd.Parameters.Add("@datebirth", SqlDbType.Date);
                        cmd.Parameters["@datebirth"].Value = DateBirth.Date.Value.DateTime;
                        foreach (var items in job) if (items.Position == JobPosition.SelectedItem as string) cmd.Parameters.AddWithValue("@jobposition", items.ID);
                        cmd.Parameters.AddWithValue("@address", Address.Text);
                        cmd.Parameters.AddWithValue("@cellphone", CellPhone.Text);
                        cmd.Parameters.AddWithValue("@landlinephone", LandLinePhone.Text);
                        foreach (var items in role) if (items.Name == Role.SelectedItem as string) cmd.Parameters.AddWithValue("@role", items.ID);
                        cmd.ExecuteNonQuery();
                        HomePage.HomePageBase.Current.main.Navigate(typeof(SystemUserSettings)); 
                    }
                }
            }
        }
    }
}
