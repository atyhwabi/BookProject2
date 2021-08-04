using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using BooksKeeperAPI.Models;

namespace BooksKeeperAPI.Infrustructure
{
    public class BookDBContext : DbContext
    {
        public BookDBContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public BookDBContext(string Constring)
            : base(Constring)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static BookDBContext Create( string Constring)
        {
            return new BookDBContext();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }
    
    
    }
}