using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksKeeperAPI.Models
{

    public class Author :  AuditableEntity, IAuditableEntity
    {

        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}