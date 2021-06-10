using System;

namespace WidgetSales
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new WidgetController(
                new WidgetService(
                    new InMemInventoryDao(),
                    new InMemSalesDao()
                    ),
                new WidgetView()
                );

            controller.Run();
        }
    }
}
