using Emarket.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emarket.Models;
using System.Data.Entity;
using Emarket.ViewModel;

namespace Emarket.Controllers
{
    public class ProductController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Atrical
        public ActionResult Index()
        {
            var product = db.Product.Include(u => u.Category).ToList();
            return View(product);
        }

        public JsonResult GetCategoryName(string term)
        {
            List<string> allCategory;
            allCategory = db.Category.Where(x => x.CategoryName.ToLower().StartsWith(term.ToLower())).Select(y => y.CategoryName).ToList();
            return Json(allCategory, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Product> products;
            if (string.IsNullOrEmpty(searchTerm))
            {
                products = db.Product.Include(u => u.Category).ToList();
            }
            else
            {
                products = db.Product.Include(u => u.Category).Where(a => a.Category.CategoryName.ToLower().StartsWith(searchTerm.ToLower())).ToList();

            }
            return View(products);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var category = db.Category.ToList();

            ProductCategories productCategory = new ProductCategories
            {
                Category = category,
            };

            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategories productCategory, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Upload/"), pic);
                    file.SaveAs(path);
                    productCategory.Product.ProductImage = pic;
                }

                db.Product.Add(productCategory.Product);
                db.SaveChanges();

                var numOfProduct = db.Category.SingleOrDefault(u => u.CategoryId == productCategory.Product.CategoryId);
                numOfProduct.NumberOfProduct++;

                db.Entry(numOfProduct).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var product = db.Product.SingleOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                HttpNotFound();
            }

            return View(product);
        }
        public ActionResult Edit(int id)
        {

            var product = db.Product.SingleOrDefault(a => a.ProductId == id);
            if (product == null)
            {
                HttpNotFound();
            }
            var categories = db.Category.ToList();
            ProductCategories productCategories = new ProductCategories
            {
                Product = product,
                Category = categories,
            };

            return View(productCategories);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategories productCategories, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var product = db.Product.SingleOrDefault(a => a.ProductId == productCategories.Product.ProductId);
                product.ProductName = productCategories.Product.ProductName;
                product.ProductPrice = productCategories.Product.ProductPrice;
                product.ProductDesc = productCategories.Product.ProductDesc;
                product.CategoryId = productCategories.Product.CategoryId;

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Upload/"), pic);
                    file.SaveAs(path);
                    product.ProductImage = pic;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", new { id = productCategories.Product.ProductId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);
            if (product == null)
            {
                HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var product = db.Product.SingleOrDefault(c => c.ProductId == id);
                if (product == null)
                {
                    HttpNotFound();
                }
                db.Product.Remove(product);
                db.SaveChanges();

                var numOfProduct = db.Category.SingleOrDefault(u => u.CategoryId == product.CategoryId);
                numOfProduct.NumberOfProduct--;
                db.Entry(numOfProduct).State = EntityState.Modified;
                db.SaveChanges();
        }
            return RedirectToAction("Index");
        }
    }
}