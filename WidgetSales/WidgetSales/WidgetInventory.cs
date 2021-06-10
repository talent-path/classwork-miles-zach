using System;
namespace WidgetSales
{
    public class WidgetInventory
    {
        public int Id { get; set; }
        public int StockCount { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }


        public WidgetInventory()
        {
        }

        public WidgetInventory(WidgetInventory that)
        {
            this.Id = that.Id;
            this.StockCount = that.StockCount;
            this.Name = that.Name;
            this.Category = that.Category;
        }

    }
}
