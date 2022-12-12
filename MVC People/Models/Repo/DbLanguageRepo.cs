using MVC_People.Data;
using MVC_People.Models.People.PeopleRepo;

namespace MVC_People.Models.Repo
{
    public class DbLanguageRepo : ILanguageRepo
    {
        readonly PeopleDbContext _peopleDbContext;
        public DbLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Language Create(Language language)
        {
            _peopleDbContext.Languages.Add(language);
            _peopleDbContext.SaveChanges();
            return language;
        }
        public List<Language> Read()
        {
            return _peopleDbContext.Languages.ToList();
        }
        public List<LanguagePeople> ReadLangPeople()
        {
            return _peopleDbContext.LanguagePeople.ToList();
        }
        public Language SearchLanguage(string languageName)
        {
            return _peopleDbContext.Languages.FirstOrDefault(l => l.LanguageName == languageName);
        }
        public List<Person> ReadPeople => _peopleDbContext.People.ToList();
        public bool Delete(Language language)
        {
            foreach (Language l in Read())
                if (language.Id == l.Id)
                {
                    _peopleDbContext.Remove(l);
                    _peopleDbContext.SaveChanges();
                    return true;
                }
            return false;
        }
        public LanguagePeople CreateLangPeople(LanguagePeople languagePeople)
        {
            _peopleDbContext.LanguagePeople.Add(languagePeople);
            _peopleDbContext.SaveChanges();
            return languagePeople;
        }
        public void SaveChanges()
        {
            _peopleDbContext.SaveChanges();
        }
    }
}
