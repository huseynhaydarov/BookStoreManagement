using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.CategoryRequests;

public record GetAllCategoryRequestModel
{
    public IEnumerable<Category> Items { get; init; } = Enumerable.Empty<Category>();
}
