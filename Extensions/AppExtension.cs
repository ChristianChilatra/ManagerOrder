using FluentValidation;
using Scalar.AspNetCore;
using static ManagerOrder.Features.Orders.Queries.GetOrderStatus;

namespace ManagerOrder.Extensions
{
    public static class AppExtension
    {
        public static WebApplication WithEndpoint(this WebApplication app)
        {
            app.MapGetOrderStatus();

            return app;
        }

        public static WebApplication WithOpenApi(this WebApplication app)
        {
            app.MapOpenApi();
            app.MapScalarApiReference();

            return app;
        }
    }
}
