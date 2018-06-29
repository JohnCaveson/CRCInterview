using DeveloperInterview.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperInterview.Website.Services.Interfaces
{
    public interface IOrderRepository
    {
        List<OrderViewModel> GetAllOrders();
        void CreateNewOrder(int CustomerId, int ProductId, int Quantity, int ProductRating);
        CreateNewOrderViewModel GetData();
    }
}
