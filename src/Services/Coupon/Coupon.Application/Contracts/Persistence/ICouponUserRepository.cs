using Coupon.Domain.Entities;
using FT.Travelako.Common.Entities;
using FT.Travelako.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Contracts.Persistence
{
    public interface ICouponUserRepository : IAsyncRepository<CouponUser>
    {
        Task<IEnumerable<CouponUser>> GetCouponsByUser(string userId);
    }
}
