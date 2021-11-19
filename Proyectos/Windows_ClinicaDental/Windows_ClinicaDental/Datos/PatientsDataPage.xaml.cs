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

namespace Windows_ClinicaDental.Datos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PatientsDataPage : Page
    {
        public PatientsDataPage()
        {
            this.InitializeComponent();
            scrollView.Height = Window.Current.CoreWindow.Bounds.Height;
            this.Height = double.NaN;
            edit.IsEnabled = false;
            delete.IsEnabled = false;
            dataModifiers.Visibility = Visibility.Collapsed;
            /*
             */
            (_, var ListAllergies) = sqlAllergies.GetTable();
            List<string> updatedAllergies = new List<string>();
            foreach (var item in ListAllergies)
            {
                updatedAllergies.Add(item.Name);
            }
            listAllergies.ItemsSource = updatedAllergies;
            /* 
             */
            (_, var ListTreatments) = sqlTreatments.GetTable();
            List<Treatments> updatedTreatments = new List<Treatments>();
            foreach (var item in ListTreatments)
            {
                Treatments treatments = new Treatments()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = Math.Round(item.Price, 2)
                };
                updatedTreatments.Add(treatments);
            }
            listTreatments.ItemsSource = updatedTreatments;
        }

        #region Allergies
        #region Add Elements
        private void addList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (addList.SelectedIndex != -1) removeFromList.IsEnabled = true;
            else removeFromList.IsEnabled = false;
        }

        List<string> toAddItems = new List<string>();
        private void addToList_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(toAdd.Text))
            {
                infoBar error = new infoBar()
                {
                    Title = "Error al añadir a la lista",
                    Message = "Debes colocar un nombre para agregarlo",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                toAddItems.Add(toAdd.Text);
                addList.ItemsSource = null;
                addList.ItemsSource = toAddItems;
            }
        }

        private void removeFromList_Click(object sender, RoutedEventArgs e)
        {
            string remove = addList.SelectedItem as string;
            toAddItems.Remove(remove);
            addList.ItemsSource = null;
            addList.ItemsSource = toAddItems;
        }

        private async void finishAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (toAddItems.Count <= 0)
            {
                infoBar error = new infoBar()
                {
                    Title = "No puedes añadir elementos",
                    Message = "No puedes actualizar debido a que no has agregado ninguna alergia a la lista.",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                string cmdStr = "IF NOT EXISTS (SELECT * FROM [Allergies] WHERE Name = @allergy)\n" +
                                "INSERT INTO[Allergies] VALUES(@allergy)";
                foreach (string item in toAddItems)
                {
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@allergy", item);
                    await cmd.ExecuteNonQueryAsync();
                }
                HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsDataPage));
            }
        }

        #endregion
        #region Remove Elements
        private async void finishAndRemove_Click(object sender, RoutedEventArgs e)
        {
            if (deleteList.Items.Count <= 0)
            {
                infoBar error = new infoBar()
                {
                    Title = "No puedes remover elementos",
                    Message = "Debe de haber al menos un elemento en la lista. Arrastra un elemento de la lista original",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                List<string> items = new List<string>();
                foreach(var item in deleteList.Items)
                {
                    items.Add(item as string);
                }
                foreach (string item in items)
                {
                    string cmdStr = "IF EXISTS (SELECT * FROM [Allergies] WHERE Name = @allergy)\n" +
                        "DELETE FROM [Allergies] WHERE Name = @allergy";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@allergy", item);
                    await cmd.ExecuteNonQueryAsync();
                }
                HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsDataPage));
            }
        }

        string elementDrag;
        private void listAllergies_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            elementDrag = e.Items[0] as string;
        }

        private void deleteList_Drop(object sender, DragEventArgs e)
        {
            if (!deleteList.Items.Contains(elementDrag))
            {
                deleteList.Items.Add(elementDrag);
            }
        }

        private void deleteList_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            deleteList.Items.Clear();
        }
        #endregion
        #endregion


        #region Treatments

        public class Treatments
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            dataModifiers.Visibility = Visibility.Visible;
            actualEdit = null;
        }

        Treatments actualEdit = null;
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            dataModifiers.Visibility = Visibility.Visible;
            var data = listTreatments.SelectedItem as Treatments;
            actualEdit = data;
            nameT.Text = data.Name;
            descriptionT.Text = data.Description;
            priceT.Value = data.Price;
        }

        private async void delete_Click(object sender, RoutedEventArgs e)
        {
            ContentDiag diag = new ContentDiag()
            {
                Title = "Eliminar Tratamiento",
                Content = "¿Estas seguro que quieres eliminar este tratamiento?\n" +
                    char.ConvertFromUtf32(0x1F6D1) + " PRECAUCION: Esta accion eliminara tambien a los pacientes y las citas ligadas a ella.\n" +
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
                string cmdStr = "IF EXISTS (SELECT * FROM [Treatments] WHERE Name = @name)\n" +
                    "DELETE FROM [Treatments] WHERE Name = @name";
                SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                var itemDelete = listTreatments.SelectedItem as Treatments;
                cmd.Parameters.AddWithValue("@name", itemDelete.Name);
                await cmd.ExecuteNonQueryAsync();
                HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsDataPage));
            }
        }
        #endregion

        private void finishEdit_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(nameT.Text) || String.IsNullOrEmpty(descriptionT.Text) || Double.IsNaN(priceT.Value) || priceT.Value <= 0)
            {
                infoBar error = new infoBar()
                {
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error,
                    Title = "Error en el modificador de datos.",
                    Message = "Verifica si no has dejado campos vacios, sin valor o si el precio es menor que 0"
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                string cmdStr;
                if (actualEdit == null)
                {
                    cmdStr = "IF NOT EXISTS (SELECT * FROM [Treatments] WHERE Name = @name)\n" +
                        "INSERT INTO [Treatments] (Name, Description, Price) VALUES (@name, @description, @price)";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@name", nameT.Text);
                    cmd.Parameters.AddWithValue("@description", descriptionT.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToSingle(priceT.Value));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmdStr = "IF EXISTS (SELECT * FROM [Treatments] WHERE Name = @name)\n" +
                        "DELETE FROM [Treatments] WHERE Name = @name";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@name", actualEdit.Name);
                    cmd.ExecuteNonQuery();
                    //
                    cmdStr = "IF NOT EXISTS (SELECT * FROM [Treatments] WHERE Name = @name)\n" +
                        "INSERT INTO [Treatments] (Name, Description, Price) VALUES (@name, @description, @price)";
                    cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@name", nameT.Text);
                    cmd.Parameters.AddWithValue("@description", descriptionT.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToSingle(priceT.Value));
                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void listTreatments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listTreatments.SelectedIndex != 1)
            {
                edit.IsEnabled = true;
                delete.IsEnabled = true;
            }
            else
            {
                edit.IsEnabled = false;
                delete.IsEnabled = false;
            }
        }
    }
}
