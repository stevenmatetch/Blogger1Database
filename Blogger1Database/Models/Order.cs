using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger1Database.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }
        public int ExtraID { get; set; }
    }
}
