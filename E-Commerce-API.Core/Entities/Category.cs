namespace E_Commerce_API.Core.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product>? Products { get; set; }
}