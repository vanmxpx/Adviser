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
        public ActionResult<string> GetSuppliers()
        {            
            return "7";
            //return GetFromPoster.GetSuppliersAsync();
        }
        //ингредиенты в поставках
        [HttpGet("supply-ingredients")]
        public void GetSupplyIngredients()
        {
            //return GetFromPoster.GetSupplyIngredientsAsync();
        }
        //поставки
        [HttpGet("supplies")]
        public void GetSuppliesAsync()
        {
            //return GetFromPoster.GetSuppliersAsync();
        }
        //остатки на складе        
        [HttpGet("storage-leftovers")]
        public void GetStorageLeftovers()
        {
           // return GetFromPoster.GetStorageLeftovers();
        }
    }
}