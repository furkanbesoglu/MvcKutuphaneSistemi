using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var kullanici = (string)Session["mail"];
            var uye = db.Uyeler.FirstOrDefault(u => u.UyeMail == kullanici);
            var uyead = db.Uyeler.Where(x => x.UyeMail == kullanici).Select(u => u.UyeAD + " " + u.UyeSoyad).FirstOrDefault();
            ViewBag.dgr1 = uyead;
            return View(uye);
        }
        [HttpPost]
        public ActionResult Index2(Uyeler p)
        {
            var kullanici = (string)Session["mail"];
            var uye = db.Uyeler.FirstOrDefault(x => x.UyeMail == kullanici);
            uye.Sifre = p.Sifre;
            uye.UyeAD = p.UyeAD;
            uye.UyeSoyad = uye.UyeSoyad;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Fotograf = uye.Fotograf;
            uye.OkulAD = p.OkulAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["mail"];
            var id = db.Uyeler.Where(x => x.UyeMail == kullanici.ToString()).Select(u => u.UyeID).FirstOrDefault();
            var kitaplar = db.Hareketler.Where(x => x.UyeID == id).ToList();
            return View(kitaplar);
        }
        public ActionResult Duyurular()
        {
            var duyuruListesi = db.Duyuru.Where(x => x.DuyuruDurum == true).ToList();
            return View(duyuruListesi);
        }
        public ActionResult logOut()
        {
            Response.Cookies.Clear();

            FormsAuthentication.SignOut();

            HttpCookie c = new HttpCookie("login");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);

            Session.Clear();
 
            return RedirectToAction("GirisYap", "Login");
        }
    }
}