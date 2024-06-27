using Application.Books.Commands;
using Application.Category.Commands;
using Application.Category.Queries;
using AutoMapper;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.Category.Create)]
    public async Task<ActionResult<CategoryResponse>> Create([FromBody] CreateCategoryRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateCategoryRequestModel, CreateCategoryCommand>(request),
            token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Category.Get)]
    public async Task<ActionResult<CategoryResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetCategoryQuery(id));
        return Ok(response);
    }

    //[HttpGet(ApiEndpoints.Category.GetAll)]
    //public async Task<IActionResult> GetAll(CancellationToken token)
    //{
    //    var response = await categoryService.GetAllAsync(token);
    //    return Ok(response);
    //}

    [HttpPut(ApiEndpoints.Category.Update)]
    public async Task<ActionResult<CategoryResponse>> Update([FromRoute] int id,
        [FromBody] UpdateCategoryRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateCategoryCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Category.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteBookCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}