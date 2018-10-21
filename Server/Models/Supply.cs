namespace Server.Models
{
    public class Supply
    {
        public int supply_id { get; set; }
        public int storage_id { get; set; }
        public int supplier_id { get; set; }
        public System.DateTime date { get; set; }
        public long supply_sum { get; set; }
        public string supply_comment { get; set; }
        public string storage_name { get; set; }
        public string supplier_name { get; set; }
        public int delete { get; set; }
        public int? account_id { get; set; }
    }
}