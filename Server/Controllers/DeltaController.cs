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
            delta.product = "All";
            delta.delta = delta.supplies - delta.wastes - delta.sales;

            return Ok(JsonConvert.SerializeObject(delta)); 
        }

        [Produces("application/json")]
        [HttpGet("prodByMonth")]
        // поставки продукта по месяцу
        public async Task<IActionResult> GetProductsDeltaByMonth([FromQuery]int month, [FromQuery] int year)
        {   
            string date = year.ToString();
            date += month < 10 ? "0" + month.ToString() : month.ToString();
            DeltaDTO delta = new DeltaDTO();
            List<DeltaDTO> deltas = new List<DeltaDTO>();
            // postavki  
            List<Supply> suppliers = await GetFromPoster.GetFromPoster.GetSuppliesByMonthAsync(date);
            List<SupplyIngridient> ingridients = new List<SupplyIngridient>();
            foreach(var supply in suppliers)
            {
                var currIngrid = await GetFromPoster.GetFromPoster.GetSupplyIngredientsAsync(supply.supply_id);
                ingridients.AddRange(currIngrid);
                foreach(var ing in currIngrid)
                {
                    var search = deltas.FirstOrDefault(s => s.product == ing.ingredient_name);
                    if(deltas.Count == 0 || search.product != ing.ingredient_name)
                    {
                        DeltaDTO currentDelta = new DeltaDTO();
                        currentDelta.product = ing.ingredient_name;
                        currentDelta.supplies += (int)(ing.supply_ingredient_num * ing.supply_ingredient_sum);
                        deltas.Add(delta);
                    }
                }  
            }

            // spisaniya 
            List<WasteDetails> wasteDetails = new List<WasteDetails>();
            List<Waste> wastes = await GetFromPoster.GetFromPoster.GetWastesByMonthAsync(date);
            long totalWastes = wastes.Where(d => d.delete != 1).Sum(s => s.total_sum);
            delta.wastes = totalWastes;
            
            // foreach(var waste in wastes)
            // {
                
            //     var details = await GetFromPoster.GetFromPoster.GetWasteDetailsAsync(waste.waste_id);
            //     foreach(var el in details.elements){
            //         foreach(var del in deltas){
            //             if(del.product == el.)
            //         }
            //     }
            // }
            // sales

            List<ProductSale> prodSales = await GetFromPoster.GetFromPoster.GetProdSalesByMonthAsync(date);
            foreach(var delt in deltas)
            {
                //GetFromPoster.GetFromPoster.Prod
                // DeltaDTO currentDelta = new DeltaDTO(); 
                // delta.product = ingrid.ingredient_name;
                // //delta.supplies = 
            }
            List<double> sales = await GetFromPoster.GetFromPoster.GetSalesByMonthAsync(date);
            double totalSales = sales.Sum(s => s);
            delta.sales = (long)totalSales;
            delta.product = "All";
            delta.delta = delta.supplies - delta.wastes - delta.sales;

            return Ok(JsonConvert.SerializeObject(delta));
        }

        [Produces("application/json")]
        [HttpGet("byMonth")]
        // поставки по месяцу
        public async Task<IActionResult> GetDeltaByMonth([FromQuery]int month, [FromQuery] int year)
        {   
            string date = year.ToString();
            date += month < 10 ? "0" + month.ToString() : month.ToString();
            DeltaDTO delta = new DeltaDTO();
            // postavki  
            List<Supply> suppliers = await GetFromPoster.GetFromPoster.GetSuppliesByMonthAsync(date);
            long totalSuppliers = suppliers.Where(d => d.delete != 1).Sum(s => s.supply_sum);
            delta.supplies = totalSuppliers;
            // spisaniya 
            List<Waste> wastes = await GetFromPoster.GetFromPoster.GetWastesByMonthAsync(date);
            long totalWastes = wastes.Where(d => d.delete != 1).Sum(s => s.total_sum);
            delta.wastes = totalWastes;
            
            // sales

            List<double> sales = await GetFromPoster.GetFromPoster.GetSalesByMonthAsync(date);
            double totalSales = sales.Sum(s => s);
            delta.sales = (long)totalSales;
            delta.product = "All";
            delta.delta = delta.supplies - delta.wastes - delta.sales;

            return Ok(JsonConvert.SerializeObject(delta));
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