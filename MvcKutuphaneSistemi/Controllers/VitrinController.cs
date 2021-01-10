using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;
using MvcKutuphaneSistemi.Models.Siniflarim;

namespace MvcKutuphaneSistemi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Kitaplar.ToList();
            cs.Deger2 = db.Hakkimizda.ToList();
            //var degerler = db.Kitaplar.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(iletisim i)
        {
            var degerler = db.iletisim.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}