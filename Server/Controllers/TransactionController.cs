using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        //поставщики       
        [HttpGet("transactions")]
        public Task<IActionResult> GetTransactions()
        {  
            DateTime timeFrom = DateTime.Now.AddDays(-1).Date;
            DateTime timeTo = DateTime.Now.Date;

            var dateTimeFromOffset = new DateTimeOffset(timeFrom);
            var unixDateTimeFrom = dateTimeFromOffset.ToUnixTimeSeconds();

            var dateTimeToOffset = new DateTimeOffset(timeTo);
            var unixDateTimeTo = dateTimeToOffset.ToUnixTimeSeconds();

            return GetFromPoster.GetFromPoster.GetTransactions(unixDateTimeFrom, unixDateTimeTo);            
        }        

       [HttpGet("transactions/{productId}")]
       public Task<IActionResult> GetProductInTransaction([FromRoute] int productId)
        {  
            DateTime timeFrom = DateTime.Now.AddDays(-1).Date;
            DateTime timeTo = DateTime.Now.Date;

            var dateTimeFromOffset = new DateTimeOffset(timeFrom);
            var unixDateTimeFrom = dateTimeFromOffset.ToUnixTimeSeconds();

            var dateTimeToOffset = new DateTimeOffset(timeTo);
            var unixDateTimeTo = dateTimeToOffset.ToUnixTimeSeconds();

            var transactions = GetFromPoster.GetFromPoster.GetTransactions(unixDateTimeFrom, unixDateTimeTo); 

            return GetProductInTransaction(transactions);            
        }
    }
}