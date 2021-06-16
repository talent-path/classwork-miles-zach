using System;
using System.Collections.Generic;
using System.Linq;
using MovieRazorPage.Models;

namespace MovieRazorPage.Services
{
    public class MovieService
    {
        static List<Movie> _allMovies = new List<Movie>()
        {
            new Movie { Id = 1, Title = "The Godfather", Year = 1972, Director = "Francis Ford Capolla"},
            new Movie { Id = 2, Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan"},
            new Movie { Id = 3, Title = "Interstellar", Year = 2014, Director = "Christopher Nolan"},
            new Movie { Id = 4, Title = "Avengers: End Game", Year = 2019, Director = "Anthony Russo"},
            new Movie { Id = 5, Title = "Titanic", Year = 1997, Director = "James Cameron"}
        };

        internal Movie GetById(int id)
        {
            return _allMovies.Single(movie => movie.Id == id);
        }

        internal IEnumerable<Movie> GetAll()
        {
            return _allMovies;
        }

        internal void EditMovie(Movie movie)
        {
            _allMovies = _allMovies.Select(m => m.Id == movie.Id ? movie : m).ToList();
        }

        internal void AddMovie(Movie movie)
        {
            int id = _allMovies.Count + 1;
            movie.Id = id;
            _allMovies.Add(movie);
        }
    }
}
