namespace Contracts.Responses;

public record OrderItemResponse
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public int OrderId { get; set; }
    public int BookId { get; set; }
}