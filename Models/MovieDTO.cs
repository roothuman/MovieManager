namespace MovieManager.Models
{
    public class MovieDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public double TicketPrice { get; set; }
        public string Country { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public string Photo { get; set; }
    }


}
