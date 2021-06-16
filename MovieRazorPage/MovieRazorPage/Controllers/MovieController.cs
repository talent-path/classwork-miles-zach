using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieRazorPage.Models;
using MovieRazorPage.Services;

namespace MovieRazorPage.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _service = new MovieService();

        public MovieController()
        {
        }

        [HttpGet]
        public IActionResult OneMovie(int? id)
        {
            if(id != null)
            {
                Movie movie = _service.GetById(id.Value);
                return View(movie);
            }

            return this.BadRequest();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _service.GetAll();
            return View(movies);
        }

        [HttpPost]
        public IActionResult OneMovie(Movie movie)
        {
            _service.EditMovie(movie);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            _service.AddMovie(movie);
            return this.RedirectToAction("Index");
        }
    }
}
