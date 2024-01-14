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
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetAllSuperHeroAsync()
        {
            var result = await _superHeroRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById([FromRoute]int id)
        {
            var result = await _superHeroRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
