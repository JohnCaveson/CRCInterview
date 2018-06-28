using DeveloperInterview.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperInterview.Website.Services.Interfaces
{
    public interface IOrderInterface
    {
        List<Order> GetAllOrders();
    }
}
