using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;
using System.Web.Security;

namespace MvcKutuphaneSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Uyeler p)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.UyeMail == p.UyeMail && x.Sifre == p.Sifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UyeMail, false);
                Session["mail"] = bilgiler.UyeMail.ToString();
                //TempData["id"] = bilgiler.UyeID.ToString();
                //TempData["Ad"] = bilgiler.UyeAD.ToString();
                //TempData["Soyad"] = bilgiler.UyeSoyad.ToString();
                //TempData["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                //TempData["Sifre"] = bilgiler.Sifre.ToString();
                //TempData["Okul"] = bilgiler.OkulAD.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}