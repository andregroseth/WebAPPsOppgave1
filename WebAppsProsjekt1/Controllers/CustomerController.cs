﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/NewCustomer
        public ActionResult NewCustomer()
        {
            var newCustomer = new Customer() { Name = "Shrek" };
            return View(newCustomer);
        }
    }
}