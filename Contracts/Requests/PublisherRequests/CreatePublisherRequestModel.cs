﻿namespace Contracts.Requests.PublisherRequests;

public record CreatePublisherRequestModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}