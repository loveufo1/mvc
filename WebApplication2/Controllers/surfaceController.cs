using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class surfaceController : Controller
    {
        // GET: surface
        public ActionResult Index()
        {
            return View();
        }

        // GET: surface/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: surface/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: surface/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: surface/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: surface/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: surface/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: surface/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
