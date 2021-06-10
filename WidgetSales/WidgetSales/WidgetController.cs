using System;
using System.Collections.Generic;

namespace WidgetSales
{
    public class WidgetController
    {
        WidgetView _view;
        WidgetService _service;

        public WidgetController( WidgetService service, WidgetView view )
        {
            _service = service;
            _view = view;

        }

        public void Run()
        {
            bool done = false;

            while( !done)
            {
                int userChoice = _view.MainMenu();
                switch( userChoice)
                {
                    //1. Add new widget type (with inventory)
                    case 1:
                        WidgetInventory toAdd = _view.BuildNewWidgetType();
                        int id = _service.AddNewWidgetType(toAdd);
                        Console.WriteLine("added id: " + id);
                        break;
                    //2. Remove widget type
                    case 2:
                        string widgetNameToRemove = _view.GetWidgetName();
                        _service.RemoveWidgetByName(widgetNameToRemove);
                        break;
                    //3. Edit widget inventory
                    case 3:
                        string widgetToGet = _view.GetWidgetName();
                        WidgetInventory currentInv = _service.GetWidgetByName(widgetToGet);
                        WidgetInventory edited = _view.EditInventory(currentInv);
                        _service.EditInv(edited);
                        break;
                    //4. View all widgets by category
                    case 4:
                        string widgetCategory = _view.GetWidgetCategory();
                        List<WidgetInventory> matching = _service.GetWidgetsByCat(widgetCategory);
                        _view.DisplayWidgets(matching);
                        break;
                    //5. View single widget report (by name)
                    case 5:
                        string widgetName = _view.GetWidgetName();
                        WidgetInventory singleWidget = _service.GetWidgetByName(widgetName);
                        _view.DisplayWidget(singleWidget);
                        break;
                    //6. Add widget sale
                    case 6:
                        throw new NotImplementedException();
                        break;
                    case 7:
                        done = true;
                        break;
                }
            }
        }
    }
}
