using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Server.Models
{
    public class Transaction
    {        
        public int transaction_id {get; set;}
        public List<Product> products {get; set;}
    }
}