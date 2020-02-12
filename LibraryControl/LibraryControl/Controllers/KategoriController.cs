using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryControl.Models.Entity;

namespace LibraryControl.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DBKUTUPHANEEntities dbKategori = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKategori.TBLKATEGORI.ToList();
            return View(values);
        }

        // Ekleme İslemleri
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TBLKATEGORI ctg)
        {
            dbKategori.TBLKATEGORI.Add(ctg);
            dbKategori.SaveChanges();
            return View();
        }

        //Silme İslemleri
        public ActionResult DeleteCategory(int id)
        {
            var values = dbKategori.TBLKATEGORI.Find(id);
            dbKategori.TBLKATEGORI.Remove(values);
            dbKategori.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var values = dbKategori.TBLKATEGORI.Find(id);
            return View("GetCategory", values);
        }

        //Güncelleme işlemleri
        public ActionResult UpdateCategory(TBLKATEGORI p)
        {
            var values = dbKategori.TBLKATEGORI.Find(p.Id);
            values.Ad = p.Ad;
            dbKategori.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}