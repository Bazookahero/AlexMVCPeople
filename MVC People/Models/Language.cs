using Microsoft.Build.Framework;

namespace MVC_People.Models
{
    public class Language
    {
        //public Language()
        //{
        //    this.People = new HashSet<Person>();
        //}
        public int Id { get; set; }
        [Required]
        public string? LanguageName { get; set; }

        public List<Person>? People { get; set; } = new List<Person>();
    }
}
