using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        [HttpPost]
        public ActionResult KayitOl(Uyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            var degerler = db.Uyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("KayitOl");
        }
    }
}