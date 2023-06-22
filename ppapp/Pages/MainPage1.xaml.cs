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
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.ComponentModel;
using System.Collections;
using ppapp.Windows;
using Button = System.Windows.Controls.Button;

namespace ppapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage1.xaml
    /// </summary>
    public partial class MainPage1 : Page
    {
        private readonly User _user;
        private Products _products = new Products();

        DB.AppContext appContext = new DB.AppContext();


        
        public MainPage1()
        {

            var db = changsalonEntities1.GetContext().Products.ToList();
            InitializeComponent();
            MainGrid.ItemsSource = db;
            CountProduct.Text = db.Count + "/" + db.Count;
            add_product_btn.Visibility = Visibility.Collapsed;
            //this._products = products;
        }
        public MainPage1(User user)
        {
            var db = changsalonEntities1.GetContext().Products.ToList();
            _user = user;
            InitializeComponent();
            MainGrid.ItemsSource = db;
            CountProduct.Text = db.Count + "/" + db.Count;
            add_product_btn.Visibility = Visibility.Collapsed; 
        }

      

        private void is_admin()
        {
            add_btn.IsEnabled = _user.is_admin;
            delete_product_btn.IsEnabled = _user.is_admin;
            edit_product_btn.IsEnabled = _user.is_admin;
        }

        void Filter()
        {
          
        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
         
            ClassFrame.authFrame.Navigate(new autharization());
        }

        private void ServiceMenu_Click(object sender, RoutedEventArgs e)
        {
            Windows.ServiceWindow serviceWindow = new Windows.ServiceWindow();
            
            serviceWindow.Show();
        }

        private void ProductsMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_product_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_product_btn_Click(object sender, RoutedEventArgs e)
        {


            //try
            //{
            //    var SelectedItem = MainGrid.SelectedItem as Products;
            //    if (SelectedItem != null)
            //    {
            //        ClassFrame.authFrame.Navigate(new EditAdd(SelectedItem));

            //    }
            //    else
            //    {
            //        throw new Exception("Не выбрана запись");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            is_admin();
          
        }

        private void delete_product_btn_Click(object sender, RoutedEventArgs e)
        {
            var productToRemove = changsalonEntities1.GetContext().Products.ToList();

            if (MessageBox.Show($"Вы уверены, что хотите удалить товар?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    changsalonEntities1.GetContext().Products.RemoveRange(productToRemove);
                    changsalonEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Товар удален");

                    MainGrid.ItemsSource = changsalonEntities1.GetContext().Products.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void search_product_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.EditAdd editAdd = new Windows.EditAdd();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
            editAdd.Show(); 
        }

        private void MainGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                changsalonEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MainGrid.ItemsSource = changsalonEntities1.GetContext().Products.ToList();
            }
        }
    }
}
