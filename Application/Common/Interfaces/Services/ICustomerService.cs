using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomerResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<CustomerResponse>> GetAllAsync(CancellationToken token = default);

    Task<CustomerResponse> CreateAsync(CreateCustomerRequestModel request, CancellationToken token = default);

    Task UpdateAsync(UpdateCustomerRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}
