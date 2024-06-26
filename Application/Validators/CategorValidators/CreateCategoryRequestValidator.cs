using Contracts.Requests.CategoryRequests;
using FluentValidation;

namespace Web.API.Validators.CategorValidators;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestModel>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name must not be empty.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(c => c.Description)
            .MaximumLength(1000)
            .WithMessage("Description must not exceed 1000 characters.");
    }
}
