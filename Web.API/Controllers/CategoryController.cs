using Application.Common.Interfaces.Services;
using Contracts.Requests.CategoryRequests;
using Contracts.Requests.OrderRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Category.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequestModel request, CancellationToken token)
    {
        var response = await categoryService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.Category.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await categoryService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Category.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await categoryService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Category.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestModel request,
    CancellationToken token)
    {
        var response = await categoryService.UpdateAsync(request, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Category.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await categoryService.DeleteAsync(id, token);
        return Ok(response);
    }
}
