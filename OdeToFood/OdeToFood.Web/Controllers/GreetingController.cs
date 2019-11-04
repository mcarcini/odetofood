using OdeToFood.Web.Extensions;
using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    [ActionFilter2]
    public class GreetingController : Controller
    {        
        [ActionFilter1(Order =1)]              
        [AuthorizationFilter]
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.Message = ConfigurationManager.AppSettings["message"];
            model.Name = name ?? "No name";
            return View(model);
        }
        [IsMobile]
        public ActionResult Index() {
            return View();
        }

    }
}