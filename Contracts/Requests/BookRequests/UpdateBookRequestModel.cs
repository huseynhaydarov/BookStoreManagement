﻿using Domain.Enum;

namespace Contracts.Requests.BookRequests;

public record UpdateBookRequestModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int PublicationYear { get; set; }
    public int StockQuantity { get; set; }
    public string ISBN { get; set; }
    public string ImagePath { get; set; }
    public BookType Type { get; set; }

    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }
}