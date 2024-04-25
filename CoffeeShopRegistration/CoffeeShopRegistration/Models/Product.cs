using System;
using System.Collections.Generic;

namespace CoffeeShopRegistration.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;
}
