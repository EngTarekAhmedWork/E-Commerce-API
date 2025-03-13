

namespace E_Commerce_API.Core.Entities
{
   public class Cart
    {
        public int Id { get; set; }
        public int Quntity { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public int Price { get; set; }

        public decimal Total => Price * Quntity;
        public User user { get; set; }
        public Product product { get; set; }
    }
}
