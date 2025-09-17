using ManagerOrder.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .WithFluentValidation()
    .WithOpenApi()
    .WithMinimalApi()
    .WithDependencyInjection()
    .WithProblemDetail();


var app = builder.Build();

app
    .WithEndpoint()
    .WithOpenApi();

app.Run();
