using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryControl.Models.Entity;
namespace LibraryControl.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var books = from k in db.TBLKITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(x => x.Ad.Contains(p));
            }
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> valueCategories = (from i in db.TBLKATEGORI.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Ad,
                                                      Value = i.Id.ToString()
                                                  }).ToList();
            ViewBag.val1 = valueCategories;

            List<SelectListItem> valueAuthors = (from i in db.TBLYAZAR.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Ad + ' ' + i.Soyad,
                                                      
                                                      Value = i.Id.ToString()
                                                  }).ToList();
            ViewBag.val2 = valueAuthors;
            return View();
        }

        [HttpPost]        
        public ActionResult AddBook(TBLKITAP b)
        {
            var ctg = db.TBLKATEGORI.Where(c => c.Id == b.TBLKATEGORI.Id).FirstOrDefault();
            var auth = db.TBLYAZAR.Where(a => a.Id == b.TBLYAZAR.Id).FirstOrDefault();
            
            b.TBLKATEGORI = ctg;
            b.TBLYAZAR = auth;
            db.TBLKITAP.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var values = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            List<SelectListItem> valueCategories = (from i in db.TBLKATEGORI.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.Ad,
                                                        Value = i.Id.ToString()
                                                    }).ToList();
            ViewBag.val1 = valueCategories;

            List<SelectListItem> valueAuthors = (from i in db.TBLYAZAR.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.Ad + ' ' + i.Soyad,

                                                     Value = i.Id.ToString()
                                                 }).ToList();
            ViewBag.val2 = valueAuthors;
            var values = db.TBLKITAP.Find(id);
            return View("GetBook", values);
        }

        public ActionResult UpdateBook(TBLKITAP b)
        {
            var values = db.TBLKITAP.Find(b.Id);
            values.Ad = b.Ad;
            
            values.BASIMYIL = b.BASIMYIL;
            values.YAYINEVI = b.YAYINEVI;
            values.SAYFA = b.SAYFA;
            values.DURUM = b.DURUM;
            var ctg = db.TBLKATEGORI.Where(c => c.Id == b.TBLKATEGORI.Id).FirstOrDefault();
            var auth = db.TBLYAZAR.Where(a => a.Id == b.TBLYAZAR.Id).FirstOrDefault();

            values.KATEGORI = ctg.Id;
            values.YAZAR = auth.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}