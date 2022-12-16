using Microsoft.EntityFrameworkCore;
using MVC_People.Data;
using System.Diagnostics.Metrics;

namespace MVC_People.Models.People.PeopleRepo
   
{
    public class DbPeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbPeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public List<Person> Read()
        {
            return _peopleDbContext.People.Include(c => c.Languages).Include(l => l.Location).ToList();
        }
        public Person SearchForPerson(string personName)
        {
            return _peopleDbContext.People.FirstOrDefault(x => x.FirstName + x.LastName == personName);
        }
        public List<City> ReadCities()
        {
            return _peopleDbContext.Cities.ToList();
        }
        public City SearchCity(string cityName)
        {
            return _peopleDbContext.Cities.FirstOrDefault(x => x.CityName == cityName);
        }
        public List<Language> ReadLanguages()
        {
            return _peopleDbContext.Languages.ToList();
        }
        public Person Create(Person person)
        {
            _peopleDbContext.People.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }
        public bool Delete(Person person)
       {
            foreach (Person p in Read())
                if (person.Id == p.Id)
                {
                    _peopleDbContext.Remove(p);
                    _peopleDbContext.SaveChanges();
                    return true;
                }
            return false;
        }
        public bool Update(Person person)
        {

            foreach (Person p in Read())
                if (person.Id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    //p.CityName = person.CityName;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    p.Languages = person.Languages;
                    p.LocationId = person.LocationId;
                    _peopleDbContext.SaveChanges();
                    return true;
                }
            return false;
        }
        
    }
}
