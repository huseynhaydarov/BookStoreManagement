using Application.Common.Interfaces.Services;
using Contracts.Requests.BookRequests;
using Contracts.Requests.CustomerRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Book.Create)]
    public async Task<IActionResult> Create([FromBody] CreateBookRequestsModel request, CancellationToken token)
    {
        var response = await bookService.CreateAsync(request, token);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.Book.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await bookService.GetAsync(id, token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Book.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var response = await bookService.GetAllAsync(token);
        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Book.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestModel request,
        CancellationToken token)
    {
      await bookService.UpdateAsync(request, token);
        return Ok();
    }

    [HttpDelete(ApiEndpoints.Book.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await bookService.DeleteAsync(id, token);
        return Ok(response);
    }
}