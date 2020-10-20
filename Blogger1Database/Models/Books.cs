using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger1Database.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long Published { get; set; }
        public string Picture { get; set; }
    }
}
