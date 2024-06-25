using Contracts.Requests.AuthorRequests;
using FluentValidation;

namespace Web.API.Validators.BookValidators;

public class GetBooksRequestValidator : AbstractValidator<GetAllAuthorRequestModel>
{
    public GetBooksRequestValidator()
    {
        RuleFor(b => b.Items)
            .NotEmpty()
            .NotNull();
    }
}

