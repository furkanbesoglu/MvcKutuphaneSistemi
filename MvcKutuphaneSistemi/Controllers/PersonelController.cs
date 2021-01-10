using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var pers = db.Personel.ToList();
            return View(pers);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            var pers = db.Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var pers = db.Personel.Find(id);
            db.Personel.Remove(pers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var pers = db.Personel.Find(id);
            return View("PersonelGetir", pers);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var pers = db.Personel.Find(p.PersonelID);
            pers.PersonelAdSoyad = p.PersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}