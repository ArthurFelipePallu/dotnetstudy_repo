using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchMvc.WebUI.Controllers
{
    //[Route("Categories")]
    public class CategoriesController : Controller
    {
        //private readonly ILogger<CategoriesController> _logger;

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }
        // public CategoriesController(ILogger<CategoriesController> logger)
        // {
        //     _logger = logger;
        // }

        //[Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        //[Route("Create")]
        [HttpGet()]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id){
            if(id == null) return NotFound();
            var categoryDto = await _categoryService.GetById(id);
            if(categoryDto == null) return NotFound();
            return View(categoryDto);
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categorydto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categorydto);
                }
                catch(Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categorydto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id) {
            if(id==null)return NotFound();
            var categorydto = await _categoryService.GetById(id);
            if(categorydto==null) return NotFound();
            return View(categorydto);
        }
        //Não é possivel criar outra função com nome Delete e mesmos parametros 
        //precisa colocar  ActionName("Delete") para configurar o nome da action para Delete
        //Permite especificar um nome da action diferente do nome do metodo
        [HttpPost(),ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}