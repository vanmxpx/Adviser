using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;

namespace GetFromPoster
{
    public class GetFromPoster
    {
        static HttpClient client = new HttpClient();
        //получить поставщики
        public static async Task<IActionResult> GetSuppliersAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSuppliers?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }

        //ингредиенты в поставке
        public static async Task<IActionResult> GetSupplyIngredientsAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSupplyIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788&supply_id=" + id
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }
        //получить поставки
        public static async Task<List<Supply>> GetSuppliesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSupplies?format=json&token=003643154d8e4a5e7e2d65389376a788&dateFrom=20100101"
            );
            response.EnsureSuccessStatusCode();
            var resString = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Response<List<Supply>>>(resString);
            return res.response;
        }

        // списания 
        public static async Task<List<Waste>> GetWastesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getWastes?format=json&token=003643154d8e4a5e7e2d65389376a788&dateFrom=20100101"
            );
            response.EnsureSuccessStatusCode();
            var resString = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Response<List<Waste>>>(resString);
            return res.response;
        }

        // списания 
        public static async Task<List<double>> GetSalesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/dash.getAnalytics?format=json&token=003643154d8e4a5e7e2d65389376a788&dateFrom=20100101&select=profit&interpolate=week"
            );
            response.EnsureSuccessStatusCode();
            var resString = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Response<StatData>>(resString);
            return res.response.data;
        }

        public static async Task<List<double>> GetSalesByProdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync(
                 $"https://hackathon.joinposter.com/api/dash.getAnalytics?token=003643154d8e4a5e7e2d65389376a788&dateFrom=20120101&type=products&id={id}&select=profit&interpolate=day"
            );
            response.EnsureSuccessStatusCode();
            var resString = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Response<StatData>>(resString);
            return res.response.data;
        }

        public static async Task<WasteDetails> GetWasteDetailsAsync(int wasteId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getWaste?format=json&token=003643154d8e4a5e7e2d65389376a788&waste_id="+wasteId.ToString()
            );
            response.EnsureSuccessStatusCode();
            var resString = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Response<WasteDetails>>(resString);
            return res.response;
            //return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }
        //получить остатки на складе
        public static async Task<IActionResult> GetStorageLeftovers()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getStorageLeftovers?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }

        //ручныие списания
        public static async Task<IActionResult> GetIngredientWriteOff()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getIngredientWriteOff?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }

        //МЕНЮ
        //ингредиенты
        public static async Task<IActionResult> GetIngredients()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }
        //получить ингредиент
        public static async Task<IActionResult> GetIngredient(int IngredientId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredient?format=json&token=003643154d8e4a5e7e2d65389376a788&ingredient_id=" + IngredientId
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }
        // продукты
        public static async Task<IActionResult> GetProducts()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProducts?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();
            
            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
          
        }
        // продукт
        public static async Task<IActionResult> GetProduct(int productId)
        {
            string path = @"https://hackathon.joinposter.com/api/menu.getProduct?format=json&token=003643154d8e4a5e7e2d65389376a788&product_id=" + productId;

            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProduct?format=json&token=003643154d8e4a5e7e2d65389376a788&product_id=" + productId
            );
            response.EnsureSuccessStatusCode();

            return new OkObjectResult( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync()));
        }


    }

}