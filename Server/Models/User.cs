using System.Collections.Generic;
using Server.Emuns;

namespace Server
{
    public class User
    {
        public int ChatId { get; set; }
        public List<Product> Models = new List<Product>();
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public UserStatus Status { get; set; }
    }
}