using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    public class Order
    {
        public string OrderID { get; set; }
        public int CustomerID { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
