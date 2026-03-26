using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp.Models;

public class InventoryItem : AbstractItem
{
    public int Quantity { get; set; }

    public InventoryItem(int id, string name, int quantity, string category)
        : base(id, name, category)
    {
        Quantity = quantity;
    }

    // Parameterless constructor for JSON deserialization
    public InventoryItem() : base(0, string.Empty, string.Empty)
    {
    }
    public override string ToString()
    {
        return $"{Id}. {Name} | Qty: {Quantity} | {Category} | Added: {AddedDate:yyyy-MM-dd} | Archived: {IsArchived}";
    }
}
