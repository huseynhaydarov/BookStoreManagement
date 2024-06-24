using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Queries;

public class GetCategoryQuery(int id) : IRequest<CategoryResponse>
{
    public int Id = id;
}

public class GetCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository) :
    IRequestHandler<GetCategoryQuery, CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);

        if (category is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }
        mapper.Map(request, category);
        return _mapper.Map<CategoryEntity, CategoryResponse>(category);
    }
}

