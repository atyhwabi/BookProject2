using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeBookKeepAPI.Models
{
    public class Author : AuditableEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}