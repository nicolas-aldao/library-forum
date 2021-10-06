using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject4.Models;
using MyProject4.Models.ViewModel;

namespace MyProject4.Controllers
{
    public class PeopleController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<ListPeopleViewModel> lst = new List<ListPeopleViewModel>();
            using (MVCProjectEntities db = new MVCProjectEntities()) // connects the db
            {
                lst =
                    (from d in db.People
                     orderby d.Name ascending
                     select new ListPeopleViewModel
                     {
                         Id = d.Id,
                         Name = d.Name
                     }).ToList();
            }
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(PeopleViewModel model)
        {
            try
            {
                using (MVCProjectEntities db = new MVCProjectEntities())
                {
                    People oPeople = new People();
                    oPeople.Name = model.Name;
                    oPeople.Age = model.Age;
                    db.People.Add(oPeople);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            PeopleViewModel model = new PeopleViewModel();
            using (MVCProjectEntities db = new MVCProjectEntities())
            {
                var p = db.People.Find(id);
                model.Name = p.Name;
                model.Age = p.Age;
                model.Id = p.Id;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(PeopleViewModel model)
        {
            try
            {
                using (MVCProjectEntities db = new MVCProjectEntities())
                {
                    People oPeople = db.People.Find(model.Id);
                    oPeople.Name = model.Name;
                    oPeople.Age = model.Age;
                    db.Entry(oPeople).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (MVCProjectEntities db = new MVCProjectEntities())
                {
                    People oPeople = db.People.Find(id);
                    db.People.Remove(oPeople);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}