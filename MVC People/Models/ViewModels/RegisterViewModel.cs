using System.ComponentModel.DataAnnotations;

namespace MVC_People.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
