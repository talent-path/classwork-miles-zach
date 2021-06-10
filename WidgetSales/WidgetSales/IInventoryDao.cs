using System;
using System.Collections.Generic;

namespace WidgetSales
{
    public interface IInventoryDao
    {
        int Add(WidgetInventory toAdd);

        WidgetInventory GetByName(string name);

        IEnumerable<WidgetInventory> GetByCategory(string category);

        WidgetInventory GetByWidgetId(int Id);

        void RemoveWidgetByName(string name);

        void EditWidget(WidgetInventory toEdit);

        int GetWidgetInventoryCount();
    }
}
