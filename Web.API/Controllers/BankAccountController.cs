using Application.BankAccounts.Commands;
using Application.BankAccounts.Queries;
using Application.Books.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Services;
using Application.Common.Services;
using AutoMapper;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BankAccountRequests;
using Contracts.Requests.BookRequests;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]

public class BankAccountController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost(ApiEndpoints.BankAccount.Create)]
    public async Task<ActionResult<BankAccountResponse>> Create([FromBody] CreateBankAccountRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateBankAccountRequestModel, CreateBankAccountCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.BankAccount.Get)]
    public async Task<ActionResult<BankAccountResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetBankAccountQuery(id));
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.BankAccount.Update)]
    public async Task<ActionResult<BankAccountResponse>> Update([FromRoute] int id, [FromBody] UpdateBankAccountRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateBankAccountCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    //    [HttpDelete(ApiEndpoints.BankAccount.Delete)]
    //    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    //    {
    //        var response = await accountService.DeleteAsync(id, token);
    //        return Ok(response);
    //    }
    //}
}