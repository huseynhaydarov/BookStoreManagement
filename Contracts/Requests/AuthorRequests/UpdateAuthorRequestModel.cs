﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.AuthorRequests;

public record UpdateAuthorRequestModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Biography { get; set; }
}
