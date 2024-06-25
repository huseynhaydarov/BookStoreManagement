using Contracts.Requests.BankAccount;
using FluentValidation;

namespace Web.API.Validators.BankAccountValidators;

public class CreateBankAccountRequestValidator : AbstractValidator<CreateBankAccountRequestModel>
{
    public CreateBankAccountRequestValidator()
    {
        RuleFor(b => b.AccountNumber)
            .GreaterThan(0).WithMessage(" Account number should be a numeric type and  should has up to 6 numbers");

        RuleFor(b => b.CustomerId)
            .NotEmpty()
            .WithMessage("Category ID is required.");
    }
}


