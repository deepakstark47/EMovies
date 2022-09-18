using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMovies.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Required(ErrorMessage ="Profile picture is required")]
        [DisplayName("Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Actor name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name must be 3 and 50 characters")]
        [DisplayName("Actor Name")]
        public string ActorName { get; set; }
        [Required(ErrorMessage = "Biography is required")]
        [DisplayName("Biography")]
        public string Biography { get; set; }
        [ValidateNever]
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
