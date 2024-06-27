using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Category.Commands;

public record CreateCategoryCommand : CreateCategoryRequestModel, IRequest<CategoryResponse>
{
}

public class CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.CreateAsync(_mapper.Map<CategoryEntity>(request), cancellationToken);
        return _mapper.Map<CategoryResponse>(entity);
    }
}