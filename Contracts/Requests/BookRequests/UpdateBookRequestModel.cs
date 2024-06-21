using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.BookRequests;

public class UpdateBookRequestModel
{
  
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int PageSize { get; init; }
    public int PublicationYear { get; init; }
    public int StockQuantity { get; init; }
    public string ISBN { get; init; }
    public string ImagePath { get; init; }
    public BookType Type { get; init; }

    public int AuthorId { get; init; }
    public int PublisherId { get; init; }
    public int CategoryId { get; init; }

}
