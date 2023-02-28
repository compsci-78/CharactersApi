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
using CharactersApi.Services.Franchises;
using CharactersApi.Exceptions;
using AutoMapper;
using CharactersApi.Models.Dtos;

namespace CharactersApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all the franchises.
        /// </summary>
        /// <returns></returns>        
        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadFranchiseDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<ReadFranchiseDto>> (await _service.GetAllFranchises()));
        }
        /// <summary>
        /// Gets a specific franchise by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadFranchiseDto>> GetFranchise(int id)
        {
            try
            {
                return Ok( _mapper.Map<ReadFranchiseDto>( await _service.GetFranchiseById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        /// Updates an existing franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, UpdateFranchiseDto franchiseDto)
        {
            if (id != franchiseDto.Id)
            {
                return BadRequest();
            }

            //_service.Entry(character).State = EntityState.Modified;

            try
            {
                var franchise = _mapper.Map<Franchise>(franchiseDto);
                await _service.UpdateFranchise(franchise);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        /// <summary>
        /// Adds a new franchise to the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(CreateFranchiseDto franchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(franchiseDto);
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, await _service.AddFranchise(franchise));
        }
        /// <summary>
        /// Deletes an existing franchise by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _service.DeleteFranchise(id);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Updates franchise movies
        /// </summary>
        /// <param name="id">Franchise id</param>
        /// <param name="movies">List of movies id</param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id, List<int> movies)
        {
            try
            {
                await _service.UpdateFranchiseMovies(id, movies);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid franchise.");
            }

            return NoContent();
        }
        /// <summary>
        /// Gets franchise movies by franchise id.
        /// </summary>
        /// <param name="id">Franchise id</param>
        /// <returns></returns>
        // GET: api/Franchises/movies
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetFranchiseMovies(int id)
        {
            return Ok( _mapper.Map<IEnumerable<ReadMovieDto>>(await _service.GetAllFranchiseMovies(id)));       
        }
        /// <summary>
        /// Gets franchise characters by franchise id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetFranchiseCharacters(int id)
        {
            return Ok(_mapper.Map<IEnumerable<ReadCharacterDto>>(await _service.GetAllFranchiseCharacters(id)));
        }
    }
}
