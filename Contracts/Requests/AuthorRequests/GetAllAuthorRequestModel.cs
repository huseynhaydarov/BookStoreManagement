using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.AuthorRequests;

public record GetAllAuthorRequestModel
{
    public IEnumerable<AuthorEntity> Items { get; init; } = Enumerable.Empty<AuthorEntity>();
}
