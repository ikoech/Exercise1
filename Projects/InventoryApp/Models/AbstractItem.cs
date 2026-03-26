using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Models;

public abstract class AbstractItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public DateTime AddedDate { get; set; }
    public bool IsArchived { get; set; }


    //Constructor used when creating a new item 
    protected AbstractItem(int id,string name, string category)
    {
        Id = id;
        Name = name;
        Category = category;
        AddedDate = DateTime.Now;
        IsArchived = false;
    }

    //Constructor used when loading an item from the database(file)
    protected AbstractItem() 
    {
        AddedDate = DateTime.Now;
        IsArchived = false;
    }
    //Implemented in the derived classes to return a string representation of the item
    public abstract override string ToString();

}
