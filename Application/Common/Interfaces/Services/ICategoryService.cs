using Contracts.Requests.BookRequests;
using Contracts.Requests.CategoryRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse?> GetAsync(int id, CancellationToken token = default);

        Task<List<CategoryResponse>> GetAllAsync(CancellationToken token = default);

        Task<CategoryResponse> CreateAsync(CreateCategoryRequestModel request, CancellationToken token = default);

        Task UpdateAsync(int id, UpdateCategoryRequestModel request, CancellationToken token = default);

        Task<bool> DeleteAsync(int id, CancellationToken token = default);
    }
}
