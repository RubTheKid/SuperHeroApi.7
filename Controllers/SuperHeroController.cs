using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi._7.Models;

namespace SuperHeroApi._7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private static List<SuperHero> superHeroes = new List<SuperHero>
    {
        new SuperHero
        {
            Id = 1,
            Name = "Batman",
            FirstName = "Bruce",
            LastName = "Wayne",
            Place = "Gotham"
        }

    };

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        return Ok(superHeroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetHero(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);

        if(hero is null)
            return NotFound("Hero doesn't exist.");

        return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        superHeroes.Add(hero);
        return Ok(superHeroes);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> EditHero(int id, SuperHero req)
    {
        var hero = superHeroes.Find(x => x.Id == id);

        if (hero is null)
            return NotFound("Hero doesn't exist.");

        hero.Name = req.Name;
        hero.FirstName = req.FirstName;
        hero.LastName = req.LastName;
        hero.Place = req.Place;

        return Ok(superHeroes);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);
        if (hero is null)
            return NotFound("Hero doesn't exist.");

        superHeroes.Remove(hero);

        return Ok(superHeroes);
    }

}