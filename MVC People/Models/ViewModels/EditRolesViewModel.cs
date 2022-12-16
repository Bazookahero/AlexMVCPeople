using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace MVC_People.Models.ViewModels
{
    public class EditRolesViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public List<AppUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
