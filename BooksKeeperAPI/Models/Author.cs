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
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}