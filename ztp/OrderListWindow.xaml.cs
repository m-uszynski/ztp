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
    /// Logika interakcji dla klasy OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        DataFacade data = new DataFacade();
        private List<Order> orders = new List<Order>();
        private List<OrderedProduct> orderedProducts = new List<OrderedProduct>();
        private int orderSelectedId = -1;

        public OrderListWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            orders = data.getOrders();
            Orders.ItemsSource = orders;
        }

        private void OrderListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                Order order = item.DataContext as Order;
                orderSelectedId = order.OrderId;
                //Console.WriteLine(orderSelectedId);
            }
            if(orderSelectedId != -1)
            {
                orderedProducts = data.GetOrderedProducts(orderSelectedId);
                OrderedProducts.ItemsSource = orderedProducts;
            }
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow aow = new AddOrderWindow();
            aow.Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
