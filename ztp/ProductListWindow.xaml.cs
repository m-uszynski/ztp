﻿using System;
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
        public ProductListWindow()
        {
            InitializeComponent();
            List<IProduct> products = new List<IProduct>();
            ProductCreator pc = new CasualProductCreator();
            products.Add(pc.Create("Garnitur", 3, 23.23, 23));
            products.Add(pc.Create("Koszula", 4, 10, 23));
            Products.ItemsSource = products;
        }
    }
}
