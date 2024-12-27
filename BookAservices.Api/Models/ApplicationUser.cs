using Microsoft.AspNetCore.Identity;

namespace BookAservices.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
