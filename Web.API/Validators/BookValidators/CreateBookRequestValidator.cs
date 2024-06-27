using Contracts.Requests.BookRequests;
using FluentValidation;

namespace Contracts.Validators.BookValidators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequestsModel>
{
    public CreateBookRequestValidator()
    {
        RuleFor(b => b.Title)
            .MaximumLength(70)
            .NotEmpty()
            .WithMessage("Book name is required.")
            .NotNull();

        RuleFor(b => b.Description)
            .MaximumLength(300)
            .NotEmpty()
            .NotNull();

        RuleFor(b => b.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.")
            .ScalePrecision(2, 18)
            .WithMessage("Price must not have more than 2 decimal places");

        RuleFor(b => b.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than 0");

        RuleFor(b => b.PublicationYear)
            .InclusiveBetween(1800, DateTime.Now.Year)
            .WithMessage($"Year must be between 1800 and {DateTime.Now.Year}");

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required.")
            .NotNull();

        RuleFor(b => b.ImagePath);

        RuleFor(b => b.Type)
            .IsInEnum()
            .WithMessage("Invalid book type.");


        RuleFor(b => b.AuthorId)
            .NotEmpty()
            .WithMessage("Author ID is required.");

        RuleFor(b => b.PublisherId)
            .NotEmpty()
            .WithMessage("Publisher ID is required.");

        RuleFor(b => b.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");
    }
}