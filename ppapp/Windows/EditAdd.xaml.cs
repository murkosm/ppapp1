using Microsoft.Win32;
using ppapp.DB;
using ppapp.Pages;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ppapp.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditAdd.xaml
    /// </summary>
    public partial class EditAdd : Window
    {
        DB.AppContext appContext = new DB.AppContext();
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
                Close();


            }
            else
            {
                MessageBox.Show("Информация НЕ сохранена.");
            }


            appContext.CloseConnection();


        }



        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}

