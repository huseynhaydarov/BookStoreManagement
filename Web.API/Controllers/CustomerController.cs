using Application.Books.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Services;
using Application.Customer.Commands;
using Application.Customer.Queries;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost(ApiEndpoints.Customer.Create)]
    public async Task<ActionResult<CustomerResponse>> Create([FromBody] CreateCustomerRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateCustomerRequestModel, CreateCustomerCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Customer.Get)]
    public async Task<ActionResult<CustomerResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetCustomerQuery(id));
        return Ok(response);
    }

    //[HttpGet(ApiEndpoints.Customer.GetAll)]
    //public async Task<IActionResult> GetAll(CancellationToken token)
    //{
    //    var response = await customerService.GetAllAsync(token);
    //    return Ok(response);
    //}

    [HttpPut(ApiEndpoints.Customer.Update)]
    public async Task<ActionResult<CustomerResponse>> Update([FromRoute] int id, [FromBody] UpdateCustomerRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateCustomerCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    //[HttpDelete(ApiEndpoints.Customer.Delete)]
    //public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    //{
    //    var response = await customerService.DeleteAsync(id, token);
    //    return Ok(response);
    //}
}