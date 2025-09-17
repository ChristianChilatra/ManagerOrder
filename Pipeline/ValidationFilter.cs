using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagerOrder.Pipeline
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            var arg = context.GetArgument<T>(0);

            if (validator is not null)
            {
                var result = await validator.ValidateAsync(arg!);

                if (!result.IsValid)
                {
                    return Results.Problem(
                        title: "Se genero un problema",
                        detail: "Uno o mas errores generados",
                        statusCode: StatusCodes.Status400BadRequest,
                        extensions: new Dictionary<string, object?>
                        {
                            ["errors"] = result.Errors.Select(x => x.ErrorMessage)
                        });
                }
            }

            return await next(context);
        }
    }

}
