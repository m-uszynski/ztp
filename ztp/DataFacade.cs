using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class DataFacade
    {
        Magazine magazine = new Magazine();
        OrderRepository orderRepository = new OrderRepository();

        // Products API
        public List<IProduct> getProducts()
        {
            return magazine.GetAllProducts();
        }

        public void addProduct(string Name, int Count, float Price, int VAT)
        {
            magazine.AddProduct(Name, Count, Price, VAT);
        }

        public void deleteProduct(int id)
        {
            magazine.DeleteProduct(id);
        }

        public void incrementCountProduct(int id, int count)
        {
            magazine.IncrementCountProduct(id, count);
        }

        // Orders API
        public List<Order> getOrders()
        {
            return orderRepository.GetAllProducts();
        }
    }
}
