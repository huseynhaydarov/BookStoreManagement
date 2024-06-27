using Contracts.Requests.OrderRequests;
using FluentValidation;

namespace Web.API.Validators.OrderValidators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequestModel>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(o => o.OrderDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Order date must be in the past or present.");

        RuleFor(o => o.Status)
            .IsInEnum()
            .WithMessage("Invalid order status.");

        RuleFor(o => o.TotalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Total amount must be greater than or equal to 0.");


        RuleFor(o => o.CustomerId)
            .GreaterThan(0)
            .WithMessage("Customer id is required.");
    }
}