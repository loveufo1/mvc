using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        public ActionResult List()
        {
            customerfactory x = new customerfactory();
            return View(x.getall());
        }
        public ActionResult insertcus()
        {
            //customerfactory x = new customerfactory();
            //string insertn = Request.Form["iname"];
            //string insertp = Request.Form["iphone"];
            //string inserte = Request.Form["iemail"];
            //string inserta = Request.Form["iaddress"];
            //customer y = new customer();
            //y.name = insertn;
            //y.phone = insertp;
            //y.email = inserte;
            //y.address = inserta;
            //x.Insert(y);
            return View();
        }
        [HttpPost]
        public ActionResult insertcus(customer p)
        {
            customerfactory y = new customerfactory();
            y.Insert(p);
            return RedirectToAction("List");
        }
        public ActionResult delete(int fId)
        {
            customerfactory y = new customerfactory();
            y.del(fId);
            return RedirectToAction("List");
        }
        public ActionResult edit(int fId)
        {
            customerfactory y = new customerfactory();
            
            customer x = y.getbyId(fId);
            if (x == null)
            {
               return RedirectToAction("List");
            }
            return View(x);
          
        }
        [HttpPost]
        public ActionResult edit(customer p)
        {
            if (!string.IsNullOrEmpty(p.name))
            {
                return RedirectToAction("List");
            }
            customerfactory y = new customerfactory();
            y.changes(p);
            return RedirectToAction("List");
        }
    }
}