namespace E_Commerce_API.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public string OrderStatus { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int OrderPrice { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public IEnumerable<OrderDetails>? Details { get; set; }
}
