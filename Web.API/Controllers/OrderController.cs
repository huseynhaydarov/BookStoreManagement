using Application.Order.Commands;
using Application.Order.Queries;
using AutoMapper;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

public class OrderController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.Order.Create)]
    public async Task<ActionResult<OrderResponse>> Create([FromBody] CreateOrderRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateOrderRequestModel, CreateOrderCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Order.Get)]
    public async Task<ActionResult<OrderResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetOrderQuery(id));
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Order.GetAll)]
    public async Task<ActionResult<List<OrderResponse>>> GetAll([FromQuery] GetAllOrderRequestModel request, CancellationToken token)
    {
        var command = mapper.Map<GetOrdersQuery>(request);

        var response = await mediator.Send(command, token);

        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Order.Update)]
    public async Task<ActionResult<OrderResponse>> Update([FromRoute] int id,
        [FromBody] UpdateOrderRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateOrderCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Order.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteOrderCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}