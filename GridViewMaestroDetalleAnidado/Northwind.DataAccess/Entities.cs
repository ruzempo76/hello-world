using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DataAccess
{

    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public string ShipVia { get; set; }
        public string ShipName { get; set; }

        public List<OrderDetail> Details { get; set; }
    }

    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public Product Product { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
    }


}
