﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.BankAccountRequests;

public record UpdateBankAccountRequestModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }
}
