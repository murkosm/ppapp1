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
            _user = user;
            InitializeComponent();
            ServicesView.ItemsSource = changsalonEntities1.GetContext().Services.ToList();
        }
        public ServiceWindow()
        {
         
            InitializeComponent();
            ServicesView.ItemsSource = changsalonEntities1.GetContext().Services.ToList();
        }

        private void isAdmin()
        {

            add_btn.IsEnabled = _user.is_admin;
            
        }
        private void service_btn_Click(object sender, RoutedEventArgs e)
        {

        }

      

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            EditService editService = new EditService(_user);
            Close();
            editService.Show();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            isAdmin();
        }

        private void service_btn_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы записаны, сообщение с подробной информацией придет вам на электронную почту!", "Уведомление о записи", MessageBoxButton.OK);
        }
    }
}
