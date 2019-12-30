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
    /// Logika interakcji dla klasy AddProductInOrderWindow.xaml
    /// </summary>
    public partial class AddProductInOrderWindow : Window
    {
        DataFacade data = new DataFacade();
        private IProduct selectedProduct;

        public AddProductInOrderWindow(int id)
        {
            InitializeComponent();
            selectedProduct = data.getProduct(id);

            ProductNameLabel.Content = "Nazwa: " + selectedProduct.Name;
            ProductCountLabel.Content = "Ilość w magazynie: " + selectedProduct.Count;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct.Count = 1;
            AddOrderWindow mw = (AddOrderWindow)Application.Current.MainWindow;
            mw.addToChosenList(selectedProduct);
            this.Close();
        }
    }
}
