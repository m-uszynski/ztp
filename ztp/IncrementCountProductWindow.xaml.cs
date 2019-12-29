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
    /// Logika interakcji dla klasy IncrementCountProductWindow.xaml
    /// </summary>
    public partial class IncrementCountProductWindow : Window
    {
        DataFacade data = new DataFacade();
        private int id = -1;
        public IncrementCountProductWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void IncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            int countToIncrement = 0;
            bool validation = true;

            if (!Int32.TryParse(CountTextBox.Text, out countToIncrement))
            {
                validation = false;
                MessageBox.Show("Ilość musi być liczbą całkowitą", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (countToIncrement < 1)
                {
                    validation = false;
                    MessageBox.Show("Ilość musi być większa od 0", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if(validation == true)
            {
                if (id == -1) return;
                data.incrementCountProduct(id, countToIncrement);
                ProductListWindow mw = (ProductListWindow)Application.Current.MainWindow;
                mw.refreshList();
                this.Close();
            }

        }
    }
}
