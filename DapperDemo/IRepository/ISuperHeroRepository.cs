using DapperDemo.Models;

namespace DapperDemo.IRepository
{
    public interface ISuperHeroRepository
    {
        Task<bool> AddAsync(CreateSuperHero superHero);
        Task<bool> UpdateAsync(SuperHero superHero);
        Task<bool> DeleteAsync(int id);
        Task<SuperHero> GetByIdAsync(int id);
        Task<IEnumerable<SuperHero>> GetAllAsync();
    }
}