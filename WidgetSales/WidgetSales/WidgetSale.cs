using System;
namespace WidgetSales
{
    public class WidgetSale
    {
        public int Id { get; set; }
        //should match a widget in our widget inventory
        public string Name { get; }

        //should be >= 1
        public int Quantity { get; }

        //should be <= today
        public DateTime SaleDate { get; }
    }
}
