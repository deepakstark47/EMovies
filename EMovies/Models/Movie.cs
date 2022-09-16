using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMovies.Models
{
    public class Movie
    {

        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public double MoviePrice { get; set; }
        public string MovieImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }

        //Relationships
        public List<Review> reviews { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; }


        public int DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public Director Director{ get; set; }




        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
