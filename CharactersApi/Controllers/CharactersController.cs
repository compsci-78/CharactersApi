using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharactersApi.Models;
using CharactersApi.Services.Characters;
using System.Text.RegularExpressions;
using CharactersApi.Exceptions;
using System.Net.Mime;
using AutoMapper;
using CharactersApi.Models.Dtos;

namespace CharactersApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;
        public CharactersController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all the Characters.
        /// </summary>
        /// <returns></returns>
        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<ReadCharacterDto>>(await _service.GetAllCharacters()));            
        }
        /// <summary>
        /// Gets a specific character by their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<ReadCharacterDto>(await _service.GetCharacterById(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        /// Updates an existing character. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        // PUT: api/Characters/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, UpdateCharacterDto characterDto)
        {
            if (id != characterDto.Id)
            {
                return BadRequest();
            }

            //_service.Entry(character).State = EntityState.Modified;

            try
            {
                var character = _mapper.Map<Character>(characterDto);
                await _service.UpdateCharacter(character);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        /// <summary>
        /// Adds a new character.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CreateCharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, await _service.AddCharacter( character));
        }
        /// <summary>
        /// Deletes an existing character by ther id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _service.DeleteCharacter(id);
            }
            catch (CharacterNotFoundException ex)
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
