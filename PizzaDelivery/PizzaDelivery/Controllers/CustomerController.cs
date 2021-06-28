﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("/api/customer")]
    public class CustomerController : Controller
    {
        PizzaDeliveryService _service;

        public CustomerController(PizzaDeliveryDbContext context)
        {
            _service = new PizzaDeliveryService(context);
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_service.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_service.GetCustomerById(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            return Created("/api/customer", _service.CreateCustomer(customer));
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            return Accepted(_service.UpdateCustomer(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _service.DeleteCustomer(id);
            return NoContent();
        }
    }
}
