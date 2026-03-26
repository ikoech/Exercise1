using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp.Data;

public interface IStorable
{
    void SaveToFile();
    void LoadFromFile();
}
