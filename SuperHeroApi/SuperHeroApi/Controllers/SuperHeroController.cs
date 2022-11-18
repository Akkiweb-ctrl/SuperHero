using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes() {
            return Ok(await _context.SuperHeroes.ToListAsync());
           
            }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperhero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperhero(SuperHero reqHero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(reqHero.Id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found");
            }

            dbHero.Name = reqHero.Name;
            dbHero.FirstName = reqHero.FirstName;
            dbHero.LastName = reqHero.LastName;
            dbHero.Place = reqHero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteSuperhero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found");
            }
            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        private ActionResult<List<SuperHero>> Ok(object value)
        {
            throw new NotImplementedException();
        }
    }
}
