using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class ChristmasSaleDecorator : OrderDecorator
    {
        public ChristmasSaleDecorator(Order order) : base(order) { }
        public override float getTotalCost()
        {
            return base.getTotalCost()*7/10;
        }
    }
}