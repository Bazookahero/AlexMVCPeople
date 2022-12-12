namespace MVC_People.Models.People.PeopleRepo
{
    public interface IPeopleRepo
    {
        public Person Create(Person person)
        {
            Person newPerson = new Person();
            newPerson.Id = person.Id;
            //newPerson.CityOfBirth = person.CityOfBirth;
            newPerson.FirstName = person.FirstName;
            newPerson.LastName = person.LastName;
            newPerson.Age = person.Age;
            return newPerson;
        }
        public Person SearchForPerson(string personName);
        public City SearchCity(string cityName);
        public List<Person> Read()
        {
            return InMemoryPeopleRepo.peopleList;
        }
        public Person Read(int id)
        {
            var readList = new List<Person>();
            foreach(Person person in InMemoryPeopleRepo.peopleList)
                if(person.Id == id)
                {
                    return person;
                }
            return null;
        }
        public bool Update(Person person)
        {
            
            foreach (Person p in InMemoryPeopleRepo.peopleList)
                if (person.Id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    //p.CityOfBirth = person.CityOfBirth;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    return true;
                }
            return false;
        }
        public bool Delete(Person person)
        {
            foreach (Person p in InMemoryPeopleRepo.peopleList)
                if (person.Id == p.Id)
                {
                    InMemoryPeopleRepo.peopleList.Remove(p);
                    return true;
                }
            return false;
        }

        public List<City> ReadCities();
        public List<Language> ReadLanguages();
    }
}
