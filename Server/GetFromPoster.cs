using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetFromPoster
{
    class GetFromPoster
    {
        static HttpClient client = new HttpClient();

        //получить поставщики
        static async Task<string> GetSuppliersAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSuppliers?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }

        //ингредиенты в поставке
        static async Task<string> GetSupplyIngredientsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSupplyIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
        //получить поставки
        static async Task<string> GetSuppliesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getSupplies?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
        //получить остатки на складе
        static async Task<string> GetStorageLeftovers()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getStorageLeftovers?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }

        //ручныие списания
        static async Task<string> GetIngredientWriteOff()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getIngredientWriteOff?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }

        //МЕНЮ
        //ингредиенты
        static async Task<string> GetIngredients()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
        //получить ингредиент
        static async Task<string> GetIngredient(int IngredientId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredient?format=json&token=003643154d8e4a5e7e2d65389376a788
                 &ingredient_id=" + IngredientId
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
        // продукты
        static async Task<string> GetProducts()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProducts?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
        // продукт
        static async Task<string> GetProduct(int productId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProduct?format=json&token=003643154d8e4a5e7e2d65389376a788
                 &product_id=" + productId
            );
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.SerializeObject(responseBody);
        }
    }

}