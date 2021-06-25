using EFBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Controllers
{
    [ApiController]
    [Route("/user")]
    public class BlogController : Controller
    {

        BlogDbContext _context;

        public BlogController(BlogDbContext context) 
        {
            // Should instantiate a service instead
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser(BlogUser user)
        {
            _context.BlogUsers.Add(user);
            _context.SaveChanges();
            return Accepted(user.Id);
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            return Ok(_context.BlogUsers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_context.BlogUsers.Find(id));
        }

        [HttpPut]
        public IActionResult EditUser(BlogUser user)
        {
            //BlogUser currentUser = _context.BlogUsers.Find(user.Id);
            //_context.Entry(currentUser).CurrentValues.SetValues(user);
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _context.BlogUsers.Remove(new BlogUser { Id = id });
            _context.SaveChanges();
            return NoContent();
        }
    }
}
