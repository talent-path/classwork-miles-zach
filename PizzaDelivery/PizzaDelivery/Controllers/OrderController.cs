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
    [Route("/api/order")]
    public class OrderController : Controller
    {

        PizzaDeliveryService _service;

        public OrderController(PizzaDeliveryDbContext context)
        {
            _service = new PizzaDeliveryService(context);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_service.GetAllOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_service.GetOrderById(id));
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            return Created("/api/order", _service.CreateOrder(order));
        }

        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            return Accepted(_service.UpdateOrder(order));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.DeleteOrder(id);
            return NoContent();
        }
    }
}
