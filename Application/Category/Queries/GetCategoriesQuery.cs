using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using MediatR;


namespace Application.Category.Queries;

public record GetCategoriesQuery : GetAllCategoryRequestModel, IRequest<IReadOnlyCollection<CategoryResponse>>;

public class GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<IReadOnlyCollection<CategoryResponse>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await categoryRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<CategoryResponse>>(authors);
    }
}
