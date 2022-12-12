//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MVC_People.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Display(Name = "Language Name")]
        [Required]
        public string? LanguageName { get; set; }
    }
}
