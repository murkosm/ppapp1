using ppapp.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// <summary>
    /// Логика взаимодействия для EditService.xaml
    /// </summary>
    public partial class EditService : Window
    {
        User _user;
        DB.AppContext appContext = new DB.AppContext();
        public EditService(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            appContext.OpenConnection();


           

            var type = type_box.Text;
            var description = description_box.Text;
            int duration;
            var staff = staff_box.Text;
            var price = price_box.Text;


           

            if (int.TryParse(duration_box.Text, out duration))
            {
                var addquary = $"INSERT INTO [Services](type_of, description_of, duration, staff, price) VALUES('{type}', '{description}', '{duration}', '{staff}', '{price}')";

                SqlCommand command = new SqlCommand(addquary, appContext.GetConnection());

                appContext.OpenConnection();

                command.ExecuteNonQuery();

                MessageBox.Show("Информация сохранена.");
                Close();
                ServiceWindow serviceWindow = new ServiceWindow(_user);
                serviceWindow.Show();

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
            ServiceWindow serviceWindow = new ServiceWindow(_user);
            serviceWindow.Show();
        }
    }
}
