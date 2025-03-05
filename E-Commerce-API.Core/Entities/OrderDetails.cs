namespace E_Commerce_API.Core.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int Quantity { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
    public int Price { get; set; }
=======
    public int Price { get; set; } 
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
=======
    public int Price { get; set; } 
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
}
=======
}
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
