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
        static async Task<HttpContent> GetIngredientWriteOff()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/storage.getIngredientWriteOff?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return response.Content;
        }

        //МЕНЮ
        //ингредиенты
        static async Task<HttpContent> GetIngredients()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredients?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
        //получить ингредиент
        static async Task<HttpContent> GetIngredient(int IngredientId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getIngredient?format=json&token=003643154d8e4a5e7e2d65389376a788
                 &ingredient_id=" + IngredientId
            );
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
        // продукты
        static async Task<HttpContent> GetProducts()
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProducts?format=json&token=003643154d8e4a5e7e2d65389376a788"
            );
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
        // продукт
        static async Task<HttpContent> GetProduct(int productId)
        {
            HttpResponseMessage response = await client.GetAsync(
                 @"https://hackathon.joinposter.com/api/menu.getProduct?format=json&token=003643154d8e4a5e7e2d65389376a788
                 &product_id=" + productId
            );
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
    }

}

