using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.BookRequests;

public record UpdateBookRequestModel
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

    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }

}
