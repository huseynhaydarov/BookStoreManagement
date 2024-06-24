using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.PublisherRequests;

public record GetAllPublisherRequestModel
{
    public IEnumerable<PublisherEntity> Items { get; init; } = Enumerable.Empty<PublisherEntity>();
}
