namespace SuperHeroApi._7.Services.SuperHeroService;

public interface ISuperHeroService
{
    List<SuperHero> GetAllHeroes();
    SuperHero GetHero(int id);
    List<SuperHero> AddHero(SuperHero hero);
    List<SuperHero>? EditHero(int id, SuperHero req);
    List<SuperHero>? DeleteHero(int id);
}
