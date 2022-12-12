using MVC_People.Data;
using MVC_People.Models.People.PeopleService;
using System;
using System.Diagnostics.Metrics;

namespace MVC_People.Models.People.PeopleRepo
{

    public class InMemoryPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public InMemoryPeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public static int iDCounter = 1;
        public static List<Person> peopleList = new List<Person>();
        public Person Create(Person person)
        {
            person.Id = iDCounter++;
            peopleList.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return peopleList;
        }
        public Person Read(int id)
        {
            foreach (Person person in Read())
                if (id == person.Id)
                {
                    return person;
                }
            return null;
        }
        public bool Update(Person person)
        {
            foreach (Person p in Read())
                if (person.Id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    //p.CityOfBirth = person.CityOfBirth;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    //p.LivesIn = person.LivesIn;
                    return true;
                }
            return false;
        }

        public bool Delete(Person person)
        {
            foreach (Person p in Read())
                if (person.Id == p.Id)
                {
                    Read().Remove(p);
                    return true;
                }
            return false;
        }
    }
}
