using System;
using System.Collections.Generic;

namespace WidgetSales
{
    public class WidgetView
    {
        public WidgetView()
        {
        }

        internal int MainMenu()
        {
            int choice = -1;
            bool valid = false;
            while( !valid)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1. Add new widget type");
                Console.WriteLine( "2. Remove widget type");
                Console.WriteLine("3. Edit widget inventory");
                Console.WriteLine("4. View widgets by category");
                Console.WriteLine("5. View widget inventory report");
                Console.WriteLine("6. Add widget sale");
                Console.WriteLine("7. Exit");
                Console.WriteLine("-----------------------------------");

                valid = int.TryParse(Console.ReadLine(), out choice);
                if (valid) valid = choice > 0 && choice < 8;
            }

            return choice;
        }

        internal WidgetInventory BuildNewWidgetType()
        {
            //todo: really implement
            return new WidgetInventory { Category = "building supplies", Name = "Lumber", StockCount = 11 };
        }

        internal string GetWidgetName()
        {
            throw new NotImplementedException();
        }

        internal WidgetInventory EditInventory(WidgetInventory currentInv)
        {
            throw new NotImplementedException();
        }

        internal string GetWidgetCategory()
        {
            throw new NotImplementedException();
        }

        internal void DisplayWidgets(List<WidgetInventory> matching)
        {
            throw new NotImplementedException();
        }

        internal void DisplayWidget(WidgetInventory singleWidget)
        {
            throw new NotImplementedException();
        }
    }
}
