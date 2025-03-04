using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Entities
{
    internal class OrderDetails
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; } 

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public List<Product> Products { get; set; }


    }
}
