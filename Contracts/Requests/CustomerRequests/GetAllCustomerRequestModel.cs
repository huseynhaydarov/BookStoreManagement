using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.CustomerRequests;

public record GetAllCustomerRequestModel
{
    public IEnumerable<CustomerEntity> Items { get; init; } = Enumerable.Empty<CustomerEntity>();
}
