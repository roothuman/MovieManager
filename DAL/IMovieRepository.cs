using MovieManager.Models;

namespace MovieManager.DAL
{
    public interface IMovieRepository
    {
        // Create a movie
        Task<Movie> CreateMovieAsync(MovieDTO movieDTO);

        // Read a movie by Id
        Task<Movie> GetMovieByIdAsync(int movieId);

        // Update a movie
        Task<Movie> UpdateMovieAsync(int movieId, MovieDTO movieDTO);

        // Delete a movie
        Task<bool> DeleteMovieAsync(int movieId);

        // Get all movies
        Task<List<Movie>> GetAllMoviesAsync();
    }


}
