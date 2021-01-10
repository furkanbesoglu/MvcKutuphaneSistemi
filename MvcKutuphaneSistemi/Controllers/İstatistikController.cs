using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.Uyeler.Count();
            var deger2 = db.Kitaplar.Count();
            var deger3 = db.Kitaplar.Where(k => k.Durum == false).Count();
            var deger4 = db.Cezalar.Sum(c => c.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;

            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKartlar()
        {
            var deger1 = db.Kitaplar.Count();
            var deger2 = db.Uyeler.Count();
            var deger3 = db.Cezalar.Sum(c => c.Para);
            var deger4 = db.Kitaplar.Where(k => k.Durum == false).Count();
            var deger5 = db.Kategoriler.Count();
            var deger6 = db.EnAktifUye().FirstOrDefault();
            var deger7 = db.EnCokOkunanKitap().FirstOrDefault();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.Kitaplar.GroupBy(k => k.YayinEvi).OrderByDescending(x => x.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger10 = db.EnBasariliPersonel2().FirstOrDefault();
            var deger11 = db.iletisim.Count();
            var deger12 = db.BugunEmanet().FirstOrDefault();




            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;



            return View();
        }
    }
}