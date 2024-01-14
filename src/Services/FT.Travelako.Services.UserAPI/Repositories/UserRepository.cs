using FT.Travelako.Common.Database;
using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models;

namespace FT.Travelako.Services.UserAPI.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private UserAppDbContext _dbContext;
        public UserRepository(UserAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
