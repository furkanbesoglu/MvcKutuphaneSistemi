using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var hareket = db.Hareketler.Where(x => x.IslemDurum == false).ToList();
            return View(hareket);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.Uyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UyeAD + " " + x.UyeSoyad,
                                               Value = x.UyeID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from k in db.Kitaplar.Where(z => z.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = k.KitapAD,
                                               Value = k.KitapID.ToString()

                                           }).ToList();

            List<SelectListItem> deger3 = (from p in db.Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = p.PersonelAdSoyad,
                                               Value = p.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(Hareketler h)
        {
            var d1 = db.Uyeler.Where(x => x.UyeID == h.Uyeler.UyeID).FirstOrDefault();
            var d2 = db.Kitaplar.Where(k => k.KitapID == h.Kitaplar.KitapID).FirstOrDefault();
            var d3 = db.Personel.Where(p => p.PersonelID == h.Personel.PersonelID).FirstOrDefault();
            h.Uyeler = d1;
            h.Kitaplar = d2;
            h.Personel = d3;
            var hareket = db.Hareketler.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(int id)
        {
            var odn = db.Hareketler.Find(id);
            DateTime d1 = DateTime.Parse(odn.iadeTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr1 = d3.TotalDays;
            return View("Odunciade", odn);
        }
        public ActionResult OduncGuncelle(Hareketler p)
        {
            var hrkt = db.Hareketler.Find(p.HareketID);
            hrkt.UyeGetirTarih = p.UyeGetirTarih;
            hrkt.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}