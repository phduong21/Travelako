using FT.Travelako.UI.Models.Orders;

namespace FT.Travelako.UI.Services
{
    public interface IOrderService
    {
        Task CheckoutOrder(CheckoutModel checkoutModel);
        Task DeleteOrder(string userId);
        Task<IEnumerable<OrderResponseModel>> GetOrdersById(string userId);
    }
}