using MVC_People.Models.ViewModels;

namespace MVC_People.Models.Service
{
    public interface ILanguageService
    {
        public Language Add(CreateLanguageViewModel language);
        public List<Language> All();
        public bool Remove(int id);
        public int CountryQueryCompare(Language language);
        public List<Person> AllPeople();
        //public LanguagePeople AddLangPeople(LanguagePeople languagePeople);
        public Language FindById(int id);
        public Person FindPersonById(int id);
        //public List<LanguagePeople> AllLangPeople();
        public void SaveChanges();
    }
}
