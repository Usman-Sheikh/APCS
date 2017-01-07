using ABSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABSM.Controllers
{
    public class ComplainController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complain
        public ActionResult Index(int id)
        {
            var product = db.Products.Include("Shop").Where(x => x.ProductID == id).FirstOrDefault();
            var complain = new PriceComplain
            {
                ProductID=product.ProductID,
                Product=product,
                Shop=product.Shop,
                ShopID=product.ShopID,
               
            };
            return View(complain);
        }

        [HttpPost]
        public ActionResult Index(PriceComplain model)
        {
            if (ModelState.IsValid) {
                db.PriceComplains.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Store");
              }

            return View(model);
        }

        }
}