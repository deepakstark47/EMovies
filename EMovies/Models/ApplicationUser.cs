using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EMovies.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "User name")]
        public string FullName { get; set; }
    }
}
