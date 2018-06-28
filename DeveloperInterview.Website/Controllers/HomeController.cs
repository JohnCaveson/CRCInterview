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

        public ActionResult Orders()
        {
            IOrderInterface orderRepo = new DbOrderInterface();
            List<Order> orders = orderRepo.GetAllOrders();
            return View(orders);
        }

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