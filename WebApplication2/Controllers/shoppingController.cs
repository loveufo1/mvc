using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class shoppingController : Controller
    {
        dbdemoEntities1 db = new dbdemoEntities1();
        // GET: shopping
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            
            var n = from m in db.tProject
                    select m;
            return View(n);
        }
        public ActionResult add(int id)
        {
            var n = from m in db.tProject
                    where m.fid == id
                    select m;
            var x = n.FirstOrDefault();
            if (x == null)
            {
                return RedirectToAction("shopping");
            }
            return View(x);
        }
        
        [HttpPost]
        public ActionResult add(tShoppingCar item)
        {
            int prodID = Convert.ToInt32(item.fProduct);
            tProject t = db.tProject.FirstOrDefault(p => p.fid == prodID);
            if (t != null)
            {
                item.fDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                item.fCustomer = "cthulu";
                item.fPrice = t.fprice;
                db.tShoppingCar.Add(item);
                db.SaveChanges();
            }
            
            return RedirectToAction("List");
        }
        public ActionResult car()
        {
            var n = from m in db.tShoppingCar
                    select m;
            return View(n);
        }
        public ActionResult addsession(int id)
        {
            var n = from m in db.tProject
                    where m.fid == id
                    select m;
            var x = n.FirstOrDefault();
            if (x == null)
            {
                return RedirectToAction("shopping");
            }
            return View(x);
        }

        [HttpPost]
        public ActionResult addsession(tShoppingCar item)
        {
            int prodID = Convert.ToInt32(item.fProduct);
            tProject t = db.tProject.FirstOrDefault(p => p.fid == prodID);
            if (t != null)
            {
                List<CShoppingCartItem> list = (List<CShoppingCartItem>)Session[CDictionary.SK_PURCHASED_IN_SHOPPINGCART];
                if(list == null)
                {
                    list = new List<CShoppingCartItem>();
                    Session[CDictionary.SK_PURCHASED_IN_SHOPPINGCART] = list;

                }
                CShoppingCartItem x = new CShoppingCartItem();
                x.price = Convert.ToDouble(t.fprice);
                x.productID = t.fid;
                x.productname = t.fname;
                x.count = (int)item.fCount;
                list.Add(x);
            }

            return RedirectToAction("List");
        }
        public ActionResult sessioncar()
        {
            List<CShoppingCartItem> list = Session[CDictionary.SK_PURCHASED_IN_SHOPPINGCART] as List<CShoppingCartItem>;
            if(list == null)
                return RedirectToAction("List");
            return View(list);
        }
    }
}