using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetFromPoster;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet("product/{id}")]
        public Task<Product> GetProduct([FromRoute] int id)
        {            
            return GetFromPoster.GetFromPoster.GetProduct(id);
        }

       [HttpGet("products")]
        public Task<IActionResult> GetProducts()
        {            
            return GetFromPoster.GetFromPoster.GetProducts();
        }

        [HttpGet("productIds")]
        public Task<IActionResult> GetProductIds()
        {            
            return GetFromPoster.GetFromPoster.GetProducts();
        }

        // [HttpGet("products-name-id/{id}")]
        // public Task<List<Product>> GetProductsNameId([FromRoute] int id)
        // {            
        //     return GetFromPoster.GetFromPoster.GetProductsNameId(id);
        // }

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