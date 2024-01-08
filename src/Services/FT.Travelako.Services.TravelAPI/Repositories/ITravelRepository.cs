using FT.Travelako.Services.TravelAPI.Models;

namespace FT.Travelako.Services.TravelAPI.Repositories
{
    public interface ITravelRepository
    {
        Task<IQueryable<Travel>> GetAll();

        Task<Travel> GetById(Guid id);

        Task Create(Travel entity);

        Task Update(Guid id, Travel entity);

        Task Delete(Guid id);
    }
}