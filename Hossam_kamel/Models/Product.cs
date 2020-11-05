using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hossam_kamel.Models
{
    public class Product
    {
        public string name { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public category category { get; set; }
        public string brand { get; set; }
    }
}
