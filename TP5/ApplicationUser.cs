using Microsoft.AspNetCore.Identity;

namespace TP5
{
    public class ApplicationUser: IdentityUser
    {

        public string? City {  get; set; }

    }
}
