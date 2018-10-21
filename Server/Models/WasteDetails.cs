using System.Collections.Generic;

namespace Server.Models
{
    public class WasteDetails
    {
        public int waste_id { get; set; }
        public int user_id { get; set; }
        public int storage_id { get; set; }
        public System.DateTime date { get; set; }
        public long total_sum { get; set; }
        public int reason_id { get; set; }
        public string reason_name { get; set; }
        public List<Element> elements { get; set; }
    }
}