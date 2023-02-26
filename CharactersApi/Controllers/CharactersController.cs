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

namespace CharactersApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharactersController(ICharacterService service)
        {
            _service = service;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(await _service.GetAllCharacters());            
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                return await _service.GetCharacterById(id);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        //// PUT: api/Characters/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCharacter(int id, Character character)
        //{
        //    if (id != character.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _service.Entry(character).State = EntityState.Modified;

        //    try
        //    {
        //        await _service.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CharacterExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Characters
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Character>> PostCharacter(Character character)
        //{
        //    _service.Characters.Add(character);
        //    await _service.SaveChangesAsync();

        //    return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        //}

        //// DELETE: api/Characters/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCharacter(int id)
        //{
        //    var character = await _service.Characters.FindAsync(id);
        //    if (character == null)
        //    {
        //        return NotFound();
        //    }

        //    _service.Characters.Remove(character);
        //    await _service.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CharacterExists(int id)
        //{
        //    return _service.Characters.Any(e => e.Id == id);
        //}
    }
}
