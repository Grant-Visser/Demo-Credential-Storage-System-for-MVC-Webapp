using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using CredentialStorageApplication.Models.Helper_Class;

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
            
            
            PasswordManagement pm1 = PasswordManagement.getInstance();
            ViewBag.Message = pm1.getValue("App1Password");
            return View();
        }

        public ActionResult Contact()
        {
            string suspectedPassword = "TestPassword";
            PasswordManagement pm1 = PasswordManagement.getInstance();
            if (pm1.getValue("Test Password") == suspectedPassword)
            {
                ViewBag.Message = "Password was identified successfully! \"" + pm1.getValue("Test Password") + "\" = \"" + suspectedPassword + "\"";
            }
            else
            {
                ViewBag.Message = "Password is incorrect" + pm1.getValue("Test Password") + " != " + suspectedPassword;
            }
            var test = pm1.getValue("Crayons");//Intentional error
            return View();
        }
    }
}