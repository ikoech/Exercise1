using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //Create an instance of the ProductInventory class and call the Run method to start the application
        var productInventory = new ProductInventory();
        productInventory.Run();
    }
}
//Manage a product inventory with options to add new products, display all products sorted by price, and quit the application.
//The application handles user input and exceptions gracefully, ensuring a smooth user experience.
class ProductInventory
{
    private List<Product> products = new List<Product>();

    public void Run()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\nTo enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
                string choice = Console.ReadLine()?.ToUpper() ?? "";

                switch (choice)
                {
                    case "P":
                        AddProduct();
                        break;
                    case "S":
                        DisplayAllProducts();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please enter P, S, or Q.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    //Add a new product to the inventory by prompting the user for the product name, category, and price.
    private void AddProduct()
    {
        Console.Write("Enter a Product Name: ");
        string name = Console.ReadLine()?? string.Empty;

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        Console.Write("Enter Category: ");
        string category = Console.ReadLine() ?? "Uncategorized";

        Console.Write("Enter Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            throw new FormatException("Price must be a valid number.");

        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");

        products.Add(new Product(name, category, price));
        Console.WriteLine("Product added successfully.");
    }
    //Display all products in the inventory, sorted by price from lowest to highest, using LINQ for sorting.
    private void DisplayAllProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        // LINQ: Sort by price (lowest to highest)
        var sortedProducts = products.OrderBy(p => p.Price).ToList();

        Console.WriteLine("\n------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Category");
        Console.ResetColor();
        Console.Write(" ".PadRight(15));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Product");
        Console.ResetColor();
        Console.Write(" ".PadRight(15));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Price");
        Console.ResetColor();
        // Display each product with category, name, and price, using different colors for better readability.
        foreach (var p in sortedProducts)
        {
            Console.Write(p.Category.PadRight(20));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(p.Name.PadRight(20));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(p.Price);
            Console.ResetColor();
        }

        Console.WriteLine("------------------------------------------------------------");
    }
}
//Define a Product class with properties for Name, Category, and Price,
//along with a constructor to initialize these properties.
class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public Product(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}