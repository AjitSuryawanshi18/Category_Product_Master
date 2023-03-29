using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Category_Product.Models;
using PagedList;
using PagedList.Mvc;

namespace Category_Product.Controllers
{
    public class ProductsController : Controller
    {   
       readonly private PCDbContext db = new PCDbContext();
        public ActionResult Index(int ? page)
        {
            var productsTable = db.ProductsTable.Include(p => p.Category).ToList();
           

            // trying Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var productList = db.ProductsTable.OrderBy(x => x.ProductId).ToPagedList(pageNumber, pageSize);
            return View(productList);

        }
        // trying to implement Pagintion
        //public PartialViewResult ProductListPartial(int? page)
        //{
        //    var pageNumber = page ?? 1;
        //    var pageSize = 3;
        //    var productList = db.ProductsTable.OrderByDescending(x => x.ProductId).ToPagedList(pageNumber, pageSize);
        //    return PartialView(productList);
        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CategoriesTable, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.ProductsTable.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CategoriesTable, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CategoriesTable, "CategoryId", "CategoryName", product.CategoryId );
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoriesTable, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
         public ActionResult Delete(int? id)
         {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
