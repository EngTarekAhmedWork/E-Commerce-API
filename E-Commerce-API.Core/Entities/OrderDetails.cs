﻿namespace E_Commerce_API.Core.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; } 
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public Product? Product { get; set; }
}
