using ManagerOrder.Features.Orders.Views;

namespace ManagerOrder.Interfaces
{
    public interface IAcmeService
    {
        Task<OrderStatusDto> VerifyOrder(OrderDto order);
    }
}
