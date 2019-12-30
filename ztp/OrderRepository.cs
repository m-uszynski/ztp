﻿using MySql.Data.MySqlClient;
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
                    Order currentOrder = new Order(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4));
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
    }
}