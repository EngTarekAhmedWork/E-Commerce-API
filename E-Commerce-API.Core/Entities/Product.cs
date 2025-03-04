namespace E_Commerce_API.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
