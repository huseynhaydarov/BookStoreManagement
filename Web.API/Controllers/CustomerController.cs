using Application.Auhtors.Queries;
using Application.Customer.Commands;
using Application.Customer.Queries;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.Customer.Create)]
    public async Task<ActionResult<CustomerResponse>> Create([FromBody] CreateCustomerRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateCustomerRequestModel, CreateCustomerCommand>(request),
            token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Customer.Get)]
    public async Task<ActionResult<CustomerResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetCustomerQuery(id));
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Customer.GetAll)]
    public async Task<ActionResult<List<CustomerResponse>>> GetAll([FromQuery] GetAllCustomerRequestModel request, CancellationToken token)
    {
        var command = mapper.Map<GetCustomersQuery>(request);

        var response = await mediator.Send(command, token);

        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Customer.Update)]
    public async Task<ActionResult<CustomerResponse>> Update([FromRoute] int id,
        [FromBody] UpdateCustomerRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateCustomerCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Customer.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteCustomerCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}