using Domain.Enum;

namespace Contracts.Requests.OrderRequests;

public record UpdateOrderRequestModel
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }
}