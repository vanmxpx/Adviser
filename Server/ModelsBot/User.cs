using System.Collections.Generic;
using Server.Enums;
using Server.Models;

namespace Server.ModelsBot
{
    public class User
    {
        public long ChatId { get; set; }
        public List<Product> Models = new List<Product>();
        public List<Product> ModelsAll = new List<Product>();
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public UserStatus Status { get; set; }
    }
}