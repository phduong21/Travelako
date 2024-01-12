using Coupon.Domain.Entities;
using FT.Travelako.Common.Repositories;

namespace Coupon.Application.Contracts.Persistence
{
    public interface ICouponRepository : IAsyncRepository<Coupons>
    {
        Task<IEnumerable<Coupons>> GetCouponsByUser(string userId);
    }
}
