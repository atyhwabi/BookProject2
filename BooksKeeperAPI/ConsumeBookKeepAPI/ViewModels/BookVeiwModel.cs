using ConsumeBookKeepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeBookKeepAPI.ViewModels
{
    public class BookVeiwModel
    {
        public Guid Id { get; set; }

        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}