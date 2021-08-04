using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksKeeperAPI.Models
{

    public class Book : AuditableEntity, IAuditableEntity
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }
        
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

    }
}