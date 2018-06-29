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

        //Load all data required for orders using Dapper
        public List<OrderViewModel> GetAllOrders()
        {
            return db.Query<OrderViewModel>("SELECT op.Id as OrderId, c.FirstName+' '+c.LastName as FullName, p.Name as ProductName, op.Quantity FROM dbo.Customer c JOIN dbo.CustomerOrder co ON c.Id = co.CustomerId JOIN dbo.OrderProduct op on co.Id = op.CustomerOrderId JOIN dbo.Product p ON op.ProductId = p.Id").ToList();
        }

        //Insert the data into the database using Dapper
        public void CreateNewOrder(int CustomerId, int ProductId, int Quantity, int ProductRating)
        {
            db.Execute($"INSERT INTO dbo.CustomerOrder VALUES({CustomerId}, GETDATE())INSERT INTO dbo.OrderProduct VALUES(@@IDENTITY, {ProductId}, {Quantity}, {ProductRating})");
        }

        //Load ALL DATA from the database in their own lists using Dapper
        public CreateNewOrderViewModel GetData()
        {
            CreateNewOrderViewModel AllData = new CreateNewOrderViewModel();
            AllData.Customers = db.Query<Customer>("SELECT * FROM dbo.Customer").ToList();
            AllData.CustomerOrders = db.Query<CustomerOrder>("SELECT * FROM dbo.CustomerOrder").ToList();
            AllData.OrderProduct = db.Query<OrderProduct>("SELECT * FROM dbo.OrderProduct").ToList();
            AllData.Product = db.Query<Product>("SELECT * FROM dbo.Product").ToList();
            return AllData;
        }
    }
}