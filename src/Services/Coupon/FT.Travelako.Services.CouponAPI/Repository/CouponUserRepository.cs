using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.CouponAPI.Repository
{
    public class CouponUserRepository : RepositoryBase<CouponUser>, ICouponUserRepository
    {
        private new readonly AppDbContext _dbContext;
        public CouponUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CouponUser>> GetCouponsByUser(string userId)
        {
            var listCoupons = await _dbContext.CouponsUser
                    .Where(o => o.UserId == userId)
                    .ToListAsync();
            return listCoupons;
        }
    }
}
