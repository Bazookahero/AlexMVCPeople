using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.Service;
using MVC_People.Models.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_People.Models
{
    public class Person
    {
        //public Person()
        //{
        //    this.Languages = new HashSet<Language>();
        //}
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public int LocationId { get; set; }
        public City? Location { get; set; }

        //public int LanguageNameId { get; set; }
        //public string? Language { get; set; }


        public List<Language>? Languages { get; set; }
        

    }
}
