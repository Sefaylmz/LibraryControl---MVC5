using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryControl.Models.Entity;
namespace LibraryControl.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.TBLPERSONEL.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddPersonal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPersonal(TBLPERSONEL prs)
        {
            db.TBLPERSONEL.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePersonal(int id)
        {
            var values = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetPersonal(int id)
        {
            var values = db.TBLPERSONEL.Find(id);
            return View("GetPersonal", values);
        }
        public ActionResult UpdatePersonal(TBLPERSONEL p)
        {
            var values = db.TBLPERSONEL.Find(p.Id);
            values.AdSoyad = p.AdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}