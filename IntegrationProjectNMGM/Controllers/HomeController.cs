﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//TESTING CHANGES
namespace IntegrationProjectNMGM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int test = 1;
            string test2 = "Gabriel Chadlebois is here, again! But this time in private...";
            return View();
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