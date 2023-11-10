using Microsoft.EntityFrameworkCore;
using MovieManager.Models;

namespace MovieManager.DAL
{
   

    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _dbContext;

        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }


            public async Task<Movie> CreateMovieAsync(MovieDTO movieDTO)
            {
                var movie = new Movie
                {
                    Name = movieDTO.Name,
                    Description = movieDTO.Description,
                    ReleaseDate = movieDTO.ReleaseDate,
                    Rating = movieDTO.Rating,
                    TicketPrice = movieDTO.TicketPrice,
                    Country = movieDTO.Country,
                    Genres = movieDTO.Genres?.Select(g => new Genre { Name = g.Name }).ToList(),
                    Photo = movieDTO.Photo
                };

                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();

                return movie;
            }

            public async Task<Movie> GetMovieByIdAsync(int movieId)
            {
                return await _dbContext.Movies
                    .Include(m => m.Genres)
                    .FirstOrDefaultAsync(m => m.Id == movieId);
            }

            public async Task<Movie> UpdateMovieAsync(int movieId, MovieDTO movieDTO)
            {
                var existingMovie = await _dbContext.Movies
                    .Include(m => m.Genres)
                    .FirstOrDefaultAsync(m => m.Id == movieId);

                if (existingMovie == null)
                {
                    // Movie not found
                    return null;
                }

                // Update properties
                existingMovie.Name = movieDTO.Name;
                existingMovie.Description = movieDTO.Description;
                existingMovie.ReleaseDate = movieDTO.ReleaseDate;
                existingMovie.Rating = movieDTO.Rating;
                existingMovie.TicketPrice = movieDTO.TicketPrice;
                existingMovie.Country = movieDTO.Country;

                // Update genres
                existingMovie.Genres = movieDTO.Genres?.Select(g => new Genre { Name = g.Name }).ToList();


                await _dbContext.SaveChangesAsync();

                return existingMovie;
            }

            public async Task<bool> DeleteMovieAsync(int movieId)
            {
                var movie = await _dbContext.Movies.FindAsync(movieId);

                if (movie == null)
                {
                    // Movie not found
                    return false;
                }

                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            public async Task<List<Movie>> GetAllMoviesAsync()
            {
                return await _dbContext.Movies
                    .Include(m => m.Genres)
                    .ToListAsync();
            }
        }


    }





