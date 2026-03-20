using InventoryManagementConsoleApp.Models;
using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InventoryManagementConsoleApp.Services;

public class Inventory
{
    public List<Product> Products { get; private set; } = new List<Product>();

    //Add a product to the inventory
    public void AddProduct(Product product)
    {
        if (Products.Any(x => x.Id == product.Id))
            throw new InvalidOperationException("Product ID already exists.");
        Products.Add(product);

    }

    //Get all products in the inventory
    public List<Product> GetAllProducts()
    {

        return Products;
    }

    //Get a product by ID
    public Product GetProductById(int productId) 
    {
        try
        {
            if (productId <= 0)
            {
                Console.WriteLine("Invalid product ID. Must be > 0.");
                return null;
            }

            return Products.FirstOrDefault(p => p.Id == productId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving product: {ex.Message}");
            return null;
        }
        return Products[productId]; 
    }

    //Remove a product from the inventory
    public void RemoveProduct(int productId)
    {
        var product = Products.FirstOrDefault(x => x.Id == productId);
        if (product == null)
            throw new InvalidOperationException("Product not found.");
        Products.Remove(product);
    }

    //Update a product in the inventory
    public void UpdateProduct(Product updatedProduct)
    {
        var product = Products.FirstOrDefault(x => x.Id == updatedProduct.Id);
        if (product == null)
            throw new InvalidOperationException("Product not found.");
        product.Name = updatedProduct.Name;
        product.Quantity = updatedProduct.Quantity;
        product.Price = updatedProduct.Price;
    }
    // Generate a report of the inventory
    public (int totalItems, decimal totalValue) GenerateReport()
    {
        int totalItems = Products.Sum(p => p.Quantity);
        decimal totalValue = Products.Sum(p => p.Quantity * p.Price);
        return (totalItems, totalValue);
    }


}
