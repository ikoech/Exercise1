using InventoryConsoleApp.Data;
using InventoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InventoryApp.Services;

public class InventoryManager : IStorable
{
    private List<InventoryItem> items = new List<InventoryItem>();
    private readonly string filePath = "inventory.json";
    private int nextId = 1;

    public void AddItem(string name, int quantity, string category)
    {
        var item = new InventoryItem(nextId++, name, quantity, category);
        items.Add(item);
    }
    //Get all items
    public IEnumerable<AbstractItem> GetAll()
    {
        return items;
    }

    public IEnumerable<AbstractItem> GetSortedByDate()
    {
        return items.OrderBy(i => i.AddedDate);
    }

    public IEnumerable<AbstractItem> GetSortedByCategory()
    {
        return items.OrderBy(i => i.Category);
    }

    public void EditItem(int id, string newName, int newQty, string newCategory)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        item.Name = newName;
        item.Quantity = newQty;
        item.Category = newCategory;
    }

    public void ArchiveItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        item.Archive();
    }

    public void DeleteItem(int id)
    {
        var removed = items.RemoveAll(i => i.Id == id);
        if (removed == 0)
        {
            Console.WriteLine("Item not found.");
        }
    }

    public void SaveToFile()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(items, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filePath))
            return;

        string json = File.ReadAllText(filePath);
        var loadedItems = JsonSerializer.Deserialize<List<InventoryItem>>(json);

        if (loadedItems != null)
        {
            items = loadedItems;
            if (items.Count > 0)
            {
                nextId = items.Max(i => i.Id) + 1;
            }
        }
    }
}