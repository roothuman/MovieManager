using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models
{
    //principal parent
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Ticket Price must be a positive number.")]
        public double TicketPrice { get; set; }

        [Required]
        public string Country { get; set; }

        // Define one-to-many relationship between Movie and Genre
        public int GenreId { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public string Photo { get; set; }
    }


}
