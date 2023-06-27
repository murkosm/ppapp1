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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ListView = System.Windows.Controls.ListView;
using System.Data;

namespace ppapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage1.xaml
    /// </summary>
    public partial class MainPage1 : Page
    {
        User _user;
   
        public MainPage1(User user)
        {
          
            _user = user;
            InitializeComponent();

            MainGrid.ItemsSource = changsalonEntities1.GetContext().Products.ToList();
            CountProduct.Text = changsalonEntities1.GetContext().Products.ToList().Count + "/" + changsalonEntities1.GetContext().Products.ToList().Count;
            Sorting.SelectedIndex = 0;

        }

      

        private void is_admin()
        {
            add_btn.IsEnabled = _user.is_admin;
            delete_product_btn.IsEnabled = _user.is_admin;
            edit_product_btn.IsEnabled = _user.is_admin;
            ProductsMenu.IsEnabled = _user.is_admin;


           

        }

     
        private void Filter()
        {
            List<Products> product = new List<Products>();
            product = changsalonEntities1.GetContext().Products.ToList();

            if (!string.IsNullOrWhiteSpace(search_product.Text))  
            {
                product = product.Where(x => x.Product_name.ToLower().Contains(search_product.Text.ToLower())).ToList();
                if (product.Count == 0)
                {
                    MessageBox.Show("Записей с таким названием нет");
                    search_product.Text = "";
                }
            }

            switch (Sorting.SelectedIndex)
            {
                case 0:
                    {
                        product.Sort((x, y) => x.Count.CompareTo(y.Count));
                    }
                    break;
                case 1:
                    {
                        product.Sort((x, y) => x.Count.CompareTo(y.Count));
                        product.Reverse();
                    }
                    break;
            }


            MainGrid.ItemsSource = product;
            if (product.Count == 0)
            {
                MessageBox.Show("нет записей");
                CountProduct.Text = changsalonEntities1.GetContext().Products.ToList().Count + "/" + changsalonEntities1.GetContext().Products.ToList().Count;
                Sorting.SelectedIndex = 0;
                search_product.Text = "";


            }
            CountProduct.Text = changsalonEntities1.GetContext().Products.ToList().Count + "/" + changsalonEntities1.GetContext().Products.ToList().Count;
        }
      

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
         
            ClassFrame.authFrame.Navigate(new autharization());
        }

        private void ServiceMenu_Click(object sender, RoutedEventArgs e)
        {
         
            Windows.ServiceWindow serviceWindow = new Windows.ServiceWindow(_user);
            
            serviceWindow.Show();
        }

        private void ProductsMenu_Click(object sender, RoutedEventArgs e)
        {
            SaleProducts saleProducts = new SaleProducts();
            saleProducts.Show();
        }

        private void add_product_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Товар добавлен в корзину.", "Корзина", MessageBoxButton.OK);
        }

        private void edit_product_btn_Click(object sender, RoutedEventArgs e)
        {

            var SelectedItem = MainGrid.SelectedItem as Products;
            if (SelectedItem != null)
            {
                EditAdd editAdd = new EditAdd();
                editAdd.Show();
            }
            else
            {
                throw new Exception("Не выбрана запись");
                
            }




        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            is_admin();
            status.Text = $"{_user.Login}: {_user.Status}";
     
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
            Filter();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.EditAdd editAdd = new Windows.EditAdd();
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

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            List<Products> product = new List<Products>();
            product = changsalonEntities1.GetContext().Products.ToList();
            MainGrid.ItemsSource = product;
        }
    }
}
