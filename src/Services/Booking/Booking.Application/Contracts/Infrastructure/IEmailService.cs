using Booking.Application.Models;
using System.Threading.Tasks;

namespace Booking.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
