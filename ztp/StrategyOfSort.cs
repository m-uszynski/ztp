using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    abstract class StrategyOfSort
    {
        public abstract List<IProduct> Sort(List<IProduct> products);
    }
}
