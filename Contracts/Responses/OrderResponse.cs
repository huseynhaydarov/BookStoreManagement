using Domain.Enum;

namespace Contracts.Responses;

public record OrderResponse
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }
}