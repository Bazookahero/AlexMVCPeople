namespace MVC_People.Models.ViewModels
{
    public class LanguagePersonViewModel
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> People { get; set; } = new List<string>();
    }
}
