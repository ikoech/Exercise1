using InventoryApp.Data;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using InventoryApp.Models;
using InventoryApp.Data;

namespace InventoryApp.Services;

public class InventoryManager : IStorable
{

    private List<InventoryItem> items = new List<InventoryItem>();
    private readonly string filePath = "inventory.txt";
    private int nextId = 1;

    // Adds a new item
    public void AddItem(string name, int quantity, string category)
    {
        var item = new InventoryItem(nextId++, name, quantity, category);
        items.Add(item);
    }

    //Returns a list of all items
    public IEnumerable<AbstractItem> GetAllItems()
    {
        return items;
    }

    //Sorts items by date added, with the most recent items first
    public IEnumerable<AbstractItem> GetItemsSortedByDate()
    {
        return items.OrderByDescending(i => i.AddedDate);
    }


    // Sorts items by category, then by name within each category
    public IEnumerable<AbstractItem> GetItemsSortedByCategory()
    {
        return items.OrderBy(i => i.Category);
        // Sorts items by category, then by name within each category
        // return items.OrderBy(i => i.Category).ThenBy(i => i.Name);

    }

    //Edits an existing item by its ID
    /* Need to come back to this method and add error handling for when the item is not found. */
    public void EditItem(int id, string newName, int newQuantity, string newCategory)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.Name = newName;
            item.Quantity = newQuantity;
            item.Category = newCategory;
        }
        else
        {
            Console.WriteLine("Item not found");
            return;
        }
    }

    //Archives an item by its ID, marking it as archived without removing it from the list
    public void ArchiveItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.IsArchived = true;
        }
        else
        {
            Console.WriteLine("Item not found");
            return;
        }
    }


    // Delete an item by its ID, removing it from the list entirely
    public void DeleteItem(int id)
    {
        int removed = items.RemoveAll(i => i.Id == id);

        if (removed == 0)
            Console.WriteLine("Item not found.");
        else
            Console.WriteLine("Item deleted.");
    }

    // Saves the current inventory to a file, with each item on a new line in the format: Id,Name,Quantity,Category,AddedDate,IsArchived
    public void SaveToFile()
    {
       List<string> lines = new List<string>();
        foreach (var item in items)
        {
            string line = $"{item.Id},{item.Name},{item.Quantity},{item.Category},{item.AddedDate},{item.IsArchived}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public void LoadFromFile()
    {
        if (File.Exists(filePath))
            return;
        string[] lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            
            var item = new InventoryItem
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Quantity = int.Parse(parts[2]),
                Category = parts[3],
                AddedDate = DateTime.Parse(parts[4]),
                IsArchived = bool.Parse(parts[5])
            };
            items.Add(item);
        }
        if(items.Count > 0)
            nextId = items.Max(i => i.Id) + 1;
    }

}