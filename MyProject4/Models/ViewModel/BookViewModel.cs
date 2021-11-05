using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MyProject4.Models.ViewModel
{
    public class BookViewModel // (Title actually)
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}