using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_People.Models.ViewModels
{
    public class EditPersonViewModel
    {
        [Display(Name = "First name")]
        [Required]
        public string? FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string? LastName { get; set; }
        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }
        [Display(Name = "Location Id")]
        [Required]
        public int LocationId { get; set; }
        public City? Location { get; set; }
        [Display(Name = "City Name")]
        [Required]
        public string? CityName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }


        public List<string>? CityList { get; set; } = new List<string>();

    }
}
