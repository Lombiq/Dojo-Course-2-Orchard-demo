using DojoCourse2.Module.Models;
using Orchard;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoCourse2.Module.Services
{
    public interface IPersonManager : IDependency
    {
        IEnumerable<PersonRecord> GetPersons();

        IEnumerable<PersonRecord> GetPersons(Sex sex, int maxCount);

        void SavePerson(string name, Sex sex, DateTime birthDateUtc, string biography);
    }

    public class PersonManager : IPersonManager
    {
        private readonly IRepository<PersonRecord> _personRepository;
        private readonly IEnumerable<IPersonFilter> _personFilters;


        public PersonManager(IRepository<PersonRecord> personRepository, IEnumerable<IPersonFilter> personFilters)
        {
            _personRepository = personRepository;
            _personFilters = personFilters;
        }


        public IEnumerable<PersonRecord> GetPersons()
        {
            return _personRepository.Table;
        }

        public IEnumerable<PersonRecord> GetPersons(Sex sex, int maxCount)
        {
            return _personRepository.Table.Where(record => record.Sex == sex).Take(maxCount);
        }

        public void SavePerson(string name, Sex sex, DateTime birthDateUtc, string biography)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            var person = _personRepository.Fetch(record => record.Name == name).FirstOrDefault();

            if (person == null)
            {
                person = new PersonRecord();
                _personRepository.Create(person);
            }

            person.Name = name;
            person.Sex = sex;
            person.BirthDateUtc = birthDateUtc;
            person.Biography = biography;

            foreach (var filter in _personFilters)
            {
                person.Biography = filter.FilterBiography(person.Biography);
            }
        }
    }


    public interface IPersonFilter : IDependency
    {
        string FilterBiography(string biography);
    }


    public class BadwordFilter : IPersonFilter
    {
        public string FilterBiography(string biography)
        {
            return biography.Replace("damn", "cute");
        }
    }


    public class ShortBiographyFilter : IPersonFilter
    {
        public string FilterBiography(string biography)
        {
            return biography.Length < 10 ?
                "This person has a short biography." :
                biography;
        }
    }
}