using FT.Travelako.Common.Database;
using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private UserAppDbContext _dbContext;
        public UserRepository(UserAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task<User> GetUserByUserName(string userName)
        {
            return await _dbContext.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUserInformationAsync(User entity)
        {
            _dbContext.Users.Attach(entity);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Users.FindAsync(entity.Id);
        }
    }
}
