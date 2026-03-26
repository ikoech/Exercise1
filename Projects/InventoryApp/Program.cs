using InventoryApp.Services;

class Program
{
    static void Main(string[] args)
    {
        var inventoryManager = new InventoryManager();
        inventoryManager.LoadFromFile();

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=====Inventory Management System=====");
            Console.WriteLine("1.Show all Item");
            Console.WriteLine("2.Show all Item sorted by date");
            Console.WriteLine("3.Show all Item sorted by category");
            Console.WriteLine("4.Add new Item");
            Console.WriteLine("5.Edit Item");
            Console.WriteLine("6.Archive Item");
            Console.WriteLine("7.Delete Item");
            Console.WriteLine("8.Save & Quit");
            Console.Write("Select an option: ");

            string? choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    ShowAllItems(inventoryManager);
                    break;  

                case "2":
                    ShowItemsSortedByDate(inventoryManager);
                    break;

                case "3":
                    ShowItemsSortedByCategory(inventoryManager);
                    break;

                case "4":   
                    AddItemsFlow(inventoryManager);
                    break ;

                case "5":
                    EditItemsFlow(inventoryManager);
                    break;
            }
        }

    }

    // Method to handle the flow of editing an existing item
    private static void EditItemsFlow(InventoryManager inventoryManager)
    {
        Console.Write("Enter the ID of the item to edit: ");
        if(!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.");
            return;
        }

        Console.Write("Enter new item Name: ");
        string? newName = Console.ReadLine();

        Console.Write("Enter new item Quantity: ");
        if(!int.TryParse(Console.ReadLine(), out int newQuantity))
        {
            Console.WriteLine("Invalid quantity. Please enter a valid number.");
            return;
        }

        Console.Write("Enter new item Category: ");
        string? newCategory = Console.ReadLine();
        inventoryManager.EditItem(id, newName!, newQuantity, newCategory!);

    }



    // Method to display all items in the inventory
    private static void ShowAllItems(InventoryManager inventoryManager)
    {
        Console.WriteLine("\nAll Items:");
        foreach (var item in inventoryManager.GetAllItems())
        {
            Console.WriteLine(item);
        }
    }
    // Method to display items sorted by date
    private static void ShowItemsSortedByDate(InventoryManager inventoryManager)
    {
        Console.WriteLine("\nItems Sorted by Date:");
        foreach(var item in inventoryManager.GetItemsSortedByDate())
        {
            Console.WriteLine(item);
        }
    }
    // Method to display items sorted by category
    private static void ShowItemsSortedByCategory(InventoryManager inventoryManager)
    {
        Console.WriteLine("\nItems Sorted by Category:");
        foreach(var item in inventoryManager.GetItemsSortedByCategory())
        {
            Console.WriteLine(item);
        }
    }

    // Method to handle the flow of adding a new item
    private static void AddItemsFlow(InventoryManager inventoryManager)
    {
        Console.Write("Enter item Name: ");
        string? name = Console.ReadLine();

        // Validate quantity input
        Console.Write("Enter item Quantity: ");
        if(!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity. Please enter a valid number.");
            return;
        }
        Console.Write("Enter item Category: ");
        string? category = Console.ReadLine();

        inventoryManager.AddItem(name!, quantity, category!);
        Console.WriteLine("Item added successfully!");

    }
}