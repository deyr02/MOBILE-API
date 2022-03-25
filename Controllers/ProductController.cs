using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_api.Data;
using mobile_api.Model;

namespace mobile_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductControllerController : ControllerBase
    {
        private readonly DataContext context;
        public ProductControllerController(DataContext context)
        {
            this.context = context;
        }


        
        [HttpGet]
        public  ActionResult Get()
        {
            return Ok( context.products.ToList());
        }
    }

}