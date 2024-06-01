﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.CategoryRequests;

public record CreateCategoryRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
