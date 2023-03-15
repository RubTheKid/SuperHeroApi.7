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
    public List<SuperHero> AddHero(SuperHero hero)
    {
        superHeroes.Add(hero);
        return superHeroes;
    }

    public List<SuperHero> DeleteHero(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);
        if (hero is null)
            return null;

        superHeroes.Remove(hero);

        return superHeroes;
    }

    public List<SuperHero> EditHero(int id, SuperHero req)
    {
        var hero = superHeroes.Find(x => x.Id == id);

        if (hero is null)
            return null;

        hero.Name = req.Name;
        hero.FirstName = req.FirstName;
        hero.LastName = req.LastName;
        hero.Place = req.Place;

        return superHeroes;
    }

    public List<SuperHero> GetAllHeroes()
    {
        return superHeroes;
    }

    public SuperHero GetHero(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);

        if (hero is null)
            return null;

        return hero;
    }
}
