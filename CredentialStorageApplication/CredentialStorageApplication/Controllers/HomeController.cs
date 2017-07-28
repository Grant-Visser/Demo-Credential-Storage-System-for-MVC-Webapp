using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CredentialStorageApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            var config = System.Web.Configuration.WebConfigurationManager.AppSettings;
            var output = config.Get("App1Password"); //Returns the value associated with the Key: "App1Password"
            ViewBag.Message = output;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}