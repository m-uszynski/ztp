using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class Magazine
    {
        private List<IProduct> products = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }

        public List<IProduct> GetAllProducts()
        {
            return products;
        }
    }
}
