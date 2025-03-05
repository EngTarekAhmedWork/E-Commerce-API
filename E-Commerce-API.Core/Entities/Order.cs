namespace E_Commerce_API.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public string OrderStatus { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int OrderPrice { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
<<<<<<< HEAD
}
=======
}
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
