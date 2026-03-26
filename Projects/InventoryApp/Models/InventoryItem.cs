using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Models;

// Represents an item in the inventory, inheriting from AbstractItem
public class InventoryItem : AbstractItem
{
 
    public int Quantity { get; set; }  

    public InventoryItem(int id, string name, int quantity, string category)
           : base(id, name, category)
    {
        Quantity = quantity;
    }

     public InventoryItem() : base()
     {
     }
    // Returns a string representation of the inventory item, including its ID, name, quantity, category, added date, and archived status
    public override string ToString()
     {
        return $"{Id}. {Name} | Qty: {Quantity} | {Category} | Added: {AddedDate:yyyy-MM-dd} | Archived: {IsArchived}";
     }
}
