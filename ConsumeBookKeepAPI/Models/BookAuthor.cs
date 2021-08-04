using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeBookKeepAPI.Models
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