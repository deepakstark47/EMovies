using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMovies.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
       
        public string ReviewDescription { get; set; }

        public int StarRating { get; set; }

        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        [ValidateNever]
        public Movie Movie { get; set; }


        

    }
}
