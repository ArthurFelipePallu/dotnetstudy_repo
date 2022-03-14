using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace CleanArchMvc.WebUI.Controllers
{
    //[Route("[controller]")]
    public class ProductsController : Controller
    {
       // private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(IProductService productservice,ICategoryService categoryservice)
        {
            _productService = productservice;
            _categoryService = categoryservice;
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

        [HttpGet()]
        public async Task<IActionResult> Create() 
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productdto)
        {
            if(ModelState.IsValid)
            {
                await _productService.Add(productdto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id","Name");
            }
            return View(productdto);
        }
        // [HttpGet()]
        // public async Task<IActionResult> Edit(int? id){
        //     if(id == null) return NotFound();
        //     var productdto = await _productService.GetById(id);
        //     if(productdto == null) return NotFound();
        //     return View(productdto);
        // }
        // [HttpPost()]
        // public async Task<IActionResult> Edit(ProductDTO productdto)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         try
        //         {
        //             await _productService.Update(productdto);
        //         }
        //         catch(Exception)
        //         {
        //             throw;
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(productdto);
        // }

        // [HttpGet()]
        // public async Task<IActionResult> Delete(int? id) {
        //     if(id==null)return NotFound();
        //     var productdto = await _productService.GetById(id);
        //     if(productdto==null) return NotFound();
        //     return View(productdto);
        // }
        // //Não é possivel criar outra função com nome Delete e mesmos parametros 
        // //precisa colocar  ActionName("Delete") para configurar o nome da action para Delete
        // //Permite especificar um nome da action diferente do nome do metodo
        // [HttpPost(),ActionName("Delete")]
        // public async Task<IActionResult> DeleteConfirmed(int id) {
        //     await _productService.Remove(id);
        //     return RedirectToAction("Index");
        // }

        // [HttpGet()]
        // public async Task<IActionResult> Details(int? id) {
        //     if(id == null) return NotFound();
        //     var productdto = await _productService.GetById(id);
        //     if(productdto==null) return NotFound();
        //     return View(productdto);
        // }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}