using FluentValidation;
using static ManagerOrder.Features.Orders.Queries.GetOrderStatus;

namespace ManagerOrder.Features.Orders.Validations
{
    public class GetOrderStatusValidation : AbstractValidator<GetOrderStatusRequest>
    {
        public GetOrderStatusValidation()
        {
            RuleFor(x => x.numPedido)
                .NotEmpty().WithMessage("El número de pedido es requerido")
                .Must(n => n.ToString().Length >= 8)
                .WithMessage("El número de pedido debe contener minimo 8 digitos");

            RuleFor(x => x.cantidadPedido)
                .NotEmpty().WithMessage("La cantidad de pedido es requerido")
                .GreaterThan(0).WithMessage("La cantidad de pedido debe ser mayor a 0");

            RuleFor(x => x.codigoEAN)
                .NotEmpty().WithMessage("El codigoEAN es requerido");

            RuleFor(x => x.nombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es requerido");

            RuleFor(x => x.numDocumento)
                .NotEmpty().WithMessage("El número de documento es requerido")
                .GreaterThan(0).WithMessage("El número de documento debe ser mayor a 0");

            RuleFor(x => x.direccion)
                .NotEmpty().WithMessage("La dirección es requerido");
        }
    }
}
