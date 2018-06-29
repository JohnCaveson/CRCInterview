using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}