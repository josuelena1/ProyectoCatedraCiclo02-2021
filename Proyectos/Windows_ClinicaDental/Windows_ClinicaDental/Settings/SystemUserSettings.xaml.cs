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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SystemUserSettings : Page
    {
        public static SystemUserSettings Current;

        public SystemUserSettings()
        {
            this.InitializeComponent();
            Current = this;
            this.Height = Double.NaN;
            #region PageLoaders
            scrollView.Height = Window.Current.CoreWindow.Bounds.Height;
            Window.Current.CoreWindow.SizeChanged += (sender, args) => scrollView.Height = Window.Current.CoreWindow.Bounds.Height;
            SystemUsers.GetSystemUsersList();
            JobPositions.GetJobPositionsList();
            Roles.GetRolesList();
            sysUsersList.ItemsSource = listSysUsers;
            JobPositionsList.ItemsSource = listJobPositions;
            RolesList.ItemsSource = listRoles;
            #endregion
            #region ButtonsDiagLoader
            //SU SECTION
            addSU.Click += async (sender, args) =>
            {
                Diags.ItemSender data = new Diags.ItemSender(null, false);
                ContentDialog diag = new Diags.SysAdmin();
                _ = await diag.ShowAsync();
            };
            modifySU.Click += async (sender, args) =>
            {
                var delete = sysUsersList.SelectedItem as SystemUsers;
                if (delete.Name == LoginPage.LoginPage.currentUser.Name)
                {
                    infoBar errorBar = new infoBar()
                    {
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                        Title = "Ocurrio un error al modificar el usuario",
                        Message = "No puedes modificar al usuario con el cual has iniciado sesion."
                    };
                    infoBar.CreateInfoBar(errorBar);
                }
                else
                {
                    var selected = sysUsersList.SelectedItem as SystemUsers;
                    (_, var usersList) = sqlSystemUsers.GetTable();
                    foreach (var element in usersList)
                    {
                        if (element.Name == selected.Name)
                        {
                            Diags.ItemSender data = new Diags.ItemSender(element, true);
                        }
                    }
                    ContentDialog diag = new Diags.SysAdmin();
                    _ = await diag.ShowAsync();
                }
            };
            deleteSU.Click += async (sender, args) =>
            {
                var delete = sysUsersList.SelectedItem as SystemUsers;
                if (delete.Name == LoginPage.LoginPage.currentUser.Name)
                {
                    infoBar errorBar = new infoBar()
                    {
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                        Title = "Ocurrio un error al eliminar el usuario",
                        Message = "No puedes eliminar al usuario con el cual has iniciado sesion."
                    };
                    infoBar.CreateInfoBar(errorBar);
                }
                else
                {
                    ContentDiag diag = new ContentDiag()
                    {
                        Title = "Eliminar usuario del sistema",
                        Content = "¿Estas seguro que quieres eliminar a este usuario?\n" +
                    "Esta accion no se puede deshacer una vez eliminado.",
                        PrimBtnEnable = true,
                        SecBtnEnable = false,
                        PrimBtnText = "Eliminar",
                        CloseBtnText = "Cancelar",
                        DefaultBtn = 0
                    };
                    var result = await ContentDiag.DiagOpen(diag);
                    if (result == ContentDialogResult.Primary)
                    {
                        SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                        cnn.Open();
                        string cmdStr = "IF EXISTS (SELECT * FROM [SystemUsers] WHERE [Name] = @name)\n" +
                        "DELETE FROM [SystemUsers] WHERE [Name] = @name";
                        SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                        cmd.Parameters.AddWithValue("@name", delete.Name);
                        cmd.ExecuteNonQuery();
                        HomePage.HomePageBase.Current.main.Navigate(typeof(SystemUserSettings));
                    }
                }
            };
            //PL SECTION
            addPL.Click += async (sender, args) =>
            {
                ContentDialog diag = new Diags.JobPositions();
                _ = await diag.ShowAsync();
            };
            deletePL.Click += async (sender, args) =>
            {
                var delete = JobPositionsList.SelectedItem as JobPositions;
                string position = "";
                (_, var jobList) = sqlJobPosition.GetTable();
                foreach (var element in jobList)
                {
                    if (element.ID == LoginPage.LoginPage.currentUser.JobPosition)
                    {
                        position = element.Position;
                    }
                }
                if (delete.Position == position)
                {
                    infoBar errorBar = new infoBar()
                    {
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                        Title = "Ocurrio un error al eliminar la posicion laboral",
                        Message = "No puedes eliminar la posicion laboral del usuario el cual has iniciado sesion."
                    };
                    infoBar.CreateInfoBar(errorBar);
                }
                else
                {
                    ContentDiag diag = new ContentDiag()
                    {
                        Title = "Eliminar posicion laboral",
                        Content = "¿Estas seguro que quieres eliminar esta posicion laboral?\n" +
                    char.ConvertFromUtf32(0x1F6D1) + " PRECAUCION: Esta accion eliminara tambien a los usuarios ligados a ella.\n" +
                    "Una vez finalizado, esta accion no se podra deshacer.",
                        PrimBtnEnable = true,
                        SecBtnEnable = false,
                        PrimBtnText = "Eliminar",
                        CloseBtnText = "Cancelar",
                        DefaultBtn = 0
                    };
                    var result = await ContentDiag.DiagOpen(diag);
                    if (result == ContentDialogResult.Primary)
                    {
                        SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                        cnn.Open();
                        string cmdStr = "IF EXISTS (SELECT * FROM [JobPosition] WHERE Position = @position)\n" +
                        "DELETE FROM [JobPosition] WHERE Position = @position";
                        SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                        cmd.Parameters.AddWithValue("@position", delete.Position);
                        cmd.ExecuteNonQuery();
                        HomePage.HomePageBase.Current.main.Navigate(typeof(SystemUserSettings));
                    }
                }
            };
            //R SECTION
            addR.Click += async (sender, args) =>
            {
                ContentDialog diag = new Diags.Roles();
                _ = await diag.ShowAsync();
            };
            deleteR.Click += async (sender, args) =>
            {
                var delete = RolesList.SelectedItem as Roles;
                string name = "";
                (_, var roleList) = sqlRoles.GetTable();
                foreach (var element in roleList)
                {
                    if (element.ID == LoginPage.LoginPage.currentUser.JobPosition)
                    {
                        name = element.Name;
                    }
                }
                if (delete.Name == name)
                {
                    infoBar errorBar = new infoBar()
                    {
                        Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                        Title = "Ocurrio un error al eliminar el rol",
                        Message = "No puedes eliminar el rol del usuario el cual has iniciado sesion."
                    };
                    infoBar.CreateInfoBar(errorBar);
                }
                else
                {
                    ContentDiag diag = new ContentDiag()
                    {
                        Title = "Eliminar rol",
                        Content = "¿Estas seguro que quieres eliminar este rol?\n" +
                    char.ConvertFromUtf32(0x1F6D1) + " PRECAUCION: Esta accion eliminara tambien a los usuarios ligados a el.\n" +
                    "Una vez finalizado, esta accion no se podra deshacer.",
                        PrimBtnEnable = true,
                        SecBtnEnable = false,
                        PrimBtnText = "Eliminar",
                        CloseBtnText = "Cancelar",
                        DefaultBtn = 0
                    };
                    var result = await ContentDiag.DiagOpen(diag);
                    if (result == ContentDialogResult.Primary)
                    {
                        SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                        cnn.Open();
                        string cmdStr = "IF EXISTS (SELECT * FROM [Roles] WHERE Name = @name)\n" +
                        "DELETE FROM [Roles] WHERE Name = @name";
                        SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                        cmd.Parameters.AddWithValue("@name", delete.Name);
                        cmd.ExecuteNonQuery();
                        HomePage.HomePageBase.Current.main.Navigate(typeof(SystemUserSettings));
                    }
                }
            };
            #endregion
        }
        private void sysUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sysUsersList.SelectedIndex != -1)
            {
                modifySU.IsEnabled = true;
                deleteSU.IsEnabled = true;
            }
            else
            {
                modifySU.IsEnabled = false; 
                deleteSU.IsEnabled = false;
            }
        }

        private void JobPositionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (JobPositionsList.SelectedIndex != -1)
            {
                deletePL.IsEnabled = true;
            }
            else
            {
                deletePL.IsEnabled = false;
            }
        }

        private void RolesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolesList.SelectedIndex != -1)
            {
                deleteR.IsEnabled = true;
            }
            else
            {
                deleteR.IsEnabled = false;
            }
        }

        public static List<SystemUsers> listSysUsers = new List<SystemUsers>();
        public static List<JobPositions> listJobPositions = new List<JobPositions>();
        public static List<Roles> listRoles = new List<Roles>();

        public class SystemUsers
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Position { get; set; }
            public string Role { get; set; }
            public string Cellphone { get; set; }
            public string LandLinePhone { get; set; }

            public static void GetSystemUsersList()
            {
                listSysUsers = new List<SystemUsers>();
                (bool state, var sysUserList) = sqlSystemUsers.GetTable();
                if (state)
                {
                    (_, var positionList) = sqlJobPosition.GetTable();
                    (_, var roleList) = sqlRoles.GetTable();
                    foreach (var user in sysUserList)
                    {
                        SystemUsers data = new SystemUsers();
                        data.Name = user.Name;
                        data.LastName = user.LastName;
                        foreach (var position in positionList) if (position.ID == user.ID_JobPosition) data.Position = position.Position;
                        foreach (var role in roleList) if (role.ID == user.Role) data.Role = role.Name;
                        data.Cellphone = user.Cellphone;
                        data.LandLinePhone = user.LandLinePhone;
                        listSysUsers.Add(data);
                    };
                }
            }
        }
        public class JobPositions
        {
            public string Position { get; set; }

            public static void GetJobPositionsList()
            {
                listJobPositions = new List<JobPositions>();
                (bool state, var jobPositions) = sqlJobPosition.GetTable();
                if (state)
                {
                    foreach(var position in jobPositions)
                    {
                        JobPositions data = new JobPositions();
                        data.Position = position.Position;
                        listJobPositions.Add(data);
                    }
                }
            }
        }
        public class Roles
        {
            public string Name { set; get; }
            public string Description { set; get; }
            public static void GetRolesList()
            {
                listRoles = new List<Roles>();
                (bool state, var list) = sqlRoles.GetTable();
                foreach (var role in list)
                {
                    Roles data = new Roles();
                    data.Name = role.Name;
                    data.Description = role.Description;
                    listRoles.Add(data);
                }
            }
        }

    }
}
