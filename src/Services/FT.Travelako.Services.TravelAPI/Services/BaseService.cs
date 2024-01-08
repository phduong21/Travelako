using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseInterface;
using FT.Travelako.Services.TravelAPI.Repositories;

namespace FT.Travelako.Services.TravelAPI.Services
{
    public class BaseService<T> : BaseExecutionService<T> where T : IBaseRequestModel
    {
        public ITravelRepository _travelRepository;

        public BaseService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }
    }
}