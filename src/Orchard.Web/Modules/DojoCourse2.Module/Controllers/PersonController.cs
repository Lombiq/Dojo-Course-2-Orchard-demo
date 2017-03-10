using DojoCourse2.Module.Models;
using DojoCourse2.Module.Services;
using Orchard.Exceptions;
using System;
using System.Web.Mvc;
using System.Linq;

namespace DojoCourse2.Module.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonManager _personManager;


        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }


        public string CreateGoodPersons()
        {
            _personManager.SavePerson("Jacob Gips", Sex.Male, new DateTime(1977, 3, 14), "I was born on a damn farm in South-North Neverland.");
            _personManager.SavePerson("Naomi Concrete", Sex.Female, new DateTime(1979, 5, 12), "\"Always cite meaningful quotes.\" - Luke Skywalker");
            _personManager.SavePerson("James Ytong", Sex.Male, new DateTime(1989, 12, 4), "<insert subject biography here>");
            _personManager.SavePerson("Maria Brick", Sex.Female, new DateTime(1969, 10, 6), "Not much.");

            return "Good persons saved.";
        }

        //public string CreateBadPerson()
        //{
        //    try
        //    {
        //        _personManager.SavePerson(null, Sex.Male, new DateTime(2077, 1, 1), "asdf");
        //    }
        //    catch (Exception ex) when (!ex.IsFatal())
        //    {
        //        return "You should do better than this!";
        //    }

        //    return "A-OK!";
        //}

        public string ListPersons()
        {
            var persons = _personManager.GetPersons();
            return string.Join("<br /><br />", persons.Select(person => person.Name + ", " + person.Sex + ", " + person.BirthDateUtc + ", " + person.Biography));
        }
    }
}