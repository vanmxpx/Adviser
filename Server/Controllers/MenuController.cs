using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetFromPoster;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet("product/{id}")]
        public Task<IActionResult> GetProduct([FromRoute] int id)
        {            
            return GetFromPoster.GetFromPoster.GetProduct(id);
        }

        [HttpGet("products")]
        public Task<IActionResult> GetProducts()
        {            
            return GetFromPoster.GetFromPoster.GetProducts();
        }

        [HttpGet("productsNameId")]
        public Task<IActionResult> GetProductsNameId()
        {            
            return GetFromPoster.GetFromPoster.GetProductsNameId();
        }

        [HttpGet("ingredient/{id}")]
        public Task<IActionResult> GetIngredient([FromRoute] int id)
        {            
            return GetFromPoster.GetFromPoster.GetIngredient(id);
        }

        [HttpGet("ingredients")]
        public Task<IActionResult> GetIngredients()
        {            
            return GetFromPoster.GetFromPoster.GetIngredients();
        }
        
    }
}