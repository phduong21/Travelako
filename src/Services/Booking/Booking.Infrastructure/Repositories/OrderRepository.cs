using Booking.Application.Contracts.Persistence;
using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(BookingContext dbContext) : base(dbContext)
        {
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
