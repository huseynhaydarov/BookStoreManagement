using Application.Books.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Services;
using Application.OrderItem.Commands;
using Application.OrderItem.Queries;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost(ApiEndpoints.OrderItem.Create)]
    public async Task<ActionResult<OrderItemResponse>> Create([FromBody] CreateOrderItemRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateOrderItemRequestModel, CreateOrderItemCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.OrderItem.Get)]
    public async Task<ActionResult<OrderItemResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetOrderItemQuery(id));
        return Ok(response);
    }

    //[HttpGet(ApiEndpoints.OrderItem.GetAll)]
    //public async Task<IActionResult> GetAll(CancellationToken token)
    //{
    //    var response = await orderItemService.GetAllAsync(token);
    //    return Ok(response);
    //}

    [HttpPut(ApiEndpoints.OrderItem.Update)]
    public async Task<ActionResult<OrderItemResponse>> Update([FromRoute] int id, [FromBody] UpdateOrderItemRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateOrderItemCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    //[HttpDelete(ApiEndpoints.OrderItem.Delete)]
    //public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    //{
    //    var response = await orderItemService.DeleteAsync(id, token);
    //    return Ok(response);
    //}
}