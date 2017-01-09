using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABSM.Models;
using System.Net.Mail;
using System.Threading.Tasks;

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


        public ActionResult Status(int? id)
        {
            if (id == null) {
                ViewBag.msg = "Select Complain";
                  }
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Status(int id, string status, string msg)
        {


            if (id !=0 && status !="" && msg !="" )
            {

                var complain= db.GeneralComplains.Where(x => x.ID == id).FirstOrDefault();
                
                var body = "<p>Complain status: {0}</p><p>Message:</p><p>{1}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(complain.Email)); //replace with valid value
                message.Subject = status;
                message.Body = string.Format(body,status, msg);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    ViewBag.msg = "Email Sent";
                    return View();
                }
            }
            ViewBag.msg = "Select Status and add description";
            return View();
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
