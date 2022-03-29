using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_api.Core;
using mobile_api.Data;
using mobile_api.Model;

namespace mobile_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext context;
        private  readonly IMapper mapper;
        public ProductController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        
        [HttpGet]
        public  async Task <IActionResult> Get()
        {
            return Ok(await context.products.ToListAsync());
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> Get (int id)
        {
            var product = await context.products.SingleOrDefaultAsync(x => x.ID == id);
            if(product == null){
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product){

            if(await context.products.AnyAsync(x => x.Name == product.Name && x.Price == product.Price)){

                ModelState.AddModelError("name", "Same Product Name and Price alreeady exist");
                ModelState.AddModelError("price", "Same Product Name and Price alreeady exist");
                return ValidationProblem();
            }

            context.products.Add(product);
            var result = await context.SaveChangesAsync() > 0;
            if(!result){
                return BadRequest("Failed to add new Product");
            }
            return Ok ("New Product added successfully.");
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProductDeatails ( int id, Product product){

            var _product = await context.products.FirstOrDefaultAsync(x => x.ID  == product.ID);

            if(_product == null){
                return NotFound();
            }

            if(ObjectComparer.ObjectsAreEqual(_product, product)){
                return NoContent();
            }

            mapper.Map(product, _product);

            var result  = await context.SaveChangesAsync() > 0;

            if (!result){
                return BadRequest("Failed to update product details.");
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id){

            var _product = await context.products.FirstOrDefaultAsync(x => x.ID  == id);

            if(_product == null){
                return NotFound();
            }
            context.products.Remove(_product);
            var result = await context.SaveChangesAsync() > 0;

            if(!result) return BadRequest("Falied to delete product item");
            return NoContent();
        }








    }

}