using Application.Common.Interfaces.Services;
using Contracts.Requests.CustomerRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Customer.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequestModel request, CancellationToken token)
    {
        var response = await customerService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.Customer.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await customerService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Customer.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await customerService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Customer.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerRequestModel request,
        CancellationToken token)
    {
        var response = await customerService.UpdateAsync(request, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Customer.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await customerService.DeleteAsync(id, token);
        return Ok(response);
    }
}