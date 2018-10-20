using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GetFromPoster
{
    class GetFromPoster
    {
        static HttpClient client = new HttpClient();

//получить поставщики
        static async Task<HttpContent> GetSuppliersAsync()
        {
           HttpResponseMessage response = await client.GetAsync(
                @"https://hackathon.joinposter.com/api/storage.getSuppliers?format=json&token=003643154d8e4a5e7e2d65389376a788"
           );
                response.EnsureSuccessStatusCode();
           
            return response.Content;           
        }

        //ингредиенты в поставке
         static async Task<HttpContent> GetSupplyIngredientsAsync()
        {
           HttpResponseMessage response = await client.GetAsync(
                @"https://hackathon.joinposter.com/api/storage.getSupplyIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788"
           );
                response.EnsureSuccessStatusCode();
           
            return response.Content;           
        }
//получить поставки
         static async Task<HttpContent> GetSuppliesAsync()
        {
           HttpResponseMessage response = await client.GetAsync(
                @"https://hackathon.joinposter.com/api/storage.getSupplies?format=json&token=003643154d8e4a5e7e2d65389376a788"
           );
                response.EnsureSuccessStatusCode();
           
            return response.Content;           
        }
//получить остатки на складе
 static async Task<HttpContent> GetStorageLeftovers()
        {
           HttpResponseMessage response = await client.GetAsync(
                @"https://hackathon.joinposter.com/api/storage.getStorageLeftovers?format=json&token=003643154d8e4a5e7e2d65389376a788"
           );
                response.EnsureSuccessStatusCode();
           
            return response.Content;           
        }

//ручныие списания
   static async Task<HttpContent> GуtIngredientWriteOff()
        {
           HttpResponseMessage response = await client.GetAsync(
                @"https://hackathon.joinposter.com/api/storage.getIngredientWriteOff?format=json&token=003643154d8e4a5e7e2d65389376a788"
           );
                response.EnsureSuccessStatusCode();
           
            return response.Content;           
        }
    }

//МЕНЮ



}
