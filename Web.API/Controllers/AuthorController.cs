using Application.Common.Interfaces.Services;
using Application.Common.Services;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.OrderRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]

public class AuhtorController(IAuthorService authorService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Author.Create)]
    public async Task<IActionResult> Create([FromBody] CreateAuthorRequestModel request, CancellationToken token)
    {
        var response = await authorService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.Author.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await authorService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Author.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await authorService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Author.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestModel request,
     CancellationToken token)
    {
        await authorService.UpdateAsync(id, request, token);
        return Ok();
    }

    [HttpDelete(ApiEndpoints.Author.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await authorService.DeleteAsync(id, token);
        return Ok(response);
    }
}
