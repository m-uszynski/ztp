using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class SortByPrice : StrategyOfSort
    {
        public override List<IProduct> Sort(List<IProduct> products)
        {
            List<IProduct> sortedProduct = new List<IProduct>();
            sortedProduct = products;
            sortedProduct.Sort((x, y) => x.Price.CompareTo(y.Price));
            return sortedProduct;
        }
    }
}
