using Application.Books.Commands;
using Application.Books.Queries;
using Application.Commands.Book;
using Application.Publishers.Commands;
using Application.Publishers.Queries;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost(ApiEndpoints.Publisher.Create)]
    public async Task<ActionResult<PublisherResponse>> Create([FromBody] CreatePublisherRequestModel request,
        CancellationToken token)
    {
        var response = await _mediator.Send(_mapper.Map<CreatePublisherRequestModel, CreatePublisherCommand>(request), token);
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Publisher.Get)]
    public async Task<ActionResult<PublisherResponse>> Get([FromRoute] int id, CancellationToken token)
    {
        var response = await _mediator.Send(new GetPublisherQuery(id));
        return Ok(response);
    }

    //[HttpGet(ApiEndpoints.Book.GetAll)]
    //public async Task<IActionResult> GetAll(CancellationToken token)
    //{
    //    var response = await bookService.GetAllAsync(token);
    //    return Ok(response);
    //}

    [HttpPut(ApiEndpoints.Publisher.Update)]
    public async Task<ActionResult<PublisherResponse>> Update([FromRoute] int id, [FromBody] UpdatePublisherRequestModel request, CancellationToken token)
    {
        var command = _mapper.Map<UpdatePublisherCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, token);
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Publisher.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var command = new DeletePublisherCommand { Id = id };
        bool result = await _mediator.Send(command, token);

        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}