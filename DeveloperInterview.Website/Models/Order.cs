using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}