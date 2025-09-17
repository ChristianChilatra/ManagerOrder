using ManagerOrder.Features.Orders.Views;
using ManagerOrder.Interfaces;
using ManagerOrder.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace ManagerOrder.Features.Orders.Queries
{
    public static class GetOrderStatus
    {
        public record GetOrderStatusRequest(long numPedido, int cantidadPedido, string codigoEAN, string nombreProducto, long numDocumento, string direccion);

        public static void MapGetOrderStatus(this WebApplication app)
        {
            app.MapPost("/orderStatus", GetOrderStatusHandle)
            .WithName("Estado de Orden")
            .Produces<OrderStatusDto>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .AddEndpointFilter<ValidationFilter<GetOrderStatusRequest>>();
        }

        public static async Task<OrderStatusDto> GetOrderStatusHandle(
            [FromBody] GetOrderStatusRequest request,
            [FromServices] IAcmeService acmeService
            )
        {
            var orderDto = new OrderDto()
            {
                Order = request.numPedido,
                Quantity = request.cantidadPedido,
                EAN = request.codigoEAN,
                Product = request.nombreProducto,
                Document = request.numDocumento,
                Address = request.direccion,
            };

            var orderStatus = await acmeService.VerifyOrder(orderDto);

            return orderStatus;
        }
    }
}
