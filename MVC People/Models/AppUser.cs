using Microsoft.AspNetCore.Identity;

namespace MVC_People.Models
{
    public class AppUser : IdentityUser
    {
        //public string UserName { get; set; }
        //public int Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
