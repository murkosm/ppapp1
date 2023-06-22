using ppapp.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;

namespace ppapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAdd.xaml
    /// </summary>
    public partial class EditAdd : Page
    {
        DB.AppContext appContext = new DB.AppContext();
        //private Products selectedItem;
   

        //public EditAdd(Products selectedItem)
        //{
        //    InitializeComponent();
        //    this.selectedItem = selectedItem;

        //}

        public EditAdd()
        {
            InitializeComponent();
        }


        private void image_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg";
            fileDialog.ShowDialog();
            if (string.IsNullOrEmpty(fileDialog.FileName))
            {
                return;
            }
            var content = fileDialog.FileName;
            image_box.Text = content;

        }
        private void save_btn_Click(object sender, RoutedEventArgs e)
        {

            appContext.OpenConnection();


            DataTable table = new DataTable();

            var name = product_name.Text;
            var manufac = manufacturer.Text;
            int count;
            var statuc = active.Text;
            var image = image_box.Text;

            if (int.TryParse(price.Text, out count))
            {
                var addquary = $"INSERT INTO [Products](Product_name, Image, Manufacturer, Active, Count) VALUES('{name}', '{image}', '{manufac}', '{statuc}', '{count}')";

                SqlCommand command = new SqlCommand(addquary, appContext.GetConnection());

                appContext.OpenConnection();

                command.ExecuteNonQuery();

                MessageBox.Show("Информация сохранена.");
                Classes.ClassFrame.authFrame.Navigate(new MainPage1());
          

            }
            else
            {
                MessageBox.Show("Информация НЕ сохранена.");
            }


            appContext.CloseConnection();



            //    StringBuilder errors = new StringBuilder();

            //    if (string.IsNullOrWhiteSpace(_addProduct.Product_name))
            //        errors.AppendLine("Укажитите название");

            //    if (string.IsNullOrWhiteSpace(_addProduct.Manufacturer))
            //        errors.AppendLine("Укажитите производителя");

            //    if (_addProduct.Count < 1)
            //        errors.AppendLine("Укажитите цену");

            //    if (_addProduct.Active == null)
            //        errors.AppendLine("Укажите статус активности товара");
            //    if (errors.Length > 0)
            //    {
            //        MessageBox.Show(errors.ToString());
            //        return;
            //    }

            //    if (_addProduct.Id_product == 0)
            //    {
            //        changsalonEntities1.GetContext().Products.Add(_addProduct);
            //    }

            //    try
            //    {
            //        changsalonEntities1.GetContext().SaveChanges();
            //        MessageBox.Show("Информация сохранена.");
            //        EditWindow editWindow = new EditWindow();
            //        editWindow.Close();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }
            //}

        }

       

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {

            Classes.ClassFrame.authFrame.Navigate(new MainPage1());
        }
    }
}
