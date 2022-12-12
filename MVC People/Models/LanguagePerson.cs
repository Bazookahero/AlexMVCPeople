namespace MVC_People.Models
{
    public class LanguagePerson
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public List<Language> LanguageList { get; set; }
        public List<Person> PeopleList { get; set; }
    }
}
