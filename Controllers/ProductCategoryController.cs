using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile_api.Data;
using mobile_api.Model;

namespace mobile_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ProductCategoryController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok(await context.ProductCategories.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {   
            var _product = await  context.ProductCategories.FirstOrDefaultAsync(x=> x.ID == id);

            if(_product == null){
                return NotFound();
            }
            return Ok(_product);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductCategory(ProductCategoryDTO categoryDTO)
        {
            ProductCategory _category = await context.ProductCategories.FirstOrDefaultAsync(x => x.Name.ToLower() == categoryDTO.Name.ToLower() );
            if(_category !=null){
                return  BadRequest("The prodcut Category already exist");
            }
            
            ProductCategory _productCategory = mapper.Map<ProductCategory>(categoryDTO);

             context.ProductCategories.Add(_productCategory);
             var result = await context.SaveChangesAsync() >0;
    
              if(!result){
                  return BadRequest("Failed to create Product Categoyr");
              }

              ProductCategoryDTO dto = mapper.Map<ProductCategoryDTO>(_productCategory);
        
                return CreatedAtAction(nameof(Get), new {id =_productCategory.ID}, dto);        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>EditProductCategory(int id, ProductCategoryDTO categoryDTO)
        {
            if(id != categoryDTO.ID){
                return BadRequest();
            }
            ProductCategory _productCategory = await context.ProductCategories.SingleOrDefaultAsync(x=> x.ID == categoryDTO.ID);

            if(_productCategory == null){
                return NotFound();
            }

           mapper.Map(categoryDTO, _productCategory);

            var result = await context.SaveChangesAsync() > 0;

            if(!result){
                return BadRequest("Failed to update product category.");
            }

            return NoContent();


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id){
            ProductCategory productCategory = await context.ProductCategories.FindAsync(id);

            if (productCategory == null){
                return NotFound();
            }

            context.ProductCategories.Remove(productCategory);
            var result = await context.SaveChangesAsync() > 0;

            if(!result){
                return BadRequest("Failed to delete product Category");
            }

            return NoContent();

        }


 




    }

}