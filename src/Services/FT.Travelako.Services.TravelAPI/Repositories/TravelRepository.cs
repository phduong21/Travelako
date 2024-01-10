using FT.Travelako.Services.TravelAPI.Data;
using FT.Travelako.Services.TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FT.Travelako.Services.TravelAPI.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private AppDbContext _dbContext;

        public TravelRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Task Create(Travel entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Set<Travel>().FindAsync(id);
            _dbContext.Set<Travel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Travel>> GetAll()
        {
            return _dbContext.Travels;
        }

        public async Task<Travel> GetById(Guid id)
        {
            return await _dbContext.Travels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Guid id, Travel entity)
        {
            _dbContext.Set<Travel>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}