using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class Order
    {

        public int OrderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pesel { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int OrderId, string Firstname, string Lastname, string Pesel, DateTime OrderDate)
        {
            this.OrderId = OrderId;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Pesel = Pesel;
            this.OrderDate = OrderDate;
        }

        public Order(string Firstname, string Lastname, string Pesel)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Pesel = Pesel;
        }
    }
}
