using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ProductRating { get; set; }
    }
}