using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(viewmodel.loginuser p)
        {

            customer c = (new customerfactory()).getbyemail(p.txtAcount);
            if(c != null)
            {
                if (c.password.Equals(p.txtPassword))
                {
                    Session[CDictionary.SK_LOGININ] = c.name;
                    return RedirectToAction("Home");
                }
            }
            return RedirectToAction("login");
        }
        public ActionResult Home()
        {
            if (Session[CDictionary.SK_LOGININ] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
    }
}