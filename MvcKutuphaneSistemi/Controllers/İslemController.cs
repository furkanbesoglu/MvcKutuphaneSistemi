using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneSistemi.Models.Entity;

namespace MvcKutuphaneSistemi.Controllers
{
    public class İslemController : Controller
    {
        // GET: İslem
        MvcKutuphaneEntities db = new MvcKutuphaneEntities();
        public ActionResult Index()
        {
            var islem = db.Hareketler.Where(x => x.IslemDurum == true).ToList();
            return View(islem);
        }
    }
}