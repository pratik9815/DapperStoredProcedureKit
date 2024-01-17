using DapperDemo.IRepository;
using DapperDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        //Here all the method should be asynchronous
        private readonly ISuperHeroRepository _superHeroRepository;

        public SuperHeroController(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;
        }
        //[HttpGet("get-all-data")]
        //public async Task<IActionResult> GetAllSuperHero()
        //{
        //    var result = await _superHeroRepository.GetAllAsync();
        //    return Ok(result);
        //}

        [HttpGet("get-all-superhero")]
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetAllSuperHero()
        {
            var result = await _superHeroRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById([FromRoute]int id)
        {
            var result = await _superHeroRepository.GetByIdAsync(id);
            if(result == null)
            {
                return StatusCode(404, "Character not found.");
            }
            return Ok(result);
        }

        [HttpPost("add-superhero")]
        public async Task<IActionResult> AddSuperHero([FromBody]CreateSuperHero superHero)
        {
            bool isAdded = await _superHeroRepository.AddAsync(superHero);
            if(isAdded)
                return StatusCode(200,"Superhero added successfully.");

            return StatusCode(500,"Error, unable to add superhero.");
        }

        [HttpDelete("remove-superhero/{id}")]
        public async Task<IActionResult> RemoveSuperHero([FromRoute]int id)
        {
            var result = await _superHeroRepository.DeleteAsync(id);
            if (result) 
                return StatusCode(200, "Character remove success");
            return StatusCode(404, "Character not found");
        }

        [HttpPut("update-superhero")]
        public async Task<IActionResult> UpdateSuperHero([FromBody]SuperHero superHero)
        {
            var result = await _superHeroRepository.UpdateAsync(superHero);
            if (result)
                return StatusCode(200, "Update successful.");
            return StatusCode(500, "Update failed");
        }
    }
}
