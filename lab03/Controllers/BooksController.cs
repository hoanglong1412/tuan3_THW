using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab03.Models;

namespace lab03.Controllers
{
    public class BooksController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // danh sách sản phẩm
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // chi tiết sản phẩm
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // giao diện khi ấn nút tạo
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

       // xác nhận tạo mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Author,title,Img,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //giao diện khi ấn nút sửa
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //xác nhận sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Author,title,Img,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // giao diện khi ấn nút xóa
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //xác nhận xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //mua sản phẩm
        [Authorize]
        public ActionResult Buy(int? id)
        {
            Book book = db.Books.SingleOrDefault(m => m.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }
}
