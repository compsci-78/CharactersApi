using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharactersApi.Models;
using System.Net.Mime;
using CharactersApi.Services.Characters;
using CharactersApi.Services.Movies;
using CharactersApi.Exceptions;

namespace CharactersApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all the Movies.
        /// </summary>
        /// <returns></returns>
        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(await _service.GetAllMovies());
        }
        /// <summary>
        /// Gets a specific movie by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                return await _service.GetMovieById(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        /// Adds a new movie to the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            //_service.Entry(movie).State = EntityState.Modified;

            try
            {
                await _service.UpdateMovie(movie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        /// <summary>
        /// Updates an existing movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            return CreatedAtAction("GetMovie", new { id = movie.Id }, await _service.AddMovie(movie));
        }
        /// <summary>
        /// Deletes an existing movie by ther id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteMovie(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

    }
}
