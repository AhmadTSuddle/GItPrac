using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice2.Models;
namespace Practice2.Controllers
{
    public class PersonController : Controller
    {

        Practice11Context Md = null;




        public PersonController(Practice11Context MYDB)
        {

            Md = MYDB;

        }
        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddPerson(Person P)
        {
            Md.Person.Add(P);
            Md.SaveChanges();

            return View();

        }
        [HttpGet]
        public IActionResult ViewPerson(Person P)
        {
            IList<Person> PP = Md.Person.ToList<Person>();



            return View(PP);
        }

       
        public IActionResult DetailPerson(Person P)
        {

            Person PPp = Md.Person.Where(m => m.PersonId == P.PersonId).FirstOrDefault<Person>();
            return View(PPp);

        }
       
        public IActionResult DeletePerson(Person P)
        {
            using (var T = Md.Database.BeginTransaction())
               
                try
                {
                    Md.Person.Remove(P);
                    Md.SaveChanges();


                    T.Commit();
                }
                catch (Exception e)
                {
                    T.Rollback();


                }


            return (RedirectToAction("ViewPerson"));
        }



        [HttpGet]
        public IActionResult EditPerson(int PersonId)
        {
            Person PP = Md.Person.Where(m => m.PersonId == PersonId).FirstOrDefault<Person>();

            return View(PP);
        }
        [HttpPost]
        public IActionResult EditPerson(Person P)
        {
            Md.Person.Attach(P);
            Person PP = Md.Person.Where(m => m.PersonId == P.PersonId).FirstOrDefault<Person>();
            var entry = Md.Entry(PP);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            Md.SaveChanges();

            return RedirectToAction(nameof(PersonController.ViewPerson));

        }



    }






}
