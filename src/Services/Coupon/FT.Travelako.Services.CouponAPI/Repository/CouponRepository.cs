using Coupon.Application.Contracts.Persistence;
using Coupon.Domain.Entities;
using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.CouponAPI.Repository
{
    public class CouponRepository : RepositoryBase<Coupons>, ICouponRepository
    {
        private new readonly AppDbContext _dbContext;
        public CouponRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Coupons>> GetCouponsByUser(string userId)
        {
            var listCoupons = await _dbContext.Coupons
                                .Where(o => o.CreatedBy.ToString() == userId)
                                .ToListAsync();
            return listCoupons;
        }
    }
}
