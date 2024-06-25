using Contracts.Requests.AuthorRequests;
using Contracts.Validators.BookValidators;
using FluentValidation;

namespace Web.API.Validators.AuthorValidators;

public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequestModel>
{
    public CreateAuthorRequestValidator()
    {

        RuleFor(b => b.FullName)
            .MaximumLength(70)
            .NotEmpty()
            .WithMessage("Full name of Author required.")
            .NotNull();

        RuleFor(a => a.DateOfBirth)
            .LessThan(DateTime.Now)
            .WithMessage("Date of birth must be in the past.");

        RuleFor(a => a.Biography)
          .MaximumLength(1000)
          .WithMessage("Biography must not exceed 1000 characters.");

    }
}
