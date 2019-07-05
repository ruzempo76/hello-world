using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;

namespace Northwind.DataAccess
{
    public static class NorthwindData
    {
        public static List<Order> GetAllOrdersByCustomer(string customerid)
        {
            List<Order> list = new List<Order>();

            using (SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string sql = @"SELECT OrderId,OrderDate,
                                    RequiredDate,ShippedDate,
                                    ShipVia,ShipName 
                                FROM Orders
                                WHERE CustomerId = @customerid";

                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                cmd.Parameters.AddWithValue("@customerid", customerid);

                SqlCeDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadOrders(reader));
                }
            }

            return list;

        }

        private static Order LoadOrders(IDataReader reader)
        {
            Order item = new Order();

            item.OrderId = Convert.ToInt32(reader["OrderId"]);
            item.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
            item.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
            item.ShippedDate = reader["ShippedDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["ShippedDate"]);
            item.ShipVia = Convert.ToString(reader["ShipVia"]);
            item.ShipName = Convert.ToString(reader["ShipName"]);

            item.Details = GetOrderDetailsByOrder(item.OrderId);

            return item;
        }

        public static List<OrderDetail> GetOrderDetailsByOrder(int orderid)
        {
            List<OrderDetail> list = new List<OrderDetail>();

            using (SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string sql = @"SELECT OrderId,ProductId,
                                    UnitPrice, Quantity, Discount 
                              FROM Order_Details 
                              WHERE OrderId = @orderid";

                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                cmd.Parameters.AddWithValue("@orderid", orderid);

                SqlCeDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadOrderDetails(reader));
                }
            }

            return list;

        }

        private static OrderDetail LoadOrderDetails(IDataReader reader)
        {
            OrderDetail item = new OrderDetail();

            item.OrderId = Convert.ToInt32(reader["OrderId"]);
            item.ProductId = Convert.ToInt32(reader["ProductId"]);
            item.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
            item.Quantity = Convert.ToInt32(reader["Quantity"]);
            item.Discount = Convert.ToInt32(reader["Discount"]);

            item.Product = GetProductById(item.ProductId);

            return item;
        }

        public static Product GetProductById(int productid)
        {
            Product product = null;

            using (SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string sql = @"SELECT ProductId, ProductName 
                                FROM Products 
                                WHERE ProductId = @productid";

                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productid", productid);

                SqlCeDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = LoadProduct(reader);
                }
            }

            return product;

        }

        private static Product LoadProduct(IDataReader reader)
        {
            Product item = new Product();

            item.ProductId = Convert.ToInt32(reader["ProductId"]);
            item.ProductName = Convert.ToString(reader["ProductName"]);

            return item;
        }

    }

}
