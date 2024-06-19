    using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.BookRequests;

public record GetAllBookRequestModel
{
    public IEnumerable<Book> Items { get; init; } = Enumerable.Empty<Book>();
}
