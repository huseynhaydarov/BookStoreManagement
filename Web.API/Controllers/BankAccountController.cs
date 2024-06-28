using Application.Auhtors.Queries;
using Application.BankAccounts.Commands;
using Application.BankAccounts.Queries;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BankAccountRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.BankAccount.Create)]
    public async Task<ActionResult<BankAccountResponse>> Create([FromBody] CreateBankAccountRequestModel request,
        CancellationToken token)
    {
        var response =
            await _mediator.Send(_mapper.Map<CreateBankAccountRequestModel, CreateBankAccountCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.BankAccount.Get)]
    public async Task<ActionResult<BankAccountResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetBankAccountQuery(id));
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.BankAccount.GetAll)]
    public async Task<ActionResult<List<BankAccountResponse>>> GetAll([FromQuery] GetAllBankAccountRequestModel request, CancellationToken token)
    {
        var command = mapper.Map<GetBankAccountsQuery>(request);

        var response = await mediator.Send(command, token);

        return Ok(response);
    }

    [HttpPut(ApiEndpoints.BankAccount.Update)]
    public async Task<ActionResult<BankAccountResponse>> Update([FromRoute] int id,
        [FromBody] UpdateBankAccountRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateBankAccountCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.BankAccount.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteBankAccountCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}