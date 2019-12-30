using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class Sorter
    {
        private StrategyOfSort strategy;

        public Sorter(StrategyOfSort strategy)
        {
            this.strategy = strategy;
        }

        public List<IProduct> Sort(List<IProduct> products)
        {
            return strategy.Sort(products);
        }
    }
}
