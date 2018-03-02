using DemoApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDemoAppRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDemoAppRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"Failed to load orders: {ex}");
                return BadRequest("Failed to get a products");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);

                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"Failed to load orders: {ex}");
                return BadRequest("Failed to get a products");
            }
        }
    }
}
