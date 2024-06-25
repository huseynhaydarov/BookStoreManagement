using Contracts.Requests.OrderItemRequestsModel;
using FluentValidation;

namespace Web.API.Validators.OrderItemValidators;

public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequestModel>
{
    public CreateOrderItemRequestValidator()
    {
        RuleFor(oi => oi.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");

        RuleFor(oi => oi.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.")
            .ScalePrecision(2, 18)
            .WithMessage("Price must not have more than 2 decimal places.");

        RuleFor(oi => oi.OrderId)
            .GreaterThan(0)
            .WithMessage("Order ID is required.");

        RuleFor(oi => oi.BookId)
            .GreaterThan(0)
            .WithMessage("Book ID is required.");
    }
}

