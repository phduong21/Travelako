using FT.Travelako.UI.Models.Orders;
using FT.Travelako.UI.Models.Orders.ViewModel;

namespace FT.Travelako.UI.Services
{
    public interface IOrderService
    {
        Task<OrderResponseModel> CheckoutOrder(CheckoutModel checkoutModel);
        Task DeleteOrder(string userId);
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserId(string userId);
        Task<OrderResponseModel> GetOrderDetails(string orderId);
        Task<OrderResponseModel> UpdateOrderStatus(OrderStatus checkoutModel);
    }
}