using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject4.Models.ViewModel
{
    public class ListBooksViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string AuthorName { get; set; }
    }
}