using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record BookResponse
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int PageSize { get; set; }
    public int PublicationYear { get; set; }
    public int StockQuantity { get; set; }
    public string ISBN { get; set; }
    public BookType Type { get; set; }

    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }

}
