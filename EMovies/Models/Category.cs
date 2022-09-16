using System.ComponentModel.DataAnnotations;

namespace EMovies.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //relationships
        public List<Movie> movies { get; set; }

    }
}
