using CleanArchMvc.Domain.Account;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
       public CategoriesController(ICategoryService categoryservice)
       {
           _categoryService = categoryservice;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get() {
            var categories = await _categoryService.GetCategories();
            if(categories ==null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
       }
       [HttpGet("{id:int}", Name ="GetProduct") ]
       public async Task<ActionResult<CategoryDTO>> Get(int id) {
            var category = await _categoryService.GetById(id);
            if(category ==null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
       }
       [HttpPost]
       public async Task<ActionResult> Post([FromBody] CategoryDTO categorydto) {
            
            if(categorydto == null)
            {
                return BadRequest("Category Data is Invalid");
            }
            await _categoryService.Add(categorydto);
            return new CreatedAtRouteResult("GetProduct",new {id = categorydto.Id},categorydto );
       }
       [HttpPut]
       public async Task<ActionResult> Put(int id,[FromBody]CategoryDTO category) {
            
            if(id != category.Id)
            {
                return BadRequest();
            }
            if(category ==  null)
            {
                return BadRequest();
            }
            await _categoryService.Update(category);
            return Ok(category);
       }
       [HttpDelete("{id:int}")]
       public async Task<ActionResult<CategoryDTO>> Delete(int id) {
            
            var category = await _categoryService.GetById(id);
            if(category == null)
                return NotFound("Category not found");
            await _categoryService.Remove(id);
            return Ok(category);
       }
    }
}