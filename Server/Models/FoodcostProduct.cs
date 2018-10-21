using System.Collections.Generic;

namespace Server
{
    public class FoodcostProduct
    {
        public string product_name { get; set; }
        // public int price {get; set;}
        public int product_id {get; set;}
        public List<FoodcostIngridient> ingridients {get; set;}
        // public int profit {get; set;}
        // public int cost {get; set;}
    }
}