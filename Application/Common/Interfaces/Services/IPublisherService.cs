﻿using Contracts.Requests.OrderRequests;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IPublisherService
{
    Task<PublisherResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<PublisherResponse>> GetAllAsync(int pageSize, int pageNumber, CancellationToken token = default);

    Task<PublisherResponse> CreateAsync(CreatePublisherRequestModel request, CancellationToken token = default);

    Task UpdateAsync(int id, UpdatePublisherRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}
