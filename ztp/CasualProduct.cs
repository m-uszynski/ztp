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
        public float Price { get; set; }
        public int VAT { get; set; }

        public float Sum
        {
            get
            {
                return Count * Price;
            }
        }

        public CasualProduct(string Name, int Count, float Price, int VAT)
        {
            this.Name = Name;
            this.Count = Count;
            this.Price = Price;
            this.VAT = VAT;
        }
    }
}
