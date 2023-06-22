using ppapp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using ppapp.DB;
using System.Data;

namespace ppapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        DB.AppContext appContext = new DB.AppContext();

        private void registation_btn_Click(object sender, RoutedEventArgs e) // регистрируем пользователя
        {
          
            var login = textbox_login.Text;
            var password = textbox_password.Text;
            var name = textbox_name.Text;
            var surname = textbox_surname.Text;
            var patronymic = textbox_patr.Text;
            var birthday = datepicker.Text;
            var email = textbox_email.Text;
            var sex = box_sex.Text;
             DateTime dt = DateTime.Now;
            //снова обращаемся к бд, чтобы онa создалa и сохранила новые данные
            string querystring = $"INSERT INTO [User1](login_user, password_user, name_user, surname_user, patronymic, email_user, datetime_user, sex, birthday, is_admin) values('{login}', '{password}' , '{name}', '{surname}','{patronymic}', '{email}','{dt}','{sex}','{birthday}', 0)";
             

            SqlCommand command = new SqlCommand(querystring, appContext.GetConnection());

            appContext.OpenConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрированы.", "Регистрация", MessageBoxButton.OK);
                ClassFrame.authFrame.Navigate(new autharization());

            }
            else
            {
                MessageBox.Show("Поля заполнены некорректно.", "Ошибка!", MessageBoxButton.OK);

            }
            appContext.CloseConnection();
        }

        private Boolean checkuser() //проверка, не зарегистрирован ли уже такой пользователь. я протестила. не работает(
        {
            var loginUser = textbox_login.Text;
            var passwordUser = textbox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT login_user, password_user FROM [User1] WHERE login_user= '{loginUser}' and password_user= '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, appContext.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже зарегистрирован", "Ошибка!", MessageBoxButton.OK);
                return true;
            }
            else
            {
                return false;
            }
        }


        private void go_to_auth_btn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.authFrame.Navigate(new autharization());
        }
    }
}
