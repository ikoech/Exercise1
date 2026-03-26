using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Data;

//Interface to mark classes that can be saving and loading in the database (file)
public interface IStorable
{
    void SaveToFile();
    void LoadFromFile();
}
