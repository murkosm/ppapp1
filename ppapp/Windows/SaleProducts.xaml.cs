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

namespace ppapp.Windows
{
    /// <summary>
    /// Логика взаимодействия для SaleProducts.xaml
    /// </summary>
    public partial class SaleProducts : Window
    {
        public SaleProducts()
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = changsalonEntities1.GetContext().ProductSale.ToList();
        }
    }
}
