using MyProject4.Models;
using MyProject4.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject4.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Books
        public ActionResult List()
        {
            List<ListBooksViewModel> lst = new List<ListBooksViewModel>();
            using (MVCProjectEntities db = new MVCProjectEntities())
            {
                lst =
                    (from b in db.Titles
                     join g in db.Genres on b.GenreId equals g.Id
                     join a in db.Authors on b.AuthorId equals a.Id
                     orderby b.Name ascending
                     select new ListBooksViewModel
                     {
                         Id = b.Id,
                         Name = b.Name,
                         GenreName = g.Name,
                         AuthorName = a.Fullname 
                     }).ToList();
            }
            return View(lst);
        }

        public ActionResult Add()
        {
            AddBookGroupViewModel lstAuthorsGenres = new AddBookGroupViewModel();
            using (MVCProjectEntities db = new MVCProjectEntities())
            {
                //lstAuthorsGenres.Authors
                var lista =
                    (from a in db.Authors
                     orderby a.Fullname ascending
                     select new System.Web.WebPages.Html.SelectListItem { Value = a.Id.ToString(), Text = a.Fullname }).ToList(); // new { Value = a.Id.ToString(), Text = a.Fullname });
                //.Select(x => new SelectListItem
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.Fullname.ToString()
                //});
                //lstAuthorsGenres.Genres =
                //    (from g in db.Genres
                //     orderby g.Name ascending
                //     select new SelectListItem
                //     {
                //         Value = g.Id.ToString(),
                //         Text = g.Name
                //     }).ToList();
                
                lstAuthorsGenres.Authors = lista;
            }
            
            return View(lstAuthorsGenres);
        }
    }
}