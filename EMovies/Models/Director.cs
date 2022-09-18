using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMovies.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [DisplayName("Director Name")]
        public string DirectorName { get; set; }
        [DisplayName("Biography")]
        public string Biography { get; set; }

        //relationships
        [ValidateNever]
        public List<Movie> movies { get; set; }
    }
}
