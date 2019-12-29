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
        private int selectedId = -1;

        public ProductListWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            deleteProductBtn.IsEnabled = false;
            products = data.getProducts();
            Products.ItemsSource = products;
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
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

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                IProduct cp = item.DataContext as IProduct;
                selectedId = cp.Id;
                deleteProductBtn.IsEnabled = true;
                Console.WriteLine(cp.Id);
            }
        }

        private void deleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            data.deleteProduct(selectedId);
            selectedId = -1;
            deleteProductBtn.IsEnabled = false;
            refreshList();
        }

        private void Products_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
