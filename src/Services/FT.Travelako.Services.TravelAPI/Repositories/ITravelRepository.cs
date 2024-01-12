using FT.Travelako.Common.Repositories;
using Travel = FT.Travelako.Services.TravelAPI.Models.Travel;

namespace FT.Travelako.Services.TravelAPI.Repositories
{
	public interface ITravelRepository : IAsyncRepository<Travel>
	{
	}
}