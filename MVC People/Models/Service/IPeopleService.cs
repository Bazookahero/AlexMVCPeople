using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using MVC_People.Models.People.ViewModels;

namespace MVC_People.Models.People.PeopleService
{
    public interface IPeopleService
    {


        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
        bool Remove(string id);
        //public List<Person> PeopleInCity(City city);
        public List<City> AllCities();
        public List<Language> AllLanguages();
        public void AddLanguage(Person person);

    }
}
