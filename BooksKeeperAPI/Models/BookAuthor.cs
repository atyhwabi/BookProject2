using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksKeeperAPI.Models
{
   
    public class BookAuthor : AuditableEntity, IAuditableEntity
    {
    
        public Guid? BookId { get; set; }
        public Guid? AuthorID { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}