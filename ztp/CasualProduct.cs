using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class CasualProduct : IProduct
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int VAT { get; set; }

        public double Sum
        {
            get
            {
                return Count * Price;
            }
        }

        public CasualProduct(string Name, int Count, double Price, int VAT)
        {
            this.Name = Name;
            this.Count = Count;
            this.Price = Price;
            this.VAT = VAT;
        }
    }
}
