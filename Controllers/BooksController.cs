using BooksCrud.Models;
using BookSCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace BookSCrud.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public BooksController()
        {
            _context = new ApplicationDbContext(); 
        }
        // GET: Books
        public ActionResult Index()
        {
            var book = _context.Books.Include(m=>m.Category).ToList();
            return View(book);
        }

        public ActionResult Create()
        {
            var viewModel = new BooksViewModel
            {
                Categories = _context.Categories.Where(m => m.IsActive).ToList()
            };
            return View("BookForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book = _context.Books.Include(m => m.Category).SingleOrDefault(m=>m.Id==id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
       

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book = _context.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new BooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Categories = _context.Categories.Where(m => m.IsActive).ToList()

            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BooksViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Where(m => m.IsActive).ToList();
                return View("BookForm", model);
            }
           
            if(model.Id == 0)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Description = model.Description
                };

                _context.Books.Add(book);
            }

            else
            {
                var book = _context.Books.Find(model.Id);
                if (book == null)
                    return HttpNotFound();

                book.Title = model.Title;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;
                book.Description = model.Description;
                
            }
            _context.SaveChanges();

            TempData["Message"] = "Saved Succesfully";
            return RedirectToAction("Index");
        }

       
    }
}