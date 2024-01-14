using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.UserAPI.Models;

namespace FT.Travelako.Services.UserAPI.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
