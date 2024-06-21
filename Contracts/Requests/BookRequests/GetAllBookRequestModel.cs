    using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.BookRequests;

public record GetAllBookRequestModel
{
    public IEnumerable<BookEntity> Items { get; init; } = Enumerable.Empty<BookEntity>();
}
