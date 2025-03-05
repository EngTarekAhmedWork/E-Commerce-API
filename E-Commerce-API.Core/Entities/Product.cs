namespace E_Commerce_API.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
<<<<<<< HEAD
}
=======
}
>>>>>>> 763c85d06ea0115cb0bfc9b5b98b5fa07fdc81ad
