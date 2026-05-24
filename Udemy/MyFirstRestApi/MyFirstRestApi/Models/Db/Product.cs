using System;
using System.Collections.Generic;

namespace MyFirstRestApi.Models.Db;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public int? Qty { get; set; }

    public string? Description { get; set; }
}
