namespace Contracts.Requests.OrderItemRequestsModel;

public record CreateOrderItemRequestModel
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public int OrderId { get; set; }
    public int BookId { get; set; }
}