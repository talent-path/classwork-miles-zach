using System;
namespace MovieRazorPage.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Title { get; set; }
        public Movie()
        {
        }
    }
}
