using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MyProject4.Models.ViewModel
{
    public class AddBookGroupViewModel
    {
        public IEnumerable<SelectListItem> Genres { get; set; }
        public int GenreId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
        public int AuthorId { get; set; }
    }
}