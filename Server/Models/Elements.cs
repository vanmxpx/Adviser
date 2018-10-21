using System.Collections.Generic;

namespace Server.Models
{
    public class Element
    {
        public int type { get; set; }
        public int product_id { get; set; }
        public int modificator_id { get; set; }
        // public System.DateTime date { get; set; }
        public int count { get; set; }

        public List<Ingridient> ingredients { get; set; }
    }
}