using System;
using System.Linq;
using System.Collections.Generic;

namespace WidgetSales
{
    public class InMemInventoryDao : IInventoryDao
    {
        List<WidgetInventory> _allInventories = new List<WidgetInventory>();

        public InMemInventoryDao()
        {
        }

        public int Add(WidgetInventory toAdd)
        {
            if (toAdd.Name == null || toAdd.Category == null || toAdd.StockCount < 0)
                throw new Exception();

            toAdd.Id = _allInventories.Count + 1;
            _allInventories.Add(new WidgetInventory(toAdd));

            return toAdd.Id;
        }

        public void EditWidget(WidgetInventory toEdit)
        {
            _allInventories = _allInventories.Select(w => w.Id == toEdit.Id ? toEdit : w).ToList();
        }

        public IEnumerable<WidgetInventory> GetByCategory(string category)
        {
            IEnumerable<WidgetInventory> toReturn = _allInventories.Where(w => w.Category == category);
            return toReturn;
        }

        public WidgetInventory GetByName(string name)
        {
            try
            {
                return _allInventories.Single(w => w.Name == name);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public WidgetInventory GetByWidgetId(int Id)
        {
            return _allInventories.Single(w => w.Id == Id);
        }

        public int GetWidgetInventoryCount()
        {
            return _allInventories.Count();
        }

        public void RemoveWidgetByName(string name)
        {
            _allInventories = _allInventories.Where(w => w.Name != name).ToList();
        }

    }
}
