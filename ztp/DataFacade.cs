using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class DataFacade
    {
        Magazine magazine = new Magazine();

        public List<IProduct> getProducts()
        {
            return magazine.GetAllProducts();
        }

        public void addProduct(string Name, int Count, float Price, int VAT)
        {
            magazine.AddProduct(Name, Count, Price, VAT);
        }
    }
}
