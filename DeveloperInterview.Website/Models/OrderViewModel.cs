using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int ProductRating { get; set; }
        public int Quantity { get; set; }
    }
}