using DapperDemo.DataAccess;
using DapperDemo.IRepository;
using DapperDemo.Models;

namespace DapperDemo.Repository
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
       private readonly ISqlDataAccess _db;
        public SuperHeroRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(CreateSuperHero superHero)
        {
            try
            {
                await _db.SaveData("sp_create_superhero", new { superHero.Character_Name, superHero.Real_Name, superHero.SuperHero_Description });
                return true;
            }
            catch (Exception)       
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(SuperHero superHero)
        {
            try
            {
                await _db.SaveData("sp_update_superhero", superHero);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_remove_superhero", new { superhero_id = id });
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<SuperHero> GetByIdAsync(int id)
        {
            IEnumerable<SuperHero> result = await _db.GetData<SuperHero, dynamic>("sp_get_superhero",new { superhero_id  = id });

            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<SuperHero>> GetAllAsync()
        {
            var result =  await _db.GetData<SuperHero, dynamic>("sp_get_all_superhero", new {  });
            return result;
        }
    }
     
}
    