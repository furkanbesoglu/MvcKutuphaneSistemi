using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphaneSistemi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var uye = db.Uyeler.ToList();
            var uye = db.Uyeler.ToList().ToPagedList(sayfa, 10);
            return View(uye);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uyeler u)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            var uye = db.Uyeler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(Uyeler u)
        {
            var uye = db.Uyeler.Find(u.UyeID);
            uye.UyeAD = u.UyeAD;
            uye.UyeSoyad = u.UyeSoyad;
            uye.UyeMail = u.UyeMail;
            uye.KullaniciAdi = u.KullaniciAdi;
            uye.Sifre = u.Sifre;
            uye.Fotograf = u.Fotograf;
            uye.Telefon = u.Telefon;
            uye.OkulAD = u.OkulAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGecmis(int id)
        {
            var gecmis = db.Hareketler.Where(x => x.UyeID == id).ToList();
            var uye = db.Uyeler.Where(x => x.UyeID == id).Select(z => z.UyeAD + " " + z.UyeSoyad).FirstOrDefault();
            ViewBag.dgr1 = uye;
            return View(gecmis);
        }
    }
}