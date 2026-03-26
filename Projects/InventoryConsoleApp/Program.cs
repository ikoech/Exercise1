using System;
using InventoryApp.Services;

namespace InventoryApp;

class Program
{
    static void Main(string[] args)
    {
        var manager = new InventoryManager();
        manager.LoadFromFile();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== INVENTORY MANAGEMENT ===");
            Console.WriteLine("1. Show all items");
            Console.WriteLine("2. Show items sorted by date");
            Console.WriteLine("3. Show items sorted by category");
            Console.WriteLine("4. Add item");
            Console.WriteLine("5. Edit item");
            Console.WriteLine("6. Archive item");
            Console.WriteLine("7. Delete item");
            Console.WriteLine("8. Save & Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nAll items:");
                    foreach (var item in manager.GetAll())
                        Console.WriteLine(item);
                    break;

                case "2":
                    Console.WriteLine("\nItems sorted by date:");
                    foreach (var item in manager.GetSortedByDate())
                        Console.WriteLine(item);
                    break;

                case "3":
                    Console.WriteLine("\nItems sorted by category:");
                    foreach (var item in manager.GetSortedByCategory())
                        Console.WriteLine(item);
                    break;

                case "4":
                    AddItemFlow(manager);
                    break;

                case "5":
                    EditItemFlow(manager);
                    break;

                case "6":
                    ArchiveItemFlow(manager);
                    break;

                case "7":
                    DeleteItemFlow(manager);
                    break;

                case "8":
                    manager.SaveToFile();
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void AddItemFlow(InventoryManager manager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? "";

        manager.AddItem(name, qty, category);
        Console.WriteLine("Item added.");
    }

    static void EditItemFlow(InventoryManager manager)
    {
        Console.Write("Enter ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.Write("New name: ");
        string newName = Console.ReadLine() ?? "";

        Console.Write("New quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int newQty))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        Console.Write("New category: ");
        string newCategory = Console.ReadLine() ?? "";

        manager.EditItem(id, newName, newQty, newCategory);
    }

    static void ArchiveItemFlow(InventoryManager manager)
    {
        Console.Write("Enter ID to archive: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        manager.ArchiveItem(id);
    }

    static void DeleteItemFlow(InventoryManager manager)
    {
        Console.Write("Enter ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        manager.DeleteItem(id);
    }
}
