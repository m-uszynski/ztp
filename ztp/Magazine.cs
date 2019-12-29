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

        public void AddProduct(IProduct product)
        {
            products.Add(product);
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
                    //Console.WriteLine(reader.GetString(1) + " " + reader.GetInt32(2) + " " + reader.GetFloat(3) + " " + reader.GetInt32(4));
                    ProductCreator pc = new CasualProductCreator();
                    products.Add(pc.Create(reader.GetString(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetInt32(4)));
                }

                reader.Close();
                con.Close();


                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
