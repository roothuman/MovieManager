using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models
{
    //dependent child
    public class Genre
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int MovieId { get; set; }
        // Define one-to-many relationship between Genre and Movie
        public Movie Movie { get; set; }
    }

}
