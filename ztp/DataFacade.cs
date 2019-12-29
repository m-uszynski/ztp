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
    }
}
