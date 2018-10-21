using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Server.Models
{
    public class ProductNameId
    {        
        public int product_id { get; set; }
        public string product_name {get; set;}
    }
}