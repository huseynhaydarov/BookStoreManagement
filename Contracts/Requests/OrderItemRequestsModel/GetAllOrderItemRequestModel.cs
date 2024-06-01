using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.OrderItemRequestsModel;

public record GetAllOrderItemRequestModel
{
    public IEnumerable<OrderItem> Items { get; init; } = Enumerable.Empty<OrderItem>();
}
