using Booking.Application.Contracts.Persistence;
using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence;
using FT.Travelako.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private new readonly BookingContext _dbContext;
        public OrderRepository(BookingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userId)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserId.ToString() == userId)
                                .ToListAsync();
            return orderList;
        }
    }
}
