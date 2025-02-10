using Microsoft.AspNetCore.Identity;

namespace Project.Models
{
    public class User : IdentityUser
    {
        public string FirstName = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
