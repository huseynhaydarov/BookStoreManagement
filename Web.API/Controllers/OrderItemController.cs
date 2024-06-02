using Application.Common.Interfaces.Services;
using Contracts.Requests.OrderItemRequestsModel;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController(IOrderItemService orderItemService) : ControllerBase
{
    [HttpPost(ApiEndpoints.OrderItem.Create)]
    public async Task<IActionResult> Create([FromBody] CreateOrderItemRequestModel request, CancellationToken token)
    {
        var response = await orderItemService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.OrderItem.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await orderItemService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.OrderItem.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await orderItemService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.OrderItem.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderItemRequestModel request,
        CancellationToken token)
    {
        await orderItemService.UpdateAsync(id, request, token);
        return Ok();
    }

    [HttpDelete(ApiEndpoints.OrderItem.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await orderItemService.DeleteAsync(id, token);
        return Ok(response);
    }
}