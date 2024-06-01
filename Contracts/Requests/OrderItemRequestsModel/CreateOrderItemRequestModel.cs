﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.OrderItemRequestsModel;

public record CreateOrderItemRequestModel
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    public int OrderId { get; set; }
    public int BookId { get; set; }
}
