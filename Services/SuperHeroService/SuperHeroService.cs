using SuperHeroApi._7.Data;
using SuperHeroApi._7.Models;

namespace SuperHeroApi._7.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
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

    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetAllHeroes()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<SuperHero?> GetHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero is null)
            return null;

        return hero;
    }

    public async Task<List<SuperHero>?> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();

        return superHeroes;
    }

    public async Task<List<SuperHero>?> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
            return null;

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();

        return superHeroes;
    }

    public async Task<List<SuperHero>?> EditHero(int id, SuperHero req)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero is null)
            return null;

        hero.Name = req.Name;
        hero.FirstName = req.FirstName;
        hero.LastName = req.LastName;
        hero.Place = req.Place;

        await _context.SaveChangesAsync();

        return superHeroes;
    }

   
}
