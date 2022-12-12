using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_People.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Display(Name = "Country Name")]
        [Required]
        public string? CountryName { get; set; }
    }
}
