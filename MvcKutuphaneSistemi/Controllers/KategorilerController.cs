using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Kategoriler.Where(x => x.KategoriDurum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler p1)
        {
            db.Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            //BurasıSİler 
            //db.Kategoriler.Remove(kategori);
            //Burası PASif HAle getirir
            kategori.KategoriDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Kategoriler p1)
        {
            var ktg = db.Kategoriler.Find(p1.KategoriID);
            ktg.KategoriAD = p1.KategoriAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}