// "product_name":"Стейк из сёмги",
//       "modificator_name":null,
//       "product_id":"168",
//       "modification_id":"0",
//       "delete":"0",
//       "left":"43",
//       "right":"44",
//       "category_id":"33",
//       "count":"171.0000",
//       "weight_flag":"0",
//       "payed_sum":"7650000",
//       "product_sum":"7695000",
//       "bonus_sum":"0",
//       "cert_sum":"45000",
//       "product_profit":"7199716",
//       "tax_sum":"72000",
//       "vat_sum":"0",
//       "unit":"p",
//       "discount":45000

namespace Server.Models
{
    public class ProductSale
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public double count { get; set; }
        public long payed_sum { get; set; }
        public long discount { get; set; }
    }
}