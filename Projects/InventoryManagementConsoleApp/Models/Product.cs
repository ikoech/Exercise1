using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementConsoleApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    //public int ProductId { get; set; }
    public string DisplayProductInfo()
    {
        return $"ID: {Id}, Name: {Name}, Quantity: {Quantity}, Price: {Price:C}";
    }
}
