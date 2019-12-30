using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class OrderedProduct
    {
        public int OrderedProductId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public int VAT { get; set; }
        public int OrderId { get; set; }

        public OrderedProduct(int OrderedProductId, string Name, int Count, float Price, int Vat, int OrderId)
        {
            this.OrderedProductId = OrderedProductId;
            this.Name = Name;
            this.Count = Count;
            this.Price = Price;
            this.VAT = Vat;
            this.OrderId = OrderId;
        }
    }
}
