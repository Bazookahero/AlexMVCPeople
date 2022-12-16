using Microsoft.AspNetCore.Identity;

namespace MVC_People.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {

        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        //public IdentityRole Role { get; set; }
    }
}
