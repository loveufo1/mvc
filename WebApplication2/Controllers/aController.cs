using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class aController : Controller
    {
        // GET: a
        public string say()
        {
            return "Hello World";
        }
        //網址後 加/controller/方法(/?參數名稱=參數)
        public string tpage(int page)
        {
            return "跳至"+page.ToString()+"頁";
        }

        public string findCustomerbyId(int? id)    //如果沒有輸入id  加?
        {
            if (id == null)
            {
                return "安安";
            }
            customer x = new customerfactory().getbyId((int)id);
            if (x == null)
            {
                return "查無資料";
            }

            return x.name + "/" + x.phone;
        }
        public ActionResult showCustomerbyId(int? id)    //如果沒有輸入id  加?
        {

            if (id == null)
            {
                return View();
            }
            customer x = new customerfactory().getbyId((int)id);
            if (x != null)
            {
                ViewBag.vid = x.id.ToString();
                ViewBag.vname = x.name;
                ViewBag.vemail = x.email;
                ViewBag.vaddress = x.address;
                ViewBag.vphone = x.phone;
            }
            return View();
        }
        public ActionResult bindCustomerbyId(int? id)    //如果沒有輸入id  加?
        {

            if (id == null)
            {
                return View();
            }
            customer x = new customerfactory().getbyId((int)id);
           

            return View(x);
        }
        public string findCustomerbykeyword(string keyword)    //如果沒有輸入id  加?
        {
            string html = "<table border='1'>";
            html += "<tr>";
            html += "<td>編號</td>";
            html += "<td>名稱</td>";
            html += "<td>電話</td>";
            html += "<td>郵件</td>";
            html += "<td>地址</td>";
            html += "</tr>";
            


            if (string.IsNullOrEmpty(keyword))
            {
                return html+="</table>";
            }
            customer[] x = new customerfactory().getbykeyword(keyword);
            if (x == null)
            {
                return "查無資料";
            }

            foreach(customer c in x)
            {
                html += "<tr>";
                html += "<td>"+c.id.ToString()+"</td>";
                html += "<td>"+c.name+"</td>";
                html += "<td>" + c.phone + "</td>";
                html += "<td>" + c.email + "</td>";
                html += "<td>" + c.address + "</td>";
                html += "</tr>";
            }
            return html + "</table>";
        }

        public string ran()
        {
           
            return (new randomnum()).lob();
        }
        public ActionResult Index()
        {
            return View();
        }
        public string inserttest()
        {
            customer x = new customer();
            x.name = "歐";
            x.phone = "0123456";
            x.email = "owo@com";
            x.address = "ooo";

            customerfactory y = new customerfactory();
            y.Insert(x);
            return "成功";

        }
        public string changetest()
        {
            customer x = new customer();
            x.id = 4;
            x.name = "幹";
            customerfactory y = new customerfactory();
            y.changes(x);
            return "ovo";
        }
        public string deltest(int id)
        {
            customerfactory x = new customerfactory();
            x.del(id);
            return "del success";
        }
        public ActionResult sumdemo()
        {
            string a = Request.Form["txta"];
            string b = Request.Form["txtb"];
            ViewBag.ans = "?";
            if (!string.IsNullOrEmpty(a))
            {
                ViewBag.ans = (Convert.ToDouble(a) + Convert.ToDouble(b)).ToString();
            }
            return View();
        }
        public ActionResult math2()
        {
            string a = Request.Form["a"];
            string b = Request.Form["b"];
            string c = Request.Form["c"];
            double i = System.Math.Sqrt(Convert.ToDouble(b) * Convert.ToDouble(b) - (4 * Convert.ToDouble(c) * Convert.ToDouble(a)));
            
            ViewBag.x1 = (-Convert.ToDouble(b) + i) / 2*(Convert.ToDouble(a));
            ViewBag.x2 = (-Convert.ToDouble(b) - i) / 2 * (Convert.ToDouble(a));
            return View();
        }
        static int c = 0;
        public ActionResult count()
        {                     
            c++;
            ViewBag.x = c;
            return View();
        }
        public ActionResult sessiondemo()
        {
            int c1 = 0;
            if (Session["kk"] != null)
            {
                c1 = Convert.ToInt16(Session["kk"].ToString());
            }
            c1++;
            Session["kk"] = c1.ToString();
            ViewBag.x = c1;
            return View();
        }
        public ActionResult APPLICATION()
        {
            int c1 = 0;
            if (System.Web.HttpContext.Current.Application["kk"] != null)
            {
                c1 = Convert.ToInt16(System.Web.HttpContext.Current.Application["kk"].ToString());
            }
            c1++;
            System.Web.HttpContext.Current.Application["kk"] = c1.ToString();
            ViewBag.x = c1;
            return View();
        }
        public ActionResult CookieDemo()
        {
            string input = Request.Form["txtCookie"];
            if (!string.IsNullOrEmpty(input))
            {
                HttpCookie cookie = new HttpCookie("kk");  /*設定key*/
                cookie.Value = input;    //
                cookie.Expires = DateTime.Now.AddSeconds(20);
                Response.Cookies.Add(cookie);
            }
            HttpCookie readcookie = Request.Cookies["kk"];
            ViewBag.cookie = "none or overtime";
            if (readcookie != null)
            {
                ViewBag.cookie = readcookie.Value;
            }
            return View();
        }
        public ActionResult photoupdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult photoupdate(HttpPostedFileBase xxx)
            

        {
            if (xxx != null)
            {
                string name = Guid.NewGuid().ToString() + Path.GetExtension(xxx.FileName);
                var photopath = Path.Combine(Server.MapPath("~/Content"), name);
                xxx.SaveAs(photopath);
            }
            return View();
        }
    }
}