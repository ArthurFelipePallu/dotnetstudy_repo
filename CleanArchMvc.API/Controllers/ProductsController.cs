using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
          private readonly IProductService _productsService;
       public ProductsController(IProductService productsservice)
       {
           _productsService = productsservice;
       }

    [HttpGet]
       public async Task<ActionResult<IEnumerable<ProductDTO>>> Get() {
            var products = await _productsService.GetProducts();
            if(products ==null)
            {
                return NotFound("Categories not found");
            }
            return Ok(products);
       }
       [HttpGet("{id:int}", Name ="GetCategory") ]
       public async Task<ActionResult<ProductDTO>> Get(int id) {
            var products = await _productsService.GetById(id);
            if(products ==null)
            {
                return NotFound("Category not found");
            }
            return Ok(products);
       }
       [HttpPost]
       public async Task<ActionResult> Post([FromBody] ProductDTO productsdto) {
            
            if(productsdto == null)
            {
                return BadRequest("Category Data is Invalid");
            }
            await _productsService.Add(productsdto);
            return new CreatedAtRouteResult("GetCategory",new {id = productsdto.Id},productsdto );
       }
       [HttpPut]
       public async Task<ActionResult> Put(int id,[FromBody]ProductDTO productsdto) {
            
            if(id != productsdto.Id)
            {
                return BadRequest();
            }
            if(productsdto ==  null)
            {
                return BadRequest();
            }
            await _productsService.Update(productsdto);
            return Ok(productsdto);
       }
       [HttpDelete("{id:int}")]
       public async Task<ActionResult<ProductDTO>> Delete(int id) {
            
            var product = await _productsService.GetById(id);
            if(product == null)
                return NotFound("Category not found");
            await _productsService.Remove(id);
            return Ok(product);
       }
    }
}