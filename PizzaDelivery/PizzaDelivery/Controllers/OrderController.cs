using Microsoft.AspNetCore.Mvc;
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


    }
}
