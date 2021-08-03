using BookSCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksCrud.API
{
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        public IHttpActionResult GetBooks(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult AddBook([FromBody] Book book)
        {
           
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }
         [HttpDelete]
         public IHttpActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();



            _context.Books.Remove(book);
            _context.SaveChanges();



            return Ok();
        }
    }
}
