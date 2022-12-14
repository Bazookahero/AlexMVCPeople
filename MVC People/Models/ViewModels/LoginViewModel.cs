using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MVC_People.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
