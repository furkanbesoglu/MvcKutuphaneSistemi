using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var dyr = db.Duyuru.ToList();
            return View(dyr);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(Duyuru d)
        {
            var degerler = db.Duyuru.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.Duyuru.Find(id);
            duyuru.DuyuruDurum = false;
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGetir(int  id)
        {
            var duyuru = db.Duyuru.Find(id);
            return View("DuyuruGetir", duyuru);
        }
        public ActionResult DuyuruGuncelle(Duyuru t)
        {
            var degerler = db.Duyuru.Find(t.DuyuruID);
            degerler.DuyuruKategori = t.DuyuruKategori;
            degerler.DuyuruIcerik = t.DuyuruIcerik;
            degerler.DuyuruTarih = t.DuyuruTarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}