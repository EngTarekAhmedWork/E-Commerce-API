using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.DTOs
{
    public record OrderDetailsDto 
    {
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int ProductId { get; set; }

        //public OrderDtos OrderDtos { get; set; }
    }
}
