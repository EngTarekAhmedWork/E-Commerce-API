using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Entities
{
    internal class Order
    {
        public int Id { get; set; }

        public string OrderName { get; set; }
        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderPrice { get; set; }

        public int OrderDetailsId { get; set; }

        public OrderDetails OrderDetails { get; set; }

        
    }
}
