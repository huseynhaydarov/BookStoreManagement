﻿using Application.Books.Commands;
using Application.Books.Queries;
using Application.Commands.Book;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class BookController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    [HttpPost(ApiEndpoints.Book.Create)]
    public async Task<ActionResult<BookResponse>> Create([FromBody] CreateBookRequestsModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreateBookRequestsModel, CreateBookCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Book.Get)]
    public async Task<ActionResult<BookResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetBookQuery(id));
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Book.GetAll)]
    public async Task<ActionResult<List<BookResponse>>> GetAll([FromQuery] GetAllBookRequestModel request, CancellationToken token)
    {
        var command = mapper.Map<GetBooksQuery>(request);

        var response = await mediator.Send(command, token);

        return Ok(response);
    }

    [HttpPut(ApiEndpoints.Book.Update)]
    public async Task<ActionResult<BookResponse>> Update([FromRoute] int id, [FromBody] UpdateBookRequestModel request,
        CancellationToken token)
    {
        var command = _mapper.Map<UpdateBookCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Book.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeleteBookCommand { Id = id };
        var result = await _mediator.Send(command, token);

        if (result)
            return NoContent();
        return NotFound();
    }
}