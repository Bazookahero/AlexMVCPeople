using Microsoft.EntityFrameworkCore;

namespace MVC_People.Models
{
    [Keyless]
    public class LanguagePeople
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int PeopleId { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<string> PersonLanguages { get; set; } = new List<string>();
    }
}
