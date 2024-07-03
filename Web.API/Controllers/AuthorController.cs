using Application.Auhtors.Commands;
using Application.Auhtors.Queries;
using Application.Authors.Commands;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class AuthorController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.Author.Create)]
    public async Task<ActionResult<AuthorResponse>> Create([FromBody] CreateAuthorRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateAuthorRequestModel, CreateAuthorCommand>(request), token);
        return Ok(response);
    }


    [HttpGet(ApiEndpoints.Author.Get)]
    public async Task<ActionResult<AuthorResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetAuthorQuery(id));
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Author.GetAll)]
    public async Task<ActionResult<List<AuthorResponse>>> GetAll([FromQuery] GetAllAuthorRequestModel request, CancellationToken token)
    {
        var command = mapper.Map<GetAuthorsQuery>(request);

        var response = await mediator.Send(command, token);

        return Ok(response);
    }


    [HttpPut(ApiEndpoints.Author.Update)]
    public async Task<ActionResult<AuthorResponse>> Update([FromRoute] int id,
        [FromBody] UpdateAuthorRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateAuthorCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Author.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteAuthorCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}