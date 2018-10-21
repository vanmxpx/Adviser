using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeltaController : ControllerBase
    {

        [Produces("application/json")]
        [HttpGet("lastMonth")]
        // получить поставки за последний месяц api/delta/deltaLastMonth
        public async Task<IActionResult> GetDeltaLastMonth()
        {  
            // postavki 
            List<Supply> suppliers = await GetFromPoster.GetFromPoster.GetSuppliesAsync();
            long totalSuppliers = suppliers.Sum(s => s.supply_sum);
            // spisaniya 
            List<Waste> wastes = await GetFromPoster.GetFromPoster.GetWastesAsync();

            return Ok(JsonConvert.SerializeObject(suppliers)); 
        }
        [Produces("application/json")]
        [HttpGet("byMonth")]
        // поставки по месяцу
        public Task<IActionResult> GetDeltaByMonth([FromQuery]int mounth, [FromQuery] int year)
        {   

            return GetFromPoster.GetFromPoster.GetProducts(); 
        }
    }
}