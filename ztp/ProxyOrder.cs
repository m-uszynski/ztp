using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class ProxyOrder : IOrder
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pesel { get; set; }

        private IOrder order;


        public ProxyOrder(string Firstname, string Lastname, String Pesel)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Pesel = Pesel;
        }

        private void CreateInstance()
        {
            order = new Order(this.Firstname, this.Lastname, this.Pesel);
        }

        public Order Validate(List<IProduct> orderedProduct)
        {
            bool validation = true;

            if (this.Firstname.Length < 0) { validation = false; }
            if (this.Lastname.Length < 0) { validation = false; }
            if (this.Pesel.Length != 11) { validation = false; }
            if (orderedProduct.Count < 1) { validation = false; }

            if (validation == true)
            {
                CreateInstance();
                return (Order) order;
            }

            return null;
        }

    }
}
