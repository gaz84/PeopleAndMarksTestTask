using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleAndMarksTestTask.Models;
using System.Web.Routing;

namespace PeopleAndMarksTestTask.Controllers
{
    public class PersonController : Controller
    {

        public ActionResult Index()
        {
            List<Person> people = new List<Person>();

            using (PeopleDbContext context = new PeopleDbContext())
            {
                //CREATE AND FILL DATABASE
                if (context.People.Count() < 1)
                {
                    for (int i = 1; i < 500; i++)
                    {

                        context.People.Add(new Person { FirstName = "FirstName" + i, LastName = "LastName" + i, Mark = new Mark { Value = i } });

                    }
                    context.SaveChanges();
                }
                @ViewBag.totalPeople = context.People.Count();

                people = context.People.Include("Mark").OrderBy(x => x.Mark.Value).Take(10).ToList();

            }
            return View(people);
        }

        public ActionResult NextPrev(PageInfo pageInfo)
        {

            List<Person> people = new List<Person>();

            using (PeopleDbContext context = new PeopleDbContext())
            {

                if (pageInfo.SortByValue)
                    people = context.People.Include("Mark").OrderBy(x => x.Mark.Value).Skip(pageInfo.CurrentPageNumber * pageInfo.RowPerPage).Take(pageInfo.RowPerPage).ToList();
                else
                    people = context.People.Include("Mark").OrderBy(x => x.LastName).ThenByDescending(x => x.FirstName).Skip(pageInfo.CurrentPageNumber * pageInfo.RowPerPage).Take(pageInfo.RowPerPage).ToList();

            }
            return PartialView("PartialShowPeople", people);
        }
        [HttpPost]
        public ActionResult AddNewPerson(Person person)
        {
            using (PeopleDbContext context = new PeopleDbContext())
            {
               
                try
                {
                    context.People.Add(person);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    string message = $"<b>Message:</b> {ex.Message}<br /><br />";
                    message += $"<b>InnerExeption:</b> {ex.InnerException}<br /><br />";
                    message += $"<b>StackTrace:</b> {ex.StackTrace}<br /><br />"; 
                    message += $"<b>Source:</b> {ex.StackTrace}<br /><br />"; 
                    message += $"<b>TargetSite:</b> {ex.StackTrace}<br /><br />";
                    ModelState.AddModelError(string.Empty, message);
                    return View("Error");
                }

            }
            return RedirectToAction("Index");
        }
    }
}