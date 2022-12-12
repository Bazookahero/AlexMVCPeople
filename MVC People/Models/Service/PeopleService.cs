using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.ViewModels;
using MVC_People.Models.Repo;
using MVC_People.Models.Service;
using System;

namespace MVC_People.Models.People.PeopleService
{
    public class PeopleService : IPeopleService
    {
        ICityService _cityService;
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            if (string.IsNullOrWhiteSpace(person.Age.ToString()) || string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName) /*|| string.IsNullOrWhiteSpace(person.CityOfBirth.CityName)*/ /*|| string.IsNullOrWhiteSpace(person.LivesIn.CityName)*/)
            {
                Exception ex = new Exception();
                throw ex;
            }
            Person newPerson = new Person();
            newPerson.Age = person.Age;
            newPerson.FirstName = person.FirstName;
            newPerson.LastName = person.LastName;
            newPerson.Location = _peopleRepo.SearchCity(person.CityName);
            newPerson.PhoneNumber = person.PhoneNumber;

            return _peopleRepo.Create(newPerson);
        }
        public List<City> AllCities()
        {
            return _peopleRepo.ReadCities();
        }
        public List<Language> AllLanguages()
        {
            return _peopleRepo.ReadLanguages();
        }
        public List<Person> Search(string search)
        {
            var peopleList = _peopleRepo.Read();
            var searchList = new List<Person>();
            foreach(Person person in peopleList)
            {
                if(person.Id.ToString().ToLower() == search.ToLower() /*|| person.CityOfBirth.CityName.ToLower() == search.ToLower()*/ || person.FirstName.ToLower() == search.ToLower() || person.LastName.ToLower() == search.ToLower() || person.Age.ToString().ToLower() == search.ToLower() || /*person.LivesIn.CityName.ToLower() == search.ToLower() ||*/ person.FirstName.ToLower() + " "+ person.LastName.ToLower() == search.ToLower())
                {
                    searchList.Add(person);
                }
            }
            return searchList;
        }
        public List<Person> All()
        {
            return _peopleRepo.Read();
        }
        public Person FindById(int id)
        {
            var personList = _peopleRepo.Read();
            foreach (Person person in personList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            foreach (Person p in _peopleRepo.Read())
                if (id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    //p.CityOfBirth = person.CityOfBirth;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    p.Location = person.Location;
                    //p.LivesIn = person.LivesIn;
                    return true;
                }
            return false;
        }
        public bool Remove(int id)
        {
            
            foreach (Person person in _peopleRepo.Read())
                if (id == person.Id)
                {
                    _peopleRepo.Delete(person);
                    return true;
                }
            return false;
        }
        public bool Remove(string id)
        {
            int parseInt = int.Parse(id);
            foreach (Person person in _peopleRepo.Read())
                if (parseInt == person.Id)
                {
                    _peopleRepo.Delete(person);
                    return true;
                }
            return false;
        }
        public void AddLanguage(Person person)
        {
            //Language newLanguage = new Language();
            _peopleRepo.Update(person);

        }
    }
}
