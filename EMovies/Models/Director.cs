using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EMovies.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string ProfilePictureUrl { get; set; }

        public string DirectorName { get; set; }

        public string Biography { get; set; }

        //relationships
        [ValidateNever]
        public List<Movie> movies { get; set; }
    }
}
