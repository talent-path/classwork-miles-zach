using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseManager
{

    //    Done

    //1. courses list all page
    //2. course detail page
    //3. course edut page

    //Need:

    //4. course delete confirmation page
    //5. teachers list all page
    //6. teacher detail page(should show all courses for the given teacher)
    //7. teacher edit page(should be able to edit which courses a teacher teaches (need to unselect any other teachers))
    //8. teacher delete confirmation pages
    //9. students list all page
    //10. student detail page(should show all courses for the given student)
    //11. student edit page(should be able to edit which courses a student is in)
    //12. student delete confirmation pages


    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
