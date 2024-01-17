using FT.Travelako.UI.Models.Orders;

namespace FT.Travelako.UI.Services
{
    public interface IOrderService
    {
        Task CheckoutOrder(CheckoutModel checkoutModel);
        Task DeleteOrder(string userId);
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserId(string userId);
        Task<OrderResponseModel> GetOrderDetails(string orderId);
        Task<OrderResponseModel> UpdateOrderStatus(OrderStatus checkoutModel);
    }
}