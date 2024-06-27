using Domain.Abstract;
using Domain.Enum;

namespace Domain.Entities;

public class BookEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int PageSize { get; set; }
    public int PublicationYear { get; set; }
    public int StockQuantity { get; set; }
    public string ISBN { get; set; }
    public string ImagePath { get; set; }
    public BookType Type { get; set; }

    public AuthorEntity Author { get; set; }
    public int AuthorId { get; set; }
    public PublisherEntity Publisher { get; set; }
    public int PublisherId { get; set; }
    public CategoryEntity Category { get; set; }
    public int CategoryId { get; set; }

    public virtual ICollection<OrderItemEntity> Items { get; set; }
}