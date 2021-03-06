﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperInterview.Website.Models;
using DeveloperInterview.Website.Services;
using DeveloperInterview.Website.Services.Interfaces;

namespace DeveloperInterview.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.DatabaseSuccess = CanConnectToDb();
            return View(model);
        }
        
        //Load all orders obtained from the Interface to the page
        public ActionResult Orders()
        {
            IOrderRepository orderRepo = new DbOrderRepository();
            List<OrderViewModel> orders = orderRepo.GetAllOrders();
            return View(orders);
        }

        #region Get and Post for Creating a new Order
        public ActionResult CreateNewOrder()
        {
            IOrderRepository orderRepo = new DbOrderRepository();
            CreateNewOrderViewModel orders = orderRepo.GetData();
            return View(orders);
        }

        [HttpPost]
        public ActionResult CreateNewOrder(int CustomerId, int ProductId, int Quantity, int ProductRating)
        {
            if (ModelState.IsValid)
            {
                IOrderRepository orderRepo = new DbOrderRepository();
                orderRepo.CreateNewOrder(CustomerId, ProductId, Quantity, ProductRating);
                return RedirectToAction("Orders");
            }
            return View();
        }
        #endregion

        private static bool CanConnectToDb()
        {
            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                cnn.Open();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                    cnn.Close();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}