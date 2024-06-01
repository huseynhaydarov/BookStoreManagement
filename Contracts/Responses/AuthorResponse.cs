﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record AuthorResponse
{
    public int Id { get; set; }
    public string Biography { get; set; }
}
