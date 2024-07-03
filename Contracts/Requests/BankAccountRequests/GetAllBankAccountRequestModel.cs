using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.BankAccountRequests;

public record GetAllBankAccountRequestModel : PagingParameters
{
}