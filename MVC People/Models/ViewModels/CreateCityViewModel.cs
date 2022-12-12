
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.People.ViewModels;
using MVC_People.Models.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MVC_People.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Display(Name = "City Name")]
        [Required]
        public string? CityName { get; set; }
        public Country? CityCountry { get; set; }
        [Display(Name = "Country Name")]
        [Required]
        public string? CityCountryName { get; set; }

        public List<string> CountryList { get; set; } = new List<string>();


    }
}
