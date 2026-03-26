using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp.Models;

public abstract class AbstractItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category {  get; set; }= string.Empty;
    public DateTime AddedDate { get; set; }
    public bool IsArchived { get; set; }

    protected AbstractItem(int Id, string name, string category ) 
    {
        this.Id = Id;
        this.Name = name;
        this.Category = category;
        IsArchived = false;
    }
    public void Archive()
    {
        IsArchived = true;
    }

    public abstract override string ToString();

}
