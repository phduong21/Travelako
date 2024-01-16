using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.Requests;

namespace FT.Travelako.Services.UserAPI.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> UpdateUserInformationAsync(User entity);

        Task<User> GetUserByUserName(string userName);
        Task DeleteUser(User user);
    }
}
