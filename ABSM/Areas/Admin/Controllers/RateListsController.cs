using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABSM.Models;

namespace ABSM.Areas.Admin.Controllers
{
    public class RateListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/RateLists
        public ActionResult Index(int? CategoryID, string searchString)
        {

            var rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product);

            if (CategoryID != null)
            {
                 rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product).Where(x=>x.CategoryID==CategoryID);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                 rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product).Where(s => s.Product.Name.Contains(searchString));
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");

            return View(rateLists.ToList());
        }

        // GET: Admin/RateLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            return View(rateList);
        }

        // GET: Admin/RateLists/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // POST: Admin/RateLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RateList rateList)
        {
            if (ModelState.IsValid)
            {
                rateList.UpdatedDate = DateTime.Now;
                db.RateLists.Add(rateList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", rateList.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", rateList.CityID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", rateList.ProductID);
            return View(rateList);
        }

        // GET: Admin/RateLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", rateList.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", rateList.CityID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", rateList.ProductID);
            return View(rateList);
        }

        // POST: Admin/RateLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RateList rateList)
        {
            if (ModelState.IsValid)
            {
                rateList.UpdatedDate = DateTime.Now;
                db.Entry(rateList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", rateList.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", rateList.CityID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", rateList.ProductID);
            return View(rateList);
        }

        // GET: Admin/RateLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            return View(rateList);
        }

        // POST: Admin/RateLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateList rateList = db.RateLists.Find(id);
            db.RateLists.Remove(rateList);
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
