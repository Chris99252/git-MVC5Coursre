using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    
    public class CRUDController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        
        // GET: CRUD 
        public ActionResult Index()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("C") && p.Price.HasValue && p.Price >= 5 && p.Price <= 10);
            //var data = from p in db.Product where p.ProductName.StartsWith("C") && p.Price.HasValue && p.Price >= 5 && p.Price <= 10 select p;
            
            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            //var data = db.Product.Find(id);
            //var data = db.Product.Single(p => p.ProductId == id);
            //var data = db.Product.SingleOrDefault(p => p.ProductId == id);
            return View(data);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product prod = new Product();
                prod.ProductName = collection["ProductName"];
                prod.Price = Convert.ToDecimal(collection["Price"]);
                prod.Active = true;
                prod.Stock = Convert.ToDecimal(collection["Stock"]);

                db.Product.Add(prod);
                db.SaveChanges();
                          
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                return View();
            }
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
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

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRUD/Delete/5
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
