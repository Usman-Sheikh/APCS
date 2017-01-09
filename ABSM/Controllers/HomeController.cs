using ABSM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ABSM.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Rates(int? CategoryID, string searchString)
        {

            var rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product);

            if (Request.IsAjaxRequest())
            {
                if (CategoryID != null)
                {
                    rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product).Where(x => x.CategoryID == CategoryID);
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    rateLists = db.RateLists.Include(r => r.Category).Include(r => r.City).Include(r => r.Product).Where(s => s.Product.Name.Contains(searchString));
                }

                return PartialView("_Rates", rateLists.ToString());
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");

            return View(rateLists.ToList());
        }


        public ActionResult Complain()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Complain(GeneralComplain complain, HttpPostedFileBase doc)
        {
            string path;
            if (doc != null)
            {

                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    path = HostingEnvironment.MapPath(Path.Combine("~/Content/Images/", filename));
                    doc.SaveAs(path);
                    complain.ImageUrl = "~/Content/Images/" + filename;
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(complain);
                }
                if (ModelState.IsValid)
                {

                    db.GeneralComplains.Add(complain);
                    db.SaveChanges();

                    return RedirectToAction("Index","Store");
                }


            }

            ModelState.AddModelError("", "Please upload image");
            return View(complain);
        }


        public ActionResult Contact()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index","Store");
            }

            return View(model);
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