using Contracts.Requests.CustomerRequests;
using FluentValidation;

namespace Web.API.Validators.CustomerValidator;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequestModel>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(c => c.RegisteredDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Registered date must be in the past or present.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email must not be empty.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
    }
}
