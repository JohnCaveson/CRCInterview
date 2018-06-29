using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Models
{
    public class CreateNewOrderViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<CustomerOrder> CustomerOrders { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
        public List<Product> Product { get; set; }
    }
}