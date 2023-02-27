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

        public FranchisesController(IFranchiseService service)
        {
            _service= service;
        }
        /// <summary>
        /// Gets all the franchises.
        /// </summary>
        /// <returns></returns>        
        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(await _service.GetAllFranchises());
        }
        /// <summary>
        /// Gets a specific franchise by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            try
            {
                return await _service.GetFranchiseById(id);
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
        /// Adds a new franchise to the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            //_service.Entry(character).State = EntityState.Modified;

            try
            {
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
        /// Updates an existing character.
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, await _service.AddFranchise(franchise));
        }
        /// <summary>
        /// Deletes an existing character by ther id.
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
    }
}
