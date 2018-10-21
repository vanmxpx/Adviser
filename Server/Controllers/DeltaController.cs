using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;
using Server.Models.DTO;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeltaController : ControllerBase
    {

        [Produces("application/json")]
        [HttpGet("")]
        // получить поставки за последний месяц api/delta/
        public async Task<IActionResult> GetDelta()
        {  
            DeltaDTO delta = new DeltaDTO();
            // postavki 
            List<Supply> suppliers = await GetFromPoster.GetFromPoster.GetSuppliesAsync();
            long totalSuppliers = suppliers.Where(d => d.delete != 1).Sum(s => s.supply_sum);
            delta.supplies = totalSuppliers;
            // spisaniya 
            List<Waste> wastes = await GetFromPoster.GetFromPoster.GetWastesAsync();
            long totalWastes = wastes.Where(d => d.delete != 1).Sum(s => s.total_sum);
            delta.wastes = totalWastes;

            // sales

            List<double> sales = await GetFromPoster.GetFromPoster.GetSalesAsync();
            double totalSales = sales.Sum(s => s);
            delta.sales = (long)totalSales;

            delta.delta = delta.supplies - delta.wastes - delta.sales;

            return Ok(JsonConvert.SerializeObject(delta)); 
        }
        [Produces("application/json")]
        [HttpGet("byMonth")]
        // поставки по месяцу
        public Task<IActionResult> GetDeltaByMonth([FromQuery]int mounth, [FromQuery] int year)
        {   

            return GetFromPoster.GetFromPoster.GetProducts(); 
        }

        [Produces("application/json")]
        [HttpGet("prodProfit")]
        // получить профит по продукту  api/delta/prodProfit/168
        public async Task<IActionResult> GetProdProfit([FromQuery] int id)
        {  
            List<double> sales = await GetFromPoster.GetFromPoster.GetSalesByProdAsync(id);
            List<double> totalSales = new List<double>();
           for(int i = 0; i < sales.Count; i++ )
           {
               if(sales[i] != 0 ) 
               {
                   totalSales.Add(sales[i]);
               }
           }

            return Ok(JsonConvert.SerializeObject(totalSales)); 
        }
    }
}