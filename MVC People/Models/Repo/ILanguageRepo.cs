namespace MVC_People.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language Create(Language language);
        public List<Language> Read();
        public bool Delete(Language language);
        public List<Person> ReadPeople { get; }
        public LanguagePeople CreateLangPeople(LanguagePeople languagePeople);
        public List<LanguagePeople> ReadLangPeople();
        public void SaveChanges();
        public Language SearchLanguage(string languageName);
    }
}
