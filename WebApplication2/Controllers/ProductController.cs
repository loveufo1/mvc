using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        dbdemoEntities1 db = new dbdemoEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var table = from n in db.tProject
                        select n;
            return View(table);
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(tProject p)
        {

            if (p.productphoto != null)
            {
                string name = Guid.NewGuid().ToString() + Path.GetExtension(p.productphoto.FileName);
                var photopath = Path.Combine(Server.MapPath("~/Content"), name);
                p.productphoto.SaveAs(photopath);
                p.fPhoto = "../Content/" + name;
            }
            
            db.tProject.Add(p);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult edit(int id)
        {
            tProject prod = db.tProject.First(p => p.fid == id);
            if(prod == null)
                return RedirectToAction("List");

            return View(prod);
        }
        [HttpPost]
        public ActionResult edit(tProject p)
        {
            tProject prod = db.tProject.First(m => m.fid == p.fid);
            if (prod == null)
                return RedirectToAction("List");
            prod.fname=p.fname;
            prod.fprice = p.fprice;
            prod.fQty = p.fQty;
            prod.fcost = p.fcost;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult del(int id)
        {
            
            var n = from m in db.tProject
                    where m.fid == id
                    select m;
            
            var x = n.First();
            if (n != null)
            {
                db.tProject.Remove(x);
                db.SaveChanges();
            }
            
            return RedirectToAction("List");

        }
       

    }
}