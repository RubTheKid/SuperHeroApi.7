using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi._7.Models;
using SuperHeroApi._7.Services.SuperHeroService;

namespace SuperHeroApi._7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;
    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        return await _superHeroService.GetAllHeroes();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetHero(int id)
    {
        var result = _superHeroService.GetHero(id);
        if (result == null)
            return null;

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        var result = _superHeroService.AddHero(hero);
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> EditHero(int id, SuperHero req)
    {
        var result = _superHeroService.EditHero(id, req);
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var result = _superHeroService.DeleteHero(id);
        if (result is null)
            return NotFound();

        return Ok(result);
    }

}