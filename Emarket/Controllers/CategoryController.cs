using Emarket.Context;
using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emarket.Controllers
{
    public class CategoryController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: User
        public ActionResult Index()
        {
            var category = db.Category.ToList();

            return View(category);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var category = db.Category.SingleOrDefault(a => a.CategoryId == id);
                db.Category.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}