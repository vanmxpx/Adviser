namespace Server.Models
{
    public class Ingridient
    {
        public int ingredient_id { get; set; }
        public int write_off_id { get; set; }
        public int prepack_id { get; set; }
        // public System.DateTime date { get; set; }
        public int product_id { get; set; }
        public int weight { get; set; }
        public int unit { get; set; }
        public int cost { get; set; }
    }
}