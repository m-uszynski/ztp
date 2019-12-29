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

namespace ztp
{
    /// <summary>
    /// Logika interakcji dla klasy ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        DataFacade data = new DataFacade();
        private List<IProduct> products;

        public ProductListWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            products = data.getProducts();
            Products.ItemsSource = products;
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            //data.addProduct("Test", 1, 10, 8);
            //refreshList();
            AddProductWindow apw = new AddProductWindow();
            apw.Show();
        }

        public void refreshList()
        {
            products.Clear();
            products = data.getProducts();
            Products.Items.Refresh();
        }

        private void backToMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow m = (ProductListWindow)Application.Current.MainWindow;
            MainWindow mw = new MainWindow();
            mw.Show();
            m.Close();
        }
    }
}
