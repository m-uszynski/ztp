using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    public class Order : IOrder
    {
        DataFacade data = new DataFacade();

        public int OrderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pesel { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalCost { get; set; }

        public Order() { }

        public Order(int OrderId, string Firstname, string Lastname, string Pesel, DateTime OrderDate, float TotalCost)
        {
            this.OrderId = OrderId;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Pesel = Pesel;
            this.OrderDate = OrderDate;
            this.TotalCost = TotalCost;
        }

        public Order(string Firstname, string Lastname, string Pesel)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Pesel = Pesel;
        }

        public virtual float getTotalCost()
        {
            float sum = 0.0f;
            List<OrderedProduct> products = data.GetOrderedProducts(this.OrderId);
            foreach(OrderedProduct product in products)
            {
                //return (Count * Price) - ((Count * Price) * ((float)VAT / 100));
                sum += (product.Count * product.Price) - ((product.Count * product.Price) * ((float)product.VAT / 100));
                
            }
            return sum;
        }

        public virtual float getTotalCost(int OrderId)
        {
            float sum = 0.0f;
            List<OrderedProduct> products = data.GetOrderedProducts(OrderId);
            foreach (OrderedProduct product in products)
            {
                //return (Count * Price) - ((Count * Price) * ((float)VAT / 100));
                sum += (product.Count * product.Price) - ((product.Count * product.Price) * ((float)product.VAT / 100));
            }
            return sum;
        }

    }
}
