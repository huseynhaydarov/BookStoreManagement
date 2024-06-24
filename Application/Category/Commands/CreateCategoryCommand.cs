using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Commands;

public record CreateCategoryCommand : CreateCategoryRequestModel, IRequest<CategoryResponse>
{
}

public class CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.CreateAsync(_mapper.Map<CategoryEntity>(request), cancellationToken);
        return _mapper.Map<CategoryResponse>(entity);
    }
}
