using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Category.Commands;

public record UpdateCategoryCommand : UpdateCategoryRequestModel, IRequest<CategoryResponse>
{
    public int Id { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);

        if (category is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        _mapper.Map(request, category);
        category = await _categoryRepository.UpdateAsync(category);
        return _mapper.Map<CategoryEntity, CategoryResponse>(category);
    }
}