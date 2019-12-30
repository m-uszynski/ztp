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

        public OrderListWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            orders = data.getOrders();
            Orders.ItemsSource = orders;
        }
    }
}
