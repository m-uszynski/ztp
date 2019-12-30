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
    /// Logika interakcji dla klasy AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        DataFacade data = new DataFacade();
        private List<IProduct> availableProducts = new List<IProduct>();
        private List<IProduct> chosenProducts = new List<IProduct>();

        private int selectedProductId = -1;
        private int selectedChoosenProductId = -1;

        public AddOrderWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            availableProducts = data.getProducts();
            AvailableProducts.ItemsSource = availableProducts;
            ChosenProducts.ItemsSource = chosenProducts;

            chooseProductBtn.IsEnabled = false;
            backChooseProductBtn.IsEnabled = false;
        }

        private void AvailableProductListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                IProduct product = item.DataContext as IProduct;
                selectedProductId = product.Id;
                //Console.WriteLine(selectedProductId);
                chooseProductBtn.IsEnabled = true;
            }
        }

        private void ChoosenProductListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if(item != null)
            {
                IProduct product = item.DataContext as IProduct;
                selectedChoosenProductId = product.Id;
                //Console.WriteLine(selectedChoosenProductId);
                backChooseProductBtn.IsEnabled = true;
            }
        }

        private void chooseProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProductId == -1) return;
            AddProductInOrderWindow apiow = new AddProductInOrderWindow(selectedProductId);
            apiow.Show();
        }


        public void addToChosenList(IProduct product)
        {
            chosenProducts.Add(product);
            ChosenProducts.Items.Refresh();

            var itemToRemove = availableProducts.Single(a => a.Id == product.Id);
            if (itemToRemove != null) availableProducts.Remove(itemToRemove);
            AvailableProducts.Items.Refresh();

            chooseProductBtn.IsEnabled = false;
        }

        private void backChooseProductBtn_Click(object sender, RoutedEventArgs e)
        {
            availableProducts.Add(data.getProduct(selectedChoosenProductId));
            AvailableProducts.Items.Refresh();

            var itemToRemove = chosenProducts.Single(a => a.Id == selectedChoosenProductId);
            if (itemToRemove != null) chosenProducts.Remove(itemToRemove);
            ChosenProducts.Items.Refresh();

            backChooseProductBtn.IsEnabled = false;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderListWindow olw = new OrderListWindow();
            olw.Show();
            this.Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            ProxyOrder proxyOrder = new ProxyOrder(FirstnameTextBox.Text, LastnameTextBox.Text, PeselTextBox.Text);
            IOrder order = proxyOrder.Validate(chosenProducts);
            if (order != null)
            {
                foreach(IProduct product in chosenProducts)
                {
                    data.decrementCountProduct(product.Id, product.Count);
                }
                data.addOrder(order.Firstname, order.Lastname, order.Pesel, chosenProducts);
                OrderListWindow olw = new OrderListWindow();
                olw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Imie i nazwisko nie powinno być puste, PESEL musi składać się z 11 cyfr oraz lista produktów nie może być pusta", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
