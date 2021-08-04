using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeBookKeepAPI.Models
{
    public class Book : AuditableEntity
    {
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public virtual BookAuthor BookAuthor  { get; set; }
    }
}