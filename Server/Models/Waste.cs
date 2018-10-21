namespace Server.Models
{
    public class Waste
    {
        public int waste_id { get; set; }
        public int user_id { get; set; }
        public int storage_id { get; set; }
        public System.DateTime date { get; set; }
        public long total_sum { get; set; }
        public int reason_id { get; set; }
        public string reason_name { get; set; }
        public string supplier_name { get; set; }
        public int delete { get; set; }
    }
}