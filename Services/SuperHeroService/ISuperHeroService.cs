namespace SuperHeroApi._7.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();
    Task<SuperHero?> GetHero(int id);
    Task<List<SuperHero>?>AddHero(SuperHero hero);
    Task<List<SuperHero>?> EditHero(int id, SuperHero req);
   Task<List<SuperHero>?> DeleteHero(int id);
}
