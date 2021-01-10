using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;
namespace MvcKutuphaneSistemi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var yzr = db.Yazarlar.ToList();
            return View(yzr);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazarlar p1)
        {
            if (ModelState.IsValid)
            {
                var yzr = db.Yazarlar.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("YazarEKle");
        }
        public ActionResult YazarSil(int id)
        {
            var yzr = db.Yazarlar.Find(id);
            db.Yazarlar.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.Yazarlar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(Yazarlar p1)
        {
            var yzr = db.Yazarlar.Find(p1.YazarID);
            yzr.YazarAD = p1.YazarAD;
            yzr.YazarSoyad = p1.YazarSoyad;
            yzr.Detay = p1.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitap(int id)
        {
            var yazar = db.Kitaplar.Where(x => x.YazarID == id).ToList();
            var yzr = db.Yazarlar.Where(x => x.YazarID == id).Select(z => z.YazarAD + " " + z.YazarSoyad).FirstOrDefault();
            ViewBag.dgr1 = yzr;
            return View(yazar);
        }
    }
}