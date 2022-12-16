using MessagePack;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Service;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.People.ViewModels;

namespace MVC_People.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CityName { get; set; }

        public int CityCountryId { get; set; }
        public virtual Country? CityCountry { get; set; }



        public List<Person>? Person { get; set; }
    }
}
