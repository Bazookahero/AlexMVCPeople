﻿using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace MVC_People.Models
{
    public class Country
    {
        [Key]
        //[ForeignKey("City")]
        public int Id { get; set; }
        [Required]
        public string? CountryName { get; set; }


        public virtual ICollection<City>? City { get; set; }
        //public virtual ICollection<Person>? Person { get; set; }

    }
}
