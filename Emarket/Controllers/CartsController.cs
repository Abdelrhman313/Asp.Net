using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emarket.Context;
using Emarket.Models;

namespace Emarket.Controllers
{
    public class CartsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            var cart = db.Cart.ToList();
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {/*
            var product = db.Product.ToList();

            Cart cart = new Cart
            {
                Product = product
            };

            return View(product);
        */
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            var productId = id;
            CultureInfo ci = CultureInfo.InvariantCulture;
            var added_time = DateTime.ParseExact("12/25/2008", "MM/dd/yyyy",ci); ;

            Cart cart = new Cart
            {
                ProductId = productId,
                added_at = added_time
            };

            if (ModelState.IsValid)
            {
                db.Cart.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index","Product");
            }
            return View(cart);
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var product = db.Product.Find(id);
                var cart = db.Cart.SingleOrDefault(a => a.ProductId == product.ProductId);
                db.Cart.Remove(cart);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
