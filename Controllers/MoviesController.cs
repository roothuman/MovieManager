using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManager.DAL;
using MovieManager.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MovieManager.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        /// <summary>
        /// Create a new movie.
        /// </summary>
        /// <param name="movieDTO">The movie data.</param>
        /// <returns>The created movie.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDTO movieDTO)
        {
            var createdMovie = await _movieRepository.CreateMovieAsync(movieDTO);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(createdMovie, options);

            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, json);
        }

        /// <summary>
        /// Get a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(movie, options);

            return Ok(json);
        }


        /// <summary>
        /// Update a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie.</param>
        /// <param name="movieDTO">The updated movie data.</param>
        /// <returns>The updated movie.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDTO movieDTO)
        {
            var updatedMovie = await _movieRepository.UpdateMovieAsync(id, movieDTO);

            if (updatedMovie == null)
            {
                return NotFound();
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(updatedMovie, options);

            return Ok(json);
        }

        /// <summary>
        /// Delete a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>No content if successful, not found otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieRepository.DeleteMovieAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <returns>All movies in the database.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var json = JsonSerializer.Serialize(movies, options);

            return Ok(json);
        }
    }




}
