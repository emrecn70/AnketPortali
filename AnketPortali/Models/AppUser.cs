using Microsoft.AspNetCore.Identity;

namespace AnketPortali.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string City { get; set; }
    }
}