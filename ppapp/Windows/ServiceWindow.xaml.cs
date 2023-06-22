using System;
using System.Collections.Generic;
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
using ppapp.Classes;

namespace ppapp.Windows
{
 
    public partial class ServiceWindow : Window
    {
        private readonly User _user;
        DB.AppContext appContext = new DB.AppContext();


       
        public ServiceWindow(User user)
        {
            InitializeComponent();
            ServicesView.ItemsSource = changsalonEntities1.GetContext().Services.ToList();
        }

        private void isAdmin()
        {
            edit_btn.IsEnabled = _user.is_admin;
            add_btn.IsEnabled = _user.is_admin;
            delete_btn.IsEnabled = _user.is_admin;
        }
        private void service_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var SelectedItem = ServicesView.SelectedItem as Services;
                if (SelectedItem != null)
                {
                    EditService editService = new EditService();
                    Close();
                    editService.Show();

                }
                else
                {
                    throw new Exception("Не выбрана запись");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            EditService editService = new EditService();
            Close();
            editService.Show();
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            isAdmin();
        }
    }
}
