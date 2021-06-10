using System;
using System.Collections.Generic;

namespace WidgetSales
{
    public class WidgetService
    {
        IInventoryDao _invDao;
        ISalesDao _salesDao;

        public WidgetService(IInventoryDao invDao, ISalesDao salesDao  )
        {
            _invDao = invDao;
            _salesDao = salesDao;
        }

        internal int AddNewWidgetType(WidgetInventory toAdd)
        {
            return _invDao.Add(toAdd);
        }

        internal void RemoveWidgetByName(string widgetNameToRemove)
        {
            throw new NotImplementedException();
        }

        internal WidgetInventory GetWidgetByName(string widgetToGet)
        {
            throw new NotImplementedException();
        }

        internal void EditInv(WidgetInventory edited)
        {
            throw new NotImplementedException();
        }

        internal List<WidgetInventory> GetWidgetsByCat(string widgetCategory)
        {
            throw new NotImplementedException();
        }
    }
}
