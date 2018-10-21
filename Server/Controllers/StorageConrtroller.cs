using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using GetFromPoster;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        //поставщики       
        [HttpGet("suppliers")]
        public Task<IActionResult> GetSuppliers()
        {            
            return GetFromPoster.GetFromPoster.GetSuppliersAsync();            
        }
        //ингредиенты в поставках
        [HttpGet("supply-ingredients/{id}")]
        public Task<IActionResult> GetSupplyIngredients([FromRoute] int id)
        {
            return GetFromPoster.GetFromPoster.GetSupplyIngredientsAsync(id);
        }
        //поставки
        [HttpGet("supplies")]
        public Task<IActionResult> GetSuppliesAsync()
        {
            return GetFromPoster.GetFromPoster.GetSuppliersAsync();
        }
        //остатки на складе        
        [HttpGet("storage-leftovers")]
        public Task<IActionResult> GetStorageLeftovers()
        {
           return GetFromPoster.GetFromPoster.GetStorageLeftovers();
        }
    }
}