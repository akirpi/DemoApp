using DemoApp.Data;
using DemoApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{   
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IDemoAppRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDemoAppRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"Failed to get products: {ex}");
                return BadRequest("Failed to get a products");
            }
        }
    }
}
