using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using MediatR;


namespace Application.Order.Queries;

public record GetOrdersQuery : GetAllOrderRequestModel, IRequest<IReadOnlyCollection<OrderResponse>>;

public class GetAuthorsQueryHandler(IMapper mapper, IAuthorRepository authorRepository)
    : IRequestHandler<GetOrdersQuery, IReadOnlyCollection<OrderResponse>>
{
    public async Task<IReadOnlyCollection<OrderResponse>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await authorRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<OrderResponse>>(authors);
    }
}
