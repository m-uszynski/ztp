using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    abstract class OrderDecorator : Order
    {
        protected Order order;
        public OrderDecorator(Order order)
        {
            this.order = order;
        }

        public override float getTotalCost()
        {
            return order.getTotalCost();
        }
    }
}
