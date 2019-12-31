using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ztp
{
    class OrderRepository
    {
        private List<Order> orders = new List<Order>();

        public OrderRepository()
        {
            // Seperator float number (,) -> (.)
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        
        public void UpdateOrderTotalCost(int id, float cost)
        {
            Console.WriteLine("CENA: " + cost);
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "update orders set totalcost=" + cost + " where orderid='" + id + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) { }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }

        public Order GetOrder(int id)
        {
            Order order = null;
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "select * from orders where orderid='" + id + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    order = new Order(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetFloat(5));
                }

                con.Close();

                return order;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
                return null;
            }
        }

        public List<Order> GetAllProducts()
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "select * from orders";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order currentOrder = new Order(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetFloat(5));
                    orders.Add(currentOrder);
                }

                reader.Close();
                con.Close();

                return orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
                return null;
            }
        }

        public List<OrderedProduct> getOrderedProducts(int OrderId)
        {
            List<OrderedProduct> orderedProducts = new List<OrderedProduct>();
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "select * from orderedproducts where orderid='" + OrderId + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderedProduct currentOrderedProducts = new OrderedProduct(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetInt32(5),reader.GetInt32(6));
                    orderedProducts.Add(currentOrderedProducts);
                }

                reader.Close();
                con.Close();

                return orderedProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
                return null;
            }
        }

        public int orderId = -1;

        public int getLastOrderId()
        {
            return orderId;
        }

        public void AddOrder(Order order, List<IProduct> orderedProducts)
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                MySqlConnection con = new MySqlConnection(connectionString);

                // INSERT ORDER
                string query = "insert into orders(orderid,firstname,lastname,pesel,date,totalcost) values (NULL,'" + order.Firstname + "','" + order.Lastname + "','" + order.Pesel + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" + 0 + "');";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                con.Close();

                // READ ORDER ID
                string readIdQuery = "select last_insert_id()";
                MySqlCommand cmd2 = new MySqlCommand(readIdQuery, con);
                con.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read()) { orderId = reader2.GetInt32(0); }
                con.Close();

                // INSERT ALL CHOSEN PRODUCT TO ORDER
                foreach (IProduct product in orderedProducts)
                {
                    con.Open();
                    //OrderedProduct orderedProduct = new OrderedProduct(0, product.Id, product.Name, product.Count, product.Price, product.VAT, orderId);
                    string writeOrderProductQuery = "insert into orderedproducts(orderedproductid,productid,name,count,price,vat,orderid) values (NULL,'" + product.Id + "','" + product.Name + "','" + product.Count + "','" + product.Price + "','" + product.VAT + "','" + orderId + "');";
                    MySqlCommand cmd3 = new MySqlCommand(writeOrderProductQuery, con);
                    MySqlDataReader reader3 = cmd3.ExecuteReader();
                    while(reader3.Read()) { }
                    con.Close();
                }

                // EDIT ORDER TOTALCOST
                string updateTotalSumQuery = "update orders set totalcost=" + order.getTotalCost(orderId) + " where orderid='" + orderId + "';";
                MySqlCommand cmdUpdate = new MySqlCommand(updateTotalSumQuery, con);
                con.Open();
                MySqlDataReader readerUpdate = cmdUpdate.ExecuteReader();
                while (readerUpdate.Read()) { }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
            }

            //products.Add(product);
        }
    }
}
