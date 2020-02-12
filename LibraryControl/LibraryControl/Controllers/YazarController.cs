using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryControl.Models.Entity;

namespace LibraryControl.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.TBLYAZAR.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(TBLYAZAR ctg)
        {
            db.TBLYAZAR.Add(ctg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Silme İşlemleri
        public ActionResult DeleteCategory(int id)
        {
            var values = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAuthor(int id)
        {
            var values = db.TBLYAZAR.Find(id);
            return View("GetAuthor", values);
        }

        //Güncelleme işlemleri
        public ActionResult UpdateAuthor(TBLYAZAR p)
        {
            var values = db.TBLYAZAR.Find(p.Id);
            values.Ad = p.Ad;
            values.Soyad = p.Soyad;
            values.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}