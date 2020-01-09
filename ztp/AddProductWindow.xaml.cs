using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logika interakcji dla klasy AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        DataFacade data = new DataFacade();
        public AddProductWindow()
        {
            InitializeComponent();

            // Seperator float number (,) -> (.)
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string count = nameTextBox.Text;
            string price = nameTextBox.Text;
            string vat = nameTextBox.Text;

            int countNumber = 0;
            float priceNumber = 0;
            int vatNumber = 0;

            bool validation = true;

            // name validation
            if (name.Length < 1)
            {
                validation = false;
                MessageBox.Show("Nazwa nie może być pusta", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // count validation
            if(!Int32.TryParse(countTextBox.Text, out countNumber))
            {
                validation = false;
                MessageBox.Show("Ilość jest nieprawidłowa (musi być liczba całkowita)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // price validation
            if (priceTextBox.Text.Contains(","))
            {
                validation = false;
                MessageBox.Show("Cena jest nieprawidłowa (zamiast , użyj .)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    priceNumber = float.Parse(priceTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                    Console.WriteLine(priceNumber);
                }
                catch
                {
                    validation = false;
                    MessageBox.Show("Cena jest nieprawidłowa", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            if (priceNumber < 0)
            {
                validation = false;
                MessageBox.Show("Cena musi być liczbą dodatnią", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // vat validation
            if (!Int32.TryParse(vatTextBox.Text, out vatNumber))
            {
                validation = false;
                MessageBox.Show("VAT musi być liczbą całkowitą", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(vatNumber<0 || vatNumber > 100)
            {
                validation = false;
                MessageBox.Show("VAT musi być z zakresu 0-100", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            

            if (validation == true)
            {
                data.addProduct(name, countNumber, priceNumber, vatNumber);
                ProductListWindow mw = (ProductListWindow)Application.Current.MainWindow;
                mw.refreshList();
                this.Close();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
