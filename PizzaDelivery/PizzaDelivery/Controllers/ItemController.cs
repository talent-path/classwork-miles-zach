using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using PizzaDelivery.Repos;
using PizzaDelivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Controllers
{
    [ApiController]
    [Route("/api/item")]
    public class ItemController : Controller
    {
        PizzaDeliveryService _service;
        public ItemController(PizzaDeliveryDbContext context) 
        {
            _service = new PizzaDeliveryService(context);    
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_service.GetAllItems());
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            return Ok(_service.GetItemById(id));
        }

        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            return Created("/api/item", _service.CreateItem(item));
        }

        [HttpPut]
        public IActionResult UpdateItem(Item item)
        {
            return Accepted(_service.UpdateItem(item));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            _service.DeleteItem(id);
            return NoContent();
        }
    }
}
