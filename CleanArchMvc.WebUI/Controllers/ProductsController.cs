using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
       // private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;
        public ProductsController(IProductService service)
        {
            _productService = service;
        }
        // public ProductsController(ILogger<ProductsController> logger)
        // {
        //     _logger = logger;
        // }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}