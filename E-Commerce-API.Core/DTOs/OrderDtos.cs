using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.DTOs
{
    public record OrderDtos
    {
        public string OrderStatus { get; set; }
        public int OrderPrice { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }

        public int UserId { get; set; }
    }


    public record OrderDetailsDto 
    {
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public int ProductId { get; set; }

        //public OrderDtos OrderDtos { get; set; }
    }
}
