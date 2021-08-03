using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookSCrud.Models
{
    public class ApplicationDbContext : DbContext
    {

        //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext() : base("DefaultConnection")
        {
            //Database.SetInitializer(new BookStoreDbInitializer());

        }
    }
}