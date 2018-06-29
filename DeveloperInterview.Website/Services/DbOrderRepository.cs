using Dapper;
using Dapper.Contrib.Extensions;
using DeveloperInterview.Website.Models;
using DeveloperInterview.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeveloperInterview.Website.Services
{
    public class DbOrderRepository : IOrderRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<OrderViewModel> GetAllOrders()
        {
            return db.Query<OrderViewModel>("SELECT op.Id as OrderId, c.FirstName+' '+c.LastName as FullName, p.Name as ProductName, op.Quantity FROM dbo.Customer c JOIN dbo.CustomerOrder co ON c.Id = co.CustomerId JOIN dbo.OrderProduct op on co.Id = op.CustomerOrderId JOIN dbo.Product p ON op.ProductId = p.Id").ToList();
        }

        public OrderViewModel CreateNewOrder(OrderViewModel ovm)
        {
            db.Execute(@"INSERT INTO dbo.CustomerOrder VALUES(:CustomerId, GETDATE())INSERT INTO dbo.OrderProduct VALUES(@@IDENTITY, :ProductId, :Quantity, :ProductRating)", new {ovm.CustomerId, ovm.ProductId, ovm.Quantity, ovm.ProductRating });
            return ovm;
        }
    }
}