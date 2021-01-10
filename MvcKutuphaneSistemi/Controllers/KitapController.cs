using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Kitaplar select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(k => k.KitapAD.Contains(p));
            }
            //var Kitaplar = db.Kitaplar.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAD,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Yazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YazarAD + ' ' + i.YazarSoyad,
                                               Value = i.YazarID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;



            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitaplar p1)
        {
            var ktg = db.Kategoriler.Where(k => k.KategoriID == p1.Kategoriler.KategoriID).FirstOrDefault();
            var yzr = db.Yazarlar.Where(y => y.YazarID == p1.Yazarlar.YazarID).FirstOrDefault();
            p1.Kategoriler = ktg;
            p1.Yazarlar = yzr;
            db.Kitaplar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktp = db.Kitaplar.Find(id);
            db.Kitaplar.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            List<SelectListItem> deger1 = (from i in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAD,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Yazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YazarAD + ' ' + i.YazarSoyad,
                                               Value = i.YazarID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            var ktp = db.Kitaplar.Find(id);
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(Kitaplar p1)
        {
            var kitap = db.Kitaplar.Find(p1.KitapID);
            kitap.KitapAD = p1.KitapAD;
            kitap.Sayfa = p1.Sayfa;
            kitap.YayinEvi = p1.YayinEvi;
            kitap.BasimYili = p1.BasimYili;
            kitap.Durum = p1.Durum;
            var ktg = db.Kategoriler.Where(k => k.KategoriID == p1.Kategoriler.KategoriID).FirstOrDefault();
            var yzr = db.Yazarlar.Where(y => y.YazarID == p1.Yazarlar.YazarID).FirstOrDefault();
            kitap.KategoriID = ktg.KategoriID;
            kitap.YazarID = yzr.YazarID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}