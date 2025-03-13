using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.DTOs
{
   public class CartDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quntity { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        

        public decimal Total => Price * Quntity;
    }
}
