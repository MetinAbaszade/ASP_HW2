using ASP_HW2.Entitities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ASP_HW2.Controllers
{
    public class PersonController : Controller
    {

        public static List<Person> People = new List<Person>()
        {
            new Person("Polad ", "Bulbuloğlu", 77, "uploads/Polad Bulbuloqlu.jpg", null),
            new Person("Mübariz", "Tağıyev", 74, "uploads/Mubariz Tagiiyev.jpg", null),
            new Person("Ağadadaş", "Ağayev", 66, "uploads/Aqadadas Aqayev.jpg", null),
            new Person("Flora", "Karimova", 81, "uploads/Flora Kerimova.jpg", null)
        };

        // GET: Person
        public ActionResult Index()
        {
            return View(People);
        }

        // POST: Person/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person newperson)
        {
            string fileextension = Path.GetExtension(newperson.MyFile.FileName);
            string filename = Path.ChangeExtension(
                    Path.GetRandomFileName(),
                    fileextension
            );
            string filelocation = "wwwroot/uploads/" + filename;
            newperson.MyFile.CopyTo(new FileStream(filelocation, FileMode.Create));
            newperson.Id = ++Person.LastId;
            newperson.Image = "uploads/" + filename;
            newperson.MyFile = null;
            People.Add(newperson);
            return RedirectToAction("index");
        }
    }
}
