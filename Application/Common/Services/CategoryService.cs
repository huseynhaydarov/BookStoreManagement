using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequestModel request, CancellationToken token = default)
    {
        var category = mapper.Map<Category>(request);
        var response = await categoryRepository.CreateAsync(category, token);
        return mapper.Map<CategoryResponse>(response);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        var category = await categoryRepository.GetAsync(id, token);

        if(category is null)
        {
            throw new NotFoundException(nameof(category), id);
        }
        return await categoryRepository.DeleteAsync(category, token);
    }

    public async Task<List<CategoryResponse>> GetAllAsync(CancellationToken token = default)
    {
        var response = await categoryRepository.GetAllAsync(token);
        return mapper.Map<List<CategoryResponse>>(response);
    }

    public async Task<CategoryResponse?> GetAsync(int id, CancellationToken token = default)
    {
        var response = await categoryRepository.GetAsync(id, token);

        if(response is null)
        {
            throw new NotFoundException(nameof(Category), id);
        }
        return mapper.Map<CategoryResponse>(response);
    }

    public async Task<bool> UpdateAsync(UpdateCategoryRequestModel request, CancellationToken token = default)
    {
        var category = await categoryRepository.GetAsync(request.Id, token);

        if(category is null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }
        category = mapper.Map<Category>(request);
        return await categoryRepository.UpdateAsync(category, token);
    }
}
