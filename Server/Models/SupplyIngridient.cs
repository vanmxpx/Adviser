namespace Server.Models
{
    public class SupplyIngridient
    {
        public int ingredient_id { get; set; }
        public double supply_ingredient_num { get; set; }
        public long supply_ingredient_sum { get; set; }
        public string ingredient_name { get; set; }
        public string ingredient_unit { get; set; }
    }
}