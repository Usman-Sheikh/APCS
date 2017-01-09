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
    public class ComplainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Complains
        public ActionResult Index()
        {
            return View(db.GeneralComplains.ToList());
        }

        // GET: Admin/Complains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralComplain generalComplain = db.GeneralComplains.Find(id);
            if (generalComplain == null)
            {
                return HttpNotFound();
            }
            return View(generalComplain);
        }

       
       

    

        // GET: Admin/Complains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralComplain generalComplain = db.GeneralComplains.Find(id);
            if (generalComplain == null)
            {
                return HttpNotFound();
            }
            return View(generalComplain);
        }

        // POST: Admin/Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralComplain generalComplain = db.GeneralComplains.Find(id);
            db.GeneralComplains.Remove(generalComplain);
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
