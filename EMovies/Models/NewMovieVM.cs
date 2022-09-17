using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EMovies.Models
{
    public class NewMovieVM
    {
        public int MovieId { get; set; }

        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Name is required")]
        public string MovieName { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is required")]
        public string MovieDescription { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double MoviePrice { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string MovieImageURL { get; set; }

        [Display(Name = "Movie Release date")]
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }


        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a Director")]
        [Required(ErrorMessage = "Movie director is required")]
        public int DirectorId { get; set; }


        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie category is required")]
        public int CategoryId { get; set; }

    }
}
