using System;

namespace WidgetCrud
{
    class Program
    {
        static InMemWidgetDao dao = new InMemWidgetDao();


        static void Main(string[] args)
        {

            bool done = false;

            while( !done)
            {
                int choice = PrintMainMenu();
                switch(choice)
                {
                    case 1:
                        AddWidget();
                        break;
                    case 2:
                        RemoveWidgetById();
                        break;
                    case 3:
                        EditWidget();
                        break;
                    case 4:
                        GetWidgetById();
                        break;
                    case 5:
                        GetWidgetsByCat();
                        break;
                    case 6:
                        GetWidgetsByPage();
                        break;
                    case 7:
                        done = true;
                        break;
                }
            }
        }

        private static void GetWidgetsByPage()
        {
            int pageSize, pageNumber;
            Console.Write("Enter the size of the pages: ");
            int.TryParse(Console.ReadLine(), out pageSize);
            Console.Write("Enter the page number: ");
            int.TryParse(Console.ReadLine(), out pageNumber);
            var widgets = dao.GetAllWidgetsForPage(pageSize, pageNumber);
            foreach (var widget in widgets)
            {
                Console.WriteLine($"{widget.Id}, {widget.Name}, {widget.Category}, {widget.Price}");
            }
        }

        private static void GetWidgetsByCat()
        {
            Console.Write("Enter the category of the Widgets you want to retrieve: ");
            var widgets = dao.GetWidgetsByCategory(Console.ReadLine());
            foreach(var widget in widgets)
            {
                Console.WriteLine($"{widget.Id}, {widget.Name}, {widget.Category}, {widget.Price}");
            }
        }

        private static void GetWidgetById()
        {
            int id = 0;
            bool success = false;
            while(!success)
            {
                Console.Write("Enter the ID of the widget you want to retrieve: ");
                success = int.TryParse(Console.ReadLine(), out id); 
            }
            Widget widget = dao.GetWidgetById(id);
            Console.WriteLine($"Widget: {widget.Id}, {widget.Name}, {widget.Category}, {widget.Price}");
        }

        private static void EditWidget()
        {
            Console.Write("Enter the ID of the Widget you want to edit: ");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            Widget newWidget = new Widget();
            Widget oldWidget = dao.GetWidgetById(id);
            newWidget.Id = oldWidget.Id;
            Console.Write("Enter the new name for your Widget: ");
            newWidget.Name = Console.ReadLine();
            Console.Write("Enter the category for your new Widget: ");
            newWidget.Category = Console.ReadLine();
            Console.Write("Enter the price of your new Widget: ");
            decimal price;
            decimal.TryParse(Console.ReadLine(), out price);
            newWidget.Price = price;
            dao.UpdateWidget(newWidget);
        }

        private static void RemoveWidgetById()
        {
            bool success = false;
            int id = 0;
            while (!success)
            {
                Console.Write("Enter the ID of the Widget you want to remove: ");
                success = int.TryParse(Console.ReadLine(), out id);
            }
            dao.RemoveWidgetById(id);
        }

        private static void AddWidget()
        {
            Widget widget = new Widget();
            Console.Write("Enter the name for your widget: ");
            widget.Name = Console.ReadLine();
            Console.Write("Enter the category for your widget: ");
            widget.Category = Console.ReadLine();
            Console.Write("Enter the price for your widget: ");
            decimal price;
            decimal.TryParse(Console.ReadLine(), out price);
            widget.Price = price;
            int id = dao.AddWidget(widget);
            Console.WriteLine($"Widget saved with ID of {id}");
        }

        private static int PrintMainMenu()
        {
            Console.WriteLine("Widget Creation Tool Main Menu");
            Console.WriteLine("1: Add a widget");
            Console.WriteLine("2: Remove a widget");
            Console.WriteLine("3: Edit a widget");
            Console.WriteLine("4: Get widget by ID");
            Console.WriteLine("5: Get widgets by category");
            Console.WriteLine("6: Get widgets by page");
            Console.WriteLine("7: Quit");
            int choice = 0;
            bool success = false;
            while(!success)
            {
                success = int.TryParse(Console.ReadLine(), out choice);
            }
            
            return choice;
        }
    }
}
