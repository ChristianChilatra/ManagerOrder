using FluentValidation;
using ManagerOrder.Interfaces;
using ManagerOrder.Services;
using static ManagerOrder.Features.Orders.Queries.GetOrderStatus;

namespace ManagerOrder.Extensions
{
    public static class BuilderExtension
    {
        public static WebApplicationBuilder WithFluentValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<GetOrderStatusRequest>();

            return builder;
        }

        public static WebApplicationBuilder WithOpenApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApi();

            return builder;
        }

        public static WebApplicationBuilder WithMinimalApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static WebApplicationBuilder WithDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient("Acme", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Acme:Url") ?? throw new NullReferenceException("No existe la variable de configuracion 'Acme:Url'"));
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            builder.Services.AddScoped<IAcmeService, AcmeService>();

            return builder;
        }

        public static WebApplicationBuilder WithProblemDetail(this WebApplicationBuilder builder)
        {
            builder.Services.AddProblemDetails();

            return builder;
        }
    }
}
