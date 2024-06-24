using Application.Auhtors.Commands;
using Application.Auhtors.Queries;
using Application.Books.Queries;
using Application.Commands.Book;
using Application.Common.Interfaces.Services;
using Application.Common.Services;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BookRequests;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthorController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

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

    //    [HttpGet(ApiEndpoints.Author.GetAll)]
    //    public async Task<IActionResult> GetAll(CancellationToken token)
    //    {
    //        var response = await authorService.GetAllAsync(token);
    //        return Ok(response);
    //    }

    [HttpPut(ApiEndpoints.Author.Update)]
    public async Task<ActionResult<AuthorResponse>> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdateAuthorCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    //    [HttpDelete(ApiEndpoints.Author.Delete)]
    //    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    //    {
    //        var response = await authorService.DeleteAsync(id, token);
    //        return Ok(response);
    //    }
    //}
}
