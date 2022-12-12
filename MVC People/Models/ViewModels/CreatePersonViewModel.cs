using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MVC_People.Data;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace MVC_People.Models.People.ViewModels
{

    public class CreatePersonViewModel
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

