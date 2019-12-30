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

        public IProduct getProduct(int id)
        {
            return magazine.GetProduct(id);
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

        public void decrementCountProduct(int id, int count)
        {
            magazine.DecrementCountProduct(id, count);
        }

        // Orders API
        public List<Order> getOrders()
        {
            return orderRepository.GetAllProducts();
        }

        public void addOrder(IOrder order, List<IProduct> orderedProducts)
        {
            orderRepository.AddOrder(order, orderedProducts);
        }

        // OrderedProducts API
        public List<OrderedProduct> GetOrderedProducts(int OrderId)
        {
            return orderRepository.getOrderedProducts(OrderId);
        }
    }
}
