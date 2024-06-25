using Contracts.Requests.PublisherRequests;
using FluentValidation;

namespace Web.API.Validators.PublisherValidators;

public class CreatePublisherRequestValidator : AbstractValidator<CreatePublisherRequestModel>
{
    public CreatePublisherRequestValidator()
    {
        RuleFor(p => p.Name)
           .NotEmpty()
           .WithMessage("Name must not be empty.")
           .MaximumLength(100)
           .WithMessage("Name cannot exceed 100 characters.");

        RuleFor(p => p.Address)
            .NotEmpty()
            .WithMessage("Address must not be empty.")
            .MaximumLength(500)
            .WithMessage("Address cannot exceed 500 characters.");

        RuleFor(p => p.Phone)
            .NotEmpty()
            .WithMessage("Phone must not be empty.")
            .Matches(@"^\d{10}$")
            .WithMessage("Phone must be exactly 10 digits.");

        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("Email must not be empty.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

    }
}
