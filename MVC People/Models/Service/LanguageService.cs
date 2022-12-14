using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Repo;
using MVC_People.Models.ViewModels;

namespace MVC_People.Models.Service
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Add(CreateLanguageViewModel language)
        {
            if (string.IsNullOrWhiteSpace(language.LanguageName) /*|| country.CitiesInCountry == null*/)
            {
                Exception ex = new Exception();
                throw ex;
            }
            Language newLanguage = new Language();
            newLanguage.LanguageName = language.LanguageName;
            var query = CountryQueryCompare(newLanguage);
            if (query == 1)
            {
                return null;
            }
            else
            {
                return _languageRepo.Create(newLanguage);
            }
        }
        public List<Language> All()
        {
            return _languageRepo.Read();
        }
        public List<Person> AllPeople()
        {
            return _languageRepo.ReadPeople;
        }
        //public List<LanguagePeople> AllLangPeople()
        //{
        //    return _languageRepo.ReadLangPeople();
        //}
        public bool Remove(int id)
        {

            foreach (Language language in _languageRepo.Read())
                if (id == language.Id)
                {
                    _languageRepo.Delete(language);
                    return true;
                }
            return false;
        }
        public int CountryQueryCompare(Language language)
        {
            List<Language> languages = _languageRepo.Read();
            int languageQuery = (
                from languageQ in languages
                where languageQ.LanguageName == language.LanguageName
                select languageQ
            ).Count();
            if (languageQuery == 0)
                return 0;
            else
                return 1;
        }
        //public LanguagePeople AddLangPeople(LanguagePeople languagePeople)
        //{
        //        return _languageRepo.CreateLangPeople(languagePeople);
            
        //}
        public Person FindPersonById(int id)
        {
            var personList = _languageRepo.ReadPeople;
            foreach (Person person in personList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }
        public Language FindById(int id)
        {
            var languageList = _languageRepo.Read();
            foreach (Language language in languageList)
            {
                if (language.Id == id)
                {
                    return language;
                }
            }
            return null;
        }
        public void SaveChanges()
        {
            _languageRepo.SaveChanges();
        }
    }
}
