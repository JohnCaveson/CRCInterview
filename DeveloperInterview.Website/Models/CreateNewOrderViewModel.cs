using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class CreateNewOrderViewModel
    {
        public List<string> Names { get; set; }
        public List<int> CustomerId { get; set; }
        public List<int> ProductId { get; set; }
        public List<string> MyProperty { get; set; }
        public int Quantity { get; set; }
    }
}