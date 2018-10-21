using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Product
{
    public class Product
    {        
        public int Id { get; set; }
        public string ProductName {get; set;}        
    }
}