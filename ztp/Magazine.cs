using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ztp
{
    class Magazine
    {
        private List<IProduct> products = new List<IProduct>();

        public void AddProduct(string Name, int Count, float Price, int VAT)
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "insert into products(id,name,count,price,vat) values (NULL,'" + Name + "','" + Count + "','" + Price + "','" + VAT + "');";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) { }

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
            }

            //products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "delete from products where id='" + id + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) { }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }

        public void IncrementCountProduct(int id, int countToIncrement)
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "update products set count=count+" + countToIncrement + " where id='" + id + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) { }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }

        public void DecrementCountProduct(int id, int countToDecrement)
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "update products set count=count-" + countToDecrement + " where id='" + id + "';";

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

        public IProduct GetProduct(int id)
        {
            IProduct product = null;
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "select * from products where id='" + id + "';";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductCreator pc = new CasualProductCreator();
                    product = pc.Create(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetInt32(4));
                }

                con.Close();

                return product;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
                return null;
            }
        }

        public List<IProduct> GetAllProducts()
        {
            try
            {
                string connectionString = "Server=remotemysql.com;Database=ZLVoYz8ysj;Uid=ZLVoYz8ysj;Pwd=7FkJ5gfEh0;";
                string query = "select * from products";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductCreator pc = new CasualProductCreator();
                    products.Add(pc.Create(reader.GetInt32(0),reader.GetString(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetInt32(4)));
                }

                reader.Close();
                con.Close();


                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + ex.Message);
                return null;
            }
        }
    }
}
