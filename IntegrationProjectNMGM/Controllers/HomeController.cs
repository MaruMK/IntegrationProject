﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//TESTING CHANGES
namespace IntegrationProjectNMGM.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// This will contain localised string value
        /// </summary>
        public string LocalisedString { get; set; }

        /// <summary>
        /// For see difference of cretion time
        /// </summary>
        public DateTime CreationDateTime { get; set; }

        public ActionResult Index()
        {
            int test = 1;
            string test2 = "Gabriel Chadlebois is here, again! But this time in private...";
            int nathanTest = 0;


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


        public ActionResult Returns()
        {
            ViewBag.Message = "Our return policy:";
            return View();
        }
        
        public ActionResult CyclingSafety()
        {
            ViewBag.Message = "Cycling Safety";
            return View();
        }

        public ActionResult Careers()
        {
            ViewBag.Message = "Work for us!";
            return View();    
        }

        public ActionResult dummy()
        {
            return View();
        }


        public ActionResult ShowCart()
        {
            return PartialView("~/Views/Shared/Cart.cshtml");
        }

    }
}