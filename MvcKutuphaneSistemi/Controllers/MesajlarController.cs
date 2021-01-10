using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();

        public ActionResult Index()
        {
            var uyemail = (string)Session["mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Alici == uyemail).ToList(); 
            return View(mesajlar);
        }
        public ActionResult GidenMesaj()
        {
            var uyemail = (string)Session["mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == uyemail).ToList(); 
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var uyemail = (string)Session["mail"].ToString();
            m.Gonderen = uyemail;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mesajlar = db.Mesajlar.Add(m);
            db.SaveChanges();
            return View();
        }
    }
}